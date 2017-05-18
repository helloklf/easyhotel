using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Term2_Client
{
    public class AreaInfo
    {
        public AreaInfo() { }
        public AreaInfo(int i, string s, int id) { this.areaId = i; this.areaName = s; this.areaPid = id; }


        private int areaId;

        public int AreaId
        {
            get { return areaId; }
            set { areaId = value; }
        }
        private string areaName;

        public string AreaName
        {
            get { return areaName; }
            set { areaName = value; }
        }
        private int areaPid;

        public int AreaPid
        {
            get { return areaPid; }
            set { areaPid = value; }
        }
    }
}
