using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;
using DLL_DAL;
using System.Data;
using System.Data.SqlClient;

namespace DLL_BLL
{
    public class RoomListBLL
    {
        #region 基本信息读取
        /// <summary>
        /// 读取所有的数据 List
        /// </summary>
        /// <returns></returns>
        public static List<View_RoomInfo> DataLoad() 
        {
            return  DLL_DAL.RoomListDAL.DataLoad();
        }

        /// <summary>
        /// 读取所有数据 DataSet
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTableAll()
        {
            return RoomListDAL.GetTableAll().Tables[0];
        }

        /// <summary>
        /// 读取所有数据 bool参数为true表示查找有效数据，false查找无效数据
        /// </summary>
        /// <param name="Nov"></param>
        /// <returns></returns>
        public static DataTable GetTableAll(bool Nov)
        {
            return RoomListDAL.GetTableAll(Nov).Tables[0];
        }

        /// <summary>
        /// 根据房间ID获取一个房间的信息
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        public static T_RoomList GetRoom( string roomid)
        {
            return DLL_DAL.RoomListDAL.GetRoom(roomid);
        }

        /// <summary>
        /// 启用或禁用指定的房间记录
        /// </summary>
        /// <param name="isEnable"></param>
        /// <param name="roomid"></param>
        /// <returns></returns>
        public static bool EnableItem(bool isEnable, string roomid) 
        {
            if(DLL_DAL.RoomListDAL.EnableItem(isEnable,roomid)>0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Insert(T_RoomList model)
        {
            if (RoomListDAL.Insert(model) > 0) return true; return false;
        }

        /// <summary>
        /// 修改一条信息
        /// </summary>
        /// <param name="RoomID"></param>
        /// <param name="RoomType"></param>
        /// <param name="RoomState"></param>
        /// <param name="RoomRemark"></param>
        /// <returns></returns>
        public static bool Update(T_RoomList TR)
        {
            if (RoomListDAL.Update(TR) > 0) return true;
            return false;
        }

        /// <summary>
        /// 根据房号修改房间状态
        /// </summary>
        /// <param name="RoomID"></param>
        /// <param name="RoomType"></param>
        /// <param name="RoomState"></param>
        /// <param name="RoomRemark"></param>
        /// <returns></returns>
        public static bool UpdateSetState(int stateid,string roomid)
        {
            if (RoomListDAL.UpdateSetState(stateid,roomid) > 0) return true;
            return false;
        }
        #endregion

        #region 搜索

        /// <summary>
        /// 根据房间类型获取数据
        /// </summary>
        /// <returns></returns>
        public static List<View_RoomInfo> GetRoom_ForTID(int id)
        {
            return DLL_DAL.RoomListDAL.GetRoom_ForTID(id);
        }

        /// <summary>
        /// 根据房间状态获取数据
        /// </summary>
        /// <returns></returns>
        public static List<View_RoomInfo> GetRoom_ForTName(string name)
        {
            return DLL_DAL.RoomListDAL.GetRoom_ForTName(name);
        }


        /// <summary>
        /// 根据房间状态状态获取数据
        /// </summary>
        /// <returns></returns>
        public static List<View_RoomInfo> GetRoom_ForSID(int id)
        {
            return DLL_DAL.RoomListDAL.GetRoom_ForSID(id);
        }

        /// <summary>
        /// 根据房间状态类型获取数据
        /// </summary>
        /// <returns></returns>
        public static List<View_RoomInfo> GetRoom_ForSName(string name)
        {
            return DLL_DAL.RoomListDAL.GetRoom_ForSName(name);
        }


        /// <summary>
        /// 根据房间状态、类型多条件获取数据
        /// </summary>
        /// <returns></returns>
        public static List<View_RoomInfo> GetRoom_ForID(int type,int state)
        {
            return DLL_DAL.RoomListDAL.GetRoom_ForID(type,state);
        }

        /// <summary>
        /// 根据房间状态、类型多条件获取数据
        /// </summary>
        /// <returns></returns>
        public static List<View_RoomInfo> GetRoom_ForName(string type,string state)
        {
            return DLL_DAL.RoomListDAL.GetRoom_ForName(type,state);
        }

        /// <summary>
        /// 根据房间ID模糊查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<View_RoomInfo> GetRoom_ForRoomID(string id)
        {
            return DLL_DAL.RoomListDAL.GetRoom_ForRoomID(id);
        }

        /// <summary>
        /// 根据价格查询符合条件的数据
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public static List<View_RoomInfo> GetRoom_ForPrice(int price)
        {
            return DLL_DAL.RoomListDAL.GetRoom_ForPrice(price);
        }

        /// <summary>
        /// 根据时长小时数查询符合条件的数据
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public static List<View_RoomInfo> GetRoom_ForTime(int timelength)
        {
            return DLL_DAL.RoomListDAL.GetRoom_ForTime(timelength);
        }
        #endregion
    }
}
