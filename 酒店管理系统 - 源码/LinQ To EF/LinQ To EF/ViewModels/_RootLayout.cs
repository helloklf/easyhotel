using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinQ_To_EF.ViewModels
{
    public class _RootLayout
    {
        public _RootLayout()
        {
            Color = "#fff";
            BackgroundColor = "#ff7800";
        }
        string color;
        /// <summary>
        /// 前景色
        /// </summary>
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        string backgroundColor;

        /// <summary>
        /// 背景色
        /// </summary>
        public string BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; }
        }

        bool isOnline;
        /// <summary>
        /// 是否登陆
        /// </summary>
        public bool IsOnline
        {
            get { return userId!=null; }
        }

        public static string userId;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
    }
}