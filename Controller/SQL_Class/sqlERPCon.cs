using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MESdbToERPdb.Controller.SQL_Class
{
    class sqlERPCon
    {
        public SqlConnection conn = DatabaseUtils.GetERPDBConnection();

        public string sqlExecuteScalarString(string sql)
        {
            String outstring;
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            //try
            outstring = cmd.ExecuteScalar().ToString();
            conn.Close();
            return outstring;
            //catch

        }
        public void sqlDataAdapterFillDatatable(string sql, ref DataTable dt)
        {
            //try
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            {
                cmd.CommandText = sql;
                cmd.Connection = conn;
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
            }
            //catch
        }

        public bool sqlExecuteNonQuery(string sql, bool result_message_show)
        {
            //try
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            int response = cmd.ExecuteNonQuery();
            if (response > 1)
            {
                if (result_message_show)
                {
                    //log
                }
                conn.Close();
                return true;
            }
            else
            {
                //log
                conn.Close();
                return false;
            }
            //catch
        }
    }
}
