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
using System.Data.SqlClient;
using Project_Term2_BaseData.Pages;

namespace Project_Term2_BaseData
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class PageManage : UserControl
    {
        public PageManage()
        {
            InitializeComponent();
            try
            {
                Delegates.V += () => { Tab.SelectedIndex = 4; ToPage(); };
                BaseDataDelegates.ToPage = new IntParameter((i) => { this.Tab.SelectedIndex = i; ToPage(); });
            }
            catch { MessageBox.Show("基础数据中心页面发生错误！");  }
        }

        private void To1(object sender, RoutedEventArgs e)
        {
            Tab.SelectedIndex = 1; ToPage(); PageTitle.Text = "基础数据-" + "证件类型";
        }

        private void To2(object sender, RoutedEventArgs e)
        {
            Tab.SelectedIndex = 2; ToPage(); PageTitle.Text = "基础数据-" + "国家列表";
        }

        private void To3(object sender, RoutedEventArgs e)
        {
            Tab.SelectedIndex = 3; ToPage(); PageTitle.Text = "基础数据-" + "VIP分级";
        }

        private void To4(object sender, RoutedEventArgs e)
        {
            Tab.SelectedIndex = 4; ToPage(); PageTitle.Text = "基础数据-" + "授权级别";
        }

        private void To5(object sender, RoutedEventArgs e)
        {
            Tab.SelectedIndex = 5; ToPage(); PageTitle.Text = "基础数据-" + "房间类型";
        }

        private void To6(object sender, RoutedEventArgs e)
        {
            Tab.SelectedIndex = 6; ToPage(); PageTitle.Text = "基础数据-" + "房间状态";
        }

        private void To7(object sender, RoutedEventArgs e)
        {
            Tab.SelectedIndex = 7; ToPage(); PageTitle.Text = "基础数据-" + "操作类型";
        }

        //private void To8(object sender, RoutedEventArgs e)
        //{
        //    Tab.SelectedIndex = 8; ToPage(); PageTitle.Text = "基础数据-" + "供应商类型";
        //}

        //private void To9(object sender, RoutedEventArgs e)
        //{
        //    Tab.SelectedIndex = 9; ToPage(); PageTitle.Text = "基础数据-" + "商品种类";
        //}

        //private void To10(object sender, RoutedEventArgs e)
        //{
        //    Tab.SelectedIndex = 10; ToPage(); PageTitle.Text = "基础数据-" + "计量单位";
        //}

        private void To11(object sender, RoutedEventArgs e)
        {
            Tab.SelectedIndex = 11; ToPage(); PageTitle.Text = "基础数据-" + "职务类型";
        }

        private void To0(object sender, MouseButtonEventArgs e)
        {
            Tab.SelectedIndex = 0; ToPage(); PageTitle.Text = "基础数据-" + "功能说明";
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.C.DataContext = Values.SurfaceSetting.Surface;
        }

        /// <summary>
        /// 开关右侧面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightPanelSet(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (LeftMenu.Visibility != Visibility.Collapsed)
                {
                    ToPage();
                }
                else { ReturnMenu(); }
            }
            catch { }
        }

        /// <summary>
        /// 回到主菜单按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnMenu(object sender, MouseButtonEventArgs e)
        {
            ReturnMenu();
        }

        /// <summary>
        /// 回到主菜单
        /// </summary>
        public void ReturnMenu() 
        {
            try
            {
                DockPanel.SetDock(Left_Right, Dock.Right);
                Left_Right.BorderThickness = new Thickness(0, 0, 2, 0);
                LeftMenu.Visibility = Visibility.Visible;
                RightMenu.Visibility = Visibility.Collapsed;
            }
            catch { }
        }

        /// <summary>
        /// 显示子页面 
        /// </summary>
        public void ToPage() 
        {
            try
            {
                DockPanel.SetDock(Left_Right, Dock.Left);
                Left_Right.BorderThickness = new Thickness(2, 0, 0, 0);
                LeftMenu.Visibility = Visibility.Collapsed;
                RightMenu.Visibility = Visibility.Visible;
            }
            catch { }
        }

        /// <summary>
        /// 返回到系统主界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnTo_MainMenu(object sender, MouseButtonEventArgs e)
        {
            if (BaseDataDelegates.ReturnToMainMenu != null) BaseDataDelegates.ReturnToMainMenu();
        }

    }
}
