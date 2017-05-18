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
    /// 授权类型
    /// </summary>
    public class AccreditTypeBLL
    {
        /// <summary>
        /// 读取授权类型数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static List<T_AccreditType> Get_AccreditTypeList(bool t)
        {
            return DLL_DAL.AccreditTypeDAL.Get_AccreditTypeList(t);
        }

        /// <summary>
        ///启用或禁用授权类型项目 
        /// </summary>
        /// <param name="E"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool AccreditType_Enable(bool E, int ID)
        {
            if (AccreditTypeDAL.AccreditType_Enable(E, ID) > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更新授权类型数据
        /// </summary>
        /// <param name="t"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        public static bool Update(string t,string r, T_AccreditType select)
        {
            int i = t.Length;
            if (i > 0 && i < 15 &&(t!=select.ALevelName||r!=select.ALevelRemark))
            {
                T_AccreditType TA = new T_AccreditType() { ALevelName = t, ALevelRemark = r};
                if (DLL_DAL.AccreditTypeDAL.Update(TA, select.ALevelID) > 0) { return true; }
            }
            return false;
        }

        /// <summary>
        /// 插入授权类型数据
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool Insert(string name,string remark)
        {
            T_AccreditType TA = new T_AccreditType()
            {
                 ALevelName=name,
                ALevelRemark=remark
            };
            int i = TA.ALevelName.Length;

            if (i > 0 && i < 15)
            {
                if ( AccreditTypeDAL.Insert(TA) > 0) return true;
            }
            else throw new Exception("输入的参数无效！请检查过后再试！");
            return false;
        }
    }
}
