using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_BLL
{
    /// <summary>
    /// 历史记录表查询
    /// </summary>
    public class History
    {
        /// <summary>
        /// 消费历史记录（T_AccountOld） 参数int : 1-当天，2-一周，3-30天，4-一年，5-全部
        /// </summary>
        /// <returns></returns>
        public static DataTable view_ConsumeHistory(int time)
        {
            return DLL_DAL.History.view_ConsumeHistory(time);
        }


        /// <summary>
        /// 住房历史记录（T_ClientRoomOld）
        /// </summary>
        /// <returns></returns>
        public static DataTable view_HousingHistory(int time)
        {
            return DLL_DAL.History.view_HousingHistory(time);
        }
    }
}
