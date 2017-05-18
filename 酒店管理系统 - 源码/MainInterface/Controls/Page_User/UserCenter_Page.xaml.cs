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
using TModel;

namespace Project_Term2.UserPage
{
    /// <summary>
    /// UserCenter_Page.xaml 的交互逻辑
    /// </summary>
    public partial class UserCenter_Page : UserControl
    {
        public UserCenter_Page()
        {
            InitializeComponent(); 
            this.DataContext = BGSET;
            //用户中心登录支持
            Delegates.LoginInfo += new UserLogin((UI) => { Menu_Userlogin.Content = "注　销"; Tab.SelectedIndex = 0; });
            //用户中心离线支持
            Delegates.UserOff_Line += new NotParameter(() => { Values.UserInfo = null; Menu_Userlogin.Content = "登　陆"; Tab.SelectedIndex = 2; Menu_Userlogin.Focus(); });
            //消息支持
            Delegates.ToMessagePage += () => { this.Tab.SelectedIndex = 1; Menu_Message.IsChecked = true; };
        }

        DllSetting.AppSurface BGSET = Values.SurfaceSetting.Surface;

        #region 关闭
        private void Close_MiniPage_Content(object sender, RoutedEventArgs e)
        {
            Values.PageStates.UserCenter = Visibility.Collapsed; CloseBut.IsChecked = false;          
        }
        #endregion

        #region 加载完毕
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region 重置用户名和密码
        private void ReSetText(object sender, MouseButtonEventArgs e)
        {
            UserLogin_Pass.Password = "";
            User_Login_UName.Text = "";
        }
        #endregion

        #region 高级授权
        private void User_AdvPass(object sender, MouseButtonEventArgs e)
        {
            string p = this.User_AdvPassWord.Text;
        }
        #endregion

        #region 用户页


        #region 登陆
        /// <summary>
        /// 用户登录数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_GoLogin(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //如果非空
                if (this.User_Login_UName.Text.Length > 0 && this.UserLogin_Pass.Password.Length > 0)
                {
                    //以开发者身份登陆
                    if (User_Login_UName.Text == "Develop" && UserLogin_Pass.Password == "DevelopLogin")
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
                        catch (Exception ex) { MessageBox.Show("开发者身份登录失败！" + ex.Message); }
                    }
                    else
                    {
                        try
                        {
                            string text = User_Login_UName.Text; string password = UserLogin_Pass.Password;
                            View_UserInfo TS = new View_UserInfo();
                            Functions.ShowMessage("正在连接数据库，稍后显示结果...","请稍等");
                            await Task.Run(() =>
                            {
                                try
                                {
                                    TS = DLL_BLL.LoginBLL.UserLogin(text, password);
                                    this.Dispatcher.Invoke(() =>
                                    {
                                        TS.StaffImage = Project_Term2_BaseData.Other.GetImage(TS.ImageBytes);
                                        Delegates.LoginInfo(TS); Values.UserInfo = TS;
                                    });
                                }
                                catch (Exception ex) { this.Dispatcher.Invoke(() => Functions.ShowMessage(ex.Message,"发生异常")); }
                            });
                        }
                        catch (Exception ex)
                        {
                            Functions.ShowMessage(ex.Message,"发生异常");
                        }
                    }
                }
                else
                {
                    Functions.ShowMessage("密码和用户名不能为空，如果你设置了空密码，请联系管理员修改！", "输入无效");
                }
            }
            catch (Exception ex)
            {
                Functions.ShowMessage(ex.Message, "出现错误");
            }
        }
        #endregion

            #region 页面切换
            /// <summary>
            /// 用户中心页面切换
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void UserPage_TabSelect(object sender, RoutedEventArgs e)
            {
                
            }
            #endregion

            private void TabTo0(object sender, RoutedEventArgs e)
            {
                Tab.SelectedIndex = 0;
            }
            private void TabTo1(object sender, RoutedEventArgs e)
            {
                Tab.SelectedIndex = 1;
            }

            private void TabTo2(object sender, RoutedEventArgs e)
            {
                if (Menu_Userlogin.Content.ToString() == "注　销")//如果功能显示为此文本，表示用户已经登陆
                {
                    if (Functions.Show_Question(Other.InfoText.ExitLogionQuestion, "确定此操作?") == true)
                    {
                        if (Delegates.UserOff_Line != null)
                        {
                            Delegates.UserOff_Line();
                        }
                        else new Exception("注销失败，由于授权处理模块尚未完善，此功能暂时无法使用。");
                    }
                    else { Menu_Userlogin.IsChecked = false; Tab.SelectedIndex = 0; Menu_UserInfo.IsChecked = true; }
                }
                else { Tab.SelectedIndex = 2;  }
            }

            private void TabTo3(object sender, RoutedEventArgs e)
            {
                Tab.SelectedIndex = 3; 
            }

        #endregion

        /// <summary>
        /// 关于安全授权
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutThis(object sender, MouseButtonEventArgs e)
        {
            Functions.ShowMessage(Other.InfoText.AboutSecurity,"关于安全授权");
        }

        private void TabTo4(object sender, RoutedEventArgs e)
        {
            Tab.SelectedIndex = 4;
        }


    }
}
