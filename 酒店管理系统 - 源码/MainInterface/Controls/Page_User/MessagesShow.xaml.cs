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

namespace Project_Term2.UserPage
{
    /// <summary>
    /// MessagesShow.xaml 的交互逻辑、
    /// </summary>
    public partial class MessagesShow : UserControl
    {
        public MessagesShow()
        {
            InitializeComponent();
            SCount.DataContext = ApplcitionMessage.list;
            OCount.DataContext = ApplcitionMessage.list;
            UserMessageList_Sys.DataContext = ApplcitionMessage.list;//绑定消息源
            UserMessageList_Other.DataContext = ApplcitionMessage.list;//绑定消息源
        }
        #region 消息系统

                #region 消息清理
                /// <summary>
                /// 清空系统消息
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                private void User_ClearMessageList_Sys(object sender, MouseButtonEventArgs e)
                {
                    ApplcitionMessage.list.SysMessages.Clear();
                }

                /// <summary>
                /// 清理其它用户消息
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                private void User_ClearMessageList_Other(object sender, MouseButtonEventArgs e)
                {
                    ApplcitionMessage.list.OtherMessages.Clear();
                }
            #endregion

                #region 点击消息
                private void MessageInfo_Select(object sender, MouseButtonEventArgs e)
                {
                    try
                    {
                        StackPanel d = sender as StackPanel;
                        Guid g = (Guid)d.Tag;
                        TextBlock t1 = d.Children[0] as TextBlock;TextBlock t2 = d.Children[2] as TextBlock;
                        Functions.ShowMessage(t1.Text,t2.Text);
                        foreach (var item in UserPage.ApplcitionMessage.list.SysMessages)
                        {
                            if (item.MessageGUID == g) { UserPage.ApplcitionMessage.list.SysMessages.Remove(item); UserPage.ApplcitionMessage.list.SMCount = 0; break; }
                        }
                    }
                    catch
                    {
                        Functions.ShowMessage(Other.InfoText.ApplictionError, "严重错误");
                    }
                }

                private void MessageInfo_Select2(object sender, MouseButtonEventArgs e)
                {
                    try
                    {
                        DockPanel d = sender as DockPanel;
                        Guid g = (Guid)d.Tag;
                        TextBlock t1 = d.Children[1] as TextBlock;TextBlock t2 = d.Children[3] as TextBlock;
                        Functions.ShowMessage(t1.Text, t2.Text);
                        foreach (var item in UserPage.ApplcitionMessage.list.OtherMessages)
                        {
                            if (item.MessageGUID == g) { UserPage.ApplcitionMessage.list.OtherMessages.Remove(item); UserPage.ApplcitionMessage.list.OmCount = 0; break; }
                        }
                    }
                    catch
                    {
                        Functions.ShowMessage(Other.InfoText.ApplictionError, "严重错误！");
                    }
                }
                #endregion

                private void UserControl_Loaded(object sender, RoutedEventArgs e)
                {
                    this.C.DataContext = Values.SurfaceSetting.Surface;
                }
            #endregion

                
    }
}
