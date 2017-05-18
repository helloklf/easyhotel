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

namespace DllSettingPanel
{
    /// <summary>
    /// SelectImage.xaml 的交互逻辑
    /// </summary>
    public partial class SelectImage : UserControl
    {
        public SelectImage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 预览选择的背景图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string File = WFormIO.SelectImage();
                if (File != null)
                {
                    Values.SurfaceSetting.Surface.BgImage = File;
                    this.Background_ImageView.Source = new BitmapImage(new Uri(File));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + "\r\n发生了不可预料的错误！图像的读取交互逻辑出现问题！"); }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            C.DataContext = Values.SurfaceSetting.Surface;
        }

        private void NoBackGroudImage(object sender, MouseButtonEventArgs e)
        {
            Values.SurfaceSetting.BgImage = null;
            Values.SurfaceSetting.Surface.BgImage = null;
        }

        private void Use_BackGroundImage(object sender, MouseButtonEventArgs e)
        {
            string Url = Values.SurfaceSetting.Surface.BgImage;
            if (Url != null)
            {
                ImageBrush bi = new ImageBrush(new BitmapImage(new Uri(Url)));
                bi.Stretch = Stretch.UniformToFill;
                Values.SurfaceSetting.BgImage = bi;
            }
        }
    }
}
