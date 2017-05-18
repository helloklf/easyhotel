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
    public class LoginDAL
    {
        public static View_UserInfo UserLogin(string user, string pass)
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            View_UserInfo ts = new View_UserInfo();
            try
            {
                SqlParameter[] sqlp = new SqlParameter[] { new SqlParameter("@StaffID", user), new SqlParameter("@StaffPass", pass) };
                dr = DB.ExecuteReaderProc("Proc_UserLogin", sqlp);
                int count=0;
                while (dr.Read())
                {
                    ts.StaffID = dr["StaffID"] as string;
                    ts.StaffName = dr["StaffName"] as string;
                    ts.STypeID = (int)dr["STypeID"];
                    ts.STypeName = (string)dr["STypeName"];
                    ts.ALevelID = (int)dr["ALevelID"];
                    ts.ALevelName = (string)dr["ALevelName"];
                    ts.StaffPassMD5 = (string)dr["StaffPwdMD5"];
                    try
                    {
                        ts.ImageBytes= (byte[])dr["StaffImage"];
                    }
                    catch { }
                    //try
                    //{
                    //    byte[] img = (byte[])dr["StaffImage"];
                    //    ts.StaffImage = Other.GetImage(img);
                    //}catch { }
                    count++;
                }
                if (count < 1) throw new Exception("用户名不存在或密码错误！如果你忘了密码，请联系管理员！");
            }
            finally
            {
                DB.ConnClose();
                if (dr != null) { dr.Close(); dr.Dispose(); }
            }
            return ts;
        }
    }
}
