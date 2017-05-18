using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;

namespace Project_Term2_Staff
{
    public delegate void Updates(T_StaffInfo Ts);
    public delegate void VOID();
    public class Delegates
    {
        public static Updates update;
        public static VOID TabAdd;//去添加
        public static VOID TabChangeReturn;//返回
    }
}
