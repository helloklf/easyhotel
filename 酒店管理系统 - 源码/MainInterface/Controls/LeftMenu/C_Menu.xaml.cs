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

namespace Project_Term2.LeftMenu
{
    /// <summary>
    /// C_LeftMenu.xaml 的交互逻辑
    /// </summary>
    public partial class C_Menu : UserControl
    {
        public C_Menu()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.C.DataContext = Values.SurfaceSetting.Surface;
            Delegates.LeftMenuState = new NotParameter(LeftMenuState);
        }

        #region 左侧导航列表显示状态切换
        /// <summary>
        /// 左侧导航列表状态
        /// </summary>
        private void LeftMenuState()
        {
            MainMenu_Left.Visibility = MainMenu_Left.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
        #endregion

        private void LeftMenuState_Clcik(object sender, MouseButtonEventArgs e)
        {
            LeftMenuState();
        }


        private void ISMenu_Click(object sender, RoutedEventArgs e)
        {
            this.TAB.SelectedIndex= (bool)ISMenu.IsChecked?0:1;
        }
    }
}
