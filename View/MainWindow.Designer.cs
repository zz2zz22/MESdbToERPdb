﻿
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
<<<<<<< Updated upstream
            this.btn_stopTimer = new System.Windows.Forms.Button();
            this.btn_startTimer = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_cycle = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_remainingSec = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
=======
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_timeRec = new System.Windows.Forms.MaskedTextBox();
            this.lb_progress = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.lb_logText = new System.Windows.Forms.Label();
            this.pgb_backgroundWorkerProgressBar = new System.Windows.Forms.ProgressBar();
>>>>>>> Stashed changes
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.pic_logo = new System.Windows.Forms.PictureBox();
            this.panel_LogText = new System.Windows.Forms.Panel();
<<<<<<< Updated upstream
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
=======
            this.dtgv_Uploaded = new System.Windows.Forms.DataGridView();
>>>>>>> Stashed changes
            this.lb_progress_percentage = new System.Windows.Forms.Label();
            this.btn_setting = new System.Windows.Forms.Button();
<<<<<<< Updated upstream
            this.btn_support = new System.Windows.Forms.Button();
            this.pgb_backgroundWorkerProgressBar = new System.Windows.Forms.ProgressBar();
            this.pic_title = new System.Windows.Forms.PictureBox();
            this.BW = new System.ComponentModel.BackgroundWorker();
            this.timer_nextRun = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
=======
            this.pic_title = new System.Windows.Forms.PictureBox();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.tmrCallBgWorker = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.timmer = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.richTextBoxLog1 = new MESdbToERPdb.RichTextBoxLog();
>>>>>>> Stashed changes
            this.panel_Controller.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_cycle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).BeginInit();
            this.panel_LogText.SuspendLayout();
<<<<<<< Updated upstream
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_title)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
=======
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Uploaded)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_title)).BeginInit();
>>>>>>> Stashed changes
            this.SuspendLayout();
            // 
            // panel_Controller
            // 
            this.panel_Controller.Controls.Add(this.groupBox2);
            this.panel_Controller.Controls.Add(this.groupBox1);
            this.panel_Controller.Controls.Add(this.pic_logo);
            this.panel_Controller.Location = new System.Drawing.Point(12, 12);
            this.panel_Controller.Name = "panel_Controller";
            this.panel_Controller.Size = new System.Drawing.Size(421, 649);
            this.panel_Controller.TabIndex = 0;
            // 
            // btn_stopTimer
            // 
            this.btn_stopTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.btn_stopTimer.Location = new System.Drawing.Point(227, 39);
            this.btn_stopTimer.Name = "btn_stopTimer";
            this.btn_stopTimer.Size = new System.Drawing.Size(160, 64);
            this.btn_stopTimer.TabIndex = 16;
            this.btn_stopTimer.Text = "Stop";
            this.btn_stopTimer.UseVisualStyleBackColor = true;
            this.btn_stopTimer.Click += new System.EventHandler(this.btn_stopTimer_Click);
            // 
            // btn_startTimer
            // 
            this.btn_startTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.btn_startTimer.Location = new System.Drawing.Point(43, 39);
            this.btn_startTimer.Name = "btn_startTimer";
            this.btn_startTimer.Size = new System.Drawing.Size(160, 64);
            this.btn_startTimer.TabIndex = 2;
            this.btn_startTimer.Text = "Start";
            this.btn_startTimer.UseVisualStyleBackColor = true;
            this.btn_startTimer.Click += new System.EventHandler(this.btn_startTimer_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(305, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "hour";
            // 
            // txt_cycle
            // 
            this.txt_cycle.Location = new System.Drawing.Point(214, 172);
            this.txt_cycle.Name = "txt_cycle";
            this.txt_cycle.Size = new System.Drawing.Size(85, 22);
            this.txt_cycle.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "Time between run";
            // 
            // txt_remainingSec
            // 
            this.txt_remainingSec.AutoSize = true;
            this.txt_remainingSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_remainingSec.Location = new System.Drawing.Point(188, 251);
            this.txt_remainingSec.Name = "txt_remainingSec";
            this.txt_remainingSec.Size = new System.Drawing.Size(53, 46);
            this.txt_remainingSec.TabIndex = 11;
            this.txt_remainingSec.Text = "...";
            this.txt_remainingSec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Count down";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(43, 159);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(344, 22);
            this.textBox2.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(43, 131);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(344, 22);
            this.textBox1.TabIndex = 6;
            // 
<<<<<<< Updated upstream
            // btn_stop
            // 
            this.btn_stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stop.Location = new System.Drawing.Point(227, 55);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(160, 70);
            this.btn_stop.TabIndex = 5;
            this.btn_stop.Text = "STOP";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
=======
            this.groupBox1.Controls.Add(this.timmer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_timeRec);
            this.groupBox1.Controls.Add(this.elementHost1);
            this.groupBox1.Controls.Add(this.lb_progress);
            this.groupBox1.Controls.Add(this.btn_start);
            this.groupBox1.Controls.Add(this.lb_logText);
            this.groupBox1.Controls.Add(this.pgb_backgroundWorkerProgressBar);
            this.groupBox1.Controls.Add(this.btn_stop);
            this.groupBox1.Location = new System.Drawing.Point(3, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 541);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
>>>>>>> Stashed changes
            // 
            // txt_timeRec
            // 
            this.txt_timeRec.Location = new System.Drawing.Point(145, 149);
            this.txt_timeRec.Mask = "0000-00-00 00:00:00.000";
            this.txt_timeRec.Name = "txt_timeRec";
            this.txt_timeRec.Size = new System.Drawing.Size(251, 22);
            this.txt_timeRec.TabIndex = 8;
            // 
            // lb_progress
            // 
            this.lb_progress.AutoSize = true;
            this.lb_progress.Font = new System.Drawing.Font("Century", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_progress.Location = new System.Drawing.Point(353, 499);
            this.lb_progress.Name = "lb_progress";
            this.lb_progress.Size = new System.Drawing.Size(53, 22);
            this.lb_progress.TabIndex = 5;
            this.lb_progress.Text = "Start";
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.Location = new System.Drawing.Point(43, 55);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(160, 70);
            this.btn_start.TabIndex = 4;
            this.btn_start.Text = "START";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
<<<<<<< Updated upstream
=======
            // lb_logText
            // 
            this.lb_logText.AutoSize = true;
            this.lb_logText.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_logText.Location = new System.Drawing.Point(6, 253);
            this.lb_logText.Name = "lb_logText";
            this.lb_logText.Size = new System.Drawing.Size(112, 21);
            this.lb_logText.TabIndex = 4;
            this.lb_logText.Text = "Log output : ";
            // 
            // pgb_backgroundWorkerProgressBar
            // 
            this.pgb_backgroundWorkerProgressBar.Location = new System.Drawing.Point(6, 499);
            this.pgb_backgroundWorkerProgressBar.Name = "pgb_backgroundWorkerProgressBar";
            this.pgb_backgroundWorkerProgressBar.Size = new System.Drawing.Size(341, 36);
            this.pgb_backgroundWorkerProgressBar.TabIndex = 2;
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
>>>>>>> Stashed changes
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
            // panel_LogText
            // 
            this.panel_LogText.Controls.Add(this.dataGridView1);
            this.panel_LogText.Controls.Add(this.lb_progress_percentage);
            this.panel_LogText.Controls.Add(this.lb_progress);
            this.panel_LogText.Controls.Add(this.lb_logText);
            this.panel_LogText.Controls.Add(this.btn_setting);
            this.panel_LogText.Controls.Add(this.btn_support);
            this.panel_LogText.Controls.Add(this.pgb_backgroundWorkerProgressBar);
            this.panel_LogText.Controls.Add(this.pic_title);
            this.panel_LogText.Location = new System.Drawing.Point(439, 12);
            this.panel_LogText.Name = "panel_LogText";
            this.panel_LogText.Size = new System.Drawing.Size(811, 649);
            this.panel_LogText.TabIndex = 1;
            // 
<<<<<<< Updated upstream
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeight = 32;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Location = new System.Drawing.Point(7, 160);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 65;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(800, 421);
            this.dataGridView1.TabIndex = 7;
=======
            // dtgv_Uploaded
            // 
            this.dtgv_Uploaded.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_Uploaded.Location = new System.Drawing.Point(4, 140);
            this.dtgv_Uploaded.Name = "dtgv_Uploaded";
            this.dtgv_Uploaded.RowHeadersWidth = 51;
            this.dtgv_Uploaded.RowTemplate.Height = 24;
            this.dtgv_Uploaded.Size = new System.Drawing.Size(804, 500);
            this.dtgv_Uploaded.TabIndex = 7;
>>>>>>> Stashed changes
            // 
            // lb_progress_percentage
            // 
            this.lb_progress_percentage.AutoSize = true;
            this.lb_progress_percentage.Font = new System.Drawing.Font("Century", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_progress_percentage.Location = new System.Drawing.Point(70, 584);
            this.lb_progress_percentage.Name = "lb_progress_percentage";
            this.lb_progress_percentage.Size = new System.Drawing.Size(0, 22);
            this.lb_progress_percentage.TabIndex = 6;
            // 
<<<<<<< Updated upstream
            // lb_progress
            // 
            this.lb_progress.AutoSize = true;
            this.lb_progress.Font = new System.Drawing.Font("Century", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_progress.Location = new System.Drawing.Point(3, 584);
            this.lb_progress.Name = "lb_progress";
            this.lb_progress.Size = new System.Drawing.Size(53, 22);
            this.lb_progress.TabIndex = 5;
            this.lb_progress.Text = "Start";
            // 
            // lb_logText
            // 
            this.lb_logText.AutoSize = true;
            this.lb_logText.Font = new System.Drawing.Font("Century", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_logText.Location = new System.Drawing.Point(3, 127);
            this.lb_logText.Name = "lb_logText";
            this.lb_logText.Size = new System.Drawing.Size(116, 22);
            this.lb_logText.TabIndex = 4;
            this.lb_logText.Text = "Log output : ";
            // 
=======
>>>>>>> Stashed changes
            // btn_setting
            // 
            this.btn_setting.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_setting.BackgroundImage")));
            this.btn_setting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_setting.Location = new System.Drawing.Point(762, 105);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(45, 45);
            this.btn_setting.TabIndex = 2;
            this.btn_setting.UseVisualStyleBackColor = true;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            // 
<<<<<<< Updated upstream
            // btn_support
            // 
            this.btn_support.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_support.BackgroundImage")));
            this.btn_support.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_support.Location = new System.Drawing.Point(711, 105);
            this.btn_support.Name = "btn_support";
            this.btn_support.Size = new System.Drawing.Size(45, 45);
            this.btn_support.TabIndex = 3;
            this.btn_support.UseVisualStyleBackColor = true;
            this.btn_support.Click += new System.EventHandler(this.btn_support_Click);
            // 
            // pgb_backgroundWorkerProgressBar
            // 
            this.pgb_backgroundWorkerProgressBar.Location = new System.Drawing.Point(3, 610);
            this.pgb_backgroundWorkerProgressBar.Name = "pgb_backgroundWorkerProgressBar";
            this.pgb_backgroundWorkerProgressBar.Size = new System.Drawing.Size(804, 36);
            this.pgb_backgroundWorkerProgressBar.TabIndex = 2;
            // 
=======
>>>>>>> Stashed changes
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
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BW_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_RunWorkerCompleted);
            // 
            // tmrCallBgWorker
            // 
            this.tmrCallBgWorker.Interval = 1000;
            this.tmrCallBgWorker.Tick += new System.EventHandler(this.timer_nextRun_Tick);
            // 
<<<<<<< Updated upstream
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_start);
            this.groupBox1.Controls.Add(this.btn_stop);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Location = new System.Drawing.Point(3, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 203);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manual";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_startTimer);
            this.groupBox2.Controls.Add(this.txt_remainingSec);
            this.groupBox2.Controls.Add(this.btn_stopTimer);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_cycle);
            this.groupBox2.Location = new System.Drawing.Point(3, 314);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(415, 332);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Automated";
=======
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Prev record";
            // 
            // timmer
            // 
            this.timmer.AutoSize = true;
            this.timmer.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timmer.Location = new System.Drawing.Point(93, 203);
            this.timmer.Name = "timmer";
            this.timmer.Size = new System.Drawing.Size(104, 21);
            this.timmer.TabIndex = 10;
            this.timmer.Text = "Prev record";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "MestoERP";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // elementHost1
            // 
            this.elementHost1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elementHost1.Location = new System.Drawing.Point(6, 277);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(403, 209);
            this.elementHost1.TabIndex = 7;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.richTextBoxLog1;
>>>>>>> Stashed changes
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
            this.panel_Controller.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_cycle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).EndInit();
            this.panel_LogText.ResumeLayout(false);
            this.panel_LogText.PerformLayout();
<<<<<<< Updated upstream
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_title)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
=======
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Uploaded)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_title)).EndInit();
>>>>>>> Stashed changes
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Controller;
        private System.Windows.Forms.Panel panel_LogText;
        private System.Windows.Forms.ProgressBar pgb_backgroundWorkerProgressBar;
        private System.Windows.Forms.PictureBox pic_title;
        private System.Windows.Forms.PictureBox pic_logo;
        private System.Windows.Forms.Button btn_setting;
        private System.Windows.Forms.Button btn_support;
        private System.Windows.Forms.Label lb_logText;
        private System.Windows.Forms.Label lb_progress_percentage;
        private System.Windows.Forms.Label lb_progress;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_start;
<<<<<<< Updated upstream
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_stopTimer;
        private System.Windows.Forms.Button btn_startTimer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown txt_cycle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txt_remainingSec;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker BW;
        private System.Windows.Forms.Timer timer_nextRun;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
=======
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.Timer tmrCallBgWorker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.DataGridView dtgv_Uploaded;
        private RichTextBoxLog richTextBoxLog1;
        private System.Windows.Forms.MaskedTextBox txt_timeRec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label timmer;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
>>>>>>> Stashed changes
    }
}

