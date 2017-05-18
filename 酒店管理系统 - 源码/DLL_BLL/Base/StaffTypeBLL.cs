using DLL_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;

namespace DLL_BLL
{
    public class StaffTypeBLL
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static List<T_StaffType> DataLoad(bool t)
        {
            return DLL_DAL.StaffTypeDAL.DataLoad(t);
        }

        /// <summary>
        ///启用或禁用项目 
        /// </summary>
        /// <param name="E"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool EnableItem(bool E, int ID)
        {
            if (StaffTypeDAL.EnableItem(E, ID) > 0)
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
        public static bool Update(string name,string r, T_StaffType select)
        {
            int i = name.Length;
            if (i > 0 && i < 15 && (name != select.STypeName ||  r != select.STypeALevelID.ToString()))
            {
                T_StaffType TA = new T_StaffType() { STypeName = name, STypeALevelID = Convert.ToInt32(r),};
                if (DLL_DAL.StaffTypeDAL.Update(TA, select.STypeALevelID) > 0) { return true; }
            }
            return false;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool Insert( string Name, string SuID)
        {
            T_StaffType TA = new T_StaffType()
            {
                STypeName = Name,
                STypeALevelID = Convert.ToInt32(SuID)
            };
            int i = TA.STypeName.Length;
            if (i > 0 && i < 15)
            {
                if (StaffTypeDAL.Insert(TA) > 0) return true;
            }
            else throw new Exception("输入的参数无效！请检查过后再试！");
            return false;
        }
    }
}
