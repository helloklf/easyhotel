using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_Term2
{
    public class Other_Function
    {
        public static string GetDateString()
        {
            DateTime dt = DateTime.Now;
            return (dt.ToString("yyyy年MM月dd日") + " " + GetWeek(dt.DayOfWeek));
        }
        public static string GetWeek(params DayOfWeek[] Week) 
        {
            string week="";
            if (Week == null) Week = new DayOfWeek[]{ DateTime.Now.DayOfWeek};
            switch (Week[0])
            {
                case DayOfWeek.Sunday: { week = "星期日"; break; }
                case DayOfWeek.Monday: { week = "星期一"; break; }
                case DayOfWeek.Tuesday: { week = "星期二"; break; }
                case DayOfWeek.Wednesday: { week = "星期三"; break; }
                case DayOfWeek.Thursday: { week = "星期四"; break; }
                case DayOfWeek.Friday: { week = "星期五"; break; }
                default: { week = "星期六"; break; }
            }
            return week;
        }

        public static string GetTimeString()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }


        [DllImport("kernel32.dll", EntryPoint = "GetSystemPowerStatus")]   //win32 api
        public static extern void GetSystemPowerStatus(ref SYSTEM_POWER_STATUS lpSystemPowerStatus);

        public struct SYSTEM_POWER_STATUS    //结构体
        {
            public Byte ACLineStatus;                //0 = offline, 1 = Online, 255 = UnKnown Status.   
            public Byte BatteryFlag;
            public Byte BatteryLifePercent;
            public Byte Reserved1;
            public int BatteryLifeTime;
            public int BatteryFullLifeTime;
        }   
    }
}
