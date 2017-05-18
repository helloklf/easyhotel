using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;

namespace DLL_BLL
{
    /// <summary>
    /// 提供房间信息读取、客户入住、退换房、房态修改、缴费等功能
    /// </summary>
    public class View_ClientRoomState_BLL
    {
        /// <summary>
        /// 读取房间信息
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        public static View_ClientRoomState LoadData(string roomid) 
        {
            return DLL_DAL.View_ClientRoomState_DAL.LoadData(roomid);
        }


        /// <summary>
        /// 账户缴费
        /// </summary>
        /// <param name="roomid"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public static bool SetClientAccount(string GUID, double money)
        {
            if (DLL_DAL.View_ClientRoomState_DAL.SetClientAccount(GUID, money) > 0) return true;
            return false;
        }

        /// <summary>
        /// 客户退房操作
        /// </summary>
        /// <param name="roomid"></param>
        /// <param name="Oid"></param>
        /// <returns></returns>
        public static bool ClientExitRoom(string roomid,string Oid)
        {
            if (DLL_DAL.View_ClientRoomState_DAL.ClientExitRoom(roomid, Oid) > 0) return true;
            return false;
        }

        /// <summary>
        /// 客户切换房间
        /// </summary>
        /// <param name="OID"></param>
        /// <param name="oldRoomID"></param>
        /// <param name="newRoomID"></param>
        /// <returns></returns>
        public static bool Proc_RoomChange(string OID,string oldRoomID,string newRoomID) 
        {
            if( DLL_DAL.View_ClientRoomState_DAL.Proc_RoomChange(OID,oldRoomID,newRoomID)>0) return true;
            return false;
        }

        /// <summary>
        /// 房间预订信息确认
        /// </summary>
        /// <param name="clientname"></param>
        /// <param name="roomid"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static bool Proc_BookRoom(string clientname, string roomid,int days)
        {
            return (DLL_DAL.View_ClientRoomState_DAL.Proc_BookRoom(clientname,roomid,days)>0?true:false);
        }


        /// <summary>
        /// 获取预订客户的姓名
        /// </summary>
        /// <param name="roomID"></param>
        /// <returns></returns>
        public static string BookClientName(string roomID)
        {
            return DLL_DAL.View_ClientRoomState_DAL.BookClientName(roomID);
        }

        /// <summary>
        /// 根据房间类型查询数量
        /// </summary>
        /// <returns></returns>
        public static List<Other_HotelRoomState> View_RoomTypeCount()
        {
            return DLL_DAL.View_ClientRoomState_DAL.View_RoomTypeCount();
        }


        /// <summary>
        /// 查询数量最多的房间类型
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static Other_HotelRoomState RoomMax_MinCount(bool max)
        {
            return DLL_DAL.View_ClientRoomState_DAL.RoomMax_MinCount(max);
        }


        /// <summary>
        /// 查询各种状态的房间数量
        /// </summary>
        /// <returns></returns>
        public static List<Other_HotelRoomState> View_RoomStateCount()
        {
            return DLL_DAL.View_ClientRoomState_DAL.View_RoomStateCount();
        }


        /// <summary>
        /// 研究各类房间的总数和空房数量
        /// </summary>
        /// <returns></returns>view_HotelFund
        public static List<Other_EmptyRoom> Proc_EmptyRoomCount()
        {
            return DLL_DAL.View_ClientRoomState_DAL.Proc_EmptyRoomCount();
        }

        /// <summary>
        /// 研究各类房间的总数和空房数量
        /// </summary>
        /// <returns></returns>
        public static List<Other_HotelFund> view_HotelFund()
        {
            return DLL_DAL.View_ClientRoomState_DAL.view_HotelFund();
        }

    }

}
