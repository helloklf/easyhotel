----判断数据库是否存在，存在则删除
use master
if exists(select * from sysdatabases where name='TavernManage')
	drop database TavernManage
--go
----创建数据库
create database TavernManage
on
(
	name = 'TavernManage',
	filename = 'D:\TavMS0.mdf',
	size = 5,
	filegrowth = 20%
)
go
use  TavernManage
go



--前台数据库

create table T_PaperType--证件类型表
(
	PapersID int identity(1,1) primary key,--证件类型编号
	PapersName varchar(30) not null,--证件号类型名
	IsValid bit Default(1)--是否有效
)

go
--证件类型相关触发器
	create trigger tri_PaperType_Delete
	on T_PaperType for delete
	as
	begin
		raiserror('基础数据不允许删除操作！请将此错误报告给开发者！',16,0)
		rollback
	end
	go
	--插入触发器
	create trigger tri_PaperType_Inssert	on T_PaperType instead of insert
	as
	begin
		declare @PName varchar(30)
		declare @IsV bit
		set @IsV = (select top 1 IsValid from inserted)
		set @PName = (select top 1 PapersName from inserted)
		if exists( select * from T_PaperType where PapersName=@PName and IsValid=@IsV)
			raiserror('操作失败，失败原因：已经存在相同的记录了!',16,0);
		else
		begin
			insert into T_PaperType values(@PName,@IsV)
			print '操作已完成！'
		end
	end
	go
	--更新触发器
	create trigger tri_PaperType_Update		on T_PaperType for update
	as
	begin
		declare @PName varchar(30)
		declare @IsV bit
		set @IsV = (select top 1 IsValid from inserted)
		set @PName = (select top 1 PapersName from inserted)
		if( (select COUNT(*) from T_PaperType where PapersName=@PName and IsValid=@IsV)>1)
		begin
			raiserror('操作失败，失败原因：已经存在相同的记录了!',16,0);
			rollback
		end
		else
			print '数据更新成功！'
	end




go




create table T_CountryInfo--国家信息表
(
	CountryID int identity(1,1) primary key,--国家编号
	CountryName varchar(30) not null,--国名
	IsValid bit Default(1),--是否有效
)
go
--国家信息相关触发器
	create trigger tri_CountryInfo_Delete
	on T_CountryInfo for delete
	as
	begin
		raiserror( '基础数据不允许删除操作！请将此错误报告给开发者！',16,0)
		rollback
	end
	go
	--插入触发器
	create trigger tri_CountryInfo_Inssert	on T_CountryInfo instead of insert
	as
	begin
		declare @IsV bit = (select top 1 IsValid from inserted)
		declare @CName varchar(30) = (select top 1 CountryName from inserted)
		if exists( select * from T_CountryInfo where CountryName=@CName and IsValid=@IsV)
			raiserror('操作失败，失败原因：已经存在相同的记录了!',16,0);
		else
		begin
			insert into T_CountryInfo values(@CName,@IsV)
			print '操作已完成！'
		end
	end
	--drop trigger tri_CountryInfo_Inssert
	go
	--更新触发器
	create trigger tri_CountryInfo_Update		on T_CountryInfo for update
	as
	begin
		declare @CName varchar(30) = (select top 1 CountryName from inserted)
		declare @IsV bit = (select top 1 IsValid from inserted)
		if( (select COUNT(*) from T_CountryInfo where CountryName=@CName and IsValid=@IsV)>1)
		begin
			raiserror('操作失败，失败原因：已经存在相同的记录了!',16,0);
			rollback
		end
		else
			print '数据更新成功！'
	end





go

create table T_VIPLevel--VIP类型类型表
(
	LevelID int identity(1,1) primary key,--等级编号
	LevelName varchar(30) not null,--等级称号
	LevelIntegral int check(LevelIntegral>-1) not null,--等级所需积分
	VipDiscount int check(VipDiscount>-1 and VipDiscount<101), --会员折扣优惠百分比
	IsValid bit Default(1)--是否有效
)
go
--VIP类型类型相关触发器
	create trigger tri_VIPLevel_Delete
	on T_VIPLevel for delete
	as
	begin
		raiserror( '基础数据不允许删除操作！请将此错误报告给开发者！',16,0)
		rollback
	end
	go
	--插入触发器
	create trigger tri_VIPLevel_Inssert	on T_VIPLevel instead of insert
	as
	begin
		declare @IsV bit = (select top 1 IsValid from inserted)
		declare @Name varchar(30) = (select top 1 LevelName from inserted)
		declare @Integral int = (select Top 1 LevelIntegral from inserted)
		declare @Dscount int =(select top 1 VipDiscount from inserted)
		if exists( select * from T_VIPLevel where (LevelName=@Name or LevelIntegral=@Integral) and IsValid=@IsV)
			raiserror('操作失败，失败原因：已经存在相同的记录了!（注意：可用状态相同，且等级称号或等级所需积分相等，视为相同记录）',16,0);
		else
		begin
			insert into T_VIPLevel values(@Name,@Integral,@Dscount,@IsV)
			print '操作已完成！'
		end
	end --drop trigger tri_VIPLevel_Inssert
	go
	--更新触发器
	create trigger tri_VIPLevel_Update		on T_VIPLevel for update
	as
	begin
		declare @Name varchar(30) = (select top 1 LevelName from inserted)
		declare @IsV bit = (select top 1 IsValid from inserted)
		declare @Integral int = (select Top 1 LevelIntegral from inserted)
		if (( select COUNT(*) from T_VIPLevel where (LevelName=@Name or LevelIntegral=@Integral) and IsValid=@IsV)>1)
		begin
			raiserror('操作失败，失败原因：已经存在相同的记录了! （注意：当可用状态相同，且等级称号或等级所需积分相等，视为相同记录）',16,0);
			rollback
		end
		else
			print '数据更新成功！'
	end
go










create table T_VIPInfo--VIP信息表
(
	VIPID varchar(40) primary key,--VIP编号
	VIPIntegral int Default(0),--会员积分
	CountryID int,--国籍编号
	IsValid bit Default(1)--是否有效
)
go
--VIP信息表相关触发器
	create trigger tri_VIPInfo_Delete
	on T_VIPInfo for delete
	as
	begin
		raiserror('基础数据不允许删除操作！请将此错误报告给开发者！',16,0)
		rollback
	end
	go
	--更新触发器
	create trigger tri_VIPInfo_Update		on T_VIPInfo for update
	as
	begin
		if ((select VIPIntegral from inserted) <0)
		begin
			rollback
			raiserror('会员的积分不能为负数！',16,0);
		end
		else
			print '数据更新成功！'
	end
go








create table T_ClientInfo--客户信息表
(
	GUID Varchar(40) Default(newid()) primary key,--记录编号
	ClientCType int foreign key(ClientCType) references T_PaperType(PapersID),--证件类型	
	ClientIDCard varchar(30) not null,--证件号
	ClientIName varchar(30) not null,--姓名
	ClientSex bit,--性别
	ClientAdress Varchar(50),--客户地址
	ClientTel varchar(40),--头像
	ClientVIPID varchar(50),--VIP编号
)
go
--客户信息表相关触发器
	create trigger tri_ClientInfo_Delete	on T_ClientInfo for delete
	as
	begin
		raiserror( '永久性档案不允许删除操作！请将此错误报告给开发者！',16,0)
		rollback
	end









	--完成
go
create table T_RoomType--房间类型表
(
	TypeID Int identity(1,1) primary key,--房间编号
	TypeName varchar(30) not null,--类型
	TypePrice int,--类型单价
	TypeImage image,--类型图片
	TypeVipPrice int,--Vip单价
	TypeRequency bigint ,--结算频率
	IsValid bit Default(1),--是否有效
)
go
--房间类型表相关触发器
	create trigger tri_T_RoomType_Delete	on T_RoomType for delete
	as
	begin
		raiserror( '基础数据不允许删除操作！请将此错误报告给开发者！',16,0)
		rollback
	end	
	go
	create trigger tri_RoomTypeInsert on T_RoomType for insert
	as
	begin
		declare @name varchar(30) = (select top 1 TypeName from inserted)
		declare @isv varchar(30) = (select top 1 IsValid from inserted)
		if ((select COUNT(*) from T_RoomType where TypeName=@Name and IsValid=@isv)>1)
		begin
			raiserror('已经存在相同的数据了，请不要让类型名重复！',16,0) rollback
		end
	end
	go
	create trigger tri_RoomTypeUpdate on T_RoomType for update
	as
	begin
		declare @name varchar(30) = (select top 1 TypeName from inserted)
		declare @isv varchar(30) = (select top 1 IsValid from inserted)
		if ((select count(*) from T_RoomType where TypeName=@Name and IsValid=@isv)>1)
		begin
			raiserror('因为出现数据重复，操作被撤销！注意，如果在禁用条目时遇到此错误，请检查在已禁用条目中是否已包含相同条目！',16,0)
			rollback
		end
		else print '操作完成！'
	end




	--完成
go

create table T_RoomStateType--房间状态类型表
(
	StateID Int identity(1,1) primary key,--房间编号
	StateName varchar(30) not null,--类型名
	StateColor varchar(20) default('#0000'),--该状态下显示的颜色
	StateRemark varchar(200),--备注
	IsValid bit Default(1),--是否有效
)
go
--房间类型表相关触发器
	create trigger tri_T_RoomState_Delete	on T_RoomStateType for delete
	as
	begin
		raiserror('基础数据不允许删除操作！请将此错误报告给开发者！',16,0)
		rollback
	end	
	go
	create trigger tri_RoomStateType_Insert on T_RoomStateType INSTEAD of insert
	as
	begin
		declare @name varchar(30) = (select top 1 StateName from inserted)
		declare @color varchar(30) = (select top 1 StateColor from inserted)
		declare @remark varchar(30) = (select top 1 StateRemark from inserted)
		declare @isv bit = (select top 1 IsValid from inserted)
		if((select COUNT(*) from T_RoomStateType where StateName=@name and IsValid=@isv )>0)
		begin
			raiserror('数据出现重复，当两条数据出现同名，且有效状态相同，视为重复！',16,0)
			rollback
		end
		else
		begin
			insert into T_RoomStateType(StateName,StateColor,StateRemark) values(@name,@color,@remark)
		end
	end
	go
	create trigger tri_RoomStateType_Update on T_RoomStateType for update
	as
	begin
		declare @name varchar(30) = (select top 1 StateName from inserted)
		declare @isv bit = (select top 1 IsValid from inserted)
		if((select COUNT(*) from T_RoomStateType where StateName=@name and IsValid=@isv )>1)
		begin
			raiserror('数据出现重复，当两条数据出现同名，且有效状态相同，视为重复u！',16,0)
			rollback
		end
		declare @oldname varchar(30) = (select top 1 StateName from deleted)
		if(@oldname='空房' or @oldname='占用房' or @oldname='脏房'or @oldname='预订')
		begin
			raiserror('该条数据受系统保护，因为修改它将会导致您的系统无法正常工作！',16,0)
			rollback
		end

	end












go
create table T_RoomList--房间列表
(
	RoomID varchar(30) primary key,--房间编号
	RoomType int not null foreign key(RoomType) references T_RoomType(TypeID),--房间类型编号
	RoomState int not null foreign key(RoomState) references T_RoomStateType(StateID),--房间状态编号
	RoomRemark varchar(200),--备注和描述
	IsValid bit Default(1),--是否有效
) 
go
 create view View_RoomInfo--查询有效房间信息
 as
 select rl.RoomID as '房间编号'
 ,rt.TypeID as '类型编号'
 ,rt.TypeName as '类型名'
 ,rt.TypePrice as '单价'
 ,(rt.TypeRequency/3600/1000/10000) as  '结算频率'
 ,rs.StateID as '状态编号'
 ,rs.StateName as '状态名',
 rs.StateColor as '颜色',
rl.RoomRemark as '房间备注',
 '有效状态'= rl.IsValid
 from T_RoomList rl join T_RoomType rt on rl.RoomType= rt.TypeID join T_RoomStateType rs on rl.RoomState= rs.StateID where rl.IsValid=1

  go
 create view View_RoomInfoAll--查询所有房间信息
 as
 select rl.RoomID as '房间编号'
 ,rt.TypeID as '类型编号'
 ,rt.TypeName as '类型名'
 ,rt.TypePrice as '单价'
 ,(rt.TypeRequency/3600/1000/10000) as  '结算频率'
 ,rs.StateID as '状态编号'
 ,rs.StateName as '状态名',
 rs.StateColor as '颜色',
rl.RoomRemark as '房间备注',
 '有效状态'= rl.IsValid
 from T_RoomList rl join T_RoomType rt on rl.RoomType= rt.TypeID join T_RoomStateType rs on rl.RoomState= rs.StateID

 
 go
 create view View_RoomInfoNo--查询无效房间信息
 as
 select rl.RoomID as '房间编号'
 ,rt.TypeID as '类型编号'
 ,rt.TypeName as '类型名'
 ,rt.TypePrice as '单价'
 ,(rt.TypeRequency/3600/1000/10000) as  '结算频率'
 ,rs.StateID as '状态编号'
 ,rs.StateName as '状态名',
 rs.StateColor as '颜色',
rl.RoomRemark as '房间备注',
 '有效状态'= rl.IsValid
 from T_RoomList rl join T_RoomType rt on rl.RoomType= rt.TypeID join T_RoomStateType rs on rl.RoomState= rs.StateID where rl.IsValid=0


 go
 --输入最高价格，查询单价低于此值得所有房间，按优惠程度降序排序
if exists (select * from sysobjects where name='Proc_PriceSearch')
	Drop procedure Proc_PriceSearch
GO
Create proc Proc_PriceSearch
@maxprice int
AS
begin
	select * from View_RoomInfo vr where vr.单价<= @maxprice order by vr.单价*1.0/vr.结算频率
end
go

--select * from T_RoomType
--select * from T_RoomStateType
--select * from T_RoomList



go
--房间列表相关触发器
	create trigger tri_RoomList_Delete	on T_RoomList for delete
	as
	begin
		raiserror('永久性数据不允许删除操作！请将此错误报告给开发者！',16,0)
		rollback
	end	













go
--等待完整
create table T_ClientRoom--客户住房信息表
(
	GUID varchar(40) Default(newid()) primary key,--记录编号
	ClientGUID varchar(40) foreign key(ClientGUID) references T_ClientInfo(GUID),--客户GUID
	ClientAccount float Default(0),--账户余额(元)
	InTime datetime Default(getdate()),--入住时间
	LastDeduct datetime not null ,--上次结算
	OperatorGUID varchar(40),--操作员ID
	RoomID varchar(30) not null foreign key(RoomID) references T_RoomList(RoomID)--房间编号
)

--房间预订
create table T_BookRoom
(
	guid varchar(40) default(newid()) primary key ,--记录编号
	RoomID varchar(30) not null,--房号
	BookTime datetime default(getdate()),--预订时间
	BookValidTime int default(5),--有效天数
	ClientName varchar(30) not null,--客户姓名
)



go

create table T_OperateType--操作类型表
(
	TypeID Int identity(1,1) primary key,--操作类型编号
	OperateName varchar(30) not null,--操作名称
	IsValid bit Default(1),--是否有效
)
go
--操作类型表相关触发器
	create trigger tri_OperateType_Delete on T_OperateType for delete
	as
	begin
		raiserror( '基础数据不允许删除操作！请将此错误报告给开发者！',16,0)
		rollback
	end
	go
	create trigger tri_OperateType_Insert on T_OperateType INSTEAD of insert
	as
	begin
		declare @name varchar(30) = (select top 1 OperateName from inserted)
		declare @isv bit = (select top 1 IsValid from inserted)
		if((select COUNT(*) from T_OperateType where OperateName=@name and IsValid=@isv )>0)
		begin
			raiserror('数据出现重复，当两条数据出现同名，且有效状态相同，视为重复u！',16,0)
			rollback
		end
		else
		begin
			insert into T_OperateType(OperateName) values(@name)
		end
	end
	go
	create trigger tri_OperateType_Update on T_OperateType for update
	as
	begin
		declare @name varchar(30) = (select top 1 OperateName from inserted)
		declare @isv bit = (select top 1 IsValid from inserted)
		if((select COUNT(*) from T_OperateType where OperateName=@name and IsValid=@isv )>1)
		begin
			raiserror('数据出现重复，当两条数据出现同名，且有效状态相同，视为重复u！',16,0)
			rollback
		end
		declare @oldname varchar(30) = (select top 1 OperateName from deleted)
		if(@oldname='入住登记' or @oldname='退房结账' or @oldname='房费扣取')
		begin
			raiserror('该条数据受系统保护，因为修改它将会导致您的系统无法正常工作！',16,0)
			rollback
		end

	end



go


create table T_ClientRoomOld--住房历史表
(
	GUID varchar(40) Default(newid()) primary key,--记录编号
	ClientGUID varchar(40) not null,--客户GUID
	RoomID varchar(30) not null,--房间编号
	CRinTime datetime not null,--入住时间
	CROutTime datetime Default(getdate()),--结束时间
	OperatorOGUID varchar(40) not null,--开房操作员ID
	OperatorEGUID varchar(40) not null,--退房操作员ID
)
go
--住房历史表相关触发器
	create trigger tri_ClientRoomOld_Delete	on T_ClientRoomOld for delete
	as
	begin
		print '永久性数据不允许删除操作！请将此错误报告给开发者！'
		rollback
	end	
	go
	create trigger tri_ClientRoomOld_update	on T_ClientRoomOld for update
	as
	begin
		print '这些数据由系统自动生成，用户无法对它进行修改！请将此错误报告给开发者！'
		rollback
	end	




go



create table T_AccountOld--账务记录表
(
	GUID varchar(40) Default(newid()) primary key,--记录编号
	ClientGUID varchar(40) not null,--客户GUID
	OperateTime datetime Default(getdate()),--操作时间
	OperateMoney int not null,--操作金额(元)
	OperatorTypeID int not null foreign key(OperatorTypeID) references T_OperateType(TypeID),--操作类型编号
	OperatorGUID varchar(40) not null,--操作员GUID
)
go
--账务记录表相关触发器
	create trigger tri_AccountOld_Delete	on T_AccountOld for delete
	as
	begin
		print '永久性数据不允许删除操作！请将此错误报告给开发者！'
		rollback
	end	
	go
	create trigger tri_AccountOld_update	on T_AccountOld for update
	as
	begin
		print '这些数据由系统自动生成，用户无法对它进行修改！请将此错误报告给开发者！'
		rollback
	end	

go









create table T_SupplierType --供应商类型表
(
	ID int primary key identity(1,1),--编号 主键 自增长
	Name varchar(30) not null,--名称 非空
	Remark varchar(200),--备注及描述
	IsValid bit default(1),--是否有效 默认有效 1
)
go
	create trigger tri_SupplierType_Delete	on T_SupplierType for delete
	as
	begin
		print '基础数据不允许删除操作！请将此错误报告给开发者！'
		rollback
	end
	go
	create trigger tri_SupplierTypeInsert on T_SupplierType for insert
	as
	begin
		declare @name varchar(30) = (select top 1 Name from inserted)
		declare @isv varchar(30) = (select top 1 IsValid from inserted)
		if ((select COUNT(*) from T_SupplierType where Name=@Name and IsValid=@isv)>1)
		begin
			raiserror('已经存在相同的数据了，请不要让名称重复！',16,0) rollback
		end
	end
	go
	create trigger tri_SupplierTypeUpdate on T_SupplierType for update
	as
	begin
		declare @name varchar(30) = (select top 1 Name from inserted)
		declare @isv varchar(30) = (select top 1 IsValid from inserted)
		if ((select count(*) from T_SupplierType where Name=@Name and IsValid=@isv)>1)
		begin
			raiserror('因为出现数据重复，操作被撤销！注意，如果在禁用条目时遇到此错误，请检查在已禁用条目中是否已包含相同条目！',16,0)
			rollback
		end
		else print '操作完成！'
	end




go
create table T_SupplierInfo --供应商信息
(
	SupplierID int primary key identity(1,1),--编号 主键 自增长
	SupplierName varchar(30) not null,--供应商名称 非空
	SupplierCouID int, --国籍号
	SupplierAdress varchar(50),-- 供应商地址
	SupplierTel varchar(30),--电话号码
	SupplierTypeID int not null,--供应类型
	Remark varchar(200), --备注
	IsValid bit default(1)--是否有效
)
go
	create trigger tri_SupplierInfo_Delete	on T_SupplierInfo for delete
	as
	begin
		print '永久性数据不允许删除操作！请将此错误报告给开发者！'
		rollback
	end	




go
create table T_WaresType--商品类型
(
	WaresID	int primary key identity(1,1),--类型编号 主键 自增长
	WaresName varchar(40) not null,--商品名 非空
	WaresImage image ,--商品图片
	WaresRemark varchar(100),--备注及描述
	IsValid bit default(1) --是否有效
)
go
	create trigger tri_WaresType_Delete	on T_WaresType for delete
	as
	begin
		print '基本数据不允许删除操作！请将此错误报告给开发者！'
		rollback
	end
	go
	create trigger tri_WaresTypeInsert on T_WaresType instead of insert
	as
	begin
		declare @name varchar(30) = (select top 1  WaresName from inserted)
		declare @remark varchar(30) = (select top 1 WaresRemark from inserted)
		declare @isv varchar(30) = (select top 1 IsValid from inserted)
		if exists(select * from T_WaresType where WaresName=@Name and IsValid=@isv)
		raiserror('已经存在相同的数据了，请不要让商品名重复！',16,0)
		else
			insert into T_WaresType(WaresName,WaresImage,WaresRemark,IsValid) values(@name,(select top 1 WaresImage from inserted),@remark,@isv)
	end
	go
	create trigger tri_WaresTypeUpdate on T_WaresType for update
	as
	begin
		declare @name varchar(30) = (select top 1 WaresName from inserted)
		declare @isv varchar(30) = (select top 1 IsValid from inserted)
		if ((select count(*) from T_WaresType where WaresName=@Name and IsValid=@isv)>1)
		begin
			raiserror('因为出现数据重复，操作被撤销！注意，如果在禁用条目时遇到此错误，请检查在已禁用条目中是否已包含相同条目！',16,0)
			rollback
		end
			else print '操作完成！'
	end








go
create table T_StockInfo--库存信息
(
	GUID varchar(40) primary key default(newid()),--编号 主键 随机编号
	WaresID int not null,--商品类型编号 非空
	Inventory int check(Inventory >-1) not null ,--库存数量
	LowCuount int check(LowCuount>-1) not null,--缺货数量
	StockUnit int not null,--库存单位
	IsValid bit default(1) --是否有效
)
go
	create trigger tri_StockInfo_Delete	on T_StockInfo for delete
	as
	begin
		print '永久性数据不允许删除操作！请将此错误报告给开发者！'
		rollback
	end	













	--完成
	go
create table T_UnitType --计量单位
(
	UnitID int primary key identity(1,1),--单位编号 主键 自增长
	UnitName varchar(45) not null,--单位名 非空
	IsValid bit default(1) --是否有效
)
go
	create trigger tri_UnitType_Delete	on T_UnitType for delete
	as
	begin
		print '基础数据不允许删除操作！请将此错误报告给开发者！'
		rollback
	end
	go
	create trigger tri_UnitTypeInsert on T_UnitType instead of insert
	as
	begin
		declare @name varchar(30) = (select top 1 UnitName from inserted)
		declare @isv varchar(30) = (select top 1 IsValid from inserted)
		if exists(select * from T_UnitType where UnitName=@Name and IsValid=@isv)
		raiserror('已经存在相同的数据了，请不要让单位名重复！',16,0)
		else
			insert into T_UnitType(UnitName,IsValid) values(@name,@isv)
	end
	go
	create trigger tri_UnitTypeUpdate on T_UnitType for update
	as
	begin
		declare @name varchar(30) = (select top 1 UnitName from inserted)
		declare @isv varchar(30) = (select top 1 IsValid from inserted)
		if ((select count(*) from T_UnitType where UnitName=@Name and IsValid=@isv)>1)
		begin
			raiserror('因为出现数据重复，操作被撤销！注意，如果在禁用条目时遇到此错误，请检查在已禁用条目中是否已包含相同条目！',16,0)
			rollback
		end
			else print '操作完成！'
	end










go
create table T_OutInInfo--出入库信息
(
	IOGUID	varchar(40) primary key default(newid()),--类型编号 主键 自增长
	IOWaresID int not null,--商品ID
	SupplierID int,--供应商ID（入库时需登记）
	IOCount int,--非空 数量
	IOUnit int,--非空 单位
	OperatorGUID varchar(40) not null,--操作员GUID
	OperatorTime datetime default(getdate()),--操作时间
	IORemark varchar(300),--备注及描述
)
go
	create trigger tri_OutInInfo_Delete	on T_OutInInfo for delete
	as
	begin
		print '永久性数据不允许删除操作！请将此错误报告给开发者！'
		rollback
	end




















go
create table T_AccreditType--授权类型
(
	ALevelID int primary key identity(1,1),--等级编号 主键 自增长
	ALevelName varchar(40) not null,--等级名称 非空
	ALevelRemark varchar(200),--备注及描述
	IsValid bit default(1) --是否有效
)
go
	create trigger tri_AccreditType_Delete	on T_AccreditType for delete
	as
	begin
		print '基础数据不允许删除操作！请将此错误报告给开发者！'
		rollback
	end	
	go
	create trigger tri_AccreditTypeInsert on T_AccreditType instead of insert
	as
	begin
		declare @name varchar(30) = (select top 1 ALevelName from inserted)
		declare @remark varchar(30) = (select top 1 ALevelRemark from inserted)
		declare @isv varchar(30) = (select top 1 IsValid from inserted)
		if exists(select * from T_AccreditType where ALevelName=@Name and IsValid=@isv)
		raiserror('已经存在相同的数据了，请不要让权限等级名重复！',16,0)
		else
			insert into T_AccreditType(ALevelName,ALevelRemark,IsValid) values(@name,@remark,@isv)
	end
	go
	create trigger tri_AccreditTypeUpdate on T_AccreditType for update
	as
	begin
		declare @name varchar(30) = (select top 1 ALevelName from inserted)
		declare @isv varchar(30) = (select top 1 IsValid from inserted)
		if ((select count(*) from T_AccreditType where ALevelName=@Name and IsValid=@isv)>1)
		begin
			raiserror('因为出现数据重复，操作被撤销！注意，如果在禁用条目时遇到此错误，请检查在已禁用条目中是否已包含相同条目！',16,0)
			rollback
		end
		else if(@name='超级管理员' or @name='高级管理员' or @name='管理员' or @name='访客')
		begin
			raiserror('你所操作的数据涉及系统架构底层模型，修改这些数据会导致一些功能无法正常运行。因此系统中断了你的操作！',16,0) rollback
		end
		else print '操作完成！'
	end




















go
create table T_AccreditList--授权列表
(
	AccreditGUID varchar(40) primary key default(newid()),--授权码 主键 自增长
	AStartDate datetime not null, --生效时间
	AEndDate datetime not null, --非空 失效时间
	ALevel int --授权等级
)


go
create table T_StaffType--职务类型
(
	STypeID int primary key identity(1,1),--类型编号 主键 自增长
	STypeName varchar(40) not null,--非空 职务名称（如：房管）
	STypeALevelID int, --权限分级编号
	IsValid bit default(1) --是否有效
)
go
	create trigger tri_StaffType_Delete	on T_StaffType for delete
	as
	begin
		print '基础数据不允许删除操作！请将此错误报告给开发者！'
		rollback
	end	
	go
	create trigger tri_StaffTypeInsert on T_StaffType instead of insert
	as
	begin
		declare @name varchar(30) = (select top 1 STypeName from inserted)
		declare @Acc varchar(30) = (select top 1 STypeALevelID from inserted)
		declare @isv varchar(30) = (select top 1 IsValid from inserted)
		if exists(select * from T_StaffType where STypeName=@Name and IsValid=@isv)
		raiserror('已经存在相同的数据了，请不要让名称重复！',16,0)
		else
			insert into T_StaffType(STypeName,STypeALevelID,IsValid) values(@name,@Acc,@isv)
	end
	go
	create trigger tri_StaffTypeUpdate on T_StaffType for update
	as
	begin
		declare @name varchar(30) = (select top 1 STypeName from inserted)
		declare @isv varchar(30) = (select top 1 IsValid from inserted)
		if ((select count(*) from T_StaffType where STypeName=@Name and IsValid=@isv)>1)
		begin
			raiserror('因为出现数据重复，操作被撤销！注意，如果在禁用条目时遇到此错误，请检查在已禁用条目中是否已包含相同条目！',16,0)
			rollback
		end
			else print '操作完成！'
	end


go
create table T_StaffInfo--员工个人信息
(
	StaffID varchar(40) primary key default(newid()),--唯一标识 主键 自增长
	StaffName varchar(30), --非空 员工姓名
	StaffSex bit, --非空 性别
	StaffCouID int, --国籍号
	StaffAdress varchar(50),--地址编号
	StaffIdCard varchar(30), --身份证号
	StaffInDate date default(getdate()), --入职时间
	StaffImage image, --头像
	StaffTel varchar(40),--员工电话
	IsValid bit not null default(1) --是否在职
)

go
	create trigger tri_StaffInfo_Delete	on T_StaffInfo for delete
	as
	begin
		print '永久性数据不允许删除操作！请将此错误报告给开发者！'
		rollback
	end	



	declare @g varchar(40) = newid()
	print @g

go
create table T_StaffList--在职员工列表
(
	StaffID varchar(40) primary key,--唯一标识 主键 自增长
	StaffPwdMD5 varchar(50), --员工密码
	StaffGuid varchar(40), --唯一标识
	StaffAccredit varchar(40), --授权代码
	STypeID int, --职务编号
)
go
--登录
if exists (select * from sysobjects where name='Proc_UserLogin')
	Drop procedure Proc_UserLogin
GO
Create proc Proc_UserLogin
@StaffID varchar(50),
@StaffPass varchar(40)
AS
	if((select COUNT(*) from T_StaffList where StaffID=@StaffID and StaffPwdMD5=@StaffPass)<1)
	begin
	select sl.StaffID,si.StaffName,si.StaffImage,
	st.STypeID,st.STypeName, at.ALevelID,at.ALevelName,sl.StaffPwdMD5
	 from T_StaffList sl join T_StaffInfo si on si.StaffID=sl.StaffGuid join T_StaffType st on sl.STypeID=st.STypeID join T_AccreditType at on
	st.STypeALevelID=at.ALevelID where sl.StaffID=@StaffID
	end
	else raiserror( '账号不存在或密码错误！',16,0)
go


--select a.StaffID as '序列号',StaffName as '姓名',StaffIdCard as '身份证',
--b.StaffID '工号',b.StaffAccredit '授权码',STypeName '职务' ,
--StaffSex as'性别',CountryName as '国家',StaffAdress as '地址',
--StaffInDate as '入职时间',StaffTel as '电话号码',a.StaffName 'GUID'
-- from T_StaffInfo a left join T_StaffList b on a.StaffID=b.StaffGuid left join T_CountryInfo on a.StaffCouID=T_CountryInfo.CountryID
--left join T_StaffType on b.STypeID=T_StaffType.STypeID where a.IsValid=1

go
--外键约束 外键是T_SupplierInfo表的 SupplierTypeID  主键是 T_SupplierType表的ID
alter table T_SupplierInfo
	add constraint FK_SupplierTypeID foreign key (SupplierTypeID) references T_SupplierType(ID)
--外键约束 外键是T_StockInfo表的 GUID  主键是 T_WaresType表的WaresID
alter table T_StockInfo
	add constraint FK_WaresID foreign key (WaresID) references T_WaresType(WaresID)
--外键约束 外键是T_StockInfo表的 StockUnit  主键是 T_UnitType表的UnitID
alter table T_StockInfo
	add constraint FK_StockUnit foreign key (StockUnit) references T_UnitType(UnitID)
--外键约束 外键是T_OutInInfo表的 IOWaresID  主键是 T_WaresType表的WaresID
alter table T_OutInInfo
	add constraint FK_IOWaresID foreign key (IOWaresID) references T_WaresType(WaresID)
--外键约束 外键是T_OutInInfo表的 IOUnit  主键是 T_UnitType表的UnitID
alter table T_OutInInfo
	add constraint FK_IOUnit foreign key (IOUnit) references T_UnitType(UnitID)
--外键约束 外键是T_AccreditList表的 ALevel  主键是 T_AccreditType表的ALevelID
alter table T_AccreditList
	add constraint FK_ALevel foreign key (ALevel) references T_AccreditType(ALevelID)
--外键约束 外键是T_StaffType表的 STypeALevelID  主键是 T_AccreditType表的ALevelID
alter table T_StaffType
	add constraint FK_STypeALevelID foreign key (STypeALevelID) references T_AccreditType(ALevelID)
--外键约束 外键是T_StaffList表的 STypeID  主键是 T_StaffType表的STypeID
alter table T_StaffList
	add constraint FK_STypeID foreign key (STypeID) references T_StaffType(STypeID)
--外键约束 外键是T_StaffList表的 STypeID  主键是 T_StaffInfo表的StaffID
alter table T_StaffList
	add constraint FK_StaffGuid foreign key (StaffGuid) references T_StaffInfo(StaffID)
go