
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
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.richTextBoxLog1 = new MESdbToERPdb.RichTextBoxLog();
            this.lb_progress = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.lb_logText = new System.Windows.Forms.Label();
            this.pgb_backgroundWorkerProgressBar = new System.Windows.Forms.ProgressBar();
            this.btn_stop = new System.Windows.Forms.Button();
            this.pic_logo = new System.Windows.Forms.PictureBox();
            this.panel_LogText = new System.Windows.Forms.Panel();
            this.dtgv_Uploaded = new System.Windows.Forms.DataGridView();
            this.lb_progress_percentage = new System.Windows.Forms.Label();
            this.btn_setting = new System.Windows.Forms.Button();
            this.pic_title = new System.Windows.Forms.PictureBox();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.tmrCallBgWorker = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel_Controller.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).BeginInit();
            this.panel_LogText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Uploaded)).BeginInit();
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
            this.groupBox1.Controls.Add(this.maskedTextBox1);
            this.groupBox1.Controls.Add(this.label1);
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
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(141, 176);
            this.maskedTextBox1.Mask = "0000-00-00 00:00:00.000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(182, 22);
            this.maskedTextBox1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Prev Time";
            // 
            // elementHost1
            // 
            this.elementHost1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elementHost1.Location = new System.Drawing.Point(6, 307);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(403, 179);
            this.elementHost1.TabIndex = 7;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.richTextBoxLog1;
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
            this.btn_start.Location = new System.Drawing.Point(21, 35);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(176, 90);
            this.btn_start.TabIndex = 4;
            this.btn_start.Text = "START";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // lb_logText
            // 
            this.lb_logText.AutoSize = true;
            this.lb_logText.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_logText.Location = new System.Drawing.Point(6, 283);
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
            this.panel_LogText.Controls.Add(this.dtgv_Uploaded);
            this.panel_LogText.Controls.Add(this.lb_progress_percentage);
            this.panel_LogText.Controls.Add(this.btn_setting);
            this.panel_LogText.Controls.Add(this.pic_title);
            this.panel_LogText.Location = new System.Drawing.Point(439, 12);
            this.panel_LogText.Name = "panel_LogText";
            this.panel_LogText.Size = new System.Drawing.Size(811, 649);
            this.panel_LogText.TabIndex = 1;
            // 
            // dtgv_Uploaded
            // 
            this.dtgv_Uploaded.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_Uploaded.Location = new System.Drawing.Point(4, 140);
            this.dtgv_Uploaded.Name = "dtgv_Uploaded";
            this.dtgv_Uploaded.RowHeadersWidth = 51;
            this.dtgv_Uploaded.RowTemplate.Height = 24;
            this.dtgv_Uploaded.Size = new System.Drawing.Size(804, 500);
            this.dtgv_Uploaded.TabIndex = 7;
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
            // btn_setting
            // 
            this.btn_setting.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_setting.BackgroundImage")));
            this.btn_setting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_setting.Location = new System.Drawing.Point(749, 24);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(45, 45);
            this.btn_setting.TabIndex = 2;
            this.btn_setting.UseVisualStyleBackColor = true;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
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
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BW_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_RunWorkerCompleted);
            // 
            // tmrCallBgWorker
            // 
            this.tmrCallBgWorker.Interval = 1000;
            this.tmrCallBgWorker.Tick += new System.EventHandler(this.timer_nextRun_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "MES->ERP";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
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
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).EndInit();
            this.panel_LogText.ResumeLayout(false);
            this.panel_LogText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Uploaded)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_title)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Controller;
        private System.Windows.Forms.Panel panel_LogText;
        private System.Windows.Forms.ProgressBar pgb_backgroundWorkerProgressBar;
        private System.Windows.Forms.PictureBox pic_title;
        private System.Windows.Forms.PictureBox pic_logo;
        private System.Windows.Forms.Button btn_setting;
        private System.Windows.Forms.Label lb_logText;
        private System.Windows.Forms.Label lb_progress_percentage;
        private System.Windows.Forms.Label lb_progress;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_start;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.Timer tmrCallBgWorker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private RichTextBoxLog richTextBoxLog1;
        private System.Windows.Forms.DataGridView dtgv_Uploaded;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

