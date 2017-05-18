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
    public class ClientInRoomDAL
    {
        /// <summary>
        /// 入住
        /// </summary>
        /// <returns></returns>
        public static int InRoom(View_ProcClientIn Proc)
        {
            Task_DBHelper DB = new Task_DBHelper();
            string sql = "Proc_ClientCheckIn";
            SqlParameter[] sqlp = new SqlParameter[]
            {
                new SqlParameter("@ClientIName", Proc.ClientIName),
                new SqlParameter("@ClientCType", Proc.ClientCType),
                new SqlParameter("@ClientIDCard", Proc.ClientIDCard),
                new SqlParameter("@ClientSex", Proc.ClientSex),
                new SqlParameter("@ClientAdress", Proc.ClientAdress),
                new SqlParameter("@ClientTel", Proc.ClientTel),
                new SqlParameter("@ClientVipID", Proc.ClientVipID),
                new SqlParameter("@ClientAccount",Proc.ClientAccount),
                new SqlParameter("@OperatorID",Proc.OperatorID),
                new SqlParameter("@RoomID",Proc.RoomID),
            };
            return DB.ExecuteNonQueryProc(sql, sqlp);
        }

        /// <summary>
        /// 预订客户入住
        /// </summary>
        /// <returns></returns>
        public static int BookInRoom(View_ProcClientIn Proc)
        {
            Task_DBHelper DB = new Task_DBHelper();
            string sql = "Proc_BookClientIn";
            SqlParameter[] sqlp = new SqlParameter[]
            {
                new SqlParameter("@ClientIName", Proc.ClientIName),
                new SqlParameter("@ClientCType", Proc.ClientCType),
                new SqlParameter("@ClientIDCard", Proc.ClientIDCard),
                new SqlParameter("@ClientSex", Proc.ClientSex),
                new SqlParameter("@ClientAdress", Proc.ClientAdress),
                new SqlParameter("@ClientTel", Proc.ClientTel),
                new SqlParameter("@ClientVipID", Proc.ClientVipID),
                new SqlParameter("@ClientAccount",Proc.ClientAccount),
                new SqlParameter("@OperatorID",Proc.OperatorID),
                new SqlParameter("@RoomID",Proc.RoomID),
            };
            return DB.ExecuteNonQueryProc(sql, sqlp);
        }


        /// <summary>
        /// 取消房间预订
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        public static int EixtBook(string roomid)
        {
            SqlParameter[] sqlp = new SqlParameter[] { new SqlParameter("@RoomID", roomid) };
            Task_DBHelper DB = new Task_DBHelper();
            return DB.ExecuteNonQueryProc("Proc_DeleteBookRoom",sqlp);
        }
    }
}
