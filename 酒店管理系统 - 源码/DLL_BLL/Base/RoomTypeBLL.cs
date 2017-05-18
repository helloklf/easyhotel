using DLL_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;

namespace DLL_BLL
{
    public class RoomTypeBLL
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static List<T_RoomType> DataLoad(bool t)
        {
            return DLL_DAL.RoomTypeDAL.DataLoad(t);
        }

        /// <summary>
        ///启用或禁用项目 
        /// </summary>
        /// <param name="E"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool EnableItem(bool E, int ID)
        {
            if (RoomTypeDAL.EnableItem(E, ID) > 0)
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
        public static bool Update(string name, string price, string r, T_RoomType select)
        {
            int i = name.Length;
            if (i > 0 && i < 15 && (name != select.TypeName||price!=select.TypePrice.ToString()||r!=select.TypeRequency.ToString() ))
            {
                T_RoomType TA = new T_RoomType() { TypeName = name, TypePrice = Convert.ToInt32(price), TypeRequency = Convert.ToInt32(r) };
                if (DLL_DAL.RoomTypeDAL.Update(TA, select.TypeID) > 0) { return true; }
            }
            return false;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool Insert(string name, string price,string r)
        {
            T_RoomType TA = new T_RoomType()
            {
                TypeName = name,
                TypePrice = Convert.ToInt32(price),
                TypeRequency = Convert.ToInt32(r)
            };
            int i = TA.TypeName.Length;
            if (i > 0 && i < 15)
            {
                if (RoomTypeDAL.Insert(TA) > 0) return true;
            }
            else throw new Exception("输入的参数无效！请检查过后再试！");
            return false;
        }
    }
}
