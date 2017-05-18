using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;

namespace DLL_BLL
{
    /// <summary>
    /// 客户入住酒店
    /// </summary>
    public class ClientInRoomBLL
    {
        /// <summary>
        /// 入住
        /// </summary>
        /// <returns></returns>
        public static bool InRoom(View_ProcClientIn proc)
        {
            if(DLL_DAL.ClientInRoomDAL.InRoom(proc)>0) return true;
            return false;
        }

        
        /// <summary>
        /// 入住
        /// </summary>
        /// <returns></returns>
        public static bool BookInRoom(View_ProcClientIn proc)
        {
            if(DLL_DAL.ClientInRoomDAL.BookInRoom(proc)>0) return true;
            return false;
        }

        /// <summary>
        /// 取消房间预订
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        public static bool EixtBook(string roomid)
        {
            return DLL_DAL.ClientInRoomDAL.EixtBook(roomid)>0?true:false;
        }
    }
}
