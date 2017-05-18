using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inform
{
    public class Functions
    {
        /// <summary>
        /// 一个用于显示消息文本的方法，参数1：消息文本，参数2：消息标题
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static void ShowMessage(string txt, string title = "消息")
        {
            P_MessageBox pm = new P_MessageBox(title + "：" + txt);
            if (Delegates.AddChildren_ != null)
            {
                Delegates.AddChildren_(txt, title);
            }
        }

        /// <summary>
        /// 显示提问框
        /// </summary>
        /// <returns></returns>
        public static bool? Show_Question(string txt, string title = "消息")
        {
            if (Values.SurfaceSetting.Surface.Overallview)
            {
                return new P_QuestionBox(txt, title).ShowDialog();
            }
            else
            {
                return new W_Question().ShowDialog();
            }

        }
    }
}
