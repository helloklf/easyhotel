using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace DllSettingPanel
{
    /// <summary>
    /// Setting_Page.xaml 的交互逻辑
    /// </summary>
    public partial class Setting_Page : UserControl
    {
        public Setting_Page()
        {
            InitializeComponent();
            Use_Setting();//设置初始化器
            SettingPanel.DataContext = SettingListIndex.Index;
        }

        #region 对话框选项卡切换
        /// <summary>
        /// 对话框导航列表选择改变
        /// </summary>
        /// <param name="t"></param>
        private void SetColor(TextBlock t)
        {
            DockPanel P = (DockPanel)t.Parent;
            foreach (TextBlock item in P.Children)
            {
                if (item.Name != t.Name)
                {
                    item.Background = null;
                    item.Opacity = 0.6;
                    item.Foreground = BGSET.ForeColor;
                }
            }
            t.Opacity = 1;
            t.Foreground = BGSET.BgColor;
            t.Background = BGSET.ForeColor;
        }
        #endregion

        #region 背景图片设置
            /// <summary>
            /// 使用背景图片
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void Use_BackGroundImage()
            {
                string Url = BGSET.BgImage;
                if (Url != null)
                {
                    try
                    {
                        ImageBrush bi = new ImageBrush(new BitmapImage(new Uri(Url)));
                        bi.Stretch = Stretch.UniformToFill;
                        Values.SurfaceSetting.BgImage = bi;
                    }
                    catch { BGSET.BgImage = null; }
                }
            }
        #endregion

        /// <summary>
        /// 常用字体大小
        /// </summary>
        List<int> FontSize_List = new List<int>() { 35, 25, 20, 15, 13, 11 };

        #region 设置初始化器

        /// <summary>
        /// 基本外观配置信息
        /// </summary>
        DllSetting.AppSurface BGSET = Values.SurfaceSetting.Surface;

        int error = 0;
        private async void Use_Setting()
        {
            try
            {
                DllSetting.StartWindowSettings_String set = null;
                await Task.Run(() =>
                {
                    set = DllSetting.StartWindowSetting.Load();
                }); //后台读取配置文件
                BGSET.ForeColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(set.ForeC));
                BGSET.BgColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(set.BgC));
                BGSET.Overallview = set.Overallview;
                BGSET.WhiteICON = set.WhiteICON;
                BGSET.Transparent = set.Transparent;
                BGSET.MessageTime = set.MessageTime;
                try
                {
                    BGSET.BgImage = set.BgImage;
                    Use_BackGroundImage();
                }
                catch { }
            }
            catch
            {
                if (error < 3)
                {
                    DllSetting.Values.CreateSetting(true);
                    MessageBox.Show("首次启动或外观存档损坏。\r\n系统已为你创建新的外观存档！");
                    Use_Setting();//递归重新读取存档文件
                }
                else //当错误次数超过3次
                {
                    MessageBox.Show("错误无法修正，请将此错误报告给开发者！");
                }
                error++;
            }
        }
        
        #endregion

        #region 控件加载


        #region 加载完毕
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Use_Setting();//加载设置档
            Use_BackGroundImage();//设置程序背景
            C.DataContext = Values.SurfaceSetting.Surface;
        }
        #endregion

        #endregion

        #region 等待实现
        /// <summary>
        /// 暂不实现的窗体移动功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiniPage_Mouse(object sender, MouseEventArgs e)
        {
            //? 窗口拖动
        }
        #endregion

    }
}
