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
    /// <summary>
    /// 证件类型
    /// </summary>
    public class PapersTypeBLL
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static List<T_PaperType> DataLoad(bool t)
        {
            return DLL_DAL.PapersTypeDAL.DataLoad(t);
        }

        /// <summary>
        ///启用或禁用项目 
        /// </summary>
        /// <param name="E"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool EnableItem(bool E, int ID)
        {
            if (PapersTypeDAL.EnableItem(E,ID) > 0)
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
        public static bool Update(string t,T_PaperType select)
        {
            int i = t.Length;
            if (i > 0 && i < 15||t == select.PapersName)
            {
                if (DLL_DAL.PapersTypeDAL.Update(t, select.PapersID) > 0) { return true; }
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
                if (PapersTypeDAL.Insert(text) > 0) return true;
            } 
            return false;
        }
    }
}
