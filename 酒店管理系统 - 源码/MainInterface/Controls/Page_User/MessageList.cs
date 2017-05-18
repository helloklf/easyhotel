using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;

namespace Project_Term2.UserPage
{
    public static class ApplcitionMessage//  :INotifyPropertyChanged// ObservableCollection<Message_List>
    {
        public static MessageList list = new MessageList();
    }

    #region 消息列表类型
    /// <summary>
    /// 全局消息集中管理
    /// </summary>
    public class MessageList :INotifyPropertyChanged
    {
        #region 非系统提示消息
        ObservableCollection<OtherMessage> otherMessages = new ObservableCollection<OtherMessage>();
        /// <summary>
        /// 其它消息列表
        /// </summary>
        public ObservableCollection<OtherMessage> OtherMessages
        {
            get {  return otherMessages; }
            set { otherMessages = value; Changed(false);  }
        }

        /// <summary>
        /// 非系统消息数量
        /// </summary>
        public int OmCount
        {
            get { return OtherMessages.Count; }
            set { Changed(false); }
        }
        #endregion

        #region 系统消息
        private ObservableCollection<SysMessage> sysMessages = new ObservableCollection<SysMessage>();
        public ObservableCollection<SysMessage> SysMessages
        {
            get {return sysMessages; }
            set { sysMessages = value;   Changed(true); }
        }

        /// <summary>
        /// 系统消息数量
        /// </summary>
        public int SMCount
        {
            get { return sysMessages.Count; }
            set { Changed(true); }
        }
        #endregion

        #region 所有消息数量
        /// <summary>
        /// 所有消息总数
        /// </summary>
        public int MessageCount
        {
            get { return sysMessages.Count+otherMessages.Count; }
        }
        #endregion


        public SolidColorBrush FColor
        {
            get { return Values.SurfaceSetting.Surface.ForeColor; }
            set { Changed("FColor"); }
        }
        public SolidColorBrush BgColor
        {
            get { return Values.SurfaceSetting.Surface.BgColor; }
            set { Changed("BgColor"); }
        }

        //方法：发送值改变通知
        public void Changed(bool IsSys) 
        {
            if (PropertyChanged != null)
            {
                if (IsSys)  PropertyChanged(this, new PropertyChangedEventArgs("SMCount"));
                else         PropertyChanged(this, new PropertyChangedEventArgs("OmCount"));
                PropertyChanged(this, new PropertyChangedEventArgs("MessageCount"));
            } 
        }

        public void Changed(string name)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(name)); };
        }

        //实现接口
        public event PropertyChangedEventHandler PropertyChanged;
    }
    #endregion

    #region 消息类型
    //其它消息：继承自消息文本
    public class OtherMessage : MessageInfo
    {
        string messageFrom = "其它";
        /// <summary>
        /// 消息来源
        /// </summary>
        public string MessageFrom
        {
            get { return messageFrom; }
            set { messageFrom = value; }
        }
    }

    //系统消息：继承自小学文本
    public class SysMessage : MessageInfo
    {
        string messageFrom = "系统提示";
        /// <summary>
        /// 消息来源
        /// </summary>
        public string MessageFrom
        {
            get { return messageFrom; }
            set { messageFrom = value; }
        }
    }

    //Base：消息文本
    public class MessageInfo : INotifyPropertyChanged
    {
        public SolidColorBrush FColor
        {
            get { return Values.SurfaceSetting.Surface.ForeColor; }
            set { Changed("FColor"); }
        }
        public SolidColorBrush BgColor
        {
            get { return Values.SurfaceSetting.Surface.BgColor; }
            set { Changed("BgColor"); }
        }

        Guid messageGUID = Guid.NewGuid();
        /// <summary>
        /// 每条消息的唯一标识
        /// </summary>
        public Guid MessageGUID
        {
            get { return messageGUID; }
            set { messageGUID = value; }
        }
        string messageText;
        /// <summary>
        /// 消息内容
        /// </summary>
        public string MessageText
        {
            get { return messageText; }
            set { messageText = value; Changed("MInfoText"); }
        }

        public void Changed(string name) 
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(name)); };
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    #endregion
}

