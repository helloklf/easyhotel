Use TavernManage
go

--����״̬���Ͷ���
insert into T_RoomStateType (StateName,StateColor,StateRemark)
values('�շ�','#090','�շ���ʾ��ǰû���˾�ס�Ŀ��෿��')
go
insert into T_RoomStateType (StateName,StateColor,StateRemark)
values('ռ�÷�','#C00','ռ�÷���ʾ��ǰ�������ڱ���ס')
go
insert into T_RoomStateType (StateName,StateColor,StateRemark)
values('�෿','#CCC','�෿��ʾ�ͻ��˷���δ����ɨ��״̬')
go
insert into T_RoomStateType (StateName,StateColor,StateRemark)
values('Ԥ��','#CC0','Ԥ����ʾ���䱻�ͻ�ԤԼ����Чʱ��5��')
go


--��������
insert into T_OperateType(OperateName)
values('��ס�Ǽ�')
go
insert into T_OperateType(OperateName)
values('�˷�����')
go
insert into T_OperateType(OperateName)
values('���ѿ�ȡ')
go




--24Сʱ�ھƵ��ʽ����
create view view_HotelFund
as
select 'OperateName'=case
	when OperateName='��ס�Ǽ�' then '��ȡ�ֽ�'
	when OperateName='�˷�����' then '�ͻ��˷�'
	when OperateName='���ѿ�ȡ' then '��������(��)'
end
,'Cash'=
case
	when OperateName='���ѿ�ȡ' then -(Cash)
	else Cash
end
 from
(select 'Cash'=sum(OperateMoney),OperatorTypeID from T_AccountOld 
	where dateadd(HOUR,24,OperateTime)>=GETDATE() group by OperatorTypeID) old join T_OperateType on old.OperatorTypeID=T_OperateType.TypeID 


go

--Ȩ�޵ȼ�
insert into T_AccreditType(ALevelName,ALevelRemark)
values('��������Ա','������߼�Ȩ�޵ĳ����û������Խ����κβ���')
go
insert into T_AccreditType(ALevelName,ALevelRemark)
values('�߼�����Ա','Ȩ����Խϸߣ����Խ��д󲿷ֲ������û�')
go
insert into T_AccreditType(ALevelName,ALevelRemark)
values('����Ա','Ȩ�޽ϵͣ����Խ���һ���Բ������û�')
go
insert into T_AccreditType(ALevelName,ALevelRemark)
values('�ÿ�','���߱����ݲ���Ȩ��,ֻ�ܲ�ѯһЩ������Ϣ')

go




--֤������
insert into T_PaperType(PapersName)
values('�������֤')
go


--�����б�
insert into T_CountryInfo(CountryName)
values('�й�')
go


--��Ա�ȼ�
insert into T_VIPLevel(LevelName,LevelIntegral,VipDiscount)
values('��ͨ��Ա',0,99)
go
insert into T_VIPLevel(LevelName,LevelIntegral,VipDiscount)
values('�߼���Ա',5000,95)
go
insert into T_VIPLevel(LevelName,LevelIntegral,VipDiscount)
values('�ƽ��Ա',20000,90)
go
insert into T_VIPLevel(LevelName,LevelIntegral,VipDiscount)
values('�׽��Ա',100000,85)
go

insert into T_StaffType(STypeName,STypeALevelID)
values('ǰ̨����',3)
go
insert into T_StaffType(STypeName,STypeALevelID)
values('�������',2)
go
insert into T_StaffType(STypeName,STypeALevelID)
values('�Ƶ꾭��',1)
go

