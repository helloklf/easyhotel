using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;

namespace DLL_BLL
{
    public class VIPListBLL
    {
        /// <summary>
        /// 读取列表数据
        /// </summary>
        /// <param name="isv"></param>
        /// <returns></returns>
        public static List<T_VIPInfo> Getdata(bool isv)
        {
            return DLL_DAL.VIPListDAL.Getdata(isv);
        }

        /// <summary>
        /// 启用或禁用项
        /// </summary>
        /// <param name="isEnable"></param>
        /// <returns></returns>
        public static bool ItemEnabled(string id,bool isEnable)
        {
            if (DLL_DAL.VIPListDAL.ItemEnabled(id,isEnable) > 0) return true;
            return false;
        }

        /// <summary>
        /// 新增VIP
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Insert(string id) 
        {
            if (DLL_DAL.VIPListDAL.Insert(id) > 0) return true;
            return false;
        }
    }
}
