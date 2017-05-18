using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;

namespace DLL_BLL
{
    public class ClientListBLL
    {
        /// <summary>
        /// 读取数据列表
        /// </summary>
        public static List<T_ClientInfo> LoadData()
        {
            return DLL_DAL.ClientListDAL.LoadData();
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <returns></returns>
        public static bool Update(T_ClientInfo ci)
        {
            if (DLL_DAL.ClientListDAL.Update(ci) > 0) return true;
            return false;
        }
    }
}
