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
        protected int cycle;
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

        private void btn_start_Click(object sender, EventArgs e) //test get data from MES
        {
            con.Open();
            string inputDate;
            sqlMESCon mes = new sqlMESCon();
            string sql = " SELECT * FROM `quality_control_order_view`  " +
                "WHERE `qc_no` LIKE '%JO202190339000001%' " +
                "AND `work_order_no` LIKE '%Y51421090017%'" +
                "AND `product_no` LIKE '%CYM0084%'";
            inputDate = "2021-09-01 15:00:00";
            //DateTime currentBGWdate = DateTime.ParseExact(inputDate, "yyyy-MM-dd HH:mm:ss", null);
            string sqlSelectTop30 = " SELECT * FROM `quality_control_order_view` " +
                "WHERE create_date >= '" + inputDate + "' " +
                "LIMIT 100";//test data grid view

            MySqlCommand cmd = new MySqlCommand(sql, con);

            MySqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            mes.sqlDataAdapterFillDatatable(sqlSelectTop30, ref dt);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = dt;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.AllowUserToResizeColumns = false;

            dataGridView1.DataSource = bSource;

            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;

            while (reader.Read())
            {
                textBox1.Text += $"{reader.GetString("qc_no")}";
                textBox2.Text += $"{reader.GetString("product_name")}";
            }
            con.Close();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        private void btn_startTimer_Click(object sender, EventArgs e)
        {
            if (txt_cycle.Value == 0)
            {
                MessageBox.Show("Cycle must be greater than 0!", "Error!");
                return;
            }
            timer_nextRun.Enabled = true;
            cycle = (int)txt_cycle.Value;
            cycle = cycle * 3600;
            txt_remainingSec.Text = cycle.ToString();
            txt_cycle.Enabled = false;
            btn_startTimer.Enabled = false;
            btn_start.Enabled = false;
            btn_stop.Enabled = false;
            //Run BW
            BW.RunWorkerAsync();
        }

        private void timer_nextRun_Tick(object sender, EventArgs e)
        {
            cycle--;
            if (0 == cycle)
            {
                //run BW
                BW.RunWorkerAsync();
                cycle = (int)txt_cycle.Value * 3600;
            }
            txt_remainingSec.Text = cycle.ToString();
        }

        private void btn_stopTimer_Click(object sender, EventArgs e)
        {
            timer_nextRun.Enabled = false;
            cycle = (int)txt_cycle.Value * 3600;
            txt_remainingSec.Text = cycle.ToString();
            txt_cycle.Enabled = true;
            btn_startTimer.Enabled = true;
            btn_start.Enabled = true;
            btn_stop.Enabled = true;

            //Stop BW
            if (!BW.IsBusy && BW.WorkerSupportsCancellation)
                BW.CancelAsync();
            else
                MessageBox.Show("Timer stopped but the process may still be running! Do not close or stop the program until progress have finished!", "Warning!");
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1)
                pgb_backgroundWorkerProgressBar.Maximum = Convert.ToInt32(e.UserState);
            else
                pgb_backgroundWorkerProgressBar.Value = e.ProgressPercentage;
        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
