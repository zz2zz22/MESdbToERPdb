using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClosedXML.Excel;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace MESdbToERPdb
{
    public class FixData
    {
        
        static FixData s_fixInstance = null;

        DataTable fixTB = null;
        private FixData()
        {
            fixTB = new DataTable();
            DataColumn clfix1 = new DataColumn();
            clfix1.ColumnName = "Ngày chuyển";
            clfix1.DataType = typeof(string);

            DataColumn clfix2 = new DataColumn();
            clfix2.ColumnName = "Thời gian chuyển";
            clfix2.DataType = typeof(string);

            DataColumn clfix3 = new DataColumn();
            clfix3.ColumnName = "Mã SX";
            clfix3.DataType = typeof(string);

            DataColumn clfix4 = new DataColumn();
            clfix4.ColumnName = "Mã đơn chuyển MES";
            clfix4.DataType = typeof(string);

            DataColumn clfix5 = new DataColumn();
            clfix5.ColumnName = "Trạng thái";
            clfix5.DataType = typeof(string);

            fixTB.Columns.AddRange(new DataColumn[] { clfix1, clfix2, clfix3, clfix4, clfix5 });
            
        }
        public static void addFixTB(DateTime date, string erpCode, string moveNo, string status)
        {
            if (s_fixInstance == null)
            {
                s_fixInstance = new FixData();
            }
            s_fixInstance.writeFixTB(date, erpCode, moveNo, status);
        }
        private void writeFixTB(DateTime date, string erpCode, string moveNo, string status)
        {
            string transDate = date.ToString("yyyy-MM-dd");
            string transTime = date.ToString("HH:mm:ss");

            fixTB.Rows.Add(new object[] { transDate, transTime, erpCode, moveNo, status });
        }
        public static void SaveFixExcel()
        {
            if (s_fixInstance == null)
            {
                s_fixInstance = new FixData();
            }
            s_fixInstance.ExportToExcel();
            s_fixInstance = null;
        }
        public void ExportToExcel()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\FixData";
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);
            if (dir.Exists == false)
                dir.Create();
            string fileName = "FixData.xlsx";
            if (File.Exists(Path.Combine(path, fileName)))
            {
                XLWorkbook currentWorkbook = new XLWorkbook(Path.Combine(path, fileName));
                IXLWorksheet currentWsh = currentWorkbook.Worksheet("FixData");
                IXLCell cellForNewData = currentWsh.Cell(currentWsh.LastRowUsed().RowNumber() + 1, 1);
                var table = currentWsh.Tables.FirstOrDefault();

                //if (currentWsh.LastRowUsed().RowNumber() != 1)
                //{
                    cellForNewData.InsertData(fixTB);
                    table.Resize(currentWsh.FirstCellUsed(), currentWsh.LastCellUsed());
                    currentWorkbook.Save();
                    currentWorkbook.Dispose();
                //}
                //else
                //{

                //    File.Delete(Path.Combine(path, fileName));
                //    System.Threading.Thread.Sleep(1000);
                //    XLWorkbook wb = new XLWorkbook();
                //    wb.Worksheets.Add(fixTB, "FixData");

                //    wb.SaveAs(Path.Combine(path, fileName));
                //    wb.Dispose();
                //}
            }
            else
            {
                //not exist
                XLWorkbook wb = new XLWorkbook();
                wb.Worksheets.Add(fixTB, "FixData");
                
                wb.SaveAs(Path.Combine(path, fileName));
                wb.Dispose();
            }
            
            //SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Đã xuất file excel và lưu tại ", Path.Combine(path, fileName));
        }
        
    }
}
