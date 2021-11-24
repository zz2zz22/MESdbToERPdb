using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESdbToERPdb
{
    public class insertERP_D201
    {
        string TOID = "";
        double LOTSIZE_B02 = 0;
        string ITEMID_TC047 = "";
        string ITEMNAME_TC048 = "";
        string ITEMDESCRIPTION = "";
        string TRANSNO = "";
        string TB039 = "";
        public int Sequence_OP_REAL_RUN = 0;
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

        public void InsertdataToERP_D201(string work_order_no, string model, string output, string NG, string date, string time)
        {
            try
            {
                string MP = work_order_no.Substring(0, 4);
                string SP = work_order_no.Substring(4);
                

                string month = date.Substring(2, 6);

                sqlERPCon sqlERPCon = new sqlERPCon();

                string TC002 = GetTC002();

                string TC047 = sqlERPCon.sqlExecuteScalarString("select distinct TA006 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                ITEMID_TC047 = TC047;
                string TC048 = sqlERPCon.sqlExecuteScalarString("select distinct TA034 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                ITEMNAME_TC048 = TC048;
                ITEMDESCRIPTION = sqlERPCon.sqlExecuteScalarString("select distinct TA035 from MOCTA where TA006 = '" + TC047 + "'");

                string TA007 = sqlERPCon.sqlExecuteScalarString("select distinct TA007 from SFCTA where TA004 ='B01' and  TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                int TC036 = int.Parse(output) + int.Parse(NG);

                TRANSNO = TB039;//kg dùng SFT nua nen TB038 & TB039 = 0

                int OutputQty = int.Parse(output);
                int NGQty = int.Parse(NG);
                int Total = OutputQty + NGQty;
                double DLDonvi = GetDonVi(TC047);
                double KLOK = DLDonvi * OutputQty;
                double KLNG = DLDonvi * NGQty;
                double KLTotal = Total * DLDonvi;


                sqlERPCon sqlInsert = new sqlERPCon();
                StringBuilder sqlInsertSFCTC = new StringBuilder();
                sqlInsertSFCTC.Append("insert into SFCTC ");
                sqlInsertSFCTC.Append(@"(COMPANY,CREATOR,USR_GROUP,CREATE_DATE,MODIFIER,MODI_DATE,FLAG,CREATE_TIME,CREATE_AP,CREATE_PRID,MODI_TIME,MODI_AP,MODI_PRID,");
                sqlInsertSFCTC.Append(@"TC001,TC002,TC003,TC004,TC005,TC006,TC007,TC008,TC009,TC010,TC011,TC012,TC013,TC014,TC015,TC016,TC017,TC018,TC019,TC020,");
                sqlInsertSFCTC.Append(@"TC021,TC022,TC023,TC024,TC025,TC026,TC027,TC033,TC034,TC035,TC036,TC037,TC038,TC039,TC040,");
                sqlInsertSFCTC.Append(@"TC041,TC042,TC043,TC044,TC045,TC046,TC047,TC048,TC049,TC050,TC051,TC055)");
                sqlInsertSFCTC.Append(" values ( ");
                sqlInsertSFCTC.Append("'TLVN2','BQC01','JG01','" + date + "','BQC01','" + date + "',2,'" + time + "','SFT','SFCMI05','" + time + "','SFT','SFCMI05',");
                sqlInsertSFCTC.Append("'D201','" + TC002 + "','0001','" + MP + "','" + SP + "','" + null + "','" + null + "','0020','B02','PCS','','','1'," + output + ",0," + NG + ",0,0,0,0,");
                sqlInsertSFCTC.Append("0,'Y','B01','',0,'N','N','" + date + "','" + date + "','N'," + TC036 + ",0,'" + date + "','0','',");
                sqlInsertSFCTC.Append("'B01'," + KLTotal + "," + KLOK + ",0," + KLNG + ",0,'" + TC047 + "','" + TC048 + "','" + ITEMDESCRIPTION + "','KG','0','N'");  //update new 21-oct
                sqlInsertSFCTC.Append(")");
                sqlInsert.sqlExecuteNonQuery(sqlInsertSFCTC.ToString(), false);

                StringBuilder sqlInsertSFCTB = new StringBuilder();
                sqlInsertSFCTB.Append("insert into SFCTB ");
                sqlInsertSFCTB.Append("(COMPANY,CREATOR,USR_GROUP,CREATE_DATE,MODIFIER,MODI_DATE,FLAG,CREATE_TIME,CREATE_AP,CREATE_PRID,MODI_TIME,MODI_AP,MODI_PRID,");
                sqlInsertSFCTB.Append("TB001,TB002,TB003,TB004,TB005,TB006,TB007,TB008,TB009,TB010,TB011,TB012,TB013,TB014,TB015,TB016,TB017,TB018,TB019,TB020,");
                sqlInsertSFCTB.Append(" TB021,TB022,TB023,TB024,TB025,TB026,TB031,TB036,TB037,TB038,TB039,");
                sqlInsertSFCTB.Append("TB200,TB201,TB202)");

                sqlInsertSFCTB.Append(" values ( ");
                sqlInsertSFCTB.Append("'TLVN2','BQC01','JG01','" + date + "','BQC01','" + date + "',2,'" + time + "','SFT','SFCMI05','" + time + "','SFT','SFCMI05',");
                sqlInsertSFCTB.Append("'D201','" + TC002 + "','" + date + "','1','B01','" + TA007 + "','1','B01','" + TA007 + "','TL',0,'N','Y','','" + date + "','ERP','N','','1','',");
                sqlInsertSFCTB.Append("'','1','1','','" + month + "',0.2,'0','VND',1,'','" + TRANSNO + "',");
                sqlInsertSFCTB.Append(int.Parse(output) + int.Parse(NG) + "," + output + "," + NG + " "); //ap them chi dieu yeu cau
                sqlInsertSFCTB.Append(")");
                sqlInsert.sqlExecuteNonQuery(sqlInsertSFCTB.ToString(), false);
                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Generated Form :", "D201-" + TC002);
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertdataToERP(string barcode, string output, string NG)", ex.Message);
            }
        }

        public void updateERP(string barcode, string model, string output, string NG, string date, string time)
        {
            try
            {
                string[] QR = barcode.Split(';');
                string[] ML = QR[0].Split('-');

                sqlERPCon data = new sqlERPCon();
                string TC047 = data.sqlExecuteScalarString("select distinct TA006 from MOCTA where TA001 = '" + ML[0] + "' and TA002 = '" + ML[1] + "'");
                int OutputQty = int.Parse(output);
                int NGQty = int.Parse(NG);
                int Total = OutputQty + NGQty;
                double DLDonvi = GetDonVi(TC047);
                double KLOK = DLDonvi * OutputQty;
                double KLNG = DLDonvi * NGQty;
                double KLTotal = Total * DLDonvi;

                StringBuilder updateSFCTA = new StringBuilder();
                //update SFCTA row B01
                updateSFCTA.Append("update SFCTA set TA011 = TA011 +" + output + " , TA012 = TA012+ " + NG + " , TA039 =TA039+ " + KLOK + " , TA040 = TA040 + " + KLNG + ", TA031 ='" + date + "' where TA001 = '" + ML[0] + "' and TA002 = '" + ML[1] + "' and TA003 = '" + "0010" + "' and TA004 = '" + "B01" + "'");
                sqlERPCon sqlUpdate = new sqlERPCon();
                sqlUpdate.sqlExecuteNonQuery(updateSFCTA.ToString(), false);

                //update SFCTA row B02
                StringBuilder updateSFCTAB02 = new StringBuilder();
                updateSFCTAB02.Append("update SFCTA set TA010 = TA010 + " + output + ", TA038 =TA038 + " + KLOK + " , MODIFIER ='BQC01', MODI_DATE ='" + date + "',MODI_TIME ='" + time + "', MODI_AP ='SFT', MODI_PRID ='SFCMI05', TA030= '" + date + "' where TA001 = '" + ML[0] + "' and TA002 = '" + ML[1] + "' and TA003 ='0020' and TA004 = 'B02' ");
                sqlUpdate.sqlExecuteNonQuery(updateSFCTAB02.ToString(), false);

                //update SFCTA Day
                StringBuilder UpdateMOCTA = new StringBuilder();
                UpdateMOCTA.Append(" update MOCTA set TA018 = TA018 + " + NG + ", TA047 = TA047 + " + KLNG + " , MODIFIER ='BQC01', MODI_DATE ='" + date + "',MODI_TIME ='" + time + "', MODI_AP ='SFT', MODI_PRID ='SFCMI05'  where TA001 = '" + ML[0] + "' and TA002 = '" + ML[1] + "' ");
                sqlUpdate.sqlExecuteNonQuery(UpdateMOCTA.ToString(), false);
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "updateERP(string barcode)", ex.Message);
            }
        }
    }
}
