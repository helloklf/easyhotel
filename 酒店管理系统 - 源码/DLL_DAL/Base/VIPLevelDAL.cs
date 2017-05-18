using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;

namespace DLL_DAL
{
    public class VIPLevelDAL
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static List<T_VIPLevel> DataLoad(bool E)
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                SqlParameter[] SP = new SqlParameter[] { new SqlParameter("@IV", E) };
                dr = DB.ExecuteReader("select * from T_VIPLevel where IsValid=@IV",SP);
                List<T_VIPLevel> TC = new List<T_VIPLevel>();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        T_VIPLevel tv = new T_VIPLevel();
                        tv.LevelID = (int)dr["LevelID"];
                        tv.LevelName = (string)dr["LevelName"];
                        tv.LevelIntegral = (int)dr["LevelIntegral"];
                        tv.VipDiscount = (int)dr["VipDiscount"];
                        tv.IsValid = (bool)dr["IsValid"];
                        TC.Add(tv);
                    }
                }
                return TC;
            }
            finally
            {
                DB.ConnClose();
                if (dr != null) { dr.Dispose(); }
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="t"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Update(T_VIPLevel TV, int id)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sp = new SqlParameter[]
            { 
                new SqlParameter("@LevelName", TV.LevelName), 
                new SqlParameter("@LevelIntegral", TV.LevelIntegral),
                new SqlParameter("@VipDiscount", TV.VipDiscount),
                new SqlParameter("@ID", id) };
            int Count = DB.ExecuteNonQuery("update T_VIPLevel set LevelName=@LevelName,LevelIntegral=@LevelIntegral,VipDiscount=@VipDiscount where LevelID=@ID", sp);
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
            int Count = DB.ExecuteNonQuery("update T_VIPLevel set IsValid=@IV where LevelID=@ID", SP);
            return Count;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int Insert(T_VIPLevel TV)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sp = new SqlParameter[] 
            { 
                new SqlParameter("@LevelName", TV.LevelName), 
                new SqlParameter("@LevelIntegral", TV.LevelIntegral),
                new SqlParameter("@VipDiscount", TV.VipDiscount) 
            };
            int Count = DB.ExecuteNonQuery("insert into T_VIPLevel(LevelName,LevelIntegral,VipDiscount) values(@LevelName,@LevelIntegral,@VipDiscount)", sp);
            return Count;
        }
    }
}
