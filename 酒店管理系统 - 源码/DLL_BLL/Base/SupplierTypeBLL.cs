using DLL_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;


namespace DLL_BLL
{
    /// <summary>
    /// 供应商类型
    /// </summary>
    public class SupplierTypeBLL
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static List<T_SupplierType> DataLoad(bool t)
        {
            return DLL_DAL.SupplierTypeDAL.DataLoad(t);
        }

        /// <summary>
        ///启用或禁用项目 
        /// </summary>
        /// <param name="E"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool EnableItem(bool E, int ID)
        {
            if (SupplierTypeDAL.EnableItem(E, ID) > 0)
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
        public static bool Update(string t, string r, T_SupplierType select)
        {
            int i = t.Length;
            if (i > 0 && i < 15 && (t != select.Name || r != select.Remark))
            {
                T_SupplierType TA = new T_SupplierType() { Name = t, Remark = r };
                if (DLL_DAL.SupplierTypeDAL.Update(TA, select.ID) > 0) { return true; }
            }
            return false;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool Insert(string name, string remark)
        {
            T_SupplierType TA = new T_SupplierType()
            {
                Name = name,
                Remark = remark
            };
            int i = TA.Name.Length;

            if (i > 0 && i < 15)
            {
                if (SupplierTypeDAL.Insert(TA) > 0) return true;
            }
            else throw new Exception("输入的参数长度无效！请检查过后再试！");
            return false;
        }
    }
}
