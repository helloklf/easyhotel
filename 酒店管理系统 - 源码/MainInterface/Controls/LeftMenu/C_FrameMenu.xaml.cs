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
using System.Windows.Threading;

namespace Project_Term2.LeftMenu
{
    /// <summary>
    /// C_LeftMenu.xaml 的交互逻辑
    /// </summary>
    public partial class C_FrameMenu : UserControl
    {
        public C_FrameMenu()
        {
            InitializeComponent();
            DispatcherTimer tm = new DispatcherTimer(); tm.Interval = TimeSpan.FromSeconds(5);
            tm.Tick += (object sender0, EventArgs a) => { DateTime_TB.Text = DateTime.Now.ToString("HH:mm:ss"); };
            tm.Start();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.C.DataContext = Values.SurfaceSetting.Surface;
        }


        /// <summary>
        /// 左侧导航菜单:结束程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowClose(object sender, MouseButtonEventArgs e)
        {
            if(Delegates.CloseWindow!=null) Delegates.CloseWindow();
        }

        /// <summary>
        /// 左侧导航菜单：锁定程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Appliction_Lock(object sender, MouseButtonEventArgs e)
        {
            LockPage lp = new LockPage(); this.Visibility = Visibility.Collapsed;
            lp.ShowDialog();
        }

        #region 工具栏
        /// <summary>
        /// 左侧导航菜单：工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Top_ToolBarState_Click(object sender, MouseButtonEventArgs e)
        {
              if(Delegates.ToolBarState!=null)  Delegates.ToolBarState();
        }
        #endregion

        #region 显示、隐藏
        /// <summary>
        /// 主菜单左侧导航栏关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenu_Left_Size(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.LeftMenuState != null) Delegates.LeftMenuState();
            Functions.ShowMessage(Other.InfoText.HelpInfo_HotKey, "快捷键说明");
            
        }
        #endregion

        #region 状态栏
        /// <summary>
        /// 左侧导航菜单：状态栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StateBarState_Click(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.StateBarState != null) Delegates.StateBarState();
        }
        #endregion

        /// <summary>
        /// 窗口风格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppWindowStyle_Click(object sender, MouseButtonEventArgs e)
        {
            bool b= Values.SurfaceSetting.Surface.Overallview;
            if (b) 
            {
                Values.SurfaceSetting.Surface.Overallview = false;
                Functions.ShowMessage("已切换为经典窗口模式,需在设置中保存才会永久生效！", "操作完成:");
            }
            else 
            {
                Values.SurfaceSetting.Surface.Overallview = true;
                Functions.ShowMessage("已切换为沉浸模式,需在设置中保存才会永久生效！", "操作完成:");
            }
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppSetting_Click(object sender, MouseButtonEventArgs e)
        {
            Values.PageStates.Setting = Values.PageStates.Setting == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        /// <summary>
        /// 弹出世间消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowDateTime_Click(object sender, MouseButtonEventArgs e)
        {
            Functions.ShowMessage(Other_Function.GetDateString()+"\n\t　"+ DateTime.Now.ToString("HH:mm:ss"),"当前时间");
        }


        private void Go_ToMainMenu(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.ToPageIndex != null) Delegates.ToPageIndex(0);
        }




    }
}
