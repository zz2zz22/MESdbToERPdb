using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESdbToERPdb
{
    [Serializable]
    public class SettingClass
    {
        public string din;
        public int interval;
        public string dIn 
        { 
            get { return din;}
            set { din = value; }
        }
        public int Interval
        {
            get { return interval;}
            set { interval = value; }
        }
    }
}
