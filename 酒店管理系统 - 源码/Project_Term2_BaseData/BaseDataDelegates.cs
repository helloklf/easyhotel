using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Term2_BaseData
{
    public delegate void IntParameter(int index);
    public delegate void NotParameter();
    /// <summary>
    /// 基础数据相关委托
    /// </summary>
    public class BaseDataDelegates
    {
        /// <summary>
        /// 跳转到指定页面
        /// </summary>
        /// <returns></returns>
        public static IntParameter ToPage;

        /// <summary>
        /// 主要的委托，刷新页面用
        /// </summary>
        public static NotParameter MainDelegate;

        /// <summary>
        /// 返回主菜单
        /// </summary>
        public static NotParameter ReturnToMainMenu;
    }
}
