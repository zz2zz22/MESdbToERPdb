﻿
namespace MESdbToERPdb.View
{
    partial class Error
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Error));
            this.dtgv_fixData = new System.Windows.Forms.DataGridView();
            this.dtp_transDate = new System.Windows.Forms.DateTimePicker();
            this.lb_errDatePicker = new System.Windows.Forms.Label();
            this.btn_errorDateSearch = new System.Windows.Forms.Button();
            this.dtp_timeStart = new System.Windows.Forms.DateTimePicker();
            this.lb_pickTimeStart = new System.Windows.Forms.Label();
            this.dtp_timeEnd = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_pickTimeEnd = new System.Windows.Forms.Label();
            this.btn_startTransfer = new System.Windows.Forms.Button();
            this.pgb_transferError = new System.Windows.Forms.ProgressBar();
            this.cbox_deleteStatus = new System.Windows.Forms.ComboBox();
            this.btn_deleteAllStatus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_fixData)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgv_fixData
            // 
            this.dtgv_fixData.AllowUserToAddRows = false;
            this.dtgv_fixData.AllowUserToDeleteRows = false;
            this.dtgv_fixData.AllowUserToResizeRows = false;
            this.dtgv_fixData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_fixData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgv_fixData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_fixData.Location = new System.Drawing.Point(12, 142);
            this.dtgv_fixData.Name = "dtgv_fixData";
            this.dtgv_fixData.ReadOnly = true;
            this.dtgv_fixData.RowHeadersWidth = 51;
            this.dtgv_fixData.RowTemplate.Height = 24;
            this.dtgv_fixData.Size = new System.Drawing.Size(1238, 445);
            this.dtgv_fixData.TabIndex = 0;
            // 
            // dtp_transDate
            // 
            this.dtp_transDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_transDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_transDate.Location = new System.Drawing.Point(13, 31);
            this.dtp_transDate.Name = "dtp_transDate";
            this.dtp_transDate.Size = new System.Drawing.Size(215, 22);
            this.dtp_transDate.TabIndex = 1;
            this.dtp_transDate.ValueChanged += new System.EventHandler(this.dtp_transDate_ValueChanged);
            // 
            // lb_errDatePicker
            // 
            this.lb_errDatePicker.AutoSize = true;
            this.lb_errDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_errDatePicker.Location = new System.Drawing.Point(9, 8);
            this.lb_errDatePicker.Name = "lb_errDatePicker";
            this.lb_errDatePicker.Size = new System.Drawing.Size(122, 20);
            this.lb_errDatePicker.TabIndex = 2;
            this.lb_errDatePicker.Text = "Choose a date:";
            // 
            // btn_errorDateSearch
            // 
            this.btn_errorDateSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_errorDateSearch.Location = new System.Drawing.Point(503, 31);
            this.btn_errorDateSearch.Name = "btn_errorDateSearch";
            this.btn_errorDateSearch.Size = new System.Drawing.Size(215, 68);
            this.btn_errorDateSearch.TabIndex = 3;
            this.btn_errorDateSearch.Text = "Search";
            this.btn_errorDateSearch.UseVisualStyleBackColor = true;
            this.btn_errorDateSearch.Click += new System.EventHandler(this.btn_errorDateSearch_Click);
            // 
            // dtp_timeStart
            // 
            this.dtp_timeStart.CustomFormat = "HH:mm:ss";
            this.dtp_timeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_timeStart.Location = new System.Drawing.Point(51, 95);
            this.dtp_timeStart.Name = "dtp_timeStart";
            this.dtp_timeStart.ShowUpDown = true;
            this.dtp_timeStart.Size = new System.Drawing.Size(157, 22);
            this.dtp_timeStart.TabIndex = 5;
            this.dtp_timeStart.ValueChanged += new System.EventHandler(this.dtp_timeStart_ValueChanged);
            // 
            // lb_pickTimeStart
            // 
            this.lb_pickTimeStart.AutoSize = true;
            this.lb_pickTimeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pickTimeStart.Location = new System.Drawing.Point(14, 72);
            this.lb_pickTimeStart.Name = "lb_pickTimeStart";
            this.lb_pickTimeStart.Size = new System.Drawing.Size(53, 20);
            this.lb_pickTimeStart.TabIndex = 6;
            this.lb_pickTimeStart.Text = "From:";
            // 
            // dtp_timeEnd
            // 
            this.dtp_timeEnd.CustomFormat = "HH:mm:ss";
            this.dtp_timeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_timeEnd.Location = new System.Drawing.Point(267, 95);
            this.dtp_timeEnd.Name = "dtp_timeEnd";
            this.dtp_timeEnd.ShowUpDown = true;
            this.dtp_timeEnd.Size = new System.Drawing.Size(157, 22);
            this.dtp_timeEnd.TabIndex = 7;
            this.dtp_timeEnd.ValueChanged += new System.EventHandler(this.dtp_timeEnd_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lb_pickTimeEnd);
            this.panel1.Controls.Add(this.lb_errDatePicker);
            this.panel1.Controls.Add(this.dtp_timeEnd);
            this.panel1.Controls.Add(this.dtp_transDate);
            this.panel1.Controls.Add(this.lb_pickTimeStart);
            this.panel1.Controls.Add(this.btn_errorDateSearch);
            this.panel1.Controls.Add(this.dtp_timeStart);
            this.panel1.Location = new System.Drawing.Point(12, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 129);
            this.panel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(241, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "<";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = ">=";
            // 
            // lb_pickTimeEnd
            // 
            this.lb_pickTimeEnd.AutoSize = true;
            this.lb_pickTimeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pickTimeEnd.Location = new System.Drawing.Point(232, 72);
            this.lb_pickTimeEnd.Name = "lb_pickTimeEnd";
            this.lb_pickTimeEnd.Size = new System.Drawing.Size(33, 20);
            this.lb_pickTimeEnd.TabIndex = 8;
            this.lb_pickTimeEnd.Text = "To:";
            // 
            // btn_startTransfer
            // 
            this.btn_startTransfer.BackColor = System.Drawing.Color.Yellow;
            this.btn_startTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_startTransfer.Location = new System.Drawing.Point(926, 11);
            this.btn_startTransfer.Name = "btn_startTransfer";
            this.btn_startTransfer.Size = new System.Drawing.Size(211, 81);
            this.btn_startTransfer.TabIndex = 9;
            this.btn_startTransfer.Text = "TRANSFER ERROR CODE";
            this.btn_startTransfer.UseVisualStyleBackColor = false;
            this.btn_startTransfer.Click += new System.EventHandler(this.btn_startTransfer_Click);
            // 
            // pgb_transferError
            // 
            this.pgb_transferError.Location = new System.Drawing.Point(790, 102);
            this.pgb_transferError.Name = "pgb_transferError";
            this.pgb_transferError.Size = new System.Drawing.Size(460, 34);
            this.pgb_transferError.TabIndex = 10;
            // 
            // cbox_deleteStatus
            // 
            this.cbox_deleteStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_deleteStatus.FormattingEnabled = true;
            this.cbox_deleteStatus.Items.AddRange(new object[] {
            "Không thể tạo phiếu do SFCTA036 > SFCTA010 - SFCTA011 - SFCTA012.",
            "Không thể tạo phiếu do thiếu dữ liệu mã quy trình 0020: ",
            "Không thể tạo phiếu do SFCTA010 lớn hơn hoặc bằng MOCTA015.",
            "Không thể tạo phiếu D101 do thiếu dữ liệu ở bảng SFCTA hoặc MOCTA",
            "Không thể tạo phiếu D201 do thiếu dữ liệu ở bảng SFCTA hoặc MOCTA.",
            "Không thể tạo phiếu! Lỗi không xác định! Xem file log để biết thêm chi tiết!"});
            this.cbox_deleteStatus.Location = new System.Drawing.Point(384, 614);
            this.cbox_deleteStatus.Name = "cbox_deleteStatus";
            this.cbox_deleteStatus.Size = new System.Drawing.Size(582, 28);
            this.cbox_deleteStatus.TabIndex = 11;
            // 
            // btn_deleteAllStatus
            // 
            this.btn_deleteAllStatus.BackColor = System.Drawing.Color.Red;
            this.btn_deleteAllStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deleteAllStatus.ForeColor = System.Drawing.Color.Yellow;
            this.btn_deleteAllStatus.Location = new System.Drawing.Point(972, 593);
            this.btn_deleteAllStatus.Name = "btn_deleteAllStatus";
            this.btn_deleteAllStatus.Size = new System.Drawing.Size(279, 68);
            this.btn_deleteAllStatus.TabIndex = 12;
            this.btn_deleteAllStatus.Text = "DELETE STATUS";
            this.btn_deleteAllStatus.UseVisualStyleBackColor = false;
            this.btn_deleteAllStatus.Click += new System.EventHandler(this.btn_deleteAllStatus_Click);
            // 
            // Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.btn_deleteAllStatus);
            this.Controls.Add(this.cbox_deleteStatus);
            this.Controls.Add(this.pgb_transferError);
            this.Controls.Add(this.btn_startTransfer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtgv_fixData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Error";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error check";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Error_FormClosed);
            this.Load += new System.EventHandler(this.Error_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_fixData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dtgv_fixData;
        private System.Windows.Forms.DateTimePicker dtp_transDate;
        private System.Windows.Forms.Label lb_errDatePicker;
        private System.Windows.Forms.Button btn_errorDateSearch;
        private System.Windows.Forms.DateTimePicker dtp_timeStart;
        private System.Windows.Forms.Label lb_pickTimeStart;
        private System.Windows.Forms.DateTimePicker dtp_timeEnd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_pickTimeEnd;
        private System.Windows.Forms.Button btn_startTransfer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pgb_transferError;
        private System.Windows.Forms.ComboBox cbox_deleteStatus;
        private System.Windows.Forms.Button btn_deleteAllStatus;
    }
}