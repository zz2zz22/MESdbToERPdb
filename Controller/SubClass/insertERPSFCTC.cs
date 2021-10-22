using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESdbToERPdb
{
    public class insertERPSFCTC
    {
        string TOID = "";
        double LOTSIZE_B02 = 0;
        string ITEMID_TC047 = "";
        string ITEMNAME_TC048 = "";
        string TRANSNO = "";
        string TO008 = "";
        public int Sequence_OP_REAL_RUN = 0;

        public void InsertdataToERP(string barcode, string model, string output, string NG, string date, string time)
        {
            string[] QR = barcode.Split(';');
            string[] ML = QR[0].Split('-');

            string month = date.Substring(2, 6);
            sqlERPCon sqlERPCON = new sqlERPCon();

            string TC002 = GetTC002();
            TO008 = TC002;
            TOID = "D201-" + TC002;



        }
        public string GetTC002()
        {
            string _TC002 = "";
            string dateFormat = DateTime.Now.ToString("yyMM");
            string countFormatReset = "0001";
            int countUp = 0;
            sqlERPCon data = new sqlERPCon();
            string strData = data.sqlExecuteScalarString("select max(TB002) from SFCTB where TB001 = 'D201'  ");
            if (strData != null && strData.Trim().Count() == 8)
            {
                string DateDatabase = strData.Trim().Substring(0, 4);
                string strCount = strData.Trim().Substring(4);
                if (dateFormat == DateDatabase)
                {
                    countUp = int.Parse(strCount) + 1;
                    string countFormatup = countUp.ToString("0000");
                    _TC002 = dateFormat + countFormatup;
                }
                else
                {
                    _TC002 = dateFormat + countFormatReset;
                }
            }

            return _TC002;
        }
        public string GetTC002_Down()
        {
            string _TC002 = "";
            string dateFormat = DateTime.Now.ToString("yyMM");
            string firstvalue = dateFormat + "9999";
            sqlERPCon data = new sqlERPCon();
            string check9999 = data.sqlExecuteScalarString("select count(*) TB002 from m_SFTKEY where TB002 = '" + firstvalue + "'");
            if (int.Parse(check9999) != 0)
            {
                string minTB002 = data.sqlExecuteScalarString("select min(TB002) from m_SFTKEY where TB002 like '" + dateFormat + "%'");
                int valueset = int.Parse(minTB002.Trim().Substring(4, 4));
                valueset = valueset - 1;
                _TC002 = dateFormat + valueset.ToString("0000");
            }
            else
            {
                _TC002 = firstvalue;
            }
            //insertnextvalue
            string sqlinsert = "insert into m_SFTKEY(TB002, datetimeRST) values ('" + _TC002 + "', getdate()) ";
            data.sqlExecuteNonQuery(sqlinsert, false);
            return _TC002;
        }
    }
}
