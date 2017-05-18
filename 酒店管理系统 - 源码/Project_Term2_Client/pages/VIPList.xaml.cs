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

namespace Project_Term2_Client
{
    /// <summary>
    /// VIPList.xaml 的交互逻辑
    /// </summary>
    public partial class VIPList : UserControl
    {
        public VIPList()
        {
            InitializeComponent();
            Project_Term2_BaseData.BaseDataDelegates.MainDelegate += new Project_Term2_BaseData.NotParameter(() => LoadData());
        }

        private void RightPanelSet(object sender, MouseButtonEventArgs e)
        {
            RightPanel.Visibility = RightPanel.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.C.DataContext = Project_Term2_BaseData.Values.SurfaceSetting.Surface;//外观关联
            LoadData();
        }

        List<TModel.T_VIPInfo> VIP = new List<TModel.T_VIPInfo>();
        /// <summary>
        /// 数据初始化
        /// </summary>
        public async void LoadData() 
        {
            try
            {
                bool b = IsCheck.IsChecked == true ? false : true;
                await Task.Run(() =>
                {
                    try
                    {
                        VIP = DLL_BLL.VIPListBLL.Getdata(b);
                    }
                    catch (Exception ex) { this.Dispatcher.Invoke(()=>Inform.Functions.ShowMessage(ex.Message,"VIP数据读取出错")); }
                });
                this.LB.DataContext = VIP;
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message,"VIP管理页面");}
        }


        private void SelectedItemEnabled(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (LB.SelectedValue != null)
                {
                    string id = (string)LB.SelectedValue; bool b = false;
                    try
                    {
                        b = DLL_BLL.VIPListBLL.ItemEnabled(id, true);
                    }
                    catch (Exception ex) { this.Dispatcher.Invoke(() => Inform.Functions.ShowMessage(ex.Message,"恢复VIP错误")); }
                    if (b) { Inform.Functions.ShowMessage("恢复一个VIP号，操作已保存生效！", "恢复VIP操作"); LoadData(); }
                }
            }
            catch (Exception ex) { this.Dispatcher.Invoke(()=>Inform.Functions.ShowMessage(ex.Message,"禁用VIP出错" )); }
        }

        private async void SelectedItemEnabledNo(object sender, MouseButtonEventArgs e)
        {
            if (LB.SelectedValue != null)
            {
                string id = (string)LB.SelectedValue; bool b = false;
                await Task.Run(() =>
                {
                    try
                    {
                        b = DLL_BLL.VIPListBLL.ItemEnabled(id, false);
                    }
                    catch (Exception ex) { this.Dispatcher.Invoke(() => Inform.Functions.ShowMessage(ex.Message, "禁用VIP出错")); }
                });
                if (b) { Inform.Functions.ShowMessage("禁用一个VIP号，操作已保存生效！", "禁用VIP操作"); LoadData(); }
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// 添加VIP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (InText.Text.Length < 1)
                {
                    return;
                }
                bool b = false;
                await Task.Run(() => 
                {
                    try { b=DLL_BLL.VIPListBLL.Insert(InText.Text); }
                    catch (Exception ex) { this.Dispatcher.Invoke(() => Inform.Functions.ShowMessage(ex.Message, "新增VIP出错")); }
                });
                if(b) LoadData();
            }
            catch (Exception ex) { MessageBox.Show("VIP管理页面：" + ex.Message); }
        }
    }
}
