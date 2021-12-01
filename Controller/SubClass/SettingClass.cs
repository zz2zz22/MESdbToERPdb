﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESdbToERPdb
{
    [Serializable]
    public class SettingClass
    {
        public string OfflineServer { get; set; }
        public string userOffline { get; set; }
        public string password { get; set; }
        public bool usingOfftlineServer { get; set; }
        public string PathListProduct { get; set; }
        public int TimmerBackgroudWorker { get; set; }

    }
}
