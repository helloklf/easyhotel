using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace Project_Term2.Other
{
    public class InfoText
    {
        /// <summary>
        /// 设置保存
        /// </summary>
        public static string SettingSave
        {
            get { return Project_Term2.Properties.Resources.SettingSave; }
        }
        
        /// <summary>
        /// 设置保存出错
        /// </summary>
        public static string SettringSaveError
        {
            get { return Project_Term2.Properties.Resources.SettringSaveError; }
        }
        /// <summary>
        /// 因为输入错误 无法登陆
        /// </summary>
        public static string UserLoginMessage
        {
            get { return Project_Term2.Properties.Resources.UserLoginMessage; }
        }

        /// <summary>
        /// 用户登录失败
        /// </summary>
        public static string UserLoginError
        {
            get { return Project_Term2.Properties.Resources.UserLoginError; }
        }

        /// <summary>
        /// 账户注销提示
        /// </summary>
        public static string ExitLogionQuestion
        {
            get { return Project_Term2.Properties.Resources.ExitLogionQuestion; }
        }

        /// <summary>
        /// 关于安全协议的说明
        /// </summary>
        public static string AboutSecurity
        {
            get { return Project_Term2.Properties.Resources.AboutSecurity; }
        }

        /// <summary>
        /// 应用程序严重错误
        /// </summary>
        public static string ApplictionError
        {
            get { return Project_Term2.Properties.Resources.ApplictionError; }
        }

        /// <summary>
        /// 快捷键说明
        /// </summary>
        public static string HelpInfo_HotKey
        {
            get { return Project_Term2.Properties.Resources.HelpInfo_HotKey; }
        }


        /// <summary>
        /// 房间信息读取器参数无效
        /// </summary>
        public static string RoomReadError
        {
            get { return Project_Term2.Properties.Resources.RoomReadError; }
        }

        /// <summary>
        /// 按房间计费时长搜索输入无效
        /// </summary>
        public static string RoomSeachNotInt
        {
            get { return Project_Term2.Properties.Resources.RoomSeachNotInt; }
        }

        /// <summary>
        /// 价格搜索帮助信息
        /// </summary>
        public static string RoomSHelpPrice
        {
            get { return Project_Term2.Properties.Resources.RoomSHelpPrice; }
        }

        /// <summary>
        /// 价格搜索输入无效
        /// </summary>
        public static string RoomSeacheNoPrice
        {
            get { return Project_Term2.Properties.Resources.RoomSeacheNoPrice; }
        }
    }
}
