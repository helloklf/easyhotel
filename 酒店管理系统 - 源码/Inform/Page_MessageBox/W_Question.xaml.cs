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
using System.Windows.Shapes;

namespace Inform
{
    /// <summary>
    /// W_Question.xaml 的交互逻辑
    /// </summary>
    public partial class W_Question:Window
    {
        public W_Question()
        {
            InitializeComponent();
        }
        public W_Question(string s,string t)
        {
            InitializeComponent();
            messageText = s;
            titleText = t;
        }

        public string messageText="";
        public string titleText="";

        /// <summary>
        /// 基本外观配置信息
        /// </summary>
        public DllSetting.AppSurface BGSET = Inform.Values.SurfaceSetting.Surface;


        private void TopDoubleClick_WindowSize(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            C.DataContext = BGSET;
            this.DataContext = BGSET; Use_BackGroundImage();
            this.MessageText.Text = messageText;
            this.TitleText.Text = titleText;
        }

        private void WindowMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) { this.DragMove(); }
        }

        private void CloseWindow_No(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void CloseWindow_Yes(object sender, RoutedEventArgs e)
        {
            DialogResult = true;         
            Close();
        }

        /// <summary>
        /// 使用背景图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Use_BackGroundImage()
        {
            string Url = BGSET.BgImage;
            if (Url != null)
            {
                ImageBrush bi = new ImageBrush(new BitmapImage(new Uri(Url)));
                bi.Stretch = Stretch.UniformToFill;
                Grid_.Background = bi;
            }
        }

        private void CloseWindow(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void WindowMini(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void WinodwMax(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

    }
}
