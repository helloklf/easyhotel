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
using System.Diagnostics;
using System.IO;

namespace Project_Term2.MainMenu
{
    /// <summary>
    /// P_MainMenu0.xaml 的交互逻辑
    /// </summary>
    public partial class C_Home : UserControl
    {

        List<TModel.Other_HotelRoomState> ClientRoomState = new List<TModel.Other_HotelRoomState>();//各类房间数量
        TModel.Other_HotelRoomState RoomMaxCount = new TModel.Other_HotelRoomState();//数量最多的类型房间
        TModel.Other_HotelRoomState RoomMinCount = new TModel.Other_HotelRoomState();//数量最多的类型房间
        List<TModel.Other_HotelRoomState> RoomStateCount = new List<TModel.Other_HotelRoomState>();// 各种状态的房间数量
        List<TModel.Other_EmptyRoom> EmptyRoomCount = new List<TModel.Other_EmptyRoom>();//获得各类房间的总数及空房数量，用于计算空余比例
        List<TModel.Other_HotelFund> HotelFund = new List<TModel.Other_HotelFund>();//酒店资金情况

        /// <summary>
        /// 读取和显示房间状态
        /// </summary>
        public async void RoomStateLoad()
        {
            await Task.Run(() =>
            {
                try
                {
                    ClientRoomState = DLL_BLL.View_ClientRoomState_BLL.View_RoomTypeCount();
                    RoomMaxCount = DLL_BLL.View_ClientRoomState_BLL.RoomMax_MinCount(true);
                    RoomMinCount = DLL_BLL.View_ClientRoomState_BLL.RoomMax_MinCount(false);
                    RoomStateCount = DLL_BLL.View_ClientRoomState_BLL.View_RoomStateCount();
                    EmptyRoomCount = DLL_BLL.View_ClientRoomState_BLL.Proc_EmptyRoomCount();
                    HotelFund= DLL_BLL.View_ClientRoomState_BLL.view_HotelFund();
                }
                catch (Exception ex) { Functions.ShowMessage(ex.Message,"发生异常"); }
            });
            try
            {
                TypeMaxCount.DataContext = RoomMaxCount;
                RoomTypeCountLB.DataContext = ClientRoomState;
                TypeMinCount.DataContext = RoomMinCount;
                RoomStateCountLB.DataContext = RoomStateCount;
                RoomEmptyCountLB.DataContext = EmptyRoomCount;
                RoomFundIO.DataContext = HotelFund;
            }
            catch (Exception ex) { Functions.ShowMessage(ex.Message,"出现错误"); }
        }

        /// <summary>
        /// 查看当天账务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Go_TodayAccounts(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (Delegates.History.Test() && Delegates.ToPageIndex != null&&Delegates.History.TodayAccounts!=null)
                {
                    Delegates.ToPageIndex(2); Delegates.History.TodayAccounts();
                }
            }
            catch (Exception ex) { Functions.ShowMessage(ex.Message,"导航失败"); }
        }

        /// <summary>
        /// 显示预订的房间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Go_RoomBook(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.RoomData.Test())
            {
                if (Delegates.RoomData.RoomBook != null && Delegates.ToPageIndex != null)
                {
                    Delegates.ToPageIndex(1); Delegates.RoomData.RoomBook();
                }
            }
        }

        #region 系统功能

            #region 消息显示风格
            /// <summary>
            /// 更改消息弹出显示风格
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void Tile_WindowStyle(object sender, MouseButtonEventArgs e)
            {
                bool b = Values.SurfaceSetting.Surface.Overallview;
                if (b)
                {
                    Values.SurfaceSetting.Surface.Overallview = false;
                    Functions.ShowMessage("已切换为经典窗口模式,需在设置中保存才会永久生效！", "操作完成:");
                }
                else
                {
                    Values.SurfaceSetting.Surface.Overallview = true;
                    Functions.ShowMessage("已切换为沉浸模式,需在设置中保存才会永久生效！", "操作完成:");
                }
            }
            #endregion
            /// <summary>
            /// 打开设置面板
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void Tile_SettingOpen(object sender, MouseButtonEventArgs e)
            {
                Values.PageStates.Setting = Values.PageStates.Setting == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            }


            /// <summary>
            /// 消息系统
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void Tile_MesageSystem(object sender, MouseButtonEventArgs e)
            {
                Values.PageStates.UserCenter = Values.PageStates.UserCenter != Visibility.Visible ? Visibility.Visible : Visibility.Collapsed;
                if (Delegates.ToMessagePage != null) Delegates.ToMessagePage();
            }

            /// <summary>
            /// 界面锁定
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void Tile_LockWindow(object sender, MouseButtonEventArgs e)
            {
                if (Delegates.HideWindow != null)
                {
                    Delegates.HideWindow();
                    LockPage lp = new LockPage();
                    lp.ShowDialog();
                }
            }

        #endregion

        /// <summary>
        /// 房间信息相关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoomInfoPanel_Click(object sender, MouseButtonEventArgs e)
        {
            RoomTran.Visibility = RoomTran.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tile_UserLogin(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (Values.UserInfo != null && Values.UserInfo.StaffID != null)
                {
                    Functions.ShowMessage("当前用户已经在线，无法再次登陆，请先注销当前用户再试", "无法登陆");
                    return;
                }
                else
                {
                    LoginPage l = new LoginPage(); l.ShowDialog(); Delegates.MaxWindow();
                }
            }
            catch (Exception ex) { Functions.ShowMessage(ex.Message,"出现错误"); }
        }

        /// <summary>
        /// 用户注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tile_UserLogOff(object sender, MouseButtonEventArgs e)
        {
            if (Values.UserInfo == null || Values.UserInfo.StaffID == null)
            {
                Functions.ShowMessage("你当前没有登陆，因此你这个操作是不会有任何效果的！", "操作无效");
            }
            else 
            {
                if (new Inform.W_Question("确定要注销当前登录的用户吗？这立即结束当前工作返回主界面。","确定注销？").ShowDialog()==true)
                {
                    if (Delegates.UserOff_Line != null)
                    {
                        try
                        {
                            Delegates.UserOff_Line();
                            Functions.ShowMessage("你可以点击任务栏的‘用户’图标或主菜单中的登陆按钮重新登录！", "注销成功");
                        }
                        catch
                        {
                            Functions.ShowMessage("用户注销时出现未知异常", "系统异常");
                        }
                    }
                    else { Functions.ShowMessage("因为系统功能的缺失，现在你不能顺利注销，请直接关闭应用程序或稍后再试！", "出现错误"); }
                }
                else Functions.ShowMessage("你取消了注销操作，你可以继续当前未完成的任务！","操作取消");
            }
        }


        //帮助
        private void Tile_HelpOpen(object sender, MouseButtonEventArgs e)
        {
            Functions.ShowMessage("帮助文档现已整合到应用中，点击界面上方的大标题即可查看所在页的说明书","使用帮助");            
        }


        /// <summary>
        /// 客户管理中心
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Fun_ClientList(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.ClientData.Test())
            {
                Delegates.ToPageIndex(3);
            }
        }

        /// <summary>
        /// 所有房间 列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Fun_AllRoomList(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.RoomData.Test())
            {
                if (Delegates.RoomData.AllRoom != null && Delegates.ToPageIndex != null)
                { Delegates.ToPageIndex(1);}
            }
        }

        /// <summary>
        /// 历史记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Fun_History(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.RoomData.Test())
            {
                if (Delegates.RoomData.AllRoom != null && Delegates.ToPageIndex != null)
                { Delegates.ToPageIndex(2); }
            }
        }

        /// <summary>
        /// 员工管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Fun_StaffList(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.StaffData.Test())
            {
                Delegates.ToPageIndex(4);
            }
        }

        /// <summary>
        /// 房间管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Fun_RoomManage(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.RoomData.Test())
            {
                Delegates.ToPageIndex(5);
            }
        }

        /// <summary>
        /// 基础数据管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Fun_BaseDataMange(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.BaseData.Test())//测试权限等级是否足够
            {
                Delegates.ToPageIndex(6);
            }
        }

        /// <summary>
        /// 小工具-显示酒店规模
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolTile_ToHotelScale(object sender, RoutedEventArgs e)
        {
            TabToolTiles.SelectedIndex = 0;
        }

        /// <summary>
        /// 小工具-显示房间状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolTile_ToRoomState(object sender, RoutedEventArgs e)
        {
            TabToolTiles.SelectedIndex = 1;
        }

        /// <summary>
        /// 小工具-显示空房情况
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolTile_ToEmptyRoom(object sender, RoutedEventArgs e)
        {
            TabToolTiles.SelectedIndex = 2;
        }

        /// <summary>
        /// 小工具-资金状况
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolTile_ToFund(object sender, RoutedEventArgs e)
        {
            TabToolTiles.SelectedIndex = 3;            
        }

        /// <summary>
        /// 返回功能页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnTo_RoomList(object sender, MouseButtonEventArgs e)
        {
            MainTab.SelectedIndex = 0;
        }

        /// <summary>
        /// 显示帮助文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpPage(object sender, MouseButtonEventArgs e)
        {
            MainTab.SelectedIndex = 1;
        }


    }
}