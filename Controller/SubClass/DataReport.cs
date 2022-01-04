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
                cl1.ColumnName = "Loại phiếu"; // Loại phiếu
                cl1.DataType = typeof(string);

                DataColumn cl2 = new DataColumn();
                cl2.ColumnName = "Mã phiếu"; // Mã phiếu
                cl2.DataType = typeof(string);

                DataColumn cl3 = new DataColumn();
                cl3.ColumnName = "Mã SX"; // Mã ERP
                cl3.DataType = typeof(string);

                DataColumn cl4 = new DataColumn();
                cl4.ColumnName = "Mã đơn chuyển"; // Mã số đơn chuyển trên MES   订单创建状态
                cl4.DataType = typeof(string);

                DataColumn cl5 = new DataColumn();
                cl5.ColumnName = "Trạng thái xác nhận";
                cl5.DataType = typeof(string);

                DataColumn cl6 = new DataColumn();
                cl6.ColumnName = "Trạng thái chuyển đổi";
                cl6.DataType = typeof(string);

                successReportTB.Columns.AddRange(new DataColumn[] { cl1, cl2, cl3, cl4, cl5, cl6 });

                failReportTB = new DataTable();
                //DataColumn clf1 = new DataColumn();
                //clf1.ColumnName = "Loại phiếu"; // Loại phiếu
                //clf1.DataType = typeof(string);

                //DataColumn clf2 = new DataColumn();
                //clf2.ColumnName = "Mã phiếu"; // Mã phiếu
                //clf2.DataType = typeof(string);

                DataColumn clf3 = new DataColumn();
                clf3.ColumnName = "Mã SX"; // Mã ERP
                clf3.DataType = typeof(string);

                DataColumn clf4 = new DataColumn();
                clf4.ColumnName = "Mã đơn chuyển"; // Mã số đơn chuyển trên MES   订单创建状态
                clf4.DataType = typeof(string);

                DataColumn clf5 = new DataColumn();
                clf5.ColumnName = "Trạng thái xác nhận";
                clf5.DataType = typeof(string);

                DataColumn clf6 = new DataColumn();
                clf6.ColumnName = "Trạng thái chuyển đổi";
                clf6.DataType = typeof(string);

                failReportTB.Columns.AddRange(new DataColumn[] {  clf3, clf4, clf5, clf6 });


            errorReportTB = new DataTable();
            //DataColumn cle1 = new DataColumn();
            //cle1.ColumnName = "Loại phiếu"; // Loại phiếu
            //cle1.DataType = typeof(string);

            //DataColumn cle2 = new DataColumn();
            //cle2.ColumnName = "Mã phiếu"; // Mã phiếu
            //cle2.DataType = typeof(string);

            DataColumn cle3 = new DataColumn();
            cle3.ColumnName = "Mã SX"; // Mã ERP
            cle3.DataType = typeof(string);

            DataColumn cle4 = new DataColumn();
            cle4.ColumnName = "Mã đơn chuyển"; // Mã số đơn chuyển trên MES   订单创建状态
            cle4.DataType = typeof(string);

            DataColumn cle5 = new DataColumn();
            cle5.ColumnName = "Trạng thái xác nhận";
            cle5.DataType = typeof(string);

            DataColumn cle6 = new DataColumn();
            cle6.ColumnName = "Trạng thái chuyển đổi";
            cle6.DataType = typeof(string);

            errorReportTB.Columns.AddRange(new DataColumn[] {  cle3, cle4, cle5, cle6 });        
        }

        public static void addReport(RP_TYPE rpType, string LP, string MP, string erpCode, string moveNo, string confirmStatus, string status)
        {
            if ( s_drInstance == null)
            {
                s_drInstance = new DataReport();
            }
            s_drInstance.writeReport(rpType, LP, MP, erpCode, moveNo, confirmStatus, status);
        }

        private void writeReport(RP_TYPE rpType, string LP, string MP, string erpCode, string moveNo, string confirmStatus, string status)
        {
            if ( rpType == RP_TYPE.Fail)
            {
                failReportTB.Rows.Add(new object[] {erpCode, moveNo, confirmStatus, status });
            }
            else
            {
                if (rpType == RP_TYPE.Success)
                {
                    successReportTB.Rows.Add(new object[] { LP, MP, erpCode, moveNo, confirmStatus, status });
                }
                else
                {
                    errorReportTB.Rows.Add(new object[] { erpCode, moveNo, confirmStatus, status });
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
            ws1.Column("A").Width = 8;
            ws1.Column("B").Width = 11;
            ws1.Column("C").Width = 15;
            ws1.Column("D").Width = 25;
            ws1.Column("E").Width = 19;
            ws1.Column("F").Width = 66;

            ws2.Column("A").Width = 15;
            ws2.Column("B").Width = 25;
            ws2.Column("C").Width = 19;
            ws2.Column("D").Width = 80;

            ws3.Column("A").Width = 15;
            ws3.Column("B").Width = 25;
            ws3.Column("C").Width = 19;
            ws3.Column("D").Width = 80;


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
            MailMessage mail = new MailMessage();
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
            }
            SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Report sent successfully", "");
            mail.Dispose();
            
            System.Threading.Thread.Sleep(1000);
        }
    }
}
