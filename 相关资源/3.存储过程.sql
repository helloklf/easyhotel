Use TavernManage
go
--客户入住酒店登记数据时执行
if exists (select * from sysobjects where name='Proc_ClientCheckIn')
	Drop procedure Proc_ClientCheckIn
GO
Create proc Proc_ClientCheckIn
@ClientIName Varchar(50),--姓名
@ClientCType int,--证件类型
@ClientIDCard varchar(50),--证件号
@ClientSex bit,--性别
@ClientAdress Varchar(50),--客户地址
@ClientTel varchar(30),--电话号码
@ClientVipID varchar(50),--VIP编号
@ClientAccount float ,--账户金额
@OperatorID varchar(50),--操作员ID
@RoomID varchar(50)--房间号
AS
		--检查房间号是否有效
		if ((select COUNT(*) from T_RoomList where RoomID=@RoomID and IsValid=1)<1)
			begin
				raiserror ('所提供的房间号无效！',16,0) with NOWAIT return
			end
		--检查VIP编号是否有效
		if(@ClientVipID is not null)
		begin
			if(@ClientVipID is not null and len(@ClientVipID)>0 and (select COUNT(*) from T_VIPInfo where VIPID=@ClientVipID and IsValid=1)<1)
				begin
					raiserror('提供的VIP编号不存在或已失效！',16,0) with NOWAIT return
				end
		end

			--客户档案操作
			declare @ClientGUID varchar(40)
				--检查是否已经存在该客户档案
				select @ClientGUID=[T_ClientInfo].[GUID] from T_ClientInfo where ClientCType=@ClientCType and ClientIDCard=@ClientIDCard  and ClientIName=@ClientIName
				if(@ClientGUID is null) --如果没有找到客户档案，创建新的档案
					begin
						insert into T_ClientInfo(ClientIName,ClientCType,ClientIDCard,ClientSex,ClientAdress,ClientTel,ClientVIPID)
						values(@ClientIName,@ClientCType,@ClientIDCard,@ClientSex,@ClientAdress,@ClientTel,@ClientVIPID)
						select @ClientGUID=[T_ClientInfo].[GUID] from T_ClientInfo where ClientCType=@ClientCType and ClientIDCard=@ClientIDCard  and ClientIName=@ClientIName
					end
				else
					begin --如果找到了，更新原有的数据
						update T_ClientInfo set ClientAdress=@ClientAdress,ClientTel=@ClientTel,ClientSex=@ClientSex,ClientVIPID=@ClientVipID where @ClientGUID=GUID
					end
	
			--检查是否为空房
			if((select StateName from T_RoomList join T_RoomStateType on T_RoomList.RoomState=T_RoomStateType.StateID where RoomID=@RoomID)!='空房'or
			(select COUNT(*) from T_ClientRoom where RoomID=@RoomID)>0)
				begin
					raiserror('客户信息已记录，但所选房间类型非“空房”，请重新选择一个空的房间！',16,0)
				end
			
			--根据VIP等级计算实际房间单价
			declare @RoomPrice int = (select TypePrice from T_RoomList join T_RoomType on T_RoomList.RoomType= T_RoomType.TypeID where RoomID=@RoomID)
				if(@ClientVipID is not null and len(@ClientVipID)>0)--如果输入的VIP编号有效，为房间收费实施优惠
				begin
					--查询会员积分
					declare @VIPIntegral int =( select VIPIntegral from T_VIPInfo where VIPID=@ClientVipID)
					--获得折扣率
					declare @VipPricce float =(select top 1 VipDiscount from T_VIPLevel where T_VIPLevel.LevelIntegral<=@VIPIntegral order by LevelIntegral desc)
					set @RoomPrice= @RoomPrice*(@VipPricce*0.01)--计算折后价
				end

			--检查金额是否足够一个单位时间的房费
			if(@ClientAccount<@RoomPrice)
				begin
					raiserror ('客户入住登记缴纳的金额，低于该类房间一个单位时间所需费用！',16,0) with nowait return
				end
				
			--获取操作类型ID
			declare @OID int =( select TypeID from T_OperateType where OperateName='入住登记' and IsValid=1 )
			--获取操作类型ID
			declare @OID2 int =( select TypeID from T_OperateType where OperateName='房费扣取' and IsValid=1 )
			--获取操作员GUID
			declare @OGUID varchar(40)= (select StaffGuid from T_StaffList where StaffID = @OperatorID)
			--获取房间状态"占用房"的类型编号
			declare @StateID int =(select StateID from T_RoomStateType where StateName='占用房' and IsValid=1)
			if(@StateID is null)
			begin
				raiserror('基础数据-房间状态“占用房”被禁用或修改，无法执行此操作，请联系管理员！',16,0) with nowait return
			end
			else if(@OID is null)
			begin
				raiserror('基础数据-操作类型“入住登记”被禁用或修改，无法执行此操作，请联系管理员！',16,0) with nowait return
			end
			else if(@OID2 is null)
			begin
				raiserror('基础数据-操作类型“房费扣取”被禁用或修改，无法执行此操作，请联系管理员！',16,0) with nowait return
			end
			else if(@OGUID is null)
			begin
				raiserror('你无权进行此操作，因为提供的操作员ID号无效，无法认证身份！',16,0) with nowait return
			end

			begin tran
			--写入账务历史记录(入住登记) 客户GUID、操作时间、操作金额、操作类型、操作员
			insert into T_AccountOld(ClientGUID,OperateTime,OperateMoney,OperatorTypeID,OperatorGUID) 
			values( @ClientGUID,GETDATE(),@ClientAccount,@OID,@OGUID )
			if(@@ERROR!=0)
			begin
				raiserror('客户档案已记录，但账务记录写入失败，操作撤销！',16,0) with nowait rollback return
			end

			--登记客户住房信息
			insert into T_ClientRoom(ClientGUID,ClientAccount,InTime,LastDeduct,OperatorGUID,RoomID)
			values( @ClientGUID,@ClientAccount,getdate(),GETDATE(),@OGUID,@RoomID)
			if(@@ERROR!=0)
			begin
				raiserror('登记客户住房信息失败，操作撤销！',16,0) with nowait rollback return
			end

			--修改房间状态
			update T_RoomList set RoomState=@StateID where RoomID=@RoomID and IsValid=1
			if(@@ERROR!=0)
			begin
				raiserror('修改房间状态失败，操作撤销！',16,0) with nowait rollback return
			end

			--写入扣费历史（房费扣取） 客户GUID、操作时间、操作金额、操作类型、操作员
			insert into T_AccountOld(ClientGUID,OperateTime,OperateMoney,OperatorTypeID,OperatorGUID)
			values( @ClientGUID,GETDATE(),-(@RoomPrice),@OID2,'System Auto Settle Accounts' )
			if(@@ERROR!=0)
			begin
				raiserror('账务记录历史写入失败，操作撤销！',16,0) with nowait rollback return
			end

			--扣取房费费
			update T_ClientRoom set ClientAccount=(ClientAccount-@RoomPrice),LastDeduct=GETDATE() where RoomID=@RoomID
			if(@@ERROR!=0)
			begin
				raiserror('房间费用扣取失败，操作撤销！',16,0) with nowait rollback return
			end

			--增加VIP积分
			update T_VIPInfo set VIPIntegral+=@ClientAccount where VIPID= 
				(select top(1) VIPID from T_ClientInfo join T_VIPInfo on T_ClientInfo.ClientVIPID=T_VIPInfo.VIPID where T_ClientInfo.GUID=@ClientGUID)
				if(@@ERROR!=0)
				begin
					raiserror('VIP积分操作失败，操作撤销！',16,0) with nowait rollback return
				end
			commit tran
go

--Exec Proc_ClientCheckIn





--房间预订存储过程
go
create proc Proc_BookRoom
@ClientName varchar(30),
@RoomID varchar(30),
@BookValidTime int
as
	if((select count(*) from T_RoomList join T_RoomStateType on T_RoomList.RoomState = T_RoomStateType.StateID 
		where RoomID=@RoomID and T_RoomList.IsValid=1 and StateName='空房')<1)
		begin
			raiserror('没有找到指定的房间，请刷新列表后从房间列表中选择一个空的房间',16,0) with nowait return
		end
	else
	begin
		declare @StateID int =(select StateID from T_RoomStateType where StateName='预订' and IsValid=1)
		if(@StateID is null)
		begin
			raiserror('数据库出现错误，房间状态类型“预订”被禁用或不存在！',16,0) return
		end
		begin tran
		update T_RoomList set RoomState=@StateID where RoomID = @RoomID
		if(@@ERROR!=0)
		begin
			raiserror('更新房间状态时出现错误，房间预订失败！',16,0) with nowait rollback return
		end
		
		insert into T_BookRoom(ClientName,RoomID,BookValidTime)
		values(@ClientName,@RoomID,@BookValidTime)
		if(@@ERROR!=0)
		begin
			raiserror('移除预订信息出错，可能输入的信息有误',16,0) with nowait rollback return
		end
		commit
	end

go



--存储过程，自动清除预订
create Proc Proc_AutoDeleteBook
as
	declare @StateID int =(select top(1) StateID from T_RoomStateType where StateName='空房' and IsValid=1)
	if(@StateID is null)
	begin
		raiserror('数据库出现错误，房间状态类型“空房”被禁用或不存在！',16,0) return
	end

	declare @StateID2 int =(select StateID from T_RoomStateType where StateName='预订' and IsValid=1)
	if(@StateID2 is null)
	begin
		raiserror('数据库出现错误，房间状态类型“预订”被禁用或不存在！',16,0) return
	end
	begin tran
	update T_RoomList set RoomState=@StateID where RoomState=@StateID2 and T_RoomList.IsValid=1 and RoomID
	 in(Select RoomID from T_BookRoom where dateadd(HOUR,(BookValidTime*24),GETDATE())>GETDATE())
	 if(@@ERROR!=0)
	 begin
		raiserror('清理失效预订过程中，修改房间状态时出现错误，操作撤销！',16,0) with nowait rollback return 
	 end
	 delete from T_BookRoom  where dateadd(HOUR,(BookValidTime*24),GETDATE())>GETDATE()if(@@ERROR!=0)
	 begin
		raiserror('清理失效预订过程中，删除失效预订记录时出现错误，操作撤销！',16,0) with nowait rollback return 
	 end
	 commit tran
go

 --select Count(*) from T_BookRoom  where dateadd(HOUR,(BookValidTime*24),GETDATE())>GETDATE() 

--取消房间预订
create proc Proc_DeleteBookRoom
@RoomID varchar(30)
as
	begin tran
	declare @StateID int =(select top(1) StateID from T_RoomStateType where StateName='空房' and IsValid=1)
	if(@StateID is null)
	begin
		raiserror('数据库出现错误，房间状态类型“空房”被禁用或不存在！',16,0) return
	end
	
	declare @StateID2 int =(select top(1) StateID from T_RoomStateType where StateName='预订' and IsValid=1)
	if(@StateID2 is null)
	begin
		raiserror('数据库出现错误，房间状态类型“预订”被禁用或不存在！',16,0) return
	end

	update T_RoomList set RoomState=@StateID where RoomID=@RoomID and RoomState=@StateID2
	if(@@ERROR!=0)
	begin
		raiserror('移除房间预订信息过程中，更改房间状态时错误',16,0) with nowait rollback return
	end
	delete from T_BookRoom where RoomID=@RoomID
	if(@@ERROR!=0)
	begin
		raiserror('移除房间预订信息过程中，删除预订信息时错误',16,0) with nowait rollback return
	end
	commit tran


go



--预订客户入住酒店登记数据时执行
if exists (select * from sysobjects where name='Proc_BookClientIn')
	Drop procedure Proc_BookClientIn
GO
Create proc Proc_BookClientIn
@ClientIName Varchar(50),--姓名
@ClientCType int,--证件类型
@ClientIDCard varchar(50),--证件号
@ClientSex bit,--性别
@ClientAdress Varchar(50),--客户地址
@ClientTel varchar(30),--电话号码
@ClientVipID varchar(50),--VIP编号
@ClientAccount float ,--账户金额
@OperatorID varchar(50),--操作员ID
@RoomID varchar(50)--房间号
AS
	begin tran
		exec Proc_DeleteBookRoom @RoomID
		if(@@ERROR!=0)
		begin
			raiserror('预订客户入住操作过程中，取消预定信息时出现错误，操作取消！',16,0) with nowait rollback return
		end
		exec Proc_ClientCheckIn @ClientIName,@ClientCType,@ClientIDCard,@ClientSex,@ClientAdress,@ClientTel,@ClientVipID,@ClientAccount,@OperatorID,@RoomID
		if(@@ERROR!=0)
		begin
			raiserror('预订客户入住操作过程中，记录客户入住信息时出现错误，操作取消！',16,0) with nowait rollback return
		end
	commit tran












--存储过程：客户退房

if exists (select * from sysobjects where name='Proc_ClientOut')
	Drop procedure Proc_ClientOut
GO
Create proc Proc_ClientOut
@RoomID varchar(50),--房间号
@OperatorID varchar(50)--操作员ID
as
begin
	declare @Money float--现金余额
	declare @GUID varchar(40)--客户编号
	declare @DataGUID varchar(40)--记录编号
	declare @LastDeduct datetime --上次结账时间
	declare @InTime datetime --入住时间
	declare @InOGUID varchar(40) --入住操作员
	select @Money=ClientAccount,@GUID=ClientGUID,@DataGUID=GUID,@LastDeduct =LastDeduct,@InTime=InTime,@InOGUID=OperatorGUID from T_ClientRoom where RoomID=@RoomID
		
	if(@DataGUID is null)
	begin
		raiserror('没有找到相关记录，所提供的房间号无效！',16,0) with nowait return
	end

	declare @Requency int
	select @Requency = (TypeRequency/60/1000/10000) From (select * from T_RoomList where IsValid = 1 ) tl join (select * from T_RoomType where IsValid=1) tr on tl.RoomType = tr.TypeID

	--select DATEDIFF(MS,GETDATE(),'2014-08-05')/3600.0/1000.0
	if(datediff(minute,DATEADD(MINUTE,@Requency,@LastDeduct),GETDATE())>5)
	begin
		raiserror('没有成功的退房结账，因为该客户还有其它一些费用没有收取，且已超过延迟结算时间（5分钟），请手动点击结算按钮以后再进行此操作！',16,0) with nowait return
	end
	
	--获取操作类型ID
	declare @OID int =( select TypeID from T_OperateType where OperateName='退房结账' and IsValid=1 )
	--获取操作员GUID
	declare @OGUID varchar(40)= (select StaffGuid from T_StaffList where StaffID = @OperatorID)
	--获取房间状态"脏房"的类型编号
	declare @StateID int =(select StateID from T_RoomStateType where StateName='脏房' and IsValid=1)
	if(@StateID is null)
		begin
			raiserror('基础数据-房间状态“脏房”被禁用或修改，无法执行此操作，请联系管理员！',16,0) with nowait return
		end
	else if(@OID is null)
		begin
			raiserror('基础数据-操作类型“退房结账”被禁用或修改，无法执行此操作，请联系管理员！',16,0) with nowait return
		end
	else if(@OGUID is null)
		begin
			raiserror('你无权进行此操作，因为提供的操作员ID号无效，无法认证身份！',16,0) with nowait return
		end

	--select * from T_AccountOld join T_OperateType on T_AccountOld.OperatorTypeID= T_OperateType.TypeID

	begin tran
		--写入账务历史记录
		insert into T_AccountOld(ClientGUID,OperateTime,OperateMoney,OperatorTypeID,OperatorGUID)
		values(@GUID,GETDATE(),-(@Money),@OID,@OGUID)
		if(@@ERROR!=0)
		begin
			raiserror('写入账务历史失败，操作被撤销',16,0)
			rollback
		end

		--select * from T_ClientRoomOld
		--写入客户住房历史
		insert into T_ClientRoomOld(ClientGUID,RoomID,CRinTime,CROutTime,OperatorOGUID,OperatorEGUID)
		values(@GUID,@RoomID,@InTime,GETDATE(),@InOGUID,@OGUID)
		if(@@ERROR!=0)
		begin
			raiserror('写入住房历史失败，操作被撤销',16,0)
			rollback return
		end

		--删除客户住房信息
		delete from T_ClientRoom where GUID=@DataGUID
		if(@@ERROR!=0)
		begin
			raiserror('删除历史记录失败，操作被撤销',16,0)
			rollback
		end

		--更新房间状态
		update T_RoomList set RoomState=@StateID where RoomID=@RoomID and IsValid =1
		if(@@ERROR!=0)
		begin
			raiserror('修改房间状态失败，操作被撤销',16,0)
			rollback
		end

		--扣除VIP积分
		update T_VIPInfo set VIPIntegral-=@Money where VIPID= 
			(select top(1) VIPID from T_ClientInfo join T_VIPInfo on T_ClientInfo.ClientVIPID=T_VIPInfo.VIPID where T_ClientInfo.GUID=@GUID)
		if(@@ERROR!=0)
		begin
			raiserror('VIP积分操作失败，操作撤销！',16,0) with nowait rollback return
		end

	commit tran

end




--存储过程：数据库自动结账

if exists(select * from sysobjects where name='view_charge')
	drop view view_charge
go

--存储过程：自动结账
create view View_Charge
as
select T_clientRoom.GUID,ClientAccount,LastDeduct,T_ClientRoom.RoomID,TypePrice,
'VipDiscount'=
case
	when VipDiscount  is null then 1
	else VipDiscount*0.01
end
,datediff(MINUTE,LastDeduct,GETDATE())/(TypeRequency/1000/10000/60) as 'Multiple'
	from T_ClientRoom join T_RoomList on T_ClientRoom.RoomID = T_RoomList.RoomID join T_RoomType on T_RoomList.RoomType=T_RoomType.TypeID left join 
	T_ClientInfo on T_ClientRoom.ClientGUID=T_ClientInfo.[GUID] left join
		(select VIPID,VIPIntegral,'VipDiscount'=(select top(1) VipDiscount from T_VIPLevel where T_VIPLevel.LevelIntegral<=VIPIntegral order by LevelIntegral desc) from T_VIPInfo)  vips 
		on T_ClientInfo.ClientVIPID= vips.VIPID

go

if exists (select * from sysobjects where name='Proc_AutoSettleAccounts')
	Drop procedure Proc_AutoSettleAccounts
GO
Create proc Proc_AutoSettleAccounts
as
begin

	--获取操作类型ID
	declare @OID int =( select TypeID from T_OperateType where OperateName='房费扣取' and IsValid=1 )
	if(@OID is null) --System Auto Settle Accounts
		begin
			raiserror('基础数据-操作类型“房费扣取”被禁用或修改，无法执行此操作，请联系管理员！',16,0) with nowait return
		end

		--查询所有VIP的等级
		--select VIPID,VIPIntegral,(select top(1) VipDiscount from T_VIPLevel where T_VIPLevel.LevelIntegral<=VIPIntegral order by LevelIntegral desc) from T_VIPInfo
		
		begin tran

			insert into T_AccountOld(ClientGUID,OperateTime,OperateMoney,OperatorTypeID,OperatorGUID)
			select [GUID],GETDATE(),-(Multiple*TypePrice*VipDiscount),1,'System Auto Settle Accounts' from View_Charge where Multiple>0
			if(@@ERROR!=0)
				begin
					raiserror('系统自动结账时写历史记录失败！操作被终止！',16,0) with nowait rollback return
				end
		
			update View_Charge set ClientAccount-=(Multiple*TypePrice*VipDiscount),LastDeduct=GETDATE() where Multiple>0
			if(@@ERROR!=0)
				begin 
					raiserror('系统自动结账时出现错误，操作撤销！',16,0) with nowait rollback return
				end
		commit tran
	end
go


--	exec Proc_AutoSettleAccounts --执行自动结账程序



go

--存储过程：读取账户欠费的房间账户
if exists (select * from sysobjects where name='Proc_AccountRemind')
	Drop procedure Proc_AccountRemind
	go
	create Proc Proc_AccountRemind
	as
	begin
		select T_ClientRoom.GUID,ClientIName,ClientAccount,LastDeduct,RoomID
		from T_ClientRoom join T_ClientInfo on T_ClientRoom.ClientGUID = T_ClientInfo.GUID where ClientAccount<0
	end

-- exec Proc_AccountRemind --查询欠费客户




go



--存储过程：客户换房操作

if exists(select * from sysobjects where name='proc_RoomChange')
	drop proc proc_RoomChange
go
create proc proc_RoomChange
@OperatorID varchar(50),--操作员工工号
@oldRoomID varchar(50),--原房间号
@newRoomID varchar(50)--要切换到的房间号
as
begin
	declare @Money float--现金余额
	declare @ClientGUID varchar(40)--客户编号
	declare @DataGUID varchar(40)--记录编号
	declare @LastDeduct datetime --上次结账时间
	declare @InTime datetime --入住时间
	declare @InOGUID varchar(40) --入住操作员
	select @Money=ClientAccount,@ClientGUID=ClientGUID,@DataGUID=GUID,@LastDeduct =LastDeduct,@InTime=InTime,@InOGUID=OperatorGUID 
	from T_ClientRoom where RoomID=@oldRoomID
	if(@DataGUID is null)
	begin
		raiserror('没有找到相关记录，所提供的房间号无效！',16,0) with nowait return
	end
	
	--检查要切换到的房间号是否有效
	if ((select COUNT(*) from T_RoomList where RoomID=@newRoomID and IsValid=1)<1)
		begin
			raiserror ('所提供的房间号无效，无法换到该房间！',16,0) with NOWAIT return
		end
	
	--检查要切换到的是否为空房
	if((select StateName from T_RoomList join T_RoomStateType on T_RoomList.RoomState=T_RoomStateType.StateID where RoomID=@newRoomID)!='空房'or
	(select COUNT(*) from T_ClientRoom where RoomID=@newRoomID)>0)
		begin
			raiserror('所选房间不是“空房”，请重新选择一个空的房间！',16,0)
		end


	declare @clientVIp varchar(50) =(select ClientVIPID from T_ClientInfo where [GUID]=@ClientGUID) --客户VIP编号
		
	declare @Requency int--结算频率
	select @Requency = (TypeRequency/60/1000/10000) From (select * from T_RoomList where IsValid = 1 ) tl
					 join (select * from T_RoomType where IsValid=1) tr on tl.RoomType = tr.TypeID

	if(datediff(minute,DATEADD(MINUTE,@Requency,@LastDeduct),GETDATE())>5)
	begin
		raiserror('没有成功的退房结账，因为该客户还有其它一些费用没有收取，且已超过延迟结算时间（5分钟），请手动结算后再进行此操作！',16,0) with nowait return
	end
	
	--获取操作‘退房结账’类型ID
	declare @OID int =( select TypeID from T_OperateType where OperateName='退房结账' and IsValid=1 )
	--获取操作员的GUID
	declare @OGUID varchar(40)= (select StaffGuid from T_StaffList where StaffID = @OperatorID)
	--获取房间状态"脏房"的类型编号
	declare @StateID int =(select StateID from T_RoomStateType where StateName='脏房' and IsValid=1)
	if(@StateID is null)
		begin
			raiserror('基础数据-房间状态“脏房”被禁用或修改，无法执行此操作，请联系管理员！',16,0) with nowait return
		end
	else if(@OID is null)
		begin
			raiserror('基础数据-操作类型“退房结账”被禁用或修改，无法执行此操作，请联系管理员！',16,0) with nowait return
		end
	else if(@OGUID is null)
		begin
			raiserror('你无权进行此操作，因为提供的操作员ID号无效，无法认证身份！',16,0) with nowait return
		end

	--获取操作类型“入住登记”ID
	declare @OID2 int =( select TypeID from T_OperateType where OperateName='入住登记' and IsValid=1 )
	--获取房间状态"占用房"的类型编号
	declare @StateID2 int =(select StateID from T_RoomStateType where StateName='占用房' and IsValid=1)
	if(@StateID2 is null)
	begin
		raiserror('基础数据-房间状态“占用房”被禁用或修改，无法执行此操作，请联系管理员！',16,0) with nowait return
	end
	else if(@OID2 is null)
	begin
		raiserror('基础数据-操作类型“入住登记”被禁用或修改，无法执行此操作，请联系管理员！',16,0) with nowait return
	end


	begin tran
		--写入账务历史记录:退房结账
		insert into T_AccountOld(ClientGUID,OperateTime,OperateMoney,OperatorTypeID,OperatorGUID)
		values(@ClientGUID,GETDATE(),-(@Money),@OID,@OGUID)
		if(@@ERROR!=0)
		begin
			raiserror('写入账务历史失败，处于资金安全考虑，操作被撤销',16,0)
			rollback return
		end

		--写入客户住房历史：客户GUID、入住时间、退房时间、入住登记员、退房登记员
		insert into T_ClientRoomOld(ClientGUID,RoomID,CRinTime,CROutTime,OperatorOGUID,OperatorEGUID)
		values(@ClientGUID,@oldRoomID,@InTime,GETDATE(),@InOGUID,@OGUID)
		if(@@ERROR!=0)
		begin
			raiserror('写入住房历史失败，所有操作已撤销',16,0)
			rollback return
		end

		--更新房间状态:将原房间改为脏房
		update T_RoomList set RoomState=@StateID where RoomID=@oldRoomID and IsValid =1
		if(@@ERROR!=0)
		begin
			raiserror('修改房间状态失败，所有操作已撤销',16,0)
			rollback return
		end

		--写入账务历史记录(入住登记) 客户GUID、操作时间、操作金额、操作类型、操作员
		insert into T_AccountOld(ClientGUID,OperateTime,OperateMoney,OperatorTypeID,OperatorGUID) values( @ClientGUID,GETDATE(),@Money,@OID2,@OGUID )
		if(@@ERROR!=0)
		begin
			raiserror('账务记录写入失败，所有操作已撤销！',16,0) with nowait rollback return
		end

		--修改房间状态：新房间改为占用房
		update T_RoomList set RoomState=@StateID2 where RoomID=@newRoomID and IsValid=1
		if(@@ERROR!=0)
		begin
			raiserror('修改房间状态(新)失败，所有操作已撤销！',16,0) with nowait rollback return
		end
		

		--修改客户住房信息：更改客户住房记录房号
		update T_ClientRoom set RoomID=@newRoomID where [GUID]=@DataGUID
		if(@@ERROR!=0)
		begin
			raiserror('修改客户房间号出错，所有操作已撤销',16,0)
			rollback return
		end

		commit tran

			
	--根据VIP等级计算实际房间单价
	declare @RoomPrice int = (select TypePrice from T_RoomList join T_RoomType on T_RoomList.RoomType= T_RoomType.TypeID where RoomID=@newRoomID)
		if(@clientVIp is not null and len(@clientVIp)>0)--如果输入的VIP编号有效，为房间收费实施优惠
		begin
			--查询会员积分
			declare @VIPIntegral int =( select VIPIntegral from T_VIPInfo where VIPID=@clientVIp)
			--获得折扣率
			declare @VipPricce float =(select top 1 VipDiscount from T_VIPLevel where T_VIPLevel.LevelIntegral<=@VIPIntegral order by LevelIntegral desc)
			set @RoomPrice= @RoomPrice*(@VipPricce*0.01)--计算折后价
		end

	--检查金额是否足够一个单位时间的房费
	if(@Money<@RoomPrice)
		begin
			declare @text varchar(100) ='客户账户余额已不足该类房间单次扣费，需在下次扣费前补交'+cast((@RoomPrice-@Money) as varchar(50))+'元'
		end
end





go



--禁用员工
if exists(select * from sysobjects where name='Proc_StaffResign')
	drop proc Proc_StaffResign
go
create proc Proc_StaffResign
@StaffID varchar(40)--员工
as
begin
	begin tran
	update T_StaffInfo set IsValid=0 where StaffID = @StaffID
	if(@@ERROR!=0)begin
		raiserror('出现错误，操作强制中断！',16,0) rollback return
	end
	delete from T_StaffList where StaffGuid=@StaffID
	if(@@ERROR!=0)begin
		raiserror('出现错误，操作强制中断！',16,0) rollback return
	end
	commit tran
end
go



create view View_RoomTypeCount --根据房间类型查询各类房间数量
as
	select TypeName ,'RCount'=COUNT(*) from T_RoomList join T_RoomType on T_RoomList.RoomType=T_RoomType.TypeID group by TypeName

--select Top (1) * from View_RoomTypeCount order by RCount --最少
--select Top (1) * from View_RoomTypeCount order by RCount desc --最多

--select StateID,StateName,TypeName 
--	from T_RoomList rl join T_RoomType rt on rl.RoomType=rt.TypeID Join T_RoomStateType ts on rl.RoomType= ts.StateID group by StateID,StateName,TypeName
go



--查询各类房间的空房数量、房间总数
if exists(select * from sysobjects where name='Proc_EmptyRoomCount')
	drop proc Proc_EmptyRoomCount
	go
create Proc Proc_EmptyRoomCount
as
	declare @StateID int = (select top 1 StateID from T_RoomStateType where StateName='空房' and IsValid=1)
	print @StateID
	select TypeName,eroom.RoomType,eroom.TypeCount as 'EmptyRoom',allroom.TypeCount as 'AllRoom' from 
	(select RoomType ,'TypeCount'= COUNT(RoomType) from T_RoomList rl where RoomState=@StateID group by RoomType) eroom right join
		(select RoomType ,'TypeCount'= COUNT(RoomType) from T_RoomList rl group by RoomType) allroom on eroom.RoomType= allroom.RoomType 
		join T_RoomType on eroom.RoomType= T_RoomType.TypeID
go

--exec Proc_EmptyRoomCount


--根据房间状态查询各种状态房间的数据
go
create view View_RoomStateCount
as
	select StateName,'RCount'=COUNT(StateName) from T_RoomList join T_RoomStateType on T_RoomList.RoomState=T_RoomStateType.StateID group by StateName
go



--查询住房历史记录
create view view_HousingHistory
as
select '记录编号'=ClientGUID,'房间编号'=RoomID,'入住时间'=CRinTime,'退房时间'=CROutTime,'入住登记'=staff.StaffName,'退房操作'=staff2.StaffName
 from T_ClientRoomOld ch join T_ClientInfo c on ch.ClientGUID=c.GUID join T_StaffInfo
  staff on ch.OperatorOGUID= staff.StaffID join  T_StaffInfo staff2 on ch.OperatorEGUID = staff2.StaffID

  go
  
	--select * from view_HousingHistory where 入住时间>= dateadd(MINUTE,-1440,GETDATE()) --当天
	--select * from view_HousingHistory where 入住时间>= dateadd(HOUR,-168,GETDATE()) --七天内
	--select * from view_HousingHistory where 入住时间>= dateadd(HOUR,-120960,GETDATE()) --30天内
	--select * from view_HousingHistory where 入住时间>= dateadd(DAY,-365,GETDATE()) --365天


  --消费历史记录
  create view view_ConsumeHistory
  as
  select '客户编号'=ClientGUID,'客户姓名'= ClientIName,'操作类型'=OperateName,'操作金额'=OperateMoney,'操作时间'=OperateTime,'客户名'=StaffName
   from T_AccountOld ta join T_ClientInfo ti on ta.ClientGUID=ti.GUID 
  join T_StaffInfo ts on ta.OperatorGUID = ts.StaffID join T_OperateType [to] on ta.OperatorTypeID= [to].TypeID
  
  
  go
  
  
  --select * from view_ConsumeHistory


--  select vc.ClientGUID,OperateTime,OperateMoney,OperatorTypeID,vc.OperatorGUID,OperateName,cr.RoomID,tcr.RoomID
--   from T_AccountOld vc join T_OperateType ot on vc.OperatorTypeID=ot.TypeID left join T_ClientRoomOld cr on vc.ClientGUID=cr.ClientGUID left join T_ClientRoom tcr
--    on vc.ClientGUID=tcr.ClientGUID
--	where DATEDIFF(HOUR, OperateTime,GETDATE())<=24 and DATEDIFF(HOUR, OperateTime,GETDATE())>=0 

--	select ClientGUID,RoomID,CRinTime,CROutTime,ClientIName from T_ClientRoomOld join T_ClientInfo on T_ClientRoomOld.ClientGUID=T_ClientInfo.GUID

--	select TA.ClientGUID,RoomID from T_ClientRoomOld right join T_AccountOld TA on T_ClientRoomOld.ClientGUID=TA.ClientGUID

--	select * from T_AccountOld

--select * from T_ClientRoom

	-- OperateName='房费扣取' and


--查询客户住房情况：中文列
go
--create view View_ClientRoomState
--as
--select tr.GUID as '数据序列',tr.ClientGUID as '客户序列',tr.ClientAccount as '账户余额',rt.TypeName as '房间类型',rt.TypePrice as '单价'
--	,cast((rt.TypeRequency/1000/3600/10000) as varchar(40))+'/小时' as '结账频率'
--	,tr.InTime as '入住时间',tr.LastDeduct as '上次结账',tr.OperatorGUID as '登记员工',tr.RoomID as '房间号',ti.ClientIName as '客户姓名'
-- from T_ClientRoom tr join T_ClientInfo ti on Tr.ClientGUID=ti.GUID join T_RoomList rl on tr.RoomID= rl.RoomID join T_RoomType rt on rl.RoomType=rt.TypeID

-- select * from View_ClientRoomState


 --查询客户住房情况：英文列
create view View_ClientRoomState
as
select tr.GUID as 'DataGUID',tr.ClientAccount
	,tr.InTime as 'InRoomTime',tr.LastDeduct,
	tr.RoomID as 'RoomID',ti.ClientIName as 'ClientName'
 from T_ClientRoom tr join T_ClientInfo ti on Tr.ClientGUID=ti.GUID 

-- select *  from T_ClientRoom 
