﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LinQ_To_EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class TavernManageEntities : DbContext
    {
        public TavernManageEntities()
            : base("name=TavernManageEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<T_AccountOld> T_AccountOld { get; set; }
        public DbSet<T_AccreditList> T_AccreditList { get; set; }
        public DbSet<T_AccreditType> T_AccreditType { get; set; }
        public DbSet<T_BookRoom> T_BookRoom { get; set; }
        public DbSet<T_ClientInfo> T_ClientInfo { get; set; }
        public DbSet<T_ClientRoom> T_ClientRoom { get; set; }
        public DbSet<T_ClientRoomOld> T_ClientRoomOld { get; set; }
        public DbSet<T_CountryInfo> T_CountryInfo { get; set; }
        public DbSet<T_OperateType> T_OperateType { get; set; }
        public DbSet<T_OutInInfo> T_OutInInfo { get; set; }
        public DbSet<T_PaperType> T_PaperType { get; set; }
        public DbSet<T_RoomList> T_RoomList { get; set; }
        public DbSet<T_RoomStateType> T_RoomStateType { get; set; }
        public DbSet<T_RoomType> T_RoomType { get; set; }
        public DbSet<T_StaffInfo> T_StaffInfo { get; set; }
        public DbSet<T_StaffList> T_StaffList { get; set; }
        public DbSet<T_StaffType> T_StaffType { get; set; }
        public DbSet<T_StockInfo> T_StockInfo { get; set; }
        public DbSet<T_SupplierInfo> T_SupplierInfo { get; set; }
        public DbSet<T_SupplierType> T_SupplierType { get; set; }
        public DbSet<T_UnitType> T_UnitType { get; set; }
        public DbSet<T_VIPInfo> T_VIPInfo { get; set; }
        public DbSet<T_VIPLevel> T_VIPLevel { get; set; }
        public DbSet<T_WaresType> T_WaresType { get; set; }
        public DbSet<View_Charge> View_Charge { get; set; }
        public DbSet<View_ClientRoomState> View_ClientRoomState { get; set; }
        public DbSet<view_ConsumeHistory> view_ConsumeHistory { get; set; }
        public DbSet<view_HousingHistory> view_HousingHistory { get; set; }
        public DbSet<View_RoomInfo> View_RoomInfo { get; set; }
        public DbSet<View_RoomInfoAll> View_RoomInfoAll { get; set; }
        public DbSet<View_RoomInfoNo> View_RoomInfoNo { get; set; }
        public DbSet<View_RoomStateCount> View_RoomStateCount { get; set; }
        public DbSet<View_RoomTypeCount> View_RoomTypeCount { get; set; }
    
        public virtual ObjectResult<Proc_AccountRemind_Result> Proc_AccountRemind()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Proc_AccountRemind_Result>("Proc_AccountRemind");
        }
    
        public virtual int Proc_AutoDeleteBook()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Proc_AutoDeleteBook");
        }
    
        public virtual int Proc_AutoSettleAccounts()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Proc_AutoSettleAccounts");
        }
    
        public virtual int Proc_BookClientIn(string clientIName, Nullable<int> clientCType, string clientIDCard, Nullable<bool> clientSex, string clientAdress, string clientTel, string clientVipID, Nullable<double> clientAccount, string operatorID, string roomID)
        {
            var clientINameParameter = clientIName != null ?
                new ObjectParameter("ClientIName", clientIName) :
                new ObjectParameter("ClientIName", typeof(string));
    
            var clientCTypeParameter = clientCType.HasValue ?
                new ObjectParameter("ClientCType", clientCType) :
                new ObjectParameter("ClientCType", typeof(int));
    
            var clientIDCardParameter = clientIDCard != null ?
                new ObjectParameter("ClientIDCard", clientIDCard) :
                new ObjectParameter("ClientIDCard", typeof(string));
    
            var clientSexParameter = clientSex.HasValue ?
                new ObjectParameter("ClientSex", clientSex) :
                new ObjectParameter("ClientSex", typeof(bool));
    
            var clientAdressParameter = clientAdress != null ?
                new ObjectParameter("ClientAdress", clientAdress) :
                new ObjectParameter("ClientAdress", typeof(string));
    
            var clientTelParameter = clientTel != null ?
                new ObjectParameter("ClientTel", clientTel) :
                new ObjectParameter("ClientTel", typeof(string));
    
            var clientVipIDParameter = clientVipID != null ?
                new ObjectParameter("ClientVipID", clientVipID) :
                new ObjectParameter("ClientVipID", typeof(string));
    
            var clientAccountParameter = clientAccount.HasValue ?
                new ObjectParameter("ClientAccount", clientAccount) :
                new ObjectParameter("ClientAccount", typeof(double));
    
            var operatorIDParameter = operatorID != null ?
                new ObjectParameter("OperatorID", operatorID) :
                new ObjectParameter("OperatorID", typeof(string));
    
            var roomIDParameter = roomID != null ?
                new ObjectParameter("RoomID", roomID) :
                new ObjectParameter("RoomID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Proc_BookClientIn", clientINameParameter, clientCTypeParameter, clientIDCardParameter, clientSexParameter, clientAdressParameter, clientTelParameter, clientVipIDParameter, clientAccountParameter, operatorIDParameter, roomIDParameter);
        }
    
        public virtual int Proc_BookRoom(string clientName, string roomID, Nullable<int> bookValidTime)
        {
            var clientNameParameter = clientName != null ?
                new ObjectParameter("ClientName", clientName) :
                new ObjectParameter("ClientName", typeof(string));
    
            var roomIDParameter = roomID != null ?
                new ObjectParameter("RoomID", roomID) :
                new ObjectParameter("RoomID", typeof(string));
    
            var bookValidTimeParameter = bookValidTime.HasValue ?
                new ObjectParameter("BookValidTime", bookValidTime) :
                new ObjectParameter("BookValidTime", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Proc_BookRoom", clientNameParameter, roomIDParameter, bookValidTimeParameter);
        }
    
        public virtual int Proc_ClientCheckIn(string clientIName, Nullable<int> clientCType, string clientIDCard, Nullable<bool> clientSex, string clientAdress, string clientTel, string clientVipID, Nullable<double> clientAccount, string operatorID, string roomID)
        {
            var clientINameParameter = clientIName != null ?
                new ObjectParameter("ClientIName", clientIName) :
                new ObjectParameter("ClientIName", typeof(string));
    
            var clientCTypeParameter = clientCType.HasValue ?
                new ObjectParameter("ClientCType", clientCType) :
                new ObjectParameter("ClientCType", typeof(int));
    
            var clientIDCardParameter = clientIDCard != null ?
                new ObjectParameter("ClientIDCard", clientIDCard) :
                new ObjectParameter("ClientIDCard", typeof(string));
    
            var clientSexParameter = clientSex.HasValue ?
                new ObjectParameter("ClientSex", clientSex) :
                new ObjectParameter("ClientSex", typeof(bool));
    
            var clientAdressParameter = clientAdress != null ?
                new ObjectParameter("ClientAdress", clientAdress) :
                new ObjectParameter("ClientAdress", typeof(string));
    
            var clientTelParameter = clientTel != null ?
                new ObjectParameter("ClientTel", clientTel) :
                new ObjectParameter("ClientTel", typeof(string));
    
            var clientVipIDParameter = clientVipID != null ?
                new ObjectParameter("ClientVipID", clientVipID) :
                new ObjectParameter("ClientVipID", typeof(string));
    
            var clientAccountParameter = clientAccount.HasValue ?
                new ObjectParameter("ClientAccount", clientAccount) :
                new ObjectParameter("ClientAccount", typeof(double));
    
            var operatorIDParameter = operatorID != null ?
                new ObjectParameter("OperatorID", operatorID) :
                new ObjectParameter("OperatorID", typeof(string));
    
            var roomIDParameter = roomID != null ?
                new ObjectParameter("RoomID", roomID) :
                new ObjectParameter("RoomID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Proc_ClientCheckIn", clientINameParameter, clientCTypeParameter, clientIDCardParameter, clientSexParameter, clientAdressParameter, clientTelParameter, clientVipIDParameter, clientAccountParameter, operatorIDParameter, roomIDParameter);
        }
    
        public virtual int Proc_ClientOut(string roomID, string operatorID)
        {
            var roomIDParameter = roomID != null ?
                new ObjectParameter("RoomID", roomID) :
                new ObjectParameter("RoomID", typeof(string));
    
            var operatorIDParameter = operatorID != null ?
                new ObjectParameter("OperatorID", operatorID) :
                new ObjectParameter("OperatorID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Proc_ClientOut", roomIDParameter, operatorIDParameter);
        }
    
        public virtual int Proc_DeleteBookRoom(string roomID)
        {
            var roomIDParameter = roomID != null ?
                new ObjectParameter("RoomID", roomID) :
                new ObjectParameter("RoomID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Proc_DeleteBookRoom", roomIDParameter);
        }
    
        public virtual ObjectResult<Proc_EmptyRoomCount_Result> Proc_EmptyRoomCount()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Proc_EmptyRoomCount_Result>("Proc_EmptyRoomCount");
        }
    
        public virtual ObjectResult<Proc_PriceSearch_Result> Proc_PriceSearch(Nullable<int> maxprice)
        {
            var maxpriceParameter = maxprice.HasValue ?
                new ObjectParameter("maxprice", maxprice) :
                new ObjectParameter("maxprice", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Proc_PriceSearch_Result>("Proc_PriceSearch", maxpriceParameter);
        }
    
        public virtual int proc_RoomChange(string operatorID, string oldRoomID, string newRoomID)
        {
            var operatorIDParameter = operatorID != null ?
                new ObjectParameter("OperatorID", operatorID) :
                new ObjectParameter("OperatorID", typeof(string));
    
            var oldRoomIDParameter = oldRoomID != null ?
                new ObjectParameter("oldRoomID", oldRoomID) :
                new ObjectParameter("oldRoomID", typeof(string));
    
            var newRoomIDParameter = newRoomID != null ?
                new ObjectParameter("newRoomID", newRoomID) :
                new ObjectParameter("newRoomID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proc_RoomChange", operatorIDParameter, oldRoomIDParameter, newRoomIDParameter);
        }
    
        public virtual int Proc_StaffResign(string staffID)
        {
            var staffIDParameter = staffID != null ?
                new ObjectParameter("StaffID", staffID) :
                new ObjectParameter("StaffID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Proc_StaffResign", staffIDParameter);
        }
    
        public virtual ObjectResult<Proc_UserLogin_Result> Proc_UserLogin(string staffID, string staffPass)
        {
            var staffIDParameter = staffID != null ?
                new ObjectParameter("StaffID", staffID) :
                new ObjectParameter("StaffID", typeof(string));
    
            var staffPassParameter = staffPass != null ?
                new ObjectParameter("StaffPass", staffPass) :
                new ObjectParameter("StaffPass", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Proc_UserLogin_Result>("Proc_UserLogin", staffIDParameter, staffPassParameter);
        }
    }
}
