Use TavernManage
go

--房间状态类型定义
insert into T_RoomStateType (StateName,StateColor,StateRemark)
values('空房','#090','空房表示当前没有人居住的空余房间')
go
insert into T_RoomStateType (StateName,StateColor,StateRemark)
values('占用房','#C00','占用房表示当前房间正在被居住')
go
insert into T_RoomStateType (StateName,StateColor,StateRemark)
values('脏房','#CCC','脏房表示客户退房后未经打扫的状态')
go
insert into T_RoomStateType (StateName,StateColor,StateRemark)
values('预订','#CC0','预订表示房间被客户预约，有效时间5天')
go


--操作类型
insert into T_OperateType(OperateName)
values('入住登记')
go
insert into T_OperateType(OperateName)
values('退房结账')
go
insert into T_OperateType(OperateName)
values('房费扣取')
go




--24小时内酒店资金情况
create view view_HotelFund
as
select 'OperateName'=case
	when OperateName='入住登记' then '收取现金'
	when OperateName='退房结账' then '客户退房'
	when OperateName='房费扣取' then '房费收入(净)'
end
,'Cash'=
case
	when OperateName='房费扣取' then -(Cash)
	else Cash
end
 from
(select 'Cash'=sum(OperateMoney),OperatorTypeID from T_AccountOld 
	where dateadd(HOUR,24,OperateTime)>=GETDATE() group by OperatorTypeID) old join T_OperateType on old.OperatorTypeID=T_OperateType.TypeID 


go

--权限等级
insert into T_AccreditType(ALevelName,ALevelRemark)
values('超级管理员','具有最高级权限的超级用户，可以进行任何操作')
go
insert into T_AccreditType(ALevelName,ALevelRemark)
values('高级管理员','权限相对较高，可以进行大部分操作的用户')
go
insert into T_AccreditType(ALevelName,ALevelRemark)
values('管理员','权限较低，可以进行一般性操作的用户')
go
insert into T_AccreditType(ALevelName,ALevelRemark)
values('访客','不具备数据操作权限,只能查询一些基本信息')

go




--证件类型
insert into T_PaperType(PapersName)
values('二代身份证')
go


--国家列表
insert into T_CountryInfo(CountryName)
values('中国')
go


--会员等级
insert into T_VIPLevel(LevelName,LevelIntegral,VipDiscount)
values('普通会员',0,99)
go
insert into T_VIPLevel(LevelName,LevelIntegral,VipDiscount)
values('高级会员',5000,95)
go
insert into T_VIPLevel(LevelName,LevelIntegral,VipDiscount)
values('黄金会员',20000,90)
go
insert into T_VIPLevel(LevelName,LevelIntegral,VipDiscount)
values('白金会员',100000,85)
go

insert into T_StaffType(STypeName,STypeALevelID)
values('前台收银',3)
go
insert into T_StaffType(STypeName,STypeALevelID)
values('房间管理',2)
go
insert into T_StaffType(STypeName,STypeALevelID)
values('酒店经理',1)
go

