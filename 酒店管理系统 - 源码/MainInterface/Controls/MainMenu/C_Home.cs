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
using System.Windows.Threading;

namespace Project_Term2.MainMenu
{
    /// <summary>
    /// P_MainMenu0.xaml 的交互逻辑
    /// </summary>
    public partial class C_Home : UserControl
    {

        public C_Home()
        {
            InitializeComponent();
            DispatcherTimer time2 = new DispatcherTimer(); time2.Start();
            time2.Interval = new TimeSpan(0,5, 0); time2.Tick += time2_Tick;//定时刷新数据
            MCount.DataContext = UserPage.ApplcitionMessage.list;//消息数量显示
            Delegates.LoginInfo += new UserLogin(UserLogin);//用户登录功能支持
            Delegates.UserOff_Line += new NotParameter(LogOff);//用户注销支持
        }

        /// <summary>
        /// 窗口加载完毕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.C.DataContext = Values.SurfaceSetting.Surface;
            RoomStateLoad();
            Functions.ShowMessage("状态监视小磁贴每5分钟自动刷新一次，如果你要手动刷新数据，请点击工具栏上的刷新按钮！", "状态板块");
        }

        /// <summary>
        /// 用户登陆功能支持
        /// </summary>
        /// <param name="ui"></param>
        public void UserLogin(TModel.View_UserInfo ui)
        {
            if (ui != null && ui.ALevelName != null)
            {
                if (ui.ALevelName == "超级管理员"||ui.ALevelName=="开发者") 
                {
                    //BasicPanel.Visibility = Visibility.Visible;//基本功能
                    RoomTranPanel.Visibility = Visibility.Visible;//房间事务
                    StaffTranPanel.Visibility = Visibility.Visible;//员工管理事务
                    ClientTran.Visibility = Visibility.Visible;//客户管理事务
                    BDTran.Visibility = Visibility.Visible;//基础数据事务
                    //ForthwithInfoPanel.Visibility = Visibility.Visible;//即时信息
                    //QuickLinkPanel.Visibility = Visibility.Visible;//快捷方式
                }
                else if (ui.ALevelName == "高级管理员")
                {
                    //BasicPanel.Visibility = Visibility.Collapsed;//基本功能
                    RoomTranPanel.Visibility = Visibility.Visible;//房间事务
                    StaffTranPanel.Visibility = Visibility.Visible;//员工管理事务
                    ClientTran.Visibility = Visibility.Visible;//客户管理事务
                    BDTran.Visibility = Visibility.Collapsed;//基础数据事务
                }
                else if (ui.ALevelName == "管理员")
                {
                    //BasicPanel.Visibility = Visibility.Collapsed;//基本功能
                    RoomTranPanel.Visibility = Visibility.Visible;//房间事务
                    StaffTranPanel.Visibility = Visibility.Collapsed;//员工管理事务
                    ClientTran.Visibility = Visibility.Visible;//客户管理事务
                    BDTran.Visibility = Visibility.Collapsed;//基础数据事务
                }
                else 
                {
                    LogOff();
                }
            }
        }

        /// <summary>
        /// 用户注销功能支持
        /// </summary>
        public void LogOff()
        {
            ClientTran.Visibility = Visibility.Collapsed;//客户管理事务
            BDTranPanel.Visibility = Visibility.Collapsed;//基础数据
            StaffTranPanel.Visibility = Visibility.Collapsed;//员工管理
            RoomTranPanel.Visibility = Visibility.Collapsed;//房间管理
            //BasicPanel.Visibility = Visibility.Visible;//基本功能模块
            //ForthwithInfoPanel.Visibility = Visibility.Visible;//即时信息
            //QuickLinkPanel.Visibility = Visibility.Visible;//快捷方式
        }


        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        void time2_Tick(object sender, EventArgs e)
        {
            RoomStateLoad();//重新读取数据
        }

        #region 显示页面切换：显示项-隐藏项
        /// <summary>
        /// 显示页面切换：显示项-隐藏项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabChange_Click(object sender, RoutedEventArgs e)
        {
            Tab.SelectedIndex = (bool)IsCkecked_Hide.IsChecked ? 1 : 0;
        }
        #endregion


        #region 房间事务

        #region 转到所有房间页面
        /// <summary>
        /// 转到所有房间页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoomSelect_Click(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.RoomData.Test())
            {
                if (Delegates.ToPageIndex != null && Delegates.RoomData.AllRoom != null)
                {
                    Delegates.ToPageIndex(1);
                    Delegates.RoomData.AllRoom();
                }
            }
        }
        #endregion

        #region 转到缴费页面
        /// <summary>
        /// 转到缴费页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Go_Client_Pay(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.RoomData.Test())
            {
                if (Delegates.RoomData.AddMoney != null && Delegates.ToPageIndex != null)
                { Delegates.ToPageIndex(1); Delegates.RoomData.AddMoney(); }
            }
        }
        #endregion

        #region 转到客户退房页面
        /// <summary>
        /// 转到退房页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Go_ClientExit(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.RoomData.Test())
            {
                if (Delegates.RoomData.AddMoney != null && Delegates.ToPageIndex != null)
                {Delegates.RoomData.AddMoney(); Delegates.ToPageIndex(1);  }
            }
        }
        #endregion

        #region 转到客户入住页面
        /// <summary>
        /// 客户入住
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Go_ClientIn(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.RoomData.Test())
            {
                if (Delegates.RoomData.ClientIn != null && Delegates.ToPageIndex != null)
                {
                    Delegates.ToPageIndex(1); Delegates.RoomData.ClientIn();
                }
            }
        }
        #endregion
        
        #endregion

        #region  板块隐藏-展开

        #region 基本功能栏目显示切换
        /// <summary>
        /// 基本功能栏目显示切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BasicPanel_Click(object sender, MouseButtonEventArgs e)
        {
            BasicFun.Visibility = BasicFun.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
        #endregion

        #region 即时信息功能栏目显示切换
        /// <summary>
        /// 即时信息功能栏目显示切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TilePanel_Click(object sender, MouseButtonEventArgs e)
        {
            ForthwithInfo.Visibility = ForthwithInfo.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }
        #endregion

        #region 快捷方式栏目显示切换
        /// <summary>
        /// 快捷方式栏目显示切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuickPanel_Click(object sender, MouseButtonEventArgs e)
        {
            Tab_2.Visibility = Tab_2.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }
        #endregion

        #region 系统功能模块收缩切换
        /// <summary>
        /// 系统功能模块收缩切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SysFunPanel_Click(object sender, MouseButtonEventArgs e)
        {
            SysFun.Visibility = SysFun.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
        #endregion

        #region 房间事务快捷方式收缩切换
        /// <summary>
        /// 房间事务快捷方式收缩切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StaffPanel_Click(object sender, MouseButtonEventArgs e)
        {
            StaffTran.Visibility = StaffTran.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
        #endregion

        #region 基础数据事务快捷方式收缩切换
        /// <summary>
        /// 基础数据事务快捷方式收缩切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BDTranPanel_Click(object sender, MouseButtonEventArgs e)
        {
            BDTran.Visibility = BDTran.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
        #endregion

        #endregion
    }
}
