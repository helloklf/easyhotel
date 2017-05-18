using DLL_BLL;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
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

namespace Project_Term2_RoomList
{
    /// <summary>
    /// StaffAdd.xaml 的交互逻辑
    /// </summary>
    public partial class RoomAdd : UserControl
    {
        public RoomAdd()
        {
            InitializeComponent();
            Project_Term2_BaseData.BaseDataDelegates.MainDelegate += new Project_Term2_BaseData.NotParameter(() => LoadDataList());
        }

        /// <summary>
        /// 数据集
        /// </summary>
        List<T_StaffInfo> TP = new List<T_StaffInfo>();
        List<T_AccreditType> TA = new List<T_AccreditType>();
        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.C.DataContext = Project_Term2_BaseData.Values.SurfaceSetting.Surface; 
                LoadDataList();
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "管理-房间查询加载"); }
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
                if (InTypeID.SelectedValue != null && InStateID.SelectedValue != null && InText.Text.Length > 0)
                {
                    T_RoomList TR = new T_RoomList() { RoomID = InText.Text, RoomType = Convert.ToInt32(InTypeID.SelectedValue), RoomState = Convert.ToInt32(InStateID.SelectedValue), RoomRemark = this.InRemark.Text };
                    bool b = false;
                    await Task.Run(() =>
                    {
                        try
                        {
                            b = RoomListBLL.Insert(TR);
                        }
                        catch (Exception ex) { this.Dispatcher.Invoke(() => Inform.Functions.ShowMessage(ex.Message, "管理-房间添加")); }
                    });
                    if (b)
                    {
                        Inform.Functions.ShowMessage("成功添加一条记录，房号" + InText.Text, "新增成功");
                        this.InText.Text = "";
                    }
                }
                else
                {
                    Inform.Functions.ShowMessage("请检查是否存在未填的必填项！","未填项目");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        #endregion

        #region 查询
        

        /// <summary>
        /// 读取数据列表
        /// </summary>
        public async void LoadDataList()
        {
            try
            {
                List<T_RoomType> RT = new List<T_RoomType>();
                List<T_RoomStateType> ST = new List<T_RoomStateType>();
                await Task.Run(() =>
                {
                    try
                    {
                        RT = DLL_BLL.RoomTypeBLL.DataLoad(true);
                        ST = DLL_BLL.RoomStateTypeBLL.DataLoad(true);
                    }
                    catch (Exception ex)
                    {
                        this.Dispatcher.Invoke(() => Inform.Functions.ShowMessage(ex.Message, "管理-新增房间_数据初始化"));
                    }
                });
                InTypeID.ItemsSource = RT; 
                InStateID.ItemsSource = ST;
                InTypeID.SelectedIndex = 0;
                InStateID.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Inform.Functions.ShowMessage(ex.Message, "管理-新增房间_数据初始化");
            }
        }
        #endregion

        private void selectImage(object sender, MouseButtonEventArgs e)
        {
            string uri = Project_Term2_BaseData.WFormIO.SelectImage();
            if (uri == null) return;
            else
            {
                
            }
        }

        private void To3(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Delegates.TabChangeReturn != null) Delegates.TabChangeReturn();
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message,"增加房间-页面切换"); }
        }

    }
}
