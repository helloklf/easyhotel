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

namespace Inform
{
    /// <summary>
    /// P_MessageBox.xaml 的交互逻辑
    /// </summary>
    public partial class P_MessageBox : UserControl
    {
        public P_MessageBox()
        {
            InitializeComponent();
            this.C.DataContext = Values.SurfaceSetting.Surface;
        }

        /// <summary>
        ///消息文本 
        /// </summary>
        /// <param name="text"></param>
        public P_MessageBox(string text)
        {
            InitializeComponent(); try
            {
                this.MessText.Text = text;
                AutoCler = Values.SurfaceSetting.Surface.MessageTime != 0 ? true : false;
            }
            catch { }
        }

        /// <summary>
        /// 图片路径、消息文本
        /// </summary>
        /// <param name="Imageurl"></param>
        /// <param name="text"></param>
        public P_MessageBox(Uri Imageurl, string text)
        {
            InitializeComponent();
            try
            {
                this.MessText.Text = text;
                BitmapImage im = new BitmapImage(Imageurl); this.MessImage.Source = im;
                AutoCler = Values.SurfaceSetting.Surface.MessageTime != 0 ? true : false;
            }
            catch { }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.C.DataContext = Inform.Values.SurfaceSetting.Surface;
            if (!AutoCler) this.BorderThickness = new Thickness(2, 2, 0, 2);
        }

        public bool AutoCler = false;

        private void No_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed; AutoCler = true;
        }

        private void NoAutoCler(object sender, MouseButtonEventArgs e)
        {
            IsPin.Visibility = Visibility.Collapsed;
            AutoCler = false; this.BorderThickness = new Thickness(2,2,0,2);
        }
    }
}
