using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESdbToERPdb
{
    public class insertERP_D201
    {
        string ITEMID_TC047 = "";
        string ITEMNAME_TC048 = "";
        string ITEMDESCRIPTION = "";
        string TC007 = "";
        string TC009 = "";
        public string CheckTransDate(DateTime date)
        {
            string transDate = date.ToString("yyyy-MM-dd");
            DateTime dateCheckMax = Convert.ToDateTime(transDate + " 08:00:00");
            DateTime dateCheckMin = Convert.ToDateTime(transDate + " 00:00:00");
            TimeSpan ts = new TimeSpan(1,0,0,0);
            if ((date < dateCheckMax || date == dateCheckMax) && (date > dateCheckMin || date == dateCheckMin))
            {
                date = date.Subtract(ts);
            }
            return date.ToString("yyyyMMdd");
        }
        public string GetTC002()
        {
            string _TC002 = "";
            DateTime date = DateTime.Now;
            DateTime nextMonth = date.AddMonths(1);
            string dateNMFormat = nextMonth.ToString("yyMM");
            string dateFormat = date.ToString("yyMM");
            string countFormatReset = "0001";
            int countUp = 0;
            
            sqlERPTest_TLVN2 data = new sqlERPTest_TLVN2(); //chỉnh thành ERPCon khi đưa vào chính thức
            string strData = data.sqlExecuteScalarString("select max(TB002) from SFCTB where TB001 = 'D201' and TB002 < '" + dateNMFormat + "%'");
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

        public static double GetDonVi(string itemNo)
        {
            sqlERPCon sqlERPCON = new sqlERPCon();
            double DonVi = 0;
            string MD003 = sqlERPCON.sqlExecuteScalarString("select distinct MD003 from INVMD where MD001 = '" + itemNo + "' and MD002 = 'KG'");
            string MD004 = sqlERPCON.sqlExecuteScalarString("select distinct MD004 from INVMD where MD001 = '" + itemNo + "' and MD002 = 'KG'");
            double DV_MD003 = double.Parse(MD003);
            double DV_MD004 = double.Parse(MD004);
            if (DV_MD003 == 0 || DV_MD004 == 0)
            {
                return 0;
            }
            else
            {
                DonVi = DV_MD003 / DV_MD004;
                return DonVi;
            }

        }

        public void InsertdataToERP_D201(string MP, string SP, string output, string NG, DateTime tdate, string date, string time)
        {
            try
            {
                string dateTm = Convert.ToDateTime(date).ToString("yyyyMMdd");
                string month = dateTm.Substring(2, 6);

                string transdate = CheckTransDate(tdate);

                sqlERPCon sqlERPCon = new sqlERPCon();

                string TC002 = GetTC002();

                string TC047 = sqlERPCon.sqlExecuteScalarString("select distinct TA006 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                ITEMID_TC047 = TC047;
                string TC048 = sqlERPCon.sqlExecuteScalarString("select distinct TA034 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                ITEMNAME_TC048 = TC048.Replace("'", "''");
                ITEMDESCRIPTION = sqlERPCon.sqlExecuteScalarString("select distinct TA035 from MOCTA where TA006 = '" + TC047 + "'");

                TC007 = sqlERPCon.sqlExecuteScalarString("select distinct TA004 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010'");
                TC009 = sqlERPCon.sqlExecuteScalarString("select distinct TA004 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0020'");


                string TA006 = sqlERPCon.sqlExecuteScalarString("select distinct TA006 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                string TA007 = sqlERPCon.sqlExecuteScalarString("select distinct TA007 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                
                int TC036 = int.Parse(output) + int.Parse(NG);
                string MOCTA56 = sqlERPCon.sqlExecuteScalarString("select distinct TA056 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                double MOCTA57 = double.Parse(sqlERPCon.sqlExecuteScalarString("select distinct TA057 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'"));
                string MOCTA70 = sqlERPCon.sqlExecuteScalarString("select distinct TA070 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");

                int MB023 = int.Parse(sqlERPCon.sqlExecuteScalarString("select distinct MB023 from INVMB where MB001 = '" + TC047 + "'"));
                int MB024 = int.Parse(sqlERPCon.sqlExecuteScalarString("select distinct MB024 from INVMB where MB001 = '" + TC047 + "'"));
                
                string TC033 = (Convert.ToDateTime(date).AddDays(MB023)).ToString("yyyyMMdd");
                string TC034 = (Convert.ToDateTime(date).AddDays(MB024)).ToString("yyyyMMdd");

                

                int OutputQty = int.Parse(output);
                int NGQty = int.Parse(NG);
                int Total = OutputQty + NGQty;
                double DLDonvi = GetDonVi(TC047);
                double KLOK = DLDonvi * OutputQty;
                double KLNG = DLDonvi * NGQty;
                double KLTotal = Total * DLDonvi;

                if (TC009 != "")
                {
                    //kg dùng SFT nữa nên TB038 & TB039 để trống
                    sqlERPTest_TLVN2 sqlInsert = new sqlERPTest_TLVN2();
                    StringBuilder sqlInsertSFCTC = new StringBuilder();
                    sqlInsertSFCTC.Append("insert into SFCTC ");
                    sqlInsertSFCTC.Append(@"(COMPANY,CREATOR,USR_GROUP,CREATE_DATE,MODIFIER,MODI_DATE,FLAG,CREATE_TIME,CREATE_AP,CREATE_PRID,MODI_TIME,MODI_AP,MODI_PRID,");
                    sqlInsertSFCTC.Append(@"TC001,TC002,TC003,TC004,TC005,TC006,TC007,TC008,TC009,TC010,TC011,TC012,TC013,TC014,TC015,TC016,TC017,TC018,TC019,TC020,");
                    sqlInsertSFCTC.Append(@"TC021,TC022,TC023,TC024,TC025,TC026,TC027,TC033,TC034,TC035,TC036,TC037,TC038,TC039,TC040,");
                    sqlInsertSFCTC.Append(@"TC041,TC042,TC043,TC044,TC045,TC046,TC047,TC048,TC049,TC050,TC051,TC053,TC054,TC055)");
                    sqlInsertSFCTC.Append(" values ( ");
                    sqlInsertSFCTC.Append("'TLVN2','BQC01','JG01','" + dateTm + "','BQC01','" + dateTm + "',2,'" + time + "','SFT','SFCMI05','" + time + "','SFT','SFCMI05',");
                    sqlInsertSFCTC.Append("'D201','" + TC002 + "','0001','" + MP + "','" + SP + "','0010','" + TC007 + "','0020','" + TC009 + "','PCS','','','1'," + output + ",0," + NG + ",0,0,0,0,");
                    sqlInsertSFCTC.Append("0,'Y','" + TC007 + "','',0,'N','N','" + TC033 + "','" + TC034 + "','N'," + TC036 + ",0,'" + transdate + "','0','',"); // chinh sua TC033 + TC034 25/11
                    sqlInsertSFCTC.Append("'" + TA006 + "'," + KLTotal + "," + KLOK + ",0," + KLNG + ",0,'" + TC047 + "','" + ITEMNAME_TC048 + "','" + ITEMDESCRIPTION + "','KG','0','0','0','N'");
                    sqlInsertSFCTC.Append(")");
                    sqlInsert.sqlExecuteNonQuery(sqlInsertSFCTC.ToString(), false);

                    StringBuilder sqlInsertSFCTB = new StringBuilder();
                    sqlInsertSFCTB.Append("insert into SFCTB ");
                    sqlInsertSFCTB.Append("(COMPANY,CREATOR,USR_GROUP,CREATE_DATE,MODIFIER,MODI_DATE,FLAG,CREATE_TIME,CREATE_AP,CREATE_PRID,MODI_TIME,MODI_AP,MODI_PRID,");
                    sqlInsertSFCTB.Append("TB001,TB002,TB003,TB004,TB005,TB006,TB007,TB008,TB009,TB010,TB011,TB012,TB013,TB014,TB015,TB016,TB017,TB018,TB019,TB020,");
                    sqlInsertSFCTB.Append(" TB021,TB022,TB023,TB024,TB025,TB026,TB027,TB028,TB031,TB034,TB036,TB037,TB038,TB039,");
                    sqlInsertSFCTB.Append("TB200,TB201,TB202)");
                    sqlInsertSFCTB.Append(" values ( ");
                    sqlInsertSFCTB.Append("'TLVN2','BQC01','JG01','" + dateTm + "','BQC01','" + dateTm + "',2,'" + time + "','SFT','SFCMI05','" + time + "','SFT','SFCMI05',");
                    sqlInsertSFCTB.Append("'D201','" + TC002 + "','" + transdate + "','1','" + TA006 + "','" + TA007 + "','1','" + TA006 + "','" + TA007 + "','TL',0,'N','Y','','" + transdate + "','MES','N','','','',");
                    sqlInsertSFCTB.Append("'','" + MOCTA56 + "','','','" + month + "'," + MOCTA57 + ",'0','','0','" + MOCTA70 + "','VND',1,'','',");
                    sqlInsertSFCTB.Append(TC036 + "," + output + "," + NG );
                    sqlInsertSFCTB.Append(")");
                    sqlInsert.sqlExecuteNonQuery(sqlInsertSFCTB.ToString(), false);
                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Generated Form :", "D201-" + TC002);
                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Code :", MP + "-" + SP);
                }
                else if (TC009 == "")
                {
                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Không thể tạo phiếu do thiếu mã quy trình 0020: ", MP + SP);
                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertdataToERP(string barcode, string output, string NG)", ex.Message);
            }
        }

        public void updateERPD201(string MP, string SP, string output, string NG, DateTime tdate,  string date, string time)
        {
            try
            {
                string transdate = CheckTransDate(tdate);
                sqlERPCon data = new sqlERPCon();
                string TC047 = data.sqlExecuteScalarString("select distinct TA006 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                int OutputQty = int.Parse(output);
                int NGQty = int.Parse(NG);
                int Total = OutputQty + NGQty;
                double DLDonvi = GetDonVi(TC047);
                double KLOK = DLDonvi * OutputQty;
                double KLNG = DLDonvi * NGQty;
                double KLTotal = Total * DLDonvi;

                string dateTm = Convert.ToDateTime(date).ToString("yyyyMMdd");

                if (TC009 != "")
                {
                    sqlERPTest_TLVN2 sqlUpdate = new sqlERPTest_TLVN2();

                    StringBuilder updateSFCTA = new StringBuilder();
                    //update SFCTA 0010
                    updateSFCTA.Append("update SFCTA set TA011 = TA011 +" + output + " , TA012 = TA012+ " + NG + " , TA039 =TA039+ " + KLOK + " , TA040 = TA040 + " + KLNG + " where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '" + "0010" + "' and TA004 = '" + TC007 + "'");
                    sqlUpdate.sqlExecuteNonQuery(updateSFCTA.ToString(), false);

                    //update SFCTA 0020
                    StringBuilder updateSFCTAB02 = new StringBuilder();
                    updateSFCTAB02.Append("update SFCTA set TA010 = TA010 + " + output + ", TA038 =TA038 + " + KLOK + " , MODIFIER ='BQC01', MODI_DATE ='" + dateTm + "',MODI_TIME ='" + time + "', MODI_AP ='SFT', MODI_PRID ='SFCMI05', TA030= '" + transdate + "' where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 ='0020' and TA004 = '" + TC009 + "' ");
                    sqlUpdate.sqlExecuteNonQuery(updateSFCTAB02.ToString(), false);

                    //update MOCTA
                    StringBuilder UpdateMOCTA = new StringBuilder();
                    UpdateMOCTA.Append(" update MOCTA set TA018 = TA018 + " + NG + ", TA047 = TA047 + " + KLNG + " , MODIFIER ='BQC01', MODI_DATE ='" + dateTm + "',MODI_TIME ='" + time + "', MODI_AP ='SFT', MODI_PRID ='SFCMI05'  where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                    sqlUpdate.sqlExecuteNonQuery(UpdateMOCTA.ToString(), false);
                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Updated code: ", MP + SP);
                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "updateERPD201(string " + MP + "-" + SP + ")", ex.Message);
            }
        }
    }
}
