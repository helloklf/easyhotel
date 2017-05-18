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
    public class VIPListDAL
    {
        /// <summary>
        /// 读取列表
        /// </summary>
        /// <param name="isv"></param>
        /// <returns></returns>
        public static List<T_VIPInfo> Getdata(bool isv)
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                SqlParameter[] sqlp = new SqlParameter[] { new SqlParameter("@isv", isv) };
                dr = DB.ExecuteReader("select * from T_VIPInfo where IsValid=@isv", sqlp);
                List<T_VIPInfo> vips = new List<T_VIPInfo>();
                while (dr.Read())
                {
                    T_VIPInfo vi = new T_VIPInfo();
                    vi.VIPID = (string)dr["VIPID"];
                    vi.VIPIntegral = (int)dr["VIPIntegral"];
                    vi.IsValid = (bool)dr["IsValid"];
                    vips.Add(vi);
                }
                return vips;
            }
            finally
            {
                DB.ConnClose();
                if (dr != null) { dr.Dispose(); }
            }
        }


        /// <summary>
        /// 启用或禁用项
        /// </summary>
        /// <param name="isEnable"></param>
        /// <returns></returns>
        public static int ItemEnabled(string id, bool isEnable)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sqlp = new SqlParameter[] { new SqlParameter("@id", id), new SqlParameter("@isEnable", isEnable) };
            return DB.ExecuteNonQuery("update T_VIPInfo set IsValid=@isEnable where VIPID=@id", sqlp);
        }


        /// <summary>
        /// 新增VIP
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Insert(string id)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sqlp = new SqlParameter[] { new SqlParameter("@ID",id) };
            return DB.ExecuteNonQuery("insert into T_VIPInfo(VIPID) values(@ID)", sqlp);
        }
    }
}
