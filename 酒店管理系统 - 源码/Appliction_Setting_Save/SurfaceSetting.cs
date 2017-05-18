using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;

namespace DllSetting
{
    #region 基本的外观信息类
    /// <summary>
    /// 简单设置：包括字体色、背景色、背景图片
    /// </summary>
    public class AppSurface:INotifyPropertyChanged
    {
        public SolidColorBrush foreColor;
        /// <summary>
        /// 字体色
        /// </summary>
        public SolidColorBrush ForeColor
        {
            get 
            {
                if (foreColor == null) foreColor = new SolidColorBrush(Colors.Black);
                return foreColor; }
            set { foreColor = value; Changed("ForeColor"); }
        }

        public SolidColorBrush FColor { get { return bgColor; } }

        private bool transparent = false;
        public bool Transparent
        {
            get { return transparent; }
            set { transparent = value; Changed("BgColor"); Changed("ForeColor"); Changed("FColor"); }
        }

        public SolidColorBrush bgColor;
        /// <summary>
        /// 背景色
        /// </summary>
        public SolidColorBrush BgColor
        {
            get
            {
                if (foreColor == null) foreColor = new SolidColorBrush(Colors.White);
                else if (transparent == true && bgColor!=null) 
                {
                    Color c = bgColor.Color; c.A = 70;
                    SolidColorBrush sb = new SolidColorBrush(c);
                    return sb;
                }
                return bgColor;
            }
            set { bgColor = value; Changed("BgColor"); Changed("FColor"); }
        }

        private string bgimage;
        /// <summary>
        /// 背景图片(路径)
        /// </summary>
        public string BgImage
        {
            get { return bgimage; }
            set { bgimage = value; Changed("BgImage"); }
        }


        bool overallview = true;
        /// <summary>
        /// 视窗模式：true表示沉浸模式、false表示标准模式
        /// </summary>
        public bool Overallview
        {
            get { return overallview; }
            set { overallview = value; Changed("Overallview"); }
        }

        bool whiteICON = true;
        /// <summary>
        /// 白色的图标:True表示白色，false表示黑色
        /// </summary>
        public bool WhiteICON
        {
            get { return whiteICON; }
            set { whiteICON = value; Changed("WhiteICON"); }
        }

        /// <summary>
        /// 消息显示秒数-0表示一直显示
        /// </summary>
        public int MessageTime=5;

        public bool MessageAutoCler
        {
            get { if (MessageTime != 0) return true; return false; }
        }

        /// <summary>
        /// 触发器
        /// </summary>
        /// <param name="name"></param>
        public void Changed(string name)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(name)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    #endregion

    #region 可以用于序列化的外观类
    /// <summary>
    /// 简单设置：用于持久化设置的字符串形式设置数据
    /// </summary>
    [Serializable]
    public class StartWindowSettings_String
    {
        public string ForeC;//字体色
        public string BgC;//背景色
        public bool Transparent;
        public string BgImage;//背景图片
        public List<int> FontSize;//字体大小
        public bool Overallview;//全景模式
        public bool WhiteICON;//白色图标
        public int MessageTime = 5;//消息显示秒数-0表示一直显示
    }
    #endregion

    /// <summary>
    /// 读取和保存基本外观设置
    /// </summary>
    public class StartWindowSetting
    {
        #region 保存外观设置文件
        /// <summary>
        /// 保存外观设置文件
        /// </summary>
        /// <param name="s_"></param>
        /// <returns></returns>
        public static bool Save(AppSurface s_)
        {
            try
            {
                using (FileStream fs = new FileStream("Setting.xml", FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    StartWindowSettings_String SetString = new StartWindowSettings_String();
                    SetString.BgImage =s_.BgImage;//背景图片路径
                    SetString.BgC = s_.bgColor.ToString();//背景色
                    SetString.Transparent = s_.Transparent;//使用透明
                    SetString.ForeC = s_.foreColor.ToString();//前景色
                    SetString.Overallview = s_.Overallview;//是否全景模式
                    SetString.WhiteICON = s_.WhiteICON;//是否使用白色图标
                    SetString.MessageTime = s_.MessageTime;//消息显示时间
                    XmlSerializer Xml = new XmlSerializer(SetString.GetType());//序列化
                    Xml.Serialize(fs,SetString);
                }
                return true;
            }
            catch { return false; }
        }
        #endregion

        #region 读取基本外观设置
        /// <summary>
        /// 读取外观设置文件
        /// </summary>
        /// <returns></returns>
        public static StartWindowSettings_String Load()
        {
            try
            {
                using (FileStream fs = new FileStream("Setting.xml", FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
                {
                    XmlSerializer Xml = new XmlSerializer(typeof(StartWindowSettings_String));
                    StartWindowSettings_String settings = (StartWindowSettings_String)Xml.Deserialize(fs);
                    return settings;
                }
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }








    #region 基本外观
    /// <summary>
    /// 应用程序设定
    /// </summary>
    public class ApplictionSurface : INotifyPropertyChanged
    {
        private DllSetting.AppSurface surface = new DllSetting.AppSurface();
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

    /// <summary>
    /// 全局共享的属性值
    /// </summary>
    public static class Values
    {
        /// <summary>
        /// 基本外观
        /// </summary>
        public static DllSetting.ApplictionSurface SurfaceSetting = new DllSetting.ApplictionSurface();

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
                    SurfaceSetting.Surface.BgImage = System.Windows.Forms.Application.StartupPath + "\\DefaultBackground.jpg";//默认背景图片
                    if (File.Exists(SurfaceSetting.Surface.BgImage))
                    {
                        SurfaceSetting.Surface.Transparent = true;//透明
                    }
                }
                DllSetting.StartWindowSetting.Save(SurfaceSetting.Surface);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + "\r\n实验性功能出现异常，在保存应用程序时出现严重错误！"); }
        }
    }
}
