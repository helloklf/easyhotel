using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using TModel;
using System.IO;

namespace Project_Term2
{
    /// <summary>
    /// 全局共享的属性值
    /// </summary>
    public static class Values
    {
        /// <summary>
        /// 基本外观
        /// </summary>
        public static DllSetting.ApplictionSurface SurfaceSetting = DllSetting.Values.SurfaceSetting;
        
        /// <summary>
        ///在线用户信息 
        /// </summary>
        public static View_UserInfo UserInfo = new View_UserInfo();

        /// <summary>
        /// 创建新设定
        /// </summary>
        public static void CreateSetting(bool CreatNew)
        {
            try
            {
                if (CreatNew)
                {
                    SurfaceSetting.Surface = new DllSetting.AppSurface();
                    SurfaceSetting.Surface.ForeColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8B0000"));
                    SurfaceSetting.Surface.BgColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFE4C4"));
                    SurfaceSetting.Surface.BgImage = System.Windows.Forms.Application.StartupPath+"\\DefaultBackground.jpg";//默认背景图片
                    if (File.Exists(SurfaceSetting.Surface.BgImage))
                    {
                        SurfaceSetting.Surface.Transparent = true;//透明
                    }
                }
                DllSetting.StartWindowSetting.Save(SurfaceSetting.Surface);
            }
            catch (Exception ex) {MessageBox.Show(ex.Message + "\r\n实验性功能出现异常，在保存应用程序时出现严重错误！"); }
        }

        /// <summary>
        /// 页面显示状态
        /// </summary>
        public static PageState PageStates = new PageState();
    }

    #region 基本外观
    /// <summary>
    /// 应用程序设定
    /// </summary>
    public class ApplictionSurface : INotifyPropertyChanged 
    {
        private DllSetting.AppSurface surface= new DllSetting.AppSurface();
        /// <summary>
        /// 色彩
        /// </summary>
        public DllSetting.AppSurface Surface
        {
            get { return surface; }
            set { surface = value; if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs("BGSET")); } }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private ImageBrush bgImage = new ImageBrush();
        /// <summary>
        /// 背景图片
        /// </summary>
        public ImageBrush BgImage
        {
            get { return bgImage; }
            set { bgImage = value; PropertyChanged(this, new PropertyChangedEventArgs("BgImage")); }
        }
    }
    #endregion


    #region 小窗口显示状态
    public class PageState:INotifyPropertyChanged
    {
        Visibility setting = Visibility.Collapsed;
        /// <summary>
        /// 设置页
        /// </summary>
        public Visibility Setting
        {
            get { return setting; }
            set { setting = value; Changed("Setting"); }
        }

        /// <summary>
        /// 用户页
        /// </summary>
        Visibility userCenter = Visibility.Collapsed;
        public Visibility UserCenter
        {
            get { return userCenter; }
            set { userCenter = value; Changed("UserCenter"); }
        }


        /// <summary>
        /// 用户页：Message
        /// </summary>
        Visibility userMessage = Visibility.Collapsed;
        public Visibility UserMessage
        {
            get { return userMessage; }
            set { userMessage = value; Changed("UserMessage"); }
        }

        /// <summary>
        /// 用户页：Message
        /// </summary>
        Visibility userLogin = Visibility.Collapsed;
        public Visibility UserLogin
        {
            get { return userLogin; }
            set { userLogin = value; Changed("UserMessage"); }
        }

        public void Changed(string s)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(s)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    #endregion
}
