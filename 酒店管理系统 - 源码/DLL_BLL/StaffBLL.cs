using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL_BLL;
using TModel;
using DLL_DAL;
using System.Data;
using System.Security.Cryptography;

namespace DLL_BLL
{
    public class StaffBLL
    {
        public static bool Insert(T_StaffInfo ts, string uri)
        {
            if (StaffDAL.Insert(ts, uri) > 0) return true;
            return false;
        }
        public static bool Insert(T_StaffList ts)
        {
            MD5 md5 = MD5.Create();
            byte[] bs = md5.ComputeHash( Encoding.UTF8.GetBytes(ts.StaffPwdMD5));
            ts.StaffPwdMD5 = BitConverter.ToString(bs);
            if (StaffDAL.Insert(ts) > 0) return true;
            return false;
        }
        #region 员工个人信息更新
        /// <summary>
        /// 员工个人信息更新
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static bool Update(T_StaffInfo ts, string uri)
        {
            if (StaffDAL.Update(ts, uri) > 0) return true;
            return false;
        }
        #endregion

        #region 员工登录账户设置
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static bool Update(T_StaffList ts)
        {
            MD5 mdt = MD5.Create();
            byte[] bytes = mdt.ComputeHash(Encoding.UTF8.GetBytes(ts.StaffPwdMD5));
            ts.StaffPwdMD5 = BitConverter.ToString(bytes);
            if (StaffDAL.Update(ts) > 0) return true;
            return false;
        }
        #endregion

        public static List<T_StaffInfo> GetData(bool isEnable) 
        {
            return DLL_DAL.StaffDAL.GetData(isEnable); 
        }
        public static DataTable GetStaffListData(bool isEnable) 
        {
             return StaffDAL.GetData();
        }

        public static bool EnableItem(bool b, string id) 
        {
            if (DLL_DAL.StaffDAL.EnableItem(b, id) > 0) { return true; }
            return false;
        }
    }
}
