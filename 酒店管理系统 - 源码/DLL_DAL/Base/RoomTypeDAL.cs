using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;
using System.Data;


namespace DLL_DAL
{
    public class RoomTypeDAL
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static List<T_RoomType> DataLoad(bool E)
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                SqlParameter[] SP = new SqlParameter[] { new SqlParameter("@IV", E) };
                dr = DB.ExecuteReader("select * from T_RoomType where IsValid=@IV",SP);
                List<T_RoomType> TC = new List<T_RoomType>();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        T_RoomType tv = new T_RoomType();
                        tv.TypeID = (int)dr["TypeID"];
                        tv.TypeName = (string)dr["TypeName"];
                        tv.TypePrice = (int)dr["TypePrice"];
                        tv.TypeRequency = (int)new TimeSpan((long)dr["TypeRequency"]).TotalHours;
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
        public static int Update(T_RoomType TV, int id)
        {
            Task_DBHelper DB = new Task_DBHelper();
            TimeSpan ts = new TimeSpan(TV.TypeRequency, 0, 0);
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@TypeName", TV.TypeName), 
                new SqlParameter("@TypePrice", TV.TypePrice),
                new SqlParameter("@TypeRequency", ts.Ticks),
                new SqlParameter("@ID", id) };
            int Count = DB.ExecuteNonQuery("update T_RoomType set TypeName=@TypeName,TypePrice=@TypePrice,TypeRequency=@TypeRequency where TypeID=@ID", sp);
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
            int Count = DB.ExecuteNonQuery("update T_RoomType set IsValid=@IV where TypeID=@ID", SP);
            return Count;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int Insert(T_RoomType TV)
        {
            Task_DBHelper DB = new Task_DBHelper();
            TimeSpan ts = new TimeSpan(TV.TypeRequency,0,0);
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@TypeName", TV.TypeName), 
                new SqlParameter("@TypePrice", TV.TypePrice),
                new SqlParameter("@TypeRequency", ts.Ticks),
            };
            int Count = DB.ExecuteNonQuery("insert into T_RoomType(TypeName,TypePrice,TypeRequency) values(@TypeName,@TypePrice,@TypeRequency)", sp);
            return Count;
        }
    }
}
