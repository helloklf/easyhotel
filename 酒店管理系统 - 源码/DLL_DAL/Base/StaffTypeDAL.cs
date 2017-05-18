using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;

namespace DLL_DAL
{
    public class StaffTypeDAL
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static List<T_StaffType> DataLoad(bool E)
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                SqlParameter[] SP = new SqlParameter[] { new SqlParameter("@IV", E) };
                dr = DB.ExecuteReader("select STypeID,STypeName,STypeALevelID,T_StaffType.IsValid,ALevelName,ALevelRemark from T_StaffType join T_AccreditType on T_StaffType.STypeALevelID=T_AccreditType.ALevelID where T_StaffType.IsValid=@IV", SP);
                List<T_StaffType> TC = new List<T_StaffType>();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        T_StaffType tv = new T_StaffType();
                        tv.STypeID = (int)dr["STypeID"];
                        tv.ALevelName = (string)dr["ALevelName"];
                        tv.STypeName = (string)dr["STypeName"];
                        tv.STypeALevelID = (int)dr["STypeALevelID"];
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
        public static int Update(T_StaffType TV, int id)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sp = new SqlParameter[]
            { 
                new SqlParameter("@STypeName", TV.STypeName), 
                new SqlParameter("@STypeALevelID", TV.STypeALevelID),
                new SqlParameter("@ID", id) };
            int Count = DB.ExecuteNonQuery("update T_StaffType set STypeName=@STypeName,STypeALevelID=@STypeALevelID where STypeID=@ID", sp);
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
            int Count = DB.ExecuteNonQuery("update T_StaffType set IsValid=@IV where STypeID=@ID", SP);
            return Count;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int Insert(T_StaffType TV)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sp = new SqlParameter[] 
            { 
                new SqlParameter("@STypeName", TV.STypeName), 
                new SqlParameter("@STypeALevelID", TV.STypeALevelID),
            };
            int Count = DB.ExecuteNonQuery("insert into T_StaffType(STypeName,STypeALevelID) values(@STypeName,@STypeALevelID)", sp);
            return Count;
        }
    }
}
