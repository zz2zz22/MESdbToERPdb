using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Threading;

namespace MESdbToERPdb
{
    public class UploadMain
    {
        sqlERPCon sqlERP = new sqlERPCon();
        sqlSOFTCon sqlSOFTCon = new sqlSOFTCon();
        public void GetListTransferOrder(string dIn, string dOut)
        {
            string timeIn = (Convert.ToDateTime(dIn)).ToString("HH:mm:ss");
            string timeOut = (Convert.ToDateTime(dOut)).ToString("HH:mm:ss");
            sqlMESPlanningExcutionCon data = new sqlMESPlanningExcutionCon();
            string sqlgetListTO = "select distinct uuid from job_move where create_date < '" + dOut + "' and create_date >= '" + dIn + "' and delete_flag = '0'";
            ComboBox cmb_ = new ComboBox();
            
            data.getComboBoxData(sqlgetListTO, ref cmb_);
            DataTable table = new DataTable();
            for (int cmbitem = 0; cmbitem < cmb_.Items.Count; cmbitem++)
            {
                try
                {
                    string jobmId = cmb_.Items[cmbitem].ToString();

                    StringBuilder sqlGetTable = new StringBuilder();
                    sqlGetTable.Append("select uuid, move_no, job_order_uuid,");
                    sqlGetTable.Append("job_no, work_order_uuid, belong_organization, work_order_process_uuid, ");
                    sqlGetTable.Append("operation_uuid, operation_no, operation_name, product_uuid, product_no ,product_lot_no, move_out_qty, move_out_pass_qty, move_out_failed_qty, move_out_date, create_by, update_by, create_date, update_date");
                    sqlGetTable.Append(" from job_move ");
                    sqlGetTable.Append(" where uuid = '" + cmb_.Items[cmbitem].ToString() + "'");
                    data.sqlDataAdapterFillDatatable(sqlGetTable.ToString(), ref table);

                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "Đơn chuyển", table.Rows[cmbitem]["move_no"].ToString() + "(" + jobmId + ").");

                    sqlMESInterCon con2 = new sqlMESInterCon();
                    string jobOrder_id = table.Rows[cmbitem]["job_order_uuid"].ToString();
                    string productLotNo = table.Rows[cmbitem]["product_lot_no"].ToString();

                    int checkD1orD2 = CheckProcess(table.Rows[cmbitem]["work_order_process_uuid"].ToString(), table.Rows[cmbitem]["operation_uuid"].ToString());
                    int checkD1orD2_D511 = CheckProcessD511(table.Rows[cmbitem]["work_order_process_uuid"].ToString(), table.Rows[cmbitem]["operation_uuid"].ToString());
                    bool checkProcessJC = CheckProductCodeForProcessD511(table.Rows[cmbitem]["work_order_process_uuid"].ToString(), table.Rows[cmbitem]["product_no"].ToString());
                    if (checkD1orD2 != 3) //check công đoạn sau MQC thì không lấy dữ liệu
                    {
                        string DateUp = DateTime.Now.ToString();
                        string TimeUp = DateTime.Now.ToString("HH:mm:ss");
                        DateTime createDateJM = Convert.ToDateTime(data.sqlExecuteScalarString("select distinct create_date from job_move where uuid = '" + jobmId + "'"));

                        int jmMOPassQty = int.Parse(table.Rows[cmbitem]["move_out_qty"].ToString());

                        DataTable dtJobRecord = new DataTable();
                        string getTableJR = "select uuid, job_order_uuid, create_date from job_order_record where job_order_uuid = '" + jobOrder_id + "' and product_lot_no = '" + productLotNo + "' and actual_pass_qty = '" + jmMOPassQty + "'";

                        data.sqlDataAdapterFillDatatable(getTableJR, ref dtJobRecord);
                        TimeSpan minDate = new TimeSpan(1, 0, 0, 0);
                        int flag = 0;
                        for (int i = 0; i < dtJobRecord.Rows.Count; i++)
                        {
                            TimeSpan subDate = new TimeSpan(0, 0, 0, 0);
                            subDate = Convert.ToDateTime(dtJobRecord.Rows[i]["create_date"].ToString()).Subtract(createDateJM);
                            if (subDate < minDate)
                            {
                                minDate = subDate;
                                flag = i;
                            }
                        }

                        sqlMESQualityControlCon qltyCon = new sqlMESQualityControlCon();
                        string jobOrderRecord_id = dtJobRecord.Rows[flag]["uuid"].ToString();

                        string reworkQ = qltyCon.sqlExecuteScalarString("select distinct rework_qty from quality_control_order where job_move_uuid = '" + jobmId + "'");
                        double RWQty = 0;
                        if (reworkQ != String.Empty)
                        {
                            RWQty = double.Parse(reworkQ);
                        }

                        string erpCode = con2.sqlExecuteScalarString("select distinct erp_order_no from job_order_record_view where uuid = '" + jobOrderRecord_id + "'");
                        string[] mesCode = (con2.sqlExecuteScalarString("select distinct order_no from job_order_record_view where uuid = '" + jobOrderRecord_id + "'")).Split('-');
                        string checkSemiOngLon = "";
                        if (mesCode != null && mesCode.Length > 1)
                        {
                            checkSemiOngLon = mesCode[1];
                        }
                        string MP = "";
                        string SP = "";
                        if (erpCode != "")
                        {
                            MP = erpCode.Substring(0, 4);
                            SP = erpCode.Substring(4);
                        }
                        string checkSemiValue = "SEMI";

                        string operationCode = table.Rows[cmbitem]["operation_no"].ToString();
                        string ParentOrgCode = GetParentOrganizationCode(table.Rows[cmbitem]["belong_organization"].ToString());
                        bool isOperationJM = false;
                        if (table.Rows[cmbitem]["operation_no"].ToString().Substring(0, 2) == "JM")
                        {
                            isOperationJM = true;
                        }
                        else isOperationJM = false;

                        double OKQty = double.Parse(con2.sqlExecuteScalarString("select distinct actual_pass_qty from job_order_record_view where uuid = '" + jobOrderRecord_id + "'"));
                        double NGQty = double.Parse(con2.sqlExecuteScalarString("select distinct actual_fail_qty from job_order_record_view where uuid = '" + jobOrderRecord_id + "'"));

                        string[] productionCodeHeaders;
                        if (Properties.Settings.Default.cfg_produceCodes == "")
                        {
                            Properties.Settings.Default.cfg_produceCodes = null;
                        }
                        if (Properties.Settings.Default.cfg_produceCodes != null)
                        {
                            productionCodeHeaders = Properties.Settings.Default.cfg_produceCodes.Split('-');
                        }
                        else
                        {
                            productionCodeHeaders = null;
                        }

                        bool checkIsProductionCode = false;
                        if (productionCodeHeaders != null)
                        {
                            for (int i = 0; i < productionCodeHeaders.Length; i++)
                            {
                                if (MP == productionCodeHeaders[i])
                                {
                                    checkIsProductionCode = true;
                                }
                            }
                        }
                        bool isFinished = false;
                        if (erpCode != "")
                        {
                            string MOCTA011 = sqlERP.sqlExecuteScalarString("select distinct UPPER(TA011) from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                            if (MOCTA011 != "")
                            {
                                if (MOCTA011.Contains("Y"))
                                {
                                    isFinished = true;
                                }
                            }
                            DateTime transDate = Convert.ToDateTime(table.Rows[cmbitem]["move_out_date"].ToString());
                            insertERP_D201 classinsertD2 = new insertERP_D201();
                            insertERP_D101 classinsertD1 = new insertERP_D101();

                            if (checkIsProductionCode) //check là mã có thuộc ( A511, B511, P511, J511, P512 ) hay kg
                            {
                                if (MP == "P512" && table.Rows[cmbitem]["belong_organization"].ToString() == "3VFVREIJ1R41") //Nếu là P512 thì xét phải có phải là công đoạn có mã JM của bộ phận J01-2 thì không phát sinh phiếu
                                {
                                    if (!isOperationJM)
                                    {
                                        if (OKQty + NGQty > 0)
                                        {
                                            if (!checkSemiOngLon.Contains(checkSemiValue))
                                            {
                                                if (checkD1orD2 == 2)
                                                {
                                                    if (isFinished == false)
                                                    {
                                                        //update D201 to realtime
                                                        classinsertD2.InsertdataToERP_D201(MP, SP, ParentOrgCode, OKQty, NGQty, RWQty, transDate, DateUp, TimeUp, timeIn, timeOut, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString());
                                                        classinsertD2.updateERPD201(MP, SP, OKQty, NGQty, RWQty, DateUp, TimeUp, transDate); //check transdate 
                                                    }
                                                    else
                                                    {
                                                        SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD2", "Không có phiếu chuyển do MOCTA011 = Y/y.");
                                                        DataReport.addReport(DataReport.RP_TYPE.Fail, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), transDate.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không có phiếu chuyển do MOCTA011 = Y/y.");
                                                    }
                                                }
                                                else
                                                {
                                                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD2", "Không có phiếu chuyển D201 do không thuộc các công đoạn cần tạo phiếu.");
                                                }
                                            }
                                            else
                                            {
                                                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD2", "Không có phiếu chuyển D201 do lệnh sản xuất có chứa 'SEMI'");
                                                DataReport.addReport(DataReport.RP_TYPE.Error, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), transDate.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không có phiếu chuyển D201 do lệnh sản xuất có chứa 'SEMI'");
                                            }
                                        }
                                        else
                                        {
                                            SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD2", "Không thể tạo phiếu chuyển do 'Số lượng hoàn thành(OK)' = 0 và 'Số lượng phế(NG)' = 0 !");
                                            DataReport.addReport(DataReport.RP_TYPE.Error, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), transDate.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không thể tạo phiếu chuyển do 'Số lượng hoàn thành(OK)' = 0 và 'Số lượng phế(NG)' = 0 !");
                                        }
                                    }
                                    else
                                    {
                                        SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD2", "Không có phiếu chuyển D201 do công đoạn thuộc J01-2 và có mã công đoạn là JM.");
                                        DataReport.addReport(DataReport.RP_TYPE.Error, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), transDate.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không có phiếu chuyển D201 do công đoạn thuộc J01-2 và có mã công đoạn là JM.");
                                    }
                                }
                                else
                                {
                                    if (OKQty + NGQty > 0)
                                    {
                                        if (!checkSemiOngLon.Contains(checkSemiValue))
                                        {
                                            if (MP == "D511")
                                            {
                                                if (checkProcessJC == false)
                                                {
                                                    if (checkD1orD2_D511 == 2)
                                                    {
                                                        if (isFinished == false)
                                                        {
                                                            //update D201 to realtime
                                                            classinsertD2.InsertdataToERP_D201(MP, SP, ParentOrgCode, OKQty, NGQty, RWQty, transDate, DateUp, TimeUp, timeIn, timeOut, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString());
                                                            classinsertD2.updateERPD201(MP, SP, OKQty, NGQty, RWQty, DateUp, TimeUp, transDate); //check transdate 
                                                        }
                                                        else
                                                        {
                                                            SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD2", "Không có phiếu chuyển do MOCTA011 = Y/y.");
                                                            DataReport.addReport(DataReport.RP_TYPE.Fail, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), transDate.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không có phiếu chuyển do MOCTA011 = Y/y.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD2", "Không có phiếu chuyển D201 do không thuộc các công đoạn cần tạo phiếu.");
                                                    }
                                                }
                                                else
                                                {
                                                    SystemLog.Output(SystemLog.MSG_TYPE.War, "GetListTransferOrderD2", "Mã hàng có chứa JM hoặc JCB-TFR");
                                                }
                                            }
                                            else
                                            {
                                                if (checkD1orD2 == 2)
                                                {
                                                    if (isFinished == false)
                                                    {
                                                        //update D201 to realtime
                                                        classinsertD2.InsertdataToERP_D201(MP, SP, ParentOrgCode, OKQty, NGQty, RWQty, transDate, DateUp, TimeUp, timeIn, timeOut, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString());
                                                        classinsertD2.updateERPD201(MP, SP, OKQty, NGQty, RWQty, DateUp, TimeUp, transDate); //check transdate 
                                                    }
                                                    else
                                                    {
                                                        SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD2", "Không có phiếu chuyển do MOCTA011 = Y/y.");
                                                        DataReport.addReport(DataReport.RP_TYPE.Fail, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), transDate.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không có phiếu chuyển do MOCTA011 = Y/y.");
                                                    }
                                                }
                                                else
                                                {
                                                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD2", "Không có phiếu chuyển D201 do không thuộc các công đoạn cần tạo phiếu.");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD2", "Không có phiếu chuyển D201 do lệnh sản xuất có chứa 'SEMI'");
                                            DataReport.addReport(DataReport.RP_TYPE.Error, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), transDate.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không có phiếu chuyển D201 do lệnh sản xuất có chứa 'SEMI'");
                                        }
                                    }
                                    else
                                    {
                                        SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD2", "Không thể tạo phiếu chuyển do 'Số lượng hoàn thành(OK)' = 0 và 'Số lượng phế(NG)' = 0 !");
                                        DataReport.addReport(DataReport.RP_TYPE.Error, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), transDate.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không thể tạo phiếu chuyển do 'Số lượng hoàn thành(OK)' = 0 và 'Số lượng phế(NG)' = 0 !");
                                    }
                                }
                            }
                            else
                            {
                                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD2", "Không có phiếu chuyển D201 do không thuộc các mã phiếu cần tạo.");
                            }

                        }
                        else
                        {
                            SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD2", "Không có phiếu chuyển do mã sản xuất rỗng");
                        }
                    }
                    else
                    {
                        SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrder", "Không có phiếu chuyển D201 do không thuộc các công đoạn cần tạo phiếu.");
                    }
                }
                catch (Exception ex)
                {
                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD2", ex.Message);
                    DataReport.addReport(DataReport.RP_TYPE.Error, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", "","", table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), "", "", "", "", ex.Message);
                }
            }
            Thread.Sleep(180000);
            //check again for missing JM
            List<string> listCheckBack = new List<string>();
            string sqlgetListCheckTO = "select distinct uuid from job_move where create_date < '" + dOut + "' and create_date >= '" + dIn + "' and delete_flag = '0'";
            ComboBox cmbCheck_ = new ComboBox();
            data.getComboBoxData(sqlgetListCheckTO, ref cmbCheck_);
            for (int cmbCheck = 0; cmbCheck < cmbCheck_.Items.Count; cmbCheck++)
            {
                if (!cmb_.Items.Contains(cmbCheck_.Items[cmbCheck].ToString()))
                {
                    listCheckBack.Add(cmbCheck_.Items[cmbCheck].ToString());
                }
            }
            String[] missingUUIDs = listCheckBack.ToArray();
            DataTable temp = new DataTable();
            for(int i = 0; i < missingUUIDs.Length; i ++)
            {
                StringBuilder sqlGetTempTable = new StringBuilder();
                sqlGetTempTable.Append("select uuid, move_no, job_order_uuid,");
                sqlGetTempTable.Append("job_no, work_order_uuid, belong_organization, work_order_process_uuid, ");
                sqlGetTempTable.Append("operation_uuid, operation_no, operation_name, product_uuid, product_no ,product_lot_no, move_out_qty, move_out_pass_qty, move_out_failed_qty, move_out_date, create_by, update_by, create_date, update_date");
                sqlGetTempTable.Append(" from job_move ");
                sqlGetTempTable.Append(" where uuid = '" + missingUUIDs[i] + "'");
                data.sqlDataAdapterFillDatatable(sqlGetTempTable.ToString(), ref temp);
                //Add điều kiện check trong DataReport nếu đã thêm mã khi check D1 thì kg thêm nữa và ngược lại
                DataReport.addReport(DataReport.RP_TYPE.Missing, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), temp.Rows[i]["move_out_date"].ToString(), "", "", temp.Rows[i]["job_no"].ToString(), temp.Rows[i]["product_lot_no"].ToString(), temp.Rows[i]["move_no"].ToString(), temp.Rows[i]["product_no"].ToString(), temp.Rows[i]["operation_no"].ToString(), temp.Rows[i]["operation_name"].ToString(), temp.Rows[i]["move_out_qty"].ToString(), "", "", "", "");
            }
        }
        public void GetListTransferOrderD1(string dIn, string dOut)
        {
            string timeIn = (Convert.ToDateTime(dIn)).ToString("HH:mm:ss");
            string timeOut = (Convert.ToDateTime(dOut)).ToString("HH:mm:ss");
            sqlMESPlanningExcutionCon data = new sqlMESPlanningExcutionCon();
            string sqlgetListTO = "select distinct uuid from job_move where create_date < '" + dOut + "' and create_date >= '" + dIn + "' and delete_flag = '0'";
            ComboBox cmb_ = new ComboBox();

            data.getComboBoxData(sqlgetListTO, ref cmb_);
            DataTable table = new DataTable();
            for (int cmbitem = 0; cmbitem < cmb_.Items.Count; cmbitem++)
            {
                try
                {
                    string jobmId = cmb_.Items[cmbitem].ToString();

                    StringBuilder sqlGetTable = new StringBuilder();
                    sqlGetTable.Append("select uuid, move_no, job_order_uuid,");
                    sqlGetTable.Append("job_no, work_order_uuid, belong_organization, work_order_process_uuid, ");
                    sqlGetTable.Append("operation_uuid, operation_no, operation_name, product_uuid, product_no ,product_lot_no, move_out_qty, move_out_pass_qty, move_out_failed_qty, move_out_date, create_by, update_by, create_date, update_date");
                    sqlGetTable.Append(" from job_move ");
                    sqlGetTable.Append(" where uuid = '" + cmb_.Items[cmbitem].ToString() + "'");
                    data.sqlDataAdapterFillDatatable(sqlGetTable.ToString(), ref table);

                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "Đơn chuyển", table.Rows[cmbitem]["move_no"].ToString() + "(" + jobmId + ").");

                    sqlMESInterCon con2 = new sqlMESInterCon();
                    string jobOrder_id = table.Rows[cmbitem]["job_order_uuid"].ToString();
                    string productLotNo = table.Rows[cmbitem]["product_lot_no"].ToString();

                    int checkD1orD2 = CheckProcess(table.Rows[cmbitem]["work_order_process_uuid"].ToString(), table.Rows[cmbitem]["operation_uuid"].ToString());
                    int checkD1orD2_B511 = CheckProcessB511(table.Rows[cmbitem]["work_order_process_uuid"].ToString(), table.Rows[cmbitem]["operation_uuid"].ToString());
                    int checkD1orD2_D511 = CheckProcessD511(table.Rows[cmbitem]["work_order_process_uuid"].ToString(), table.Rows[cmbitem]["operation_uuid"].ToString());
                    bool checkProcessJC = CheckProductCodeForProcessD511(table.Rows[cmbitem]["work_order_process_uuid"].ToString(), table.Rows[cmbitem]["product_no"].ToString());
                    if (checkD1orD2 != 3) //check công đoạn sau MQC thì không lấy dữ liệu
                    {
                        string DateUp = DateTime.Now.ToString();
                        string TimeUp = DateTime.Now.ToString("HH:mm:ss");
                        DateTime createDateJM = Convert.ToDateTime(data.sqlExecuteScalarString("select distinct create_date from job_move where uuid = '" + jobmId + "'"));

                        int jmMOPassQty = int.Parse(table.Rows[cmbitem]["move_out_qty"].ToString());

                        DataTable dtJobRecord = new DataTable();
                        string getTableJR = "select uuid, job_order_uuid, create_date from job_order_record where job_order_uuid = '" + jobOrder_id + "' and product_lot_no = '" + productLotNo + "' and actual_pass_qty = '" + jmMOPassQty + "'";

                        data.sqlDataAdapterFillDatatable(getTableJR, ref dtJobRecord);
                        TimeSpan minDate = new TimeSpan(1, 0, 0, 0);
                        int flag = 0;
                        for (int i = 0; i < dtJobRecord.Rows.Count; i++)
                        {
                            TimeSpan subDate = new TimeSpan(0, 0, 0, 0);
                            subDate = Convert.ToDateTime(dtJobRecord.Rows[i]["create_date"].ToString()).Subtract(createDateJM);
                            if (subDate < minDate)
                            {
                                minDate = subDate;
                                flag = i;
                            }
                        }

                        sqlMESQualityControlCon qltyCon = new sqlMESQualityControlCon();
                        string jobOrderRecord_id = dtJobRecord.Rows[flag]["uuid"].ToString();

                        string reworkQ = qltyCon.sqlExecuteScalarString("select distinct rework_qty from quality_control_order where job_move_uuid = '" + jobmId + "'");
                        double RWQty = 0;
                        if (reworkQ != String.Empty)
                        {
                            RWQty = double.Parse(reworkQ);
                        }

                        string erpCode = con2.sqlExecuteScalarString("select distinct erp_order_no from job_order_record_view where uuid = '" + jobOrderRecord_id + "'");
                        string[] mesCode = (con2.sqlExecuteScalarString("select distinct order_no from job_order_record_view where uuid = '" + jobOrderRecord_id + "'")).Split('-');
                        string checkSemiOngLon = "";
                        if (mesCode != null && mesCode.Length > 1)
                        {
                            checkSemiOngLon = mesCode[1];
                        }
                        string MP = "";
                        string SP = "";
                        if (erpCode != "")
                        {
                            MP = erpCode.Substring(0, 4);
                            SP = erpCode.Substring(4);
                        }
                        string checkSemiValue = "SEMI";

                        string operationCode = table.Rows[cmbitem]["operation_no"].ToString();
                        string ParentOrgCode = GetParentOrganizationCode(table.Rows[cmbitem]["belong_organization"].ToString());
                        bool isOperationJM = false;
                        if (table.Rows[cmbitem]["operation_no"].ToString().Substring(0, 2) == "JM")
                        {
                            isOperationJM = true;
                        }
                        else isOperationJM = false;

                        double OKQty = double.Parse(con2.sqlExecuteScalarString("select distinct actual_pass_qty from job_order_record_view where uuid = '" + jobOrderRecord_id + "'"));
                        double NGQty = double.Parse(con2.sqlExecuteScalarString("select distinct actual_fail_qty from job_order_record_view where uuid = '" + jobOrderRecord_id + "'"));

                        string[] productionCodeHeaders;
                        if (Properties.Settings.Default.cfg_produceCodes == "")
                        {
                            Properties.Settings.Default.cfg_produceCodes = null;
                        }
                        if (Properties.Settings.Default.cfg_produceCodes != null)
                        {
                            productionCodeHeaders = Properties.Settings.Default.cfg_produceCodes.Split('-');
                        }
                        else
                        {
                            productionCodeHeaders = null;
                        }

                        bool checkIsProductionCode = false;
                        if (productionCodeHeaders != null)
                        {
                            for (int i = 0; i < productionCodeHeaders.Length; i++)
                            {
                                if (MP == productionCodeHeaders[i])
                                {
                                    checkIsProductionCode = true;
                                }
                            }
                        }
                        
                        bool isFinished = false;
                        if (erpCode != "")
                        {
                            string MOCTA011 = sqlERP.sqlExecuteScalarString("select distinct UPPER(TA011) from MOCTA where TA001 = '" + MP + "' and TA002 = '" + SP + "'");
                            if (MOCTA011 != "")
                            {
                                if (MOCTA011.Contains("Y"))
                                {
                                    isFinished = true;
                                }
                            }
                            DateTime transDate = Convert.ToDateTime(table.Rows[cmbitem]["move_out_date"].ToString());
                            insertERP_D201 classinsertD2 = new insertERP_D201();
                            insertERP_D101 classinsertD1 = new insertERP_D101();

                            if (checkIsProductionCode) //check là mã có thuộc ( A511, B511, P511, J511, P512 ) hay kg
                            {
                                if (MP == "P512" && table.Rows[cmbitem]["belong_organization"].ToString() == "3VFVREIJ1R41") //Nếu là P512 thì xét phải có phải là công đoạn có mã JM của bộ phận J01-2 thì không phát sinh phiếu
                                {
                                    if (!isOperationJM)
                                    {
                                        if (OKQty + NGQty > 0)
                                        {
                                            if (!checkSemiOngLon.Contains(checkSemiValue))
                                            {
                                                if (checkD1orD2 == 1)
                                                {
                                                    if (isFinished == false)
                                                    {
                                                        classinsertD1.InsertdataToERP_D101(MP, SP, ParentOrgCode, OKQty, transDate, DateUp, TimeUp, timeIn, timeOut, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString());
                                                        classinsertD1.updateERPD101(MP, SP, OKQty, DateUp, TimeUp, transDate);
                                                    }
                                                    else
                                                    {
                                                        SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD1", "Không có phiếu chuyển do MOCTA011 = Y/y.");
                                                        DataReport.addReport(DataReport.RP_TYPE.Fail, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), transDate.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không có phiếu chuyển do MOCTA011 = Y/y.");
                                                    }
                                                }
                                                else
                                                {
                                                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD1", "Không có phiếu chuyển D101 do không thuộc các công đoạn cần tạo phiếu.");
                                                }
                                            }
                                            else
                                            {
                                                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD1", "Không có phiếu chuyển D101 do lệnh sản xuất có chứa 'SEMI'");
                                                DataReport.addReport(DataReport.RP_TYPE.Error, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), transDate.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không có phiếu chuyển D101 do lệnh sản xuất có chứa 'SEMI'");
                                            }
                                        }
                                        else
                                        {
                                            SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD1", "Không thể tạo phiếu chuyển do 'Số lượng hoàn thành(OK)' = 0 và 'Số lượng phế(NG)' = 0 !");
                                            DataReport.addReport(DataReport.RP_TYPE.Error, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), transDate.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không thể tạo phiếu chuyển do 'Số lượng hoàn thành(OK)' = 0 và 'Số lượng phế(NG)' = 0 !");
                                        }
                                    }
                                    else
                                    {
                                        SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD1", "Không có phiếu chuyển D101 do công đoạn thuộc J01-2 và có mã công đoạn là JM.");
                                        DataReport.addReport(DataReport.RP_TYPE.Error, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), transDate.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không có phiếu chuyển D101 do công đoạn thuộc J01-2 và có mã công đoạn là JM.");
                                    }
                                }
                                else
                                {
                                    if (OKQty + NGQty > 0)
                                    {
                                        if (!checkSemiOngLon.Contains(checkSemiValue))
                                        {
                                            if (MP == "B511")
                                            {
                                                if (checkD1orD2_B511 == 1)
                                                {
                                                    if (isFinished == false)
                                                    {
                                                        classinsertD1.InsertdataToERP_D101(MP, SP, ParentOrgCode, OKQty, transDate, DateUp, TimeUp, timeIn, timeOut, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString());
                                                        classinsertD1.updateERPD101(MP, SP, OKQty, DateUp, TimeUp, transDate);
                                                    }
                                                    else
                                                    {
                                                        SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD1", "Không có phiếu chuyển do MOCTA011 = Y/y.");
                                                        DataReport.addReport(DataReport.RP_TYPE.Fail, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), transDate.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không có phiếu chuyển do MOCTA011 = Y/y.");
                                                    }
                                                }
                                                else
                                                {
                                                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD1", "Không có phiếu chuyển D101 do không thuộc các công đoạn cần tạo phiếu.");
                                                }
                                            }
                                            else
                                            {
                                                if (MP == "D511")
                                                {
                                                    if(checkProcessJC == false)
                                                    {
                                                        if(checkD1orD2_D511 == 1)
                                                        {
                                                            if (isFinished == false)
                                                            {
                                                                classinsertD1.InsertdataToERP_D101(MP, SP, ParentOrgCode, OKQty, transDate, DateUp, TimeUp, timeIn, timeOut, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString());
                                                                classinsertD1.updateERPD101(MP, SP, OKQty, DateUp, TimeUp, transDate);
                                                            }
                                                            else
                                                            {
                                                                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD1", "Không có phiếu chuyển do MOCTA011 = Y/y.");
                                                                DataReport.addReport(DataReport.RP_TYPE.Fail, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), transDate.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không có phiếu chuyển do MOCTA011 = Y/y.");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD1", "Không có phiếu chuyển D101 do không thuộc các công đoạn cần tạo phiếu.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        SystemLog.Output(SystemLog.MSG_TYPE.War, "GetListTransferOrderD1", "Mã hàng có chứa JM hoặc JCB-TFR");
                                                    }
                                                }
                                                else
                                                {
                                                    if (checkD1orD2 == 1)
                                                    {
                                                        if (isFinished == false)
                                                        {
                                                            classinsertD1.InsertdataToERP_D101(MP, SP, ParentOrgCode, OKQty, transDate, DateUp, TimeUp, timeIn, timeOut, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString());
                                                            classinsertD1.updateERPD101(MP, SP, OKQty, DateUp, TimeUp, transDate);
                                                        }
                                                        else
                                                        {
                                                            SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD1", "Không có phiếu chuyển do MOCTA011 = Y/y.");
                                                            DataReport.addReport(DataReport.RP_TYPE.Fail, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), transDate.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không có phiếu chuyển do MOCTA011 = Y/y.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD1", "Không có phiếu chuyển D101 do không thuộc các công đoạn cần tạo phiếu.");
                                                    }
                                                }
                                            }

                                        }
                                        else
                                        {
                                            SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD1", "Không có phiếu chuyển D101 do lệnh sản xuất có chứa 'SEMI'");
                                            DataReport.addReport(DataReport.RP_TYPE.Error, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), transDate.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không có phiếu chuyển D101 do lệnh sản xuất có chứa 'SEMI'");
                                        }
                                    }
                                    else
                                    {
                                        SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD1", "Không thể tạo phiếu chuyển do 'Số lượng hoàn thành(OK)' = 0 và 'Số lượng phế(NG)' = 0 !");
                                        DataReport.addReport(DataReport.RP_TYPE.Error, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), transDate.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", MP + SP, table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), OKQty.ToString(), NGQty.ToString(), reworkQ, "", "Không thể tạo phiếu chuyển do 'Số lượng hoàn thành(OK)' = 0 và 'Số lượng phế(NG)' = 0 !");
                                    }
                                }
                            }
                            else
                            {
                                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD1", "Không có phiếu chuyển D101 do không thuộc các mã phiếu cần tạo.");
                            }

                        }
                        else
                        {
                            SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD1", "Không có phiếu chuyển do mã sản xuất rỗng");
                        }
                    }
                    else
                    {
                        SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD1", "Không có phiếu chuyển D101 do không thuộc các công đoạn cần tạo phiếu.");
                    }
                }
                catch (Exception ex)
                {
                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrderD1", ex.Message);
                    DataReport.addReport(DataReport.RP_TYPE.Error, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "", "", "", table.Rows[cmbitem]["move_no"].ToString(), table.Rows[cmbitem]["product_no"].ToString(), table.Rows[cmbitem]["operation_no"].ToString(), table.Rows[cmbitem]["operation_name"].ToString(), "", "", "", "", ex.Message);
                }
            }
            Thread.Sleep(180000);
            //check again for missing JM
            List<string> listCheckBack = new List<string>();
            string sqlgetListCheckTO = "select distinct uuid from job_move where create_date < '" + dOut + "' and create_date >= '" + dIn + "' and delete_flag = '0'";
            ComboBox cmbCheck_ = new ComboBox();
            data.getComboBoxData(sqlgetListCheckTO, ref cmbCheck_);
            for (int cmbCheck = 0; cmbCheck < cmbCheck_.Items.Count; cmbCheck++)
            {
                if (!cmb_.Items.Contains(cmbCheck_.Items[cmbCheck].ToString()))
                {
                    listCheckBack.Add(cmbCheck_.Items[cmbCheck].ToString());
                }
            }
            String[] missingUUIDs = listCheckBack.ToArray();
            DataTable temp = new DataTable();
            for (int i = 0; i < missingUUIDs.Length; i++)
            {
                StringBuilder sqlGetTempTable = new StringBuilder();
                sqlGetTempTable.Append("select uuid, move_no, job_order_uuid,");
                sqlGetTempTable.Append("job_no, work_order_uuid, belong_organization, work_order_process_uuid, ");
                sqlGetTempTable.Append("operation_uuid, operation_no, operation_name, product_uuid, product_no ,product_lot_no, move_out_qty, move_out_pass_qty, move_out_failed_qty, move_out_date, create_by, update_by, create_date, update_date");
                sqlGetTempTable.Append(" from job_move ");
                sqlGetTempTable.Append(" where uuid = '" + missingUUIDs[i] + "'");
                data.sqlDataAdapterFillDatatable(sqlGetTempTable.ToString(), ref temp);
                DataReport.addReport(DataReport.RP_TYPE.Missing, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), temp.Rows[i]["move_out_date"].ToString(), "", "", temp.Rows[i]["job_no"].ToString(), temp.Rows[i]["product_lot_no"].ToString(), temp.Rows[i]["move_no"].ToString(), temp.Rows[i]["product_no"].ToString(), temp.Rows[i]["operation_no"].ToString(), temp.Rows[i]["operation_name"].ToString(), temp.Rows[i]["move_out_qty"].ToString(), "", "", "", "");
            }
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
                }else if (getLineNo > int.Parse(getMQClineNo))
                {
                    return 3;
                }
                else return 0;
            }
            else return 0;
        }
        public int CheckProcessB511(string work_order_process_id, string operationID)
        {
            sqlMESBaseDataCon con = new sqlMESBaseDataCon();
            sqlMESPlanningExcutionCon conEx = new sqlMESPlanningExcutionCon();
            string productProcessListID = conEx.sqlExecuteScalarString("select distinct product_process_list_uuid from work_order_process where uuid = '" + work_order_process_id + "'");
            int getLineNo = int.Parse(con.sqlExecuteScalarString("select distinct line_no from product_process_list where uuid = '" + productProcessListID + "' and operation_uuid = '" + operationID + "'"));
            string processID = con.sqlExecuteScalarString("select distinct process_uuid from product_process_list where uuid = '" + productProcessListID + "'");
            string getMQClineNo = con.sqlExecuteScalarString("select distinct line_no from process_list where process_uuid = '" + processID + "' and operation_name like '%MQC%' and delete_flag = '0'");
            string getOP4lineNo = con.sqlExecuteScalarString("select distinct line_no from process_list where process_uuid = '" + processID + "' and operation_no like 'OP4' and delete_flag = '0'");
            if (getMQClineNo != "")
            {
                if (getLineNo == int.Parse(getMQClineNo))
                {
                    return 2;
                }
            }
            if (getOP4lineNo != "")
            {
                if (getLineNo == int.Parse(getOP4lineNo))
                {
                    return 1;
                }
            }
            return 0;
            
        }

        public int CheckProcessD511(string work_order_process_id, string operationID)
        {
            sqlMESBaseDataCon con = new sqlMESBaseDataCon();
            sqlMESPlanningExcutionCon conEx = new sqlMESPlanningExcutionCon();
            string productProcessListID = conEx.sqlExecuteScalarString("select distinct product_process_list_uuid from work_order_process where uuid = '" + work_order_process_id + "'");
            int getLineNo = int.Parse(con.sqlExecuteScalarString("select distinct line_no from product_process_list where uuid = '" + productProcessListID + "' and operation_uuid = '" + operationID + "'"));
            string processID = con.sqlExecuteScalarString("select distinct process_uuid from product_process_list where uuid = '" + productProcessListID + "'");
            string getDun2lineNo = con.sqlExecuteScalarString("select distinct line_no from process_list where process_uuid = '" + processID + "' and (operation_name like '%ĐÙN LỚP 2%' OR operation_name like '%ĐÙN LỚP NGOÀI%') and delete_flag = '0'");
            string getDun3lineNo = con.sqlExecuteScalarString("select distinct line_no from process_list where process_uuid = '" + processID + "' and operation_name like '%ĐÙN LỚP 3%' and delete_flag = '0'");
            if (getDun2lineNo != "")
            {
                if (getLineNo == int.Parse(getDun2lineNo))
                {
                    return 2;
                }
            }
            if (getDun3lineNo != "")
            {
                if (getLineNo == int.Parse(getDun3lineNo))
                {
                    return 2;
                }
            }
            if (getLineNo == 1)
            {
                return 1;
            }
            return 0;
        }
        public bool CheckProductCodeForProcessD511(string work_order_process_id, string prodNo)
        {
            sqlMESBaseDataCon con = new sqlMESBaseDataCon();
            sqlMESPlanningExcutionCon conEx = new sqlMESPlanningExcutionCon();
            string productProcessListID = conEx.sqlExecuteScalarString("select distinct product_process_list_uuid from work_order_process where uuid = '" + work_order_process_id + "'");
            string processID = con.sqlExecuteScalarString("select distinct process_uuid from product_process_list where uuid = '" + productProcessListID + "'");
            if (processID == "4LJBK8SSPDS1")
            {
                if (prodNo.Contains("JM") || prodNo.Contains("JCB-TFR"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
