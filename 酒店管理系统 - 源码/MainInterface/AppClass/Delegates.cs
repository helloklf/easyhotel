using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TModel;

namespace Project_Term2
{

    public delegate void NotParameter();
    public delegate void ChildrenAdd(Control obj);
    public delegate void IntParameter(int index);
    public delegate void ObjectParameter(object index);
    public delegate void StringParmeter(string name);
    
    /// <summary>
    /// 用户登录信息传递专用委托
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public delegate void UserLogin(View_UserInfo UI);

    public class Delegates
    {
        /// <summary>
        /// 用户离线
        /// </summary>
        /// <returns></returns>
        public static NotParameter UserOff_Line;

        /// <summary>
        /// 用户登录方法
        /// </summary>
        public static UserLogin LoginInfo;

        /// <summary>
        /// 跳转到消息列表页面
        /// </summary>
        public static NotParameter ToMessagePage;

        /// <summary>
        /// 窗体关闭方法
        /// </summary>
        public static NotParameter CloseWindow;

        /// <summary>
        /// 窗体最小化方法
        /// </summary>
        public static NotParameter MinWindow;

        /// <summary>
        /// 隐藏窗口
        /// </summary>
        public static NotParameter HideWindow;

        /// <summary>
        /// 窗体最大化方法
        /// </summary>
        public static NotParameter MaxWindow;

        /// <summary>
        /// 添加控件到容器
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static ChildrenAdd AddChildren_;

        /// <summary>
        /// 添加控件到主界面视图
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static ChildrenAdd menuChildren_;

        public static ChildrenAdd MenuChildren_
        {
            get { return Delegates.menuChildren_; }
            set { Delegates.menuChildren_ = value; }
        }

        /// <summary>
        /// 工具栏显示切换
        /// </summary>
        public static NotParameter ToolBarState;
        
        /// <summary>
        /// 状态栏显示切换
        /// </summary>
        public static NotParameter StateBarState;

        /// <summary>
        /// 左侧导航列表状态
        /// </summary>
        public static NotParameter LeftMenuState;

        /// <summary>
        /// 让主界面窗口面板切换到指定窗口索引
        /// </summary>
        private static IntParameter toPageIndex;

        public static IntParameter ToPageIndex
        {
            get { return Delegates.toPageIndex; }
            set { Delegates.toPageIndex = value; }
        }

        /// <summary>
        /// 让主界面窗口面板切换到指定名称页
        /// </summary>
        public static StringParmeter ToPageName;

        /// <summary>
        /// 转到客户入住页面
        /// </summary>
        public static NotParameter GoClientIn;

        /// <summary>
        /// 房间相关操作
        /// </summary>
        public class RoomData
        {
            /// <summary>
            /// 测试权限是否足够
            /// </summary>
            /// <returns></returns>
            public static bool Test()
            {
                if (Values.UserInfo.ALevelName == null || (Values.UserInfo.ALevelName != "高级管理员" && Values.UserInfo.ALevelName != "超级管理员" && Values.UserInfo.ALevelName != "开发者"))
                {
                    Functions.ShowMessage("没有登陆或权限过低，你无权进行此操作！", "权限过低"); return false;
                }
                else
                {
                    return true;
                }
            }

            /// <summary>
            /// 所有房间
            /// </summary>
            public static NotParameter AllRoom;

            /// <summary>
            /// 退房
            /// </summary>
            public static NotParameter ExitRoom;

            /// <summary>
            /// 缴费
            /// </summary>
            public static NotParameter AddMoney;

            /// <summary>
            /// 客户入住
            /// </summary>
            public static NotParameter ClientIn;

            /// <summary>
            /// 房间预订
            /// </summary>
            public static NotParameter RoomBook;
        }

        /// <summary>
        /// 客户数据管理
        /// </summary>
        public class ClientData 
        {
            /// <summary>
            /// 测试权限是否足够
            /// </summary>
            /// <returns></returns>
            public static bool Test()
            {
                if (Values.UserInfo.ALevelName == null)
                {
                    Functions.ShowMessage("没有登陆或权限过低，你无权进行此操作！", "权限过低"); return false;
                }
                else if(Values.UserInfo.ALevelName !="管理员" && Values.UserInfo.ALevelName != "高级管理员" && Values.UserInfo.ALevelName != "超级管理员" && Values.UserInfo.ALevelName != "开发者")
                {
                    Functions.ShowMessage("没有登陆或权限过低，你无权进行此操作！", "权限过低"); return false;
                }
                else
                {
                    return true;
                }
            }

            /// <summary>
            /// 转到指定页面序号
            /// </summary>
            public static IntParameter ToSetPage;
        }


        /// <summary>
        /// 员工数据管理
        /// </summary>
        public class StaffData 
        {
            /// <summary>
            /// 测试权限是否足够
            /// </summary>
            /// <returns></returns>
            public static bool Test()
            {
                if (Values.UserInfo.ALevelName == null)
                {
                    Functions.ShowMessage("没有登陆或权限过低，你无权进行此操作！", "权限过低"); return false;
                }
                else if (Values.UserInfo.ALevelName != "高级管理员" && Values.UserInfo.ALevelName != "超级管理员" && Values.UserInfo.ALevelName != "开发者")
                {
                    Functions.ShowMessage("没有登陆或权限过低，你无权进行此操作！", "权限过低"); return false;
                }
                else
                {
                    return true;
                }
            }

            /// <summary>
            /// 转到指定页面序号
            /// </summary>
            public static IntParameter ToSetPage;

        }

        /// <summary>
        /// 基础数据相关操作
        /// </summary>
        public class BaseData
        {
            /// <summary>
            /// 测试权限是否足够
            /// </summary>
            /// <returns></returns>
            public static bool Test() 
            {
                if (Values.UserInfo.ALevelName == null)
                {
                    Functions.ShowMessage("没有登陆或权限过低，你无权进行此操作！", "权限过低"); return false;
                }
                else if (Values.UserInfo.ALevelName != "超级管理员" && Values.UserInfo.ALevelName != "开发者")
                {
                    Functions.ShowMessage("没有登陆或权限过低，你无权进行此操作！", "权限过低"); return false;  
                }
                else
                {
                    return true;
                }
            }

            /// <summary>
            /// 转到指定页面序号
            /// </summary>
            private static IntParameter toSetPage;

            public static IntParameter ToSetPage
            {
                get { return BaseData.toSetPage; }
                set { BaseData.toSetPage = value; }
            }

        }

        public class History
        {
            /// <summary>
            /// 测试权限是否足够
            /// </summary>
            /// <returns></returns>
            public static bool Test()
            {
                if (Values.UserInfo.ALevelName == null)
                {
                    Functions.ShowMessage("没有登陆或权限过低，你无权进行此操作！", "权限过低"); return false;
                }
                else if (Values.UserInfo.ALevelName != "管理员" && Values.UserInfo.ALevelName != "高级管理员" && Values.UserInfo.ALevelName != "超级管理员" && Values.UserInfo.ALevelName != "开发者")
                {
                    Functions.ShowMessage("没有登陆或权限过低，你无权进行此操作！", "权限过低"); return false;
                }
                else
                {
                    return true;
                }
            }

            /// <summary>
            /// 查看当天账目
            /// </summary>
            public static NotParameter TodayAccounts;
        }
    }
}
