using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Runtime.InteropServices;

namespace MESdbToERPdb.View
{
    public partial class Error : Form
    {
        
        public Error()
        {
            InitializeComponent();
            
            dtgv_fixData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private static DataTable LoadExcel2DataGrid(bool hasFilter, string value)
        {
            using (DataTable dt = new DataTable())
            { 
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\FixData";
            string fileName = "FixData.xlsx";
            string file = Path.Combine(path, fileName);
                if (File.Exists(file))
                {
                    DataRow row;
                    try
                    {
                        Excel.Application excelApp = new Excel.Application();
                        Excel.Workbook excelWB = excelApp.Workbooks.Open(file);
                        Excel._Worksheet excelWS = excelWB.Sheets[1];
                        Excel.Range excelRange = excelWS.UsedRange;

                        int rowCount = excelRange.Rows.Count;
                        int colCount = excelRange.Columns.Count;

                        for (int j = 1; j <= colCount; j++)
                        {
                            dt.Columns.Add(excelRange.Cells[1, j].Value2.ToString());
                        }
                        int rowCounter;
                        for (int i = 2; i <= rowCount; i++)
                        {
                            row = dt.NewRow();
                            rowCounter = 0;
                            for (int j = 1; j <= colCount; j++)
                            {
                                if (excelRange.Cells[i, j] != null)
                                {
                                    row[rowCounter] = excelRange.Cells[i, j].Value2.ToString();
                                }
                                else
                                {
                                    row[i] = "";
                                }
                                rowCounter++;
                            }
                            if (!hasFilter)
                            {
                                dt.Rows.Add(row);
                            }
                            else
                            {
                                if (row.Table.Columns.Contains(value)){
                                    dt.Rows.Add(row);
                                }
                            }
                            
                        }
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        Marshal.ReleaseComObject(excelRange);
                        Marshal.ReleaseComObject(excelWS);
                        excelWB.Close();
                        Marshal.ReleaseComObject(excelWB);

                        excelApp.Quit();
                        Marshal.ReleaseComObject(excelApp);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                return dt;
            }
        }

        private void Error_Load(object sender, EventArgs e)
        {
            dtgv_fixData.DataSource = LoadExcel2DataGrid(false, "");
        }

        private void dtp_transDate_ValueChanged(object sender, EventArgs e)
        {
            dtgv_fixData.DataSource = null;
            string searchDate = dtp_transDate.Value.ToString("yyyy-MM-dd");
            dtgv_fixData.DataSource = LoadExcel2DataGrid(true, searchDate);
            
        }
    }
    
}
