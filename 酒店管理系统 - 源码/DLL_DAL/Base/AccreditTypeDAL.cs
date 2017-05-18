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
    /// 授权类型
    /// </summary>
    public class AccreditTypeDAL
    {
        /// <summary>
        /// 读取授权类型数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static List<T_AccreditType> Get_AccreditTypeList(bool b)
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                SqlParameter[] sqlp = new SqlParameter[] { new SqlParameter("@IsValid",b) };
                dr = DB.ExecuteReader("select * from T_AccreditType where IsValid=@IsValid",sqlp);
                List<T_AccreditType> TC = new List<T_AccreditType>();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        T_AccreditType tv = new T_AccreditType();
                        tv.ALevelID = (int)dr["ALevelID"];
                        tv.ALevelName = (string)dr["ALevelName"];
                        object o = dr["ALevelRemark"];if(o!=DBNull.Value) tv.ALevelRemark = (string)o;
                        tv.IsValid = (bool)dr["IsValid"];
                        TC.Add(tv);
                    }
                }
                return TC;
            }
            finally
            {
                DB.ConnClose();
                if (dr != null) { dr.Close(); }
            }
        }

        /// <summary>
        /// 更新授权类型数据
        /// </summary>
        /// <param name="t"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Update(T_AccreditType TV, int id)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sp = new SqlParameter[]
            { 
                new SqlParameter("@AlevelName", TV.ALevelName), 
                new SqlParameter("@ALevelRemark", TV.ALevelRemark),
                new SqlParameter("@ID", id) };
            int Count = DB.ExecuteNonQuery("update T_AccreditType set ALevelRemark=@ALevelRemark,AlevelName=@AlevelName where ALevelID=@ID", sp);
            return Count;
        }

        /// <summary>
        /// 启用或禁用授权类型项
        /// </summary>
        /// <param name="E"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static int AccreditType_Enable(bool E, int ID)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] SP = new SqlParameter[] { new SqlParameter("@IV", E), new SqlParameter("@ID", ID) };
            int Count = DB.ExecuteNonQuery("update T_AccreditType set IsValid=@IV where ALevelID=@ID", SP);
            return Count;
        }

        /// <summary>
        /// 插入授权类型数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int Insert(T_AccreditType TV)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sp = new SqlParameter[] 
            { 
                new SqlParameter("@AlevelName", TV.ALevelName), 
                new SqlParameter("@ALevelRemark", TV.ALevelRemark),
            };
            int Count = DB.ExecuteNonQuery("insert into T_AccreditType(AlevelName,ALevelRemark) values(@AlevelName,@ALevelRemark)", sp);
            return Count;
        }
    }
}
