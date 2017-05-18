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
    /// SettingMenu.xaml 的交互逻辑
    /// </summary>
    public partial class SettingMenu : UserControl
    {
        public SettingMenu()
        {
            InitializeComponent();
        }
        #region 设置页切换
        private void SetSelect0(object sender, RoutedEventArgs e)
        {
            SettingListIndex.Index.TabItemIndex = 0;
        }

        private void SetSelect1(object sender, RoutedEventArgs e)
        {
            SettingListIndex.Index.TabItemIndex = 1;
        }
        private void SetSelect2(object sender, RoutedEventArgs e)
        {
            SettingListIndex.Index.TabItemIndex = 2;
        }
        private void SetSelect3(object sender, RoutedEventArgs e)
        {
            SettingListIndex.Index.TabItemIndex = 3;
        }
        private void SetSelect4(object sender, RoutedEventArgs e)
        {
            SettingListIndex.Index.TabItemIndex = 4;
        }
        #endregion

        #region 关闭
        /// <summary>
        /// 关闭页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void Close_MiniPage_Content(object sender, RoutedEventArgs e)
        {
            try
            {
                DllSetting.Values.CreateSetting(false);//依据现有设置生成设置存档
                Inform.Functions.ShowMessage("应用程序外观设置已保存，下次启动时将载入当前外观设置！", "操作完成");
                if(Delegates.ClosePage!=null)Delegates.ClosePage();
            }
            catch { Inform.Functions.ShowMessage("出现未知异常，实验性功能中的外观存储出现错误，无法保存外观设置！", "保存失败"); }
            Set0.IsChecked = true; SetSelect0(null,null);
        }
        #endregion

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            C.DataContext = Values.SurfaceSetting.Surface;
        }





    }
}
