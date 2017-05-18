using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TModel
{
    //房间信息实体类


    /// <summary>
    /// VIP 类型表
    /// </summary>
    public class T_VIPLevel
    {
        private int levelID;
        private string levelName;
        private int levelIntegral;
        private int vipDiscount;
        private bool isValid;
        /// <summary>
        /// 等级编号
        /// </summary>
        public int LevelID
        {
            get { return levelID; }
            set { levelID = value; }
        }

        /// <summary>
        /// 等级称号
        /// </summary>
        public string LevelName
        {
            get { return levelName; }
            set { levelName = value; }
        }

        /// <summary>
        /// 等级所需积分
        /// </summary>
        public int LevelIntegral
        {
            get { return levelIntegral; }
            set { levelIntegral = value; }
        }
        /// <summary>
        /// 折扣百分比
        /// </summary>
        public int VipDiscount
        {
            get { return vipDiscount; }
            set { vipDiscount = value; }
        }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        /// <summary>
        /// 文本化的是否有效信息
        /// </summary>
        public string IsValidText 
        {
            get { return IsValid ? "有效" : "无效"; }
        }
    }

    /// <summary>
    /// VIP信息表
    /// </summary>
    public class T_VIPInfo
    {
        private string vIPID;
        private int vIPIntegral;
        private int countryID;
        private bool isValid;
        /// <summary>
        /// VIP编号
        /// </summary>
        public string VIPID
        {
            get { return vIPID; }
            set { vIPID = value; }
        }

        /// <summary>
        /// 会员积分
        /// </summary>
        public int VIPIntegral
        {
            get { return vIPIntegral; }
            set { vIPIntegral = value; }
        }

        /// <summary>
        /// 国籍编号
        /// </summary>
        public int CountryID
        {
            get { return countryID; }
            set { countryID = value; }
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        /// <summary>
        /// 文本化的是否有效信息
        /// </summary>
        public string IsValidText
        {
            get { return IsValid ? "有效" : "无效"; }
        }

    }


    /// <summary>
    /// 国家信息表
    /// </summary>
    public class T_CountryInfo
    {
        private int countryID;
        private string countryName;
        private bool isValid;
        /// <summary>
        /// 国家编号
        /// </summary>
        public int CountryID
        {
            get { return countryID; }
            set { countryID = value; }
        }

        /// <summary>
        /// 国名
        /// </summary>
        public string CountryName
        {
            get { return countryName; }
            set { countryName = value; }
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        /// <summary>
        /// 文本化的是否有效信息
        /// </summary>
        public string IsValidText
        {
            get { return IsValid ? "有效" : "无效"; }
        }
    }

    /// <summary>
    /// 证件类型表
    /// </summary>
    public class T_PaperType
    {
        private int papersID;
        private string papersName;
        private bool isValid;
        /// <summary>
        /// 证件类型编号
        /// </summary>
        public int PapersID
        {
            get { return papersID; }
            set { papersID = value; }
        }

        /// <summary>
        /// 证件号类型名
        /// </summary>
        public string PapersName
        {
            get { return papersName; }
            set { papersName = value; }
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        /// <summary>
        /// 文本化的是否有效信息
        /// </summary>
        public string IsValidText
        {
            get { return IsValid ? "有效" : "无效"; }
        }
    }

    /// <summary>
    /// 客户信息表
    /// </summary>
    public class T_ClientInfo:T_PaperType
    {
        private string gUID;
        private int clientCType;
        private string clientIDCard;
        private string clientIName;
        private bool clientSex;
        private string clientAdress;
        private string clientTel;
        private string clientVIPID;
        /// <summary>
        /// 记录编号
        /// </summary>
        public string GUID
        {
            get { return gUID; }
            set { gUID = value; }
        }

        /// <summary>
        /// 证件类型	
        /// </summary>
        public int ClientCType
        {
            get { return clientCType; }
            set { clientCType = value; }
        }

        /// <summary>
        /// 证件号
        /// </summary>
        public string ClientIDCard
        {
            get { return clientIDCard; }
            set { clientIDCard = value; }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string ClientIName
        {
            get { return clientIName; }
            set { clientIName = value; }
        }

        /// <summary>
        /// 性别
        /// </summary>
        public bool ClientSex
        {
            get { return clientSex; }
            set { clientSex = value; }
        }

        /// <summary>
        /// 客户地址
        /// </summary>
        public string ClientAdress
        {
            get { return clientAdress; }
            set { clientAdress = value; }
        }

        /// <summary>
        /// 头像
        /// </summary>
        public string ClientTel
        {
            get { return clientTel; }
            set { clientTel = value; }
        }

        /// <summary>
        /// VIP编号
        /// </summary>
        public string ClientVIPID
        {
            get { return clientVIPID; }
            set { clientVIPID = value; }
        }
    }

    /// <summary>
    /// 房间类型表
    /// </summary>
    public class T_RoomType
    {
        private int typeID;
        private string typeName;
        private int typePrice;
        private int typeVipPrice;

        public int TypeVipPrice
        {
            get { return typeVipPrice; }
            set { typeVipPrice = value; }
        }
        int typeRequency;
        private bool isValid;

        /// <summary>
        /// 房间类型编号
        /// </summary>
        public int TypeID
        {
            get { return typeID; }
            set { typeID = value; }
        }

        /// <summary>
        /// 类型
        /// </summary>
        public string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }

        /// <summary>
        /// 类型单价
        /// </summary>
        public int TypePrice
        {
            get { return typePrice; }
            set { typePrice = value; }
        }
        /// <summary>
        /// 结算频率
        /// </summary>
        public int TypeRequency
        {
            get { return typeRequency; }
            set { typeRequency = value; }
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        /// <summary>
        /// 文本化的是否有效信息
        /// </summary>
        public string IsValidText
        {
            get { return IsValid ? "有效" : "无效"; }
        }
    }
    /// <summary>
    /// 房间状态类型表
    /// </summary>
    public class T_RoomStateType
    {
        private int stateID;
        private string stateName;
        private string stateRemark;
        public string StateColor = "#0000";
        private bool isValid;

        /// <summary>
        /// 显示颜色
        /// </summary> 
        public SolidColorBrush StateColorBrush
        {
            get {
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString(StateColor));
            }
        }

        /// <summary>
        /// 房间编号
        /// </summary>
        public int StateID
        {
            get { return stateID; }
            set { stateID = value; }
        }

        /// <summary>
        /// 类型名
        /// </summary>
        public string StateName
        {
            get { return stateName; }
            set { stateName = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string StateRemark
        {
            get { return stateRemark; }
            set { stateRemark = value; }
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        /// <summary>
        /// 文本化的是否有效信息
        /// </summary>
        public string IsValidText
        {
            get { return IsValid ? "有效" : "无效"; }
        }
    }

    /// <summary>
    /// 房间列表
    /// </summary>
    public class T_RoomList:T_RoomType
    {
        private string roomID;
        private int roomType;
        private int roomState;
        private string roomRemark;
        private bool isValid;
        /// <summary>
        /// 房间编号
        /// </summary>
        public string RoomID
        {
            get { return roomID; }
            set { roomID = value; }
        }

        /// <summary>
        /// 房间类型编号
        /// </summary>
        public int RoomType
        {
            get { return roomType; }
            set { roomType = value; }
        }

        /// <summary>
        /// 房间状态编号
        /// </summary>
        public int RoomState
        {
            get { return roomState; }
            set { roomState = value; }
        }

        /// <summary>
        /// 备注和描述
        /// </summary>
        public string RoomRemark
        {
            get { return roomRemark; }
            set { roomRemark = value; }
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        public new bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        /// <summary>
        /// 文本化的是否有效信息
        /// </summary>
        public new string IsValidText
        {
            get { return IsValid ? "有效" : "无效"; }
        }
    }

    public class View_RoomInfo:T_RoomList
    {
        private int stateID;
        /// <summary>
        /// 房间状态编号
        /// </summary>
        public int StateID
        {
            get { return stateID; }
            set { stateID = value; }
        }
        /// <summary>
        /// 标识房间状态的颜色(文本化)
        /// </summary>
        public string StateColor = "#0000";

        /// <summary>
        /// 标识房间状态的颜色
        /// </summary>
        public SolidColorBrush SCBrush
        {
            get { return new SolidColorBrush((Color)ColorConverter.ConvertFromString(StateColor)); }
        }

        /// <summary>
        /// 文本化用于显示的价格
        /// </summary>
        public string PriceText { get { return "￥"+TypePrice+"/"+TypeRequency+"h"; } }

        string roomTypeName;
        /// <summary>
        /// 房间类型名
        /// </summary>
        public string RoomTypeName
        {
            get { return roomTypeName; }
            set { roomTypeName = value; }
        }

        string roomStateName;
        /// <summary>
        /// 房间状态名
        /// </summary>
        public string RoomStateName
        {
            get { return roomStateName; }
            set { roomStateName = value; }
        }

    }

    /// <summary>
    /// 客户房间预订信息
    /// </summary>
    public class T_BookRoom 
    {
        string gUID;
        /// <summary>
        /// 记录编号
        /// </summary>
        public string GUID
        {
            get { return gUID; }
            set { gUID = value; }
        }

        string roomID;
        /// <summary>
        /// 预订房间号
        /// </summary>
        public string RoomID
        {
            get { return roomID; }
            set { roomID = value; }
        }

        DateTime bookTime;
        /// <summary>
        /// 预订时间
        /// </summary>
        public DateTime BookTime
        {
            get { return bookTime; }
            set { bookTime = value; }
        }

        int bookValidTime;
        /// <summary>
        /// 预订有效天数
        /// </summary>
        public int BookValidTime
        {
            get { return bookValidTime; }
            set { bookValidTime = value; }
        }

        string clientName;
        /// <summary>
        /// 预订客户的姓名
        /// </summary>
        public string ClientName
        {
            get { return clientName; }
            set { clientName = value; }
        }
    }
    

//create table T_BookRoom
//(
//    guid varchar(40) default(newid()) primary key ,--记录编号
//    RoomID varchar(30) not null,--房号
//    BookTime datetime default(getdate()),--预订时间
//    BookValidTime int default(5),--有效天数
//    ClientName varchar(30) not null,--客户姓名
//)


    /// <summary>
    /// 客户住房信息表
    /// </summary>
    public class T_ClientRoom
    {
        private string gUID;
        private string clientGUID;
        private int clientAccount;
        private DateTime inTime;
        private DateTime lastDeduct;
        private string operatorGUID;
        private string roomID;
        /// <summary>
        /// 记录编号
        /// </summary>
        public string GUID
        {
            get { return gUID; }
            set { gUID = value; }
        }

        /// <summary>
        /// 客户GUID
        /// </summary>
        public string ClientGUID
        {
            get { return clientGUID; }
            set { clientGUID = value; }
        }

        /// <summary>
        /// 账户余额(元)
        /// </summary>
        public int ClientAccount
        {
            get { return clientAccount; }
            set { clientAccount = value; }
        }

        /// <summary>
        /// 入住时间
        /// </summary>
        public DateTime InTime
        {
            get { return inTime; }
            set { inTime = value; }
        }
        /// <summary>
        /// 上次结账时间
        /// </summary>
        public DateTime LastDeduct
        {
            get { return lastDeduct; }
            set { lastDeduct = value; }
        }
        /// <summary>
        /// 操作员ID
        /// </summary>
        public string OperatorGUID
        {
            get { return operatorGUID; }
            set { operatorGUID = value; }
        }

        /// <summary>
        /// 房间编号
        /// </summary>
        public string RoomID
        {
            get { return roomID; }
            set { roomID = value; }
        }
    }

    public class View_ProcClientIn 
    {
        //@ClientCType int,--证件类型
        //@ClientIDCard varchar(10),--证件号
        //@ClientIName Varchar(10),--姓名
        //@ClientSex bit,--性别
        //@VIPAdress Varchar(40),--客户地址
        //@ClientVIPID int,--VIP编号
        //@ClientAccount int ,--账户金额
        //@OperatorGUID varchar(30),--操作员ID
        //@RoomID varchar(10)--房间号

        int clientCType;//证件类型

        /// <summary>
        /// 证件类型
        /// </summary>
        public int ClientCType
        {
            get { return clientCType; }
            set { clientCType = value; }
        }

        string clientIDCard;//证件号
        /// <summary>
        /// 证件号
        /// </summary>
        public string ClientIDCard
        {
            get { return clientIDCard; }
            set { clientIDCard = value; }
        }
        
        string clientIName;//客户姓名
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string ClientIName
        {
            get { return clientIName; }
            set { clientIName = value; }
        }
        
        bool clientSex;//客户性别
        /// <summary>
        /// 客户性别
        /// </summary>
        public bool ClientSex
        {
            get { return clientSex; }
            set { clientSex = value; }
        }

        string clientAdress;//客户地址
        /// <summary>
        /// 客户地址
        /// </summary>
        public string ClientAdress
        {
            get { return clientAdress; }
            set { clientAdress = value; }
        }
        
        string clientTel;//客户电话号码
        /// <summary>
        /// 客户电话
        /// </summary>
        public string ClientTel
        {
            get { return clientTel; }
            set { clientTel = value; }
        }

        string clientVipID;//客户VIP号
        /// <summary>
        /// VIP号
        /// </summary>
        public string ClientVipID
        {
            get { return clientVipID; }
            set { clientVipID = value; }
        }

        float clientAccount;//账户余额
        /// <summary>
        /// 账户余额
        /// </summary>
        public float ClientAccount
        {
            get { return clientAccount; }
            set { clientAccount = value; }
        }
        
        string operatorID;//操作员工号
        /// <summary>
        /// 操作员工号
        /// </summary>
        public string OperatorID
        {
            get { return operatorID; }
            set { operatorID = value; }
        }

        string roomID;//房间号
        /// <summary>
        /// 房间号
        /// </summary>
        public string RoomID
        {
            get { return roomID; }
            set { roomID = value; }
        }
    }

    public class View_ClientRoomState 
    {

        string dataGUID;
        /// <summary>
        /// 记录编号
        /// </summary>
        public string DataGUID
        {
            get { return dataGUID; }
            set { dataGUID = value; }
        }


        double clientAccount;
        /// <summary>
        /// 账户余额
        /// </summary>
        public double ClientAccount
        {
            get { return clientAccount; }
            set { clientAccount = value; }
        }


        DateTime inRoomTime;
        /// <summary>
        /// 入住时间
        /// </summary>
        public DateTime InRoomTime
        {
            get { return inRoomTime; }
            set { inRoomTime = value; }
        }


        DateTime lastDeduct;
        /// <summary>
        /// 最后结账
        /// </summary>
        public DateTime LastDeduct
        {
            get { return lastDeduct; }
            set { lastDeduct = value; }
        }


        string roomID;
        /// <summary>
        /// 房间编号
        /// </summary>
        public string RoomID
        {
            get { return roomID; }
            set { roomID = value; }
        }


        string clientName;
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string ClientName
        {
            get { return clientName; }
            set { clientName = value; }
        }
    }

    /// <summary>
    /// 操作类型表
    /// </summary>
    public class T_OperateType
    {
        private int typeID;
        private string operateName;
        private bool isValid;
        /// <summary>
        /// 操作类型编号
        /// </summary>
        public int TypeID
        {
            get { return typeID; }
            set { typeID = value; }
        }

        /// <summary>
        /// 操作名称
        /// </summary>
        public string OperateName
        {
            get { return operateName; }
            set { operateName = value; }
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        /// <summary>
        /// 文本化的是否有效信息
        /// </summary>
        public string IsValidText
        {
            get { return IsValid ? "有效" : "无效"; }
        }
    }

    /// <summary>
    /// 住房历史表
    /// </summary>
    public class T_ClientRoomOld
    {
        private string gUID;
        private string clientGUID;
        private string roomID;
        private DateTime cRinTime;
        private DateTime cROutTime;
        private string operatorOGUID;
        private string operatorEGUID;
        /// <summary>
        /// 记录编号
        /// </summary>
        public string GUID
        {
            get { return gUID; }
            set { gUID = value; }
        }

        /// <summary>
        /// 客户GUID
        /// </summary>
        public string ClientGUID
        {
            get { return clientGUID; }
            set { clientGUID = value; }
        }

        /// <summary>
        /// 房间编号
        /// </summary>
        public string RoomID
        {
            get { return roomID; }
            set { roomID = value; }
        }

        /// <summary>
        /// 入住时间
        /// </summary>
        public DateTime CRinTime
        {
            get { return cRinTime; }
            set { cRinTime = value; }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime CROutTime
        {
            get { return cROutTime; }
            set { cROutTime = value; }
        }

        /// <summary>
        /// 开房操作员ID
        /// </summary>
        public string OperatorOGUID
        {
            get { return operatorOGUID; }
            set { operatorOGUID = value; }
        }

        /// <summary>
        /// 退房操作员ID
        /// </summary>
        public string OperatorEGUID
        {
            get { return operatorEGUID; }
            set { operatorEGUID = value; }
        }
    }
    /// <summary>
    /// 账务记录表
    /// </summary>
    public class T_AccountOld
    {
        private string gUID;
        private string clientGUID;
        private DateTime operateTime;
        private int operateMoney;
        private int operatorTypeID;
        private string operatorGUID;
        /// <summary>
        /// 记录编号
        /// </summary>
        public string GUID
        {
            get { return gUID; }
            set { gUID = value; }
        }

        /// <summary>
        /// 客户GUID
        /// </summary>
        public string ClientGUID
        {
            get { return clientGUID; }
            set { clientGUID = value; }
        }

        /// <summary>
        /// 入住时间
        /// </summary>
        public DateTime OperateTime
        {
            get { return operateTime; }
            set { operateTime = value; }
        }

        /// <summary>
        /// 操作金额(元)
        /// </summary>
        public int OperateMoney
        {
            get { return operateMoney; }
            set { operateMoney = value; }
        }

        /// <summary>
        /// 操作类型编号
        /// </summary>
        public int OperatorTypeID
        {
            get { return operatorTypeID; }
            set { operatorTypeID = value; }
        }

        /// <summary>
        /// 操作员ID
        /// </summary>
        public string OperatorGUID
        {
            get { return operatorGUID; }
            set { operatorGUID = value; }
        }
    }


    //库存实体类
    /// <summary>
    /// 供应商类型表
    /// </summary>
    public class T_SupplierType
    {
        int iD;
        string name;
        string remark;
        bool isValid;
        /// <summary>
        /// 供应商编号
        /// </summary>
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        /// <summary>
        /// 文本化的是否有效信息
        /// </summary>
        public string IsValidText
        {
            get { return IsValid ? "有效" : "无效"; }
        }
    }
    /// <summary>
    /// 供应商信息表
    /// </summary>
    public class T_SupplierInfo
    {
        int supplierID;
        string supplierName;
        int supplierCouID;
        string supplierAdress;
        string supplierTel;
        int supplierTypeID;
        string remark;
        bool isValid;
        /// <summary>
        /// 编号
        /// </summary>
        public int SupplierID
        {
            get { return supplierID; }
            set { supplierID = value; }
        }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName
        {
            get { return supplierName; }
            set { supplierName = value; }
        }
        /// <summary>
        /// 国籍号
        /// </summary>
        public int SupplierCouID
        {
            get { return supplierCouID; }
            set { supplierCouID = value; }
        }
        /// <summary>
        /// 供应商地址
        /// </summary>
        public string SupplierAdress
        {
            get { return supplierAdress; }
            set { supplierAdress = value; }
        }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string SupplierTel
        {
            get { return supplierTel; }
            set { supplierTel = value; }
        }
        /// <summary>
        /// 供应类型
        /// </summary>
        public int SupplierTypeID
        {
            get { return supplierTypeID; }
            set { supplierTypeID = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        /// <summary>
        /// 表是否有效
        /// </summary>
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        /// <summary>
        /// 文本化的是否有效信息
        /// </summary>
        public string IsValidText
        {
            get { return IsValid ? "有效" : "无效"; }
        }
    }
    /// <summary>
    /// 商品类型表
    /// </summary>
    public class T_WaresType
    { /*
       * WaresID	int primary key identity(1,1),--类型编号 主键 自增长
	WaresName varchar(30) not null,--商品名 非空
	WaresImage image ,--商品图片
	WaresRemark varchar(100),--备注及描述
	IsValid bit default(1) --是否有效
       */
        int waresID;
        string waresName;
        BitmapImage waresImage;
        string waresRemark;
        bool isValid;
        /// <summary>
        /// 商品编号
        /// </summary>
        public int WaresID
        {
            get { return waresID; }
            set { waresID = value; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string WaresName
        {
            get { return waresName; }
            set { waresName = value; }
        }
        /// <summary>
        /// 商品图片
        /// </summary>
        public BitmapImage WaresImage
        {
            get { return waresImage; }
            set { waresImage = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string WaresRemark
        {
            get { return waresRemark; }
            set { waresRemark = value; }
        }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        /// <summary>
        /// 文本化的是否有效信息
        /// </summary>
        public string IsValidText
        {
            get { return IsValid ? "有效" : "无效"; }
        }
    }

    /// <summary>
    /// 计量单位表
    /// </summary>
    public class T_UnitType
    { 
        /*UnitID int primary key identity(1,1),--单位编号 主键 自增长
	UnitName varchar(15) not null,--单位名 非空
	IsValid bit default(1) --是否有效*/
        int unitID;
        string unitName;
        bool isValid;
        /// <summary>
        /// 单位编号
        /// </summary>
        public int UnitID
        {
            get { return unitID; }
            set { unitID = value; }
        }
        /// <summary>
        /// 单位名
        /// </summary>
        public string UnitName
        {
            get { return unitName; }
            set { unitName = value; }
        }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        /// <summary>
        /// 文本化的是否有效信息
        /// </summary>
        public string IsValidText
        {
            get { return IsValid ? "有效" : "无效"; }
        }
    }

    /// <summary>
    /// 库存信息表
    /// </summary>
    public class T_StockInfo 
    {
        /*
         * GUID varchar(30) primary key default(newid()),--编号 主键 随机编号
    WaresID int not null,--商品类型编号 非空
    Inventory int check(Inventory > 1) not null ,--库存数量
    LowCuount int check(LowCuount>-1) not null,--缺货数量
    StockUnit int not null,--库存单位
    IsValid bit default(1) --是否有效
         */
        string gUID;
        int waresID;
        int inventory;
        int lowCuount;
        int stockUnit;
        bool isValid;
        /// <summary>
        /// 编号
        /// </summary>
        public string GUID
        {
            get { return gUID; }
            set { gUID = value; }
        }
        /// <summary>
        /// 商品类型编号
        /// </summary>
        public int WaresID
        {
            get { return waresID; }
            set { waresID = value; }
        }
        /// <summary>
        /// 库存数量
        /// </summary>
        public int Inventory
        {
            get { return inventory; }
            set { inventory = value; }
        }
        /// <summary>
        /// 缺货数量
        /// </summary>
        public int LowCuount
        {
            get { return lowCuount; }
            set { lowCuount = value; }
        }
        /// <summary>
        /// 库存单位
        /// </summary>
        public int StockUnit
        {
            get { return stockUnit; }
            set { stockUnit = value; }
        }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        /// <summary>
        /// 文本化的是否有效信息
        /// </summary>
        public string IsValidText
        {
            get { return IsValid ? "有效" : "无效"; }
        }
    }
    /// <summary>
    /// 出入库信息表
    /// </summary>
    public class T_OutInInfo 
    {
        string iOGUID;
        int iOWaresID;
        int supplierID;
        int iOCount;
        int iOUnit;
        string operatorGUID;
        DateTime operatorTime;
        string iORemark;
        /// <summary>
        /// 类型编号
        /// </summary>
        public string IOGUID
        {
            get { return iOGUID; }
            set { iOGUID = value; }
        }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int IOWaresID
        {
            get { return iOWaresID; }
            set { iOWaresID = value; }
        }
        /// <summary>
        /// 供应商ID(入库时)
        /// </summary>
        public int SupplierID
        {
            get { return supplierID; }
            set { supplierID = value; }
        }
        /// <summary>
        ///  数量
        /// </summary>
        public int IOCount
        {
            get { return iOCount; }
            set { iOCount = value; }
        }
        /// <summary>
        ///   单位
        /// </summary>
        public int IOUnit
        {
            get { return iOUnit; }
            set { iOUnit = value; }
        }
        /// <summary>
        ///  操作员GUID
        /// </summary>
        public string OperatorGUID
        {
            get { return operatorGUID; }
            set { operatorGUID = value; }
        }
        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime OperatorTime
        {
            get { return operatorTime; }
            set { operatorTime = value; }
        }
        /// <summary>
        ///  备注及描述
        /// </summary>
        public string IORemark
        {
            get { return iORemark; }
            set { iORemark = value; }
        }
    }



    /// <summary>
    /// 授权类型表
    /// </summary>
    public class T_AccreditType
    { 
        /*ALevelID int primary key identity(1,1),--等级编号 主键 自增长
	ALevelName varchar(30) not null,--等级名称 非空
	ALevelRemark varchar(200),--备注及描述
	IsValid bit default(1) --是否有效*/
        int aLevelID;
        string alevelName;
        string aLevelRemark;
        bool isValid;
        public int ALevelID
        {
            get { return aLevelID; }
            set { aLevelID = value; }
        }
        
        public string ALevelName
        {
            get { return alevelName; }
            set { alevelName = value; }
        }
        
        public string ALevelRemark
        {
            get { return aLevelRemark; }
            set { aLevelRemark = value; }
        }

        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        /// <summary>
        /// 文本化的是否有效信息
        /// </summary>
        public string IsValidText
        {
            get { return IsValid ? "有效" : "无效"; }
        }
    }

    /// <summary>
    /// 授权列表
    /// </summary>
    public class T_AccreditList
    {
        /*
         * AccreditGUID varchar(30) primary key default(newid()),--授权码 主键 自增长
	AStartDate datetime not null, --生效时间
	AEndDate datetime not null, --非空 失效时间
	ALevel int --授权等级
         */
        string accreditGUID;
        DateTime aStartDate;
        DateTime aEndDate;
        int aLevel;
        /// <summary>
        /// 授权码
        /// </summary>
        public string AccreditGUID
        {
            get { return accreditGUID; }
            set { accreditGUID = value; }
        }
        /// <summary>
        /// 生效时间
        /// </summary>
        public DateTime AStartDate
        {
            get { return aStartDate; }
            set { aStartDate = value; }
        }
        /// <summary>
        /// 失效时间
        /// </summary>
        public DateTime AEndDate
        {
            get { return aEndDate; }
            set { aEndDate = value; }
        }
        /// <summary>
        /// 授权等级
        /// </summary>
        public int ALevel
        {
            get { return aLevel; }
            set { aLevel = value; }
        }
    }


    /// <summary>
    /// 职务类型表
    /// </summary>
    public class T_StaffType:T_AccreditType
    {
        int sTypeID;
        string sTypeName;
        int sTypeALevelID;
        bool isValid;
        /// <summary>
        /// 类型编号
        /// </summary>
        public int STypeID
        {
            get { return sTypeID; }
            set { sTypeID = value; }
        }
        /// <summary>
        /// 职务名称
        /// </summary>
        public string STypeName
        {
            get { return sTypeName; }
            set { sTypeName = value; }
        }
        /// <summary>
        /// 权限等级编号
        /// </summary>
        public int STypeALevelID
        {
            get { return sTypeALevelID; }
            set { sTypeALevelID = value; }
        }
        /// <summary>
        /// 是否有效
        /// </summary>
        public new bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        /// <summary>
        /// 文本化的是否有效信息
        /// </summary>
        public new string IsValidText
        {
            get { return IsValid ? "有效" : "无效"; }
        }
    }

    /// <summary>
    /// 员工基本信息
    /// </summary>
    public class View_UserInfo : INotifyPropertyChanged
    {
        string staffID;
        /// <summary>
        /// 员工工号
        /// </summary>
        public string StaffID
        {
            get { return staffID; }
            set { staffID = value; }
        }

        string staffPassMD5;
        /// <summary>
        /// 员工密码
        /// </summary>
        public string StaffPassMD5
        {
            get { return staffPassMD5; }
            set { staffPassMD5 = value; }
        }

        /// <summary>
        /// 员工工号显示文本
        /// </summary>
        public string StaffIDText 
        {
            get { return "工号：" + staffID; }
        }

        string staffName;
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string StaffName
        {
            get { return staffName; }
            set { staffName = value; }
        }

        /// <summary>
        /// 员工信息显示文本
        /// </summary>
        public string StaffNameText 
        {
            get { return "姓名：" + staffName; }
        }

        /// <summary>
        /// 用户头像
        /// </summary>
        public BitmapImage StaffImage { get; set; }

        public byte[] ImageBytes { get; set; }

        int sTypeID;
        /// <summary>
        /// 员工职务类型
        /// </summary>
        public int STypeID
        {
            get { return sTypeID; }
            set { sTypeID = value; }
        }

        string sTypeName;
        /// <summary>
        /// 员工职务类型名称
        /// </summary>
        public string STypeName
        {
            get { return sTypeName; }
            set { sTypeName = value; }
        }

        /// <summary>
        /// 职务显示文本
        /// </summary>
        public string STypeNameText 
        {
            get { return "职务："+sTypeName; }
        }

        int aLevelID;
        /// <summary>
        /// 权限等级编号
        /// </summary>
        public int ALevelID
        {
            get { return aLevelID; }
            set { aLevelID = value; }
        }


        string aLevelName;
        /// <summary>
        /// 权限等级名称
        /// </summary>
        public string ALevelName
        {
            get { return aLevelName; }
            set { aLevelName = value; }
        }

        /// <summary>
        /// 权限等级名称文本
        /// </summary>
        public string ALevelNameText 
        {
            get { return "权限：" + aLevelName; }
        }

        public void Changed(string name)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(name)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    /// <summary>
    /// 员工个人信息
    /// </summary>
    public class T_StaffInfo
    {
        string staffID;
        string staffName;
        bool staffSex;
        int staffCouID;
        string staffAdress;
        string staffIdCard;
        DateTime staffInDate;
        BitmapImage staffImage;
        public byte[] ImageBytes;
        string staffTel;
        public string StaffTel
        {
            get { return staffTel; }
            set { staffTel = value; }
        }
        bool isValid;
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string StaffID
        {
            get { return staffID; }
            set { staffID = value; }
        }
        /// <summary>
        ///  员工姓名
        /// </summary>
        public string StaffName
        {
            get { return staffName; }
            set { staffName = value; }
        }
        /// <summary>
        ///  性别
        /// </summary>
        public bool StaffSex
        {
            get { return staffSex; }
            set { staffSex = value; }
        }
        public string StaffSexText
        {
            get { return staffSex? "男" : "女"; }
        }
        /// <summary>
        ///  国籍号
        /// </summary>
        public int StaffCouID
        {
            get { return staffCouID; }
            set { staffCouID = value; }
        }
        /// <summary>
        ///  地址编号
        /// </summary>
        public string StaffAdress
        {
            get { return staffAdress; }
            set { staffAdress = value; }
        }
        /// <summary>
        ///  身份证号
        /// </summary>
        public string StaffIdCard
        {
            get { return staffIdCard; }
            set { staffIdCard = value; }
        }
        /// <summary>
        ///  入职时间
        /// </summary>
        public DateTime StaffInDate
        {
            get { return staffInDate; }
            set { staffInDate = value; }
        }
        /// <summary>
        ///  员工头像
        /// </summary>
        public BitmapImage StaffImage
        {
            get { return staffImage; }
            set { staffImage = value; }
        }
        /// <summary>
        ///  是否在职
        /// </summary>
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        /// <summary>
        /// 文本化的是否有效信息
        /// </summary>
        public string IsValidText
        {
            get { return IsValid ? "有效" : "无效"; }
        }
    }


    /// <summary>
    /// 在职员工列表
    /// </summary>
    public class T_StaffList
    {
        string staffID;
        string staffPwdMD5;
        string staffGuid;
        string staffAccredit;
        int sTypeID;
        /// <summary>
        /// 唯一标示
        /// </summary>
        public string StaffID
        {
            get { return staffID; }
            set { staffID = value; }
        }
        /// <summary>
        /// 员工密码
        /// </summary>
        public string StaffPwdMD5
        {
            get { return staffPwdMD5; }
            set { staffPwdMD5 = value; }
        }
        /// <summary>
        ///  唯一标识
        /// </summary>
        public string StaffGuid
        {
            get { return staffGuid; }
            set { staffGuid = value; }
        }
        /// <summary>
        ///  授权代码
        /// </summary>
        public string StaffAccredit
        {
            get { return staffAccredit; }
            set { staffAccredit = value; }
        }
        /// <summary>
        ///  职务编号
        /// </summary>
        public int STypeID
        {
            get { return sTypeID; }
            set { sTypeID = value; }
        }

    }
}
