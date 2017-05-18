using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;

namespace DLL_BLL
{
    /// <summary>
    /// 系统自动运行的存储过程
    /// </summary>
    public class AutoRunProcBLL
    {
        /// <summary>
        /// 数据库自动处理客户账户余额，对未结账的账户进行结账操作
        /// </summary>
        /// <returns></returns>
        public static bool Proc_AutoSettleAccounts() 
        {
            if (DLL_DAL.AutoRunProcDAL.Proc_AutoSettleAccounts() > 0) return true;
            return false;
        }


        /// <summary>
        /// 数据库查找所有账户欠费的课户
        /// </summary>
        /// <returns></returns>
        public static List<View_ClientRoomState> Proc_AccountRemind()
        {
            return DLL_DAL.AutoRunProcDAL.Proc_AccountRemind();
        }

        /// <summary>
        /// 自动清理失效预订，返回受影响行数
        /// </summary>
        /// <returns></returns>
        public static List<T_BookRoom> Proc_AutoDeleteBook() 
        {
            List<T_BookRoom> TB = DLL_DAL.AutoRunProcDAL.PastDueBook();
            if (TB.Count > 0) 
            {
                DLL_DAL.AutoRunProcDAL.Proc_AutoDeleteBook();
            }
            return TB;
        }
    }
}
