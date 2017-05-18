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

namespace Project_Term2.DataView
{
    /// <summary>
    /// DataGrid1.xaml 的交互逻辑
    /// </summary>
    public partial class DataGrid1 : UserControl
    {
        public DataGrid1()
        {
            InitializeComponent(); 
            Project_Term2_BaseData.BaseDataDelegates.MainDelegate += new Project_Term2_BaseData.NotParameter(Case);
            Delegates.History.TodayAccounts += new NotParameter(TodayAccounts);
        }

        DataTable DT = new DataTable();
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.C.DataContext = Values.SurfaceSetting.Surface;
        }

        /// <summary>
        /// 切换列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTypeChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SearchType.Header = (string)SearchTypeList.SelectedValue;
                SearchType.IsExpanded = false; Case();
            }
            catch (Exception ex) { Functions.ShowMessage(ex.Message,"系统错误"); }
        }

        public void TodayAccounts() 
        {
            SearchType.Header = "消费记录";
            TimeSpanSelect.Text = "当天"; Case();
        }

        /// <summary>
        /// 判断要获取的数据类型
        /// </summary>
        public void Case()
        {
            if (SearchType.Header.ToString() == "住房历史") LoadData(1);
            else if (SearchType.Header.ToString() == "消费记录") LoadData(2);
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="index"></param>
        public async void LoadData(int index)
        {
            string time = TimeSpanSelect.Text;
            if (time == null || time.Length < 1) return;
            await Task.Run(() =>
            {
                try
                {
                    int i = 0;
                    switch (time)
                    {
                        case "当天": i = 1; break;
                        case "7天": i = 2; break;
                        case "30天": i = 3; break;
                        case "365天": i = 4; break;
                        case "全部": i = 5; break;
                        default:
                            break;
                    }
                    if (index == 1)
                    {
                        DT = DLL_BLL.History.view_HousingHistory(i);
                    }
                    else if (index == 2)
                    {
                        DT = DLL_BLL.History.view_ConsumeHistory(i);
                    }
                }
                catch(Exception ex) { this.Dispatcher.Invoke(()=>Functions.ShowMessage(ex.Message,"发生异常")); }
            });
            DataList.DataContext = DT;
        }

        private void ReturnTo_MainMenu(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.ToPageIndex != null) Delegates.ToPageIndex(0);
        }

        private void TimeSpanSelect_DropDownClosed(object sender, EventArgs e)
        {
            Case();
        }

        /// <summary>
        /// 显示说明帮助文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToHelpPage(object sender, MouseButtonEventArgs e)
        {
            MainTab.SelectedIndex = 1;
        }

        private void ReturnTo_RoomList(object sender, MouseButtonEventArgs e)
        {
            MainTab.SelectedIndex = 0;
        }

    }
}
