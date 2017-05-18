using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllSettingPanel
{
    public delegate void VOID();
    public class Delegates
    {
        /// <summary>
        /// 关闭设置面板
        /// </summary>
        public static VOID ClosePage;
    }
}
