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
using System.Data;


namespace Project_Term2_RoomList
{
    /// <summary>
    /// RoomSelect.xaml 的交互逻辑
    /// </summary>
    public partial class RoomSelect : UserControl
    {
        public RoomSelect()
        {
            InitializeComponent();
            Project_Term2_BaseData.BaseDataDelegates.MainDelegate += new Project_Term2_BaseData.NotParameter(() => GetData());
            Project_Term2_BaseData.BaseDataDelegates.MainDelegate += new Project_Term2_BaseData.NotParameter(() => LoadDataList());
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.C.DataContext = Project_Term2_BaseData.Values.SurfaceSetting.Surface;
                GetData();LoadDataList();
            }
            catch (Exception ex) {Inform.Functions.ShowMessage(ex.Message,"管理-房间查询加载"); }
        }

        /// <summary>
        /// 禁用项显示切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            GetData();
        }

        DataTable TL;
        public async void GetData()
        {
            try
            {
                bool b = (bool)this.IsCheck.IsChecked;
                await Task.Run(() =>
                {
                    try
                    {
                        TL = DLL_BLL.RoomListBLL.GetTableAll(b);
                    }
                    catch (Exception ex) {this.Dispatcher.Invoke(()=>Inform.Functions.ShowMessage(ex.Message,"管理-房间数据读取")); }
                });
                this.LB.DataContext = TL;
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message,"管理-房间列表获取"); }
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
                string SI = (string)LB.SelectedValue; bool b = false;
                await Task.Run(() => 
                {
                    try { b= RoomListBLL.EnableItem(false, SI); }
                    catch (Exception ex) { this.Dispatcher.Invoke(()=>Inform.Functions.ShowMessage(ex.Message,"管理-房间操作")); }
                });
                if (b) GetData();
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message,"管理-房间操作"); }
        }

        T_RoomList select = new T_RoomList();

        /// <summary>
        /// 双击列表中的项修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (LB.SelectedItem != null)
                {
                    select = LB.SelectedItem as T_RoomList;
                    string s = LB.SelectedValue.ToString();
                    if (s != null)
                    {
                        T_RoomList RL = new T_RoomList();
                        await Task.Run(() =>
                        {
                            try
                            {
                                RL = RoomListBLL.GetRoom(s); this.Dispatcher.Invoke(()=> RightPanel.Visibility = Visibility.Visible);
                            }
                            catch (Exception ex) { this.Dispatcher.Invoke(() => Inform.Functions.ShowMessage(ex.Message,"房管-获得房间信息")); }
                        });
                        UpdateT_Room(RL);
                    }
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "管理-跳转页面"); }
        }

        /// <summary>
        /// 选择项恢复可用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SelectedItemEnabled(object sender, MouseButtonEventArgs e)
        {
            if (LB.SelectedItem == null) return;
            try
            {
                string SI = (string)LB.SelectedValue; bool b = false;
                await Task.Run(() =>
                {
                    try { b = RoomListBLL.EnableItem(true, SI); }
                    catch (Exception ex) { this.Dispatcher.Invoke(()=>Inform.Functions.ShowMessage(ex.Message,"管理-房间操作")); }
                });
                if (b) GetData();
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message,"管理-房间操作"); }
        }

        /// <summary>
        /// 点击添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddItem(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.TabChangeToAdd != null) Delegates.TabChangeToAdd();
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
                    MenuItem_Forbidden.Visibility = Visibility.Collapsed; MenuItem_EnableItem.Visibility = Visibility.Visible;
                }
                else
                {
                    MenuItem_Forbidden.Visibility = Visibility.Visible;MenuItem_EnableItem.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void RightPanelSet(object sender, MouseButtonEventArgs e)
        {
            try
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
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "授权类型操作界面"); }
        }


        T_RoomList TR = new T_RoomList();
        public void UpdateT_Room(T_RoomList tr)
        {
            try
            {
                TR = tr;
                this.InText.Text = TR.RoomID;
                string typename = ""; string statename="";
                foreach (var item in RT)
                {
                    if (item.TypeID == TR.RoomType) { typename = item.TypeName; break; }
                }
                foreach (var item in ST)
	            {
		            if(item.StateID==TR.RoomState){ statename=item.StateName;break; }
	            }
                this.InRemark.Text = TR.RoomRemark;
                this.InTypeID.Text = typename;//TR.RoomType;
                this.InStateID.Text = statename;
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message,"管理-房间修改参数接收"); }
        }

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
                if (InTypeID.SelectedValue != null && InStateID.SelectedValue != null && InText.Text.Length > 0)
                {
                    T_RoomList TR = new T_RoomList()
                    {
                        RoomID = InText.Text,
                        RoomType = Convert.ToInt32(InTypeID.SelectedValue),
                        RoomState = Convert.ToInt32(InStateID.SelectedValue),
                        RoomRemark = this.InRemark.Text
                    };
                    bool b = false;
                    await Task.Run(() =>
                    {
                        try
                        {
                            b = RoomListBLL.Update(TR);
                        }
                        catch (Exception ex) { this.Dispatcher.Invoke(() => Inform.Functions.ShowMessage(ex.Message, "管理-更新房间信息")); }
                    });
                    if (b)
                    {
                        Inform.Functions.ShowMessage("成功修改一个房间的信息！", "修改成功"); GetData(); RightPanel.Visibility = Visibility.Collapsed;
                    }
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message,"更新房间"); }
        }
        #endregion

        List<T_RoomType> RT = new List<T_RoomType>();
        List<T_RoomStateType> ST = new List<T_RoomStateType>();


        /// <summary>
        /// 读取数据列表
        /// </summary>
        public async void LoadDataList()
        {
            try
            {
                await Task.Run(() =>
                {
                    try
                    {
                        RT = DLL_BLL.RoomTypeBLL.DataLoad(true);
                        ST = DLL_BLL.RoomStateTypeBLL.DataLoad(true);
                    }
                    catch (Exception ex)
                    {
                        this.Dispatcher.Invoke(()=>Inform.Functions.ShowMessage(ex.Message,"管理-更新房间_数据初始化"));
                    }
                });
                InTypeID.ItemsSource = null; InStateID.ItemsSource = null;
                InTypeID.ItemsSource = RT;
                InStateID.ItemsSource = ST;
            }
            catch (Exception ex)
            {
                Inform.Functions.ShowMessage(ex.Message,"管理-更新房间_数据初始化");
            }
        }

        /// <summary>
        /// 返回到列表页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnList(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (InTypeID.SelectedValue.ToString() == TR.RoomType.ToString() && InStateID.SelectedValue.ToString() == TR.RoomState.ToString() && InText.Text == TR.RoomID.ToString() && InRemark.Text == TR.RoomRemark.ToString())
                {
                        InTypeID.SelectedValue = null; InStateID.SelectedValue = null;
                        InText.Text = ""; InRemark.Text = "";
                        RightPanel.Visibility = Visibility.Collapsed;
                }
                else
                {
                    this.InText.Text = TR.RoomID.ToString();
                    this.InRemark.Text = TR.RoomRemark.ToString();
                    this.InTypeID.SelectedValue = TR.RoomType;
                    this.InStateID.SelectedValue = TR.RoomState;
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message,"房间更新-页面导航"); }
        }

    }
}