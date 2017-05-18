using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;
using System.Data;
using System.Data.SqlClient;

namespace DLL_DAL
{
    /// <summary>
    /// 提供单个房间信息读取、客户入住、退换房、房态修改、缴费等功能
    /// </summary>
    public class View_ClientRoomState_DAL
    {
        /// <summary>
        /// 读取房间信息
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        public static View_ClientRoomState LoadData(string roomid)
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                SqlParameter[] sqlp = new SqlParameter[] { new SqlParameter("@RoomID", roomid) };
                string sql = "select * from View_ClientRoomState where RoomID=@RoomID";
                dr = DB.ExecuteReader(sql, sqlp);
                View_ClientRoomState vc = new View_ClientRoomState();
                while (dr.Read())
                {
                    vc.ClientAccount = (double)dr["ClientAccount"];
                    vc.ClientName = (string)dr["ClientName"];
                    vc.DataGUID = (string)dr["DataGUID"];
                    vc.InRoomTime = (DateTime)dr["InRoomTime"];
                    vc.LastDeduct = (DateTime)dr["LastDeduct"];
                    vc.RoomID = (string)dr["RoomID"];
                }
                return vc;
            }
            finally 
            {
                DB.ConnClose(); if (dr != null) { dr.Close();}
            }
            
        }

        /// <summary>
        /// 账户缴费
        /// </summary>
        /// <param name="roomid"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public static int SetClientAccount(string GUID,double money)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sqlp = new SqlParameter[]{new SqlParameter("@GUID",GUID),new SqlParameter("@money",money)};
            string sql = "update T_ClientRoom set ClientAccount+=@money where GUID=@GUID";
            return DB.ExecuteNonQuery(sql, sqlp);
        }


        /// <summary>
        /// 客户退房操作
        /// </summary>
        /// <param name="roomid"></param>
        /// <param name="Oid"></param>
        /// <returns></returns>
        public static int ClientExitRoom(string roomid, string Oid)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sqlp = new SqlParameter[] { new SqlParameter("@RoomID", roomid), new SqlParameter("@OperatorID", Oid) };
            return DB.ExecuteNonQueryProc("Proc_ClientOut", sqlp);
        }


        /// <summary>
        /// 客户切换房间
        /// </summary>
        /// <param name="OID"></param>
        /// <param name="oldRoomID"></param>
        /// <param name="newRoomID"></param>
        /// <returns></returns>
        public static int Proc_RoomChange(string OID, string oldRoomID, string newRoomID)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sqlp = new SqlParameter[] 
            {
                new SqlParameter("@OperatorID", OID),
                new SqlParameter("@oldRoomID", oldRoomID),
                new SqlParameter("@newRoomID", newRoomID),
            };
            return DB.ExecuteNonQueryProc("Proc_RoomChange", sqlp);
        }


        /// <summary>
        /// 房间预订信息确认
        /// </summary>
        /// <param name="clientname"></param>
        /// <param name="roomid"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static int Proc_BookRoom(string clientname, string roomid, int days)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sqlp= new SqlParameter[]
            {
                new SqlParameter("@ClientName",clientname),
                new SqlParameter("@RoomID",roomid),
                new SqlParameter("@BookValidTime",days)
            };
            return DB.ExecuteNonQueryProc("Proc_BookRoom", sqlp);
        }



        /// <summary>
        /// 获取预订客户的姓名
        /// </summary>
        /// <param name="roomID"></param>
        /// <returns></returns>
        public static string BookClientName(string roomID)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sqlp = new SqlParameter[]{ new SqlParameter("@RoomID",roomID)};
            return (string)DB.ExecuteScalar("select ClientName from T_BookRoom where RoomID=@RoomID", sqlp);
        }

        /// <summary>
        /// 根据房间类型查询数量
        /// </summary>
        /// <returns></returns>
        public static List<Other_HotelRoomState> View_RoomTypeCount()
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                dr = DB.ExecuteReader("select * from View_RoomTypeCount");
                List<Other_HotelRoomState> otl = new List<Other_HotelRoomState>();
                while (dr.Read())
                {
                    Other_HotelRoomState ot = new Other_HotelRoomState();
                    ot.Title = dr[0].ToString() + ":";
                    ot.Text = dr[1].ToString() + "间";
                    otl.Add(ot);
                }
                return otl;
            }
            finally
            {
                DB.ConnClose(); if (dr != null) { dr.Dispose(); }
            }
        }

        /// <summary>
        /// 查询数量最多的房间类型
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static Other_HotelRoomState RoomMax_MinCount(bool max)
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                if (max) { dr = DB.ExecuteReader("select Top (1) * from View_RoomTypeCount order by RCount desc"); }
                else
                {
                    dr = DB.ExecuteReader("select Top (1) * from View_RoomTypeCount order by RCount");
                }
                Other_HotelRoomState ot = new Other_HotelRoomState();
                while (dr.Read())
                {
                    ot.Title = dr[0].ToString() + "";
                    ot.Text = dr[1].ToString() + "间";
                }
                return ot;
            }
            finally
            {
                DB.ConnClose(); if (dr != null) { dr.Dispose(); }
            }
        }




        /// <summary>
        /// 查询各种状态的房间数量
        /// </summary>
        /// <returns></returns>
        public static List<Other_HotelRoomState> View_RoomStateCount()
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                dr = DB.ExecuteReader("select * from View_RoomStateCount");
                List<Other_HotelRoomState> otl = new List<Other_HotelRoomState>();
                while (dr.Read())
                {
                    Other_HotelRoomState ot = new Other_HotelRoomState();
                    ot.Title = dr[0].ToString() + ":";
                    ot.Text = dr[1].ToString() + "间";
                    otl.Add(ot);
                }
                return otl;
            }
            finally
            {
                DB.ConnClose(); if (dr != null) { dr.Dispose(); }
            }
        }

        /// <summary>
        /// 研究各类房间的总数和空房数量
        /// </summary>
        /// <returns></returns>
        public static List<Other_EmptyRoom> Proc_EmptyRoomCount() 
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                dr = DB.ExecuteReaderProc("Proc_EmptyRoomCount");
                List<Other_EmptyRoom> OC = new List<Other_EmptyRoom>();
                while (dr.Read())
                {
                    Other_EmptyRoom oc = new Other_EmptyRoom();
                    oc.Title = (string)dr["TypeName"];
                    oc.AllRoom = (int)dr["AllRoom"];
                    oc.EmptyRoom = (int)dr["EmptyRoom"];
                    OC.Add(oc);
                }
                return OC;
            }
            finally
            {
                DB.ConnClose(); if (dr != null) { dr.Dispose(); }
            }
        }

        /// <summary>
        /// 研究各类房间的总数和空房数量
        /// </summary>
        /// <returns></returns>
        public static List<Other_HotelFund> view_HotelFund() 
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                dr = DB.ExecuteReader("select * from view_HotelFund");
                List<Other_HotelFund> OC = new List<Other_HotelFund>();
                while (dr.Read())
                {
                    Other_HotelFund oc = new Other_HotelFund();
                    oc.Title = (string)dr["OperateName"];
                    oc.Text = (int)dr["Cash"];
                    OC.Add(oc);
                }
                return OC;
            }
            finally
            {
                DB.ConnClose(); if (dr != null) { dr.Dispose(); }
            }
        }
    }
}
