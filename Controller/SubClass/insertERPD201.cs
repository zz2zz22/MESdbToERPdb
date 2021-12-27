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
        string TB013 = "Y";
        bool isTicketCreated = false;
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
            return date.ToString("yyyy-MM-dd HH:mm:ss");
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

        public string getFirstD201ofOrganization(string orgCode, string autoStart, string autoEnd, string MP, string SP)
        {
            sqlERPTest_TLVN2 con = new sqlERPTest_TLVN2();
            DateTime date = DateTime.Now;
            string dateFormat = date.ToString("yyyyMMdd");
            string strData = "";
            if (orgCode != "B01")
            {
                 strData = con.sqlExecuteScalarString("select max(TC002) from SFCTC where TC001 = 'D201' and TC004 = '" + MP + "' and TC005 = '" + SP + "' and CREATE_DATE = '" + dateFormat + "' and CREATE_TIME < '" + autoEnd + "' and CREATE_TIME >= '" + autoStart + "'");
            }
            return strData;
        }

        public string getTicketNumber(string ticketCode)
        {
            sqlERPTest_TLVN2 con = new sqlERPTest_TLVN2();
            string nextTC003 = con.sqlExecuteScalarString("select max(TC003) from SFCTC where TC001 = 'D201' and TC002 = '" + ticketCode + "'");
            int countUp = int.Parse(nextTC003) + 1;
            string countFormatup = countUp.ToString("0000");
            return countFormatup;
        }

        public void InsertdataToERP_D201(string MP, string SP, string orgCode, double output, double NG,double RW, DateTime tdate, string date, string time, string timeIn, string timeOut, string MES_move_no)
        {
            try
            {
                bool isDataMissing = false;
                string dateTm = Convert.ToDateTime(date).ToString("yyyyMMdd");
                string month = dateTm.Substring(0, 6);

                string mesTransDate = CheckTransDate(tdate);

                sqlERPCon sqlERPCon = new sqlERPCon();

                string TC002 = GetTC002();

                string TC047 = sqlERPCon.sqlExecuteScalarString("select distinct TA006 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                ITEMID_TC047 = TC047;
                if (TC047 == String.Empty)
                    isDataMissing = true;
                string TC048 = sqlERPCon.sqlExecuteScalarString("select distinct TA034 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                ITEMNAME_TC048 = TC048.Replace("'", "''");
                if (TC048 == String.Empty)
                    isDataMissing = true;
                
                ITEMDESCRIPTION = sqlERPCon.sqlExecuteScalarString("select distinct TA035 from MOCTA where TA006 = '" + TC047 + "'");

                TC007 = sqlERPCon.sqlExecuteScalarString("select distinct TA004 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010'");
                if (TC007 == String.Empty)
                    isDataMissing = true;
                TC009 = sqlERPCon.sqlExecuteScalarString("select distinct TA004 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0020'");
                if (TC009 == String.Empty)
                    isDataMissing = true;


                string TA006 = sqlERPCon.sqlExecuteScalarString("select distinct TA006 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                if (TA006 == String.Empty)
                    isDataMissing = true;
                string TA007 = sqlERPCon.sqlExecuteScalarString("select distinct TA007 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                if (TA007 == String.Empty)
                    isDataMissing = true;

                double TC036 = (output + NG) - RW ;
                string MOCTA56 = sqlERPCon.sqlExecuteScalarString("select distinct TA056 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                if (MOCTA56 == String.Empty)
                    isDataMissing = true;
                string getMOCTA57 = sqlERPCon.sqlExecuteScalarString("select distinct TA057 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                double MOCTA57 = 0;
                if (getMOCTA57 == String.Empty)
                    isDataMissing = true;
                else
                    MOCTA57 = double.Parse(getMOCTA57);
                string MOCTA70 = sqlERPCon.sqlExecuteScalarString("select distinct TA070 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                //if (MOCTA70 == String.Empty)
                //    isDataMissing = true;

                string MB023 = sqlERPCon.sqlExecuteScalarString("select distinct MB023 from INVMB where MB001 = '" + TC047 + "'");
                string MB024 = sqlERPCon.sqlExecuteScalarString("select distinct MB024 from INVMB where MB001 = '" + TC047 + "'");
                string TC033 = "";
                string TC034 = "";
                if (MB023 != String.Empty && MB023 != "0")
                {
                    TC033 = (Convert.ToDateTime(mesTransDate).AddDays(int.Parse(MB023))).ToString("yyyyMMdd");
                }
                if (MB024 != String.Empty && MB024 != "0")
                {
                    TC034 = (Convert.ToDateTime(mesTransDate).AddDays(int.Parse(MB024))).ToString("yyyyMMdd");
                }


                double Total = (output + NG) - RW;
                double DLDonvi = GetDonVi(TC047);
                double KLOK = DLDonvi * output;
                double KLNG = DLDonvi * NG;
                double KLTotal = Total * DLDonvi;

                sqlERPTest_TLVN2 data = new sqlERPTest_TLVN2();
                string getSFCTA010 = data.sqlExecuteScalarString("select distinct TA010 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010'");
                double SFCTA010 = 0;
                if (getSFCTA010 != String.Empty)
                    SFCTA010 = double.Parse(getSFCTA010);
                else
                    isDataMissing = true;

                string getSFCTA011 = data.sqlExecuteScalarString("select distinct TA011 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010'");
                double SFCTA011 = 0;
                if (getSFCTA010 != String.Empty)
                    SFCTA011 = double.Parse(getSFCTA011);
                else
                    isDataMissing = true;

                string getSFCTA012 = data.sqlExecuteScalarString("select distinct TA012 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010'");
                double SFCTA012 = 0;
                if (getSFCTA012 != String.Empty)
                    SFCTA012 = double.Parse(getSFCTA012);
                else
                    isDataMissing = true;
                double totalTA101112 = SFCTA010 - SFCTA011 - SFCTA012;

                string getSFCTA038 = data.sqlExecuteScalarString("select distinct TA038 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010'");
                double SFCTA038 = 0;
                if (getSFCTA038 != String.Empty)
                    SFCTA038 = double.Parse(getSFCTA038);
                else
                    isDataMissing = true;
                
                string getSFCTA039 = data.sqlExecuteScalarString("select distinct TA039 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010'");
                double SFCTA039 = 0;
                if (getSFCTA039 != String.Empty)
                    SFCTA039 = double.Parse(getSFCTA039);
                else
                    isDataMissing = true;

                string getSFCTA040 = data.sqlExecuteScalarString("select distinct TA040 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010'");
                double SFCTA040 = 0;
                if (getSFCTA040 != String.Empty)
                    SFCTA040 = double.Parse(getSFCTA040);
                else
                    isDataMissing = true;
                double totalTA383940 = SFCTA038 - SFCTA039 - SFCTA040;
                
                if (KLTotal > totalTA383940)
                {
                    TB013 = "N";
                }
                bool checkQty = false;
                if(TC036 > totalTA101112) {
                    checkQty = true;
                }
                string transdate = (Convert.ToDateTime(mesTransDate)).ToString("yyyyMMdd");

                string ticketCode = getFirstD201ofOrganization(orgCode, timeIn, timeOut, MP, SP);
                string ticketNumber = "";
                if (ticketCode != "")
                {
                    ticketNumber = getTicketNumber(ticketCode);
                }
                if (isDataMissing == false)
                {
                    if (ticketCode == "")
                    {
                        if (TC009 != "")
                        {
                            if (!checkQty)
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
                                sqlInsertSFCTC.Append("'TEST20211215','BQC01','JG01','" + dateTm + "','MES','" + dateTm + "',2,'" + time + "','SFT','SFCMI05','" + time + "','SFT','SFCMI05',");
                                sqlInsertSFCTC.Append("'D201','" + TC002 + "','0001','" + MP + "','" + SP + "','0010','" + TC007 + "','0020','" + TC009 + "','PCS','','','1'," + output + ",0," + NG + ",0,0,0,0,");
                                sqlInsertSFCTC.Append("0,'" + TB013 + "','" + TC007 + "','',0,'N','N','" + TC033 + "','" + TC034 + "','N'," + TC036 + ",0,'" + transdate + "','0','',"); // chinh sua TC033 + TC034 25/11
                                sqlInsertSFCTC.Append("'" + TA006 + "'," + KLTotal + "," + KLOK + ",0," + KLNG + ",0,'" + TC047 + "','" + ITEMNAME_TC048 + "','" + ITEMDESCRIPTION + "','KG','0','0','0','N'");
                                sqlInsertSFCTC.Append(")");
                                sqlInsert.sqlExecuteNonQuery(sqlInsertSFCTC.ToString(), false);

                                StringBuilder sqlInsertSFCTB = new StringBuilder();
                                sqlInsertSFCTB.Append("insert into SFCTB ");
                                sqlInsertSFCTB.Append("(COMPANY,CREATOR,USR_GROUP,CREATE_DATE,MODIFIER,MODI_DATE,FLAG,CREATE_TIME,CREATE_AP,CREATE_PRID,MODI_TIME,MODI_AP,MODI_PRID,");
                                sqlInsertSFCTB.Append("TB001,TB002,TB003,TB004,TB005,TB006,TB007,TB008,TB009,TB010,TB011,TB012,TB013,TB014,TB015,TB016,TB017,TB018,TB019,TB020,");
                                sqlInsertSFCTB.Append(" TB021,TB022,TB023,TB024,TB025,TB026,TB027,TB028,TB029,TB030,TB031,TB034,TB036,TB037,TB038,TB039,");
                                sqlInsertSFCTB.Append("TB200,TB201,TB202)");
                                sqlInsertSFCTB.Append(" values ( ");
                                sqlInsertSFCTB.Append("'TEST20211215','BQC01','JG01','" + dateTm + "','MES','" + dateTm + "',2,'" + time + "','SFT','SFCMI05','" + time + "','SFT','SFCMI05',");
                                sqlInsertSFCTB.Append("'D201','" + TC002 + "','" + transdate + "','1','" + TA006 + "','" + TA007 + "','1','" + TA006 + "','" + TA007 + "','TL',0,'N','" + TB013 + "','','" + transdate + "','MES','N','','','',");
                                sqlInsertSFCTB.Append("'','" + MOCTA56 + "','1','N','" + month + "'," + MOCTA57 + ",'0','','0','0','0','" + MOCTA70 + "','VND',1,'','',");
                                sqlInsertSFCTB.Append(TC036 + "," + output + "," + NG);
                                sqlInsertSFCTB.Append(")");
                                sqlInsert.sqlExecuteNonQuery(sqlInsertSFCTB.ToString(), false);
                                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Generated Form :", "D201-" + TC002);
                                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Code :", MP + "-" + SP);
                                DataReport.addReport(DataReport.RP_TYPE.Success, "D201", TC002, MP + SP, MES_move_no, TB013, "Đã tạo phiếu chuyển thành công");
                                isTicketCreated = true;
                            }
                            else
                            {
                                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Không thể tạo phiếu do SFCTA036 > SFCTA010 - SFCTA011 - SFCTA012.", " (Code : " + MP + "-" + SP + ")");
                                DataReport.addReport(DataReport.RP_TYPE.Fail, "", "", MP + SP, MES_move_no, "", "Không thể tạo phiếu do SFCTA036 > SFCTA010 - SFCTA011 - SFCTA012.");
                            }
                        }
                        else if (TC009 == "")
                        {
                            SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Không thể tạo phiếu do thiếu mã quy trình 0020: ", MP + SP);
                            DataReport.addReport(DataReport.RP_TYPE.Fail, "", "", MP + SP, MES_move_no, "", "Không thể tạo phiếu do thiếu dữ liệu mã quy trình 0020: ");
                        }
                    }
                    else
                    {
                        if (TC009 != "")
                        {
                            if (!checkQty)
                            {
                                sqlERPTest_TLVN2 sqlInsert = new sqlERPTest_TLVN2();
                                StringBuilder sqlInsertSFCTC = new StringBuilder();
                                sqlInsertSFCTC.Append("insert into SFCTC ");
                                sqlInsertSFCTC.Append(@"(COMPANY,CREATOR,USR_GROUP,CREATE_DATE,MODIFIER,MODI_DATE,FLAG,CREATE_TIME,CREATE_AP,CREATE_PRID,MODI_TIME,MODI_AP,MODI_PRID,");
                                sqlInsertSFCTC.Append(@"TC001,TC002,TC003,TC004,TC005,TC006,TC007,TC008,TC009,TC010,TC011,TC012,TC013,TC014,TC015,TC016,TC017,TC018,TC019,TC020,");
                                sqlInsertSFCTC.Append(@"TC021,TC022,TC023,TC024,TC025,TC026,TC027,TC033,TC034,TC035,TC036,TC037,TC038,TC039,TC040,");
                                sqlInsertSFCTC.Append(@"TC041,TC042,TC043,TC044,TC045,TC046,TC047,TC048,TC049,TC050,TC051,TC053,TC054,TC055)");
                                sqlInsertSFCTC.Append(" values ( ");
                                sqlInsertSFCTC.Append("'TL05112021','BQC01','JG01','" + dateTm + "','MES','" + dateTm + "',2,'" + time + "','SFT','SFCMI05','" + time + "','SFT','SFCMI05',");
                                sqlInsertSFCTC.Append("'D201','" + ticketCode + "','" + ticketNumber + "','" + MP + "','" + SP + "','0010','" + TC007 + "','0020','" + TC009 + "','PCS','','','1'," + output + ",0," + NG + ",0,0,0,0,");
                                sqlInsertSFCTC.Append("0,'" + TB013 + "','" + TC007 + "','',0,'N','N','" + TC033 + "','" + TC034 + "','N'," + TC036 + ",0,'" + transdate + "','0','',"); // chinh sua TC033 + TC034 25/11
                                sqlInsertSFCTC.Append("'" + TA006 + "'," + KLTotal + "," + KLOK + ",0," + KLNG + ",0,'" + TC047 + "','" + ITEMNAME_TC048 + "','" + ITEMDESCRIPTION + "','KG','0','0','0','N'");
                                sqlInsertSFCTC.Append(")");
                                sqlInsert.sqlExecuteNonQuery(sqlInsertSFCTC.ToString(), false);

                                StringBuilder sqlUpdateSFCTB = new StringBuilder();
                                sqlUpdateSFCTB.Append("update SFCTB set TB200 = TB200 + " + TC036 + ", TB201 = TB201 + " + output + ", TB202 = TB202 + " + NG + " where TB001 = 'D201' and TB002 = '" + ticketCode + "'");
                                sqlInsert.sqlExecuteNonQuery(sqlUpdateSFCTB.ToString(), false);

                                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Generated Form :", "D201-" + TC002);
                                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Code :", MP + "-" + SP);
                                DataReport.addReport(DataReport.RP_TYPE.Success, "D201", ticketCode, MP + SP, MES_move_no, TB013, "Đã tạo và gộp phiếu chuyển thành công! Số thứ tự phiếu: " + ticketNumber);
                                isTicketCreated = true;
                            }
                            //kg dùng SFT nữa nên TB038 & TB039 để trống
                            else
                            {
                                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Không thể tạo phiếu do SFCTA036 > SFCTA010 - SFCTA011 - SFCTA012.", " (Code : " + MP + "-" + SP + ")");
                                DataReport.addReport(DataReport.RP_TYPE.Fail, "", "", MP + SP, MES_move_no, "", "Không thể tạo phiếu do SFCTA036 > SFCTA010 - SFCTA011 - SFCTA012.");
                            }
                        }
                        else if (TC009 == "")
                        {
                            SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Không thể tạo phiếu do thiếu dữ liệu mã quy trình 0020: ", MP + SP);
                            DataReport.addReport(DataReport.RP_TYPE.Fail, "", "", MP + SP, MES_move_no, "", "Không thể tạo phiếu do thiếu dữ liệu mã quy trình 0020: ");
                        }
                    }
                }
                else
                {
                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Không thể tạo phiếu D201 do thiếu dữ liệu ở bảng SFCTA hoặc MOCTA: ", MP + SP);
                    DataReport.addReport(DataReport.RP_TYPE.Fail, "", "", MP + SP, MES_move_no, "", "Không thể tạo phiếu D201 do thiếu dữ liệu ở bảng SFCTA hoặc MOCTA");
                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertdataToERP(string barcode, string output, string NG)", ex.Message);
                DataReport.addReport(DataReport.RP_TYPE.Fail, "", "", MP + SP, MES_move_no, "", "Không thể tạo phiếu! Lỗi không xác định! Xem file log để biết thêm chi tiết!");
            }
        }
        public string GetFirstD2Date(string MP, string SP)
        {
            DateTime date = DateTime.Now;
            DateTime nextMonth = date.AddMonths(1);
            string dateNMFormat = nextMonth.ToString("yyMM");
            sqlERPTest_TLVN2 con = new sqlERPTest_TLVN2();
            string transferCode = con.sqlExecuteScalarString("select min(TC002) from SFCTC where TC001 = 'D201' and TC002 < '" + dateNMFormat + "%' and TC004 = '" + MP + "' and TC005 = '" + SP + "'");
            string createDate = con.sqlExecuteScalarString("select distinct TB003 from SFCTB where TB001 ='D201' and TB002 = '" + transferCode + "'");
            return createDate;
        }
        public string CheckTA032_D201_0010(string MP, string SP)
        {
            sqlERPCon con = new sqlERPCon();

            double TA010 = double.Parse(con.sqlExecuteScalarString("select distinct TA010 from SFCTA where TA001 = '" + MP + "' and TA002 ='" + SP + "' and TA003 = '0010'"));
            double TA011 = double.Parse(con.sqlExecuteScalarString("select distinct TA011 from SFCTA where TA001 = '" + MP + "' and TA002 ='" + SP + "' and TA003 = '0010'"));
            double TA012 = double.Parse(con.sqlExecuteScalarString("select distinct TA012 from SFCTA where TA001 = '" + MP + "' and TA002 ='" + SP + "' and TA003 = '0010'"));
            double TA017 = double.Parse(con.sqlExecuteScalarString("select distinct TA017 from SFCTA where TA001 = '" + MP + "' and TA002 ='" + SP + "' and TA003 = '0010'"));
            double check = TA010 - TA011 - TA012 - TA017;
            if (check == 0)
            {
                return "Y";
            }
            else return "N";
        }
        public string CheckTA032_D201_0020(string MP, string SP)
        {
            sqlERPCon con = new sqlERPCon();

            double TA010 = double.Parse(con.sqlExecuteScalarString("select distinct TA010 from SFCTA where TA001 = '" + MP + "' and TA002 ='" + SP + "' and TA003 = '0020'"));
            double TA011 = double.Parse(con.sqlExecuteScalarString("select distinct TA011 from SFCTA where TA001 = '" + MP + "' and TA002 ='" + SP + "' and TA003 = '0020'"));
            double TA012 = double.Parse(con.sqlExecuteScalarString("select distinct TA012 from SFCTA where TA001 = '" + MP + "' and TA002 ='" + SP + "' and TA003 = '0020'"));
            double TA017 = double.Parse(con.sqlExecuteScalarString("select distinct TA017 from SFCTA where TA001 = '" + MP + "' and TA002 ='" + SP + "' and TA003 = '0020'"));
            double check = TA010 - TA011 - TA012 - TA017;
            if (check == 0)
            {
                return "Y";
            }
            else return "N";
        }
        public void updateERPD201(string MP, string SP, double output, double NG, double RW,  string date, string time)
        {
            try
            {
                if (isTicketCreated ==true)
                {
                    string firstD2Date = GetFirstD2Date(MP, SP);
                    sqlERPCon data = new sqlERPCon();
                    string TC047 = data.sqlExecuteScalarString("select distinct TA006 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");

                    double Total = (output + NG) - RW;
                    double DLDonvi = GetDonVi(TC047);
                    double KLOK = DLDonvi * output;
                    double KLNG = DLDonvi * NG;
                    double KLTotal = Total * DLDonvi;

                    string dateTm = Convert.ToDateTime(date).ToString("yyyyMMdd");

                    sqlERPTest_TLVN2 con = new sqlERPTest_TLVN2();
                    double SFCTA010 = double.Parse(con.sqlExecuteScalarString("select distinct TA010 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010'"));
                    double SFCTA011 = double.Parse(con.sqlExecuteScalarString("select distinct TA011 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010'"));
                    double SFCTA012 = double.Parse(con.sqlExecuteScalarString("select distinct TA012 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010'"));
                    double totalTA101112 = SFCTA010 - SFCTA011 - SFCTA012;

                    double SFCTA038 = double.Parse(con.sqlExecuteScalarString("select distinct TA038 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010'"));
                    double SFCTA039 = double.Parse(con.sqlExecuteScalarString("select distinct TA039 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010'"));
                    double SFCTA040 = double.Parse(con.sqlExecuteScalarString("select distinct TA040 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010'"));
                    double totalTA383940 = SFCTA038 - SFCTA039 - SFCTA040;

                    if (KLTotal > totalTA383940)
                    {
                        TB013 = "N";
                    }
                    bool checkQty = false;
                    if (Total > totalTA101112)
                    {
                        checkQty = true;
                    }

                    if (TC009 != "")
                    {
                        if (!checkQty)
                        {
                            sqlERPTest_TLVN2 sqlUpdate = new sqlERPTest_TLVN2();

                            StringBuilder updateSFCTA = new StringBuilder();
                            //update SFCTA 0010
                            if (TB013 == "Y")
                            {
                                updateSFCTA.Append("update SFCTA set TA011 = TA011 + " + output + " , TA012 = TA012 + " + NG + " , TA032 = '" + CheckTA032_D201_0010(MP, SP) + "', TA039 = TA039 + " + KLOK + " , TA040 = TA040 + " + KLNG + " where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010' and TA004 = '" + TC007 + "'");
                                sqlUpdate.sqlExecuteNonQuery(updateSFCTA.ToString(), false);
                            }
                            else
                            {
                                updateSFCTA.Append("update SFCTA set TA017 = TA017 + " + Total + ", TA032 = '" + CheckTA032_D201_0010(MP, SP) + "', TA045 = TA045 + " + KLTotal + " where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010' and TA004 = '" + TC007 + "'");
                                sqlUpdate.sqlExecuteNonQuery(updateSFCTA.ToString(), false);
                            }

                            double SFCTA011Updated = double.Parse(con.sqlExecuteScalarString("select distinct TA011 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010'"));
                            double SFCTA039Updated = double.Parse(con.sqlExecuteScalarString("select distinct TA039 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010'"));
                            //update SFCTA 0020
                            StringBuilder updateSFCTA02 = new StringBuilder();
                            updateSFCTA02.Append("update SFCTA set TA010 = " + SFCTA011Updated + ", TA030= '" + firstD2Date + "', TA032 = '" + CheckTA032_D201_0020(MP, SP) + "', TA038 = " + SFCTA039Updated + " , MODIFIER ='MES', MODI_DATE ='" + dateTm + "',MODI_TIME ='" + time + "', MODI_AP ='SFT', MODI_PRID ='SFCMI05' where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 ='0020' and TA004 = '" + TC009 + "' ");
                            sqlUpdate.sqlExecuteNonQuery(updateSFCTA02.ToString(), false);

                            //update MOCTA
                            StringBuilder UpdateMOCTA = new StringBuilder();
                            UpdateMOCTA.Append(" update MOCTA set TA018 = TA018 + " + NG + ", TA047 = TA047 + " + KLNG + " , MODIFIER ='MES', MODI_DATE ='" + dateTm + "',MODI_TIME ='" + time + "', MODI_AP ='SFT', MODI_PRID ='SFCMI05'  where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                            sqlUpdate.sqlExecuteNonQuery(UpdateMOCTA.ToString(), false);
                            SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Updated code: ", MP + SP);
                        }
                        else
                        {
                            SystemLog.Output(SystemLog.MSG_TYPE.Err, "Không thể cập nhật do SFCTA036 > SFCTA010 - SFCTA011 - SFCTA012.", " (Code : " + MP + "-" + SP + ")");
                        }
                    }
                }
                else
                {
                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "Không cập nhật phiếu do phiếu không được tạo!", "");
                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "updateERPD201(string " + MP + "-" + SP + ")", ex.Message);
            }
        }
    }
}
