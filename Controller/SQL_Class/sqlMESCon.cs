using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace MESdbToERPdb
{
    public class sqlMESCon
    {
        public MySqlConnection conn = DatabaseUtils.GetMESDBConnection();

        public string sqlExecuteScalarString(string sql)
        {
            String outstring;
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            //try
            outstring = cmd.ExecuteScalar().ToString();

            conn.Close();
            return outstring;
            //catch
            //Xuất log file báo lỗi nếu có
        }
        public void sqlDataAdapterFillDatatable(string sql, ref DataTable dt)
        {
            //try
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
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
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            int response = cmd.ExecuteNonQuery();
            if (response > 1)
            {
                if (result_message_show)
                {
                    //Xuất log message ra để thông báo kết nối thành công
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
