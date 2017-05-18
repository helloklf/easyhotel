using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Project_Term2
{
    /// <summary>
    /// LockPage.xaml 的交互逻辑
    /// </summary>
    public partial class LockPage : Window
    {
        public LockPage()
        {
            InitializeComponent();
        }


        private void LockApp(object sender, MouseButtonEventArgs e) 
        {
            try
            {
                if (Values.UserInfo==null||Values.UserInfo.StaffPassMD5 == null || Values.UserInfo.StaffPassMD5.Length < 1)
                {
                    this.Close();Delegates.MaxWindow(); 
                }
                if (PassTxt.Text == "") return;
                MD5 md5 = MD5.Create();
                byte[] h = md5.ComputeHash(Encoding.UTF8.GetBytes(this.PassTxt.Text));
                string sb = BitConverter.ToString(h);
                if (sb != Values.UserInfo.StaffPassMD5) 
                    { HelpTxt.Visibility = Visibility.Visible; HelpTxt.Text = "如果你不知道密码，只能重新启动程序了！"; return; }
                else { Close(); Delegates.MaxWindow(); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        DispatcherTimer dt;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.DataContext = Values.SurfaceSetting.Surface;
                BG.DataContext = Values.SurfaceSetting.BgImage;
                Grid_.DataContext = Values.SurfaceSetting.Surface;
                #region 计时器
                dt = new DispatcherTimer();
                dt.Interval = new TimeSpan(0, 0, 0, 1);
                dt.Tick += dt_Tick2; dt.Start();
                #endregion
            }
            catch { }
        }
        void dt_Tick2(object sender, EventArgs e)
        {
            try
            {
                this.Date.Text = Other_Function.GetDateString();
                this.Time.Text = Other_Function.GetTimeString();
            }
            catch { }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void Hyperlink_MouseDown(object sender, RoutedEventArgs e)
        {
            Delegates.CloseWindow(); Close();
        }

        private void PassTxt_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                if (PassTxt.Text == "在这儿输入密码解锁") { PassTxt.Text = ""; }
            }
            catch { }
        }

        private void PassTxt_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                if (PassTxt.Text == "") { PassTxt.Text = "在这儿输入密码解锁"; }
            }
            catch { }
        }

    }
}
