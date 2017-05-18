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

namespace Project_Term2.MainMenu
{
    public partial class Style_C
    {
        /// <summary>
        /// 主菜单按钮左键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Lable_MD(object sender, MouseButtonEventArgs e)
        {
            Label l = sender as Label; 
            l.Focus();
            //l.Background = new SolidColorBrush(Colors.Yellow);
        }

    }
}
