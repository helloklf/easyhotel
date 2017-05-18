using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;
namespace DLL_DAL
{
    public class UnitTypeDAL
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static List<T_UnitType>  DataLoad(bool E)
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                SqlParameter[] SP = new SqlParameter[] { new SqlParameter("@IV", E) };
                dr = DB.ExecuteReader("select * from T_UnitType where IsValid=@IV",SP);
                List<T_UnitType> TP = new List<T_UnitType>();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        T_UnitType tp = new T_UnitType();
                        tp.UnitName = (string)dr[1];
                        tp.UnitID = (int)dr[0];
                        tp.IsValid = (bool)dr[2];
                        TP.Add(tp);
                    }
                }
                return TP;
            }
            finally
            {
                DB.ConnClose();
                if (dr != null) { dr.Close();}
            }
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
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@UnitName", t), new SqlParameter("@ID", id) };
            int Count = DB.ExecuteNonQuery("update T_UnitType set UnitName=@UnitName where UnitID=@ID", sp);
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
            int Count = DB.ExecuteNonQuery("update T_UnitType set IsValid=@IV where UnitID=@ID", SP);
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
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@UnitName", text) };
            int Count = DB.ExecuteNonQuery("insert into T_UnitType(UnitName) values(@UnitName)", sp);
            return Count;
        }
    }
}
