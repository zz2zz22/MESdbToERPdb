using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace MESdbToERPdb
{
    public class UploadMain
    {
        
        public void GetListTransferOrder(DateTime dIn, DateTime dOut)
        {
            string dateIn = dIn.ToString("yyyy-MM-dd HH:mm:ss");
            string dateOut = dOut.ToString("yyyy-MM-dd HH:mm:ss");
            string DateUp = DateTime.Now.ToString();
            string TimeUp = DateTime.Now.ToString("HH:mm:ss");
            try
            {
                string sqlgetListTO = "select distinct uuid from job_move where create_date < '" + dateOut + "' and create_date >= '" + dateIn + "'";
                ComboBox cmb_ = new ComboBox();
                sqlMESPlanningExcutionCon data = new sqlMESPlanningExcutionCon();
                data.getComboBoxData(sqlgetListTO, ref cmb_);
                DataTable table = new DataTable();
                for (int cmbitem = 0; cmbitem < cmb_.Items.Count; cmbitem++)
                {
                    string jobmId = cmb_.Items[cmbitem].ToString();
                    
                    StringBuilder sqlGetTable = new StringBuilder();
                    sqlGetTable.Append("select uuid, move_no, job_order_uuid,");
                    sqlGetTable.Append("job_no, work_order_uuid, belong_organization, work_order_process_uuid, ");
                    sqlGetTable.Append("operation_uuid, operation_no, product_uuid, product_no ,product_lot_no, move_out_date, create_by, update_by, create_date, update_date");
                    sqlGetTable.Append(" from job_move ");
                    sqlGetTable.Append(" where uuid = '" + cmb_.Items[cmbitem].ToString() + "'");
                    data.sqlDataAdapterFillDatatable(sqlGetTable.ToString(), ref table);

                    sqlMESInterCon con2 = new sqlMESInterCon();
                    string jobOrder_id = table.Rows[cmbitem]["job_order_uuid"].ToString();
                    string productLotNo = table.Rows[cmbitem]["product_lot_no"].ToString();


                    DateTime createDateJM = Convert.ToDateTime(data.sqlExecuteScalarString("select distinct create_date from job_move where uuid = '" + jobmId + "'"));
                    ComboBox cmb_jobRecord = new ComboBox();
                   
                    DataTable dtJobRecord = new DataTable();
                    string getTableJR = "select uuid, job_order_uuid, create_date from job_order_record where job_order_uuid = '" + jobOrder_id + "' and product_lot_no = '"+ productLotNo +"'";
                    data.sqlDataAdapterFillDatatable(getTableJR, ref dtJobRecord);
                    TimeSpan minDate = new TimeSpan(3,0,0,0);
                    int flag = 0;
                    for (int i = 0; i< dtJobRecord.Rows.Count;i++)
                    {
                        TimeSpan subDate = new TimeSpan(0, 0, 0, 0);
                        subDate = Convert.ToDateTime(dtJobRecord.Rows[i]["create_date"].ToString()).Subtract(createDateJM);
                        if ( subDate < minDate )
                        {
                            minDate = subDate;
                            flag = i;
                        }
                    }
                    string jobOrderRecord_id = dtJobRecord.Rows[flag]["uuid"].ToString();

                    int OKQty = int.Parse(con2.sqlExecuteScalarString("select distinct actual_pass_qty from job_order_record_view where uuid = '" + jobOrderRecord_id + "'"));
                    int NGQty = int.Parse(con2.sqlExecuteScalarString("select distinct actual_fail_qty from job_order_record_view where uuid = '" + jobOrderRecord_id + "'"));


                    DateTime transDate = Convert.ToDateTime(table.Rows[cmbitem]["move_out_date"].ToString());

                    string erpCode = con2.sqlExecuteScalarString("select distinct erp_order_no from job_order_record_view where uuid = '" + jobOrderRecord_id + "'");
                    string[] mesCode = (con2.sqlExecuteScalarString("select distinct order_no from job_order_record_view where uuid = '" + jobOrderRecord_id + "'")).Split('-');
                    string checkSemiOngLon = "";
                    if (mesCode.Length > 1)
                    {
                         checkSemiOngLon = mesCode[1];
                    }
                    
                    if (erpCode != "")
                    {
                        string MP = erpCode.Substring(0, 4);
                        string SP = erpCode.Substring(4);

                        int checkD1orD2 = CheckProcess(table.Rows[cmbitem]["work_order_process_uuid"].ToString(), table.Rows[cmbitem]["operation_uuid"].ToString());
                        //check là mã có thuộc ( A511, B511, P511, J511, P512 ) hay kg
                        string operationCode = table.Rows[cmbitem]["operation_no"].ToString();
                        string ParentOrgCode = GetParentOrganizationCode(table.Rows[cmbitem]["belong_organization"].ToString());
                        bool isOperationJM = false;
                        if (table.Rows[cmbitem]["operation_no"].ToString().Substring(0, 2) == "JM")
                        {
                            isOperationJM = true;
                        } else isOperationJM = false;

                        
                        insertERP_D201 classinsertD2 = new insertERP_D201();
                        insertERP_D101 classinsertD1 = new insertERP_D101();
                        if ((MP == "A511") || (MP == "B511") || (MP == "P511") || (MP == "J511") || (MP == "P512"))
                        {
                            if (MP == "P512" && table.Rows[cmbitem]["belong_organization"].ToString() == "3VFVREIJ1R41")
                            {
                                if (!isOperationJM)
                                {
                                    if (OKQty + NGQty > 0)
                                    {
                                        if (checkSemiOngLon == "")
                                        {
                                            if (checkD1orD2 == 2)
                                            {
                                                //update D201 to realtime
                                                classinsertD2.InsertdataToERP_D201(MP, SP, OKQty.ToString(), NGQty.ToString(), transDate, DateUp, TimeUp);
                                                classinsertD2.updateERPD201(MP, SP, OKQty.ToString(), NGQty.ToString(), transDate, DateUp, TimeUp); //check transdate 
                                            }
                                            if (checkD1orD2 == 1)
                                            {
                                                classinsertD1.InsertdataToERP_D101(MP, SP, ParentOrgCode, OKQty.ToString(), transDate, DateUp, TimeUp);
                                                classinsertD1.updateERPD101(MP, SP, OKQty.ToString(), transDate, DateUp, TimeUp);
                                            }
                                            else
                                            {
                                                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrder", "Không có phiếu chuyển D101 hay D201");
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {

                            }
                            if (OKQty + NGQty > 0)
                            {
                                if (checkSemiOngLon == "")
                                {
                                    if (checkD1orD2 == 2)
                                    {
                                        //update D201 to realtime
                                        classinsertD2.InsertdataToERP_D201(MP, SP, OKQty.ToString(), NGQty.ToString(), transDate, DateUp, TimeUp);
                                        classinsertD2.updateERPD201(MP, SP, OKQty.ToString(), NGQty.ToString(), transDate, DateUp, TimeUp); //check transdate 
                                    }
                                    if (checkD1orD2 == 1)
                                    {
                                        classinsertD1.InsertdataToERP_D101(MP, SP, ParentOrgCode, OKQty.ToString(), transDate, DateUp, TimeUp);
                                        classinsertD1.updateERPD101(MP, SP, OKQty.ToString(), transDate, DateUp, TimeUp);
                                    }
                                    else
                                    {
                                        SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrder", "Không có phiếu chuyển D101 hay D201");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        SystemLog.Output(SystemLog.MSG_TYPE.Nor, "GetListTransferOrder", "Không có phiếu chuyển.");
                    }          
                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetListTransferOrder", ex.Message);
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
                }
                else return 0;
            }
            else return 0;
        }
    }
}
