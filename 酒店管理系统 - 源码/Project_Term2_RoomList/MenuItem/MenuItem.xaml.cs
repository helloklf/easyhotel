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

namespace Project_Term2_RoomList.MenuItem
{
    /// <summary>
    /// MenuItem.xaml 的交互逻辑
    /// </summary>
    public partial class MenuItem : UserControl
    {
        public MenuItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 鼠标左键按下
        /// </summary>
        public event RoutedEventHandler Click;
        
        /// <summary>
        /// 背景色
        /// </summary>
        public ImageSource ItemBackground 
        {
            set { Gi.ImageSource = value; }
        }
        

        /// <summary>
        /// 标题
        /// </summary>
        public string ItemTitle
        {
            get { return Ti.Text; }
            set { this.Ti.Text = value; }
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if (Click != null) Click(this, null);
        }
    }
}
