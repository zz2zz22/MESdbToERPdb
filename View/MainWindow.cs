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
<<<<<<< Updated upstream
        protected int cycle;
        public MySqlConnection con = DatabaseUtils.GetMESDBConnection();
=======
        string Title = "";
        EventBroker.EventObserver m_observerLog = null;

        EventBroker.EventParam m_timerEvent = null;

        FlowDocument m_flowDoc = null; //Hien log vao richtextbox
        //Khoi tao bg worker
        int timer = 0;

        System.Threading.Timer tmrEnsureWorkerGetsCalled;
        object lockObject = new object();
        System.Windows.Forms.NotifyIcon m_notify = null; //icon trong bảng thông báo
        SettingClass SettingClass = null; 
        private void InitializeVersion()
        {
             
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major.ToString(); //AssemblyVersion을 가져온다.
            version += "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();
            version += "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();
            Title = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + " " + version;
        }


>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
            while (reader.Read())
            {
                textBox1.Text += $"{reader.GetString("qc_no")}";
                textBox2.Text += $"{reader.GetString("product_name")}";
            }
            con.Close();
        }

=======
            //DataTable dt = new DataTable();
            //mes.sqlDataAdapterFillDatatable(sqlSelectTop30, ref dt);

            //BindingSource bSource = new BindingSource();
            //bSource.DataSource = dt;
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //dataGridView1.AllowUserToResizeRows = false;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dataGridView1.AllowUserToResizeColumns = false;

            //dataGridView1.DataSource = bSource;

            //textBox1.Text = string.Empty;
            //textBox2.Text = string.Empty;

            ////while (reader.Read())
            ////{
            ////    textBox1.Text += $"{reader.GetString("qc_no")}";
            ////    textBox2.Text += $"{reader.GetString("product_name")}";
            ////}
            ////con.Close();
            ///

            //tmrCallBgWorker.Start();
            //btn_start.Text = "STARTING";
            //btn_stop.Text = "STOP";
            //btn_start.Enabled = false;
            //btn_stop.Enabled = true;
            //UploadMain uploadMain = new UploadMain();
            //uploadMain.GetListLOT();
            #endregion
            
            

            tmrCallBgWorker.Start();
            //UploadMain uploadMain = new UploadMain();
            //uploadMain.GetListTransferOrder();
            //btn_start.Enabled = false;
            //btn_stop.Enabled = true;
            ////insertERPSFCTC insert = new insertERPSFCTC();
            ////insert.InsertdataToERP("B511-19120073;0010;B01;B01", "BMH1284056S02", "80", "0", "20211101", "00:00:00"); //test truyền dữ liệu tạo phiếu chuyển D201

            ////rtb_log.Text = "Upload to data to ERP finished!";
            //SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Upload to data to ERP finished!", "");
            //ClearMemory.CleanMemory();
        }
        #region backgroundworker
       
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            cycle--;
            if (0 == cycle)
            {
                //run BW
                BW.RunWorkerAsync();
                cycle = (int)txt_cycle.Value * 3600;
            }
            txt_remainingSec.Text = cycle.ToString();
=======
            if (timer > 0)
            {
                timer--;
                timmer.Text = timer.ToString();
            }
            else
            {
                if (Monitor.TryEnter(lockObject))
                {
                    try
                    {
                        // if bgworker is not busy then call the worker
                        if (!bgWorker.IsBusy)
                        {
                            if (txt_timeRec.Text == "    -  -     :  :  .")
                            {
                                Properties.Settings.Default.TimeSet = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                Properties.Settings.Default.Save();
                                txt_timeRec.Text = Properties.Settings.Default.TimeSet;
                            }
                            else
                            {
                                Properties.Settings.Default.TimeSet = txt_timeRec.Text;
                                Properties.Settings.Default.Save();
                            }                          
                            bgWorker.RunWorkerAsync();
                        }
                            
                    }
                    finally
                    {
                        Monitor.Exit(lockObject);
                    }
                }
                else
                {
                    // as the bgworker is busy we will start a timer that will try to call the bgworker again after some time
                    tmrEnsureWorkerGetsCalled = new System.Threading.Timer(new TimerCallback(tmrEnsureWorkerGetsCalled_Callback), null, 0, 10);
                }
                timer = 3600;
            }          
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        {
=======
        {        
            

           // does a job like writing to serial communication, webservices etc
           var worker = sender as BackgroundWorker;
            try
            {
                UploadMain uploadMain = new UploadMain();
                uploadMain.GetListTransferOrder();
                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Upload to data to ERP finished!", "");
                ClearMemory.CleanMemory();
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Upload to data to ERP not successful!", ex.Message);
            }
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream

=======
            try
            {
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "update UI error", ex.Message);
            }
        }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //DataGridViewRow row = this.dataGridView1.CurrentRow;
        //    //textBox1.Text = row.Cells["qc_no"].Value.ToString();
        //    //textBox2.Text = row.Cells["finish_quantity"].Value.ToString();
        //}
        void tmrEnsureWorkerGetsCalled_Callback(object obj)
        {
            // this timer was started as the bgworker was busy before now it will try to call the bgworker again
            if (Monitor.TryEnter(lockObject))
            {
                try
                {
                    if (!bgWorker.IsBusy)
                        bgWorker.RunWorkerAsync();
                }
                finally
                {
                    Monitor.Exit(lockObject);
                }
                tmrEnsureWorkerGetsCalled = null;
            }
        }
        #endregion

        private void mes2ERPMainWin_FormClosed(object sender, FormClosedEventArgs e)
        {
            tmrCallBgWorker.Tick -= new EventHandler(timer_nextRun_Tick);
            bgWorker.DoWork -= new DoWorkEventHandler(BW_DoWork);
            bgWorker.ProgressChanged -= BW_ProgressChanged;
            bgWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(BW_RunWorkerCompleted);

            if (m_timerEvent != null)
                EventBroker.RemoveTimeEvent(EventBroker.EventID.etUpdateMe, m_timerEvent);
            EventBroker.RemoveObserver(EventBroker.EventID.etLog, m_observerLog);
            EventBroker.Relase();
            Environment.Exit(0);
        }

        private void mes2ERPMainWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Visible = false;
                this.notifyIcon1.Visible = true;
            }
        }

        private void mes2ERPMainWin_Load(object sender, EventArgs e)
        {
            SettingClass = new SettingClass();
            if (File.Exists(SaveObject.Pathsave))
                SettingClass = (SettingClass)SaveObject.Load_data(SaveObject.Pathsave);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
>>>>>>> Stashed changes
        }
    }
}
