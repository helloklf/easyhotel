using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_DAL
{
    /// <summary>
    /// 历史记录表查询
    /// </summary>
    public class History
    {
        /// <summary>
        /// 消费历史记录（T_AccountOld）参数int : 1-当天，2-一周，3-30天，4-一年，5-全部
        /// </summary>
        /// <returns></returns>
        public static DataTable view_ConsumeHistory(int time)
        {
            Task_DBHelper DB = new Task_DBHelper();
            if (time == 1) return DB.GetTable("select * from view_ConsumeHistory where 操作时间>= dateadd(MINUTE,-1440,GETDATE())").Tables[0];
            if (time == 2) return DB.GetTable("select * from view_ConsumeHistory where 操作时间>= dateadd(HOUR,-168,GETDATE())").Tables[0];
            if (time == 3) return DB.GetTable("select * from view_ConsumeHistory where 操作时间>= dateadd(HOUR,-120960,GETDATE())").Tables[0];
            if (time == 4) return DB.GetTable("select * from view_ConsumeHistory where 操作时间> dateadd(DAY,-365,GETDATE())").Tables[0];
            if (time == 5) return DB.GetTable("select * from view_ConsumeHistory").Tables[0];
            else return null;
        }

        /// <summary>
        /// 住房历史记录（T_ClientRoomOld）
        /// </summary>
        /// <returns></returns>
        public static DataTable view_HousingHistory(int time)
        {
            Task_DBHelper DB = new Task_DBHelper();
            //select * from view_HousingHistory where 入住时间>= dateadd(MINUTE,-1440,GETDATE()) --当天
            //select * from view_HousingHistory where 入住时间> dateadd(HOUR,-168,GETDATE()) --七天内
            //select * from view_HousingHistory where 入住时间> dateadd(HOUR,-120960,GETDATE()) --30天内
            //select * from view_HousingHistory where 入住时间> dateadd(DAY,-365,GETDATE()) --365天
            if (time == 1) return DB.GetTable("select * from view_HousingHistory where 入住时间>= dateadd(MINUTE,-1440,GETDATE())").Tables[0];
            if (time == 2) return DB.GetTable("select * from view_HousingHistory where 入住时间>= dateadd(HOUR,-168,GETDATE())").Tables[0];
            if (time == 3) return DB.GetTable("select * from view_HousingHistory where 入住时间>= dateadd(HOUR,-120960,GETDATE())").Tables[0];
            if (time == 4) return DB.GetTable("select * from view_HousingHistory where 入住时间> dateadd(DAY,-365,GETDATE())").Tables[0];
            if (time == 5) return DB.GetTable("select * from view_HousingHistory").Tables[0];
            else return null;
        }
    }
}
