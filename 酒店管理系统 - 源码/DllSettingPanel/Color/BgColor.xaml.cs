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

namespace DllSettingPanel
{
    /// <summary>
    /// BgColor.xaml 的交互逻辑
    /// </summary>
    public partial class BgColor : UserControl
    {
        public BgColor()
        {
            InitializeComponent();
            try
            {
                ColorsPanlStart();
            }
            catch { }
        }
        #region 为色板提供选定支持
        private void ColorsPanlStart()
        {
            foreach (Button item in ColorPanl.Children)
            {
                item.Click += SelectColor; item.Focusable = false;
            }
            foreach (Button item in ColorPanl1.Children)
            {
                item.Click += SelectColor1; item.Focusable = false;
            }
        }
        #endregion


        /// <summary>
        /// 基本外观配置信息
        /// </summary>
        DllSetting.AppSurface BGSET = Values.SurfaceSetting.Surface;

        #region 颜色选择
        /// <summary>
        /// 选择深色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectColor(object sender, RoutedEventArgs e)
        {
            Button bt = sender as Button;
            Values.SurfaceSetting.Surface.BgColor = (SolidColorBrush)bt.Background;
            Values.SurfaceSetting.Surface.ForeColor = (SolidColorBrush)new SolidColorBrush(Colors.White);
            //? SetColor(Set1);
        }

        /// <summary>
        /// 选择浅色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectColor1(object sender, RoutedEventArgs e)
        {
            Button bt = sender as Button;
            BGSET.BgColor = (SolidColorBrush)bt.Background;
            BGSET.ForeColor = (SolidColorBrush)new SolidColorBrush(Colors.Black);
            //? SetColor(Set1);//作为主题色
        }
        #endregion

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            C.DataContext = Values.SurfaceSetting.Surface;
        }
    }
}
