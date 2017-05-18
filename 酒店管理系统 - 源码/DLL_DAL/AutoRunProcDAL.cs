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
    public class AutoRunProcDAL
    {
        /// <summary>
        /// 数据库自动处理客户账户余额，对未结账的账户进行结账操作
        /// </summary>
        /// <returns></returns>
        public static int Proc_AutoSettleAccounts()
        {
            Task_DBHelper DB = new Task_DBHelper();
            return DB.ExecuteNonQueryProc("Proc_AutoSettleAccounts");
        }

        /// <summary>
        /// 数据库查找所有账户欠费的课户
        /// </summary>
        /// <returns></returns>
        public static List<View_ClientRoomState> Proc_AccountRemind()
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            List<View_ClientRoomState> VL = new List<View_ClientRoomState>();
            try
            {
                dr = DB.ExecuteReaderProc("Proc_AccountRemind");
                while (dr.Read())
                {
                    View_ClientRoomState vi = new View_ClientRoomState();
                    vi.ClientName = (string)dr["ClientIName"];
                    vi.DataGUID = (string)dr["GUID"];
                    vi.ClientAccount = (double)dr["ClientAccount"];
                    vi.LastDeduct = (DateTime)dr["LastDeduct"];
                    vi.RoomID = (string)dr["RoomID"];
                    VL.Add(vi);
                }
                return VL;
            }
            finally 
            {
                DB.ConnClose();
                if (dr != null) { dr.Close(); }
            }
        }



        /// <summary>
        /// 自动清理失效预订，返回受影响行数
        /// </summary>
        /// <returns></returns>
        public static int Proc_AutoDeleteBook()
        {
            Task_DBHelper DB = new Task_DBHelper();
            return DB.ExecuteNonQueryProc("Proc_AutoDeleteBook");
        }

        /// <summary>
        /// 查询过期预订信息
        /// </summary>
        /// <returns>//select Count(*) from T_BookRoom  where dateadd(HOUR,(BookValidTime*24),GETDATE())>GETDATE() </returns>
        public static List<T_BookRoom> PastDueBook()
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            List<T_BookRoom> TB = new List<T_BookRoom>();
            dr = DB.ExecuteReader("select Count(*) from T_BookRoom  where dateadd(HOUR,(BookValidTime*24),GETDATE())>GETDATE()");
            while (dr.Read())
            {
                T_BookRoom BR = new T_BookRoom();
                BR.ClientName = (string)dr["ClientName"];
                BR.RoomID = (string)dr["RoomID"];
                BR.BookTime = (DateTime)dr["BookTime"];
                BR.BookValidTime = (int)dr["BookValidTime"];
                TB.Add(BR);
            }
            return TB;
        }
    }
}
