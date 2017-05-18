Use TavernManage
go
--�ͻ���ס�Ƶ�Ǽ�����ʱִ��
if exists (select * from sysobjects where name='Proc_ClientCheckIn')
	Drop procedure Proc_ClientCheckIn
GO
Create proc Proc_ClientCheckIn
@ClientIName Varchar(50),--����
@ClientCType int,--֤������
@ClientIDCard varchar(50),--֤����
@ClientSex bit,--�Ա�
@ClientAdress Varchar(50),--�ͻ���ַ
@ClientTel varchar(30),--�绰����
@ClientVipID varchar(50),--VIP���
@ClientAccount float ,--�˻����
@OperatorID varchar(50),--����ԱID
@RoomID varchar(50)--�����
AS
		--��鷿����Ƿ���Ч
		if ((select COUNT(*) from T_RoomList where RoomID=@RoomID and IsValid=1)<1)
			begin
				raiserror ('���ṩ�ķ������Ч��',16,0) with NOWAIT return
			end
		--���VIP����Ƿ���Ч
		if(@ClientVipID is not null)
		begin
			if(@ClientVipID is not null and len(@ClientVipID)>0 and (select COUNT(*) from T_VIPInfo where VIPID=@ClientVipID and IsValid=1)<1)
				begin
					raiserror('�ṩ��VIP��Ų����ڻ���ʧЧ��',16,0) with NOWAIT return
				end
		end

			--�ͻ���������
			declare @ClientGUID varchar(40)
				--����Ƿ��Ѿ����ڸÿͻ�����
				select @ClientGUID=[T_ClientInfo].[GUID] from T_ClientInfo where ClientCType=@ClientCType and ClientIDCard=@ClientIDCard  and ClientIName=@ClientIName
				if(@ClientGUID is null) --���û���ҵ��ͻ������������µĵ���
					begin
						insert into T_ClientInfo(ClientIName,ClientCType,ClientIDCard,ClientSex,ClientAdress,ClientTel,ClientVIPID)
						values(@ClientIName,@ClientCType,@ClientIDCard,@ClientSex,@ClientAdress,@ClientTel,@ClientVIPID)
						select @ClientGUID=[T_ClientInfo].[GUID] from T_ClientInfo where ClientCType=@ClientCType and ClientIDCard=@ClientIDCard  and ClientIName=@ClientIName
					end
				else
					begin --����ҵ��ˣ�����ԭ�е�����
						update T_ClientInfo set ClientAdress=@ClientAdress,ClientTel=@ClientTel,ClientSex=@ClientSex,ClientVIPID=@ClientVipID where @ClientGUID=GUID
					end
	
			--����Ƿ�Ϊ�շ�
			if((select StateName from T_RoomList join T_RoomStateType on T_RoomList.RoomState=T_RoomStateType.StateID where RoomID=@RoomID)!='�շ�'or
			(select COUNT(*) from T_ClientRoom where RoomID=@RoomID)>0)
				begin
					raiserror('�ͻ���Ϣ�Ѽ�¼������ѡ�������ͷǡ��շ�����������ѡ��һ���յķ��䣡',16,0)
				end
			
			--����VIP�ȼ�����ʵ�ʷ��䵥��
			declare @RoomPrice int = (select TypePrice from T_RoomList join T_RoomType on T_RoomList.RoomType= T_RoomType.TypeID where RoomID=@RoomID)
				if(@ClientVipID is not null and len(@ClientVipID)>0)--��������VIP�����Ч��Ϊ�����շ�ʵʩ�Ż�
				begin
					--��ѯ��Ա����
					declare @VIPIntegral int =( select VIPIntegral from T_VIPInfo where VIPID=@ClientVipID)
					--����ۿ���
					declare @VipPricce float =(select top 1 VipDiscount from T_VIPLevel where T_VIPLevel.LevelIntegral<=@VIPIntegral order by LevelIntegral desc)
					set @RoomPrice= @RoomPrice*(@VipPricce*0.01)--�����ۺ��
				end

			--������Ƿ��㹻һ����λʱ��ķ���
			if(@ClientAccount<@RoomPrice)
				begin
					raiserror ('�ͻ���ס�Ǽǽ��ɵĽ����ڸ��෿��һ����λʱ��������ã�',16,0) with nowait return
				end
				
			--��ȡ��������ID
			declare @OID int =( select TypeID from T_OperateType where OperateName='��ס�Ǽ�' and IsValid=1 )
			--��ȡ��������ID
			declare @OID2 int =( select TypeID from T_OperateType where OperateName='���ѿ�ȡ' and IsValid=1 )
			--��ȡ����ԱGUID
			declare @OGUID varchar(40)= (select StaffGuid from T_StaffList where StaffID = @OperatorID)
			--��ȡ����״̬"ռ�÷�"�����ͱ��
			declare @StateID int =(select StateID from T_RoomStateType where StateName='ռ�÷�' and IsValid=1)
			if(@StateID is null)
			begin
				raiserror('��������-����״̬��ռ�÷��������û��޸ģ��޷�ִ�д˲���������ϵ����Ա��',16,0) with nowait return
			end
			else if(@OID is null)
			begin
				raiserror('��������-�������͡���ס�Ǽǡ������û��޸ģ��޷�ִ�д˲���������ϵ����Ա��',16,0) with nowait return
			end
			else if(@OID2 is null)
			begin
				raiserror('��������-�������͡����ѿ�ȡ�������û��޸ģ��޷�ִ�д˲���������ϵ����Ա��',16,0) with nowait return
			end
			else if(@OGUID is null)
			begin
				raiserror('����Ȩ���д˲�������Ϊ�ṩ�Ĳ���ԱID����Ч���޷���֤��ݣ�',16,0) with nowait return
			end

			begin tran
			--д��������ʷ��¼(��ס�Ǽ�) �ͻ�GUID������ʱ�䡢�������������͡�����Ա
			insert into T_AccountOld(ClientGUID,OperateTime,OperateMoney,OperatorTypeID,OperatorGUID) 
			values( @ClientGUID,GETDATE(),@ClientAccount,@OID,@OGUID )
			if(@@ERROR!=0)
			begin
				raiserror('�ͻ������Ѽ�¼���������¼д��ʧ�ܣ�����������',16,0) with nowait rollback return
			end

			--�Ǽǿͻ�ס����Ϣ
			insert into T_ClientRoom(ClientGUID,ClientAccount,InTime,LastDeduct,OperatorGUID,RoomID)
			values( @ClientGUID,@ClientAccount,getdate(),GETDATE(),@OGUID,@RoomID)
			if(@@ERROR!=0)
			begin
				raiserror('�Ǽǿͻ�ס����Ϣʧ�ܣ�����������',16,0) with nowait rollback return
			end

			--�޸ķ���״̬
			update T_RoomList set RoomState=@StateID where RoomID=@RoomID and IsValid=1
			if(@@ERROR!=0)
			begin
				raiserror('�޸ķ���״̬ʧ�ܣ�����������',16,0) with nowait rollback return
			end

			--д��۷���ʷ�����ѿ�ȡ�� �ͻ�GUID������ʱ�䡢�������������͡�����Ա
			insert into T_AccountOld(ClientGUID,OperateTime,OperateMoney,OperatorTypeID,OperatorGUID)
			values( @ClientGUID,GETDATE(),-(@RoomPrice),@OID2,'System Auto Settle Accounts' )
			if(@@ERROR!=0)
			begin
				raiserror('�����¼��ʷд��ʧ�ܣ�����������',16,0) with nowait rollback return
			end

			--��ȡ���ѷ�
			update T_ClientRoom set ClientAccount=(ClientAccount-@RoomPrice),LastDeduct=GETDATE() where RoomID=@RoomID
			if(@@ERROR!=0)
			begin
				raiserror('������ÿ�ȡʧ�ܣ�����������',16,0) with nowait rollback return
			end

			--����VIP����
			update T_VIPInfo set VIPIntegral+=@ClientAccount where VIPID= 
				(select top(1) VIPID from T_ClientInfo join T_VIPInfo on T_ClientInfo.ClientVIPID=T_VIPInfo.VIPID where T_ClientInfo.GUID=@ClientGUID)
				if(@@ERROR!=0)
				begin
					raiserror('VIP���ֲ���ʧ�ܣ�����������',16,0) with nowait rollback return
				end
			commit tran
go

--Exec Proc_ClientCheckIn





--����Ԥ���洢����
go
create proc Proc_BookRoom
@ClientName varchar(30),
@RoomID varchar(30),
@BookValidTime int
as
	if((select count(*) from T_RoomList join T_RoomStateType on T_RoomList.RoomState = T_RoomStateType.StateID 
		where RoomID=@RoomID and T_RoomList.IsValid=1 and StateName='�շ�')<1)
		begin
			raiserror('û���ҵ�ָ���ķ��䣬��ˢ���б��ӷ����б���ѡ��һ���յķ���',16,0) with nowait return
		end
	else
	begin
		declare @StateID int =(select StateID from T_RoomStateType where StateName='Ԥ��' and IsValid=1)
		if(@StateID is null)
		begin
			raiserror('���ݿ���ִ��󣬷���״̬���͡�Ԥ���������û򲻴��ڣ�',16,0) return
		end
		begin tran
		update T_RoomList set RoomState=@StateID where RoomID = @RoomID
		if(@@ERROR!=0)
		begin
			raiserror('���·���״̬ʱ���ִ��󣬷���Ԥ��ʧ�ܣ�',16,0) with nowait rollback return
		end
		
		insert into T_BookRoom(ClientName,RoomID,BookValidTime)
		values(@ClientName,@RoomID,@BookValidTime)
		if(@@ERROR!=0)
		begin
			raiserror('�Ƴ�Ԥ����Ϣ���������������Ϣ����',16,0) with nowait rollback return
		end
		commit
	end

go



--�洢���̣��Զ����Ԥ��
create Proc Proc_AutoDeleteBook
as
	declare @StateID int =(select top(1) StateID from T_RoomStateType where StateName='�շ�' and IsValid=1)
	if(@StateID is null)
	begin
		raiserror('���ݿ���ִ��󣬷���״̬���͡��շ��������û򲻴��ڣ�',16,0) return
	end

	declare @StateID2 int =(select StateID from T_RoomStateType where StateName='Ԥ��' and IsValid=1)
	if(@StateID2 is null)
	begin
		raiserror('���ݿ���ִ��󣬷���״̬���͡�Ԥ���������û򲻴��ڣ�',16,0) return
	end
	begin tran
	update T_RoomList set RoomState=@StateID where RoomState=@StateID2 and T_RoomList.IsValid=1 and RoomID
	 in(Select RoomID from T_BookRoom where dateadd(HOUR,(BookValidTime*24),GETDATE())>GETDATE())
	 if(@@ERROR!=0)
	 begin
		raiserror('����ʧЧԤ�������У��޸ķ���״̬ʱ���ִ��󣬲���������',16,0) with nowait rollback return 
	 end
	 delete from T_BookRoom  where dateadd(HOUR,(BookValidTime*24),GETDATE())>GETDATE()if(@@ERROR!=0)
	 begin
		raiserror('����ʧЧԤ�������У�ɾ��ʧЧԤ����¼ʱ���ִ��󣬲���������',16,0) with nowait rollback return 
	 end
	 commit tran
go

 --select Count(*) from T_BookRoom  where dateadd(HOUR,(BookValidTime*24),GETDATE())>GETDATE() 

--ȡ������Ԥ��
create proc Proc_DeleteBookRoom
@RoomID varchar(30)
as
	begin tran
	declare @StateID int =(select top(1) StateID from T_RoomStateType where StateName='�շ�' and IsValid=1)
	if(@StateID is null)
	begin
		raiserror('���ݿ���ִ��󣬷���״̬���͡��շ��������û򲻴��ڣ�',16,0) return
	end
	
	declare @StateID2 int =(select top(1) StateID from T_RoomStateType where StateName='Ԥ��' and IsValid=1)
	if(@StateID2 is null)
	begin
		raiserror('���ݿ���ִ��󣬷���״̬���͡�Ԥ���������û򲻴��ڣ�',16,0) return
	end

	update T_RoomList set RoomState=@StateID where RoomID=@RoomID and RoomState=@StateID2
	if(@@ERROR!=0)
	begin
		raiserror('�Ƴ�����Ԥ����Ϣ�����У����ķ���״̬ʱ����',16,0) with nowait rollback return
	end
	delete from T_BookRoom where RoomID=@RoomID
	if(@@ERROR!=0)
	begin
		raiserror('�Ƴ�����Ԥ����Ϣ�����У�ɾ��Ԥ����Ϣʱ����',16,0) with nowait rollback return
	end
	commit tran


go



--Ԥ���ͻ���ס�Ƶ�Ǽ�����ʱִ��
if exists (select * from sysobjects where name='Proc_BookClientIn')
	Drop procedure Proc_BookClientIn
GO
Create proc Proc_BookClientIn
@ClientIName Varchar(50),--����
@ClientCType int,--֤������
@ClientIDCard varchar(50),--֤����
@ClientSex bit,--�Ա�
@ClientAdress Varchar(50),--�ͻ���ַ
@ClientTel varchar(30),--�绰����
@ClientVipID varchar(50),--VIP���
@ClientAccount float ,--�˻����
@OperatorID varchar(50),--����ԱID
@RoomID varchar(50)--�����
AS
	begin tran
		exec Proc_DeleteBookRoom @RoomID
		if(@@ERROR!=0)
		begin
			raiserror('Ԥ���ͻ���ס���������У�ȡ��Ԥ����Ϣʱ���ִ��󣬲���ȡ����',16,0) with nowait rollback return
		end
		exec Proc_ClientCheckIn @ClientIName,@ClientCType,@ClientIDCard,@ClientSex,@ClientAdress,@ClientTel,@ClientVipID,@ClientAccount,@OperatorID,@RoomID
		if(@@ERROR!=0)
		begin
			raiserror('Ԥ���ͻ���ס���������У���¼�ͻ���ס��Ϣʱ���ִ��󣬲���ȡ����',16,0) with nowait rollback return
		end
	commit tran












--�洢���̣��ͻ��˷�

if exists (select * from sysobjects where name='Proc_ClientOut')
	Drop procedure Proc_ClientOut
GO
Create proc Proc_ClientOut
@RoomID varchar(50),--�����
@OperatorID varchar(50)--����ԱID
as
begin
	declare @Money float--�ֽ����
	declare @GUID varchar(40)--�ͻ����
	declare @DataGUID varchar(40)--��¼���
	declare @LastDeduct datetime --�ϴν���ʱ��
	declare @InTime datetime --��סʱ��
	declare @InOGUID varchar(40) --��ס����Ա
	select @Money=ClientAccount,@GUID=ClientGUID,@DataGUID=GUID,@LastDeduct =LastDeduct,@InTime=InTime,@InOGUID=OperatorGUID from T_ClientRoom where RoomID=@RoomID
		
	if(@DataGUID is null)
	begin
		raiserror('û���ҵ���ؼ�¼�����ṩ�ķ������Ч��',16,0) with nowait return
	end

	declare @Requency int
	select @Requency = (TypeRequency/60/1000/10000) From (select * from T_RoomList where IsValid = 1 ) tl join (select * from T_RoomType where IsValid=1) tr on tl.RoomType = tr.TypeID

	--select DATEDIFF(MS,GETDATE(),'2014-08-05')/3600.0/1000.0
	if(datediff(minute,DATEADD(MINUTE,@Requency,@LastDeduct),GETDATE())>5)
	begin
		raiserror('û�гɹ����˷����ˣ���Ϊ�ÿͻ���������һЩ����û����ȡ�����ѳ����ӳٽ���ʱ�䣨5���ӣ������ֶ�������㰴ť�Ժ��ٽ��д˲�����',16,0) with nowait return
	end
	
	--��ȡ��������ID
	declare @OID int =( select TypeID from T_OperateType where OperateName='�˷�����' and IsValid=1 )
	--��ȡ����ԱGUID
	declare @OGUID varchar(40)= (select StaffGuid from T_StaffList where StaffID = @OperatorID)
	--��ȡ����״̬"�෿"�����ͱ��
	declare @StateID int =(select StateID from T_RoomStateType where StateName='�෿' and IsValid=1)
	if(@StateID is null)
		begin
			raiserror('��������-����״̬���෿�������û��޸ģ��޷�ִ�д˲���������ϵ����Ա��',16,0) with nowait return
		end
	else if(@OID is null)
		begin
			raiserror('��������-�������͡��˷����ˡ������û��޸ģ��޷�ִ�д˲���������ϵ����Ա��',16,0) with nowait return
		end
	else if(@OGUID is null)
		begin
			raiserror('����Ȩ���д˲�������Ϊ�ṩ�Ĳ���ԱID����Ч���޷���֤��ݣ�',16,0) with nowait return
		end

	--select * from T_AccountOld join T_OperateType on T_AccountOld.OperatorTypeID= T_OperateType.TypeID

	begin tran
		--д��������ʷ��¼
		insert into T_AccountOld(ClientGUID,OperateTime,OperateMoney,OperatorTypeID,OperatorGUID)
		values(@GUID,GETDATE(),-(@Money),@OID,@OGUID)
		if(@@ERROR!=0)
		begin
			raiserror('д��������ʷʧ�ܣ�����������',16,0)
			rollback
		end

		--select * from T_ClientRoomOld
		--д��ͻ�ס����ʷ
		insert into T_ClientRoomOld(ClientGUID,RoomID,CRinTime,CROutTime,OperatorOGUID,OperatorEGUID)
		values(@GUID,@RoomID,@InTime,GETDATE(),@InOGUID,@OGUID)
		if(@@ERROR!=0)
		begin
			raiserror('д��ס����ʷʧ�ܣ�����������',16,0)
			rollback return
		end

		--ɾ���ͻ�ס����Ϣ
		delete from T_ClientRoom where GUID=@DataGUID
		if(@@ERROR!=0)
		begin
			raiserror('ɾ����ʷ��¼ʧ�ܣ�����������',16,0)
			rollback
		end

		--���·���״̬
		update T_RoomList set RoomState=@StateID where RoomID=@RoomID and IsValid =1
		if(@@ERROR!=0)
		begin
			raiserror('�޸ķ���״̬ʧ�ܣ�����������',16,0)
			rollback
		end

		--�۳�VIP����
		update T_VIPInfo set VIPIntegral-=@Money where VIPID= 
			(select top(1) VIPID from T_ClientInfo join T_VIPInfo on T_ClientInfo.ClientVIPID=T_VIPInfo.VIPID where T_ClientInfo.GUID=@GUID)
		if(@@ERROR!=0)
		begin
			raiserror('VIP���ֲ���ʧ�ܣ�����������',16,0) with nowait rollback return
		end

	commit tran

end




--�洢���̣����ݿ��Զ�����

if exists(select * from sysobjects where name='view_charge')
	drop view view_charge
go

--�洢���̣��Զ�����
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

	--��ȡ��������ID
	declare @OID int =( select TypeID from T_OperateType where OperateName='���ѿ�ȡ' and IsValid=1 )
	if(@OID is null) --System Auto Settle Accounts
		begin
			raiserror('��������-�������͡����ѿ�ȡ�������û��޸ģ��޷�ִ�д˲���������ϵ����Ա��',16,0) with nowait return
		end

		--��ѯ����VIP�ĵȼ�
		--select VIPID,VIPIntegral,(select top(1) VipDiscount from T_VIPLevel where T_VIPLevel.LevelIntegral<=VIPIntegral order by LevelIntegral desc) from T_VIPInfo
		
		begin tran

			insert into T_AccountOld(ClientGUID,OperateTime,OperateMoney,OperatorTypeID,OperatorGUID)
			select [GUID],GETDATE(),-(Multiple*TypePrice*VipDiscount),1,'System Auto Settle Accounts' from View_Charge where Multiple>0
			if(@@ERROR!=0)
				begin
					raiserror('ϵͳ�Զ�����ʱд��ʷ��¼ʧ�ܣ���������ֹ��',16,0) with nowait rollback return
				end
		
			update View_Charge set ClientAccount-=(Multiple*TypePrice*VipDiscount),LastDeduct=GETDATE() where Multiple>0
			if(@@ERROR!=0)
				begin 
					raiserror('ϵͳ�Զ�����ʱ���ִ��󣬲���������',16,0) with nowait rollback return
				end
		commit tran
	end
go


--	exec Proc_AutoSettleAccounts --ִ���Զ����˳���



go

--�洢���̣���ȡ�˻�Ƿ�ѵķ����˻�
if exists (select * from sysobjects where name='Proc_AccountRemind')
	Drop procedure Proc_AccountRemind
	go
	create Proc Proc_AccountRemind
	as
	begin
		select T_ClientRoom.GUID,ClientIName,ClientAccount,LastDeduct,RoomID
		from T_ClientRoom join T_ClientInfo on T_ClientRoom.ClientGUID = T_ClientInfo.GUID where ClientAccount<0
	end

-- exec Proc_AccountRemind --��ѯǷ�ѿͻ�




go



--�洢���̣��ͻ���������

if exists(select * from sysobjects where name='proc_RoomChange')
	drop proc proc_RoomChange
go
create proc proc_RoomChange
@OperatorID varchar(50),--����Ա������
@oldRoomID varchar(50),--ԭ�����
@newRoomID varchar(50)--Ҫ�л����ķ����
as
begin
	declare @Money float--�ֽ����
	declare @ClientGUID varchar(40)--�ͻ����
	declare @DataGUID varchar(40)--��¼���
	declare @LastDeduct datetime --�ϴν���ʱ��
	declare @InTime datetime --��סʱ��
	declare @InOGUID varchar(40) --��ס����Ա
	select @Money=ClientAccount,@ClientGUID=ClientGUID,@DataGUID=GUID,@LastDeduct =LastDeduct,@InTime=InTime,@InOGUID=OperatorGUID 
	from T_ClientRoom where RoomID=@oldRoomID
	if(@DataGUID is null)
	begin
		raiserror('û���ҵ���ؼ�¼�����ṩ�ķ������Ч��',16,0) with nowait return
	end
	
	--���Ҫ�л����ķ�����Ƿ���Ч
	if ((select COUNT(*) from T_RoomList where RoomID=@newRoomID and IsValid=1)<1)
		begin
			raiserror ('���ṩ�ķ������Ч���޷������÷��䣡',16,0) with NOWAIT return
		end
	
	--���Ҫ�л������Ƿ�Ϊ�շ�
	if((select StateName from T_RoomList join T_RoomStateType on T_RoomList.RoomState=T_RoomStateType.StateID where RoomID=@newRoomID)!='�շ�'or
	(select COUNT(*) from T_ClientRoom where RoomID=@newRoomID)>0)
		begin
			raiserror('��ѡ���䲻�ǡ��շ�����������ѡ��һ���յķ��䣡',16,0)
		end


	declare @clientVIp varchar(50) =(select ClientVIPID from T_ClientInfo where [GUID]=@ClientGUID) --�ͻ�VIP���
		
	declare @Requency int--����Ƶ��
	select @Requency = (TypeRequency/60/1000/10000) From (select * from T_RoomList where IsValid = 1 ) tl
					 join (select * from T_RoomType where IsValid=1) tr on tl.RoomType = tr.TypeID

	if(datediff(minute,DATEADD(MINUTE,@Requency,@LastDeduct),GETDATE())>5)
	begin
		raiserror('û�гɹ����˷����ˣ���Ϊ�ÿͻ���������һЩ����û����ȡ�����ѳ����ӳٽ���ʱ�䣨5���ӣ������ֶ�������ٽ��д˲�����',16,0) with nowait return
	end
	
	--��ȡ�������˷����ˡ�����ID
	declare @OID int =( select TypeID from T_OperateType where OperateName='�˷�����' and IsValid=1 )
	--��ȡ����Ա��GUID
	declare @OGUID varchar(40)= (select StaffGuid from T_StaffList where StaffID = @OperatorID)
	--��ȡ����״̬"�෿"�����ͱ��
	declare @StateID int =(select StateID from T_RoomStateType where StateName='�෿' and IsValid=1)
	if(@StateID is null)
		begin
			raiserror('��������-����״̬���෿�������û��޸ģ��޷�ִ�д˲���������ϵ����Ա��',16,0) with nowait return
		end
	else if(@OID is null)
		begin
			raiserror('��������-�������͡��˷����ˡ������û��޸ģ��޷�ִ�д˲���������ϵ����Ա��',16,0) with nowait return
		end
	else if(@OGUID is null)
		begin
			raiserror('����Ȩ���д˲�������Ϊ�ṩ�Ĳ���ԱID����Ч���޷���֤��ݣ�',16,0) with nowait return
		end

	--��ȡ�������͡���ס�Ǽǡ�ID
	declare @OID2 int =( select TypeID from T_OperateType where OperateName='��ס�Ǽ�' and IsValid=1 )
	--��ȡ����״̬"ռ�÷�"�����ͱ��
	declare @StateID2 int =(select StateID from T_RoomStateType where StateName='ռ�÷�' and IsValid=1)
	if(@StateID2 is null)
	begin
		raiserror('��������-����״̬��ռ�÷��������û��޸ģ��޷�ִ�д˲���������ϵ����Ա��',16,0) with nowait return
	end
	else if(@OID2 is null)
	begin
		raiserror('��������-�������͡���ס�Ǽǡ������û��޸ģ��޷�ִ�д˲���������ϵ����Ա��',16,0) with nowait return
	end


	begin tran
		--д��������ʷ��¼:�˷�����
		insert into T_AccountOld(ClientGUID,OperateTime,OperateMoney,OperatorTypeID,OperatorGUID)
		values(@ClientGUID,GETDATE(),-(@Money),@OID,@OGUID)
		if(@@ERROR!=0)
		begin
			raiserror('д��������ʷʧ�ܣ������ʽ�ȫ���ǣ�����������',16,0)
			rollback return
		end

		--д��ͻ�ס����ʷ���ͻ�GUID����סʱ�䡢�˷�ʱ�䡢��ס�Ǽ�Ա���˷��Ǽ�Ա
		insert into T_ClientRoomOld(ClientGUID,RoomID,CRinTime,CROutTime,OperatorOGUID,OperatorEGUID)
		values(@ClientGUID,@oldRoomID,@InTime,GETDATE(),@InOGUID,@OGUID)
		if(@@ERROR!=0)
		begin
			raiserror('д��ס����ʷʧ�ܣ����в����ѳ���',16,0)
			rollback return
		end

		--���·���״̬:��ԭ�����Ϊ�෿
		update T_RoomList set RoomState=@StateID where RoomID=@oldRoomID and IsValid =1
		if(@@ERROR!=0)
		begin
			raiserror('�޸ķ���״̬ʧ�ܣ����в����ѳ���',16,0)
			rollback return
		end

		--д��������ʷ��¼(��ס�Ǽ�) �ͻ�GUID������ʱ�䡢�������������͡�����Ա
		insert into T_AccountOld(ClientGUID,OperateTime,OperateMoney,OperatorTypeID,OperatorGUID) values( @ClientGUID,GETDATE(),@Money,@OID2,@OGUID )
		if(@@ERROR!=0)
		begin
			raiserror('�����¼д��ʧ�ܣ����в����ѳ�����',16,0) with nowait rollback return
		end

		--�޸ķ���״̬���·����Ϊռ�÷�
		update T_RoomList set RoomState=@StateID2 where RoomID=@newRoomID and IsValid=1
		if(@@ERROR!=0)
		begin
			raiserror('�޸ķ���״̬(��)ʧ�ܣ����в����ѳ�����',16,0) with nowait rollback return
		end
		

		--�޸Ŀͻ�ס����Ϣ�����Ŀͻ�ס����¼����
		update T_ClientRoom set RoomID=@newRoomID where [GUID]=@DataGUID
		if(@@ERROR!=0)
		begin
			raiserror('�޸Ŀͻ�����ų������в����ѳ���',16,0)
			rollback return
		end

		commit tran

			
	--����VIP�ȼ�����ʵ�ʷ��䵥��
	declare @RoomPrice int = (select TypePrice from T_RoomList join T_RoomType on T_RoomList.RoomType= T_RoomType.TypeID where RoomID=@newRoomID)
		if(@clientVIp is not null and len(@clientVIp)>0)--��������VIP�����Ч��Ϊ�����շ�ʵʩ�Ż�
		begin
			--��ѯ��Ա����
			declare @VIPIntegral int =( select VIPIntegral from T_VIPInfo where VIPID=@clientVIp)
			--����ۿ���
			declare @VipPricce float =(select top 1 VipDiscount from T_VIPLevel where T_VIPLevel.LevelIntegral<=@VIPIntegral order by LevelIntegral desc)
			set @RoomPrice= @RoomPrice*(@VipPricce*0.01)--�����ۺ��
		end

	--������Ƿ��㹻һ����λʱ��ķ���
	if(@Money<@RoomPrice)
		begin
			declare @text varchar(100) ='�ͻ��˻�����Ѳ�����෿�䵥�ο۷ѣ������´ο۷�ǰ����'+cast((@RoomPrice-@Money) as varchar(50))+'Ԫ'
		end
end





go



--����Ա��
if exists(select * from sysobjects where name='Proc_StaffResign')
	drop proc Proc_StaffResign
go
create proc Proc_StaffResign
@StaffID varchar(40)--Ա��
as
begin
	begin tran
	update T_StaffInfo set IsValid=0 where StaffID = @StaffID
	if(@@ERROR!=0)begin
		raiserror('���ִ��󣬲���ǿ���жϣ�',16,0) rollback return
	end
	delete from T_StaffList where StaffGuid=@StaffID
	if(@@ERROR!=0)begin
		raiserror('���ִ��󣬲���ǿ���жϣ�',16,0) rollback return
	end
	commit tran
end
go



create view View_RoomTypeCount --���ݷ������Ͳ�ѯ���෿������
as
	select TypeName ,'RCount'=COUNT(*) from T_RoomList join T_RoomType on T_RoomList.RoomType=T_RoomType.TypeID group by TypeName

--select Top (1) * from View_RoomTypeCount order by RCount --����
--select Top (1) * from View_RoomTypeCount order by RCount desc --���

--select StateID,StateName,TypeName 
--	from T_RoomList rl join T_RoomType rt on rl.RoomType=rt.TypeID Join T_RoomStateType ts on rl.RoomType= ts.StateID group by StateID,StateName,TypeName
go



--��ѯ���෿��Ŀշ���������������
if exists(select * from sysobjects where name='Proc_EmptyRoomCount')
	drop proc Proc_EmptyRoomCount
	go
create Proc Proc_EmptyRoomCount
as
	declare @StateID int = (select top 1 StateID from T_RoomStateType where StateName='�շ�' and IsValid=1)
	print @StateID
	select TypeName,eroom.RoomType,eroom.TypeCount as 'EmptyRoom',allroom.TypeCount as 'AllRoom' from 
	(select RoomType ,'TypeCount'= COUNT(RoomType) from T_RoomList rl where RoomState=@StateID group by RoomType) eroom right join
		(select RoomType ,'TypeCount'= COUNT(RoomType) from T_RoomList rl group by RoomType) allroom on eroom.RoomType= allroom.RoomType 
		join T_RoomType on eroom.RoomType= T_RoomType.TypeID
go

--exec Proc_EmptyRoomCount


--���ݷ���״̬��ѯ����״̬���������
go
create view View_RoomStateCount
as
	select StateName,'RCount'=COUNT(StateName) from T_RoomList join T_RoomStateType on T_RoomList.RoomState=T_RoomStateType.StateID group by StateName
go



--��ѯס����ʷ��¼
create view view_HousingHistory
as
select '��¼���'=ClientGUID,'������'=RoomID,'��סʱ��'=CRinTime,'�˷�ʱ��'=CROutTime,'��ס�Ǽ�'=staff.StaffName,'�˷�����'=staff2.StaffName
 from T_ClientRoomOld ch join T_ClientInfo c on ch.ClientGUID=c.GUID join T_StaffInfo
  staff on ch.OperatorOGUID= staff.StaffID join  T_StaffInfo staff2 on ch.OperatorEGUID = staff2.StaffID

  go
  
	--select * from view_HousingHistory where ��סʱ��>= dateadd(MINUTE,-1440,GETDATE()) --����
	--select * from view_HousingHistory where ��סʱ��>= dateadd(HOUR,-168,GETDATE()) --������
	--select * from view_HousingHistory where ��סʱ��>= dateadd(HOUR,-120960,GETDATE()) --30����
	--select * from view_HousingHistory where ��סʱ��>= dateadd(DAY,-365,GETDATE()) --365��


  --������ʷ��¼
  create view view_ConsumeHistory
  as
  select '�ͻ����'=ClientGUID,'�ͻ�����'= ClientIName,'��������'=OperateName,'�������'=OperateMoney,'����ʱ��'=OperateTime,'�ͻ���'=StaffName
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

	-- OperateName='���ѿ�ȡ' and


--��ѯ�ͻ�ס�������������
go
--create view View_ClientRoomState
--as
--select tr.GUID as '��������',tr.ClientGUID as '�ͻ�����',tr.ClientAccount as '�˻����',rt.TypeName as '��������',rt.TypePrice as '����'
--	,cast((rt.TypeRequency/1000/3600/10000) as varchar(40))+'/Сʱ' as '����Ƶ��'
--	,tr.InTime as '��סʱ��',tr.LastDeduct as '�ϴν���',tr.OperatorGUID as '�Ǽ�Ա��',tr.RoomID as '�����',ti.ClientIName as '�ͻ�����'
-- from T_ClientRoom tr join T_ClientInfo ti on Tr.ClientGUID=ti.GUID join T_RoomList rl on tr.RoomID= rl.RoomID join T_RoomType rt on rl.RoomType=rt.TypeID

-- select * from View_ClientRoomState


 --��ѯ�ͻ�ס�������Ӣ����
create view View_ClientRoomState
as
select tr.GUID as 'DataGUID',tr.ClientAccount
	,tr.InTime as 'InRoomTime',tr.LastDeduct,
	tr.RoomID as 'RoomID',ti.ClientIName as 'ClientName'
 from T_ClientRoom tr join T_ClientInfo ti on Tr.ClientGUID=ti.GUID 

-- select *  from T_ClientRoom 
