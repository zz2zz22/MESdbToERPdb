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
        static DataReport s_drInstance = null;
        static DataReport s_mailInstance = null;

        Properties.Settings settings = new Properties.Settings();
        DataTable successReportTB = null;
        DataTable failReportTB = null;

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
                DataColumn clf1 = new DataColumn();
                clf1.ColumnName = "Loại phiếu"; // Loại phiếu
                clf1.DataType = typeof(string);

                DataColumn clf2 = new DataColumn();
                clf2.ColumnName = "Mã phiếu"; // Mã phiếu
                clf2.DataType = typeof(string);

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

                failReportTB.Columns.AddRange(new DataColumn[] { clf1, clf2, clf3, clf4, clf5, clf6 });
            
        }

        public static void addReport(RP_TYPE rpType, string LP, string MP, string erpCode, string moveNo, string confirmStatus, string status)
        {
            if ( s_drInstance == null)
            {
                s_drInstance = new DataReport();
            }
            s_drInstance.writeReport(rpType, LP, MP, erpCode, moveNo, confirmStatus, status);
        }
        public static void SendMail(string excelFilePath, string sender, string sender_pw)
        {
            if ( s_mailInstance == null)
            {
                s_mailInstance = new DataReport();
            }
            s_mailInstance.SendReport(excelFilePath, sender, sender_pw);
        }
        private void writeReport(RP_TYPE rpType, string LP, string MP, string erpCode, string moveNo, string confirmStatus, string status)
        {
            if ( rpType == RP_TYPE.Fail)
            {
                failReportTB.Rows.Add(new object[] { LP, MP, erpCode, moveNo, confirmStatus, status });
            }
            else
            {
                successReportTB.Rows.Add(new object[] { LP, MP, erpCode, moveNo, confirmStatus, status });
            }
        }
        public enum RP_TYPE
        {
            Fail,
            Success
        };
        #endregion
        public static void SaveExcel(string excelFilePath, string fileName)
        {
            if (s_drInstance ==null)
            {
                s_drInstance = new DataReport();
            }
            s_drInstance.ExportToExcel(excelFilePath, fileName);
        }

        public void ExportToExcel(string excelFilePath, string fileName)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\MES2ERP_Reports";
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);
            if (dir.Exists == false)
                dir.Create();
            

            XLWorkbook wb = new XLWorkbook();
            wb.Worksheets.Add(successReportTB, "Success MO");
            wb.Worksheets.Add(failReportTB, "Failed MO");
            
            // check file path
            if (!string.IsNullOrEmpty(excelFilePath))
            {
                try
                {
                    wb.SaveAs(Path.Combine(excelFilePath, fileName));
                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Report is exported and save at ", Path.Combine(excelFilePath, fileName));
                    settings.excelFilePath = Path.Combine(excelFilePath, fileName);
                    settings.Save();
                }
                catch (Exception ex)
                {
                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "ExportToExcel: Không thể lưu file excel! Xin kiểm tra lại đường dẫn.\n" , ex.Message);
                }
            }
            else { // no file path is given
                wb.SaveAs(Path.Combine(path, fileName));
                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Đã xuất file excel và lưu tại ", Path.Combine(path, fileName));
                settings.excelFilePath = Path.Combine(path, fileName);
                settings.Save();
            }
        }

        public void SendReport(string excelFilePath, string sender, string sender_pw)
        {
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
            string[] receivers = settings.cfg_receivers.Split('-');
            for (int i = 0; i < receivers.Length; i ++)
            {
                SmtpClient SmtpServer = new SmtpClient(settings.smtp_server);
                mail.From = new MailAddress(sender);
                mail.To.Add(receivers[i]);
                mail.Subject = "MES to ERP transfer report : " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                mail.Body = "test mail";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(excelFilePath);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = int.Parse(settings.smtp_port);
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(sender, sender_pw);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
        }
    }
}
