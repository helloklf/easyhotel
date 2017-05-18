using DLL_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;

namespace DLL_BLL
{
    public class RoomStateTypeBLL
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static List<T_RoomStateType> DataLoad(bool t)
        {
            return DLL_DAL.RoomStateTypeDAL.DataLoad(t);
        }

        /// <summary>
        ///启用或禁用项目 
        /// </summary>
        /// <param name="E"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool EnableItem(bool E, int ID)
        {
            if(RoomStateTypeDAL.EnableItem(E, ID) > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="t"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        public static bool Update(string t,string color, string r, T_RoomStateType select)
        {
            int i = t.Length;
            if (i > 0 && i < 15 && (t != select.StateName || r != select.StateRemark||select.StateColor!=color))
            {
                T_RoomStateType TA = new T_RoomStateType()
                {
                    StateName = t,
                    StateColor = color,
                    StateRemark = r
                };
                if (DLL_DAL.RoomStateTypeDAL.Update(TA, select.StateID) > 0) { return true; }
            }
            return false;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool Insert(string name, string color,string remark)
        {
            T_RoomStateType TA = new T_RoomStateType()
            {
                StateName = name,
                StateColor= color,
                StateRemark = remark
            };
            int i = TA.StateName.Length;

            if (i > 0 && i < 15)
            {
                if (RoomStateTypeDAL.Insert(TA) > 0) return true;
            }
            else throw new Exception("输入的参数无效！请检查过后再试！");
            return false;
        }
    }
}
