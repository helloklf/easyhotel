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
    /// DataBaseSet.xaml 的交互逻辑
    /// </summary>
    public partial class DataBaseSet : UserControl
    {
        public DataBaseSet()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.C.DataContext = Values.SurfaceSetting.Surface;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
