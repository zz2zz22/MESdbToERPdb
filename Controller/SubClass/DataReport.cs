using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows;
using ClosedXML.Excel;
using System.IO;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace MESdbToERPdb
{
    public class DataReport
    {
        static DataReport s_drInstance = null;

        
        DataTable successReportTB = null;
        DataTable failReportTB = null;
        DataTable errorReportTB = null;
        

        #region CreateDatatable
        private DataReport()
        {
            successReportTB = new DataTable();

            DataColumn cl1 = new DataColumn();
            cl1.ColumnName = "Thời gian chuyển"; //DateTime.Now
            cl1.DataType = typeof(string);

            DataColumn cl2 = new DataColumn();
            cl2.ColumnName = "Loại phiếu chuyển"; // Loại phiếu
            cl2.DataType = typeof(string);

            DataColumn cl3 = new DataColumn();
            cl3.ColumnName = "Mã phiếu chuyển"; // Mã phiếu
            cl3.DataType = typeof(string);

            DataColumn cl4 = new DataColumn();
            cl4.ColumnName = "Thứ tự phiếu";
            cl4.DataType = typeof(string);

            DataColumn cl5 = new DataColumn();
            cl5.ColumnName = "Số đơn đặt"; // Mã ERP
            cl5.DataType = typeof(string);

            DataColumn cl6 = new DataColumn();
            cl6.ColumnName = "Chuyển số đơn đặt hàng"; // Mã số đơn chuyển trên MES   订单创建状态  Trạng thái xác nhận  Trạng thái chuyển đổi
            cl6.DataType = typeof(string);

            DataColumn cl7 = new DataColumn();
            cl7.ColumnName = "Số hiệu sản phẩm";
            cl7.DataType = typeof(string);

            DataColumn cl8 = new DataColumn();
            cl8.ColumnName = "Số hiệu công đoạn sản xuất";
            cl8.DataType = typeof(string);

            DataColumn cl9 = new DataColumn();
            cl9.ColumnName = "Tên gọi công đoạn sản xuất";
            cl9.DataType = typeof(string);

            DataColumn cl10 = new DataColumn();
            cl10.ColumnName = "Số lượng đạt yêu cầu";
            cl10.DataType = typeof(string);

            DataColumn cl11 = new DataColumn();
            cl11.ColumnName = "Số lượng không đạt";
            cl11.DataType = typeof(string);

            DataColumn cl12 = new DataColumn();
            cl12.ColumnName = "Trả lại số lượng Xiuli";
            cl12.DataType = typeof(string);

            DataColumn cl13 = new DataColumn();
            cl13.ColumnName = "Trạng thái xác nhận";
            cl13.DataType = typeof(string);

            DataColumn cl14 = new DataColumn();
            cl14.ColumnName = "Trạng thái chuyển đổi";
            cl14.DataType = typeof(string);

            successReportTB.Columns.AddRange(new DataColumn[] { cl1, cl2, cl3, cl4, cl5, cl6, cl7, cl8, cl9, cl10, cl11, cl12, cl13, cl14 });
            


            failReportTB = new DataTable();

            DataColumn clf1 = new DataColumn();
            clf1.ColumnName = "Thời gian chuyển"; 
            clf1.DataType = typeof(string);

            DataColumn clf2 = new DataColumn();
            clf2.ColumnName = "Số đơn đặt"; // Mã ERP
            clf2.DataType = typeof(string);

            DataColumn clf3 = new DataColumn();
            clf3.ColumnName = "Chuyển số đơn đặt hàng"; // Mã số đơn chuyển trên MES   订单创建状态
            clf3.DataType = typeof(string);

            DataColumn clf4 = new DataColumn();
            clf4.ColumnName = "Số hiệu sản phẩm";
            clf4.DataType = typeof(string);

            DataColumn clf5 = new DataColumn();
            clf5.ColumnName = "Số hiệu công đoạn sản xuất";
            clf5.DataType = typeof(string);

            DataColumn clf6 = new DataColumn();
            clf6.ColumnName = "Tên gọi công đoạn sản xuất";
            clf6.DataType = typeof(string);

            DataColumn clf7 = new DataColumn();
            clf7.ColumnName = "Số lượng đạt yêu cầu";
            clf7.DataType = typeof(string);

            DataColumn clf8 = new DataColumn();
            clf8.ColumnName = "Số lượng không đạt";
            clf8.DataType = typeof(string);

            DataColumn clf9 = new DataColumn();
            clf9.ColumnName = "Trả lại số lượng Xiuli";
            clf9.DataType = typeof(string);

            DataColumn clf10 = new DataColumn();
            clf10.ColumnName = "Trạng thái xác nhận";
            clf10.DataType = typeof(string);

            DataColumn clf11 = new DataColumn();
            clf11.ColumnName = "Trạng thái chuyển đổi";
            clf11.DataType = typeof(string);

            failReportTB.Columns.AddRange(new DataColumn[] { clf1, clf2, clf3, clf4, clf5, clf6, clf7, clf8, clf9, clf10, clf11 });



            errorReportTB = new DataTable();

            DataColumn cle1 = new DataColumn();
            cle1.ColumnName = "Thời gian chuyển"; // Mã ERP
            cle1.DataType = typeof(string);

            DataColumn cle2 = new DataColumn();
            cle2.ColumnName = "Số đơn đặt"; // Mã ERP
            cle2.DataType = typeof(string);

            DataColumn cle3 = new DataColumn();
            cle3.ColumnName = "Chuyển số đơn đặt hàng"; // Mã số đơn chuyển trên MES   订单创建状态
            cle3.DataType = typeof(string);

            DataColumn cle4 = new DataColumn();
            cle4.ColumnName = "Số hiệu sản phẩm";
            cle4.DataType = typeof(string);

            DataColumn cle5 = new DataColumn();
            cle5.ColumnName = "Số hiệu công đoạn sản xuất";
            cle5.DataType = typeof(string);

            DataColumn cle6 = new DataColumn();
            cle6.ColumnName = "Tên gọi công đoạn sản xuất";
            cle6.DataType = typeof(string);

            DataColumn cle7 = new DataColumn();
            cle7.ColumnName = "Số lượng đạt yêu cầu";
            cle7.DataType = typeof(string);

            DataColumn cle8 = new DataColumn();
            cle8.ColumnName = "Số lượng không đạt";
            cle8.DataType = typeof(string);

            DataColumn cle9 = new DataColumn();
            cle9.ColumnName = "Trả lại số lượng Xiuli";
            cle9.DataType = typeof(string);

            DataColumn cle10 = new DataColumn();
            cle10.ColumnName = "Trạng thái xác nhận";
            cle10.DataType = typeof(string);

            DataColumn cle11 = new DataColumn();
            cle11.ColumnName = "Trạng thái chuyển đổi";
            cle11.DataType = typeof(string);

            errorReportTB.Columns.AddRange(new DataColumn[] { cle1, cle2, cle3, cle4, cle5, cle6, cle7, cle8, cle9, cle10, cle11 });        
        }

        public static void addReport(RP_TYPE rpType, string transDate, string LP, string MP, string ticketNo, string erpCode, string moveNo, string productCode, string operationNo, string operationName, string OK, string NG, string RW, string confirmStatus, string status)
        {
            if ( s_drInstance == null)
            {
                s_drInstance = new DataReport();
            }
            s_drInstance.writeReport(rpType, transDate, LP, MP, ticketNo, erpCode, moveNo, productCode, operationNo, operationName, OK, NG, RW, confirmStatus, status);
        }

        private void writeReport(RP_TYPE rpType,string transDate, string LP, string MP, string ticketNo, string erpCode, string moveNo, string productCode, string operationNo, string operationName, string OK, string NG, string RW, string confirmStatus, string status)
        {
            if ( rpType == RP_TYPE.Fail)
            {
                failReportTB.Rows.Add(new object[] { transDate, erpCode, moveNo, productCode, operationNo, operationName, OK, NG, RW, confirmStatus, status });
            }
            else
            {
                if (rpType == RP_TYPE.Success)
                {
                    successReportTB.Rows.Add(new object[] { transDate, LP, MP, ticketNo, erpCode, moveNo, productCode, operationNo, operationName, OK, NG, RW, confirmStatus, status });
                }
                else
                {
                    errorReportTB.Rows.Add(new object[] { transDate, erpCode, moveNo, productCode, operationNo, operationName, OK, NG, RW, confirmStatus, status });
                }
            }
        }
        public enum RP_TYPE
        {
            Fail,
            Success,
            Error
        };
        #endregion
        public static void SaveExcel(string excelFilePath, string fileName, string sender, string sender_pw)
        {
            if (s_drInstance ==null)
            {
                s_drInstance = new DataReport();
            }
            s_drInstance.ExportToExcel(excelFilePath, fileName);
            s_drInstance.SendReport(sender, sender_pw);
            s_drInstance = null;
        }

        public void ExportToExcel(string excelFilePath, string fileName)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\MES2ERP_Reports";
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);
            if (dir.Exists == false)
                dir.Create();
            

            XLWorkbook wb = new XLWorkbook();
            var ws1 = wb.Worksheets.Add(successReportTB, "Success MO");
            var ws2 = wb.Worksheets.Add(failReportTB, "Failed MO");
            var ws3 = wb.Worksheets.Add(errorReportTB, "Error MO");
            wb.Style.Fill.BackgroundColor = XLColor.NoColor;
            ws1.Column("A").Width = 19;
            ws1.Column("B").Width = 11;
            ws1.Column("C").Width = 14;
            ws1.Column("D").Width = 14;
            ws1.Column("E").Width = 15;
            ws1.Column("F").Width = 22;
            ws1.Column("G").Width = 25;
            ws1.Column("H").Width = 13;
            ws1.Column("I").Width = 34;
            ws1.Column("J").Width = 9;
            ws1.Column("K").Width = 9;
            ws1.Column("L").Width = 9;
            ws1.Column("M").Width = 9;
            ws1.Column("N").Width = 34;

            ws2.Column("A").Width = 19;
            ws2.Column("B").Width = 15;
            ws2.Column("C").Width = 22;
            ws2.Column("D").Width = 25;
            ws2.Column("E").Width = 13;
            ws2.Column("F").Width = 34;
            ws2.Column("G").Width = 9;
            ws2.Column("H").Width = 9;
            ws2.Column("I").Width = 9;
            ws2.Column("J").Width = 9;
            ws2.Column("K").Width = 58;

            ws3.Column("A").Width = 19;
            ws3.Column("B").Width = 15;
            ws3.Column("C").Width = 22;
            ws3.Column("D").Width = 25;
            ws3.Column("E").Width = 13;
            ws3.Column("F").Width = 34;
            ws3.Column("G").Width = 9;
            ws3.Column("H").Width = 9;
            ws3.Column("I").Width = 9;
            ws3.Column("J").Width = 9;
            ws3.Column("K").Width = 58;


            // check file path
            if (!string.IsNullOrEmpty(excelFilePath))
            {
                try
                {
                    wb.SaveAs(Path.Combine(excelFilePath, fileName));
                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Report is exported and save at ", Path.Combine(excelFilePath, fileName));
                    Properties.Settings.Default.excelFilePath = Path.Combine(excelFilePath, fileName);
                    Properties.Settings.Default.Save();
                }
                catch (Exception ex)
                {
                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "ExportToExcel: Không thể lưu file excel! Xin kiểm tra lại đường dẫn.\n" , ex.Message);
                }
            }
            else { // no file path is given
                wb.SaveAs(Path.Combine(path, fileName));
                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Đã xuất file excel và lưu tại ", Path.Combine(path, fileName));
                Properties.Settings.Default.excelFilePath = Path.Combine(path, fileName);
                Properties.Settings.Default.Save();
            }
            wb.Dispose();
        }

        public void SendReport(string sender, string sender_pw)
        {
            
            string smtp = sender.Substring(sender.IndexOf('@'));
            if (smtp == "@gmail.com")
            {
                Properties.Settings.Default.smtp_server = "smtp.gmail.com";
                Properties.Settings.Default.smtp_port = "587";
            }else if (smtp == "@techlink.vn")
            {
                Properties.Settings.Default.smtp_server = "pro56.emailserver.vn";
                Properties.Settings.Default.smtp_port = "587";
            }

            Properties.Settings.Default.Save();
            string[] receivers = Properties.Settings.Default.cfg_receivers.Split('-');
            for (int i = 0; i < receivers.Length; i ++)
            {
                MailMessage mail = new MailMessage();
                //SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Send mail to", receivers[i]);
                SmtpClient SmtpServer = new SmtpClient(Properties.Settings.Default.smtp_server);
                mail.From = new MailAddress(sender);
                mail.To.Add(receivers[i]);
                mail.Subject = "MES to ERP transfer report : " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                mail.Body = "This is an auto generated report! Please don't reply!";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(Properties.Settings.Default.excelFilePath);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = int.Parse(Properties.Settings.Default.smtp_port);
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(sender, sender_pw);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                mail.Dispose();
            }
            SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Report sent successfully", "");
            
            System.Threading.Thread.Sleep(1000);
        }
    }
}
