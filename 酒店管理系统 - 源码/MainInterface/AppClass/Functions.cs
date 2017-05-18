using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Term2.Properties;

namespace Project_Term2
{
    public class Functions
    {
        #region 本地方案
        ///// <summary>
        ///// 一个用于显示消息文本的方法，参数1：消息文本，参数2：消息标题
        ///// </summary>
        ///// <param name="txt"></param>
        ///// <param name="title"></param>
        ///// <returns></returns>
        //public static bool ShowMessage(string txt, string title = "")
        //{
        //    try
        //    {
        //        if (Values.SurfaceSetting.Surface.Overallview)
        //        {
        //            Project_Term2.Page_MessageBox.P_MessageBox pm = new Project_Term2.Page_MessageBox.P_MessageBox(title + "：" + txt); Delegates.AddChildren_(pm);
        //        }
        //        else
        //        {
        //            Project_Term2.Page_MessageBox.W_Message wm = new Project_Term2.Page_MessageBox.W_Message(txt, title); wm.ShowDialog();
        //        }
        //        return true;
        //    }
        //    catch { return false; }
        //}

        ///// <summary>
        ///// 一个用于显示消息文本并添加到通知列表的的方法，参数1：消息文本，参数2：消息标题
        ///// </summary>
        ///// <param name="txt"></param>
        ///// <param name="title"></param>
        ///// <returns></returns>
        //public static bool ShowMessageAndToList(string txt, string title = "", bool issys = false)
        //{
        //    try
        //    {
        //        if (Values.SurfaceSetting.Surface.Overallview)
        //        {
        //            Project_Term2.Page_MessageBox.P_MessageBox pm = new Project_Term2.Page_MessageBox.P_MessageBox(title + "：" + txt); Delegates.AddChildren_(pm);
        //        }
        //        else
        //        {
        //            Project_Term2.Page_MessageBox.W_Message wm = new Project_Term2.Page_MessageBox.W_Message(txt, title); wm.ShowDialog();
        //        }
        //        if (!issys) AddMessageOther(txt, title); else AddMessageSys(txt, title);
        //        return true;
        //    }
        //    catch { return false; }
        //}
        #endregion

        #region 全局方案
        /// <summary>
        /// 一个用于显示消息文本的方法，参数1：消息文本，参数2：消息标题
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static bool ShowMessage(string txt, string title = "消息提示")
        {
            try
            {
                Inform.Functions.ShowMessage(txt,title);
                return true;
            }
            catch { return false; }
        }


        
        /// <summary>
        /// 显示提问框
        /// </summary>
        /// <returns></returns>
        public static bool? Show_Question(string txt, string title = "消息")
        {
            return Inform.Functions.Show_Question(txt, title);
        }

        /// <summary>
        /// 一个用于显示消息文本并添加到通知列表的的方法，参数1：消息文本，参数2：消息标题
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static bool ShowMessageAndToList(string txt, string title = "", bool issys = false)
        {
            try
            {
                Inform.Functions.ShowMessage(txt, title);
                if (!issys) AddMessageOther(txt, title); else AddMessageSys(txt, title);
                return true;
            }
            catch { return false; }
        }
        #endregion


        /// <summary>
        /// 向消息中心添加用户级消息文本
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static bool AddMessageOther(string txt, string from="基本提示")
        {
            try
            {
                UserPage.OtherMessage m = new UserPage.OtherMessage();
                m.MessageText = txt;
                m.MessageFrom = from;
                UserPage.ApplcitionMessage.list.OtherMessages.Add(m);
                UserPage.ApplcitionMessage.list.SMCount = 0;
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// 向消息中心添加系统级消息文本
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static bool AddMessageSys(string txt, string from="系统警告")
        {
            try
            {
                UserPage.SysMessage m = new UserPage.SysMessage();
                m.MessageText = txt;
                m.MessageFrom = from;
                UserPage.ApplcitionMessage.list.SysMessages.Add(m);
                UserPage.ApplcitionMessage.list.SMCount = 0;
                return true;
            }
            catch { return false; }
        }
    }
}
