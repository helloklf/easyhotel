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
using MyControls;

namespace Project_Term2_BaseData.Pages
{
    /// <summary>
    /// RoomType.xaml 的交互逻辑
    /// </summary>
    public partial class RoomStateType : UserControl
    {
        public RoomStateType()
        {
            InitializeComponent();
            try
            {
                ColorSet();
                BaseDataDelegates.MainDelegate += new NotParameter(() => LoadDataList());
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "房间状态类型页");}
        }
        /// <summary>
        /// 数据集
        /// </summary>
        List<T_RoomStateType> TP = new List<T_RoomStateType>();
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataList(); this.C.DataContext = Values.SurfaceSetting.Surface;
        }

        #region 新增
        /// <summary>
        /// 提交新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {

                string text = InText.Text;
                string color = InColor.Background.ToString();
                string remark = InRemark.Text;
                bool b = false; await Task.Run(() =>
                {
                    try { b = DLL_BLL.RoomStateTypeBLL.Insert(text, color, remark); }
                    catch (Exception ex) { this.Dispatcher.Invoke(() => { Inform.Functions.ShowMessage(ex.Message, "房间状态类型页"); }); }
                });
                if (b)
                { Inform.Functions.ShowMessage("新增一项房间状态类型记录，已成功保存！", "操作成功"); LoadDataList(); InText.Text = ""; }
            }
            catch (Exception ex){ Inform.Functions.ShowMessage(ex.Message, "房间状态类型页"); }
        }
        #endregion

        #region 查询
        /// <summary>
        /// 禁用项显示切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            LoadDataList();
        }

        /// <summary>
        /// 读取数据列表
        /// </summary>
        public async void LoadDataList()
        {
            try
            {
                bool b = (bool)IsCheck.IsChecked ? false : true;
                await Task.Run(() =>
                {
                    try { TP = DLL_BLL.RoomStateTypeBLL.DataLoad(b); }
                    catch (Exception ex) { this.Dispatcher.Invoke(() => { Inform.Functions.ShowMessage(ex.Message, "房间状态类型页"); }); }
                });
                LB.ItemsSource = TP;
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "房间状态类型页"); }
        }
        #endregion

        #region 启用和禁用
        /// <summary>
        /// 启用选择项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SelectedItemEnabled(object sender, MouseButtonEventArgs e)
        {
            if (LB.SelectedItem == null) return;
            try
            {
                int SI = (int)LB.SelectedValue; bool b = false;
                await Task.Run(() =>
                {
                    try { b = RoomStateTypeBLL.EnableItem(true, SI); }
                    catch (Exception ex) { this.Dispatcher.Invoke(() => { Inform.Functions.ShowMessage(ex.Message, "房间状态类型页"); }); }
                });
                if (b) { Inform.Functions.ShowMessage("恢复一项房间状态类型记录，已成功保存！", "操作成功"); LoadDataList(); }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "房间状态类型页"); }
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
                int SI = (int)LB.SelectedValue; bool b = false;
                await Task.Run(() =>
                {
                    try { b = RoomStateTypeBLL.EnableItem(false, SI); }
                    catch (Exception ex) { this.Dispatcher.Invoke(() => { Inform.Functions.ShowMessage(ex.Message, "房间状态类型页"); }); }
                });
                if (b) { Inform.Functions.ShowMessage("禁用一项房间状态类型记录，已成功保存！", "操作成功"); LoadDataList(); }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "房间状态类型页"); }
        }
        #endregion

        #region 修改

        T_RoomStateType select = new T_RoomStateType();
        /// <summary>
        /// 双击列表中的项修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditItem(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (LB.SelectedItem != null)
                {
                    select = LB.SelectedItem as T_RoomStateType;
                    if (select != null)
                    {
                        Tab.SelectedIndex = 1;
                        UpText.Text = select.StateName;
                        UpColor.Background = select.StateColorBrush;
                        UpRemark.Text = select.StateRemark;
                        LB.IsEnabled = false; Tab.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "房间状态类型页"); }
        }
        /// <summary>
        /// 提交修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string text = UpText.Text;
                string color=UpColor.Background.ToString();
                string remark= UpRemark.Text;
                bool b = false; await Task.Run(() =>
                {
                    try { b = DLL_BLL.RoomStateTypeBLL.Update(text, color, remark, select); }
                    catch (Exception ex) { this.Dispatcher.Invoke(() => { Inform.Functions.ShowMessage(ex.Message, "房间状态类型页"); }); }
                });
                if (b)
                {
                    Inform.Functions.ShowMessage("修改一项房间状态类型记录，已成功保存！", "操作成功");
                    LoadDataList(); LB.IsEnabled = true; Tab.SelectedIndex = 0; Tab.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "房间状态类型页");}
        }

        /// <summary>
        /// 返回列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnList(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (UpText.Text != select.StateName || select.StateRemark.ToString() != UpRemark.Text)
                {
                    UpText.Text = select.StateName;
                    UpRemark.Text = select.StateRemark;
                }
                else
                {
                    LB.IsEnabled = true;
                    Tab.SelectedIndex = 0; Tab.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "房间状态类型页"); }
        }
        #endregion

        private void SelectColor(object sender, RoutedEventArgs e)
        {
            try
            {
                Button but = sender as Button;
                InColor.Background = but.Background;
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "房间状态类型页"); }
        }
        private void UpdateColor(object sender, RoutedEventArgs e)
        {
            try
            {
                Button but = sender as Button;
                UpColor.Background = but.Background;
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "房间状态类型页"); }
        }


        public void ColorSet() 
        {
            try
            {
                foreach (Button item in InColorPanel.Children)
                {
                    item.Click += SelectColor;
                }
                foreach (Button item in InColorPanel2.Children)
                {
                    item.Click += SelectColor;
                }
                foreach (Button item in UpColorPanel2.Children)
                {
                    item.Click += UpdateColor;
                }
                foreach (Button item in UpColorPanel.Children)
                {
                    item.Click += UpdateColor;
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "房间状态类型页"); }
        }

        private void RightPanelSet(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (Tab.Visibility == Visibility.Visible)
                {
                    Tab.Visibility = Visibility.Collapsed; LB.IsEnabled = true;
                }
                else
                {
                    Tab.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "房间状态类型页"); }
        }

        private void AddItem(object sender, MouseButtonEventArgs e)
        {
            Tab.Visibility = Visibility.Visible;
            Tab.SelectedIndex = 0;
        }

        private void LB_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            try
            {
                if (LB.SelectedItem != null)
                {
                    T_RoomStateType ta = LB.SelectedItem as T_RoomStateType;
                    if (ta.IsValid) { LB.MenuItem_Emable.Visibility = Visibility.Collapsed; LB.MenuItem_Forbidden.Visibility = Visibility.Visible; }
                    else { LB.MenuItem_Emable.Visibility = Visibility.Visible; LB.MenuItem_Forbidden.Visibility = Visibility.Collapsed; }
                }
            }
            catch { }
        }
    }
}
