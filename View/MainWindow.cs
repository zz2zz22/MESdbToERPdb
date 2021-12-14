﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
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
        Properties.Settings settings = new Properties.Settings();
        FlowDocument m_flowDoc = null; //Hien log vao richtextbox
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
            SystemLog.Output(SystemLog.MSG_TYPE.War, Title, "Started ");
            
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
            nud_timeInterval.Enabled = false;
            settings.interval = int.Parse(nud_timeInterval.Value.ToString());
            settings.Save();
            //string dEnd = (DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"); // khi bat dau se kg lay du lieu nhung bay gio tét thi set lan dau lay ve truoc
            string dEnd = "2021-12-12 06:00:00";
            TimeSpan ts = new TimeSpan(int.Parse(nud_timeInterval.Value.ToString()), 0, 0);
            string dStart = "2021-12-12 02:00:00";//((Convert.ToDateTime(dEnd)).Subtract(ts)).ToString("yyyy-MM-dd HH:mm:ss");
            tmrCallBgWorker.Interval = settings.interval * 3600000; //3600000;
            tmrCallBgWorker.Start();
            UploadMain uploadMain = new UploadMain();
            DataReport dataReport = new DataReport();
            DataTable failTest = dataReport.createFailReportDT();
            DataTable successTest = dataReport.createSuccessReportDT();

            btn_start.Enabled = false;
            btn_stop.Enabled = true;
            
            uploadMain.GetListTransferOrder(dStart, dEnd);
            settings.dIn = dEnd;
            settings.Save();
            
            SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Upload to data to ERP finished!", "");
            DataReport.ExportToExcel(failTest, successTest, "", DateTime.Now.ToString("yyyyMMdd-HHmm") + ".xlsx");
            ClearMemory.CleanMemory();
        }
        #region backgroundworker
        private void LoadBackgroundWorker()
        {   // this timer calls bgWorker again and again after regular intervals
            tmrCallBgWorker = new System.Windows.Forms.Timer();//Timer for do task
            tmrCallBgWorker.Tick += new EventHandler(timer_nextRun_Tick);
            tmrCallBgWorker.Interval = settings.interval * 3600000; //3600000;

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
            nud_timeInterval.Enabled = true;
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
            //DateTime dIn = Convert.ToDateTime("2021-11-02 11:00:00"); //dùng để test
            //DateTime dOut = Convert.ToDateTime("2021-11-02 12:00:00");

            
            // does a job like writing to serial communication, webservices etc
            var worker = sender as BackgroundWorker;
            try
            {
                
                string timeIN = settings.dIn;
                string dOut = (Convert.ToDateTime(timeIN)).AddHours(settings.interval).ToString("yyyy-MM-dd HH:mm:ss");
                for (int i = 0; i <= 100; i++)
                {
                    if (bgWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    Thread.Sleep(100);
                    bgWorker.ReportProgress(i);
                }
                UploadMain uploadMain = new UploadMain();
                uploadMain.GetListTransferOrder(timeIN,dOut);
                settings.dIn = dOut;
                settings.Save();
                

                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Đã hoàn tất chuyển đổi từ MES sang ERP!", "\n");
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
                pgb_backgroundWorkerProgressBar.Value = e.ProgressPercentage;
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
            this.WindowState = FormWindowState.Minimized;
            e.Cancel = true;
        }

        private void mes2ERPMainWin_Load(object sender, EventArgs e)
        {
            settingClass = new SettingClass();
            if (File.Exists(SaveObject.Pathsave))
                settingClass = (SettingClass)SaveObject.Load_data(SaveObject.Pathsave);
            nud_timeInterval.Value = settings.interval;
            
            LoadBackgroundWorker();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            View.Setting setting = new View.Setting();
            setting.Show();
            
        }
    }
}
