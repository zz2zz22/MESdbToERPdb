
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
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_fixData)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgv_fixData
            // 
            this.dtgv_fixData.AllowUserToAddRows = false;
            this.dtgv_fixData.AllowUserToDeleteRows = false;
            this.dtgv_fixData.AllowUserToResizeColumns = false;
            this.dtgv_fixData.AllowUserToResizeRows = false;
            this.dtgv_fixData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgv_fixData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_fixData.Location = new System.Drawing.Point(12, 125);
            this.dtgv_fixData.Name = "dtgv_fixData";
            this.dtgv_fixData.ReadOnly = true;
            this.dtgv_fixData.RowHeadersWidth = 51;
            this.dtgv_fixData.RowTemplate.Height = 24;
            this.dtgv_fixData.Size = new System.Drawing.Size(1238, 536);
            this.dtgv_fixData.TabIndex = 0;
            // 
            // dtp_transDate
            // 
            this.dtp_transDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_transDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_transDate.Location = new System.Drawing.Point(17, 36);
            this.dtp_transDate.Name = "dtp_transDate";
            this.dtp_transDate.Size = new System.Drawing.Size(215, 22);
            this.dtp_transDate.TabIndex = 1;
            this.dtp_transDate.ValueChanged += new System.EventHandler(this.dtp_transDate_ValueChanged);
            // 
            // lb_errDatePicker
            // 
            this.lb_errDatePicker.AutoSize = true;
            this.lb_errDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_errDatePicker.Location = new System.Drawing.Point(13, 13);
            this.lb_errDatePicker.Name = "lb_errDatePicker";
            this.lb_errDatePicker.Size = new System.Drawing.Size(122, 20);
            this.lb_errDatePicker.TabIndex = 2;
            this.lb_errDatePicker.Text = "Choose a date:";
            // 
            // Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.lb_errDatePicker);
            this.Controls.Add(this.dtp_transDate);
            this.Controls.Add(this.dtgv_fixData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Error";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error check";
            this.Load += new System.EventHandler(this.Error_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_fixData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dtgv_fixData;
        private System.Windows.Forms.DateTimePicker dtp_transDate;
        private System.Windows.Forms.Label lb_errDatePicker;
    }
}