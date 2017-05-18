using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllSettingPanel
{
    public class SettingListIndex:INotifyPropertyChanged
    {
        public static SettingListIndex Index = new SettingListIndex();
        int tabItemIndex;
        /// <summary>
        /// 选择页面
        /// </summary>
        public int TabItemIndex
        {
            get { return tabItemIndex; }
            set { tabItemIndex = value; if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs("TabItemIndex")); } }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
