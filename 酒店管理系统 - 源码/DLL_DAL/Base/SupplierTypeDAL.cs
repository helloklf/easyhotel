using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;

namespace DLL_DAL
{
    public class SupplierTypeDAL
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static List<T_SupplierType> DataLoad(bool E)
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                SqlParameter[] SP = new SqlParameter[] { new SqlParameter("@IV", E) };
                dr = DB.ExecuteReader("select * from T_SupplierType where IsValid=@IV",SP);
                List<T_SupplierType> TC = new List<T_SupplierType>();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        T_SupplierType tv = new T_SupplierType();
                        tv.ID = (int)dr["ID"];
                        tv.Name = (string)dr["Name"];
                        tv.Remark = (string)dr["Remark"];
                        tv.IsValid = (bool)dr["IsValid"];
                        TC.Add(tv);
                    }
                }
                return TC;
            }
            finally
            {
                DB.ConnClose(); if (dr != null) { dr.Dispose(); }
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="t"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Update(T_SupplierType TV, int id)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sp = new SqlParameter[]
            { 
                new SqlParameter("@Name", TV.Name), 
                new SqlParameter("@Remark", TV.Remark),
                new SqlParameter("@ID", id) };
            int Count = DB.ExecuteNonQuery("update T_SupplierType set Name=@Name,Remark=@Remark where ID=@ID", sp);
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
            int Count = DB.ExecuteNonQuery("update T_SupplierType set IsValid=@IV where ID=@ID", SP);
            return Count;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int Insert(T_SupplierType TV)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sp = new SqlParameter[] 
            { 
                new SqlParameter("@Name", TV.Name), 
                new SqlParameter("@Remark", TV.Remark),
            };
            int Count = DB.ExecuteNonQuery("insert into T_SupplierType(Name,Remark) values(@Name,@Remark)", sp);
            return Count;
        }
    }
}
