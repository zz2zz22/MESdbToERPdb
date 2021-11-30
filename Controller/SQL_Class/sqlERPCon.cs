using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MESdbToERPdb
{
    public class sqlERPCon
    {
        public SqlConnection conn = DatabaseUtils.GetERPDBConnection();
        public string sqlExecuteScalarCheck(string sql)
        {
            String result;
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                object outstring = cmd.ExecuteScalar().ToString();
                if (outstring.GetType() != typeof(DBNull))
                {
                    conn.Close();
                    result = (string)outstring;
                    return result;
                }
                else
                {
                    conn.Close();
                    result = "";
                    return result;
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "sqlExecuteScalarCheck(string sql)", ex.Message);
                return String.Empty;
            }

        }
        public string sqlExecuteScalarString(string sql)
        {
            String outstring;
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                outstring = cmd.ExecuteScalar().ToString();
                conn.Close();
                return outstring;
            }
            catch(Exception ex)
            {
                conn.Close();
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "sqlExecuteScalarString(string sql)", ex.Message);
                return String.Empty;
            }
        }
        public void sqlDataAdapterFillDatatable(string sql, ref DataTable dt)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter adapter = new SqlDataAdapter();
                {
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);
                }
            }
            catch(Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Database ERP Responce", ex.Message);
            }
        }

        public bool sqlExecuteNonQuery(string sql, bool result_message_show)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                int response = cmd.ExecuteNonQuery();
                if (response >= 1)
                {
                    if (result_message_show) { SystemLog.Output(SystemLog.MSG_TYPE.War, "Successful!", "Database ERP Responce", ""); }
                    conn.Close();
                    return true;
                }
                else
                {
                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "Database ERP Responce", "");

                    conn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Database ERP Responce", ex.Message);
                conn.Close();
                return false;
            }
        }
    }
}
