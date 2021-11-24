﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MESdbToERPdb
{
    public class sqlMESPlanningExcutionCon
    {
        public MySqlConnection conn = DatabaseUtils.GetMes_Planning_Excution();

        public string sqlExecuteScalarString(string sql)
        {

            String outstring;
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                outstring = cmd.ExecuteScalar().ToString();
                conn.Close();
                return outstring;
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Database Responce", ex.Message);
                return String.Empty;
            }
        }
        public void getComboBoxData(string sql, ref ComboBox cmb)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                adapter.Dispose();
                cmd.Dispose();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    cmb.Items.Add(row[0].ToString());
                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Database Responce", ex.Message);


            }
            conn.Close();
        }
        public void sqlDataAdapterFillDatatable(string sql, ref DataTable dt)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                {
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Database Responce", ex.Message);
            }
        }
        public bool sqlExecuteNonQuery(string sql, bool result_message_show)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                int response = cmd.ExecuteNonQuery();
                if (response >= 1)
                {
                    if (result_message_show) { SystemLog.Output(SystemLog.MSG_TYPE.War, "Successful!", "Database Responce", ""); }
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Database Responce", ex.Message);
                conn.Close();
                return false;
            }
        }
    }
}
