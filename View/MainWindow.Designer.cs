
namespace MESdbToERPdb
{
    partial class mes2ERPMainWin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mes2ERPMainWin));
            this.panel_Controller = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_timeDV = new System.Windows.Forms.Label();
            this.lb_pickTime = new System.Windows.Forms.Label();
            this.nud_timeInterval = new System.Windows.Forms.NumericUpDown();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.pic_logo = new System.Windows.Forms.PictureBox();
            this.lb_logText = new System.Windows.Forms.Label();
            this.panel_LogText = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.richTextBoxLog1 = new MESdbToERPdb.RichTextBoxLog();
            this.lb_progress_percentage = new System.Windows.Forms.Label();
            this.pic_title = new System.Windows.Forms.PictureBox();
            this.BW = new System.ComponentModel.BackgroundWorker();
            this.timer_nextRun = new System.Windows.Forms.Timer(this.components);
            this.lb_progress = new System.Windows.Forms.Label();
            this.pgb_backgroundWorkerProgressBar = new System.Windows.Forms.ProgressBar();
            this.panel_Controller.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_timeInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).BeginInit();
            this.panel_LogText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_title)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Controller
            // 
            this.panel_Controller.Controls.Add(this.groupBox1);
            this.panel_Controller.Controls.Add(this.pic_logo);
            this.panel_Controller.Location = new System.Drawing.Point(12, 12);
            this.panel_Controller.Name = "panel_Controller";
            this.panel_Controller.Size = new System.Drawing.Size(421, 649);
            this.panel_Controller.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_timeDV);
            this.groupBox1.Controls.Add(this.lb_pickTime);
            this.groupBox1.Controls.Add(this.nud_timeInterval);
            this.groupBox1.Controls.Add(this.btn_start);
            this.groupBox1.Controls.Add(this.btn_stop);
            this.groupBox1.Location = new System.Drawing.Point(3, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 541);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // lb_timeDV
            // 
            this.lb_timeDV.AutoSize = true;
            this.lb_timeDV.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_timeDV.Location = new System.Drawing.Point(310, 177);
            this.lb_timeDV.Name = "lb_timeDV";
            this.lb_timeDV.Size = new System.Drawing.Size(47, 21);
            this.lb_timeDV.TabIndex = 8;
            this.lb_timeDV.Text = "hour";
            // 
            // lb_pickTime
            // 
            this.lb_pickTime.AutoSize = true;
            this.lb_pickTime.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pickTime.Location = new System.Drawing.Point(6, 177);
            this.lb_pickTime.Name = "lb_pickTime";
            this.lb_pickTime.Size = new System.Drawing.Size(146, 21);
            this.lb_pickTime.TabIndex = 7;
            this.lb_pickTime.Text = "Fetching interval";
            // 
            // nud_timeInterval
            // 
            this.nud_timeInterval.Location = new System.Drawing.Point(221, 176);
            this.nud_timeInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_timeInterval.Name = "nud_timeInterval";
            this.nud_timeInterval.Size = new System.Drawing.Size(83, 22);
            this.nud_timeInterval.TabIndex = 6;
            this.nud_timeInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_timeInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.Location = new System.Drawing.Point(21, 35);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(176, 90);
            this.btn_start.TabIndex = 4;
            this.btn_start.Text = "START";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stop.Location = new System.Drawing.Point(220, 35);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(176, 90);
            this.btn_stop.TabIndex = 5;
            this.btn_stop.Text = "STOP";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // pic_logo
            // 
            this.pic_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pic_logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pic_logo.Image = ((System.Drawing.Image)(resources.GetObject("pic_logo.Image")));
            this.pic_logo.Location = new System.Drawing.Point(0, 0);
            this.pic_logo.Name = "pic_logo";
            this.pic_logo.Size = new System.Drawing.Size(421, 99);
            this.pic_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_logo.TabIndex = 3;
            this.pic_logo.TabStop = false;
            // 
            // lb_logText
            // 
            this.lb_logText.AutoSize = true;
            this.lb_logText.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_logText.Location = new System.Drawing.Point(3, 105);
            this.lb_logText.Name = "lb_logText";
            this.lb_logText.Size = new System.Drawing.Size(112, 21);
            this.lb_logText.TabIndex = 4;
            this.lb_logText.Text = "Log output : ";
            // 
            // panel_LogText
            // 
            this.panel_LogText.Controls.Add(this.button1);
            this.panel_LogText.Controls.Add(this.lb_progress);
            this.panel_LogText.Controls.Add(this.lb_logText);
            this.panel_LogText.Controls.Add(this.elementHost1);
            this.panel_LogText.Controls.Add(this.lb_progress_percentage);
            this.panel_LogText.Controls.Add(this.pgb_backgroundWorkerProgressBar);
            this.panel_LogText.Controls.Add(this.pic_title);
            this.panel_LogText.Location = new System.Drawing.Point(439, 12);
            this.panel_LogText.Name = "panel_LogText";
            this.panel_LogText.Size = new System.Drawing.Size(811, 649);
            this.panel_LogText.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Location = new System.Drawing.Point(734, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 60);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elementHost1.Location = new System.Drawing.Point(3, 140);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(805, 441);
            this.elementHost1.TabIndex = 7;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.richTextBoxLog1;
            // 
            // lb_progress_percentage
            // 
            this.lb_progress_percentage.AutoSize = true;
            this.lb_progress_percentage.Font = new System.Drawing.Font("Century", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_progress_percentage.Location = new System.Drawing.Point(70, 584);
            this.lb_progress_percentage.Name = "lb_progress_percentage";
            this.lb_progress_percentage.Size = new System.Drawing.Size(0, 23);
            this.lb_progress_percentage.TabIndex = 6;
            // 
            // pic_title
            // 
            this.pic_title.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_title.BackgroundImage")));
            this.pic_title.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.pic_title.Location = new System.Drawing.Point(0, 0);
            this.pic_title.Name = "pic_title";
            this.pic_title.Size = new System.Drawing.Size(811, 99);
            this.pic_title.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_title.TabIndex = 0;
            this.pic_title.TabStop = false;
            // 
            // BW
            // 
            this.BW.WorkerReportsProgress = true;
            this.BW.WorkerSupportsCancellation = true;
            this.BW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_DoWork);
            this.BW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BW_ProgressChanged);
            this.BW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_RunWorkerCompleted);
            // 
            // timer_nextRun
            // 
            this.timer_nextRun.Interval = 1000;
            this.timer_nextRun.Tick += new System.EventHandler(this.timer_nextRun_Tick);
            // 
            // lb_progress
            // 
            this.lb_progress.AutoSize = true;
            this.lb_progress.Font = new System.Drawing.Font("Century", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_progress.Location = new System.Drawing.Point(757, 601);
            this.lb_progress.Name = "lb_progress";
            this.lb_progress.Size = new System.Drawing.Size(37, 23);
            this.lb_progress.TabIndex = 5;
            this.lb_progress.Text = "0%";
            // 
            // pgb_backgroundWorkerProgressBar
            // 
            this.pgb_backgroundWorkerProgressBar.Location = new System.Drawing.Point(3, 587);
            this.pgb_backgroundWorkerProgressBar.Name = "pgb_backgroundWorkerProgressBar";
            this.pgb_backgroundWorkerProgressBar.Size = new System.Drawing.Size(739, 53);
            this.pgb_backgroundWorkerProgressBar.TabIndex = 2;
            // 
            // mes2ERPMainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.panel_LogText);
            this.Controls.Add(this.panel_Controller);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mes2ERPMainWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MES database to ERP database";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mes2ERPMainWin_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mes2ERPMainWin_FormClosed);
            this.Load += new System.EventHandler(this.mes2ERPMainWin_Load);
            this.panel_Controller.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_timeInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).EndInit();
            this.panel_LogText.ResumeLayout(false);
            this.panel_LogText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_title)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Controller;
        private System.Windows.Forms.Panel panel_LogText;
        private System.Windows.Forms.PictureBox pic_title;
        private System.Windows.Forms.PictureBox pic_logo;
        private System.Windows.Forms.Label lb_logText;
        private System.Windows.Forms.Label lb_progress_percentage;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_start;
        private System.ComponentModel.BackgroundWorker BW;
        private System.Windows.Forms.Timer timer_nextRun;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        public System.Windows.Forms.Label lb_pickTime;
        private System.Windows.Forms.NumericUpDown nud_timeInterval;
        private System.Windows.Forms.Label lb_timeDV;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb_progress;
        private RichTextBoxLog richTextBoxLog1;
        private System.Windows.Forms.ProgressBar pgb_backgroundWorkerProgressBar;
    }
}

