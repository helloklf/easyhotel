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

namespace DllSettingPanel.OtherSet
{
    /// <summary>
    /// ColorTrans.xaml 的交互逻辑
    /// </summary>
    public partial class ColorTrans : UserControl
    {
        public ColorTrans()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.C.DataContext = Values.SurfaceSetting.Surface;
            CTransparent.DataContext = Values.SurfaceSetting.Surface;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //Values.SurfaceSetting.Surface.Transparent = true;
        }
    }
}
