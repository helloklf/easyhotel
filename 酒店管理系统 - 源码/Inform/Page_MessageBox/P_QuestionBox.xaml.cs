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
    /// P_QuestionBox.xaml 的交互逻辑
    /// </summary>
    public partial class P_QuestionBox : Window
    {
        public P_QuestionBox()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 问题、标题
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="Title"></param>
        public P_QuestionBox(string txt, string Title)
        {
            InitializeComponent();
            MessText.Text = txt;
            TitleText.Text = Title;
        }

        /// <summary>
        /// 图标图片、问题文本、标题
        /// </summary>
        /// <param name="Imageurl"></param>
        /// <param name="txt"></param>
        /// <param name="Title"></param>
        public P_QuestionBox(Uri Imageurl, string txt, string Title)
        {
            InitializeComponent();
            MessText.Text = txt;
            TitleText.Text = Title;
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


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Y)
            {
                DialogResult = true;
                Close();
            }
            else if (e.Key == Key.N)
            {
                DialogResult = false;
                Close();
            }
        }
    }
}
