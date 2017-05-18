using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;

namespace DLL_DAL
{
    public class PapersTypeDAL
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static List<T_PaperType> DataLoad(bool e)
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                SqlParameter[] SP = new SqlParameter[] { new SqlParameter("@IV", e) };
                dr = DB.ExecuteReader("select * from T_PaperType where IsValid=@IV",SP);
                List<T_PaperType> TP = new List<T_PaperType>();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        T_PaperType tp = new T_PaperType();
                        tp.PapersName = (string)dr[1];
                        tp.PapersID = (int)dr[0];
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
        public static int Update(string t,int id)
        {
            Task_DBHelper DB = new Task_DBHelper(); 
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@PapersName", t), new SqlParameter("@ID", id) };
            int Count = DB.ExecuteNonQuery("update T_PaperType set PapersName=@PapersName where PapersID=@ID", sp);
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
            int Count = DB.ExecuteNonQuery("update T_PaperType set IsValid=@IV where PapersID=@ID", SP);
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
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@PapersName", text) };
            int Count = DB.ExecuteNonQuery("insert into T_PaperType(PapersName) values(@PapersName)", sp);
            return Count;
        }
    }
}
