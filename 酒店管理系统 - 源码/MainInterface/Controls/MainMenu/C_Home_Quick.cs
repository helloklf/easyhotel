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
using System.Diagnostics;
using System.IO;

namespace Project_Term2.MainMenu
{
    /// <summary>
    /// P_MainMenu0.xaml 的交互逻辑
    /// </summary>
    public partial class C_Home : UserControl
    {

        /// <summary>
        /// 打开计算器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open_Calculator(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ProcessStartInfo pi = new ProcessStartInfo("calc");
                System.Diagnostics.Process.Start(pi);
            }
            catch (Exception ex) { Functions.ShowMessage(ex.Message, "打开失败"); }
        }

        /// <summary>
        /// 打开软键盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open_SoftKeyboard(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ProcessStartInfo pi = new ProcessStartInfo("osk");
                System.Diagnostics.Process.Start(pi);
            }
            catch (Exception ex) { Functions.ShowMessage(ex.Message, "打开失败"); }
        }

        /// <summary>
        /// 打开记事本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open_Notepad(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ProcessStartInfo pi = new ProcessStartInfo("notepad");
                System.Diagnostics.Process.Start(pi);
            }
            catch (Exception ex) { Functions.ShowMessage(ex.Message, "打开失败"); }
        }

        /// <summary>
        /// 打开任务管理器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open_Task(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ProcessStartInfo pi = new ProcessStartInfo("LaunchTM");
                System.Diagnostics.Process.Start(pi);
            }
            catch (Exception ex) { Functions.ShowMessage(ex.Message, "打开失败"); }
        }

        /// <summary>
        /// 屏幕放大镜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open_Magnify(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ProcessStartInfo pi = new ProcessStartInfo("Magnify");
                System.Diagnostics.Process.Start(pi);
            }
            catch (Exception ex) { Functions.ShowMessage(ex.Message, "打开失败"); }
        }

        /// <summary>
        /// 打开系统画图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open_Mspaint(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ProcessStartInfo pi = new ProcessStartInfo("Mspaint");
                System.Diagnostics.Process.Start(pi);
            }
            catch (Exception ex) { Functions.ShowMessage(ex.Message, "打开失败"); }
        }

        /// <summary>
        /// 打开IE浏览器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open_IEXPLORE(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ProcessStartInfo pi = new ProcessStartInfo("IEXPLORE");
                System.Diagnostics.Process.Start(pi);
            }
            catch (Exception ex) { Functions.ShowMessage(ex.Message, "打开失败"); }
        }

        /// <summary>
        /// 显示截屏工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open_SnippingTool(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ProcessStartInfo pi = new ProcessStartInfo("SnippingToole");
                System.Diagnostics.Process.Start(pi);
            }
            catch (Exception ex) { Functions.ShowMessage(ex.Message, "打开失败"); }
        }

        /// <summary>
        /// 打开播放器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open_Play(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ProcessStartInfo pi = new ProcessStartInfo("wmplayer");
                System.Diagnostics.Process.Start(pi);
            }
            catch { Functions.ShowMessage("由于应用程序组件出现错误，播放器无法正常启动！", "无法打开"); }
        }
    }
}
