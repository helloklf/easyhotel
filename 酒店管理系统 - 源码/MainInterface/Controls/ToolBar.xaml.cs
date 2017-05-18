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
using Project_Term2.UserPage;

namespace Project_Term2.Top
{
    /// <summary>
    /// ToolBar.xaml 的交互逻辑
    /// </summary>
    public partial class ToolBar : UserControl
    {
        public ToolBar()
        {
            InitializeComponent();
            MCount.DataContext = UserPage.ApplcitionMessage.list;
        }
        #region 后退
        /// <summary>
        /// 向前翻页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainPage_Up(object sender, MouseButtonEventArgs e)
        {

        }
        #endregion

        #region 前进
        /// <summary>
        /// 向后翻页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainPage_Down(object sender, MouseButtonEventArgs e)
        {

        }
        #endregion

        #region 刷新
        /// <summary>
        /// 重置或重新加载当前页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetOrLoad(object sender, MouseButtonEventArgs e)
        {
            if (Project_Term2_BaseData.BaseDataDelegates.MainDelegate!=null)
                Project_Term2_BaseData.BaseDataDelegates.MainDelegate();
        }
        #endregion

        #region 用户
        /// <summary>
        /// 显示用户中心
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserWindowState(object sender, MouseButtonEventArgs e)
        {
            Values.PageStates.UserCenter = Values.PageStates.UserCenter != Visibility.Visible ? Visibility.Visible : Visibility.Collapsed;
        }
        #endregion

        #region 消息
        /// <summary>
        /// 消息中心
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserWindowState_Message(object sender, MouseButtonEventArgs e)
        {
            Values.PageStates.UserCenter = Values.PageStates.UserCenter != Visibility.Visible ? Visibility.Visible : Visibility.Collapsed;
            if (Delegates.ToMessagePage != null) Delegates.ToMessagePage();
        }
        #endregion

        #region 设置
        /// <summary>
        /// 初始化颜色选择器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowColorSelectPanl(object sender, MouseButtonEventArgs e)
        {
            Values.PageStates.Setting = Values.PageStates.Setting != Visibility.Visible ? Visibility.Visible : Visibility.Collapsed;
        }
        #endregion

        #region 最小化
        /// <summary>
        /// 最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowMini(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.MinWindow != null) { Delegates.MinWindow(); }
            else 
            {
                Functions.ShowMessage("功能未被初始化，可能是应用程序缺陷。请联系开发者修补该漏洞！", "不能最小化");
            }
        }
        #endregion

        #region 最大化-默认
        /// <summary>
        /// 最大化-默认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WinodwMax(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.MaxWindow != null) { Delegates.MaxWindow(); }
            else
            {
                Functions.ShowMessage("功能未被初始化，可能是应用程序缺陷。请联系开发者修补该漏洞！", "不能最大化");
            }
        }
        #endregion

        #region 关闭窗口
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseWindow(object sender, MouseButtonEventArgs e)
        {
            //窗口关闭
            //? Close();
            Delegates.CloseWindow();
        }
        #endregion

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.C.DataContext = Values.SurfaceSetting.Surface;
        }

        private void LockAppliction_Click(object sender, RoutedEventArgs e)
        {
            LockPage lp = new LockPage(); this.Visibility = Visibility.Collapsed; lp.ShowDialog(); this.Visibility = Visibility.Visible;
        }


        private void LockAppliction_Click(object sender, MouseButtonEventArgs e)
        {
            LockPage lp = new LockPage(); this.Visibility = Visibility.Collapsed;
            lp.ShowDialog();
        }

        private void MainPage_ToHome(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.ToPageIndex != null) Delegates.ToPageName("mainmenu");
        }



    }
}
