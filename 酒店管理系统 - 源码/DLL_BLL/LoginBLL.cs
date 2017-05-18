using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TModel;
using System.Data;
using System.Data.SqlClient;

namespace DLL_BLL
{
    public class LoginBLL
    {
        public static View_UserInfo UserLogin(string user, string pass)
        {
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));
            pass = BitConverter.ToString(bytes);
            View_UserInfo vu = DLL_DAL.LoginDAL.UserLogin(user,pass);
            return vu;
        }
    }
}
