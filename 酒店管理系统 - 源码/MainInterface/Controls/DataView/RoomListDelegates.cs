using DLL_BLL;
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

namespace Project_Term2.DataView
{
    /// <summary>
    /// RoomList.xaml 的交互逻辑
    /// </summary>
    public partial class RoomList : UserControl
    {
        /// <summary>
        /// 委托初始化器
        /// </summary>
        public void SetDelegates()
        {
            try
            {
                Delegates.RoomData.AllRoom = new NotParameter(D_AllRoom);
                Delegates.RoomData.ExitRoom = new NotParameter(D_ExitRoom);
                Delegates.RoomData.AddMoney = new NotParameter(D_AddMoney);
                Delegates.RoomData.ClientIn = new NotParameter(D_ClientIn);
                Delegates.RoomData.RoomBook = new NotParameter(D_RoomBook);
            }
            catch (Exception ex) { Functions.ShowMessage(ex.Message, "发生错误"); }
        }

        /// <summary>
        /// 显示所有房间
        /// </summary>
        public void D_AllRoom()
        {
            try
            {
                AllRoomType.IsChecked = true;
                AllStateType.IsChecked = true;
                LoadData_ComBox();
                RightPanel.Visibility = Visibility.Collapsed;
                RightPanel.SelectedIndex = 0;
            }
            catch (Exception ex) { Functions.ShowMessage(ex.Message, "发生错误"); }
        }

        /// <summary>
        /// 退房界面
        /// </summary>
        public void D_ExitRoom()
        {
            try
            {
                AllRoomType.IsChecked = true;
                AllStateType.IsChecked = false;
                ComRoomState.Text = "占用房";
                LoadData_ComBox();
                RightPanel.Visibility = Visibility.Visible;
                RightPanel.SelectedIndex = 3;
            }
            catch (Exception ex) { Functions.ShowMessage(ex.Message, "发生错误"); }
        }

        /// <summary>
        /// 续费界面
        /// </summary>
        public void D_AddMoney() 
        {
            try
            {
                AllRoomType.IsChecked = true;
                AllStateType.IsChecked = false;
                ComRoomState.Text = "占用房";
                LoadData_ComBox();
                RightPanel.Visibility = Visibility.Visible;
                RightPanel.SelectedIndex = 2;
            }
            catch (Exception ex) { Functions.ShowMessage(ex.Message, "发生错误"); }
        }

        /// <summary>
        /// 客户入住界面
        /// </summary>
        public void D_ClientIn()
        {
            try
            {
                AllRoomType.IsChecked = true;
                AllStateType.IsChecked = false;
                ComRoomState.Text = "空房";
                LoadData_ComBox();
                RightPanel.Visibility = Visibility.Visible;
                RightPanel.SelectedIndex = 0;
            }
            catch (Exception ex) { Functions.ShowMessage(ex.Message, "发生错误"); }
        }

        /// <summary>
        /// 房间预订
        /// </summary>
        public void D_RoomBook()
        {
            try
            {
                AllRoomType.IsChecked = true;
                AllStateType.IsChecked = false;
                ComRoomState.Text = "预订";
                LoadData_ComBox();
            }
            catch (Exception ex) { Functions.ShowMessage(ex.Message, "发生错误"); }
        }
    }
}
