using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;

namespace DLL_DAL
{
    public class OperateTypeDAL
    {/// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static List<T_OperateType> DataLoad(bool isv)
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                SqlParameter[] sqlp = new SqlParameter[] { new SqlParameter("@isv", isv) };
                dr = DB.ExecuteReader("select * from T_OperateType where IsValid=@isv", sqlp);
                List<T_OperateType> TP = new List<T_OperateType>();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        T_OperateType tp = new T_OperateType();
                        tp.OperateName = (string)dr[1];
                        tp.TypeID = (int)dr[0];
                        tp.IsValid = (bool)dr[2];
                        TP.Add(tp);
                    }
                }
                return TP;
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
        public static int Update(string t, int id)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@OperateName", t), new SqlParameter("@ID", id) };
            int Count = DB.ExecuteNonQuery("update T_OperateType set OperateName=@OperateName where TypeID=@ID", sp);
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
            int Count = DB.ExecuteNonQuery("update T_OperateType set IsValid=@IV where TypeID=@ID", SP);
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
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@OperateName", text) };
            int Count = DB.ExecuteNonQuery("insert into T_OperateType(OperateName) values(@OperateName)", sp);
            return Count;
        }
    }
}
