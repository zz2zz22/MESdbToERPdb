using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESdbToERPdb
{
    public class insertERPSFCTC
    { 
        public void InsertdataToERP(string barcode, string model, string output, string NG, string date, string time)
        {
            string[] QR = barcode.Split(';');
            string[] ML = QR[0].Split('-');

            
        }
    }
}
