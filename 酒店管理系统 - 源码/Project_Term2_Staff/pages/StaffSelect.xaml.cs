using DLL_BLL;
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

namespace Project_Term2_Staff
{
    /// <summary>
    /// StaffSelect.xaml 的交互逻辑
    /// </summary>
    public partial class StaffSelect : UserControl
    {
        public StaffSelect()
        {
            InitializeComponent();
            Project_Term2_BaseData.BaseDataDelegates.MainDelegate += new Project_Term2_BaseData.NotParameter(() => LoadDataList());
            Project_Term2_BaseData.BaseDataDelegates.MainDelegate += new Project_Term2_BaseData.NotParameter(() => LoadData());
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataList();
            LoadData(); this.C.DataContext = Values.SurfaceSetting.Surface;
        }

        /// <summary>
        /// 禁用项显示切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            LoadDataList();
        }

        public async void LoadDataList() 
        {
            try
            {
                bool b = (bool)this.IsCheck.IsChecked ? false : true;
                List<T_StaffInfo> ts = new List<T_StaffInfo>();
                await Task.Run(() =>
                {
                    try
                    {
                        ts = DLL_BLL.StaffBLL.GetData(b);
                    }
                    catch (Exception ex) { this.Dispatcher.Invoke(()=>Inform.Functions.ShowMessage(ex.Message, "员工信息-数据加载")); }
                });
                foreach (var item in ts)
                {
                    try
                    {
                        item.StaffImage = Project_Term2_BaseData.Other.GetImage(item.ImageBytes);
                    }
                    catch { }
                }
                this.LB.DataContext = ts;
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "员工信息-数据加载"); }
        }

        /// <summary>
        /// 禁用选择项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SelectedItemEnabledNo(object sender, MouseButtonEventArgs e)
        {
            if (LB.SelectedItem == null) return;
            try
            {
                if (new Inform.W_Question("如果你禁用该条记录，则所有与之关联的在职员工信息都将会被移除，确定？","确定禁用？").ShowDialog()==true)
                {
                    string SI = (string)LB.SelectedValue;
                    bool b = false;
                    await Task.Run(()=>
                    {
                        try
                        {
                            b = StaffBLL.EnableItem(false, SI);
                        }
                        catch (Exception ex) 
                        {
                            this.Dispatcher.Invoke(() =>
                            {
                                Inform.Functions.ShowMessage(ex.Message, "员工信息-禁用员工信息");
                            });
                        }
                    });
                    if (b) LoadDataList();
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "员工信息-禁用员工信息"); }
        }

        T_StaffInfo select = new T_StaffInfo();
        /// <summary>
        /// 双击列表中的项修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (LB.SelectedItem != null)
                {
                    select = LB.SelectedItem as T_StaffInfo;
                    if (select != null)
                    {
                        LoadFromClass(select); RightPanel.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "员工管理-页面跳转"); }
        }

        private async void SelectedItemEnabled(object sender, MouseButtonEventArgs e)
        {
            if (LB.SelectedItem == null) return;
            try
            {
                string SI = (string)LB.SelectedValue; 
                bool b = false;
                await Task.Run(() =>
                {
                    try
                    {
                        b = StaffBLL.EnableItem(true, SI);
                    }
                    catch (Exception ex) { this.Dispatcher.Invoke(() => Inform.Functions.ShowMessage(ex.Message, "员工管理-恢复员工")); }
                });
                if (b) LoadDataList();
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "员工管理-恢复员工"); }       
        }

        private void LB_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            LB_MouseDoubleClick(null,null);
        }

        private void SelectedItemEnabled(object sender, RoutedEventArgs e)
        {
            SelectedItemEnabled(null,null);
        }

        private void SelectedItemEnabledNo(object sender, RoutedEventArgs e)
        {
            SelectedItemEnabledNo(null,null);
        }

        private void AddItem(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.TabAdd != null) Delegates.TabAdd();
        }

        /// <summary>
        /// 显示-隐藏右侧面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightPanelSet(object sender, MouseButtonEventArgs e)
        {
            if (RightPanel.Visibility == Visibility.Visible)
            {
                RightPanel.Visibility = Visibility.Collapsed; LB.IsEnabled = true;
            }
            else
            {
                RightPanel.Visibility = Visibility.Visible;
            }
        }


        T_StaffInfo Select = new T_StaffInfo();

        public void LoadFromClass(T_StaffInfo select)
        {
            try
            {
                Select = select; InGUID.Text = select.StaffID ;
                this.InText.Text = select.StaffName;
                this.Sex1.IsChecked = select.StaffSex;
                this.InInTime.Text = select.StaffInDate.ToShortDateString();
                InCardID.Text = select.StaffIdCard;
                if (select.StaffImage != null) InHeader.Source = select.StaffImage;
                InTel.Text = select.StaffTel;
                InCouID.SelectedValue = select.StaffCouID;
                InAdress.Text = select.StaffAdress;
                Inform.Functions.ShowMessage("该页面暂不支持修改撤销，点击‘x’按钮以后将直接取消修改。由此给您带来不便，请谅解...","功能提示");
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "员工信息更新-解析实体"); }
        }

        public async void LoadData()
        {
            List<T_CountryInfo> TA = new List<T_CountryInfo>();
            await Task.Run(() =>
            {
                try
                {
                    TA = DLL_BLL.CountryInfoBLL.DataLoad(true);
                }
                catch (Exception ex)
                {
                    this.Dispatcher.Invoke(() => { Inform.Functions.ShowMessage(ex.Message, "员工更新-读取国家列表"); });
                }
            });
            this.InCouID.ItemsSource = TA;
        }


        /// <summary>
        /// 数据集
        /// </summary>
        List<T_StaffInfo> TP = new List<T_StaffInfo>();
        List<T_AccreditType> TA = new List<T_AccreditType>();


        #region 修改
        /// <summary>
        /// 提交修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (InCardID.Text.Length != 18 || InText.Text.Length < 2) { Inform.Functions.ShowMessage("姓名至少两个字，且身份证号为18位！","输入无效"); return; }
                else
                {
                    T_StaffInfo ts = new T_StaffInfo();
                    ts.StaffID = Select.StaffID; ts.StaffName = this.InText.Text;
                    ts.StaffSex = (bool)this.Sex1.IsChecked ? true : false; ts.StaffIdCard = this.InCardID.Text;
                    ts.StaffInDate = DateTime.Parse(this.InInTime.Text);
                    if (this.InCouID.SelectedValue != null) ts.StaffCouID = (int)InCouID.SelectedValue;
                    ts.StaffAdress = InAdress.Text; ts.StaffTel = this.InTel.Text;
                    string uri = InHeader.Tag as string;
                    bool b = false;
                    await Task.Run(() =>
                    {
                        try
                        {
                            b = StaffBLL.Update(ts, uri);
                        }
                        catch (Exception ex) { this.Dispatcher.Invoke(()=> Inform.Functions.ShowMessage("员工信息修改-保存修改：" + ex.Message)); }
                    });
                    if (b)
                    {
                        Inform.Functions.ShowMessage("已成功修改员工"+select.StaffID+"的个人档案","修改已保存");
                        ReturnList(null, null);
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        #endregion

        /// <summary>
        /// 选择头像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectImage(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string uri = Project_Term2_BaseData.WFormIO.SelectImage();
                if (uri == null) return;
                else
                {
                    InHeader.Source = new BitmapImage(new Uri(uri));
                    InHeader.Tag = uri;
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "员工修改-选择头像"); }
        }

        /// <summary>
        /// 关闭修改页面，返回列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnList(object sender, MouseButtonEventArgs e)
        {
            try
            {
                InGUID.Text = "";
                this.InCardID.Text = ""; this.InTel.Text = ""; this.InText.Text = "";
                this.InHeader.Tag = null; RightPanel.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "员工修改-页面导航"); }
        }


        /// <summary>
        /// 右键菜单打开前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LB_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (LB.SelectedItem != null)
            {
                if (IsCheck.IsChecked == true)
                {
                    ForbiddenItem.Visibility = Visibility.Collapsed; EnableItem.Visibility = Visibility.Visible;
                }
                else 
                {
                    ForbiddenItem.Visibility = Visibility.Visible; EnableItem.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
