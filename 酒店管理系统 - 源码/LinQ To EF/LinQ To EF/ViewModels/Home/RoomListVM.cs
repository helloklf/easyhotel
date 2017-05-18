using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinQ_To_EF.ViewModels.Home
{
    public class RoomListVM : _RootLayout
    {
        List<View_RoomInfo> rooms;
        /// <summary>
        /// RoomList
        /// </summary>
        public List<View_RoomInfo> Rooms
        {
            get 
            {
                using (var db = new TavernManageEntities())
                {
                    rooms = db.View_RoomInfo.ToList();
                }
                return rooms;
            }
            set { rooms = value; }
        }

        private List<T_RoomStateType> stateTypes;
        /// <summary>
        /// 
        /// </summary>
        public List<T_RoomStateType> StateTypes 
        {
            get 
            {
                using (var db = new TavernManageEntities())
                {
                    stateTypes = db.T_RoomStateType.ToList();
                    if(stateTypes!=null)
                        stateTypes.Insert(0, new T_RoomStateType() { StateID = 0, StateName = "所有状态" });
                    return stateTypes;
                }
            }
        }

        private List<T_RoomType> roomTypes;

        public List<T_RoomType> RoomTypes
        {
            get {
                using (var db = new TavernManageEntities())
                {
                    roomTypes = db.T_RoomType.ToList();
                    if (roomTypes != null)
                        roomTypes.Insert(0, new T_RoomType() { TypeID = 0, TypeName = "所有类型" });
                    return roomTypes;
                }
            }
        }

        /// <summary>
        /// 房间总数
        /// </summary>
        public int AllCount { get { return Rooms.Count(); } }

        public List<View_RoomInfo> Available
        {
            get
            {
                using (var db = new TavernManageEntities())
                {
                    var stateid = db.T_RoomStateType.Where(state => state.StateName == "空房").First().StateID;
                    return Rooms = db.View_RoomInfo.Where(room => room.状态编号 == stateid).ToList();
                }
            }
        }


    }
}