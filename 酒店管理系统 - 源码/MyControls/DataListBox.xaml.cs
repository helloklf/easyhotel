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
    /// DataListBox.xaml 的交互逻辑
    /// </summary>
    public partial class DataListBox : UserControl
    {
        public DataListBox()
        {
            InitializeComponent();
        }
        
        public event MouseButtonEventHandler OnAddItem;
        public event MouseButtonEventHandler OnEditItem;
        public event MouseButtonEventHandler OnSelectedItemEnabled;
        public event MouseButtonEventHandler OnSelectedItemEnabledNo;
        public event ContextMenuEventHandler OnLBContextMenuOpening;

        public System.Windows.Controls.MenuItem MenuItem_Emable
        {
            get { return this.MenuItemEmable; }
            set { this.MenuItemEmable = value; }
        }
        public System.Windows.Controls.MenuItem MenuItem_Forbidden
        {
            get { return this.MenuItemForbidden; }
            set { this.MenuItemForbidden = value; }
        }

        public System.Collections.IEnumerable ItemsSource 
        {
            get { return LB.ItemsSource; }
            set { LB.ItemsSource = value; }
        }
        public System.Windows.DataTemplate ItemTemplate
        {
            get { return LB.ItemTemplate; }
            set { LB.ItemTemplate = value; }
        }
        public string SelectedValuePath
        {
            get{ return LB.SelectedValuePath; }
            set{ LB.SelectedValuePath = value; }
        }
        public object SelectedItem
        {
            get { return LB.SelectedItem; }
            set { LB.SelectedItem = value; }
        }
        public object SelectedValue
        {
            get { return LB.SelectedValue; }
            set { LB.SelectedValue = value; }
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

        private void LB_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (OnLBContextMenuOpening != null) { OnLBContextMenuOpening(this, null); }
        }
    }
}
