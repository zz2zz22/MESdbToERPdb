using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClosedXML.Excel;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace MESdbToERPdb
{
    public class FixData
    {

        public static void addFixTB(DateTime date, string erpCode, string moveNo, string status)
        { 
            string transDate = date.ToString("yyyy-MM-dd");
            string transTime = date.ToString("HH:mm:ss");

            sqlSOFTCon sqlInsert = new sqlSOFTCon();
            StringBuilder sqlInsertFixData = new StringBuilder();
            sqlInsertFixData.Append("insert into v_FixData ");
            sqlInsertFixData.Append(@"(TRANS_DATE,TRANS_TIME,PROD_CODE,MOVE_NO,STATUS)");
            sqlInsertFixData.Append(" values ( ");
            sqlInsertFixData.Append("'" + transDate + "', '" + transTime + "', '" + erpCode + "', '" + moveNo + "', '" + status + "'");
            sqlInsertFixData.Append(")");
            sqlInsert.sqlExecuteNonQuery(sqlInsertFixData.ToString(), false);
        }
    }
}
