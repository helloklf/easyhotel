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
using DllSettingPanel;
using System.Threading;
using System.Windows.Threading;

namespace Project_Term2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StartWindow : Window
    {
        #region 窗体基本逻辑

        //窗体关闭时
        private void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ExitAffirm ea = new ExitAffirm(); ea.ShowDialog();
            if (ea.DR != MessageBoxResult.Yes)
            {
                e.Cancel = true;
            }
            else 
            {
                MessageWindow.Close();
            }
        }

        /// <summary>
        /// 顶部双击缩放窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopDoubleClick_WindowSize(object sender, MouseButtonEventArgs e)
        {
            WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        /// <summary>
        /// 窗体拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }
        #endregion


        //#region 鼠标右键拖动换页
        //double StartX = 0; double StartY = 0;
        //private void MainMenuView_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    StartX = e.GetPosition(MainMenuView).X;
        //    StartY = e.GetPosition(MainMenuView).Y;
        //}

        //private void MainMenuView_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    double x = e.GetPosition(MainMenuView).X;
        //    double y = e.GetPosition(MainMenuView).Y;
        //    if (Math.Abs(StartY - y) < (this.ActualHeight * 0.1))
        //    {
        //        if (StartX - x > (this.ActualWidth * 0.25))
        //            MainMenuView.ScrollToHorizontalOffset(MainMenuView.HorizontalOffset + 1);
        //        else if (StartX - x < -(this.ActualWidth * 0.25))
        //            MainMenuView.ScrollToHorizontalOffset(MainMenuView.HorizontalOffset - 1);
        //    }
        //}
        //#endregion

        #region 按住鼠标右键滚动换页

        /// <summary>
        /// 鼠标滚轮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScrollViewer_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            //if (e.RightButton == MouseButtonState.Pressed)
            //{
            //    if (e.Delta < 0)
            //    {
            //        TabSelectIndexUp();
            //    }
            //    else { TabSelectIndexDown(); }
            //}
        }

        /// <summary>
        /// 向后翻页
        /// </summary>
        public void TabSelectIndexUp()
        {
            if (MainMenuList.SelectedIndex != (MainMenuList.Items.Count - 1)) MainMenuList.SelectedIndex++;
        }

        /// <summary>
        /// 向前翻页
        /// </summary>
        public void TabSelectIndexDown()
        {
             if (MainMenuList.SelectedIndex != 0) MainMenuList.SelectedIndex--; 
        }
        #endregion
    }
}
