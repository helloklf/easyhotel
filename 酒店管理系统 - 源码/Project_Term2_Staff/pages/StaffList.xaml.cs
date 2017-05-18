using DLL_BLL;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// StaffListxaml.xaml 的交互逻辑
    /// </summary>
    public partial class StaffList : UserControl
    {
        public StaffList()
        {
            InitializeComponent();
            Project_Term2_BaseData.BaseDataDelegates.MainDelegate += new Project_Term2_BaseData.NotParameter(() => LoadDataList());
        }

        /// <summary>
        /// 窗口打开时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.C.DataContext = Values.SurfaceSetting.Surface;
                LoadDataList();
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "在职员工管理-页面加载"); }
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        public async void LoadDataList()
        {
            try
            {
                DataTable dt = null;
                await Task.Run(() =>
                {
                    try
                    {
                        dt = StaffBLL.GetStaffListData(true);
                    }
                    catch (Exception ex) { this.Dispatcher.Invoke(()=> Inform.Functions.ShowMessage(ex.Message, "在职员工管理-列表加载")); }
                });
                this.DATAGRIDVIEW.DataContext = dt;
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "在职员工管理-列表加载"); }
        }

        List<T_StaffType> StaffType = new List<T_StaffType>();

        /// <summary>
        /// 双击数据列表中的行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DATAGRIDVIEW_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (DATAGRIDVIEW.SelectedItem != null && DATAGRIDVIEW.SelectedIndex > -1)
                {
                    DataRowView drw = DATAGRIDVIEW.Items[DATAGRIDVIEW.SelectedIndex] as DataRowView;
                    string guid = (string)drw[0];
                    await Task.Run(() =>
                    {
                        try
                        {
                            StaffType = DLL_BLL.StaffTypeBLL.DataLoad(true);
                        }
                        catch (Exception ex) { this.Dispatcher.Invoke(()=>Inform.Functions.ShowMessage(ex.Message,"在职员工操作-职务类型加载")); }
                    });
                    Set(drw,guid);
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message,"在职员工操作"); }
        }

        /// <summary>
        /// 根据数据设置文本
        /// </summary>
        /// <param name="drw"></param>
        void Set(DataRowView drw,string guid)
        {
            if (drw[3].ToString().Length < 1)//添加
            {
                InPost.ItemsSource = StaffType;
                this.InGUID.Text = guid; Tab.Visibility = Visibility.Visible; Tab.SelectedIndex = 0;
            }
            else //更新
            {
                UpPost.ItemsSource = StaffType;
                this.UpGUID.Text = guid;
                UpPost.Text = drw[5].ToString();
                Tab.Visibility = Visibility.Visible; Tab.SelectedIndex = 1;
                this.UpText.Text = drw[3].ToString();
            }
        }


        /// <summary>
        /// 保存新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void yes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (InPost.SelectedValue == null) return;
                T_StaffList ts = new T_StaffList();
                ts.StaffGuid = this.InGUID.Text;
                ts.StaffID = InText.Text;
                ts.StaffPwdMD5 = InPass.Text;
                ts.STypeID = (int)InPost.SelectedValue;
                ts.StaffAccredit = InSu.Text;

                bool b = false;
                await Task.Run(() =>
                {
                    try
                    {
                        b = StaffBLL.Insert(ts);
                    }
                    catch (Exception ex) { this.Dispatcher.Invoke(()=>Inform.Functions.ShowMessage(ex.Message,"在职员工操作-新增工号")); }
                });
                if (b)
                {
                    InText.Text = ""; InPass.Text = ""; InSu.Text = "";
                    InGUID.Text = ""; 
                    LoadDataList();Tab.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message,"在职员工操作"); }
        }


        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void yes_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (UpPost.SelectedValue == null) { Inform.Functions.ShowMessage("职务类型为必填项，但是你没有选择一个有效的职务类型！","未填项目"); return; }
                else if (UpPass.Text.Length < 1) { Inform.Functions.ShowMessage("应用程序限制登陆时密码输入不能为空，因此设置一个密码为空的账户没有任何作用，请填写密码！", "密码为空"); return; }
                T_StaffList ts = new T_StaffList();
                ts.StaffGuid = this.UpGUID.Text;
                ts.StaffID = UpText.Text;
                ts.StaffPwdMD5 = UpPass.Text;
                ts.STypeID = (int)UpPost.SelectedValue;
                ts.StaffAccredit = UpSu.Text;
                bool b= false;
                await Task.Run(() => 
                {
                    try { b=StaffBLL.Update(ts); }
                    catch (Exception ex) { this.Dispatcher.Invoke(()=>Inform.Functions.ShowMessage(ex.Message, "在职员工操作-修改工号")); }
                });
                if (b)
                {
                    UpText.Text = ""; UpPass.Text = ""; UpSu.Text = "";
                    UpGUID.Text = "";
                    LoadDataList(); Tab.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "在职员工操作"); }
        }

        /// <summary>
        /// 显示、隐藏右侧面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightPanelSet(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (Tab.Visibility == Visibility.Visible)
                {
                    Tab.Visibility = Visibility.Collapsed;
                }
                else
                {
                    Tab.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "在职员工操作"); }
        }

        private void HideTab(object sender, MouseButtonEventArgs e)
        {
            Tab.Visibility = Visibility.Collapsed;
        }
    }
}
