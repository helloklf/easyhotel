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
using TModel;

namespace Project_Term2_Client
{
    /// <summary>
    /// ClientList.xaml 的交互逻辑
    /// </summary>
    public partial class ClientList : UserControl
    {
        public ClientList()
        {
            InitializeComponent();
            Project_Term2_BaseData.BaseDataDelegates.MainDelegate += new Project_Term2_BaseData.NotParameter(() => LoadData());
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.C.DataContext = Project_Term2_BaseData.Values.SurfaceSetting.Surface;
                LoadData(); 
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "客户管理中心错误"); }
        }

        List<T_ClientInfo> CL = new List<T_ClientInfo>();
        public async void LoadData()
        {
            try
            {
                await Task.Run(()=>
                {
                    try
                    {
                        CL = DLL_BLL.ClientListBLL.LoadData();
                    }
                    catch (Exception ex) { this.Dispatcher.Invoke(() => Inform.Functions.ShowMessage(ex.Message,"客管中心数据加载")); }
                });
                this.LB.DataContext =CL;
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "客户管理中心错误"); }
        }

        private void RightPanelSet(object sender, MouseButtonEventArgs e)
        {
            try
            {
                RightPanel.Visibility = RightPanel.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message,"客管中心控件操作"); }
        }

        T_ClientInfo Select = new T_ClientInfo();


        List<T_PaperType> TP = new List<T_PaperType>();
        /// <summary>
        /// 双击列表中的项-显示在修改页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                RightPanel.Visibility = Visibility.Visible;
                if (LB.SelectedItem != null) Select = LB.SelectedItem as T_ClientInfo;
                this.InText.Text = Select.ClientIName;
                if (Select.ClientSex) Sex1.IsChecked = true; else Sex0.IsChecked = true;
                this.InAdress.Text = Select.ClientAdress;
                this.InCardID.Text = Select.ClientIDCard;

                await Task.Run(() =>
                {
                    try
                    {
                        TP = DLL_BLL.PapersTypeBLL.DataLoad(true);
                    }
                    catch (Exception ex) { this.Dispatcher.Invoke(() => Inform.Functions.ShowMessage(ex.Message,"客观中心数据操作")); };
                });
                
                this.InPapers.DataContext = TP;
                InPapers.Text = Select.PapersName;
                this.InVIPID.Text = Select.ClientVIPID;
                this.InTel.Text = Select.ClientTel;
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message,"客观中心控件操作"); }
        }

        private async void yes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Select.ClientIName = this.InText.Text;
                Select.ClientSex=Sex1.IsChecked==true?true:false;
                Select.ClientAdress = this.InAdress.Text;
                Select.ClientIDCard = this.InCardID.Text;
                Select.PapersID = (int)InPapers.SelectedValue;
                Select.ClientVIPID = this.InVIPID.Text;
                Select.ClientTel = this.InTel.Text;

                bool b = false;
                await Task.Run(() => 
                {
                    try
                    {
                        b = DLL_BLL.ClientListBLL.Update(Select);
                    }
                    catch (Exception ex) { this.Dispatcher.Invoke(() => Inform.Functions.ShowMessage(ex.Message,"客管中心数据操作")); }
                });
                if (b) 
                {
                    Inform.Functions.ShowMessage("更新一名客户个人档案，保存成功！","客户档案修改");
                    this.RightPanel.Visibility = Visibility.Collapsed; LoadData();
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message,"客管中心未知异常"); }
        }

        private void AddItem(object sender, MouseButtonEventArgs e)
        {
            RightPanel.Visibility = Visibility.Visible;
        }
    }
}
