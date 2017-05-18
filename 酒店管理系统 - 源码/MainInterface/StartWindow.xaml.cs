using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Configuration;
using System.Windows.Threading;

using System.Runtime.InteropServices;
using TModel;

namespace Project_Term2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StartWindow : Window
    {
        /// <summary>
        /// 窗体构建时
        /// </summary>
        public StartWindow()
        {
            InitializeComponent();

            #region 原始方法
            TabItem t = new TabItem(); t.Name = "roomlist";
            t.Content = new DataView.RoomList();
            MainMenuList.Items.Add(t);

            TabItem t2 = new TabItem(); t2.Name = "datagrid1";
            t2.Content = new DataView.DataGrid1();
            MainMenuList.Items.Add(t2);

            TabItem t3 = new TabItem(); t3.Name = "clientmanage";
            t3.Content = new Project_Term2_Client.PageManage();
            MainMenuList.Items.Add(t3);


            TabItem t4 = new TabItem(); t4.Name = "staffmanage";
            t4.Content = new Project_Term2_Staff.PageManage();
            MainMenuList.Items.Add(t4);


            TabItem t5 = new TabItem(); t5.Name = "roommanage";
            t5.Content = new Project_Term2_RoomList.PageManage();
            MainMenuList.Items.Add(t5);

            TabItem t6 = new TabItem(); t6.Name = "basedatamanage";
            t6.Content = new Project_Term2_BaseData.PageManage();
            MainMenuList.Items.Add(t6);

            #endregion

            //显示登陆页
            LoginPage l = new LoginPage(); l.Show();

        }



        DllSetting.AppSurface SET = Values.SurfaceSetting.Surface;

        /// <summary>
        /// 窗口加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Visibility = Visibility.Collapsed;
                ThemeSetting();//外观初始化
                #region 其它可延迟加载的操作
                await Task.Run(() => DelegateCreate());//委托初始化
                #endregion
                #region 数据库自动结算、取消失效预订功能
                DispatcherTimer time = new DispatcherTimer();
                time.Interval = new TimeSpan(0, 5, 0); time.Start();
                time.Tick += (a, b) => { DbSettleAccounts(); };
                #endregion 
                MessageWindow.Show();//启动消息系统
                Inform.Delegates.AddChildren_("全局消息系统正式提供使用，所有提示消息都可以该形式弹出！", "新本功能");
            }
            catch { MessageBox.Show("在应用程序启动时发生不可预料的错误！"); }
        }

        /// <summary>
        /// 消息系统-消息窗口
        /// </summary>
        Inform.MessageWindow MessageWindow = new Inform.MessageWindow();

        /// <summary>
        /// 自动结算
        /// </summary>
        public async void DbSettleAccounts() 
        {
            try
            {
                bool b = false;
                await Task.Run(() => 
                {
                    try
                    {
                        b = DLL_BLL.AutoRunProcBLL.Proc_AutoSettleAccounts();
                    }
                    catch (Exception ex) { Functions.ShowMessage(ex.Message,"自动结算错误"); }
                });
                if (b)
                {
                    List<View_ClientRoomState> list = DLL_BLL.AutoRunProcBLL.Proc_AccountRemind();
                    foreach (var item in list)
                    {
                        Functions.ShowMessageAndToList("房间“" + item.RoomID + "”客户 " + item.ClientName + "的账户已欠费 " + item.ClientAccount + "元。请及时处理！", "数据库通知", true);
                    }
                }
                //查询失效预订
                await Task.Run(() =>
                {
                    try
                    {
                        List<T_BookRoom> TB = DLL_BLL.AutoRunProcBLL.Proc_AutoDeleteBook();
                        foreach (var item in TB)
                        {
                            Functions.ShowMessageAndToList("客户"+item.ClientName+"预订的房间"+item.RoomID+"超出预定有效期"+item.BookValidTime+"天。系统已自动清除该预订信息！","预订失效", false);
                        }
                    }
                    catch (Exception ex) { Functions.ShowMessage(ex.Message, "自动结算错误"); }
                });
                Functions.ShowMessage("自动结算程序执行(扣除客户住房费用和清理过期预订)。执行时间:"+DateTime.Now.ToShortTimeString(),"自动结算");

            }
            catch (Exception ex)
            {
                Functions.ShowMessage(ex.Message, "出现错误");
            }
        }

        #region 主题加载
        /// <summary>
        /// 主题加载
        /// </summary>
        public void ThemeSetting()
        {
            Page_Setting_Content.DataContext = Values.PageStates;//关联页面显示状态
            Page_UserPage_Content.DataContext = Values.PageStates;//关联页面显示状态
            Grid_.DataContext = Values.SurfaceSetting;//背景图像绑定
            C.DataContext = SET;//外观色彩的绑定
        }
        #endregion

        #region 快捷键
        /// <summary>
        /// 按键按下事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2) { if (Delegates.LeftMenuState != null) Delegates.LeftMenuState(); }
            else if (e.Key == Key.F3) { Top_ToolBar.Visibility = Top_ToolBar.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible; }
            else if (e.Key == Key.F4) { BottomStateBar.Visibility = BottomStateBar.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible; }
            else if (e.Key == Key.F11) { WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized; }
        }
        #endregion
    }
}
