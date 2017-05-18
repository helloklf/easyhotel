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

namespace Project_Term2_Staff
{
    /// <summary>
    /// StaffAdd.xaml 的交互逻辑
    /// </summary>
    public partial class StaffAdd : UserControl
    {
        public StaffAdd()
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
                if (InCardID.Text.Length !=18||InText.Text.Length<2) { MessageBox.Show("姓名至少两个字，且身份证号为18位！"); return; }
                else 
                {
                    T_StaffInfo ts = new T_StaffInfo();
                    ts.StaffName = this.InText.Text;
                    ts.StaffSex = (bool)this.Sex1.IsChecked ? true : false;
                    ts.StaffIdCard = this.InCardID.Text;
                    ts.StaffInDate = DateTime.Parse(this.InInTime.Text);
                    if (this.InCouID.SelectedValue != null)
                        ts.StaffCouID = (int)InCouID.SelectedValue;
                    ts.StaffAdress = InAdress.Text; 
                    ts.StaffTel = this.InTel.Text;
                    string uri = InHeader.Tag as string;
                    bool b = false;
                    await Task.Run(() => 
                    {
                        try { b = StaffBLL.Insert(ts, uri); }
                        catch (Exception ex) 
                        {
                           this.Dispatcher.Invoke(()=>Inform.Functions.ShowMessage(ex.Message,"员工管理-新增员工"));
                        }
                    });
                    if (b) 
                    {
                        Inform.Functions.ShowMessage("成功添加一名员工，姓名"+InText.Text,"操作完成！"); ResetText();
                    }
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "员工管理-新增员工"); }
        }
        #endregion


        public void ResetText()
        {
            try
            {
                this.InText.Text = "";
                this.InCardID.Text = "";
                this.InHeader.Tag = null;
                this.InInTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                this.InTel.Text = "";
                this.InAdress.Text = "";
            }
            catch (Exception ex) { MessageBox.Show("增加员工-控件操作："+ex.Message); }
        }

        #region 查询
        

        /// <summary>
        /// 读取数据列表
        /// </summary>
        public async void LoadDataList()
        {List<T_CountryInfo> TA = new List<T_CountryInfo>();
            await Task.Run(() => 
            {
                try
                {
                    //获得国家信息数据
                    TA= DLL_BLL.CountryInfoBLL.DataLoad(true);
                }
                catch(Exception ex)
                {
                    this.Dispatcher.Invoke(()=>Inform.Functions.ShowMessage(ex.Message,"增加员工-获取国家列表"));
                };
            });
            this.InCouID.ItemsSource = TA; 
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
                    InHeader.Source = new BitmapImage(new Uri(uri));
                    InHeader.Tag = uri;
                }
            }
            catch (Exception ex) { Inform.Functions.ShowMessage(ex.Message, "增加员工-选择图片"); }
        }

        private void ReSetText(object sender, MouseButtonEventArgs e)
        {
            ResetText();
        }

    }
}
