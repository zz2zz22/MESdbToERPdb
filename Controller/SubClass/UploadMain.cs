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
        string strLot = "";
        public void GetListTransferOrder(DateTime dIn, DateTime dOut)
        {
            string dateIn = dIn.ToString("yyyy-MM-dd HH:mm:ss");
            string dateOut = dOut.ToString("yyyy-MM-dd HH:mm:ss");
            string DateUp = DateTime.Now.ToString("yyyyMMdd");
            string TimeUp = DateTime.Now.ToString("HH:mm:ss");
            try
            {
                string sqlgetListTO = "select distinct uuid from job_move where create_date < '" + dateOut + "' and create_date >= '" + dateIn + "'";
                ComboBox cmb_ = new ComboBox();
                sqlMESPlanningExcutionCon data = new sqlMESPlanningExcutionCon();
                data.getComboBoxData(sqlgetListTO, ref cmb_);

                for (int cmbitem = 0; cmbitem < cmb_.Items.Count; cmbitem++)
                {
                    string jobmId = cmb_.Items[cmbitem].ToString();
                    DataTable table = new DataTable();
                    StringBuilder sqlGetTable = new StringBuilder();
                    sqlGetTable.Append("select uuid, move_no, job_order_uuid,");
                    sqlGetTable.Append("job_no, work_order_uuid, belong_organization, work_order_process_uuid, ");
                    sqlGetTable.Append("operation_uuid, operation_no, product_uuid, product_lot_no, move_out_date, create_by, update_by, create_date, update_date");
                    sqlGetTable.Append("from job_move");
                    sqlGetTable.Append("where uuid = '" + cmb_.Items[cmbitem].ToString() + "'");
                    data.sqlDataAdapterFillDatatable(sqlGetTable.ToString(), ref table);

                    sqlMESInterCon con2 = new sqlMESInterCon();
                    string jobOrder_id = table.Rows[cmbitem]["job_order_uuid"].ToString();
                    string productLotNo = table.Rows[cmbitem]["product_lot_no"].ToString();
                    DateTime createDate = Convert.ToDateTime(data.sqlExecuteScalarString("select distinct create_date from job_move where uuid = '" + jobmId + "'"));

                    string jobOrderRecord_id = data.sqlExecuteScalarString("select distinct uuid from job_order_record where job_order_uuid = '" + jobOrder_id + "' and product_lot_no = '" + productLotNo + "' and create_date = '" + createDate.ToString("yyyy-MM-dd HH:mm:ss") + "'");

                    int OKQty = int.Parse(con2.sqlExecuteScalarString("select distinct actual_pass_qty from job_order_record_view where uuid = '" + jobOrderRecord_id + "'"));
                    int NGQty = int.Parse(con2.sqlExecuteScalarString("select distinct actual_fail_qty from job_order_record_view where uuid = '" + jobOrderRecord_id + "'"));


                    DateTime transDate = Convert.ToDateTime(table.Rows[0]["move_out_date"].ToString());

                    string erpCode = con2.sqlExecuteScalarString("select distinct erp_order_no from job_order_record_view where uuid = '" + jobOrderRecord_id + "'");
                    
                    string MP = erpCode.Substring(0,4);
                    string SP = erpCode.Substring(4);
                    //check là mã có thuộc ( A511, B511, P511, J511 ) hay kg
                    string operationCode = table.Rows[cmbitem]["operation_no"].ToString();
                    insertERP_D201 classinsert = new insertERP_D201();
                    if ((MP == "A511") || (MP == "B511") || (MP == "P511") || (MP == "J511"))
                    {
                        if (OKQty + NGQty > 0) // check lai
                        {
                            //update to realtime
                            classinsert.InsertdataToERP_D201(MP, SP, OrgCode ,  OKQty.ToString(), NGQty.ToString(), transDate.ToString("yyyyMMdd"), DateUp, TimeUp);
                            classinsert.updateERPD201(MP, SP, OrgCode, OKQty.ToString(), NGQty.ToString(), transDate.ToString("yyyyMMdd"), DateUp, TimeUp); //check transdate

                            string PO = table.Rows[0]["lot"].ToString().Split(';')[0];
                        }
                    }             
                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetListTransferOrder", ex.Message);
            }
        }
        
        public string GetOrganization(string uuid)
        {

        }
    }
}
