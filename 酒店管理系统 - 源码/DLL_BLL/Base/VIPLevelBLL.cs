using DLL_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;

namespace DLL_BLL
{
    public class VIPLevelBLL
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static List<T_VIPLevel> DataLoad(bool t)
        {
            return DLL_DAL.VIPLevelDAL.DataLoad(t);
        }

        /// <summary>
        ///启用或禁用项目 
        /// </summary>
        /// <param name="E"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool EnableItem(bool E, int ID)
        {
            if (VIPLevelDAL.EnableItem(E, ID) > 0)
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
        public static bool Update(string t,string I,string d, T_VIPLevel select)
        {
            int i = t.Length;
            if (i > 0 && i < 15 && (t != select.LevelName||select.LevelIntegral.ToString()!=I||select.VipDiscount.ToString()==d))
            {
                T_VIPLevel TV= new T_VIPLevel(){ LevelName=t,LevelIntegral=Convert.ToInt32(I),VipDiscount=Convert.ToInt32(d) };
                if (DLL_DAL.VIPLevelDAL.Update(TV, select.LevelID) > 0) { return true; }
            }
            return false;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool Insert(string name,string integral,string discount)
        {
            T_VIPLevel TV = new T_VIPLevel()
            { LevelName=name,
                LevelIntegral=Convert.ToInt32(integral)
                ,VipDiscount=Convert.ToInt32(discount) };
            int i = TV.LevelName.Length;

            if (i > 0 && i < 15 && TV.LevelIntegral > -1 && TV.LevelIntegral < 2100000000 && TV.VipDiscount > -1 && TV.VipDiscount < 101)
            {
                if (VIPLevelDAL.Insert(TV) > 0) return true;
            }
            else throw new Exception("输入的参数无效！请检查过后再试！");
            return false;
        }
    }
}
