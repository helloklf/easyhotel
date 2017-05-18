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
        public RoomList()
        {
            InitializeComponent();
            SetDelegates();//设置委托方法
            Project_Term2_BaseData.BaseDataDelegates.MainDelegate += new Project_Term2_BaseData.NotParameter(ReLoadData);
            ReLoadData();
        }

        List<View_RoomInfo> Rooms = new List<View_RoomInfo>();
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //ReLoadData();
        }

        /// <summary>
        /// 处理数据读取请求的方法，一个Int型参数表示操作类型。0：读取所有有效数据，1：按房间类型过滤数据，2：按房间状态过滤数据，3：按搜索方式
        /// </summary>
        /// <param name="ReadType"></param>
        public async void GetData(int ReadType)
        {
            try
            {
                if (ReadType != 4)
                {
                    await Task.Run(() =>
                    {
                        try
                        {
                            if (ReadType == 0)
                            {
                                Rooms = RoomListBLL.DataLoad();
                            }
                            else if (ReadType == 1) //1：按房间类型过滤数据
                            {
                                int id = 0;
                                this.Dispatcher.Invoke(() => id = Convert.ToInt32(ComRoomType.SelectedValue));
                                Rooms = DLL_BLL.RoomListBLL.GetRoom_ForTID(id);
                            }
                            else if (ReadType == 2) //2：按房间状态过滤数据
                            {
                                int id = 0;
                                this.Dispatcher.Invoke(() => id = Convert.ToInt32(ComRoomState.SelectedValue));
                                Rooms = DLL_BLL.RoomListBLL.GetRoom_ForSID(id);
                            }
                            else if (ReadType == 3) //3：多重条件过滤
                            {
                                int type = 0; int state = 0;
                                this.Dispatcher.Invoke(() => 
                                { type = Convert.ToInt32(ComRoomType.SelectedValue); state = Convert.ToInt32(ComRoomState.SelectedValue); });
                                Rooms = DLL_BLL.RoomListBLL.GetRoom_ForID(type, state);
                            }
                        }
                        catch (Exception ex) { this.Dispatcher.Invoke(() => Functions.ShowMessage(ex.Message,"异常发生")); }
                    });
                }
                #region 搜索
                else if (ReadType == 4)//4：按搜索方式
                {
                    string text = InputSeachText.Text; 
                    if (text.Length < 1) { Functions.ShowMessage("起码应该输入一个字符！", "参数过短"); return; }
                    string header = SearchType.Header.ToString();
                    await Task.Run(() =>
                    {
                        try
                        {
                            //房号搜索
                            if (header == "按房号")
                            {
                                Rooms = DLL_BLL.RoomListBLL.GetRoom_ForRoomID(text);
                            }

                            //类型搜索
                            else if (header == "按类型")
                            {
                                Rooms = DLL_BLL.RoomListBLL.GetRoom_ForTName(text);
                            }

                            //状态搜索
                            else if (header == "按状态")
                            {
                                Rooms = DLL_BLL.RoomListBLL.GetRoom_ForSName(text);
                            }

                            //价格搜索
                            else if (header == "按价格")
                            {
                                int value;
                                if (int.TryParse(text, out value))
                                {
                                    Rooms = DLL_BLL.RoomListBLL.GetRoom_ForPrice(value);
                                }
                                else Functions.ShowMessage(Other.InfoText.RoomSeacheNoPrice, "不是整数");
                            }

                            //时长搜索
                            else if (header == "按时长")
                            {
                                int value;
                                if (int.TryParse(text, out value))
                                {
                                    Rooms = DLL_BLL.RoomListBLL.GetRoom_ForTime(value);
                                }
                                else Functions.ShowMessage(Other.InfoText.RoomSeachNotInt, "不是整数");
                            }
                        }
                        catch (Exception ex) { this.Dispatcher.Invoke(() => Functions.ShowMessage(ex.Message,"异常发生")); }
                    });
                }
                WrapRoomList.DataContext = Rooms;
                #endregion
            }
            catch (Exception ex) { Functions.ShowMessage(ex.Message, "发生错误"); }
        }


        /// <summary>
        /// 数据重载
        /// </summary>
        public async void ReLoadData()
        {
            try
            {
                this.C.DataContext = Values.SurfaceSetting.Surface;
                List<T_RoomType> RT = new List<T_RoomType>();
                List<T_RoomStateType> ST = new List<T_RoomStateType>(); ;
                await Task.Run(() =>
                {
                    try
                    {
                        RT = DLL_BLL.RoomTypeBLL.DataLoad(true);
                        ST = DLL_BLL.RoomStateTypeBLL.DataLoad(true);
                    }
                    catch (Exception ex)
                    {
                        this.Dispatcher.Invoke(() => Functions.ShowMessage(ex.Message, "发生异常"));
                    }
                });
                ComRoomState.ItemsSource = ST;if(ComRoomState.SelectedValue==null) ComRoomState.SelectedIndex = 0;
                ComRoomType.ItemsSource = RT; if (ComRoomType.SelectedValue == null) ComRoomType.SelectedIndex = 0;
                LoadData_ComBox();
            }
            catch (Exception ex) { Functions.ShowMessage(ex.Message, "系统异常"); }
        }
    }
}
