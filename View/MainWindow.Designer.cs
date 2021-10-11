
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mes2ERPMainWin));
            this.panel_Controller = new System.Windows.Forms.Panel();
            this.pic_logo = new System.Windows.Forms.PictureBox();
            this.panel_LogText = new System.Windows.Forms.Panel();
            this.lb_progress_percentage = new System.Windows.Forms.Label();
            this.lb_progress = new System.Windows.Forms.Label();
            this.lb_logText = new System.Windows.Forms.Label();
            this.btn_setting = new System.Windows.Forms.Button();
            this.btn_support = new System.Windows.Forms.Button();
            this.pgb_backgroundWorkerProgressBar = new System.Windows.Forms.ProgressBar();
            this.rtb_logText = new System.Windows.Forms.RichTextBox();
            this.pic_title = new System.Windows.Forms.PictureBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.panel_Controller.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).BeginInit();
            this.panel_LogText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_title)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Controller
            // 
            this.panel_Controller.Controls.Add(this.btn_stop);
            this.panel_Controller.Controls.Add(this.btn_start);
            this.panel_Controller.Controls.Add(this.pic_logo);
            this.panel_Controller.Location = new System.Drawing.Point(12, 12);
            this.panel_Controller.Name = "panel_Controller";
            this.panel_Controller.Size = new System.Drawing.Size(421, 649);
            this.panel_Controller.TabIndex = 0;
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
            this.panel_LogText.Controls.Add(this.lb_progress_percentage);
            this.panel_LogText.Controls.Add(this.lb_progress);
            this.panel_LogText.Controls.Add(this.lb_logText);
            this.panel_LogText.Controls.Add(this.btn_setting);
            this.panel_LogText.Controls.Add(this.btn_support);
            this.panel_LogText.Controls.Add(this.pgb_backgroundWorkerProgressBar);
            this.panel_LogText.Controls.Add(this.rtb_logText);
            this.panel_LogText.Controls.Add(this.pic_title);
            this.panel_LogText.Location = new System.Drawing.Point(439, 12);
            this.panel_LogText.Name = "panel_LogText";
            this.panel_LogText.Size = new System.Drawing.Size(811, 649);
            this.panel_LogText.TabIndex = 1;
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
            // lb_progress
            // 
            this.lb_progress.AutoSize = true;
            this.lb_progress.Font = new System.Drawing.Font("Century", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_progress.Location = new System.Drawing.Point(3, 584);
            this.lb_progress.Name = "lb_progress";
            this.lb_progress.Size = new System.Drawing.Size(55, 23);
            this.lb_progress.TabIndex = 5;
            this.lb_progress.Text = "Start";
            // 
            // lb_logText
            // 
            this.lb_logText.AutoSize = true;
            this.lb_logText.Font = new System.Drawing.Font("Century", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_logText.Location = new System.Drawing.Point(3, 127);
            this.lb_logText.Name = "lb_logText";
            this.lb_logText.Size = new System.Drawing.Size(122, 23);
            this.lb_logText.TabIndex = 4;
            this.lb_logText.Text = "Log output : ";
            // 
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
            // rtb_logText
            // 
            this.rtb_logText.Enabled = false;
            this.rtb_logText.Location = new System.Drawing.Point(4, 156);
            this.rtb_logText.Name = "rtb_logText";
            this.rtb_logText.ReadOnly = true;
            this.rtb_logText.Size = new System.Drawing.Size(804, 425);
            this.rtb_logText.TabIndex = 1;
            this.rtb_logText.Text = "";
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
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.Location = new System.Drawing.Point(110, 160);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(160, 70);
            this.btn_start.TabIndex = 4;
            this.btn_start.Text = "START";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stop.Location = new System.Drawing.Point(110, 247);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(160, 70);
            this.btn_stop.TabIndex = 5;
            this.btn_stop.Text = "STOP";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).EndInit();
            this.panel_LogText.ResumeLayout(false);
            this.panel_LogText.PerformLayout();
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
        private System.Windows.Forms.Button btn_support;
        private System.Windows.Forms.RichTextBox rtb_logText;
        private System.Windows.Forms.Label lb_logText;
        private System.Windows.Forms.Label lb_progress_percentage;
        private System.Windows.Forms.Label lb_progress;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_start;
    }
}

