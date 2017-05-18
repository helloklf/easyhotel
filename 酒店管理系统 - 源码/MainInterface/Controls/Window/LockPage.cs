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
using System.Windows.Threading;

namespace Project_Term2
{
    /// <summary>
    /// Lock.xaml 的交互逻辑
    /// </summary>
    public partial class LoginPage : Window
    {
        public void GetText()
        {
            int d = DateTime.Now.Hour;
            if (d >= 0 && d < 5)
            {
                T1.Text = "凌晨好！";
                if (d >= 4)
                    T2.Text = "你大概起得比鸡还早了吧！";
            }
            else if (d >= 5 && d < 9)
            {
                T1.Text = "早安！";
                if (d < 6) T2.Text = "让眼睛放松一会儿，愉快的一天就快要开始了！";
                else if (d < 10) T2.Text = "忙碌的一天又开始了，加油！";
            }
            else if (d >= 10 && d <= 12)
            {
                T1.Text = "上午好！";
                if (d <= 10) T2.Text = "";
                else if (d <= 11) T2.Text = "工作好些时间了，让眼睛稍微休息一下吧！";
                else T2.Text = "午餐时间就快到了，饱食一顿，打个小盹...";
            }
            else if (d < 14)
            {
                T1.Text = "中午好！";
                T2.Text = "工作再忙，也需要休息哦！";
            }
            else if (d < 17)
            {
                T1.Text = "下午好！";
                T2.Text = "尽情享受午后的时光吧！";
            }
            else if (d < 19)
            {
                T1.Text = "傍晚好！";
                T2.Text = "愉快的一天即将过去，放下所有的负担，享受夜晚的静谧吧！";
            }
            else if (d < 24)
            {
                T1.Text = "晚上好！";
                if (d < 20) T2.Text = "当旅客们远在他乡时，总有这样的一家酒店，带他家一样的温暖！";
                else if (d < 23) T2.Text = "忘掉所有的烦恼，好好的休息，相信明天比今天要更好些！";
            }
        }
    }
}
