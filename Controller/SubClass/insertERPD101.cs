using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESdbToERPdb
{
    public class insertERP_D101 //Hàm xử lý tạo phiếu D101
    {
        
        string ITEMID_TC047 = "";
        string ITEMNAME_TC048 = "";
        string ITEMDESCRIPTION = "";
        string TC009 = "";
        bool isTicketCreated = false; // Xét xem phiếu có được tạo hay không nếu kg tạo thì kg cập nhật báo trong UpdateLogic


        #region SubLogic
        public string CheckTransDate(DateTime date) // Check nếu qua ngày mới nhưng nằm trong khoảng 0h đến 8h thì vẫn lấy ngày cũ
        {
            string transDate = date.ToString("yyyy-MM-dd");
            DateTime dateCheckMax = Convert.ToDateTime(transDate + " 08:00:00");
            DateTime dateCheckMin = Convert.ToDateTime(transDate + " 00:00:00");
            TimeSpan ts = new TimeSpan(1, 0, 0, 0);
            if ((date < dateCheckMax || date == dateCheckMax) && (date > dateCheckMin || date == dateCheckMin))
            {
                date = date.Subtract(ts);
            }
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public string GetTC002() // Số mã phiếu tăng tự động
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

        public static double GetDonVi(string itemNo) // Lấy tỉ lệ khối lượng của mã sản phẩm để nhân với số lượng lấy khối lượng tổng
        {
            sqlERPCon sqlERPCON = new sqlERPCon();
            double DonVi = 0;
            string MD003 = sqlERPCON.sqlExecuteScalarString("select distinct MD003 from INVMD where MD001 = '" + itemNo + "' and UPPER(MD002) = 'KG'");
            string MD004 = sqlERPCON.sqlExecuteScalarString("select distinct MD004 from INVMD where MD001 = '" + itemNo + "' and UPPER(MD002) = 'KG'");
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
            if (orgCode.Contains("A01"))
                warehouse = "A07";

            if (orgCode.Contains("A02"))
                warehouse = "A09";

            if (orgCode.Contains("A03"))
                warehouse = "A11";

            if (orgCode.Contains("B01"))
                warehouse = "B09";

            if (orgCode.Contains("B02"))
                warehouse = "B06";
            
            if (orgCode.Contains("B04"))
                warehouse = "B06";

            if (orgCode.Contains("C01"))
                warehouse = "C01";

            if (orgCode.Contains("C02"))
                warehouse = "C01";

            if (orgCode.Contains("D01"))
                warehouse = "D02";

            if (orgCode.Contains("D02"))
                warehouse = "D02";

            if (orgCode.Contains("J01"))
                warehouse = "J01";

            if (orgCode.Contains("P01"))
                warehouse = "P07";

            if (orgCode.Contains("P02"))
                warehouse = "P06";

            if (orgCode.Contains("P03"))
                warehouse = "P06";

            if (orgCode.Contains("W01"))
                warehouse = "W01";

            if (orgCode.Contains("Y01"))
                warehouse = "Y06";

            if (orgCode.Contains("Y02"))
                warehouse = "Y07";

            if (orgCode.Contains("Y03"))
                warehouse = "Y08";

            if (orgCode.Contains("Y04"))
                warehouse = "Y08";

            if (orgCode.Contains("Y05"))
                warehouse = "Y09";

            if (orgCode.Contains("Y06"))
                warehouse = "Y10";

            if (orgCode.Contains("Y07"))
                warehouse = "Y24";

            return warehouse;
        } // Lấy mã kho theo mã bộ phận set sẵn theo file Excel chị Diệu gửi (chỉ phiếu D1)

        public string getFirstD101ofOrganization(string orgCode, string autoStart, string autoEnd, string MP, string SP) //Hàm lấy số phiếu để gộp phiếu nếu là bộ phận ống B01 thì không gộp
        {
            sqlERPTest_TLVN2 con = new sqlERPTest_TLVN2();
            DateTime date = DateTime.Now;
            string dateFormat = date.ToString("yyyyMMdd");
            string strData = "";
            if (autoEnd != "" && autoStart !="")
            {
                if (orgCode != "B01")
                {
                    strData = con.sqlExecuteScalarString("select max(TC002) from SFCTC where TC001 = 'D101' and TC004 = '" + MP + "' and TC005 = '" + SP + "' and CREATE_DATE = '" + dateFormat + "' and CREATE_TIME between '" + autoStart + "' and '" + autoEnd + "'");
                }
                else
                {
                    strData = "";
                }
            }
            else
            {
                strData = "";
            }

            return strData;
        }
        
        public string getTicketNumber(string ticketCode) //Lấy số thứ tự phiếu để gộp phiếu chỉ gộp SFCTC kg gộp trong SFCTB
        {
            sqlERPTest_TLVN2 con = new sqlERPTest_TLVN2();
            string nextTC003 = con.sqlExecuteScalarString("select max(TC003) from SFCTC where TC001 = 'D101' and TC002 = '" + ticketCode + "'");
            int countUp = 0;
            countUp = int.Parse(nextTC003) + 1;
            string countFormatup = countUp.ToString("0000");
            return countFormatup;
        }

        public string CheckTA032(string MP, string SP) //Kiểm tra điều kiện theo như file excel chị Diệu gửi
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

        public string GetFirstD1Date(string MP, string SP) // Lấy số ngày hiện tại trong SFCTA xét cập nhật
        {
            sqlERPTest_TLVN2 con = new sqlERPTest_TLVN2();
            string Date = "";
            string createDate = con.sqlExecuteScalarString("select distinct TA030 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010'");
            if (createDate != "")
            {
                string year = createDate.Substring(0, 4);
                string month = createDate.Substring(4, 2);
                string day = createDate.Substring(6, 2);
                Date = month + "/" + day + "/" + year + " 00:00:00 AM";
            }
            return Date;
        }
        #endregion


        #region MainLogic

            #region InsertLogic
        public void InsertdataToERP_D101(string MP, string SP, string orgCode, double output, DateTime tdate, string date, string time, string timeIn, string timeOut, string MES_move_no, string productCode, string operationNo, string operationName)
        {
            try
            {
                bool isDataMissing = false;
                bool isHaveWeight = true;
                string dateTm = Convert.ToDateTime(date).ToString("yyyyMMdd");
                string month = dateTm.Substring(0, 6);

                string mesTransDate = CheckTransDate(tdate);

                sqlERPCon sqlERPCon = new sqlERPCon();

                string TC002 = GetTC002();

                double NG = 0;

                string TA006 = sqlERPCon.sqlExecuteScalarString("select distinct TA006 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                if (TA006 == String.Empty)
                    isDataMissing = true;
                string TA007 = sqlERPCon.sqlExecuteScalarString("select distinct TA007 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                if (TA007 == String.Empty)
                    isDataMissing = true;

                string TC047 = sqlERPCon.sqlExecuteScalarString("select distinct TA006 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                ITEMID_TC047 = TC047;
                if (TC047 == String.Empty)
                    isDataMissing = true;
                string TC048 = sqlERPCon.sqlExecuteScalarString("select distinct TA034 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                ITEMNAME_TC048 = TC048.Replace("'","''");
                if (TC048 == String.Empty)
                    isDataMissing = true;
                ITEMDESCRIPTION = sqlERPCon.sqlExecuteScalarString("select distinct TA035 from MOCTA where TA006 = '" + TC047 + "'");

                TC009 = sqlERPCon.sqlExecuteScalarString("select distinct TA004 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010'");
                if (TC009 == String.Empty)
                    isDataMissing = true;

                double TC036 = output + NG;
                string MOCTA56 = sqlERPCon.sqlExecuteScalarString("select distinct TA056 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                if (MOCTA56 == String.Empty)
                    isDataMissing = true;
                string getMOCTA57 = sqlERPCon.sqlExecuteScalarString("select distinct TA057 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                double MOCTA57 = 0;
                if (getMOCTA57 != String.Empty)
                    MOCTA57 = double.Parse(getMOCTA57);
                else
                    isDataMissing = true;
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
                sqlERPTest_TLVN2 data = new sqlERPTest_TLVN2();
                string getSFCTA010 = data.sqlExecuteScalarString("select distinct TA010 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010'");
                double SFCTA010 = 0;
                if (getSFCTA010 != String.Empty)
                    SFCTA010 = double.Parse(getSFCTA010);
                else
                    isDataMissing = true;

                string getMOCTA015 = data.sqlExecuteScalarString("select distinct TA015 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                double MOCTA015 = 0;
                if (getMOCTA015 != String.Empty)
                    MOCTA015 = double.Parse(getMOCTA015);
                else
                    isDataMissing = true;
                
                bool checkQty = false;
                if (SFCTA010 > MOCTA015 || SFCTA010 == MOCTA015)
                {
                    checkQty = true;
                }

                
                string TB005 = GetWarehouse(TA006);
                string TB006 = sqlERPCon.sqlExecuteScalarString("select distinct MC002 from CMSMC where MC001 = '" + TB005 + "'");
                string transdate = (Convert.ToDateTime(mesTransDate)).ToString("yyyyMMdd");

                string ticketCode = "";
                if (Properties.Settings.Default.d1Status == "Y")
                {
                    ticketCode = getFirstD101ofOrganization(orgCode, timeIn, timeOut, MP, SP);
                }
                //getFirstD101ofOrganization(orgCode, timeIn, timeOut, MP, SP);
                string ticketNumber = "";
                if (ticketCode != "")
                {
                    ticketNumber = getTicketNumber(ticketCode);
                }
                double Total = output + NG;
                double DLDonvi, KLOK, KLNG, KLTotal;
                string getMB091 = sqlERPCon.sqlExecuteScalarString("select distinct MB091 from INVMB where MB001 = '" + TC047 + "'");
                if (getMB091.ToUpper() == "Y")
                {
                    DLDonvi = GetDonVi(TC047);
                }
                else
                {
                    DLDonvi = 0;
                    isHaveWeight = false;
                }
                KLOK = DLDonvi * output;
                KLNG = DLDonvi * NG;
                KLTotal = Total * DLDonvi;
                if (isDataMissing == false)
                {
                    if (ticketCode == "")
                    {
                        if (!checkQty)
                        {
                            sqlERPTest_TLVN2 sqlInsert = new sqlERPTest_TLVN2();
                            if (Properties.Settings.Default.d1Status == "Y")
                            {
                                StringBuilder sqlInsertSFCTC = new StringBuilder();
                                sqlInsertSFCTC.Append("insert into SFCTC ");
                                sqlInsertSFCTC.Append(@"(COMPANY,CREATOR,USR_GROUP,CREATE_DATE,MODIFIER,MODI_DATE,FLAG,CREATE_TIME,CREATE_AP,CREATE_PRID,MODI_TIME,MODI_AP,MODI_PRID,");
                                sqlInsertSFCTC.Append(@"TC001,TC002,TC003,TC004,TC005,TC006,TC007,TC008,TC009,TC010,TC011,TC012,TC013,TC014,TC015,TC016,TC017,TC018,TC019,TC020,");
                                sqlInsertSFCTC.Append(@"TC021,TC022,TC023,TC024,TC025,TC026,TC027,TC033,TC034,TC035,TC036,TC037,TC038,TC039,TC040,");
                                sqlInsertSFCTC.Append(@"TC041,TC042,TC043,TC044,TC045,TC046,TC047,TC048,TC049,TC050,TC051,TC052,TC053,TC054,TC055,TC059,TC060)");
                                sqlInsertSFCTC.Append(" values ( ");
                                sqlInsertSFCTC.Append("'TLVN','MES','GS','" + dateTm + "','MES','" + dateTm + "',2,'" + time + "','SFT','SFCMI05','" + time + "','SFT','SFCMI05',");
                                sqlInsertSFCTC.Append("'D101','" + TC002 + "','0001','" + MP + "','" + SP + "','','','0010','" + TC009 + "','PCS','','','6'," + output + ",0," + NG + ",0,0,0,0,");
                                sqlInsertSFCTC.Append("0,'" + Properties.Settings.Default.d1Status + "','" + TB005 + "','',0,'N','N','" + TC033 + "','" + TC034 + "','N'," + output + ",0,'" + transdate + "','0','',"); // chinh sua TC033 + TC034
                                sqlInsertSFCTC.Append("'" + TA006 + "'," + KLTotal + "," + KLOK + ",0," + KLNG + ",0,'" + TC047 + "','" + ITEMNAME_TC048 + "','" + ITEMDESCRIPTION + "','KG','0','','0','0','N','N','0'");  //check lai TC050
                                sqlInsertSFCTC.Append(")");
                                sqlInsert.sqlExecuteNonQuery(sqlInsertSFCTC.ToString(), false);

                                StringBuilder sqlInsertSFCTB = new StringBuilder();
                                sqlInsertSFCTB.Append("insert into SFCTB ");
                                sqlInsertSFCTB.Append("(COMPANY,CREATOR,USR_GROUP,CREATE_DATE,MODIFIER,MODI_DATE,FLAG,CREATE_TIME,CREATE_AP,CREATE_PRID,MODI_TIME,MODI_AP,MODI_PRID,");
                                sqlInsertSFCTB.Append("TB001,TB002,TB003,TB004,TB005,TB006,TB007,TB008,TB009,TB010,TB011,TB012,TB013,TB014,TB015,TB016,TB017,TB018,TB019,TB020,");
                                sqlInsertSFCTB.Append(" TB021,TB022,TB023,TB024,TB025,TB026,TB027,TB028,TB029,TB030,TB031,TB034,TB036,TB037,TB038,TB039,");
                                sqlInsertSFCTB.Append("TB200,TB201,TB202)");
                                sqlInsertSFCTB.Append(" values ( ");
                                sqlInsertSFCTB.Append("'TLVN','MES','GS','" + dateTm + "','MES','" + dateTm + "',2,'" + time + "','SFT','SFCMI05','" + time + "','SFT','SFCMI05',");
                                sqlInsertSFCTB.Append("'D101','" + TC002 + "','" + transdate + "','3','" + TB005 + "','" + TB006 + "','1','" + TA006 + "','" + TA007 + "','TL','0','N','" + Properties.Settings.Default.d1Status + "','','" + transdate + "','MES','N','','','',"); //check va lay data TB005 + 6
                                sqlInsertSFCTB.Append("'','','1','N','" + month + "'," + MOCTA57 + ",'0','','0','0','0','" + MOCTA70 + "','VND',1,'','',");
                                sqlInsertSFCTB.Append(TC036 + "," + output + "," + NG + ")");
                                sqlInsert.sqlExecuteNonQuery(sqlInsertSFCTB.ToString(), false);
                                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Generated Form :", "D101-" + TC002 + ", " + Properties.Settings.Default.d1Status);
                                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Code :", MP + "-" + SP);
                                DataReport.addReport(DataReport.RP_TYPE.Success, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), tdate.ToString("dd/MM/yyyy HH:mm:ss"), "D101", TC002, "0001", MP + SP, MES_move_no, productCode, operationNo, operationName, output.ToString(), "", "", Properties.Settings.Default.d1Status, "Đã tạo phiếu chuyển thành công");
                            }
                            else
                            {
                                StringBuilder sqlInsertSFCTC = new StringBuilder();
                                sqlInsertSFCTC.Append("insert into SFCTC ");
                                sqlInsertSFCTC.Append(@"(COMPANY,CREATOR,USR_GROUP,CREATE_DATE,MODIFIER,MODI_DATE,FLAG,CREATE_TIME,CREATE_AP,CREATE_PRID,MODI_TIME,MODI_AP,MODI_PRID,");
                                sqlInsertSFCTC.Append(@"TC001,TC002,TC003,TC004,TC005,TC006,TC007,TC008,TC009,TC010,TC011,TC012,TC013,TC014,TC015,TC016,TC017,TC018,TC019,TC020,");
                                sqlInsertSFCTC.Append(@"TC021,TC022,TC023,TC024,TC025,TC026,TC027,TC033,TC034,TC035,TC036,TC037,TC038,TC039,TC040,");
                                sqlInsertSFCTC.Append(@"TC041,TC042,TC043,TC044,TC045,TC046,TC047,TC048,TC049,TC050,TC051,TC052,TC053,TC054,TC055,TC059,TC060)");
                                sqlInsertSFCTC.Append(" values ( ");
                                sqlInsertSFCTC.Append("'TLVN','MES','GS','" + dateTm + "','','',2,'" + time + "','SFT','SFCMI05','','','',");
                                sqlInsertSFCTC.Append("'D101','" + TC002 + "','0001','" + MP + "','" + SP + "','','','0010','" + TC009 + "','PCS','','','6'," + output + ",0," + NG + ",0,0,0,0,");
                                sqlInsertSFCTC.Append("0,'" + Properties.Settings.Default.d1Status + "','" + TB005 + "','',0,'N','N','" + TC033 + "','" + TC034 + "','N'," + output + ",0,'" + transdate + "','0','',"); // chinh sua TC033 + TC034
                                sqlInsertSFCTC.Append("'" + TA006 + "'," + KLTotal + "," + KLOK + ",0," + KLNG + ",0,'" + TC047 + "','" + ITEMNAME_TC048 + "','" + ITEMDESCRIPTION + "','KG','0','','0','0','N','N','0'");  //check lai TC050
                                sqlInsertSFCTC.Append(")");
                                sqlInsert.sqlExecuteNonQuery(sqlInsertSFCTC.ToString(), false);

                                StringBuilder sqlInsertSFCTB = new StringBuilder();
                                sqlInsertSFCTB.Append("insert into SFCTB ");
                                sqlInsertSFCTB.Append("(COMPANY,CREATOR,USR_GROUP,CREATE_DATE,MODIFIER,MODI_DATE,FLAG,CREATE_TIME,CREATE_AP,CREATE_PRID,MODI_TIME,MODI_AP,MODI_PRID,");
                                sqlInsertSFCTB.Append("TB001,TB002,TB003,TB004,TB005,TB006,TB007,TB008,TB009,TB010,TB011,TB012,TB013,TB014,TB015,TB016,TB017,TB018,TB019,TB020,");
                                sqlInsertSFCTB.Append(" TB021,TB022,TB023,TB024,TB025,TB026,TB027,TB028,TB029,TB030,TB031,TB034,TB036,TB037,TB038,TB039,");
                                sqlInsertSFCTB.Append("TB200,TB201,TB202)");
                                sqlInsertSFCTB.Append(" values ( ");
                                sqlInsertSFCTB.Append("'TLVN','MES','GS','" + dateTm + "','','',2,'" + time + "','SFT','SFCMI05','','','',");
                                sqlInsertSFCTB.Append("'D101','" + TC002 + "','" + transdate + "','3','" + TB005 + "','" + TB006 + "','1','" + TA006 + "','" + TA007 + "','TL','0','N','" + Properties.Settings.Default.d1Status + "','','" + transdate + "','','N','','','',"); //check va lay data TB005 + 6
                                sqlInsertSFCTB.Append("'','','1','N','" + month + "'," + MOCTA57 + ",'0','','0','0','0','" + MOCTA70 + "','VND',1,'','',");
                                sqlInsertSFCTB.Append(TC036 + "," + output + "," + NG + ")");
                                sqlInsert.sqlExecuteNonQuery(sqlInsertSFCTB.ToString(), false);
                                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Generated Form :", "D101-" + TC002 + ", " + Properties.Settings.Default.d1Status);
                                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Code :", MP + "-" + SP);
                                DataReport.addReport(DataReport.RP_TYPE.Success, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),tdate.ToString("dd/MM/yyyy HH:mm:ss"), "D101", TC002, "0001", MP + SP, MES_move_no, productCode, operationNo, operationName, output.ToString(), "", "", Properties.Settings.Default.d1Status, "Đã tạo phiếu chuyển thành công");
                               
                            }
                            isTicketCreated = true;
                            if (isHaveWeight == false)
                            {
                                DataReport.addReport(DataReport.RP_TYPE.NoWeightPercent, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), tdate.ToString("dd/MM/yyyy HH:mm:ss"), "D101", TC002, "0001", MP + SP, MES_move_no, productCode, operationNo, operationName, output.ToString(), "", "", Properties.Settings.Default.d1Status, "");
                            }
                        }
                        else
                        {
                            SystemLog.Output(SystemLog.MSG_TYPE.Err, "Không thể tạo phiếu do SFCTA010 lớn hơn hoặc bằng MOCTA015.", SFCTA010 + " : " + MOCTA015 + " (Code : " + MP + "-" + SP + ")");
                            DataReport.addReport(DataReport.RP_TYPE.Fail, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), tdate.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, MES_move_no, productCode, operationNo, operationName, output.ToString(), "", "", "", "Không thể tạo phiếu do SFCTA010 lớn hơn hoặc bằng MOCTA015.");
                            FixData.addFixTB(DateTime.Now, MP + SP, MES_move_no, "Khong the tao phieu do SFCTA010 lon hon hoac bang MOCTA015.");
                        }
                    }
                    else
                    {
                        if (!checkQty)
                        {
                            sqlERPTest_TLVN2 sqlInsert = new sqlERPTest_TLVN2();

                            StringBuilder sqlInsertSFCTC = new StringBuilder();
                            sqlInsertSFCTC.Append("insert into SFCTC ");
                            sqlInsertSFCTC.Append(@"(COMPANY,CREATOR,USR_GROUP,CREATE_DATE,MODIFIER,MODI_DATE,FLAG,CREATE_TIME,CREATE_AP,CREATE_PRID,MODI_TIME,MODI_AP,MODI_PRID,");
                            sqlInsertSFCTC.Append(@"TC001,TC002,TC003,TC004,TC005,TC006,TC007,TC008,TC009,TC010,TC011,TC012,TC013,TC014,TC015,TC016,TC017,TC018,TC019,TC020,");
                            sqlInsertSFCTC.Append(@"TC021,TC022,TC023,TC024,TC025,TC026,TC027,TC033,TC034,TC035,TC036,TC037,TC038,TC039,TC040,");
                            sqlInsertSFCTC.Append(@"TC041,TC042,TC043,TC044,TC045,TC046,TC047,TC048,TC049,TC050,TC051,TC052,TC053,TC054,TC055,TC059,TC060)");
                            sqlInsertSFCTC.Append(" values ( ");
                            sqlInsertSFCTC.Append("'TLVN','MES','GS','" + dateTm + "','MES','" + dateTm + "',2,'" + time + "','SFT','SFCMI05','" + time + "','SFT','SFCMI05',");
                            sqlInsertSFCTC.Append("'D101','" + ticketCode + "','" + ticketNumber + "','" + MP + "','" + SP + "','','','0010','" + TC009 + "','PCS','','','6'," + output + ",0," + NG + ",0,0,0,0,");
                            sqlInsertSFCTC.Append("0,'"+ Properties.Settings.Default.d1Status + "','" + TB005 + "','',0,'N','N','" + TC033 + "','" + TC034 + "','N'," + output + ",0,'" + transdate + "','0','',"); // chinh sua TC033 + TC034
                            sqlInsertSFCTC.Append("'" + TA006 + "'," + KLTotal + "," + KLOK + ",0," + KLNG + ",0,'" + TC047 + "','" + ITEMNAME_TC048 + "','" + ITEMDESCRIPTION + "','KG','0','','0','0','N','N','0'");  //check lai TC050
                            sqlInsertSFCTC.Append(")");
                            sqlInsert.sqlExecuteNonQuery(sqlInsertSFCTC.ToString(), false);

                            StringBuilder sqlUpdateSFCTB = new StringBuilder();
                            sqlUpdateSFCTB.Append("update SFCTB set TB200 = TB200 + " + TC036 + ", TB201 = TB201 + " + output + ", TB202 = TB202 + " + NG + " where TB001 = 'D101' and TB002 = '" + ticketCode + "'");
                            sqlInsert.sqlExecuteNonQuery(sqlUpdateSFCTB.ToString(), false);
                            SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Generated Form :", "D101-" + ticketCode + ", " + Properties.Settings.Default.d1Status);
                            SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Code :", MP + "-" + SP);
                            DataReport.addReport(DataReport.RP_TYPE.Success, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), tdate.ToString("dd/MM/yyyy HH:mm:ss"), "D101", ticketCode, ticketNumber, MP + SP, MES_move_no, productCode, operationNo, operationName, output.ToString(), "", "", Properties.Settings.Default.d1Status, "Đã tạo và gộp phiếu chuyển thành công");
                            isTicketCreated = true;
                            if (isHaveWeight == false)
                            {
                                DataReport.addReport(DataReport.RP_TYPE.NoWeightPercent, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), tdate.ToString("dd/MM/yyyy HH:mm:ss"), "D101", TC002, ticketNumber, MP + SP, MES_move_no, productCode, operationNo, operationName, output.ToString(), "", "", Properties.Settings.Default.d1Status, "");
                            }
                        }
                        else
                        {
                            SystemLog.Output(SystemLog.MSG_TYPE.Err, "Không thể tạo phiếu do SFCTA010 > MOCTA015.", SFCTA010 + ">" + MOCTA015 + " (Code : " + MP + "-" + SP + ")");
                            DataReport.addReport(DataReport.RP_TYPE.Fail, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), tdate.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, MES_move_no, productCode, operationNo, operationName, output.ToString(), "", "", "", "Không thể tạo phiếu do SFCTA010 lớn hơn hoặc bằng MOCTA015.");
                            FixData.addFixTB(DateTime.Now, MP + SP, MES_move_no, "Khong the tao phieu do SFCTA010 lon hon MOCTA015.");
                        }
                    }
                }
                else
                {
                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "Không thể tạo phiếu D101 do thiếu dữ liệu ở bảng SFCTA hoặc MOCTA: ", MP + SP);
                    DataReport.addReport(DataReport.RP_TYPE.Fail, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), tdate.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, MES_move_no, productCode, operationNo, operationName, output.ToString(), "", "", "", "Không thể tạo phiếu D101 do thiếu dữ liệu ở bảng SFCTA hoặc MOCTA");
                    FixData.addFixTB(DateTime.Now, MP + SP, MES_move_no, "Khong the tao phieu D101 do thieu du lieu o bang SFCTA hoac MOCTA.");
                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertdataToERP(string barcode, string output, string NG)", ex.Message);
                DataReport.addReport(DataReport.RP_TYPE.Fail, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), tdate.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, MES_move_no, productCode, operationNo, operationName, output.ToString(), "", "", "", "Không thể tạo phiếu! Lỗi không xác định! Xem file log để biết thêm chi tiết!"); ;
                FixData.addFixTB(DateTime.Now, MP + SP, MES_move_no, "Khong the tao phieu! Loi khong xac dinh xem file log de biet chi tiet!");
            }
        }
        #endregion

            #region UpdateLogic
        public void updateERPD101(string MP, string SP, double output, string date, string time, DateTime tdate)
        {
            try
            {
                if (Properties.Settings.Default.d1Status == "Y")
                {
                    if (isTicketCreated == true)
                    {
                        string firstDate = GetFirstD1Date(MP, SP);
                        bool isUpdated = false;
                        if (firstDate != "")
                        {
                            DateTime convertedFDate = Convert.ToDateTime(firstDate);
                            if (tdate < convertedFDate)
                            {
                                isUpdated = true;
                            }
                        }
                        else
                        {
                            isUpdated = true;
                        }
                        sqlERPCon data = new sqlERPCon();
                        string TC047 = data.sqlExecuteScalarString("select distinct TA006 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");

                        double NGQty = 0;
                        double Total = output + NGQty;
                        double DLDonvi, KLOK, KLNG, KLTotal;
                        string getMB091 = data.sqlExecuteScalarString("select distinct MB091 from INVMB where MB001 = '" + TC047 + "'");
                        if (getMB091.ToUpper() == "Y")
                        {
                            DLDonvi = GetDonVi(TC047);
                        }
                        else
                        {
                            DLDonvi = 0;
                        }
                        KLOK = DLDonvi * output;
                        KLNG = DLDonvi * NGQty;
                        KLTotal = Total * DLDonvi;

                        sqlERPTest_TLVN2 con = new sqlERPTest_TLVN2();
                        double SFCTA010 = double.Parse(con.sqlExecuteScalarString("select distinct TA010 from SFCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010'"));
                        double MOCTA015 = double.Parse(con.sqlExecuteScalarString("select distinct TA015 from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'"));
                        bool checkQty = false;
                        if (SFCTA010 > MOCTA015 || SFCTA010 == MOCTA015)
                        {
                            checkQty = true;
                        }

                        string dateTm = Convert.ToDateTime(date).ToString("yyyyMMdd");

                        if (!checkQty)
                        {
                            sqlERPTest_TLVN2 sqlUpdate = new sqlERPTest_TLVN2();

                            StringBuilder updateSFCTA = new StringBuilder();
                            //update SFCTA 0010
                            if (isUpdated == true)
                            {
                                updateSFCTA.Append("update SFCTA set TA010 = TA010 + " + output + ", TA012 = 0, TA013 = 0, TA014 = 0, TA015 = 0, TA016 = 0, TA017 = 0,TA030 = '" + tdate.ToString("yyyyMMdd") + "',TA031 = '" + dateTm + "', TA032 = '" + CheckTA032(MP, SP) + "', TA038 = TA038 + " + KLTotal + "  where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010' and TA004 = '" + TC009 + "'");
                                sqlUpdate.sqlExecuteNonQuery(updateSFCTA.ToString(), false);
                            }
                            else
                            {
                                updateSFCTA.Append("update SFCTA set TA010 = TA010 + " + output + ", TA012 = 0, TA013 = 0, TA014 = 0, TA015 = 0, TA016 = 0, TA017 = 0,TA031 = '" + dateTm + "', TA032 = '" + CheckTA032(MP, SP) + "', TA038 = TA038 + " + KLTotal + "  where TA001 = '" + MP + "' and TA002 = '" + SP + "' and TA003 = '0010' and TA004 = '" + TC009 + "'");
                                sqlUpdate.sqlExecuteNonQuery(updateSFCTA.ToString(), false);
                            }


                            //phiếu D1 không có 0020

                            //update MOCTA
                            StringBuilder UpdateMOCTA = new StringBuilder();
                            UpdateMOCTA.Append(" update MOCTA set TA011 = '3', TA012 = '" + dateTm + "' , MODIFIER ='MES', MODI_DATE ='" + dateTm + "',MODI_TIME ='" + time + "', MODI_AP ='SFT', MODI_PRID ='SFCMI05'  where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                            sqlUpdate.sqlExecuteNonQuery(UpdateMOCTA.ToString(), false);
                            SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Updated code: ", MP + SP);
                        }
                        else
                        {
                            SystemLog.Output(SystemLog.MSG_TYPE.Err, "Không thể cập nhật do SFCTA010 lớn hơn hoặc bằng MOCTA015.", SFCTA010 + " : " + MOCTA015 + " (Code : " + MP + "-" + SP + ")");
                        }
                    }
                    else
                    {
                        SystemLog.Output(SystemLog.MSG_TYPE.Err, "Không cập nhật phiếu do phiếu không được tạo!", "");
                    }
                }
                else
                {
                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "Không cập nhật do phiếu không xác nhận!", "");
                }
                
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "updateERPD101(string " + MP + "-" + SP + ")", ex.Message);
            }
        }
        #endregion

        #endregion
    }
}
