using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;

namespace DLL_DAL
{
    public class RoomStateTypeDAL
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static List<T_RoomStateType> DataLoad(bool e)
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                SqlParameter[] SP = new SqlParameter[] { new SqlParameter("@IV", e) };
                dr = DB.ExecuteReader("select * from T_RoomStateType where IsValid=@IV",SP);
                List<T_RoomStateType> TC = new List<T_RoomStateType>();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        T_RoomStateType tv = new T_RoomStateType();
                        tv.StateID = (int)dr["StateID"];
                        tv.StateName = (string)dr["StateName"];
                        tv.StateColor = (string)dr["StateColor"];
                        tv.StateRemark = (string)dr["StateRemark"];
                        tv.IsValid = (bool)dr["IsValid"];
                        TC.Add(tv);
                    }
                }
                return TC;
            }
            finally
            {
                DB.ConnClose();
                if (dr != null) { dr.Close(); dr.Dispose(); }
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="t"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Update(T_RoomStateType TV, int id)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sp = new SqlParameter[]
            { 
                new SqlParameter("@StateName", TV.StateName), 
                new SqlParameter("@StateRemark", TV.StateRemark),
                new SqlParameter("StateColor",TV.StateColor),
                new SqlParameter("@ID", id) };
            int Count = DB.ExecuteNonQuery("update T_RoomStateType set StateName=@StateName,StateColor=@StateColor,StateRemark=@StateRemark where StateID=@ID", sp);
            return Count;
        }

        /// <summary>
        /// 启用或禁用项
        /// </summary>
        /// <param name="E"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static int EnableItem(bool E, int ID)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] SP = new SqlParameter[] { new SqlParameter("@IV", E), new SqlParameter("@ID", ID) };
            int Count = DB.ExecuteNonQuery("update T_RoomStateType set IsValid=@IV where StateID=@ID", SP);
            return Count;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int Insert(T_RoomStateType TV)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sp = new SqlParameter[] 
            { 
                new SqlParameter("@StateName", TV.StateName), 
                new SqlParameter("StateColor",TV.StateColor),
                new SqlParameter("@StateRemark", TV.StateRemark),
            };
            int Count = DB.ExecuteNonQuery("insert into T_RoomStateType(StateName,StateColor,StateRemark) values(@StateName,@StateColor,@StateRemark)", sp);
            return Count;
        }
    }
}
