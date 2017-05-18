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
using System.Collections.ObjectModel;

namespace Project_Term2.Controls
{
    /// <summary>
    /// SearchBox.xaml 的交互逻辑
    /// </summary>
    public partial class SearchBox : UserControl
    {
        public SearchBox()
        {
            InitializeComponent();
            this.Xaml_DownList.DataContext = SuggestList;
        }
         
        /// <summary>
        /// 搜索时触发
        /// </summary>
        public event RoutedEventHandler Click = null;

        /// <summary>
        /// 筛选列表数据List<string>
        /// </summary>
        private List<string> data;

        public List<string> DataList
        {
            get { return data; }
            set { data = value ; }
        }

        ObservableCollection<string> suggestList = new ObservableCollection<string>();
        ObservableCollection<string> SuggestList 
        {
            get 
            {
                return  suggestList ;
            }
        }

        /// <summary>
        /// 输入的文本
        /// </summary>
        public string Text 
        { 
            get 
            {
                return InputContent.Text;
            }
        }

        /// <summary>
        /// 搜索按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Click != null) { Click(this, new RoutedEventArgs()); }
        }

        private void InputContent_GotFocus(object sender, RoutedEventArgs e)
        {
            Xaml_watermark.Opacity = 0;
            Xaml_DownList.Visibility = Visibility.Visible;
        }

        private void InputContent_LostFocus(object sender, RoutedEventArgs e)
        {
            if (InputContent.Text == "") { Xaml_watermark.Opacity = 0.5; }
            Xaml_DownList.Visibility= Visibility.Collapsed;
        }

        /// <summary>
        /// 回车时搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) { if (Click != null) { Click(this, new RoutedEventArgs()); } }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InputContent.TextChanged -= InputContent_TextChanged;
            this.InputContent.Text = Xaml_DownList.SelectedValue as string;
            Xaml_watermark.Opacity = 0;
            InputContent.TextChanged += InputContent_TextChanged;
        }

        private void InputContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            string t = InputContent.Text.Trim();
            suggestList.Clear();
            foreach (var item in (from a in DataList where a.Contains(t) select a).ToList())
            {
                suggestList.Add(item);
            }
        }
    }
}
