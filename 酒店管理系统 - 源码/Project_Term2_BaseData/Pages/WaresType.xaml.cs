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
    /// WaresType.xaml 的交互逻辑
    /// </summary>
    public partial class WaresType : UserControl
    {
        public WaresType()
        {
            InitializeComponent();
            try
            {
                BaseDataDelegates.MainDelegate += new NotParameter(() => LoadDataList());//创建刷新页面委托方法
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "商品类型表"); }
        }

        /// <summary>
        /// 数据集
        /// </summary>
        List<T_WaresType> TP = new List<T_WaresType>();
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
                string im = WI.Tag as string; string text = InText.Text; string remark = InRemark.Text;
                bool b = false;
                await Task.Run(() => 
                {
                    try
                    {
                        b = DLL_BLL.WaresTypeBLL.Insert(text, im, remark);
                    }
                    catch (Exception ex) { this.Dispatcher.Invoke(() => { Inform.Functions.ShowMessage(ex.Message, "商品类型表"); }); }
                });
                if (b) { Inform.Functions.ShowMessage("新增一项商品类型记录，已成功保存！", "操作成功"); LoadDataList(); InText.Text = ""; }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "商品类型表"); }
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
                        TP = DLL_BLL.WaresTypeBLL.DataLoad(b);
                    }
                    catch (Exception ex) { this.Dispatcher.Invoke(() => { Inform.Functions.ShowMessage(ex.Message, "商品类型表"); }); }
                }); 
                LB.ItemsSource = TP;
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "商品类型表"); }
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
                        b=WaresTypeBLL.EnableItem(true, SI);
                    }
                    catch (Exception ex) { this.Dispatcher.Invoke(() => { Inform.Functions.ShowMessage(ex.Message, "商品类型表"); }); }
                });
                if (b) { Inform.Functions.ShowMessage("恢复一项商品类型记录，已成功保存！", "操作成功"); LoadDataList(); }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "商品类型表"); }
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
                        b = WaresTypeBLL.EnableItem(false, SI);
                    }
                    catch (Exception ex) { this.Dispatcher.Invoke(() => { Inform.Functions.ShowMessage(ex.Message, "商品类型表"); }); }
                });
                if (b) { Inform.Functions.ShowMessage("禁用一项商品类型记录，已成功保存！", "操作成功"); LoadDataList(); }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "商品类型表"); }
        }
        #endregion

        #region 修改

        bool isNew = false;
        T_WaresType select = new T_WaresType();
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
                    select = LB.SelectedItem as T_WaresType;
                    if (select != null)
                    {
                        Tab.SelectedIndex = 1;
                        UpText.Text = select.WaresName;
                        UpWI.Source = select.WaresImage;
                        UpRemark.Text = select.WaresRemark;
                        LB.IsEnabled = false; isNew = false; Tab.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "商品类型表"); }
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
                string im = UpWI.Tag as string; string text = UpText.Text; string remark = UpRemark.Text;
                bool b = false;
                await Task.Run(() =>
                {
                    try
                    {
                        b = DLL_BLL.WaresTypeBLL.Update(text, remark, im, isNew, select);
                    }
                    catch (Exception ex) { this.Dispatcher.Invoke(() => { Inform.Functions.ShowMessage(ex.Message, "商品类型表"); }); }
                });

                if (b)
                {
                    Inform.Functions.ShowMessage("修改一项商品类型记录，已成功保存！", "操作成功");
                    LoadDataList(); LB.IsEnabled = true; Tab.SelectedIndex = 0; Tab.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "商品类型表"); }
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
                if (UpText.Text != select.WaresName || select.WaresRemark.ToString() != UpRemark.Text || isNew)
                {
                    UpText.Text = select.WaresName;
                    UpRemark.Text = select.WaresRemark;
                    UpWI.Source = select.WaresImage; isNew = false;
                }
                else
                {
                    LB.IsEnabled = true;
                    Tab.SelectedIndex = 0;
                    isNew = false; Tab.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "商品类型表"); }
        }
        #endregion

        private void selectImage(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string uri = Project_Term2_BaseData.WFormIO.SelectImage();
                if (uri == null) return;
                else
                {
                    WI.Source = new BitmapImage(new Uri(uri));
                    WI.Tag = uri;
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "商品类型表");}
        }

        private void selectImage0(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string uri = Project_Term2_BaseData.WFormIO.SelectImage();
                if (uri == null) return;
                else
                {
                    UpWI.Source = new BitmapImage(new Uri(uri));
                    UpWI.Tag = uri;
                    isNew = true;
                }
            }
            catch (Exception ex) { MessageBox.Show("商品类型操作界面：" + ex.Message); }
        }

        private void RightPanelSet(object sender, MouseButtonEventArgs e)
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

        private void AddItem(object sender, MouseButtonEventArgs e)
        {
            Tab.Visibility = Visibility.Visible; Tab.SelectedIndex = 0;
        }

        private void LB_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            
        }
    }
}
