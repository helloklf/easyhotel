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
    /// DataListMenu.xaml 的交互逻辑
    /// </summary>
    public partial class DataListMenu : UserControl
    {
        public DataListMenu()
        {
            InitializeComponent();
            this.DataContext = Values.SurfaceSetting.Surface;
        }

        public event MouseButtonEventHandler OnAddItem;
        public event MouseButtonEventHandler OnEditItem;
        public event MouseButtonEventHandler OnSelectedItemEnabled;
        public event MouseButtonEventHandler OnSelectedItemEnabledNo;
        public event RoutedEventHandler OnCheckBox_Click;
        public bool IsChecked
        {
            get { return (bool)this.IsCheck.IsChecked; }
            set { this.IsCheck.IsChecked=value; }
        }

        private void SelectedItemEnabled(object sender, MouseButtonEventArgs e)
        {
            if (OnSelectedItemEnabled != null) OnSelectedItemEnabled(this, null);
        }

        private void SelectedItemEnabledNo(object sender, MouseButtonEventArgs e)
        {
            if (OnSelectedItemEnabledNo != null) OnSelectedItemEnabledNo(this, null);
        }

        private void EditItem(object sender, MouseButtonEventArgs e)
        {
            if (OnEditItem != null) OnEditItem(this, null);
        }

        private void AddItem(object sender, MouseButtonEventArgs e)
        {
            if (OnAddItem != null) OnAddItem(this, null);
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (OnCheckBox_Click != null) { OnCheckBox_Click(this, null); }
        }
    }
}
