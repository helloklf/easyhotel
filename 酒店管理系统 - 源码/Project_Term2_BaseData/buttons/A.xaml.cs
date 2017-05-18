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

namespace MyControls
{
    /// <summary>
    /// _.xaml 的交互逻辑
    /// </summary>
    public partial class A : UserControl
    {
        public A()
        {
            InitializeComponent(); 
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.C.DataContext = Project_Term2_BaseData.Values.SurfaceSetting.Surface;
        }
    }
}
