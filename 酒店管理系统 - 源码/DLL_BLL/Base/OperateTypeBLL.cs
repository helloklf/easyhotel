using DLL_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;

namespace DLL_BLL
{
    public class OperateTypeBLL
    {/// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static List<T_OperateType> DataLoad(bool t)
        {
            return  DLL_DAL.OperateTypeDAL.DataLoad(t);
        }

        /// <summary>
        ///启用或禁用项目 
        /// </summary>
        /// <param name="E"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool EnableItem(bool E, int ID)
        {
            if (OperateTypeDAL.EnableItem(E, ID) > 0)
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
        public static bool Update(string t, T_OperateType select)
        {
            int i = t.Length;
            if (i > 0 && i < 15 || t == select.OperateName)
            {
                if (DLL_DAL.OperateTypeDAL.Update(t, select.TypeID) > 0) { return true; }
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
                if ( OperateTypeDAL.Insert(text) > 0) return true;
            }
            return false;
        }
    }
}
