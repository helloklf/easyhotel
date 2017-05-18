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
    /// C_Battery.xaml 的交互逻辑
    /// </summary>
    public partial class C_Battery : UserControl
    {
        public C_Battery()
        {
            InitializeComponent();
            //电池电量刷新
            BatteryStart();
        }
        BitmapImage bim = new BitmapImage();

        Project_Term2.Other_Function.SYSTEM_POWER_STATUS SysPower = new Other_Function.SYSTEM_POWER_STATUS();

        #region 电池电量监视
        /// <summary>
        /// 启动电池刷新
        /// </summary>
        private void BatteryStart()
        {
            DispatcherTimer time = new DispatcherTimer();
            time.Interval = new TimeSpan(0, 5, 0);
            time.Tick += (a, b) => { BatteryState(); }; time.Start();
            BatteryState();
        }

        /// <summary>
        /// 电池状态
        /// </summary>
        private void BatteryState()
        {
            try
            {
                if (SystemParameters.PowerLineStatus == PowerLineStatus.Online)
                {
                    bim = new BitmapImage(new Uri("/酒店管理系统-主程序;component/Controls/Image/ICON0/电池/充电.png", UriKind.Relative));
                    BatteryImage.Source = bim;
                }
                else
                {
                    Project_Term2.Other_Function.GetSystemPowerStatus(ref SysPower);
                    byte num = SysPower.BatteryLifePercent;
                    BatteryText.Text = num.ToString();
                    if (num < 15)
                    {
                        bim = new BitmapImage(new Uri("/酒店管理系统-主程序;component/Controls/Image/ICON0/电池/空.png", UriKind.Relative));
                        BatteryImage.Source = bim;
                    }
                    else if (num < 45)
                    {
                        bim = new BitmapImage(new Uri("/酒店管理系统-主程序;component/Controls/Image/ICON0/电池/低.png", UriKind.Relative));
                        BatteryImage.Source = bim;
                    }
                    else if (num < 65)
                    {
                        bim = new BitmapImage(new Uri("/酒店管理系统-主程序;component/Controls/Image/ICON0/电池/中.png", UriKind.Relative));
                        BatteryImage.Source = bim;
                    }
                    else
                    {
                        bim = new BitmapImage(new Uri("/酒店管理系统-主程序;component/Controls/Image/ICON0/电池/满.png", UriKind.Relative));
                        BatteryImage.Source = bim;
                    }
                }
            }
            catch { }
        }
        #endregion
    }
}
