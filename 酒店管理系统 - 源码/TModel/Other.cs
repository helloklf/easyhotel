using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TModel
{

    /// <summary>
    /// 使用于简单信息的显示，只有一个标题和文本
    /// </summary>
    public class Other_HotelRoomState
    {
        string title;
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        string text;
        /// <summary>
        /// 文本
        /// </summary>
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
    }


    /// <summary>
    /// 使用于房间类型数量的类型，具有两个Int和三个String字段
    /// </summary>
    public class Other_EmptyRoom
    {
        string title;
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        int allRoom;
        /// <summary>
        /// 所有房间
        /// </summary>
        public int AllRoom
        {
            get { return allRoom; }
            set { allRoom = value; }
        }

        int emptyRoom;
        /// <summary>
        /// 空房间
        /// </summary>
        public int EmptyRoom
        {
            get { return emptyRoom; }
            set { emptyRoom = value; }
        }

        /// <summary>
        /// 文本
        /// </summary>
        public string Text
        {
            get
            {
                return Math.Round(((emptyRoom * 100.0) / allRoom), 1).ToString() + "%";
            }
        }

        /// <summary>
        /// 文本
        /// </summary>
        public string Text_1
        {
            get
            {
                return emptyRoom+"/"+AllRoom;
            }
        }
    }

    /// <summary>
    /// 用于酒店资金分析
    /// </summary>
    public class Other_HotelFund 
    {
        string title;
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        int fund;
        /// <summary>
        /// 数量
        /// </summary>
        public int Text
        {
            get { return fund; }
            set { fund = value; }
        }
    }
}
