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
using TModel;

namespace Project_Term2.UserPage
{
    /// <summary>
    /// UserInfo.xaml 的交互逻辑
    /// </summary>
    public partial class UserInfo : UserControl
    {
        public UserInfo()
        {
            InitializeComponent();
            Delegates.LoginInfo += new UserLogin(LoginInfoRead);
            Delegates.UserOff_Line += new NotParameter(() => { UserInfoPanel.DataContext = null;});
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.C.DataContext = Values.SurfaceSetting.Surface;
        }
        public void LoginInfoRead(View_UserInfo UI) 
        {
            UserInfoPanel.DataContext = UI; Values.UserInfo = UI;
        } 
    }
}
