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
using ClosedXML.Excel;

namespace MESdbToERPdb.View
{
    public partial class Error : Form
    {
        
        public Error()
        {
            InitializeComponent();
        }
        private static DataTable Load2DataGrid()
        {
            DataTable dt = new DataTable();
            string sqlLoadFixData = "select * from v_FixData";
            sqlSOFTCon con = new sqlSOFTCon();
            con.sqlDataAdapterFillDatatable(sqlLoadFixData, ref dt);
            return dt;
        }

        private void Error_Load(object sender, EventArgs e)
        {
            dtgv_fixData.DataSource = Load2DataGrid();
            
            
            btn_startTransfer.Enabled = false;
            btn_startTransfer.BackColor = Color.Gray;
            if ( Properties.Settings.Default.cfg_language == 1)
            {
                ChangeLanguageToEnglish();
            }
            else
            {
                ChangeLanguageToVietnamese();
            }
        }

        private void ChangeLanguageToVietnamese()
        {
            lb_errDatePicker.Text = "Chọn ngày:";
            btn_errorDateSearch.Text = "Tìm";
            lb_pickTimeStart.Text = "Từ:";
            lb_pickTimeEnd.Text = "Đến:";
            btn_startTransfer.Text = "CHUYỂN ĐỔI CÁC MÃ LỖI";
        }
        private void ChangeLanguageToEnglish()
        {
            lb_errDatePicker.Text = "Choose a date:";
            btn_errorDateSearch.Text = "Search";
            lb_pickTimeStart.Text = "From:";
            lb_pickTimeEnd.Text = "To:";
            btn_startTransfer.Text = "TRANSFER ERROR CODE";
        }
        private static DataTable SearchErrorResult(string TransDate, string TimeIn, string TimeEnd)
        {
            string searchDate = TransDate;
            DataTable dt = new DataTable();
            string sqlLoadFixData = "select * from v_FixData where TRANS_DATE = '" + TransDate + "' and TRANS_TIME >= '" + TimeIn + "' and TRANS_TIME <= '" + TimeEnd + "'";
            sqlSOFTCon con = new sqlSOFTCon();
            con.sqlDataAdapterFillDatatable(sqlLoadFixData, ref dt);
            return dt;

        }
        private void btn_errorDateSearch_Click(object sender, EventArgs e)
        {
            dtgv_fixData.DataSource = null;
            btn_startTransfer.Enabled = true;
            btn_startTransfer.BackColor = Color.Yellow;
            dtgv_fixData.DataSource = SearchErrorResult(dtp_transDate.Value.ToString("yyyy-MM-dd"), dtp_timeStart.Value.ToString("HH:mm:ss"), dtp_timeEnd.Value.ToString("HH:mm:ss"));
        }

        public void GetListTransferOrder(DataTable dt)
        {
            //string timeIn = "";
            //string timeOut = "";
            
            //try
            //{ 
            //    ComboBox cmb_ = new ComboBox();
            //    sqlMESPlanningExcutionCon data = new sqlMESPlanningExcutionCon();
                
            //    if (dt != null)
            //    {
            //        List<string> moveNOs = new List<string>(dt.Rows.Count);
            //        foreach (DataRow row in dt.Rows)
            //        {
            //            moveNOs.Add(row[3].ToString());
            //        }
            //        for (int i = 0; i < moveNOs.Count(); i++)
            //        {
            //            string uuid = data.sqlExecuteScalarString("select distinct uuid from job_move where move_no = '" + moveNOs[i] + "'");
            //            cmb_.Items.Add(uuid);
            //        }
            //        DataTable table = new DataTable();
            //        for (int cmbitem = 0; cmbitem < cmb_.Items.Count; cmbitem++)
            //        {
            //            pgb_transferError.Value = (cmbitem + 1) * pgb_transferError.Maximum / cmb_.Items.Count;
            //            string jobmId = cmb_.Items[cmbitem].ToString();

            //            StringBuilder sqlGetTable = new StringBuilder();
            //            sqlGetTable.Append("select uuid, move_no, job_order_uuid,");
            //            sqlGetTable.Append("job_no, work_order_uuid, belong_organization, work_order_process_uuid, ");
            //            sqlGetTable.Append("operation_uuid, operation_no,operation_name, product_uuid, product_no ,product_lot_no, move_out_qty, move_out_pass_qty, move_out_failed_qty, move_out_date, create_by, update_by, create_date, update_date");
            //            sqlGetTable.Append(" from job_move ");
            //            sqlGetTable.Append(" where uuid = '" + cmb_.Items[cmbitem].ToString() + "'");
            //            data.sqlDataAdapterFillDatatable(sqlGetTable.ToString(), ref table);

            //            SystemLog.Output(SystemLog.MSG_TYPE.Err, "Đơn chuyển", table.Rows[cmbitem]["move_no"].ToString() + "(" + jobmId + ").");

            //            sqlMESInterCon con2 = new sqlMESInterCon();
            //            string jobOrder_id = table.Rows[cmbitem]["job_order_uuid"].ToString();
            //            string productLotNo = table.Rows[cmbitem]["product_lot_no"].ToString();

            //            int checkD1orD2 = CheckProcess(table.Rows[cmbitem]["work_order_process_uuid"].ToString(), table.Rows[cmbitem]["operation_uuid"].ToString());
            //            if (checkD1orD2 != 3) //check công đoạn sau MQC thì không lấy dữ liệu
            //            {
            //                string DateUp = DateTime.Now.ToString();
            //                string TimeUp = DateTime.Now.ToString("HH:mm:ss");
            //                DateTime createDateJM = Convert.ToDateTime(data.sqlExecuteScalarString("select distinct create_date from job_move where uuid = '" + jobmId + "'"));

            //                int jmMOPassQty = int.Parse(table.Rows[cmbitem]["move_out_qty"].ToString());

            //                DataTable dtJobRecord = new DataTable();
            //                string getTableJR = "select uuid, job_order_uuid, create_date from job_order_record where job_order_uuid = '" + jobOrder_id + "' and product_lot_no = '" + productLotNo + "' and actual_pass_qty = '" + jmMOPassQty + "'";

            //                data.sqlDataAdapterFillDatatable(getTableJR, ref dtJobRecord);
            //                TimeSpan minDate = new TimeSpan(1, 0, 0, 0);
            //                int flag = 0;
            //                for (int i = 0; i < dtJobRecord.Rows.Count; i++)
            //                {
            //                    TimeSpan subDate = new TimeSpan(0, 0, 0, 0);
            //                    subDate = Convert.ToDateTime(dtJobRecord.Rows[i]["create_date"].ToString()).Subtract(createDateJM);
            //                    if (subDate < minDate)
            //                    {
            //                        minDate = subDate;
            //                        flag = i;
            //                    }
            //                }

            //                sqlMESQualityControlCon qltyCon = new sqlMESQualityControlCon();
            //                string jobOrderRecord_id = dtJobRecord.Rows[flag]["uuid"].ToString();

            //                string reworkQ = qltyCon.sqlExecuteScalarString("select distinct rework_qty from quality_control_order where job_move_uuid = '" + jobmId + "'");
            //                double RWQty = 0;
            //                if (reworkQ != String.Empty)
            //                {
            //                    RWQty = double.Parse(reworkQ);
            //                }

            //                string erpCode = con2.sqlExecuteScalarString("select distinct erp_order_no from job_order_record_view where uuid = '" + jobOrderRecord_id + "'");
            //                string[] mesCode = (con2.sqlExecuteScalarString("select distinct order_no from job_order_record_view where uuid = '" + jobOrderRecord_id + "'")).Split('-');
            //                string checkSemiOngLon = "";
            //                if (mesCode != null && mesCode.Length > 1)
            //                {
            //                    checkSemiOngLon = mesCode[1];
            //                }
            //                string MP = "";
            //                string SP = "";
            //                if (erpCode != "")
            //                {
            //                    MP = erpCode.Substring(0, 4);
            //                    SP = erpCode.Substring(4);
            //                }
            //                string checkSemiValue = "SEMI";

            //                string operationCode = table.Rows[cmbitem]["operation_no"].ToString();
            //                string ParentOrgCode = GetParentOrganizationCode(table.Rows[cmbitem]["belong_organization"].ToString());
            //                bool isOperationJM = false;
            //                if (table.Rows[cmbitem]["operation_no"].ToString().Substring(0, 2) == "JM")
            //                {
            //                    isOperationJM = true;
            //                }
            //                else isOperationJM = false;

            //                double OKQty = double.Parse(con2.sqlExecuteScalarString("select distinct actual_pass_qty from job_order_record_view where uuid = '" + jobOrderRecord_id + "'"));
            //                double NGQty = double.Parse(con2.sqlExecuteScalarString("select distinct actual_fail_qty from job_order_record_view where uuid = '" + jobOrderRecord_id + "'"));

            //                string[] productionCodeHeaders;
            //                if (Properties.Settings.Default.cfg_produceCodes == "")
            //                {
            //                    Properties.Settings.Default.cfg_produceCodes = null;
            //                }
            //                if (Properties.Settings.Default.cfg_produceCodes != null)
            //                {
            //                    productionCodeHeaders = Properties.Settings.Default.cfg_produceCodes.Split('-');
            //                }
            //                else
            //                {
            //                    productionCodeHeaders = null;
            //                }

            //                bool checkIsProductionCode = false;
            //                if (productionCodeHeaders != null)
            //                {
            //                    for (int i = 0; i < productionCodeHeaders.Length; i++)
            //                    {
            //                        if (MP == productionCodeHeaders[i])
            //                        {
            //                            checkIsProductionCode = true;
            //                        }
            //                    }
            //                }
            //                if (erpCode != "")
            //                {
            //                    DateTime transDate = Convert.ToDateTime(table.Rows[cmbitem]["move_out_date"].ToString());
            //                    insertERP_D201 classinsertD2 = new insertERP_D201();
            //                    insertERP_D101 classinsertD1 = new insertERP_D101();
            //                    if (checkIsProductionCode) //check là mã có thuộc ( A511, B511, P511, J511, P512 ) hay kg
            //                    {
            //                        if (MP == "P512" && table.Rows[cmbitem]["belong_organization"].ToString() == "3VFVREIJ1R41") //Nếu là P512 thì xét phải có phải là công đoạn có mã JM của bộ phận J01-2 thì không phát sinh phiếu
            //                        {
            //                            if (!isOperationJM)
            //                            {
            //                                if (OKQty + NGQty > 0)
            //                                {
            //                                    if (!checkSemiOngLon.Contains(checkSemiValue))
            //                                    {
            //                                        if (checkD1orD2 == 2)
            //                                        {
            //                                            //update D201 to realtime
            //                                            classinsertD2.InsertdataToERP_D201(MP, SP, ParentOrgCode, OKQty, NGQty, RWQty, transDate, DateUp, TimeUp, timeIn, timeOut, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString());
            //                                            classinsertD2.updateERPD201(MP, SP, OKQty, NGQty, RWQty, DateUp, TimeUp, transDate); //check transdate 
            //                                        }
            //                                        else
            //                                        {
            //                                            if (checkD1orD2 == 1)
            //                                            {
            //                                                classinsertD1.InsertdataToERP_D101(MP, SP, ParentOrgCode, OKQty, transDate, DateUp, TimeUp, timeIn, timeOut, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString());
            //                                                classinsertD1.updateERPD101(MP, SP, OKQty, DateUp, TimeUp, transDate);
            //                                            }
            //                                            else
            //                                            {
            //                                                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrder", "Không có phiếu chuyển D101 hay D201 do không thuộc các công đoạn cần tạo phiếu.");
                                                            
            //                                            }
            //                                        }
            //                                    }
            //                                    else
            //                                    {
            //                                        SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrder", "Không có phiếu chuyển D101 hay D201 do lệnh sản xuất có chứa 'SEMI'");
            //                                        DataReport.addReport(DataReport.RP_TYPE.Error, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không có phiếu chuyển D101 hay D201 do lệnh sản xuất có chứa 'SEMI'");
            //                                    }
            //                                }
            //                                else
            //                                {
            //                                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrder", "Không thể tạo phiếu chuyển do 'Số lượng hoàn thành(OK)' = 0 và 'Số lượng phế(NG)' = 0 !");
            //                                    DataReport.addReport(DataReport.RP_TYPE.Error, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không thể tạo phiếu chuyển do 'Số lượng hoàn thành(OK)' = 0 và 'Số lượng phế(NG)' = 0 !");
            //                                }
            //                            }
            //                            else
            //                            {
            //                                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrder", "Không có phiếu chuyển D101 hay D201 do công đoạn thuộc J01-2 và có mã công đoạn là JM.");
            //                                DataReport.addReport(DataReport.RP_TYPE.Error, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không có phiếu chuyển D101 hay D201 do công đoạn thuộc J01-2 và có mã công đoạn là JM.");
            //                            }
            //                        }
            //                        else
            //                        {
            //                            if (OKQty + NGQty > 0)
            //                            {
            //                                if (!checkSemiOngLon.Contains(checkSemiValue))
            //                                {
            //                                    if (checkD1orD2 == 2)
            //                                    {
            //                                        //update D201 to realtime
            //                                        classinsertD2.InsertdataToERP_D201(MP, SP, ParentOrgCode, OKQty, NGQty, RWQty, transDate, DateUp, TimeUp, timeIn, timeOut, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString());
            //                                        classinsertD2.updateERPD201(MP, SP, OKQty, NGQty, RWQty, DateUp, TimeUp, transDate); //check transdate 
            //                                    }
            //                                    else
            //                                    {
            //                                        if (checkD1orD2 == 1)
            //                                        {
            //                                            classinsertD1.InsertdataToERP_D101(MP, SP, ParentOrgCode, OKQty, transDate, DateUp, TimeUp, timeIn, timeOut, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString());
            //                                            classinsertD1.updateERPD101(MP, SP, OKQty, DateUp, TimeUp,transDate);
            //                                        }
            //                                        else
            //                                        {
            //                                            SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrder", "Không có phiếu chuyển D101 hay D201 do không thuộc các công đoạn cần tạo phiếu.");
            //                                        }
            //                                    }
            //                                }
            //                                else
            //                                {
            //                                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrder", "Không có phiếu chuyển D101 hay D201 do lệnh sản xuất có chứa 'SEMI'");
            //                                    DataReport.addReport(DataReport.RP_TYPE.Error, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không có phiếu chuyển D101 hay D201 do lệnh sản xuất có chứa 'SEMI'");
            //                                }
            //                            }
            //                            else
            //                            {
            //                                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrder", "Không thể tạo phiếu chuyển do 'Số lượng hoàn thành(OK)' = 0 và 'Số lượng phế(NG)' = 0 !");
            //                                DataReport.addReport(DataReport.RP_TYPE.Error, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không thể tạo phiếu chuyển do 'Số lượng hoàn thành(OK)' = 0 và 'Số lượng phế(NG)' = 0 !");
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrder", "Không có phiếu chuyển D101 hay D201 do không thuộc các mã phiếu cần tạo.");
            //                    }
            //                }
            //                else
            //                {
            //                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrder", "Không có phiếu chuyển do mã sản xuất rỗng");
            //                    DataReport.addReport(DataReport.RP_TYPE.Error, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không có phiếu chuyển do mã sản xuất rỗng");
            //                }
            //            }
            //            else
            //            {
            //                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrder", "Không có phiếu chuyển D101 hay D201 do không thuộc các công đoạn cần tạo phiếu.");
            //            }
            //        }
            //        pgb_transferError.Value = 0;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Không có dữ liệu để chuyển!");
            //    }
                
            //}
            //catch (Exception ex)
            //{
            //    SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetListTransferOrder", ex.Message);
            //}
        }

        public string GetParentOrganizationCode(string uuid)
        {
            sqlMESBaseDataCon con = new sqlMESBaseDataCon();
            string orgCode = con.sqlExecuteScalarString("select distinct organization_code from organization_info where organization_uuid = '" + uuid + "'");
            string parentOrgCode = orgCode.Substring(0, 3);
            return parentOrgCode;
        }


        public int CheckProcess(string work_order_process_id, string operationID)
        {
            sqlMESBaseDataCon con = new sqlMESBaseDataCon();
            sqlMESPlanningExcutionCon conEx = new sqlMESPlanningExcutionCon();
            string productProcessListID = conEx.sqlExecuteScalarString("select distinct product_process_list_uuid from work_order_process where uuid = '" + work_order_process_id + "'");
            int getLineNo = int.Parse(con.sqlExecuteScalarString("select distinct line_no from product_process_list where uuid = '" + productProcessListID + "' and operation_uuid = '" + operationID + "'"));
            string processID = con.sqlExecuteScalarString("select distinct process_uuid from product_process_list where uuid = '" + productProcessListID + "'");
            string getMQClineNo = con.sqlExecuteScalarString("select distinct line_no from process_list where process_uuid = '" + processID + "' and operation_name like '%MQC%'");
            if (getMQClineNo != "")
            {
                if (getLineNo == int.Parse(getMQClineNo))
                {
                    return 2;
                }
                else if (getLineNo == (int.Parse(getMQClineNo) - 1))
                {
                    return 1;
                }
                else if (getLineNo > int.Parse(getMQClineNo))
                {
                    return 3;
                }
                else return 0;
            }
            else return 0;
        }

        private void btn_startTransfer_Click(object sender, EventArgs e)
        {
            if ( Properties.Settings.Default.cfg_language == 1 )
            {
                btn_startTransfer.Text = "TRANSFERING...";
            }
            else
            {
                btn_startTransfer.Text = "ĐANG CHUYỂN ĐỔI...";
            }
            
            DataTable tableDel = new DataTable();
            tableDel = SearchErrorResult(dtp_transDate.Value.ToString("yyyy-MM-dd"), dtp_timeStart.Value.ToString("HH:mm:ss"), dtp_timeEnd.Value.ToString("HH:mm:ss"));
            List<string> moveNOs = new List<string>(tableDel.Rows.Count);
            foreach (DataRow row in tableDel.Rows)
            {
                moveNOs.Add(row[3].ToString());
            }
            for (int i = 0; i < moveNOs.Count(); i++)
            {
                sqlSOFTCon con = new sqlSOFTCon();
                string sqlCmd = "delete from v_FixData where MOVE_NO = '" + moveNOs[i] + "'";
                con.sqlExecuteNonQuery(sqlCmd, false);
            }
            GetListTransferOrder(tableDel);
            MessageBox.Show("Chuyển thành công!");
            if (Properties.Settings.Default.cfg_language == 1)
            {
                btn_startTransfer.Text = "TRANSFER ERROR CODE";
            }
            else
            {
                btn_startTransfer.Text = "CHUYỂN ĐỔI CÁC MÃ LỖI";
            }
            btn_startTransfer.Enabled = false;
            btn_startTransfer.BackColor = Color.Gray;

            dtgv_fixData.DataSource = null;
            dtgv_fixData.DataSource = Load2DataGrid();
        }

        private void dtp_transDate_ValueChanged(object sender, EventArgs e)
        {
            btn_startTransfer.Enabled = false;
            dtgv_fixData.DataSource = null;
            string searchDate = dtp_transDate.Value.ToString("yyyy-MM-dd");
            DataTable dt = new DataTable();
            string sqlLoadFixData = "select * from v_FixData where TRANS_DATE = '" + searchDate + "'";
            sqlSOFTCon con = new sqlSOFTCon();
            con.sqlDataAdapterFillDatatable(sqlLoadFixData, ref dt);
            dtgv_fixData.DataSource = dt;
        }

        private void dtp_timeStart_ValueChanged(object sender, EventArgs e)
        {
            btn_startTransfer.Enabled = false;
        }

        private void dtp_timeEnd_ValueChanged(object sender, EventArgs e)
        {
            btn_startTransfer.Enabled = false;
        }

        private void Error_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }
    }
}
