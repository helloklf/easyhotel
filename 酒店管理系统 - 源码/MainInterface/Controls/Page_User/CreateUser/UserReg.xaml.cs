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

namespace Project_Term2.Page_User.CreateUser
{
    /// <summary>
    /// UserReg.xaml 的交互逻辑
    /// </summary>
    public partial class UserReg : UserControl
    {
        public UserReg()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.C.DataContext = Values.SurfaceSetting.Surface;
        }

        private void ReSetText(object sender, MouseButtonEventArgs e)
        {
            this.User_Login_ID.Text = "";
            this.UserLogin_Name.Text = "";
            this.UserLogin_Pass.Text = "";
        }

        private void Button_GoReg(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
