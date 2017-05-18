----�ж����ݿ��Ƿ���ڣ�������ɾ��
use master
if exists(select * from sysdatabases where name='TavernManage')
	drop database TavernManage
--go
----�������ݿ�
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



--ǰ̨���ݿ�

create table T_PaperType--֤�����ͱ�
(
	PapersID int identity(1,1) primary key,--֤�����ͱ��
	PapersName varchar(30) not null,--֤����������
	IsValid bit Default(1)--�Ƿ���Ч
)

go
--֤��������ش�����
	create trigger tri_PaperType_Delete
	on T_PaperType for delete
	as
	begin
		raiserror('�������ݲ�����ɾ���������뽫�˴��󱨸�������ߣ�',16,0)
		rollback
	end
	go
	--���봥����
	create trigger tri_PaperType_Inssert	on T_PaperType instead of insert
	as
	begin
		declare @PName varchar(30)
		declare @IsV bit
		set @IsV = (select top 1 IsValid from inserted)
		set @PName = (select top 1 PapersName from inserted)
		if exists( select * from T_PaperType where PapersName=@PName and IsValid=@IsV)
			raiserror('����ʧ�ܣ�ʧ��ԭ���Ѿ�������ͬ�ļ�¼��!',16,0);
		else
		begin
			insert into T_PaperType values(@PName,@IsV)
			print '��������ɣ�'
		end
	end
	go
	--���´�����
	create trigger tri_PaperType_Update		on T_PaperType for update
	as
	begin
		declare @PName varchar(30)
		declare @IsV bit
		set @IsV = (select top 1 IsValid from inserted)
		set @PName = (select top 1 PapersName from inserted)
		if( (select COUNT(*) from T_PaperType where PapersName=@PName and IsValid=@IsV)>1)
		begin
			raiserror('����ʧ�ܣ�ʧ��ԭ���Ѿ�������ͬ�ļ�¼��!',16,0);
			rollback
		end
		else
			print '���ݸ��³ɹ���'
	end




go




create table T_CountryInfo--������Ϣ��
(
	CountryID int identity(1,1) primary key,--���ұ��
	CountryName varchar(30) not null,--����
	IsValid bit Default(1),--�Ƿ���Ч
)
go
--������Ϣ��ش�����
	create trigger tri_CountryInfo_Delete
	on T_CountryInfo for delete
	as
	begin
		raiserror( '�������ݲ�����ɾ���������뽫�˴��󱨸�������ߣ�',16,0)
		rollback
	end
	go
	--���봥����
	create trigger tri_CountryInfo_Inssert	on T_CountryInfo instead of insert
	as
	begin
		declare @IsV bit = (select top 1 IsValid from inserted)
		declare @CName varchar(30) = (select top 1 CountryName from inserted)
		if exists( select * from T_CountryInfo where CountryName=@CName and IsValid=@IsV)
			raiserror('����ʧ�ܣ�ʧ��ԭ���Ѿ�������ͬ�ļ�¼��!',16,0);
		else
		begin
			insert into T_CountryInfo values(@CName,@IsV)
			print '��������ɣ�'
		end
	end
	--drop trigger tri_CountryInfo_Inssert
	go
	--���´�����
	create trigger tri_CountryInfo_Update		on T_CountryInfo for update
	as
	begin
		declare @CName varchar(30) = (select top 1 CountryName from inserted)
		declare @IsV bit = (select top 1 IsValid from inserted)
		if( (select COUNT(*) from T_CountryInfo where CountryName=@CName and IsValid=@IsV)>1)
		begin
			raiserror('����ʧ�ܣ�ʧ��ԭ���Ѿ�������ͬ�ļ�¼��!',16,0);
			rollback
		end
		else
			print '���ݸ��³ɹ���'
	end





go

create table T_VIPLevel--VIP�������ͱ�
(
	LevelID int identity(1,1) primary key,--�ȼ����
	LevelName varchar(30) not null,--�ȼ��ƺ�
	LevelIntegral int check(LevelIntegral>-1) not null,--�ȼ��������
	VipDiscount int check(VipDiscount>-1 and VipDiscount<101), --��Ա�ۿ��Żݰٷֱ�
	IsValid bit Default(1)--�Ƿ���Ч
)
go
--VIP����������ش�����
	create trigger tri_VIPLevel_Delete
	on T_VIPLevel for delete
	as
	begin
		raiserror( '�������ݲ�����ɾ���������뽫�˴��󱨸�������ߣ�',16,0)
		rollback
	end
	go
	--���봥����
	create trigger tri_VIPLevel_Inssert	on T_VIPLevel instead of insert
	as
	begin
		declare @IsV bit = (select top 1 IsValid from inserted)
		declare @Name varchar(30) = (select top 1 LevelName from inserted)
		declare @Integral int = (select Top 1 LevelIntegral from inserted)
		declare @Dscount int =(select top 1 VipDiscount from inserted)
		if exists( select * from T_VIPLevel where (LevelName=@Name or LevelIntegral=@Integral) and IsValid=@IsV)
			raiserror('����ʧ�ܣ�ʧ��ԭ���Ѿ�������ͬ�ļ�¼��!��ע�⣺����״̬��ͬ���ҵȼ��ƺŻ�ȼ����������ȣ���Ϊ��ͬ��¼��',16,0);
		else
		begin
			insert into T_VIPLevel values(@Name,@Integral,@Dscount,@IsV)
			print '��������ɣ�'
		end
	end --drop trigger tri_VIPLevel_Inssert
	go
	--���´�����
	create trigger tri_VIPLevel_Update		on T_VIPLevel for update
	as
	begin
		declare @Name varchar(30) = (select top 1 LevelName from inserted)
		declare @IsV bit = (select top 1 IsValid from inserted)
		declare @Integral int = (select Top 1 LevelIntegral from inserted)
		if (( select COUNT(*) from T_VIPLevel where (LevelName=@Name or LevelIntegral=@Integral) and IsValid=@IsV)>1)
		begin
			raiserror('����ʧ�ܣ�ʧ��ԭ���Ѿ�������ͬ�ļ�¼��! ��ע�⣺������״̬��ͬ���ҵȼ��ƺŻ�ȼ����������ȣ���Ϊ��ͬ��¼��',16,0);
			rollback
		end
		else
			print '���ݸ��³ɹ���'
	end
go










create table T_VIPInfo--VIP��Ϣ��
(
	VIPID varchar(40) primary key,--VIP���
	VIPIntegral int Default(0),--��Ա����
	CountryID int,--�������
	IsValid bit Default(1)--�Ƿ���Ч
)
go
--VIP��Ϣ����ش�����
	create trigger tri_VIPInfo_Delete
	on T_VIPInfo for delete
	as
	begin
		raiserror('�������ݲ�����ɾ���������뽫�˴��󱨸�������ߣ�',16,0)
		rollback
	end
	go
	--���´�����
	create trigger tri_VIPInfo_Update		on T_VIPInfo for update
	as
	begin
		if ((select VIPIntegral from inserted) <0)
		begin
			rollback
			raiserror('��Ա�Ļ��ֲ���Ϊ������',16,0);
		end
		else
			print '���ݸ��³ɹ���'
	end
go








create table T_ClientInfo--�ͻ���Ϣ��
(
	GUID Varchar(40) Default(newid()) primary key,--��¼���
	ClientCType int foreign key(ClientCType) references T_PaperType(PapersID),--֤������	
	ClientIDCard varchar(30) not null,--֤����
	ClientIName varchar(30) not null,--����
	ClientSex bit,--�Ա�
	ClientAdress Varchar(50),--�ͻ���ַ
	ClientTel varchar(40),--ͷ��
	ClientVIPID varchar(50),--VIP���
)
go
--�ͻ���Ϣ����ش�����
	create trigger tri_ClientInfo_Delete	on T_ClientInfo for delete
	as
	begin
		raiserror( '�����Ե���������ɾ���������뽫�˴��󱨸�������ߣ�',16,0)
		rollback
	end









	--���
go
create table T_RoomType--�������ͱ�
(
	TypeID Int identity(1,1) primary key,--������
	TypeName varchar(30) not null,--����
	TypePrice int,--���͵���
	TypeImage image,--����ͼƬ
	TypeVipPrice int,--Vip����
	TypeRequency bigint ,--����Ƶ��
	IsValid bit Default(1),--�Ƿ���Ч
)
go
--�������ͱ���ش�����
	create trigger tri_T_RoomType_Delete	on T_RoomType for delete
	as
	begin
		raiserror( '�������ݲ�����ɾ���������뽫�˴��󱨸�������ߣ�',16,0)
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
			raiserror('�Ѿ�������ͬ�������ˣ��벻Ҫ���������ظ���',16,0) rollback
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
			raiserror('��Ϊ���������ظ���������������ע�⣬����ڽ�����Ŀʱ�����˴����������ѽ�����Ŀ���Ƿ��Ѱ�����ͬ��Ŀ��',16,0)
			rollback
		end
		else print '������ɣ�'
	end




	--���
go

create table T_RoomStateType--����״̬���ͱ�
(
	StateID Int identity(1,1) primary key,--������
	StateName varchar(30) not null,--������
	StateColor varchar(20) default('#0000'),--��״̬����ʾ����ɫ
	StateRemark varchar(200),--��ע
	IsValid bit Default(1),--�Ƿ���Ч
)
go
--�������ͱ���ش�����
	create trigger tri_T_RoomState_Delete	on T_RoomStateType for delete
	as
	begin
		raiserror('�������ݲ�����ɾ���������뽫�˴��󱨸�������ߣ�',16,0)
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
			raiserror('���ݳ����ظ������������ݳ���ͬ��������Ч״̬��ͬ����Ϊ�ظ���',16,0)
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
			raiserror('���ݳ����ظ������������ݳ���ͬ��������Ч״̬��ͬ����Ϊ�ظ�u��',16,0)
			rollback
		end
		declare @oldname varchar(30) = (select top 1 StateName from deleted)
		if(@oldname='�շ�' or @oldname='ռ�÷�' or @oldname='�෿'or @oldname='Ԥ��')
		begin
			raiserror('����������ϵͳ��������Ϊ�޸������ᵼ������ϵͳ�޷�����������',16,0)
			rollback
		end

	end












go
create table T_RoomList--�����б�
(
	RoomID varchar(30) primary key,--������
	RoomType int not null foreign key(RoomType) references T_RoomType(TypeID),--�������ͱ��
	RoomState int not null foreign key(RoomState) references T_RoomStateType(StateID),--����״̬���
	RoomRemark varchar(200),--��ע������
	IsValid bit Default(1),--�Ƿ���Ч
) 
go
 create view View_RoomInfo--��ѯ��Ч������Ϣ
 as
 select rl.RoomID as '������'
 ,rt.TypeID as '���ͱ��'
 ,rt.TypeName as '������'
 ,rt.TypePrice as '����'
 ,(rt.TypeRequency/3600/1000/10000) as  '����Ƶ��'
 ,rs.StateID as '״̬���'
 ,rs.StateName as '״̬��',
 rs.StateColor as '��ɫ',
rl.RoomRemark as '���䱸ע',
 '��Ч״̬'= rl.IsValid
 from T_RoomList rl join T_RoomType rt on rl.RoomType= rt.TypeID join T_RoomStateType rs on rl.RoomState= rs.StateID where rl.IsValid=1

  go
 create view View_RoomInfoAll--��ѯ���з�����Ϣ
 as
 select rl.RoomID as '������'
 ,rt.TypeID as '���ͱ��'
 ,rt.TypeName as '������'
 ,rt.TypePrice as '����'
 ,(rt.TypeRequency/3600/1000/10000) as  '����Ƶ��'
 ,rs.StateID as '״̬���'
 ,rs.StateName as '״̬��',
 rs.StateColor as '��ɫ',
rl.RoomRemark as '���䱸ע',
 '��Ч״̬'= rl.IsValid
 from T_RoomList rl join T_RoomType rt on rl.RoomType= rt.TypeID join T_RoomStateType rs on rl.RoomState= rs.StateID

 
 go
 create view View_RoomInfoNo--��ѯ��Ч������Ϣ
 as
 select rl.RoomID as '������'
 ,rt.TypeID as '���ͱ��'
 ,rt.TypeName as '������'
 ,rt.TypePrice as '����'
 ,(rt.TypeRequency/3600/1000/10000) as  '����Ƶ��'
 ,rs.StateID as '״̬���'
 ,rs.StateName as '״̬��',
 rs.StateColor as '��ɫ',
rl.RoomRemark as '���䱸ע',
 '��Ч״̬'= rl.IsValid
 from T_RoomList rl join T_RoomType rt on rl.RoomType= rt.TypeID join T_RoomStateType rs on rl.RoomState= rs.StateID where rl.IsValid=0


 go
 --������߼۸񣬲�ѯ���۵��ڴ�ֵ�����з��䣬���Żݳ̶Ƚ�������
if exists (select * from sysobjects where name='Proc_PriceSearch')
	Drop procedure Proc_PriceSearch
GO
Create proc Proc_PriceSearch
@maxprice int
AS
begin
	select * from View_RoomInfo vr where vr.����<= @maxprice order by vr.����*1.0/vr.����Ƶ��
end
go

--select * from T_RoomType
--select * from T_RoomStateType
--select * from T_RoomList



go
--�����б���ش�����
	create trigger tri_RoomList_Delete	on T_RoomList for delete
	as
	begin
		raiserror('���������ݲ�����ɾ���������뽫�˴��󱨸�������ߣ�',16,0)
		rollback
	end	













go
--�ȴ�����
create table T_ClientRoom--�ͻ�ס����Ϣ��
(
	GUID varchar(40) Default(newid()) primary key,--��¼���
	ClientGUID varchar(40) foreign key(ClientGUID) references T_ClientInfo(GUID),--�ͻ�GUID
	ClientAccount float Default(0),--�˻����(Ԫ)
	InTime datetime Default(getdate()),--��סʱ��
	LastDeduct datetime not null ,--�ϴν���
	OperatorGUID varchar(40),--����ԱID
	RoomID varchar(30) not null foreign key(RoomID) references T_RoomList(RoomID)--������
)

--����Ԥ��
create table T_BookRoom
(
	guid varchar(40) default(newid()) primary key ,--��¼���
	RoomID varchar(30) not null,--����
	BookTime datetime default(getdate()),--Ԥ��ʱ��
	BookValidTime int default(5),--��Ч����
	ClientName varchar(30) not null,--�ͻ�����
)



go

create table T_OperateType--�������ͱ�
(
	TypeID Int identity(1,1) primary key,--�������ͱ��
	OperateName varchar(30) not null,--��������
	IsValid bit Default(1),--�Ƿ���Ч
)
go
--�������ͱ���ش�����
	create trigger tri_OperateType_Delete on T_OperateType for delete
	as
	begin
		raiserror( '�������ݲ�����ɾ���������뽫�˴��󱨸�������ߣ�',16,0)
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
			raiserror('���ݳ����ظ������������ݳ���ͬ��������Ч״̬��ͬ����Ϊ�ظ�u��',16,0)
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
			raiserror('���ݳ����ظ������������ݳ���ͬ��������Ч״̬��ͬ����Ϊ�ظ�u��',16,0)
			rollback
		end
		declare @oldname varchar(30) = (select top 1 OperateName from deleted)
		if(@oldname='��ס�Ǽ�' or @oldname='�˷�����' or @oldname='���ѿ�ȡ')
		begin
			raiserror('����������ϵͳ��������Ϊ�޸������ᵼ������ϵͳ�޷�����������',16,0)
			rollback
		end

	end



go


create table T_ClientRoomOld--ס����ʷ��
(
	GUID varchar(40) Default(newid()) primary key,--��¼���
	ClientGUID varchar(40) not null,--�ͻ�GUID
	RoomID varchar(30) not null,--������
	CRinTime datetime not null,--��סʱ��
	CROutTime datetime Default(getdate()),--����ʱ��
	OperatorOGUID varchar(40) not null,--��������ԱID
	OperatorEGUID varchar(40) not null,--�˷�����ԱID
)
go
--ס����ʷ����ش�����
	create trigger tri_ClientRoomOld_Delete	on T_ClientRoomOld for delete
	as
	begin
		print '���������ݲ�����ɾ���������뽫�˴��󱨸�������ߣ�'
		rollback
	end	
	go
	create trigger tri_ClientRoomOld_update	on T_ClientRoomOld for update
	as
	begin
		print '��Щ������ϵͳ�Զ����ɣ��û��޷����������޸ģ��뽫�˴��󱨸�������ߣ�'
		rollback
	end	




go



create table T_AccountOld--�����¼��
(
	GUID varchar(40) Default(newid()) primary key,--��¼���
	ClientGUID varchar(40) not null,--�ͻ�GUID
	OperateTime datetime Default(getdate()),--����ʱ��
	OperateMoney int not null,--�������(Ԫ)
	OperatorTypeID int not null foreign key(OperatorTypeID) references T_OperateType(TypeID),--�������ͱ��
	OperatorGUID varchar(40) not null,--����ԱGUID
)
go
--�����¼����ش�����
	create trigger tri_AccountOld_Delete	on T_AccountOld for delete
	as
	begin
		print '���������ݲ�����ɾ���������뽫�˴��󱨸�������ߣ�'
		rollback
	end	
	go
	create trigger tri_AccountOld_update	on T_AccountOld for update
	as
	begin
		print '��Щ������ϵͳ�Զ����ɣ��û��޷����������޸ģ��뽫�˴��󱨸�������ߣ�'
		rollback
	end	

go









create table T_SupplierType --��Ӧ�����ͱ�
(
	ID int primary key identity(1,1),--��� ���� ������
	Name varchar(30) not null,--���� �ǿ�
	Remark varchar(200),--��ע������
	IsValid bit default(1),--�Ƿ���Ч Ĭ����Ч 1
)
go
	create trigger tri_SupplierType_Delete	on T_SupplierType for delete
	as
	begin
		print '�������ݲ�����ɾ���������뽫�˴��󱨸�������ߣ�'
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
			raiserror('�Ѿ�������ͬ�������ˣ��벻Ҫ�������ظ���',16,0) rollback
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
			raiserror('��Ϊ���������ظ���������������ע�⣬����ڽ�����Ŀʱ�����˴����������ѽ�����Ŀ���Ƿ��Ѱ�����ͬ��Ŀ��',16,0)
			rollback
		end
		else print '������ɣ�'
	end




go
create table T_SupplierInfo --��Ӧ����Ϣ
(
	SupplierID int primary key identity(1,1),--��� ���� ������
	SupplierName varchar(30) not null,--��Ӧ������ �ǿ�
	SupplierCouID int, --������
	SupplierAdress varchar(50),-- ��Ӧ�̵�ַ
	SupplierTel varchar(30),--�绰����
	SupplierTypeID int not null,--��Ӧ����
	Remark varchar(200), --��ע
	IsValid bit default(1)--�Ƿ���Ч
)
go
	create trigger tri_SupplierInfo_Delete	on T_SupplierInfo for delete
	as
	begin
		print '���������ݲ�����ɾ���������뽫�˴��󱨸�������ߣ�'
		rollback
	end	




go
create table T_WaresType--��Ʒ����
(
	WaresID	int primary key identity(1,1),--���ͱ�� ���� ������
	WaresName varchar(40) not null,--��Ʒ�� �ǿ�
	WaresImage image ,--��ƷͼƬ
	WaresRemark varchar(100),--��ע������
	IsValid bit default(1) --�Ƿ���Ч
)
go
	create trigger tri_WaresType_Delete	on T_WaresType for delete
	as
	begin
		print '�������ݲ�����ɾ���������뽫�˴��󱨸�������ߣ�'
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
		raiserror('�Ѿ�������ͬ�������ˣ��벻Ҫ����Ʒ���ظ���',16,0)
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
			raiserror('��Ϊ���������ظ���������������ע�⣬����ڽ�����Ŀʱ�����˴����������ѽ�����Ŀ���Ƿ��Ѱ�����ͬ��Ŀ��',16,0)
			rollback
		end
			else print '������ɣ�'
	end








go
create table T_StockInfo--�����Ϣ
(
	GUID varchar(40) primary key default(newid()),--��� ���� ������
	WaresID int not null,--��Ʒ���ͱ�� �ǿ�
	Inventory int check(Inventory >-1) not null ,--�������
	LowCuount int check(LowCuount>-1) not null,--ȱ������
	StockUnit int not null,--��浥λ
	IsValid bit default(1) --�Ƿ���Ч
)
go
	create trigger tri_StockInfo_Delete	on T_StockInfo for delete
	as
	begin
		print '���������ݲ�����ɾ���������뽫�˴��󱨸�������ߣ�'
		rollback
	end	













	--���
	go
create table T_UnitType --������λ
(
	UnitID int primary key identity(1,1),--��λ��� ���� ������
	UnitName varchar(45) not null,--��λ�� �ǿ�
	IsValid bit default(1) --�Ƿ���Ч
)
go
	create trigger tri_UnitType_Delete	on T_UnitType for delete
	as
	begin
		print '�������ݲ�����ɾ���������뽫�˴��󱨸�������ߣ�'
		rollback
	end
	go
	create trigger tri_UnitTypeInsert on T_UnitType instead of insert
	as
	begin
		declare @name varchar(30) = (select top 1 UnitName from inserted)
		declare @isv varchar(30) = (select top 1 IsValid from inserted)
		if exists(select * from T_UnitType where UnitName=@Name and IsValid=@isv)
		raiserror('�Ѿ�������ͬ�������ˣ��벻Ҫ�õ�λ���ظ���',16,0)
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
			raiserror('��Ϊ���������ظ���������������ע�⣬����ڽ�����Ŀʱ�����˴����������ѽ�����Ŀ���Ƿ��Ѱ�����ͬ��Ŀ��',16,0)
			rollback
		end
			else print '������ɣ�'
	end










go
create table T_OutInInfo--�������Ϣ
(
	IOGUID	varchar(40) primary key default(newid()),--���ͱ�� ���� ������
	IOWaresID int not null,--��ƷID
	SupplierID int,--��Ӧ��ID�����ʱ��Ǽǣ�
	IOCount int,--�ǿ� ����
	IOUnit int,--�ǿ� ��λ
	OperatorGUID varchar(40) not null,--����ԱGUID
	OperatorTime datetime default(getdate()),--����ʱ��
	IORemark varchar(300),--��ע������
)
go
	create trigger tri_OutInInfo_Delete	on T_OutInInfo for delete
	as
	begin
		print '���������ݲ�����ɾ���������뽫�˴��󱨸�������ߣ�'
		rollback
	end




















go
create table T_AccreditType--��Ȩ����
(
	ALevelID int primary key identity(1,1),--�ȼ���� ���� ������
	ALevelName varchar(40) not null,--�ȼ����� �ǿ�
	ALevelRemark varchar(200),--��ע������
	IsValid bit default(1) --�Ƿ���Ч
)
go
	create trigger tri_AccreditType_Delete	on T_AccreditType for delete
	as
	begin
		print '�������ݲ�����ɾ���������뽫�˴��󱨸�������ߣ�'
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
		raiserror('�Ѿ�������ͬ�������ˣ��벻Ҫ��Ȩ�޵ȼ����ظ���',16,0)
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
			raiserror('��Ϊ���������ظ���������������ע�⣬����ڽ�����Ŀʱ�����˴����������ѽ�����Ŀ���Ƿ��Ѱ�����ͬ��Ŀ��',16,0)
			rollback
		end
		else if(@name='��������Ա' or @name='�߼�����Ա' or @name='����Ա' or @name='�ÿ�')
		begin
			raiserror('���������������漰ϵͳ�ܹ��ײ�ģ�ͣ��޸���Щ���ݻᵼ��һЩ�����޷��������С����ϵͳ�ж�����Ĳ�����',16,0) rollback
		end
		else print '������ɣ�'
	end




















go
create table T_AccreditList--��Ȩ�б�
(
	AccreditGUID varchar(40) primary key default(newid()),--��Ȩ�� ���� ������
	AStartDate datetime not null, --��Чʱ��
	AEndDate datetime not null, --�ǿ� ʧЧʱ��
	ALevel int --��Ȩ�ȼ�
)


go
create table T_StaffType--ְ������
(
	STypeID int primary key identity(1,1),--���ͱ�� ���� ������
	STypeName varchar(40) not null,--�ǿ� ְ�����ƣ��磺���ܣ�
	STypeALevelID int, --Ȩ�޷ּ����
	IsValid bit default(1) --�Ƿ���Ч
)
go
	create trigger tri_StaffType_Delete	on T_StaffType for delete
	as
	begin
		print '�������ݲ�����ɾ���������뽫�˴��󱨸�������ߣ�'
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
		raiserror('�Ѿ�������ͬ�������ˣ��벻Ҫ�������ظ���',16,0)
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
			raiserror('��Ϊ���������ظ���������������ע�⣬����ڽ�����Ŀʱ�����˴����������ѽ�����Ŀ���Ƿ��Ѱ�����ͬ��Ŀ��',16,0)
			rollback
		end
			else print '������ɣ�'
	end


go
create table T_StaffInfo--Ա��������Ϣ
(
	StaffID varchar(40) primary key default(newid()),--Ψһ��ʶ ���� ������
	StaffName varchar(30), --�ǿ� Ա������
	StaffSex bit, --�ǿ� �Ա�
	StaffCouID int, --������
	StaffAdress varchar(50),--��ַ���
	StaffIdCard varchar(30), --���֤��
	StaffInDate date default(getdate()), --��ְʱ��
	StaffImage image, --ͷ��
	StaffTel varchar(40),--Ա���绰
	IsValid bit not null default(1) --�Ƿ���ְ
)

go
	create trigger tri_StaffInfo_Delete	on T_StaffInfo for delete
	as
	begin
		print '���������ݲ�����ɾ���������뽫�˴��󱨸�������ߣ�'
		rollback
	end	



	declare @g varchar(40) = newid()
	print @g

go
create table T_StaffList--��ְԱ���б�
(
	StaffID varchar(40) primary key,--Ψһ��ʶ ���� ������
	StaffPwdMD5 varchar(50), --Ա������
	StaffGuid varchar(40), --Ψһ��ʶ
	StaffAccredit varchar(40), --��Ȩ����
	STypeID int, --ְ����
)
go
--��¼
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
	else raiserror( '�˺Ų����ڻ��������',16,0)
go


--select a.StaffID as '���к�',StaffName as '����',StaffIdCard as '���֤',
--b.StaffID '����',b.StaffAccredit '��Ȩ��',STypeName 'ְ��' ,
--StaffSex as'�Ա�',CountryName as '����',StaffAdress as '��ַ',
--StaffInDate as '��ְʱ��',StaffTel as '�绰����',a.StaffName 'GUID'
-- from T_StaffInfo a left join T_StaffList b on a.StaffID=b.StaffGuid left join T_CountryInfo on a.StaffCouID=T_CountryInfo.CountryID
--left join T_StaffType on b.STypeID=T_StaffType.STypeID where a.IsValid=1

go
--���Լ�� �����T_SupplierInfo��� SupplierTypeID  ������ T_SupplierType���ID
alter table T_SupplierInfo
	add constraint FK_SupplierTypeID foreign key (SupplierTypeID) references T_SupplierType(ID)
--���Լ�� �����T_StockInfo��� GUID  ������ T_WaresType���WaresID
alter table T_StockInfo
	add constraint FK_WaresID foreign key (WaresID) references T_WaresType(WaresID)
--���Լ�� �����T_StockInfo��� StockUnit  ������ T_UnitType���UnitID
alter table T_StockInfo
	add constraint FK_StockUnit foreign key (StockUnit) references T_UnitType(UnitID)
--���Լ�� �����T_OutInInfo��� IOWaresID  ������ T_WaresType���WaresID
alter table T_OutInInfo
	add constraint FK_IOWaresID foreign key (IOWaresID) references T_WaresType(WaresID)
--���Լ�� �����T_OutInInfo��� IOUnit  ������ T_UnitType���UnitID
alter table T_OutInInfo
	add constraint FK_IOUnit foreign key (IOUnit) references T_UnitType(UnitID)
--���Լ�� �����T_AccreditList��� ALevel  ������ T_AccreditType���ALevelID
alter table T_AccreditList
	add constraint FK_ALevel foreign key (ALevel) references T_AccreditType(ALevelID)
--���Լ�� �����T_StaffType��� STypeALevelID  ������ T_AccreditType���ALevelID
alter table T_StaffType
	add constraint FK_STypeALevelID foreign key (STypeALevelID) references T_AccreditType(ALevelID)
--���Լ�� �����T_StaffList��� STypeID  ������ T_StaffType���STypeID
alter table T_StaffList
	add constraint FK_STypeID foreign key (STypeID) references T_StaffType(STypeID)
--���Լ�� �����T_StaffList��� STypeID  ������ T_StaffInfo���StaffID
alter table T_StaffList
	add constraint FK_StaffGuid foreign key (StaffGuid) references T_StaffInfo(StaffID)
go