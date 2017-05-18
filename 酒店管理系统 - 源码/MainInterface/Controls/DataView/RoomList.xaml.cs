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

        #region 控制逻辑

            #region 房间类型筛选条件改变
            /// <summary>
            /// 切换房间类型
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ComRoomType_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                LoadData_ComBox();
            }
            #endregion

            #region 房间状态筛选条件改变
            /// <summary>
            /// 切换房间状态
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ComRoomState_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                LoadData_ComBox();
            }
            #endregion

            #region 筛选条件判断解析
            /// <summary>
            /// 筛选条件判断解析
            /// </summary>
            public void LoadData_ComBox() 
            {
                try
                {
                    //如果房间类型筛选未设置或勾选了‘全部（类型）’则不使用类型过滤条件
                    if (ComRoomType.SelectedValue == null || AllRoomType.IsChecked == true)
                    {
                        //如果按状态筛选未设置或勾选了‘全部（状态）’则不使用类型过滤条件。 即，获取所有房间
                        if (ComRoomState.SelectedValue == null || AllStateType.IsChecked == true) GetData(0);
                        else GetData(2);//否则只使用房间状态筛选条件
                    }
                    else //如果类型筛选条件有效
                    {
                        //如果按状态筛选未设置或勾选了‘全部（状态）’则不使用类型过滤条件。 即，只使用房间类型筛选条件
                        if (ComRoomState.SelectedValue == null || AllStateType.IsChecked == true) GetData(1);
                        else GetData(3);//使用所有筛选条件
                    }

                }
                catch (Exception ex) { Functions.ShowMessage(ex.Message, "系统异常"); }
            }
            #endregion

            #region 切换搜索方式
            /// <summary>
            /// 搜索方式切换
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void SearchTypeChanged(object sender, SelectionChangedEventArgs e)
            {
                try
                {
                    SearchType.IsExpanded = false;//关闭下拉列表
                    SearchType.Header = (string)SearchTypeList.SelectedValue;
                    Functions.ShowMessage("搜索方式已切换为"+SearchType.Header.ToString()+"搜索", "操作提示");
                    if (SearchType.Header.ToString() == "按时长") 
                    {
                        Functions.ShowMessage("按时间搜索，请在搜索框内输入一个整数。如： 24 表示每一天结算一次的房间","使用帮助");
                    }
                    else if (SearchType.Header.ToString() == "按价格") 
                    {
                        Functions.ShowMessage(Other.InfoText.RoomSHelpPrice, "使用建议");
                    }
                }
                catch { Functions.ShowMessage("切换搜索方式失败，请将此错误汇报给开发者！","出现错误"); }
            }
            #endregion

            #region 搜索按钮按下
            /// <summary>
            /// 搜索文本
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void SeachText(object sender, MouseButtonEventArgs e)
            {
                GetData(4);
            }

            /// <summary>
            /// 搜索框回车按下
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void InputSeachTextKeyDown(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Enter) GetData(4);
            }
            #endregion

            #region 筛选条件变化
            private void ComRoomType_Changed(object sender, RoutedEventArgs e)
            {
                ComRoomState_SelectionChanged(null,null);
            }

            private void ComRoomState_Changed(object sender, RoutedEventArgs e)
            {
                ComRoomState_SelectionChanged(null, null);
            }
            #endregion

            #region 刷新按钮按下
            /// <summary>
            /// 刷新按钮
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ReLoadData(object sender, MouseButtonEventArgs e)
            {
                ReLoadData();
            }

            /// <summary>
            /// 重新读取数据 右键菜单
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ReLoadData(object sender, RoutedEventArgs e)
            {
                LoadData_ComBox();
            }
            #endregion

            #region  右键菜单打开前
            /// <summary>
            /// 右键菜单打开前
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void WrapRoomList_ContextMenuOpening(object sender, ContextMenuEventArgs e)
            {
                try
                {
                    if (WrapRoomList.SelectedItem == null) return;
                    View_RoomInfo ri = WrapRoomList.SelectedItem as View_RoomInfo;
                    if (ri.RoomStateName == "空房")
                    {
                        StateSet.Visibility = Visibility.Visible;//修改房间状态
                        RoomBook.Visibility = Visibility.Visible;//房间预订
                        ClientBill.Visibility = Visibility.Collapsed;//账目查询
                        ClientIn.Visibility = Visibility.Visible;//客户入住
                        ClientPay.Visibility = Visibility.Collapsed;//客户缴费
                        ClientOut.Visibility = Visibility.Collapsed;//客户退房
                        RoomRenewal.Visibility = Visibility.Collapsed;//更换房间
                        BookClientIn.Visibility = Visibility.Collapsed;//预订客户入住
                        EixtRoomBook.Visibility = Visibility.Collapsed;//取消预定
                    }
                    else if (ri.RoomStateName == "满房" || ri.RoomStateName == "在住房" || ri.RoomStateName == "占用房")
                    {
                        StateSet.Visibility = Visibility.Collapsed;//修改房间状态
                        RoomBook.Visibility = Visibility.Collapsed;//房间预订
                        ClientBill.Visibility = Visibility.Collapsed;//账目查询
                        ClientIn.Visibility = Visibility.Collapsed;//客户入住
                        ClientPay.Visibility = Visibility.Visible;//客户缴费
                        ClientOut.Visibility = Visibility.Visible;//客户退房
                        RoomRenewal.Visibility = Visibility.Visible;//更换房间
                        BookClientIn.Visibility = Visibility.Collapsed;//预订客户入住
                        EixtRoomBook.Visibility = Visibility.Collapsed;//取消预定
                    }
                    else if(ri.RoomStateName=="预订")
                    {
                        StateSet.Visibility = Visibility.Collapsed;//房间状态修改
                        RoomBook.Visibility = Visibility.Collapsed;//房间预订
                        ClientBill.Visibility = Visibility.Collapsed;//账目查询
                        ClientIn.Visibility = Visibility.Collapsed;//客户入住
                        ClientPay.Visibility = Visibility.Collapsed;//客户缴费
                        ClientOut.Visibility = Visibility.Collapsed;//客户退房
                        RoomRenewal.Visibility = Visibility.Collapsed;//更换房间
                        BookClientIn.Visibility = Visibility.Visible;//预订客户入住
                        EixtRoomBook.Visibility = Visibility.Visible;//取消预定
                    }
                    else
                    {
                        StateSet.Visibility = Visibility.Visible;//房间状态修改
                        RoomBook.Visibility = Visibility.Collapsed;//房间预订
                        ClientBill.Visibility = Visibility.Collapsed;//账目查询
                        ClientIn.Visibility = Visibility.Collapsed;//客户入住
                        ClientPay.Visibility = Visibility.Collapsed;//客户缴费
                        ClientOut.Visibility = Visibility.Collapsed;//客户退房
                        RoomRenewal.Visibility = Visibility.Collapsed;//更换房间
                        BookClientIn.Visibility = Visibility.Collapsed;//预订客户入住
                        EixtRoomBook.Visibility = Visibility.Collapsed;//取消预定
                    }
                }
                catch(Exception ex)
                {
                    Functions.ShowMessage(ex.Message, "遇到错误");
                    StateSet.Visibility = Visibility.Collapsed;//房间状态修改
                    RoomBook.Visibility = Visibility.Collapsed;//房间预订
                    ClientBill.Visibility = Visibility.Collapsed;//账目查询
                    ClientIn.Visibility = Visibility.Collapsed;//客户入住
                    ClientPay.Visibility = Visibility.Collapsed;//客户缴费
                    ClientOut.Visibility = Visibility.Collapsed;//客户退房
                    BookClientIn.Visibility = Visibility.Collapsed;//预订客户入住
                    EixtRoomBook.Visibility = Visibility.Collapsed;//取消预定
                }
            }
            #endregion

            #region 右侧隐藏面板显示切换
            /// <summary>
            /// 右侧隐藏面板显示切换
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void RightPanelSet(object sender, MouseButtonEventArgs e)
            {
                try
                {
                    RightPanel.Visibility = RightPanel.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                }
                catch { Functions.ShowMessage("由于某些原因，该操作没有成功，请再试试", "切换失败"); }
            }
            #endregion

            #region 双击房间
            /// <summary>
            /// 双击房间
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void WrapRoomList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
            {
                try
                {
                    if (WrapRoomList.SelectedItem == null) return;
                    View_RoomInfo ri = WrapRoomList.SelectedItem as View_RoomInfo;
                    if (ri.RoomStateName == "空房")//双击一个空房
                    {
                        if (RightPanel.SelectedIndex != 1) //如果未停留在客户换房界面，理解为客户入住
                            ClientIn_Click(null, null);
                        else//如果正在进行换房操作，理解为要换过去的房间
                        {
                            NewRoomID.Text = ri.RoomID; NewRoomPrice.Text = ri.TypePrice.ToString() + "/" + ri.TypeRequency + "小时";
                        }
                    }
                    else if (ri.RoomStateName == "在住房" || ri.RoomStateName == "占用房" || ri.RoomStateName == "满房")
                    {
                        ClientPay_Click(null, null);//转到续交房费界面
                    }
                    else if (ri.RoomStateName == "预订")
                    {
                        BookClientIn_Click(null, null);//转到续交房费界面
                    }
                    else
                    {
                        StateSet_Click(null, null);//修改房间状态
                    }
                }
                catch (Exception ex) { Functions.ShowMessage(ex.Message, "系统异常"); }
            }
            #endregion

        #endregion

        #region  功能板块

            #region 入住登记
            /// <summary>
            /// 客户入住 右键菜单
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private async void ClientIn_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    if (WrapRoomList.SelectedItem == null) return;
                    View_RoomInfo ri = WrapRoomList.SelectedItem as View_RoomInfo;
                    //错误防御
                    if (ri.RoomStateName != "空房") throw new Exception("所选房间不是一个空的房间，请将此错误反馈给开发者！");
                    else
                    {
                        RightPanel.Visibility = Visibility.Visible; RightPanel.SelectedIndex = 0;//显示房间登记页面
                        List<T_PaperType> TP = new List<T_PaperType>();
                        await Task.Run(() => 
                        {
                            try 
                            {
                                TP = DLL_BLL.PapersTypeBLL.DataLoad(true);
                            }
                            catch(Exception ex)
                            {
                                this.Dispatcher.Invoke(() => Functions.ShowMessage(ex.Message, "发生异常"));
                            }
                        });
                        this.InPapers.DataContext = TP;//重新加载证件类型数据
                        InRoomID.Text = ri.RoomID;//获得房号
                        InRoomPrice.Text = ri.TypePrice + "/" + ri.TypeRequency + "小时";//显示该房间的计费情况
                    }
                }
                catch (Exception ex) { Functions.ShowMessage(ex.Message, "遇到错误"); }
            }


            /// <summary>
            /// 客户入住提交
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private async void SubInRoom_Click(object sender, MouseButtonEventArgs e)
            {
                try
                {
                    View_ProcClientIn vp = new View_ProcClientIn();
                    vp.ClientIName = this.InText.Text;
                    vp.RoomID = this.InRoomID.Text;
                    vp.ClientSex = this.Sex1.IsChecked==true?true:false;
                    vp.ClientAdress = this.InAdress.Text;
                    vp.ClientCType = Convert.ToInt32(this.InPapers.SelectedValue);
                    vp.ClientIDCard = this.InCardID.Text;
                    vp.ClientTel = this.InTel.Text;
                    vp.ClientVipID = this.InVIPID.Text;
                    vp.OperatorID = Values.UserInfo.StaffID;
                    float m = 0; if (float.TryParse(InMoney.Text, out m)) vp.ClientAccount = m;
                    else throw new Exception("输入的预付金额无效！");
                    bool b = false; Functions.ShowMessage("正在发送请求，稍后显示结果！","请稍等...");
                    await Task.Run(() => 
                    {
                        try
                        {
                            b = DLL_BLL.ClientInRoomBLL.InRoom(vp);
                        }
                        catch(Exception ex) { this.Dispatcher.Invoke(()=>Functions.ShowMessage(ex.Message,"发生异常")); }
                    });
                    if (b)
                    {
                        LoadData_ComBox();
                        Functions.ShowMessage("住房信息登记成功，房间状态成功，账户记录操作成功！", "系统提示");
                        ReSetInRoomText();//清空文本
                    }
                }
                catch (Exception ex) { Functions.ShowMessage(ex.Message,"发生错误"); }
            }

            /// <summary>
            /// 清空文本按钮按下
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ReSetInRoomText(object sender, MouseButtonEventArgs e)
            {
                ReSetInRoomText();
            }

            /// <summary>
            /// 清空入住登记的输入文本
            /// </summary>
            public void ReSetInRoomText() 
            {
                try
                {
                    this.InText.Text = ""; this.InCardID.Text = ""; this.InMoney.Text = ""; this.InRoomPrice.Text = "";
                    this.InAdress.Text = ""; this.InText.Text = ""; this.InTel.Text = "";
                    this.InVIPID.Text = ""; this.InRoomID.Text = "";
                }
                catch (Exception ex) { Functions.ShowMessage(ex.Message,"发生错误"); }
            }
            #endregion

            #region 客户换房
            /// <summary>
            /// 客户换房
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ClientRenewal_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    RightPanel.Visibility = Visibility.Visible; RightPanel.SelectedIndex = 1;
                    if (WrapRoomList.SelectedItem != null)
                    {
                        View_RoomInfo ri = WrapRoomList.SelectedItem as View_RoomInfo;
                        //BUG防御
                        if (ri.RoomStateName == "占用房" || ri.RoomStateName == "在住房" || ri.RoomStateName == "满房")
                        {
                            OldRoomID.Text = ri.RoomID; OldRoomPrice.Text = ri.TypePrice.ToString() + "/" + ri.TypeRequency + "小时";
                        }
                    }
                }
                catch (Exception ex) { Functions.ShowMessage(ex.Message,"出现异常"); }
            }

            /// <summary>
            /// 提交换房
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private async void SubRenewal_Click(object sender, MouseButtonEventArgs e)
            {
                try
                {
                    if (NewRoomID.Text.Length < 1) return;
                    string oldroom = OldRoomID.Text; string newroomid = NewRoomID.Text; bool b = false;
                    await Task.Run(() => 
                    {
                        try
                        {
                            b = DLL_BLL.View_ClientRoomState_BLL.Proc_RoomChange(Values.UserInfo.StaffID, oldroom, newroomid);
                        }
                        catch (Exception ex) { this.Dispatcher.Invoke(() => Functions.ShowMessage(ex.Message, "发生异常")); }
                    });
                    if (b) 
                    {
                        LoadData_ComBox(); 
                        RightPanel.SelectedIndex = 0; RightPanel.Visibility = Visibility.Collapsed;
                        Functions.ShowMessage("房间切换成功，原"+OldRoomID.Text+"已换到"+NewRoomID.Text,"操作成功");
                        ResetSubRenewalText();//清空文本
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"出现错误");
                }
            }
            public void ResetSubRenewalText()
            {
                OldRoomID.Text = ""; OldRoomPrice.Text = "";
                NewRoomID.Text = ""; NewRoomPrice.Text = "";
            }
            #endregion

            /// <summary>
            /// 账务查询
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ClientBill_Click(object sender, RoutedEventArgs e)
            {

            }

            #region 房间预订
            /// <summary>
            /// 房间预订
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void RoomBook_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    if (WrapRoomList.SelectedItem != null) 
                    {
                        View_RoomInfo ri = WrapRoomList.SelectedItem as View_RoomInfo;
                        if (ri == null) Functions.ShowMessage("所选的项是无效项，无法进行此操作", "操作失败");
                        else if (ri.RoomStateName != "空房") Functions.ShowMessage("此操作只能对空房有效，请鼠标右键单击一个空房图标选择‘预订’操作！", "选择无效");
                        else
                        {
                            BookRoomID.Text = ri.RoomID;
                            RightPanel.Visibility = Visibility.Visible;
                            RightPanel.SelectedIndex = 4;
                        }
                    }
                }
                catch (Exception ex) { Functions.ShowMessage(ex.Message,"出现错误"); }
            }

            /// <summary>
            /// 重设预订信息
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ReSetBookRoomText(object sender, MouseButtonEventArgs e)
            {
                try
                {
                    BookRoomID.Text = "";
                    BookTime.Text = ""; BookText.Text = "";
                }
                catch { }
            }

            /// <summary>
            /// 确定预订
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private async void SubBookRoom_Click(object sender, MouseButtonEventArgs e)
            {
                try
                {
                    int days = 0;
                    if (int.TryParse(BookTime.Text, out days))
                    {
                        string name = BookText.Text; string roomid = BookRoomID.Text;
                        if (name.Length < 1 || roomid.Length < 1)
                        {
                            Functions.ShowMessage("预订房间号和客户姓名都是必选参数，不能留空！", "无效参数");
                        }
                        else
                        {
                            Functions.ShowMessage("等待数据库响应，稍后显示处理结果！","正在处理");
                            await Task.Run(() => 
                            {
                                try
                                {
                                    bool b= DLL_BLL.View_ClientRoomState_BLL.Proc_BookRoom(name, roomid, days);
                                    this.Dispatcher.Invoke(() =>
                                    {
                                        if (b)
                                        {
                                            Functions.ShowMessage("客户预订信息已成功等登记!", "操作成功"); ReSetBookRoomText(null,null);
                                            LoadData_ComBox(); RightPanel.Visibility = Visibility.Collapsed; RightPanel.SelectedIndex = 0;
                                        }
                                        else Functions.ShowMessage("因为操作过程中没有报出任何错误，同时没有操作成功提示，因此无法确认操作结果，请手工检测一下吧！", "结果未知");
                                        LoadData_ComBox();
                                    });
                                }
                                catch(Exception ex)
                                {
                                    this.Dispatcher.Invoke(() => 
                                    {
                                        Functions.ShowMessage(ex.Message,"发生异常");
                                    });
                                }
                            });
                        }
                    }
                    else Functions.ShowMessage("输入的预订有效天数无效，请输入一个整数。如：5","输入无效");
                }
                catch (Exception ex) { Functions.ShowMessage(ex.Message,"出现错误"); }
            }


            /// <summary>
            /// 预订房间的客户正式入住 点击功能
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private async void BookClientIn_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    if (WrapRoomList.SelectedItem == null) return;
                    View_RoomInfo ri = WrapRoomList.SelectedItem as View_RoomInfo;
                    //错误防御
                    if (ri.RoomStateName != "预订") throw new Exception("所选房间不是一个预订中的房间，无法进行此操作！");
                    else
                    {
                        RightPanel.Visibility = Visibility.Visible; RightPanel.SelectedIndex = 6;//显示房间登记页面
                        List<T_PaperType> TP = new List<T_PaperType>();
                        await Task.Run(() =>
                        {
                            try
                            {
                                TP = DLL_BLL.PapersTypeBLL.DataLoad(true);
                            }
                            catch (Exception ex)
                            {
                                this.Dispatcher.Invoke(() => Functions.ShowMessage(ex.Message, "发生异常"));
                            }
                        });
                        this.BookInPapers.DataContext = TP;//重新加载证件类型数据
                        BookInRoomID.Text = ri.RoomID;//获得房号
                        BookInRoomPrice.Text = ri.TypePrice + "/" + ri.TypeRequency + "小时";//显示该房间的计费情况
                        string clientName = "";
                        await Task.Run(() =>
                        {
                            try
                            {
                                clientName = DLL_BLL.View_ClientRoomState_BLL.BookClientName(ri.RoomID);
                            }
                            catch (Exception ex)
                            {
                                this.Dispatcher.Invoke(() => Functions.ShowMessage(ex.Message, "发生异常"));
                            }
                        });
                        this.BookInText.Text = clientName;
                    }
                }
                catch (Exception ex) { Functions.ShowMessage(ex.Message, "遇到错误"); }
            }

            /// <summary>
            /// 清除预订房间客户入住信息
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ReSetBookInText(object sender, MouseButtonEventArgs e)
            {
                ReSetBookInText();
            }

            /// <summary>
            /// 预订客户正式入住 提交
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private async void SubBookIn_Click(object sender, MouseButtonEventArgs e)
            {
                try
                {
                    View_ProcClientIn vp = new View_ProcClientIn();
                    vp.ClientIName = this.BookInText.Text;
                    vp.RoomID = this.BookInRoomID.Text;
                    vp.ClientSex = this.BookSex1.IsChecked == true ? true : false;
                    vp.ClientAdress = this.BookInAdress.Text;
                    vp.ClientCType = Convert.ToInt32(this.BookInPapers.SelectedValue);
                    vp.ClientIDCard = this.BookInCardID.Text;
                    vp.ClientTel = this.BookInTel.Text;
                    vp.ClientVipID = this.BookInVIPID.Text;
                    vp.OperatorID = Values.UserInfo.StaffID;
                    float m = 0; if (float.TryParse(BookInMoney.Text, out m)) vp.ClientAccount = m;
                    else throw new Exception("输入的预付金额无效！");
                    bool b = false; Functions.ShowMessage("正在发送请求，稍后显示结果！", "请稍等...");
                    await Task.Run(() =>
                    {
                        try
                        {
                            b = DLL_BLL.ClientInRoomBLL.BookInRoom(vp);
                        }
                        catch (Exception ex) { this.Dispatcher.Invoke(() => Functions.ShowMessage(ex.Message, "发生异常")); }
                    });
                    if (b)
                    {
                        LoadData_ComBox(); RightPanel.Visibility = Visibility.Collapsed; RightPanel.SelectedIndex = 0;
                        Functions.ShowMessage("住房信息登记成功，房间状态成功，账户记录操作成功！", "系统提示");
                        ReSetBookInText();//清空文本
                    }
                }
                catch (Exception ex) { Functions.ShowMessage(ex.Message, "发生错误"); }
            }

            /// <summary>
            /// 清空预订客户入住登记的输入文本
            /// </summary>
            public void ReSetBookInText()
            {
                try
                {
                    RightPanel.SelectedIndex = 0; RightPanel.Visibility = Visibility.Collapsed;
                    this.BookInText.Text = ""; this.BookInCardID.Text = ""; this.BookInMoney.Text = "";
                    this.BookInAdress.Text = ""; this.BookInText.Text = ""; this.BookInTel.Text = "";
                    this.BookInVIPID.Text = ""; this.BookInRoomID.Text = "";
                }
                catch (Exception ex) { Functions.ShowMessage(ex.Message, "发生错误"); }
            }


            /// <summary>
            /// 取消房间预订
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private async void EixtBook_Click(object sender, RoutedEventArgs e)
            {
                if (Functions.Show_Question("此操作无法撤销，确定要取消该客户的房间预订吗？", "操作确认")==true)
                if (WrapRoomList.SelectedItem != null)
                {
                    View_RoomInfo ri = WrapRoomList.SelectedItem as View_RoomInfo;
                    if (ri != null && ri.RoomStateName != null)
                    {
                        if (ri.RoomStateName != "预订") Functions.ShowMessage("所选的房间不是一个已经被预订的房间，无法进行此操作！", "选择无效");
                        else
                        {
                            await Task.Run(() =>
                            {
                                try
                                {
                                    bool b = DLL_BLL.ClientInRoomBLL.EixtBook(ri.RoomID);
                                    this.Dispatcher.Invoke(() =>
                                    {
                                        if (b) Functions.ShowMessage("已成功取消客户预订的房间信息！", "操作成功");
                                        else Functions.ShowMessage("因为操作过程中没有报出任何错误，同时没有操作成功提示，因此无法确认操作结果，请手工检测一下吧！","结果未知");
                                        LoadData_ComBox();
                                    });
                                }
                                catch (Exception ex) 
                                {
                                    this.Dispatcher.Invoke(() => 
                                    {
                                        Functions.ShowMessage(ex.Message,"发生异常");
                                    });
                                }
                            });
                        }
                    }
                    else Functions.ShowMessage("在房间列表中所选项目无效！","选择无效");
                }
            }

            #endregion

            #region 续交房费
            /// <summary>
            /// 续交房费
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private async void ClientPay_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    if (WrapRoomList.SelectedItem != null)
                    {
                        View_RoomInfo vr = WrapRoomList.SelectedItem as View_RoomInfo;
                        this.UpRoomID.Text = vr.RoomID;
                        View_ClientRoomState vc = new View_ClientRoomState();
                        await Task.Run(() =>
                        {
                            try
                            {
                                vc = DLL_BLL.View_ClientRoomState_BLL.LoadData(vr.RoomID);
                            }
                            catch (Exception ex) { this.Dispatcher.Invoke(() => Functions.ShowMessage(ex.Message, "发生异常")); }
                        });
                        this.UpClientName.Text = vc.ClientName;
                        this.UpGUID.Text = vc.DataGUID;
                        this.UpAccountO.Text = vc.ClientAccount.ToString();
                        this.UpTime.Text = vc.InRoomTime.ToString();
                        this.LastDeduct.Text = vc.LastDeduct.ToString();
                        RightPanel.Visibility = Visibility.Visible; RightPanel.SelectedIndex = 2;
                    }
                }
                catch (Exception ex) 
                {
                    Functions.ShowMessage(ex.Message,"出现错误");
                }
            }

            /// <summary>
            /// 续交房费提交
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private async void ClientPay_SubMit(object sender, MouseButtonEventArgs e)
            {
                try
                {
                    double m = 0;string guid =UpGUID.Text;
                    if (double.TryParse(UpAccountA.Text, out m))
                    {
                        bool b = false;
                        await Task.Run(()=>
                        {
                            try { b = DLL_BLL.View_ClientRoomState_BLL.SetClientAccount(guid, m); }
                            catch (Exception ex)
                            {
                                this.Dispatcher.Invoke(()=>Functions.ShowMessage(ex.Message, "发生异常"));
                            }
                        });
                        if (b)
                        {
                            RightPanel.Visibility = Visibility.Collapsed; RightPanel.SelectedIndex = 0;
                            this.UpGUID.Text = "";
                            this.UpAccountA.Text = "";
                            this.UpClientName.Text = "";
                            Functions.ShowMessage("成功向房间号 " + UpRoomID.Text + " 的客户账户交费" + UpAccountA.Text + "元。", "操作成功");
                        }
                    }
                    else
                    {
                        Functions.ShowMessage("输入的金额指无法转换为有效的数字，请重新输入！", "输入无效");
                    }
                }
                catch (Exception ex) 
                {
                    Functions.ShowMessage(ex.Message, "出现错误");
                }
            }
            #endregion

            #region 客户退房
            /// <summary>
            /// 客户退房
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private async void ClientOut_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    if (WrapRoomList.SelectedItem != null)
                    {
                        View_RoomInfo vr = WrapRoomList.SelectedItem as View_RoomInfo;
                        if (vr.RoomStateName != "占用房" && vr.RoomStateName != "在住房" && vr.RoomStateName != "满房") 
                            throw new Exception("所选房间无法进行退房操作，因为并没有人住。请将此错误汇报给开发者！");
                        this.OutRoomID.Text = vr.RoomID;
                        View_ClientRoomState vc = new View_ClientRoomState();
                        await Task.Run(() =>
                        {
                            try
                            {
                                vc = DLL_BLL.View_ClientRoomState_BLL.LoadData(vr.RoomID);
                            }
                            catch (Exception ex)
                            {
                                this.Dispatcher.Invoke(()=> Functions.ShowMessage(ex.Message, "出现异常"));
                            }
                        });
                        this.OutClientName.Text = vc.ClientName;
                        this.OutGUID.Text = vc.DataGUID;
                        this.OutAccountO.Text = vc.ClientAccount.ToString();
                        this.OutInTime.Text = vc.InRoomTime.ToString();
                        this.OutLastDeduct.Text = vc.LastDeduct.ToString();
                        RightPanel.Visibility = Visibility.Visible; RightPanel.SelectedIndex = 3;
                    }
                }
                catch (Exception ex)
                {
                    Functions.ShowMessage(ex.Message, "出现错误");
                }
            }

            /// <summary>
            /// 客户退房确认
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private async void ClientOut_SubMit(object sender, MouseButtonEventArgs e)
            {
                try
                {
                    if (Functions.Show_Question("此操作一经确认无法撤销，确定要进行此操作吗？","确定退房") ==true)
                    {
                        string outroomid = OutRoomID.Text;
                        bool b = false;
                        await Task.Run(() => 
                        {
                            try
                            {
                                b = DLL_BLL.View_ClientRoomState_BLL.ClientExitRoom(outroomid, Values.UserInfo.StaffID);
                            }
                            catch (Exception ex) { this.Dispatcher.Invoke(() => Functions.ShowMessage(ex.Message, "异常发生")); }
                        });
                        if (b)
                        {
                            Functions.ShowMessageAndToList("房间" + OutRoomID.Text + "的客户已成功退房，结账时客户账户余额：" + OutAccountO.Text + "元", "系统提示", true); 
                            LoadData_ComBox();//重新加载数据
                            ResetOutRoomText();//清空文本
                            RightPanel.Visibility = Visibility.Collapsed; RightPanel.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        RightPanel.Visibility = Visibility.Collapsed; RightPanel.SelectedIndex = 0;
                        Functions.ShowMessage("操作没有被确认，退房操作取消！", "操作取消");
                    }
                }
                catch (Exception ex)
                {
                    Functions.ShowMessage(ex.Message,"出现错误");
                }
            }
            
            /// <summary>
            /// 清空文本
            /// </summary>
            public void ResetOutRoomText() 
            {
                this.OutGUID.Text = ""; this.OutInTime.Text = ""; this.OutLastDeduct.Text = ""; this.OutRoomID.Text = "";
                this.OutAccountO.Text = ""; this.OutClientName.Text = "";
            }

            #endregion

            #region 房间状态修改
            /// <summary>
            /// 修改房间状态
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private async void StateSet_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    RightPanel.Visibility = Visibility.Visible; RightPanel.SelectedIndex = 5;
                    View_RoomInfo vr = WrapRoomList.SelectedItem as View_RoomInfo;
                    this.SetRoomID.Text = vr.RoomID;
                    List<T_RoomStateType> RT = new List<T_RoomStateType>();
                    await Task.Run(() => 
                    {
                        try { RT=DLL_BLL.RoomStateTypeBLL.DataLoad(true); }
                        catch (Exception ex) { this.Dispatcher.Invoke(() => { Functions.ShowMessage(ex.Message,"发生异常"); }); }
                    });
                    SetRoomState.DataContext = RT;
                    SetRoomState.Text = vr.RoomStateName;
                }
                catch (Exception ex) 
                {
                    Functions.ShowMessage(ex.Message,"出现错误");
                }
            }

            /// <summary>
            /// 修改房间状态 提交
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private async void SubSetRoomState_Click(object sender, MouseButtonEventArgs e)
            {
                try
                {
                    if (SetRoomState.SelectedValue != null)
                    {
                        int RoomState = (int)SetRoomState.SelectedValue; string roomID = this.SetRoomID.Text;
                        bool b = false;
                        await Task.Run(() => 
                        {
                            try
                            {
                                b = DLL_BLL.RoomListBLL.UpdateSetState(RoomState, roomID);
                            }
                            catch (Exception ex) { this.Dispatcher.Invoke(() => Functions.ShowMessage(ex.Message,"异常发生")); }
                        });
                        if (b)
                        {
                            LoadData_ComBox(); RightPanel.Visibility = Visibility.Collapsed; RightPanel.SelectedIndex = 0;
                            Functions.ShowMessage("房间状态已修改完成！", "修改完成");
                            this.SetRoomID.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Functions.ShowMessage(ex.Message,"出现异常");
                }
            }
            #endregion

        #endregion


        /// <summary>
        /// 返回主菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnTo_MainMenu(object sender, MouseButtonEventArgs e)
        {
            if (Delegates.ToPageIndex != null) { Delegates.ToPageIndex (0); }
        }

        /// <summary>
        /// 返回房间列表页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnTo_RoomList(object sender, MouseButtonEventArgs e)
        {
            MainTab.SelectedIndex = 0;            
        }

        /// <summary>
        /// 打开说明页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToHelpPage(object sender, MouseButtonEventArgs e)
        {
            MainTab.SelectedIndex = 1;
        }
    }
}
