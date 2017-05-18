using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;
using System.Windows.Media.Imaging;
using System.IO;
using System.Data;

namespace DLL_DAL
{
    public class WaresTypeDAL
    {/// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static List<T_WaresType> DataLoad(bool E)
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                SqlParameter[] SP = new SqlParameter[] { new SqlParameter("@IV", E) };
                dr = DB.ExecuteReader("select * from T_WaresType where IsValid=@IV",SP);
                List<T_WaresType> TC = new List<T_WaresType>();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        T_WaresType tv = new T_WaresType();
                        tv.WaresID = (int)dr["WaresID"];
                        tv.WaresName = (string)dr["WaresName"];
                        try
                        {
                            byte[] img = (byte[])dr["WaresImage"];
                            tv.WaresImage = Other.GetImage(img);
                        }
                        catch { }
                        tv.WaresRemark = (string)dr["WaresRemark"];
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
        public static int Update(T_WaresType TV,string uri,bool isNew, int id)
        {
            Task_DBHelper DB = new Task_DBHelper(); 
            SqlParameter[] sp;
            SqlParameter name = new SqlParameter("@WaresName", TV.WaresName);
            SqlParameter remark = new SqlParameter("@WaresRemark", TV.WaresRemark);
            SqlParameter ID = new SqlParameter("@ID", id);
            if (isNew)
            {
                SqlParameter s = Other.ImageToSqlParameter(uri, "WaresImage");
                sp = new SqlParameter[] 
                {
                    name,remark,s,ID
                };
                int Count = DB.ExecuteNonQuery("update T_WaresType set WaresName=@WaresName,WaresRemark=@WaresRemark,WaresImage=@WaresImage where WaresID=@ID", sp);
                return Count;
            }
            else 
            {
                sp = new SqlParameter[] { name, remark,ID };
                int Count = DB.ExecuteNonQuery("update T_WaresType set WaresName=@WaresName,WaresRemark=@WaresRemark where WaresID=@ID", sp);
                return Count;
            }
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
            int Count = DB.ExecuteNonQuery("update T_WaresType set IsValid=@IV where WaresID=@ID", SP);
            return Count;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int Insert(T_WaresType TV,string uri)
        {
            Task_DBHelper DB = new Task_DBHelper(); 
            SqlParameter[] sp;
            try
            {
                SqlParameter name = new SqlParameter("@WaresName", TV.WaresName);
                SqlParameter remark = new SqlParameter("@WaresRemark", TV.WaresRemark);
                SqlParameter s =null;
                try
                {
                    s = Other.ImageToSqlParameter(uri, "WaresImage");
                }
                catch {  }
                if (s != null)
                {
                    sp = new SqlParameter[] 
                    {
                        name,remark,s
                    };
                    int Count = DB.ExecuteNonQuery("insert into T_WaresType(WaresName,WaresImage,WaresRemark) values(@WaresName,@WaresImage,@WaresRemark)", sp);
                    return Count;
                }
                else
                {
                    sp = new SqlParameter[] { name, remark }; 
                    int Count = DB.ExecuteNonQuery("insert into T_WaresType(WaresName,WaresRemark) values(@WaresName,@WaresRemark)", sp);
                    return Count;
                }
            }
            catch { throw new Exception("创建参数出现错误！请检查输入的数据是否有效，如果依然出现此错误，请报告给开发者！"); }
            
        }
    }
}
