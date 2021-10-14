using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace MESdbToERPdb
{
    public partial class mes2ERPMainWin : Form
    {
        public MySqlConnection con = DatabaseUtils.GetMESDBConnection();
        public mes2ERPMainWin()
        {
            InitializeComponent();
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            View.SettingWindow settingW = new View.SettingWindow();
            settingW.ShowDialog();
        }

        private void btn_support_Click(object sender, EventArgs e)
        {
            View.SupportWindow supportW = new View.SupportWindow();
            supportW.ShowDialog();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = " SELECT * FROM `quality_control_order_view`  " +
                "WHERE `qc_no` LIKE '%JO202190339000001%' " +
                "AND `work_order_no` LIKE '%Y51421090017%'" +
                "AND `product_no` LIKE '%CYM0084%'";
            
            MySqlCommand cmd = new MySqlCommand(sql, con);

            

            MySqlDataReader reader = cmd.ExecuteReader();

            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;

            while (reader.Read())
            {
                textBox1.Text += $"{reader.GetString("qc_no")};";
                textBox2.Text += $"{reader.GetString("product_name")};";
            }
            con.Close();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
        }
    }
}
