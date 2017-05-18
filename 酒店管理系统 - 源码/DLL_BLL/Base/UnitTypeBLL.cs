using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;
using DLL_DAL;

namespace DLL_BLL
{
    public class UnitTypeBLL
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static List<T_UnitType> DataLoad(bool t)
        {
            return DLL_DAL.UnitTypeDAL.DataLoad(t);
        }

        /// <summary>
        ///启用或禁用项目 
        /// </summary>
        /// <param name="E"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool EnableItem(bool E, int ID)
        {
            if (UnitTypeDAL.EnableItem(E, ID) > 0)
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
        public static bool Update(string t, T_UnitType select)
        {
            int i = t.Length;
            if (i > 0 && i < 15 || t == select.UnitName)
            {
                if (DLL_DAL.UnitTypeDAL.Update(t, select.UnitID) > 0) { return true; }
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
                if (UnitTypeDAL.Insert(text) > 0) return true;
            }
            return false;
        }
    }
}
