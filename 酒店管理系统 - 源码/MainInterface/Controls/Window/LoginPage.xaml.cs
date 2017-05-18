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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TModel;


namespace Project_Term2
{
    /// <summary>
    /// Lock.xaml 的交互逻辑
    /// </summary>
    public partial class LoginPage : Window
    {
        DispatcherTimer dt;
        public LoginPage()
        {
            InitializeComponent();
            if (Delegates.HideWindow != null)
            {
                Delegates.HideWindow();
            }
            try
            {
                dt = new DispatcherTimer(); dt.Interval = new TimeSpan(0, 0, 0, 4);
                dt.Tick += dt_Tick;
                this.DataContext = Values.SurfaceSetting.Surface;
                Grid_.DataContext = Values.SurfaceSetting;
            }
            catch { }
        }

        /// <summary>
        /// 界面元素改变定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dt_Tick(object sender, EventArgs e)
        {
            try
            {
                WelcomeText.Visibility = Visibility.Collapsed;
                WelcomeText.Visibility = Visibility.Collapsed;
                TitleText.Visibility = Visibility.Visible;
                dt.Interval = new TimeSpan(0, 0, 0, 1);
                dt.Tick -= dt_Tick; dt.Tick += dt_Tick2;
                DateTimePanel.Visibility = Visibility.Visible;
            }
            catch { }
        }

        /// <summary>
        /// 时钟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dt_Tick2(object sender, EventArgs e)
        {
            try
            {
                this.Date.Text = Other_Function.GetDateString();
                this.Time.Text = Other_Function.GetTimeString();
            }
            catch { }
        }

        /// <summary>
        /// 窗口关闭时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (Delegates.MaxWindow != null) { Delegates.MaxWindow(); }
                else e.Cancel = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void UserLogin_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //如果非空
                if (this.UserName.Text.Length > 0 && this.UserPass.Password.Length > 0)
                {
                    //以开发者身份登陆
                    if (UserName.Text == "Develop" && UserPass.Password == "DevelopLogin")
                    {
                        try
                        {
                            MD5 md5 = MD5.Create();
                            View_UserInfo UI = new View_UserInfo() 
                            {
                                ALevelName = "开发者",
                                ALevelID = 0,
                                StaffName = "开发调试员",
                                StaffID = "Develop",
                                StaffImage = new BitmapImage(new Uri("酒店管理系统-主程序;component/Controls/Image/ICON0/笑脸.png", UriKind.Relative)),
                                StaffPassMD5 = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes("DevelopLogin")))
                            };
                            Delegates.LoginInfo(UI); Values.UserInfo = UI;
                        }
                        catch (Exception ex) { MessageBox.Show("开发者身份登录失败！"+ex.Message); }
                        this.Close();
                    }
                    else
                    {
                        try
                        {
                            string text = UserName.Text; string password = UserPass.Password;
                            View_UserInfo TS = new View_UserInfo();
                            LoginError.Text = "正在连接数据库，请稍等...";
                            LoginError.Visibility = Visibility.Visible;
                            await Task.Run(() =>
                            {
                                try
                                {
                                    TS = DLL_BLL.LoginBLL.UserLogin(text, password);
                                    this.Dispatcher.Invoke(() =>
                                    {
                                        TS.StaffImage = Project_Term2_BaseData.Other.GetImage(TS.ImageBytes);
                                        Delegates.LoginInfo(TS); Values.UserInfo = TS;
                                        this.Close();
                                    });
                                }
                                catch (Exception ex) { this.Dispatcher.Invoke(()=>LoginError.Text=ex.Message); }
                            });
                        }
                        catch (Exception ex)
                        {
                            LoginError.Text = ex.Message;
                            LoginError.Visibility = Visibility.Visible;
                        }
                    }
                }
                else 
                {
                    LoginError.Text = "密码和用户名不能为空，如果你设置了空密码，请联系管理员修改！";
                    LoginError.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            GetText(); dt.Start(); 
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) { UserLogin_Click(null,null); }
        }

        #region 游客身份
        /// <summary>
        /// 游客身份进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hyperlink_MouseDown(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #endregion

        private void textChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                LoginError.Visibility = Visibility.Collapsed;
            }
            catch { }
        }

        private void textChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                LoginError.Visibility = Visibility.Collapsed;
            }
            catch { }
        }
    }
}
