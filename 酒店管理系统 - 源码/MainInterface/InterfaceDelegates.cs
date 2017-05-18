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

namespace Project_Term2
{
    public partial class StartWindow : Window
    {

        #region 委托

        #region 委托创建
        /// <summary>
        /// 初始化委托
        /// </summary>
        private void DelegateCreate()
        {
            Delegates.CloseWindow = new NotParameter(()=>Close());//窗口关闭
            Delegates.MinWindow = new NotParameter(() => WindowState = WindowState.Minimized);//窗口最小化
            Delegates.MaxWindow = new NotParameter(MaxWindow);//窗口最大化
            Delegates.ToolBarState = new NotParameter(ToolBarState);//切换工具栏显示
            Delegates.StateBarState = new NotParameter(StateBarState);//切换状态栏显示
            Delegates.HideWindow = new NotParameter( ()=>this.Visibility = Visibility.Collapsed); //隐藏窗口
            
            //添加控件到主页面
            Delegates.MenuChildren_ = new ChildrenAdd((C)
            => {
                 MainMenuList.Items.Add(C);
            });

            //跳转到指定页面
            Delegates.ToPageIndex = new IntParameter((go) =>
            {
                this.MainMenuList.SelectedIndex = go;
            });

            //跳转到指定页面（名称）
            Delegates.ToPageName = new StringParmeter ((go) =>
            {
                MainMenuList.SelectedItem = mainmenu;
                MainMenuList.SelectedIndex = 0;
                foreach (var item in MainMenuList.Items)
                {
                    if ((item as TabItem).Name == go) {MainMenuList.SelectedItem = item; break;}
                }
            });

            //主窗口用户登录状态显示支持
            Delegates.LoginInfo += new UserLogin((UI) =>
            {
                this.WindowTitle.Text = "在线:" + UI.StaffName;
                this.Title ="用户："+ UI.StaffName;
                Functions.ShowMessage(UI.ALevelName.ToString(),"当前权限");
            });

            //主窗口用户离线状态显示支持
            Delegates.UserOff_Line += new NotParameter(() => { this.WindowTitle.Text = "未登录"; 
                MainMenuList.SelectedIndex = 0;
            });

            //转到基础数据操作页面
            Delegates.BaseData.ToSetPage = new IntParameter((i) => 
            {
                if (Delegates.BaseData.Test())
                {
                    MainMenuList.SelectedIndex = 6;
                    Project_Term2_BaseData.BaseDataDelegates.ToPage(i);
                }
            });
            
            //结算按钮
            Project_Term2_BaseData.BaseDataDelegates.MainDelegate += new Project_Term2_BaseData.NotParameter(DbSettleAccounts);//自动结算
            Project_Term2_BaseData.BaseDataDelegates.ReturnToMainMenu = new Project_Term2_BaseData.NotParameter(() => MainMenuList.SelectedIndex=0 );

            //隐藏设置面板
            DllSettingPanel.Delegates.ClosePage += new DllSettingPanel.VOID(() => { Values.PageStates.Setting = Visibility.Collapsed; });
        }
        #endregion

        #region 窗口最大化
        /// <summary>
        /// 寄予委托的窗体最大化方法
        /// </summary>
        private void MaxWindow()
        {
            this.Visibility = Visibility.Visible;
            this.WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }
        #endregion

        #region 工具栏显示切换
        /// <summary>
        /// 工具栏显示状态切换方法
        /// </summary>
        private void ToolBarState()
        {
            Top_ToolBar.Visibility = Top_ToolBar.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
        #endregion

        #region 状态栏显示切换
        /// <summary>
        /// 状态栏显示状态切换方法
        /// </summary>
        private void StateBarState()
        {
            BottomStateBar.Visibility = BottomStateBar.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
        #endregion

        #endregion


    }
}
