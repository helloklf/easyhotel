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
using System.Threading;

namespace Inform
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageWindow()
        {
            InitializeComponent(); Delegates.AddChildren_ += new VOID(AddMessage);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        public void AddMessage(string txt, string title)
        {
            if (Values.SurfaceSetting.Surface.Overallview)
            {
                P_MessageBox pm = new P_MessageBox(title + "：" + txt);
                MessageList.Children.Add(pm);
                try
                {
                    ThreadPool.QueueUserWorkItem((o) =>
                    {
                        bool isRemove = false;
                        while (!isRemove)
                        {
                            Thread.Sleep((Values.SurfaceSetting.Surface.MessageTime) * 1000);
                            this.Dispatcher.Invoke(() =>
                            {
                                if (pm.AutoCler) MessageList.Children.Remove(pm);
                            });
                        }
                    });
                }
                catch { }
            }
            else 
            {
                W_Message WM = new W_Message(txt, title); WM.Show();
            }
        }
    }
}
