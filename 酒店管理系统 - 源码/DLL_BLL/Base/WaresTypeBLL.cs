using DLL_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;
using System.Windows.Media.Imaging;

namespace DLL_BLL
{
    public class WaresTypeBLL
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static List<T_WaresType> DataLoad(bool t)
        {
            return DLL_DAL.WaresTypeDAL.DataLoad(t);
        }

        /// <summary>
        ///启用或禁用项目 
        /// </summary>
        /// <param name="E"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool EnableItem(bool E, int ID)
        {
            {
            if (WaresTypeDAL.EnableItem(E, ID) > 0)
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
        public static bool Update(string t, string r,string uri,bool isNew, T_WaresType select)
        {
            int i = t.Length;
            if (i > 0 && i <= 15 && (t != select.WaresName || r != select.WaresRemark||isNew))
            {
                T_WaresType TA = new T_WaresType() { WaresName = t, WaresRemark = r };
                if (DLL_DAL.WaresTypeDAL.Update(TA,uri,isNew, select.WaresID) > 0) { return true; }
            }
            return false;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool Insert(string name, string uri ,string remark)
        {
            T_WaresType TA = new T_WaresType()
            {
                WaresName = name,
                WaresRemark = remark,
            };
            int i = TA.WaresName.Length;

            if (i > 0 && i < 15)
            {
                if (WaresTypeDAL.Insert(TA,uri) > 0) return true;
            }
            else throw new Exception("输入的参数无效！请检查过后再试！");
            return false;
        }
    }
}
