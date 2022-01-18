using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Windows.Forms;
using MySqlConnector;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Data;


namespace MESdbToERPdb
{
    public partial class mes2ERPMainWin : Form
    {
        string Title = "";
        EventBroker.EventObserver m_observerLog = null;
        

        EventBroker.EventParam m_timerEvent = null;
        
        FlowDocument m_flowDoc = null; //Hien log vao flowDoc
        System.Windows.Forms.Timer tmrCallBgWorker;
        
        //Khoi tao bg worker
        BackgroundWorker bgWorker;
        
        System.Threading.Timer tmrEnsureWorkerGetsCalled;
        
        object lockObject = new object();
        
        //System.Windows.Forms.NotifyIcon m_notify = null; //icon trong bảng thông báo
        SettingClass settingClass = null;

        private void InitializeVersion()
        {
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major.ToString(); //AssemblyVersion을 가져온다.
            version += "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();
            version += "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();
            Title = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + " " + version;
        }
        public mes2ERPMainWin()
        {
            InitializeComponent();
            InitializeVersion();
            LoadLogfileInitialize();
            this.Text = Title;
        }
        #region LogFile

        private void LoadLogfileInitialize()
        {
            m_flowDoc = richTextBoxLog1.rtb_log.Document;
            m_flowDoc.LineHeight = 2;
            richTextBoxLog1.rtb_log.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            m_observerLog = new EventBroker.EventObserver(OnReceiveLog);
            EventBroker.AddObserver(EventBroker.EventID.etLog, m_observerLog);
        }

        private void OnReceiveLog(EventBroker.EventID id, EventBroker.EventParam param)
        {
            if (param == null)
                return;
            SystemLog.MSG_TYPE type = (SystemLog.MSG_TYPE)param.ParamInt;
            if (type == SystemLog.MSG_TYPE.Err)
                Output(param.ParamString, Brushes.Yellow);
            else if (type == SystemLog.MSG_TYPE.War)
                Output(param.ParamString, Brushes.YellowGreen);
            else
                Output(param.ParamString, Brushes.LightGray);
        }

        private void Output(string msg, Brush brush = null, bool isBold = false)
        {
            if (richTextBoxLog1.rtb_log.Dispatcher.Thread == Thread.CurrentThread)
                addMessage(msg, brush, false);
            else
                richTextBoxLog1.rtb_log.Dispatcher.BeginInvoke(new Action(delegate { addMessage(msg, brush, false); }));
        }

        private void addMessage(string msg, Brush brush, bool isBold)
        {
            Paragraph newExternalParagraph = new Paragraph();
            newExternalParagraph.Inlines.Add(new Bold(new Run(DateTime.Now.ToString("HH:mm:ss.fff "))));

            if (isBold)
                newExternalParagraph.Inlines.Add(new Bold(new Run(msg/* + Environment.NewLine*/)));
            else
                newExternalParagraph.Inlines.Add(new Run(msg/* + Environment.NewLine*/));

            if (brush == null)
                newExternalParagraph.Foreground = Brushes.White;
            else
                newExternalParagraph.Foreground = brush;
            m_flowDoc.Blocks.Add(newExternalParagraph);
            while (m_flowDoc.Blocks.Count >= 1000)
            {
                m_flowDoc.Blocks.Remove(m_flowDoc.Blocks.FirstBlock);
            }
            if (!richTextBoxLog1.rtb_log.IsSelectionActive)
                richTextBoxLog1.rtb_log.ScrollToEnd();
        }

        #endregion


        private void btn_start_Click(object sender, EventArgs e)
        {
            tmrCallBgWorker.Interval = Properties.Settings.Default.interval * 3600000; //3600000;
            tmrCallBgWorker.Start();
            
            btn_stop.Text = "Stop";
            btn_start.Enabled = false;
            btn_stop.Enabled = true;

            Properties.Settings.Default.dIn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Properties.Settings.Default.intervalCounter = 0;
            Properties.Settings.Default.excelFileName = "Report_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";
            Properties.Settings.Default.Save();

            
            SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Starting...!", "");

            //test

            //UploadMain uploadMain = new UploadMain();
            //string testIn = "2022-01-06 09:00:00";
            //string testOut = "2022-01-06 11:00:00";
            //uploadMain.GetListTransferOrder(testIn, testOut);
            //DataReport.SaveExcel("", Properties.Settings.Default.excelFileName, Properties.Settings.Default.cfg_senders, Properties.Settings.Default.cfg_senderPW);
            //FixData.SaveFixExcel();

            //System.Threading.Thread.Sleep(100);
            //settings.excelFileName = "Report_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";
            //settings.Save();

            ClearMemory.CleanMemory();
        }

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
            DialogResult dialogResult;
            if (Properties.Settings.Default.cfg_language == 1)
            {
                dialogResult = MessageBox.Show("Are you sure want to quit ?", "Confirmation", MessageBoxButtons.OKCancel);
            }
            else
            {
                dialogResult = MessageBox.Show("Bạn muốn thoát chương trình ?", "Xác nhận thoát", MessageBoxButtons.OKCancel);
            }
            if (dialogResult == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void mes2ERPMainWin_Load(object sender, EventArgs e)
        {
            SystemLog.Output(SystemLog.MSG_TYPE.War, Title, "Started ");
            settingClass = new SettingClass();
            if (File.Exists(SaveObject.Pathsave))
                settingClass = (SettingClass)SaveObject.Load_data(SaveObject.Pathsave);
            LoadBackgroundWorker();

        }

        private void btn_settingForm_Click(object sender, EventArgs e)
        {
            View.Setting setting = new View.Setting();
            setting.ShowDialog();
        }

        private void btn_errorForm_Click(object sender, EventArgs e)
        {
            View.Error errorForm = new View.Error();
            errorForm.ShowDialog();
        }

        #region backgroundworker
        private void LoadBackgroundWorker()
        {   // this timer calls bgWorker again and again after regular intervals
            tmrCallBgWorker = new System.Windows.Forms.Timer();//Timer for do task
            tmrCallBgWorker.Tick += new EventHandler(timer_nextRun_Tick);
            tmrCallBgWorker.Interval = Properties.Settings.Default.interval * 3600000; //3600000;

            // this is our worker
            bgWorker = new BackgroundWorker();

            // work happens in this method
            bgWorker.DoWork += new DoWorkEventHandler(BW_DoWork);
            bgWorker.ProgressChanged += BW_ProgressChanged;
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BW_RunWorkerCompleted);
            bgWorker.WorkerReportsProgress = true;
        }
        private void btn_stop_Click(object sender, EventArgs e)
        {
            tmrCallBgWorker.Stop();

            Properties.Settings.Default.Save();
            btn_stop.Text = "Stopping";
            btn_start.Text = "Start";
            btn_start.Enabled = true;
            btn_stop.Enabled = false;
        }

        private void timer_nextRun_Tick(object sender, EventArgs e)
        {
            
            if (Monitor.TryEnter(lockObject))
            {
                try
                {
                    // if bgworker is not busy the call the worker
                    if (!bgWorker.IsBusy)
                        bgWorker.RunWorkerAsync();
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
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            try
            {
                SystemLog.Output(SystemLog.MSG_TYPE.War, "Background worker", "Started ");
                
                string timeIN = Properties.Settings.Default.dIn;
                string dOut = ((Convert.ToDateTime(timeIN)).AddHours(Properties.Settings.Default.interval)).ToString("yyyy-MM-dd HH:mm:ss");
                
                UploadMain uploadMain = new UploadMain();
                uploadMain.GetListTransferOrder(timeIN,dOut);
                Properties.Settings.Default.dIn = dOut;
                Properties.Settings.Default.intervalCounter = Properties.Settings.Default.intervalCounter + Properties.Settings.Default.interval;
                Properties.Settings.Default.Save();
                FixData.SaveFixExcel();
                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Đã hoàn tất chuyển đổi từ MES sang ERP!", "\n");
                
                if (Properties.Settings.Default.intervalCounter > Properties.Settings.Default.intervalMail || Properties.Settings.Default.intervalCounter == Properties.Settings.Default.intervalMail)
                {
                    DataReport.SaveExcel("", Properties.Settings.Default.excelFileName, Properties.Settings.Default.cfg_senders, Properties.Settings.Default.cfg_senderPW);
                    
                    Properties.Settings.Default.excelFileName = "Report_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xlsx";
                    Properties.Settings.Default.intervalCounter = 0;
                    Properties.Settings.Default.Save();
                }
                ClearMemory.CleanMemory();
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Chuyển đổi từ MES sang ERP không thành công!", ex.Message + "\n");
            }

            System.Threading.Thread.Sleep(100);
        }

        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
                
        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "update UI error", ex.Message);
            }
        }

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

        
    }
}
