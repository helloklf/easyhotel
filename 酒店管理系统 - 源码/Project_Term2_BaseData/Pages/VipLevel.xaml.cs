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
using DLL_BLL;
using MyControls;

namespace Project_Term2_BaseData.Pages
{
    /// <summary>
    /// VipLevel.xaml 的交互逻辑
    /// </summary>
    public partial class VipLevel : UserControl
    {
        public VipLevel()
        {
            InitializeComponent();
            try
            {
                BaseDataDelegates.MainDelegate += new NotParameter(() => LoadDataList());//创建刷新页面委托方法
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "VIP等级划分"); }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox tb = sender as TextBox;
                Convert.ToInt32(tb.Text);
                VIPintegralError.Visibility = Visibility.Collapsed;
            }
            catch
            {
                VIPintegralError.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// 数据集
        /// </summary>
        List<T_VIPLevel> TP = new List<T_VIPLevel>();
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataList();
            this.C.DataContext = Values.SurfaceSetting.Surface;
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
                string text = InText.Text; string integral = InIntegral.Text; string DisCount = InDisCount.Text;
                bool b = false;
                await Task.Run(() => 
                {
                    try
                    {
                        b = DLL_BLL.VIPLevelBLL.Insert(text, integral, DisCount);
                    }
                    catch (Exception ex) { this.Dispatcher.Invoke(() => { Inform.Functions.ShowMessage(ex.Message, "VIP等级划分"); }); }
                });
                if (b)
                {
                    Inform.Functions.ShowMessage("新增一项VIP等级记录，已成功保存！", "操作成功"); LoadDataList(); InText.Text = "";
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "VIP等级划分"); }
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
                    try
                    {
                        TP = DLL_BLL.VIPLevelBLL.DataLoad(b);
                    }
                    catch (Exception ex) { this.Dispatcher.Invoke(() => { Inform.Functions.ShowMessage(ex.Message, "VIP等级划分"); }); }
                });
                LB.ItemsSource = TP;
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "VIP等级划分"); }
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
                    try
                    {
                        b = VIPLevelBLL.EnableItem(true, SI);
                    }
                    catch (Exception ex) { this.Dispatcher.Invoke(() => { Inform.Functions.ShowMessage(ex.Message, "VIP等级划分"); }); }
                });
                if (b)
                {
                    LoadDataList();
                    Inform.Functions.ShowMessage("恢复一项VIP等级记录，已成功保存！", "操作成功");
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "VIP等级划分"); }
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
                    try
                    {
                        b = VIPLevelBLL.EnableItem(false, SI);
                    }
                    catch (Exception ex) { this.Dispatcher.Invoke(() => { Inform.Functions.ShowMessage(ex.Message, "VIP等级划分"); }); }
                });
                if (b)
                {
                    LoadDataList();
                    Inform.Functions.ShowMessage("禁用一项VIP等级记录，已成功保存！", "操作成功");
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "VIP等级划分"); }
        }
        #endregion

        #region 修改

        T_VIPLevel select = new T_VIPLevel();
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
                    select = LB.SelectedItem as T_VIPLevel;
                    if (select != null)
                    {
                        Tab.SelectedIndex = 1;
                        UpText.Text = select.LevelName;
                        UpIntegral.Text = select.LevelIntegral.ToString();
                        UpDisCount.Text = select.VipDiscount.ToString();
                        LB.IsEnabled = false; Tab.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "VIP等级划分"); }
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
                string text = UpText.Text; string integral = UpIntegral.Text; string DisCount = UpDisCount.Text;
                bool b = false;
                await Task.Run(() =>
                {
                    try
                    {
                        b = DLL_BLL.VIPLevelBLL.Update(text, integral, DisCount,select);
                    }
                    catch (Exception ex) {this.Dispatcher.Invoke(() => { Inform.Functions.ShowMessage(ex.Message, "VIP等级划分"); }); }
                });
                if (b)
                {
                    Inform.Functions.ShowMessage("修改一项VIP等级记录，已成功保存！", "操作成功");
                    LoadDataList(); LB.IsEnabled = true; Tab.SelectedIndex = 0; Tab.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "VIP等级划分"); }
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
                if (UpText.Text != select.LevelName || select.LevelIntegral.ToString() != UpIntegral.Text || select.VipDiscount.ToString() != UpDisCount.Text)
                {
                    UpText.Text = select.LevelName;
                    UpIntegral.Text = select.LevelIntegral.ToString();
                    UpDisCount.Text = select.VipDiscount.ToString();
                }
                else
                {
                    LB.IsEnabled = true;
                    Tab.SelectedIndex = 0; Tab.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "VIP等级划分"); }
        }
        #endregion

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
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "VIP等级划分"); }
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
                    T_VIPLevel ta = LB.SelectedItem as T_VIPLevel;
                    if (ta.IsValid) { LB.MenuItem_Emable.Visibility = Visibility.Collapsed; LB.MenuItem_Forbidden.Visibility = Visibility.Visible; }
                    else { LB.MenuItem_Emable.Visibility = Visibility.Visible; LB.MenuItem_Forbidden.Visibility = Visibility.Collapsed; }
                }
            }
            catch { }
        }

    }
}
