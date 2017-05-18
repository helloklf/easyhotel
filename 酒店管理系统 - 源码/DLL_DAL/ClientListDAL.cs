using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;
using System.Data;
using System.Data.SqlClient;

namespace DLL_DAL
{
    public class ClientListDAL
    {
        /// <summary>
        /// 读取数据列表
        /// </summary>
        public static List<T_ClientInfo> LoadData()
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                dr= DB.ExecuteReader("select * from T_ClientInfo join T_PaperType on T_ClientInfo.ClientCType=T_PaperType.PapersID");
                List<T_ClientInfo> CIL = new List<T_ClientInfo>();
                while (dr.Read())
                {
                    T_ClientInfo ci = new T_ClientInfo();
                    ci.GUID = (string)dr["GUID"];
                    ci.ClientIName = (string)dr["ClientIName"];
                    ci.ClientSex = (bool)dr["ClientSex"];
                    ci.ClientIDCard = (string)dr["ClientIDCard"];
                    ci.ClientAdress = (string)dr["ClientAdress"];
                    ci.ClientVIPID = (string)dr["ClientVIPID"];
                    ci.ClientCType = (int)dr["ClientCType"];
                    ci.PapersName = (string)dr["PapersName"];
                    ci.ClientTel = (string)dr["ClientTel"];
                    CIL.Add(ci);
                }
                return CIL;
            }
            finally
            {
                DB.ConnClose();
                if (dr != null) { dr.Close(); }
            }
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <returns></returns>
        public static int Update(T_ClientInfo ci)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sqlp = new SqlParameter[] 
            { 
                new SqlParameter("@ClientIName", ci.ClientIName),
                new SqlParameter("@ClientSex",ci.ClientSex),
                new SqlParameter("@ClientCType",ci.ClientCType),
                new SqlParameter("@ClientIDCard",ci.ClientIDCard),
                new SqlParameter("@ClientVIPID",ci.ClientVIPID),
                new SqlParameter("@ClientTel",ci.ClientTel),
                new SqlParameter("@GUID",ci.GUID)
            };
            string sql = "update T_ClientInfo set ClientIName=@ClientIName,ClientSex=@ClientSex,ClientCType=@ClientCType,ClientIDCard=@ClientIDCard,ClientVIPID=@ClientVIPID,ClientTel=@ClientTel where GUID=@GUID";
            return DB.ExecuteNonQuery(sql, sqlp);
        }
    }
}
