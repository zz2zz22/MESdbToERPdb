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
        public void GetListLOT()
        {
            try
            {
                //test
                
                string sqlgetListLOT = "select distinct lot  from m_ERPMQC_REALTIME  where data not like '0' and status  like '' ";
                ComboBox cmb_ = new ComboBox();
                sqlCON data = new sqlCON();
                data.getComboBoxData(sqlgetListLOT, ref cmb_);
                string inspectdate = DateTime.Now.ToString("yyyy-MM-dd");
                string inspecttime = DateTime.Now.ToString("HH:mm:ss");
                string DateUp = DateTime.Now.ToString("yyyyMMdd");
                string TimeUp = DateTime.Now.ToString("HH:mm:ss");
                string TimeSerno = DateTime.Now.ToString("HHmmss");

                for (int cmbitem = 0; cmbitem < cmb_.Items.Count; cmbitem++)
                {
                    string serno = cmb_.Items[cmbitem].ToString().Split(';')[0] + "-" + DateUp + "_" + TimeSerno;
                    DataTable table = new DataTable();
                    StringBuilder sqlGetTable = new StringBuilder();
                    sqlGetTable.Append("select '" + serno + "' as serno,");
                    sqlGetTable.Append("lot, model, site, factory, line, process,item,");
                    sqlGetTable.Append("'" + inspectdate + "' as inspectdate,");
                    sqlGetTable.Append("'" + inspecttime + "' as inspecttime,");
                    sqlGetTable.Append("sum(cast(data as int)) as data,");
                    sqlGetTable.Append("'0' as judge , status, remark from m_ERPMQC_REALTIME_Test  ");
                    sqlGetTable.Append("where data not like '0' and status  like '' and lot = '" + cmb_.Items[cmbitem].ToString() + "'");
                    sqlGetTable.Append("group by item,lot,model,site, factory, line, process, item,  status, remark");
                    data.sqlDataAdapterFillDatatable(sqlGetTable.ToString(), ref table);

                    int intCountOK = CounterỌKERP(ref table);
                    int intCountNG = CounterNGERP(ref table);
                    strLot = table.Rows[0]["lot"].ToString();
                    string code = table.Rows[0]["serno"].ToString().Split('-')[0];
                    string No = table.Rows[0]["serno"].ToString().Split('-')[1];
                    string Model = table.Rows[0]["model"].ToString();

                    string typeNG = "";
                    int checkdouble = 0;
                    
                    string sqlERPError = "select count(*) from m_ERPMQC_REALTIME_Test where serno = '" + serno + "'";
                    
                    string MaLSX = code + "-" + No;
                    Material material = new Material();
                    bool IsDuSoLuong = false;
                    bool IsNVL = false;
                    List<string> _messages = new List<string>();
                    List<MaterialAdapt> listMaterial = new List<MaterialAdapt>();
                    double SL_UPload = intCountOK + intCountNG;
                    //Chua ma Lenh San xuat vao 2 truong dang dua vao
                    bool IsResultheck = material.KiemtraNguyenVatLieu(code, No, SL_UPload, out IsDuSoLuong, out IsNVL, out listMaterial, out _messages);
                    insertERPSFCTC classinsert = new insertERPSFCTC();
                    


                    if (intCountNG + intCountOK > 0) // check lai
                    {
                        //update to realtime

                        if (IsResultheck == true)
                        {
                            //test
                            
                            classinsert.InsertdataToERP(table.Rows[0]["lot"].ToString(), Model, intCountOK.ToString(), intCountNG.ToString(), DateUp, TimeUp);
                            classinsert.updateERP(table.Rows[0]["lot"].ToString(), Model, intCountOK.ToString(), intCountNG.ToString(), DateUp, TimeUp);

                            string PO = table.Rows[0]["lot"].ToString().Split(';')[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, " GetListLOT", ex.Message);
            }
        }
        public int CounterỌKERP(ref DataTable dt)
        {
            int OK = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["remark"].ToString() == "OP") OK += int.Parse(dt.Rows[i]["data"].ToString());
            }
            return OK;
        }
        //Counter NG < chưa dung để đó>
        public int CounterNGERP(ref DataTable dt)
        {
            int NG = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["remark"].ToString() == "NG") NG += int.Parse(dt.Rows[i]["data"].ToString());
            }
            return NG;
        }
    }
}
