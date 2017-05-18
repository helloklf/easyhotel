using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;
using System.Data;

namespace DLL_DAL
{
    public class StaffDAL
    {

        public static List<T_StaffInfo> GetData(bool b)
        {
            Task_DBHelper DB = new Task_DBHelper(); SqlDataReader dr = null;
            try
            {
                SqlParameter[] sqlp = new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@IsValid", b) };
                dr = DB.ExecuteReader("select * from T_StaffInfo where IsValid=@IsValid",sqlp);
                List<T_StaffInfo> TC = new List<T_StaffInfo>();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        T_StaffInfo tv = new T_StaffInfo();
                        tv.StaffID = (string)dr["StaffID"];
                        tv.StaffName = (string)dr["StaffName"];
                        tv.StaffIdCard = (string)dr["StaffIdCard"];
                        tv.StaffCouID = (int)dr["StaffCouID"];
                        try
                        {
                            tv.ImageBytes = (byte[])dr["StaffImage"];
                        }
                        catch { }
                        //try
                        //{
                        //    byte[] img = (byte[])dr["StaffImage"];
                        //    tv.StaffImage = Other.GetImage(img);
                        //}
                        //catch { }
                        tv.StaffTel = (string)dr["StaffTel"];
                        tv.StaffSex = (bool)dr["StaffSex"];
                        tv.StaffInDate = (DateTime)dr["StaffInDate"];
                        tv.StaffAdress = (string)dr["StaffAdress"];

                        tv.IsValid = (bool)dr["IsValid"];
                        TC.Add(tv);
                    }
                }
                return TC;
            }
            finally { DB.ConnClose();if (dr != null) { dr.Dispose(); }}
            
            
        }
        public static DataTable GetData()
        {
            Task_DBHelper DB = new Task_DBHelper();
            DataSet dt = DB.GetTable
            (
                @"select a.StaffID as '序列号',StaffName as '姓名',StaffIdCard as '身份证',
                b.StaffID '工号',b.StaffAccredit '授权码',STypeName '职务' ,
                StaffSex as'性别',CountryName as '国家',StaffAdress as '地址',
                StaffInDate as '入职时间',StaffTel as '电话号码',a.StaffName 'GUID'
                 from T_StaffInfo a left join T_StaffList b on a.StaffID=b.StaffGuid left join T_CountryInfo on a.StaffCouID=T_CountryInfo.CountryID
                left join T_StaffType on b.STypeID=T_StaffType.STypeID where a.IsValid=1"
            );
            return dt.Tables[0];
        }

        /// <summary>
        /// 插入员工信息 参数为员工基本信息、头像文件路径
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static int Insert(T_StaffInfo ts, string uri)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sp;
            SqlParameter StaffName = new SqlParameter("@StaffName", ts.StaffName);
            SqlParameter StaffSex = new SqlParameter("@StaffSex", ts.StaffSex);
            SqlParameter StaffIdCard = new SqlParameter("@StaffIdCard", ts.StaffIdCard);
            SqlParameter StaffCouID = new SqlParameter("@StaffCouID", ts.StaffCouID);
            SqlParameter StaffAdress = new SqlParameter("@StaffAdress", ts.StaffAdress);
            SqlParameter StaffTel = new SqlParameter("@StaffTel", ts.StaffTel);
            SqlParameter StaffInDate = new SqlParameter("@StaffInDate", ts.StaffInDate);
            try
            {
                SqlParameter StaffImage = Other.ImageToSqlParameter(uri, "StaffImage");
                sp = new SqlParameter[] 
                {
                    StaffName ,StaffSex ,StaffIdCard,StaffCouID ,StaffAdress, StaffTel, StaffInDate,StaffImage
                };
                int Count = DB.ExecuteNonQuery(
                @"insert into T_StaffInfo (StaffName,StaffSex,StaffIdCard,StaffCouID,StaffAdress,StaffTel,StaffInDate,StaffImage) 
                values(@StaffName,@StaffSex,@StaffIdCard,@StaffCouID,@StaffAdress,@StaffTel,@StaffInDate,@StaffImage)", sp);
                return Count;
            }
            catch
            {
                sp = new SqlParameter[] 
                {
                    StaffName ,StaffSex ,StaffIdCard,StaffCouID ,StaffAdress, StaffTel, StaffInDate
                };
                int Count = DB.ExecuteNonQuery(
                @"insert into T_StaffInfo (StaffName,StaffSex,StaffIdCard,StaffCouID,StaffAdress,StaffTel,StaffInDate) 
                values(@StaffName,@StaffSex,@StaffIdCard,@StaffCouID,@StaffAdress,@StaffTel,@StaffInDate)", sp);
                return Count;
            }
        }

        /// <summary>
        /// 插入一个在职员工条目
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static int Insert(T_StaffList ts)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sp;
            SqlParameter StaffID = new SqlParameter("@StaffID", ts.StaffID);
            SqlParameter StaffGuid = new SqlParameter("@StaffGuid", ts.StaffGuid);
            SqlParameter StaffPwdMD5 = new SqlParameter("@StaffPwdMD5", ts.StaffPwdMD5);
            SqlParameter STypeID = new SqlParameter("@STypeID", ts.STypeID);
            SqlParameter StaffAccredit = new SqlParameter("@StaffAccredit", ts.StaffAccredit);
            sp = new SqlParameter[] 
            {
                StaffID ,StaffGuid ,StaffPwdMD5,STypeID ,StaffAccredit
            };
            int Count = DB.ExecuteNonQuery(
            @"insert into T_StaffList (StaffID,StaffGuid,StaffPwdMD5,STypeID,StaffAccredit) 
            values(@StaffID,@StaffGuid,@StaffPwdMD5,@STypeID,@StaffAccredit)", sp);
            return Count;
        }

        #region 员工个人信息更新
        /// <summary>
        /// 更新员工个人信息
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static int Update(T_StaffInfo ts, string uri)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sp;
            SqlParameter StaffID = new SqlParameter("@StaffID", ts.StaffID);
            SqlParameter StaffName = new SqlParameter("@StaffName", ts.StaffName);
            SqlParameter StaffSex = new SqlParameter("@StaffSex", ts.StaffSex);
            SqlParameter StaffIdCard = new SqlParameter("@StaffIdCard", ts.StaffIdCard);
            SqlParameter StaffCouID = new SqlParameter("@StaffCouID", ts.StaffCouID);
            SqlParameter StaffAdress = new SqlParameter("@StaffAdress", ts.StaffAdress);
            SqlParameter StaffTel = new SqlParameter("@StaffTel", ts.StaffTel);
            SqlParameter StaffInDate = new SqlParameter("@StaffInDate", ts.StaffInDate);
            try
            {
                SqlParameter StaffImage = Other.ImageToSqlParameter(uri, "StaffImage");
                sp = new SqlParameter[] 
                {
                    StaffID,StaffName ,StaffSex ,StaffIdCard,StaffCouID ,StaffAdress, StaffTel, StaffInDate,StaffImage
                };
                int Count = DB.ExecuteNonQuery(
                @"update T_StaffInfo set StaffName=@StaffName,StaffSex=@StaffSex,StaffIdCard=@StaffIdCard,StaffCouID=@StaffCouID,
                StaffAdress=@StaffAdress,StaffTel=@StaffTel,StaffInDate=@StaffInDate,StaffImage=@StaffImage where StaffID = @StaffID", sp);
                return Count;
            }
            catch
            {
                try
                {
                    sp = new SqlParameter[] 
                    {
                        StaffID,StaffName ,StaffSex ,StaffIdCard,StaffCouID ,StaffAdress, StaffTel, StaffInDate
                    };
                    int Count = DB.ExecuteNonQuery(
                    @"update T_StaffInfo set StaffName=@StaffName,StaffSex=@StaffSex,StaffIdCard=@StaffIdCard,StaffCouID=@StaffCouID,
                StaffAdress=@StaffAdress,StaffTel=@StaffTel,StaffInDate=@StaffInDate where StaffID = @StaffID", sp);
                    return Count;
                }
                catch { return 0; }
            }
        }
        #endregion

        #region 修改员工登录账户
        
        /// <summary>
        /// 更新员工个人信息
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static int Update(T_StaffList ts)
        {
            Task_DBHelper DB = new Task_DBHelper();
            SqlParameter[] sqlp = new SqlParameter[] { new SqlParameter("@StaffID", ts.StaffID), new SqlParameter("@StaffPwdMD5", ts.StaffPwdMD5), new SqlParameter("@StaffAccredit", ts.StaffAccredit), new SqlParameter("@StaffGuid", ts.StaffGuid), new SqlParameter("@STypeID", ts.STypeID) };
            string sql = "update T_StaffList set StaffID=@StaffID,StaffPwdMD5 =@StaffPwdMD5,StaffAccredit=@StaffAccredit,STypeID=@STypeID where StaffGuid=@StaffGuid";
            return DB.ExecuteNonQuery(sql,sqlp);
        }
        #endregion

        public static int EnableItem(bool e, string id)
        {
            Task_DBHelper DB = new Task_DBHelper();
            if (e)
            {
                SqlParameter[] sqlp = new SqlParameter[] { new SqlParameter("@ID", id),new SqlParameter("@isv",e) };
                string sql = "update T_StaffInfo set IsValid= @isv where StaffID = @ID";
                return DB.ExecuteNonQuery(sql, sqlp);
            }
            else
            {
                SqlParameter[] sqlp = new SqlParameter[] { new SqlParameter("@StaffID", id) }; string sql = "Proc_StaffResign";
                return DB.ExecuteNonQueryProc(sql, sqlp);
            }
        }
    }
}
