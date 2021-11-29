using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESdbToERPdb
{
    public class insertERP_D101
    {

        string ITEMID_TC047 = "";
        string ITEMNAME_TC048 = "";
        string ITEMDESCRIPTION = "";
        string TC009 = "";

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
            string strData = data.sqlExecuteScalarString("select max(TB002) from SFCTB where TB001 = 'D101' and TB002 < '" + dateNMFormat + "%'");
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

        public string GetWarehouse(string orgCode)
        {
            string warehouse = "";
            if (orgCode == "A01")
                warehouse = "A07";
            if (orgCode == "P01")
                warehouse = "P07";
            if (orgCode == "J01")
                warehouse = "J01";
            if (orgCode == "B01")
                warehouse = "B09";
            return warehouse;
        }

        public void InsertdataToERP_D101(string MP, string SP, string orgCode, string output, string transdate, string date, string time)
        {
            try
            {
                
                string dateTm = Convert.ToDateTime(date).ToString("yyyyMMdd");
                string month = date.Substring(2, 6);

                sqlERPCon sqlERPCon = new sqlERPCon();

                string TC002 = GetTC002();

                int NG = 0;

                string TA006 = sqlERPCon.sqlExecuteScalarString("select distinct TA006 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                string TA007 = sqlERPCon.sqlExecuteScalarString("select distinct TA007 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");

                string TC047 = sqlERPCon.sqlExecuteScalarString("select distinct TA006 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                ITEMID_TC047 = TC047;
                string TC048 = sqlERPCon.sqlExecuteScalarString("select distinct TA034 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                ITEMNAME_TC048 = TC048;
                ITEMDESCRIPTION = sqlERPCon.sqlExecuteScalarString("select distinct TA035 from MOCTA where TA006 = '" + TC047 + "'");

                TC009 = sqlERPCon.sqlExecuteScalarString("select distinct TA004 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010'");

                int TC036 = int.Parse(output) + NG;
                string MOCTA56 = sqlERPCon.sqlExecuteScalarString("select distinct TA056 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                double MOCTA57 = double.Parse(sqlERPCon.sqlExecuteScalarString("select distinct TA057 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'"));
                string MOCTA70 = sqlERPCon.sqlExecuteScalarString("select distinct TA070 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");

                int MB023 = int.Parse(sqlERPCon.sqlExecuteScalarString("select distinct MB023 from INVMB where MB001 = '" + TC047 + "'"));
                int MB024 = int.Parse(sqlERPCon.sqlExecuteScalarString("select distinct MB024 from INVMB where MB001 = '" + TC047 + "'"));

                string TC033 = (Convert.ToDateTime(date).AddDays(MB023)).ToString("yyyyMMdd");
                string TC034 = (Convert.ToDateTime(date).AddDays(MB024)).ToString("yyyyMMdd");

                int OutputQty = int.Parse(output);
                
                int Total = OutputQty + NG;
                double DLDonvi = GetDonVi(TC047);
                double KLOK = DLDonvi * OutputQty;
                double KLNG = DLDonvi * NG;
                double KLTotal = Total * DLDonvi;

                string TB005 = GetWarehouse(orgCode);
                string TB006 = sqlERPCon.sqlExecuteScalarString("select distinct MC002 from CMSMC where MC001 = '" + TB005 + "'");
                
                sqlERPTest_TLVN2 sqlInsert = new sqlERPTest_TLVN2();
                StringBuilder sqlInsertSFCTC = new StringBuilder();
                sqlInsertSFCTC.Append("insert into SFCTC ");
                sqlInsertSFCTC.Append(@"(COMPANY,CREATOR,USR_GROUP,CREATE_DATE,MODIFIER,MODI_DATE,FLAG,CREATE_TIME,CREATE_AP,CREATE_PRID,MODI_TIME,MODI_AP,MODI_PRID,");
                sqlInsertSFCTC.Append(@"TC001,TC002,TC003,TC004,TC005,TC006,TC007,TC008,TC009,TC010,TC011,TC012,TC013,TC014,TC015,TC016,TC017,TC018,TC019,TC020,");
                sqlInsertSFCTC.Append(@"TC021,TC022,TC023,TC024,TC025,TC026,TC027,TC033,TC034,TC035,TC036,TC037,TC038,TC039,TC040,");
                sqlInsertSFCTC.Append(@"TC041,TC042,TC043,TC044,TC045,TC046,TC047,TC048,TC049,TC050,TC051,TC052,TC053,TC054,TC055,TC059,TC060)");
                sqlInsertSFCTC.Append(" values ( ");
                sqlInsertSFCTC.Append("'TLVN2','BQC01','JG01','" + dateTm + "','BQC01','" + dateTm + "',2,'" + time + "','SFT','SFCMI05','" + time + "','SFT','SFCMI05',");
                sqlInsertSFCTC.Append("'D101','" + TC002 + "','0001','" + MP + "','" + SP + "','','','0010','" + TC009 + "','PCS','','','6'," + output + ",0," + NG + ",0,0,0,0,");
                sqlInsertSFCTC.Append("0,'Y','" + TB005 + "','',0,'N','N','" + TC033 + "','" + TC034 + "','N'," + output + ",0,'" + transdate + "','0','',"); // chinh sua TC033 + TC034
                sqlInsertSFCTC.Append("'" + TA006 + "'," + KLTotal + "," + KLOK + ",0," + KLNG + ",0,'" + TC047 + "','" + TC048 + "','" + ITEMDESCRIPTION + "','KG','0','','0','0','N','N','0'");  //check lai TC050
                sqlInsertSFCTC.Append(")");
                sqlInsert.sqlExecuteNonQuery(sqlInsertSFCTC.ToString(), false);

                StringBuilder sqlInsertSFCTB = new StringBuilder();
                sqlInsertSFCTB.Append("insert into SFCTB ");
                sqlInsertSFCTB.Append("(COMPANY,CREATOR,USR_GROUP,CREATE_DATE,MODIFIER,MODI_DATE,FLAG,CREATE_TIME,CREATE_AP,CREATE_PRID,MODI_TIME,MODI_AP,MODI_PRID,");
                sqlInsertSFCTB.Append("TB001,TB002,TB003,TB004,TB005,TB006,TB007,TB008,TB009,TB010,TB011,TB012,TB013,TB014,TB015,TB016,TB017,TB018,TB019,TB020,");
                sqlInsertSFCTB.Append(" TB021,TB022,TB023,TB024,TB025,TB026,TB027,TB028,TB029,TB030,TB031,TB034,TB036,TB037,TB038,TB039,");
                sqlInsertSFCTB.Append("TB200,TB201,TB202)");
                sqlInsertSFCTB.Append(" values ( ");
                sqlInsertSFCTB.Append("'TLVN2','BQC01','JG01','" + dateTm + "','BQC01','" + dateTm + "',2,'" + time + "','SFT','SFCMI05','" + time + "','SFT','SFCMI05',");
                sqlInsertSFCTB.Append("'D101','" + TC002 + "','" + transdate + "','3','" + TB005 + "','" + TB006 + "','1','" + TA006 + "','" + TA007 + "','TL','0','N','Y','','" + transdate + "','MES','N','','','',"); //check va lay data TB005 + 6
                sqlInsertSFCTB.Append("'','','1','N','" + month + "'," + MOCTA57 + ",'0','','0','0','0','" + MOCTA70 + "','VND',1,'','',");
                sqlInsertSFCTB.Append(TC036 + "," + output + "," + NG + ")");
                sqlInsert.sqlExecuteNonQuery(sqlInsertSFCTB.ToString(), false);
                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Generated Form :", "D101-" + TC002);
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertdataToERP(string barcode, string output, string NG)", ex.Message);
            }
        }
        public string CheckTA032(string MP, string SP)
        {
            sqlERPCon con = new sqlERPCon();
            
            double TA010 = double.Parse(con.sqlExecuteScalarString("select distinct TA010 from SFCTA where TA001 = '" + MP + "' and TA002 ='" + SP + "' and TA003 = '0010'"));
            double TA011 = double.Parse(con.sqlExecuteScalarString("select distinct TA011 from SFCTA where TA001 = '" + MP + "' and TA002 ='" + SP + "' and TA003 = '0010'"));
            double TA012 = double.Parse(con.sqlExecuteScalarString("select distinct TA012 from SFCTA where TA001 = '" + MP + "' and TA002 ='" + SP + "' and TA003 = '0010'"));
            if (TA010 == 0 && TA011 == 0 && TA012 == 0)
            {
                return "Y";
            }
            else return "N";
        }
        public void updateERPD101(string MP, string SP, string output, string transdate, string date, string time)
        {
            try
            {
                sqlERPCon data = new sqlERPCon();
                string TC047 = data.sqlExecuteScalarString("select distinct TA006 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                int OutputQty = int.Parse(output);
                int NGQty = 0;
                int Total = OutputQty + NGQty;
                double DLDonvi = GetDonVi(TC047);
                double KLOK = DLDonvi * OutputQty;
                double KLNG = DLDonvi * NGQty;
                double KLTotal = Total * DLDonvi;

                string dateTm = Convert.ToDateTime(date).ToString("yyyyMMdd");

                
                    sqlERPTest_TLVN2 sqlUpdate = new sqlERPTest_TLVN2();

                    StringBuilder updateSFCTA = new StringBuilder();
                    //update SFCTA 0010
                    updateSFCTA.Append("update SFCTA set TA010 = TA010 +" + output + " , TA011 = 0, TA012 = 0, TA013 = 0, TA014 = 0, TA015 = 0, TA016 = 0, TA017 = 0,TA030 = '"+ transdate+ "',TA031 = '"+ dateTm +"', TA032 = '"+ CheckTA032(MP,SP) +"', TA038 = TA038 + " + KLTotal + "  where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010' and TA004 = '" + TC009 + "'");
                    sqlUpdate.sqlExecuteNonQuery(updateSFCTA.ToString(), false);

                    //phiếu D1 không có 0020

                    //update MOCTA
                    StringBuilder UpdateMOCTA = new StringBuilder();
                    UpdateMOCTA.Append(" update MOCTA set TA011 = '3', TA012 = '" + dateTm + "' , MODIFIER ='BQC01', MODI_DATE ='" + dateTm + "',MODI_TIME ='" + time + "', MODI_AP ='SFT', MODI_PRID ='SFCMI05'  where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                    sqlUpdate.sqlExecuteNonQuery(UpdateMOCTA.ToString(), false);
                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Updated code: ", MP + SP);
                
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "updateERPD101(string " + MP + "-" + SP + ")", ex.Message);
            }
        }
    }
}
