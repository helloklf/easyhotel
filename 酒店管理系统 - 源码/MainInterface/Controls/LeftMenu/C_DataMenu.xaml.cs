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

namespace Project_Term2.LeftMenu
{
    /// <summary>
    /// C_LeftMenu2.xaml 的交互逻辑
    /// </summary>
    public partial class C_DataMenu : UserControl
    {
        public C_DataMenu()
        {
            InitializeComponent();
            Delegates.LoginInfo += new UserLogin(LoginTest);
            Delegates.UserOff_Line += new NotParameter(UserLogOff);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.C.DataContext = Values.SurfaceSetting.Surface;
        }


        /// <summary>
        /// 用户登录时
        /// </summary>
        /// <param name="ui"></param>
        public void LoginTest(TModel.View_UserInfo ui)
        {
            if (ui != null && ui.ALevelName != null)
            {
                if (ui.ALevelName == "开发者" || ui.ALevelName == "超级管理员")
                {
                    SuperAdminiItem.Visibility = Visibility.Visible; 
                    AdministratorItem.Visibility = Visibility.Visible;
                    AdvAdminiItem.Visibility = Visibility.Visible;
                }
                else if (ui.ALevelName == "高级管理员")
                {
                    SuperAdminiItem.Visibility = Visibility.Collapsed;
                    AdvAdminiItem.Visibility = Visibility.Visible;
                    AdministratorItem.Visibility = Visibility.Visible;
                }
                else if (ui.ALevelName == "管理员")
                {
                    SuperAdminiItem.Visibility = Visibility.Collapsed;
                    AdvAdminiItem.Visibility = Visibility.Collapsed;
                    AdministratorItem.Visibility = Visibility.Visible;
                }
                else
                {
                    UserLogOff();
                }
            }
        }

        /// <summary>
        /// 用户离线
        /// </summary>
        public void UserLogOff()
        {
            SuperAdminiItem.Visibility = Visibility.Collapsed;
            AdvAdminiItem.Visibility = Visibility.Collapsed;
            AdministratorItem.Visibility = Visibility.Collapsed;
        }


        /// <summary>
        /// 去开房
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientInRoom_Click(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.RoomData.Test())
            {
                if (Delegates.RoomData.ClientIn != null && Delegates.ToPageIndex != null)
                {
                    Delegates.ToPageIndex(1); Delegates.RoomData.ClientIn();
                }
            }
        }

        /// <summary>
        /// 去退房
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientExitRoom_Click(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.RoomData.Test())
            {
                if (Delegates.RoomData.ExitRoom != null && Delegates.ToPageIndex != null)
                { Delegates.ToPageIndex(1); Delegates.RoomData.ExitRoom(); }
            }
        }

        /// <summary>
        /// 去交钱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientMoney_Click(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.RoomData.Test())
            {
                if (Delegates.RoomData.AddMoney != null && Delegates.ToPageIndex != null) 
                { Delegates.ToPageIndex(1); Delegates.RoomData.AddMoney(); }
            }
        }

        /// <summary>
        /// 预订房
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientBook_Click(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.RoomData.Test())
            {
                if (Delegates.RoomData.RoomBook != null && Delegates.ToPageIndex != null) 
                {
                    Delegates.ToPageIndex(1); Delegates.RoomData.RoomBook();
                }
            }
        }
        
        /// <summary>
        /// 显示所有房间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientAllRoom_Click(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.RoomData.Test())
            {
                if (Delegates.RoomData.AllRoom != null && Delegates.ToPageIndex != null)
                { Delegates.ToPageIndex(1); Delegates.RoomData.AllRoom(); }
            }
        }

        /// <summary>
        /// 基础数据操作页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseDataSet_Click(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.BaseData.Test())//测试权限等级是否足够
            {
                Delegates.ToPageIndex(6);
            }
        }

        /// <summary>
        /// 员工管理界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StaffList_Click(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.StaffData.Test())
            {
                Delegates.ToPageIndex(4);
            }
        }

        /// <summary>
        /// 客户管理界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientList_Click(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.ClientData.Test())
            {
                Delegates.ToPageIndex(3);
            }
        }

        /// <summary>
        /// 房间管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoomList_Click(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.RoomData.Test())
            {
                Delegates.ToPageIndex(5);
            }
        }

        /// <summary>
        /// 主菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenu_Clcik(object sender, MouseButtonEventArgs e)
        {
            Delegates.ToPageIndex(0);
        }

    }
}
