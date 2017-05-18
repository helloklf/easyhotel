using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;
using DLL_DAL;
using System.Data.SqlClient;

namespace DLL_BLL
{
    /// <summary>
    /// 国家信息读写
    /// </summary>
    public class CountryInfoBLL
    {
        /// <summary>
        /// 读取国家信息数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static List<T_CountryInfo> DataLoad(bool t)
        {
            return DLL_DAL.CountryInfoDAL.DataLoad(t) ;
        }

        /// <summary>
        /// 用于根据国家ID查询得到国家名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetCountryName(int id)
        {
            return DLL_DAL.CountryInfoDAL.GetCountryName(id);
        }

        /// <summary>
        ///启用或禁用项目 
        /// </summary>
        /// <param name="E"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool EnableItem(bool E, int ID)
        {
            if (CountryInfoDAL.EnableItem(E, ID) > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="t"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        public static bool Update(string t, T_CountryInfo select)
        {
            int i = t.Length;
            if (i > 0 && i < 15 || t == select.CountryName)
            {
                if (DLL_DAL.CountryInfoDAL.Update(t, select.CountryID) > 0) { return true; }
            }
            return false;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool Insert(string text)
        {
            int i = text.Length;
            if (i > 0 && i < 15)
            {
                if (CountryInfoDAL.Insert(text) > 0) return true;
            }
            return false;
        }
    }
}
