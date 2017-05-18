using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;


namespace DLL_DAL
{
    /// <summary>
    /// 国家信息读写
    /// </summary>
    public class CountryInfoDAL
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static List<T_CountryInfo> DataLoad(bool b)
        {
            SqlParameter[] SP = new SqlParameter[] { new SqlParameter("@IV", b) };
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                dr = DB.ExecuteReader("select * from T_CountryInfo where IsValid=@IV",SP);
                List<T_CountryInfo> TC = new List<T_CountryInfo>();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        T_CountryInfo tc = new T_CountryInfo();
                        tc.CountryName = (string)dr[1];
                        tc.CountryID = (int)dr[0];
                        tc.IsValid = (bool)dr[2];
                        TC.Add(tc);
                    }
                }
                return TC;
            }
            finally
            {
                DB.ConnClose();
                if (dr != null) { dr.Close();}
            }
        }


        /// <summary>
        /// 用于根据国家ID查询得到国家名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetCountryName(int id)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sqlp = new SqlParameter[] { new SqlParameter("@CountryID", id) };
            string name = (string)DB.ExecuteScalar("select CountryName from T_CountryInfo where CountryID=@CountryID",sqlp);
            return name;
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="t"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Update(string t, int id)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@CountryName", t), new SqlParameter("@ID", id) };
            int Count = DB.ExecuteNonQuery("update T_CountryInfo set CountryName=@CountryName where CountryID=@ID", sp);
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
            int Count = DB.ExecuteNonQuery("update T_CountryInfo set IsValid=@IV where CountryID=@ID", SP);
            return Count;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int Insert(string text)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@CountryName", text) };
            int Count = DB.ExecuteNonQuery("insert into T_CountryInfo(CountryName) values(@CountryName)", sp);
            return Count;
        }
    }
}
