using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TModel;

namespace Project_Term2_RoomList
{
    public delegate void Updates(T_RoomList Ts);
    public delegate void VOID();
    public class Delegates
    {
        public static VOID TabChangeReturn;
        public static VOID TabChangeToAdd;
    }
}
