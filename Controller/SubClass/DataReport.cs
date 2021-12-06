using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows;

namespace MESdbToERPdb.Controller.SubClass
{
    public class DataReport
    {
        DataTable successReportTB = new DataTable();
        DataTable failReportTB = new DataTable();
        #region CreateDatatable
        public void createSuccessReportDT()
        {
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
        }
        public void addSuccessReport(string LP, string MP, string erpCode, string moveNo, string status)
        {
            successReportTB.Rows.Add(new object[] { LP, MP, erpCode, moveNo, status });
        }

        public void createFailReportDT()
        {
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

            successReportTB.Columns.AddRange(new DataColumn[] { cl1, cl2, cl3, cl4, cl5 });
        }
        public void addFailReport(string LP, string MP, string erpCode, string moveNo, string status)
        {
            successReportTB.Rows.Add(new object[] { LP, MP, erpCode, moveNo, status });
        }
        #endregion

        public static void ExportToExcel(DataTable tbl1, DataTable tbl2, string excelFilePath = null)
        {
           
        }
    }
}
