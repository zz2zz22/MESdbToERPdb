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

namespace MESdbToERPdb
{
    public class DataReport
    {
        Properties.Settings settings = new Properties.Settings();
        DataTable successReportTB = null;
        DataTable failReportTB = null;
        #region CreateDatatable
        public DataTable createSuccessReportDT()
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
            return successReportTB;
        }
        public void addSuccessReport(string LP, string MP, string erpCode, string moveNo, string status)
        {
            successReportTB.Rows.Add(new object[] { LP, MP, erpCode, moveNo, status });
        }

        public DataTable createFailReportDT()
        {
            failReportTB = new DataTable();
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

            failReportTB.Columns.AddRange(new DataColumn[] { cl1, cl2, cl3, cl4, cl5 });
            return failReportTB;
        }
        public void addFailReport(string LP, string MP, string erpCode, string moveNo, string status)
        {
            failReportTB.Rows.Add(new object[] { LP, MP, erpCode, moveNo, status });
        }
        #endregion

        public static void ExportToExcel(DataTable tbl1, DataTable tbl2, string excelFilePath, string fileName)
        {
            //dstring fileName = "MOreport_" + DateTime.Now.ToString("yyyyMMdd-HHmm");
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string folder = "\\MES2ERP_Reports\\";
            String full_path = path + folder;
            XLWorkbook wb = new XLWorkbook();
            wb.Worksheets.Add(tbl1, "Success MO");
            wb.Worksheets.Add(tbl2, "Failed MO");
            if (!Directory.Exists(full_path))
            {
                Directory.CreateDirectory(full_path);
            }
            // check file path
            if (!string.IsNullOrEmpty(excelFilePath))
            {
                try
                {
                    wb.SaveAs(Path.Combine(excelFilePath, fileName));
                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Report is exported and save at ", Path.Combine(excelFilePath, fileName));
                }
                catch (Exception ex)
                {
                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "ExportToExcel: Không thể lưu file excel! Xin kiểm tra lại đường dẫn.\n" , ex.Message);
                }
            }
            else { // no file path is given
                wb.SaveAs(Path.Combine(full_path, fileName));
                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Đã xuất file excel và lưu tại ", Path.Combine(full_path, fileName));
                
            }
        }

        public void SendReport(string excelFilePath, string fileName, string sender, string sender_pw, string receiver)
        {
            string filePath = Path.Combine(excelFilePath, fileName);
            MailMessage mail = new MailMessage();
            string smtp = sender.Substring(sender.IndexOf('@'));
            if (smtp == "@gmail.com")
            {
                settings.smtp_server = "smtp.gmail.com";
                settings.smtp_port = "587";
            }else if (smtp == "@techlink.vn")
            {
                settings.smtp_server = "smtp.gg.com";
                settings.smtp_port = "465";
            }
            settings.Save();
            SmtpClient SmtpServer = new SmtpClient(settings.smtp_server);
            mail.From = new MailAddress(sender);
            mail.To.Add(receiver);
            mail.Subject = "MES to ERP transfer report : " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            mail.Body = "test mail";

            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(excelFilePath + fileName);
            mail.Attachments.Add(attachment);

            SmtpServer.Port = int.Parse(settings.smtp_port);
            SmtpServer.Credentials = new System.Net.NetworkCredential(sender, sender_pw);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}
