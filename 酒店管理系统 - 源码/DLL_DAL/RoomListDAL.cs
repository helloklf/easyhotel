using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;

namespace DLL_DAL
{
    public class RoomListDAL
    {
        /// <summary>
        /// 根据房间编号获得一个房间信息
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        public static T_RoomList GetRoom(string roomid)
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                SqlParameter[] sqlp = new SqlParameter[] { new SqlParameter("@roomid", roomid) };
                dr = DB.ExecuteReader("select * from T_RoomList where RoomID=@roomid", sqlp);
                T_RoomList tl = new T_RoomList();
                while (dr.Read())
                {
                    tl.RoomID = (string)dr["RoomID"];
                    tl.RoomType = (int)dr["RoomType"];
                    tl.RoomState = (int)dr["RoomState"];
                    tl.RoomRemark = (string)dr["RoomRemark"];
                }
                return tl;
            }
            finally
            {
                DB.ConnClose();
                if (dr != null) { dr.Close(); dr.Dispose(); }
            }

        }

        /// <summary>
        /// 启用或禁用指定的房间记录
        /// </summary>
        /// <param name="isEnable"></param>
        /// <param name="roomid"></param>
        /// <returns></returns>
        public static int EnableItem(bool isEnable, string roomid)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sqlp = new SqlParameter[] { new SqlParameter("@IsV",isEnable),new SqlParameter("@RoomID",roomid) };
            return DB.ExecuteNonQuery(" update T_RoomList set IsValid=@IsV where RoomID=@RoomID", sqlp);
        }

        /// <summary>
        /// 全部房间列表
        /// </summary>
        /// <returns></returns>
        public static DataSet GetTableAll()
        {
            Task_DBHelper DB = new Task_DBHelper();
            string strSql = " select * from View_RoomInfoAll";
            return DB.GetTable(strSql);
        }

        /// <summary>
        /// 全部房间列表 list
        /// </summary>
        /// <returns></returns>
        public static List<View_RoomInfo> DataLoad()
        {
            Task_DBHelper DB = new Task_DBHelper();
            try
            {
                string strSql = " select * from View_RoomInfoAll";
                List<View_RoomInfo> LV = GetRoom_ForType(strSql);
                return LV;
            }
            finally { DB.ConnClose(); }
        }

        /// <summary>
        /// 全部房间列表 dataset
        /// </summary>
        /// <returns></returns>
        public static DataSet GetTableAll(bool isv)
        {
            Task_DBHelper DB = new Task_DBHelper();
            string strSql;
            if (!isv) { strSql = "select * from View_RoomInfo"; }
            else { strSql = "select * from View_RoomInfoNo"; }
            return DB.GetTable(strSql);
        }
        
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Insert(T_RoomList model)
        {
            Task_DBHelper DB = new Task_DBHelper();
            string sql = "insert into T_RoomList (RoomID,RoomType,RoomState,RoomRemark) values(@RoomID,@RoomType,@RoomState,@RoomRemark)";
            SqlParameter[] SqlName =
            {
                new SqlParameter("@RoomID",model.RoomID),
                new SqlParameter("@RoomType",model.RoomType),
                new SqlParameter("@RoomState",model.RoomState),
                new SqlParameter("@RoomRemark",model.RoomRemark),
            };
            return DB.ExecuteNonQuery(sql, SqlName);
        }

        /// <summary>
        /// 修改一条信息
        /// </summary>
        /// <param name="RoomID"></param>
        /// <param name="RoomType"></param>
        /// <param name="RoomState"></param>
        /// <param name="RoomRemark"></param>
        /// <returns></returns>
        public static int Update(T_RoomList TR)
        {
            Task_DBHelper DB = new Task_DBHelper();
            string sql = "update T_RoomList set RoomState=@RoomState,RoomRemark=@RoomRemark,RoomType=@RoomType where RoomID=@RoomID";
            SqlParameter[] SqlName = 
            { 
                new SqlParameter("@RoomID",TR.RoomID),
                new SqlParameter("@RoomState",TR.RoomState),
                new SqlParameter("@RoomType",TR.RoomType),
                new SqlParameter("@RoomRemark",TR.RoomRemark),
                new SqlParameter("@IsValid",TR.IsValid),
            };
            return DB.ExecuteNonQuery(sql, SqlName);
        }
        

        /// <summary>
        /// 根据房号修改房间状态
        /// </summary>
        /// <param name="RoomID"></param>
        /// <param name="RoomType"></param>
        /// <param name="RoomState"></param>
        /// <param name="RoomRemark"></param>
        /// <returns></returns>
        public static int UpdateSetState(int stateid,string roomid)
        {
            Task_DBHelper DB = new Task_DBHelper();
            string sql = "update T_RoomList set RoomState=@RoomState where RoomID=@RoomID";
            SqlParameter[] SqlName = 
            { 
                new SqlParameter("@RoomID",roomid),
                new SqlParameter("@RoomState",stateid),
            };
            return DB.ExecuteNonQuery(sql, SqlName);
        }

        #region 搜索过滤


        #region 只根据房间类型筛选
        /// <summary>
        /// 根据房间类型ID获取数据
        /// </summary>
        /// <returns></returns>
        public static List<View_RoomInfo> GetRoom_ForTID(int typeid)
        {
            string strSql = " select * from View_RoomInfoAll where 类型编号=@RoomType";
            SqlParameter[] sqlp = new SqlParameter[] { new SqlParameter("@RoomType", typeid) };
            List<View_RoomInfo> LV = GetRoom_ForType(strSql, sqlp);
            return LV;
        }


        /// <summary>
        /// 根据房间类型Name获取数据
        /// </summary>
        /// <returns></returns>
        public static List<View_RoomInfo> GetRoom_ForTName(string typename)
        {
            string strSql = "select * from View_RoomInfoAll where 类型名 like '%" + typename + "%'";
            List<View_RoomInfo> LV = GetRoom_ForType(strSql);
            return LV;
        }
        #endregion

        #region 只根据房间状态筛选
        /// <summary>
        /// 根据房间状态类型ID获取数据
        /// </summary>
        /// <returns></returns>
        public static List<View_RoomInfo> GetRoom_ForSID(int typeid)
        {
            string strSql = " select * from View_RoomInfoAll where 状态编号=@RoomState";
            SqlParameter[] sqlp = new SqlParameter[] { new SqlParameter("@RoomState", typeid) };
            List<View_RoomInfo> LV = GetRoom_ForType(strSql, sqlp);
            return LV;
        }


        /// <summary>
        /// 根据房间状态类型Name获取数据
        /// </summary>
        /// <returns></returns>
        public static List<View_RoomInfo> GetRoom_ForSName(string typename)
        {
            string strSql = "select * from View_RoomInfoAll where 状态名 like '%" + typename + "%'";
            List<View_RoomInfo> LV = GetRoom_ForType(strSql);
            return LV;
        }
        #endregion

        #region 按状态、类型两个条件筛选
        /// <summary>
        /// 根据房间状态、类型ID多条件获取数据
        /// </summary>
        /// <returns></returns>
        public static List<View_RoomInfo> GetRoom_ForID(int typeid,int stateid)
        {
            string strSql = "select * from View_RoomInfoAll where 类型编号=@RoomType and 状态编号=@RoomState";
            SqlParameter[] sqlp = new SqlParameter[] { new SqlParameter("@RoomType", typeid), new SqlParameter("@RoomState", stateid) };
            List<View_RoomInfo> LV = GetRoom_ForType(strSql, sqlp);
            return LV;
        }


        /// <summary>
        /// 根据房间状态、类型Name多条件获取数据
        /// </summary>
        /// <returns></returns>
        public static List<View_RoomInfo> GetRoom_ForName(string typename,string statename)
        {
            string strSql = "select * from View_RoomInfoAll where 类型名 like '%" + typename + "%' and 状态名 like '"+statename+"'";
            List<View_RoomInfo> LV = GetRoom_ForType(strSql);
            return LV;
        }
        #endregion

        #region 根据房间ID查询
        /// <summary>
        /// 根据房间ID查询数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<View_RoomInfo> GetRoom_ForRoomID(string id)
        {
            string sql = "select * from View_RoomInfoAll where 房间编号 like '%"+id+"%'";
            return GetRoom_ForType(sql);
        }
        #endregion
        

        /// <summary>
        /// 根据价格查询符合条件的数据
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public static List<View_RoomInfo> GetRoom_ForPrice(int price)
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                string sql = "Proc_PriceSearch";
                SqlParameter[] sqlp = new SqlParameter[] { new SqlParameter("@maxprice", price) };
                dr = DB.ExecuteReaderProc(sql, sqlp);
                return Read(dr);
            }
            finally 
            {
                DB.ConnClose();
                if (dr != null) { dr.Close(); dr.Dispose(); }
            }
        }

        /// <summary>
        /// 根据时长小时数查询符合条件的数据
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public static List<View_RoomInfo> GetRoom_ForTime(int timelength)
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                string sql = "select * from View_RoomInfo where 结算频率=@timelength";
                SqlParameter[] sqlp = new SqlParameter[] { new SqlParameter("@timelength", timelength) };
                dr = DB.ExecuteReader(sql, sqlp);
                return Read(dr);
            }
            finally 
            {
                DB.ConnClose();
                if (dr != null) { dr.Close(); dr.Dispose(); }
            }
        }

        #region 根据查询语句、参数读取数据称List
        public static List<View_RoomInfo> GetRoom_ForType(string sql,params SqlParameter[] sqlp)
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                dr = DB.ExecuteReader(sql, sqlp);
                return Read(dr);
            }
            finally
            {
                DB.ConnClose();
                if (dr != null) { dr.Dispose(); }
            }
        }

        public static List<View_RoomInfo> Read(SqlDataReader dr)
        {
            List<View_RoomInfo> LV = new List<View_RoomInfo>();
            while (dr.Read())
            {
                View_RoomInfo vr = new View_RoomInfo();
                vr.RoomID = (string)dr["房间编号"];
                vr.TypeID = (int)dr["类型编号"];
                vr.TypeName = (string)dr["类型名"];
                vr.TypePrice = (int)dr["单价"];
                vr.TypeRequency = Convert.ToInt32((long)dr["结算频率"]);
                vr.StateID = (int)dr["状态编号"];
                vr.RoomStateName = (string)dr["状态名"];
                vr.StateColor = (string)dr["颜色"];
                vr.RoomRemark = (string)dr["房间备注"];
                vr.IsValid = (bool)dr["有效状态"];
                LV.Add(vr);
            }
            return LV;
        }
        #endregion


        #endregion
    }
}
