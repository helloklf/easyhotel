﻿using System;
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

namespace Project_Term2_Staff
{
    /// <summary>
    /// StaffData.xaml 的交互逻辑
    /// </summary>
    public partial class PageManage : UserControl
    {
        public PageManage()
        {
            InitializeComponent();
            Delegates.TabChangeReturn = () => { Tab.SelectedIndex = 2; ToPage(); PageTitle.Text = "员工管理-查看员工"; };
            Delegates.TabAdd = () => { Tab.SelectedIndex = 1; PageTitle.Text = "员工管理-添加员工"; };
        }
        private void To0(object sender, RoutedEventArgs e)
        {
            Tab.SelectedIndex = 0; ToPage(); PageTitle.Text = "员工管理-功能说明"; 
        }
        private void To1(object sender, RoutedEventArgs e)
        {
            Tab.SelectedIndex = 1; ToPage(); PageTitle.Text = "员工管理-添加员工"; 
        }
        private void To2(object sender, RoutedEventArgs e)
        {
            Tab.SelectedIndex = 2; ToPage(); PageTitle.Text = "员工管理-查看员工"; 
        }
        private void To3(object sender, RoutedEventArgs e)
        {
            Tab.SelectedIndex = 3; ToPage(); PageTitle.Text = "员工管理-在职员工"; 
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.C.DataContext = Values.SurfaceSetting.Surface;
            }
            catch (Exception ex) { MessageBox.Show("员工管理模块："+ex.Message); }
        }

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

        private void ReturnTo_MainMenu(object sender, MouseButtonEventArgs e)
        {
            if (Project_Term2_BaseData.BaseDataDelegates.ReturnToMainMenu != null)
                Project_Term2_BaseData.BaseDataDelegates.ReturnToMainMenu();
        }

        private void ReturnMenu(object sender, MouseButtonEventArgs e)
        {
            ReturnMenu();
        }
    }
}
