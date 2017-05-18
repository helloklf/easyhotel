using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Project_Term2.Controls
{
    /// <summary>
    /// C_TimeSpan.xaml 的交互逻辑
    /// </summary>
    public partial class C_TimeSpan : UserControl
    {
        public C_TimeSpan()
        {
            InitializeComponent();
            TimeSystem();//时间系统
        }


        #region 时间系统
        /// <summary>
        /// 时间系统
        /// </summary>
        public void TimeSystem()
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += (a, b) =>
            {
                SysDate.Text = Other_Function.GetDateString();
                SysTime.Text = Other_Function.GetTimeString();
            };
            dt.Start();
        }
        #endregion
    }
}
