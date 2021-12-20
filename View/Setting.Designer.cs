
namespace MESdbToERPdb.View
{
    partial class Setting
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
            this.pn_general = new System.Windows.Forms.Panel();
            this.pn_mail = new System.Windows.Forms.Panel();
            this.btn_saveReceiver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_receiverConfig = new System.Windows.Forms.TextBox();
            this.btn_deleteEmail = new System.Windows.Forms.Button();
            this.btn_addReceiver = new System.Windows.Forms.Button();
            this.lb_listMail = new System.Windows.Forms.Label();
            this.dtgv_receivers = new System.Windows.Forms.DataGridView();
            this.btn_checkMailCon = new System.Windows.Forms.Button();
            this.txb_password = new System.Windows.Forms.TextBox();
            this.txb_email = new System.Windows.Forms.TextBox();
            this.lb_mailPW = new System.Windows.Forms.Label();
            this.lb_username = new System.Windows.Forms.Label();
            this.lb_configMailTitle = new System.Windows.Forms.Label();
            this.btn_settingCancel = new System.Windows.Forms.Button();
            this.btn_settingSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_languageVietnam = new System.Windows.Forms.Button();
            this.btn_languageEnglish = new System.Windows.Forms.Button();
            this.lb_languageConfig = new System.Windows.Forms.Label();
            this.btn_deleteAllReceiver = new System.Windows.Forms.Button();
            this.pn_mail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_receivers)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_general
            // 
            this.pn_general.Location = new System.Drawing.Point(12, 12);
            this.pn_general.Name = "pn_general";
            this.pn_general.Size = new System.Drawing.Size(788, 572);
            this.pn_general.TabIndex = 0;
            // 
            // pn_mail
            // 
            this.pn_mail.Controls.Add(this.btn_deleteAllReceiver);
            this.pn_mail.Controls.Add(this.btn_saveReceiver);
            this.pn_mail.Controls.Add(this.label1);
            this.pn_mail.Controls.Add(this.txb_receiverConfig);
            this.pn_mail.Controls.Add(this.btn_deleteEmail);
            this.pn_mail.Controls.Add(this.btn_addReceiver);
            this.pn_mail.Controls.Add(this.lb_listMail);
            this.pn_mail.Controls.Add(this.dtgv_receivers);
            this.pn_mail.Controls.Add(this.btn_checkMailCon);
            this.pn_mail.Controls.Add(this.txb_password);
            this.pn_mail.Controls.Add(this.txb_email);
            this.pn_mail.Controls.Add(this.lb_mailPW);
            this.pn_mail.Controls.Add(this.lb_username);
            this.pn_mail.Controls.Add(this.lb_configMailTitle);
            this.pn_mail.Location = new System.Drawing.Point(806, 12);
            this.pn_mail.Name = "pn_mail";
            this.pn_mail.Size = new System.Drawing.Size(444, 572);
            this.pn_mail.TabIndex = 1;
            // 
            // btn_saveReceiver
            // 
            this.btn_saveReceiver.BackColor = System.Drawing.Color.OldLace;
            this.btn_saveReceiver.Enabled = false;
            this.btn_saveReceiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_saveReceiver.Location = new System.Drawing.Point(321, 119);
            this.btn_saveReceiver.Name = "btn_saveReceiver";
            this.btn_saveReceiver.Size = new System.Drawing.Size(119, 45);
            this.btn_saveReceiver.TabIndex = 13;
            this.btn_saveReceiver.Text = "SAVE";
            this.btn_saveReceiver.UseVisualStyleBackColor = false;
            this.btn_saveReceiver.Click += new System.EventHandler(this.btn_saveReceiver_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Receiver:";
            // 
            // txb_receiverConfig
            // 
            this.txb_receiverConfig.Enabled = false;
            this.txb_receiverConfig.Location = new System.Drawing.Point(3, 142);
            this.txb_receiverConfig.Name = "txb_receiverConfig";
            this.txb_receiverConfig.Size = new System.Drawing.Size(295, 22);
            this.txb_receiverConfig.TabIndex = 11;
            // 
            // btn_deleteEmail
            // 
            this.btn_deleteEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deleteEmail.Location = new System.Drawing.Point(318, 269);
            this.btn_deleteEmail.Name = "btn_deleteEmail";
            this.btn_deleteEmail.Size = new System.Drawing.Size(119, 54);
            this.btn_deleteEmail.TabIndex = 10;
            this.btn_deleteEmail.Text = "DELETE";
            this.btn_deleteEmail.UseVisualStyleBackColor = true;
            this.btn_deleteEmail.Click += new System.EventHandler(this.btn_deleteEmail_Click);
            // 
            // btn_addReceiver
            // 
            this.btn_addReceiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addReceiver.Location = new System.Drawing.Point(318, 209);
            this.btn_addReceiver.Name = "btn_addReceiver";
            this.btn_addReceiver.Size = new System.Drawing.Size(119, 54);
            this.btn_addReceiver.TabIndex = 8;
            this.btn_addReceiver.Text = "ADD";
            this.btn_addReceiver.UseVisualStyleBackColor = true;
            this.btn_addReceiver.Click += new System.EventHandler(this.btn_addReceiver_Click);
            // 
            // lb_listMail
            // 
            this.lb_listMail.AutoSize = true;
            this.lb_listMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_listMail.Location = new System.Drawing.Point(4, 186);
            this.lb_listMail.Name = "lb_listMail";
            this.lb_listMail.Size = new System.Drawing.Size(130, 20);
            this.lb_listMail.TabIndex = 7;
            this.lb_listMail.Text = "List of receivers";
            // 
            // dtgv_receivers
            // 
            this.dtgv_receivers.AllowUserToAddRows = false;
            this.dtgv_receivers.AllowUserToDeleteRows = false;
            this.dtgv_receivers.AllowUserToResizeColumns = false;
            this.dtgv_receivers.AllowUserToResizeRows = false;
            this.dtgv_receivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_receivers.Location = new System.Drawing.Point(3, 209);
            this.dtgv_receivers.Name = "dtgv_receivers";
            this.dtgv_receivers.ReadOnly = true;
            this.dtgv_receivers.RowHeadersWidth = 51;
            this.dtgv_receivers.RowTemplate.Height = 24;
            this.dtgv_receivers.Size = new System.Drawing.Size(309, 317);
            this.dtgv_receivers.TabIndex = 6;
            this.dtgv_receivers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_receivers_CellClick);
            // 
            // btn_checkMailCon
            // 
            this.btn_checkMailCon.BackColor = System.Drawing.Color.OldLace;
            this.btn_checkMailCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_checkMailCon.Location = new System.Drawing.Point(342, 42);
            this.btn_checkMailCon.Name = "btn_checkMailCon";
            this.btn_checkMailCon.Size = new System.Drawing.Size(99, 51);
            this.btn_checkMailCon.TabIndex = 5;
            this.btn_checkMailCon.Text = "CHECK";
            this.btn_checkMailCon.UseVisualStyleBackColor = false;
            this.btn_checkMailCon.Click += new System.EventHandler(this.button2_Click);
            // 
            // txb_password
            // 
            this.txb_password.Location = new System.Drawing.Point(90, 71);
            this.txb_password.Name = "txb_password";
            this.txb_password.Size = new System.Drawing.Size(246, 22);
            this.txb_password.TabIndex = 4;
            // 
            // txb_email
            // 
            this.txb_email.Location = new System.Drawing.Point(90, 42);
            this.txb_email.Name = "txb_email";
            this.txb_email.Size = new System.Drawing.Size(246, 22);
            this.txb_email.TabIndex = 3;
            // 
            // lb_mailPW
            // 
            this.lb_mailPW.AutoSize = true;
            this.lb_mailPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_mailPW.Location = new System.Drawing.Point(5, 72);
            this.lb_mailPW.Name = "lb_mailPW";
            this.lb_mailPW.Size = new System.Drawing.Size(79, 18);
            this.lb_mailPW.TabIndex = 2;
            this.lb_mailPW.Text = "Password:";
            // 
            // lb_username
            // 
            this.lb_username.AutoSize = true;
            this.lb_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_username.Location = new System.Drawing.Point(5, 43);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(53, 18);
            this.lb_username.TabIndex = 1;
            this.lb_username.Text = "Email: ";
            // 
            // lb_configMailTitle
            // 
            this.lb_configMailTitle.AutoSize = true;
            this.lb_configMailTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_configMailTitle.Location = new System.Drawing.Point(3, 10);
            this.lb_configMailTitle.Name = "lb_configMailTitle";
            this.lb_configMailTitle.Size = new System.Drawing.Size(273, 20);
            this.lb_configMailTitle.TabIndex = 0;
            this.lb_configMailTitle.Text = "Input sender\'s email and password:";
            // 
            // btn_settingCancel
            // 
            this.btn_settingCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_settingCancel.Location = new System.Drawing.Point(927, 601);
            this.btn_settingCancel.Name = "btn_settingCancel";
            this.btn_settingCancel.Size = new System.Drawing.Size(140, 60);
            this.btn_settingCancel.TabIndex = 0;
            this.btn_settingCancel.Text = "CANCEL";
            this.btn_settingCancel.UseVisualStyleBackColor = true;
            this.btn_settingCancel.Click += new System.EventHandler(this.btn_settingCancel_Click);
            // 
            // btn_settingSave
            // 
            this.btn_settingSave.BackColor = System.Drawing.SystemColors.Info;
            this.btn_settingSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_settingSave.Location = new System.Drawing.Point(1110, 601);
            this.btn_settingSave.Name = "btn_settingSave";
            this.btn_settingSave.Size = new System.Drawing.Size(140, 60);
            this.btn_settingSave.TabIndex = 2;
            this.btn_settingSave.Text = "SAVE";
            this.btn_settingSave.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_languageVietnam);
            this.panel1.Controls.Add(this.btn_languageEnglish);
            this.panel1.Controls.Add(this.lb_languageConfig);
            this.panel1.Location = new System.Drawing.Point(12, 590);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 71);
            this.panel1.TabIndex = 3;
            // 
            // btn_languageVietnam
            // 
            this.btn_languageVietnam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_languageVietnam.Location = new System.Drawing.Point(175, 25);
            this.btn_languageVietnam.Name = "btn_languageVietnam";
            this.btn_languageVietnam.Size = new System.Drawing.Size(160, 42);
            this.btn_languageVietnam.TabIndex = 2;
            this.btn_languageVietnam.Text = "Vietnamese";
            this.btn_languageVietnam.UseVisualStyleBackColor = true;
            this.btn_languageVietnam.Click += new System.EventHandler(this.btn_languageVietnam_Click);
            // 
            // btn_languageEnglish
            // 
            this.btn_languageEnglish.Enabled = false;
            this.btn_languageEnglish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_languageEnglish.Location = new System.Drawing.Point(9, 25);
            this.btn_languageEnglish.Name = "btn_languageEnglish";
            this.btn_languageEnglish.Size = new System.Drawing.Size(160, 42);
            this.btn_languageEnglish.TabIndex = 1;
            this.btn_languageEnglish.Text = "English";
            this.btn_languageEnglish.UseVisualStyleBackColor = true;
            this.btn_languageEnglish.Click += new System.EventHandler(this.btn_languageEnglish_Click);
            // 
            // lb_languageConfig
            // 
            this.lb_languageConfig.AutoSize = true;
            this.lb_languageConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_languageConfig.Location = new System.Drawing.Point(6, 4);
            this.lb_languageConfig.Name = "lb_languageConfig";
            this.lb_languageConfig.Size = new System.Drawing.Size(157, 18);
            this.lb_languageConfig.TabIndex = 0;
            this.lb_languageConfig.Text = "Choose your language";
            // 
            // btn_deleteAllReceiver
            // 
            this.btn_deleteAllReceiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deleteAllReceiver.Location = new System.Drawing.Point(318, 454);
            this.btn_deleteAllReceiver.Name = "btn_deleteAllReceiver";
            this.btn_deleteAllReceiver.Size = new System.Drawing.Size(119, 72);
            this.btn_deleteAllReceiver.TabIndex = 14;
            this.btn_deleteAllReceiver.Text = "DELETE ALL";
            this.btn_deleteAllReceiver.UseVisualStyleBackColor = true;
            this.btn_deleteAllReceiver.Click += new System.EventHandler(this.btn_deleteAllReceiver_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_settingSave);
            this.Controls.Add(this.btn_settingCancel);
            this.Controls.Add(this.pn_mail);
            this.Controls.Add(this.pn_general);
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.pn_mail.ResumeLayout(false);
            this.pn_mail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_receivers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_general;
        private System.Windows.Forms.Panel pn_mail;
        private System.Windows.Forms.Button btn_checkMailCon;
        private System.Windows.Forms.TextBox txb_password;
        private System.Windows.Forms.TextBox txb_email;
        private System.Windows.Forms.Label lb_mailPW;
        private System.Windows.Forms.Label lb_username;
        private System.Windows.Forms.Label lb_configMailTitle;
        private System.Windows.Forms.Button btn_settingCancel;
        private System.Windows.Forms.Button btn_settingSave;
        public System.Windows.Forms.DataGridView dtgv_receivers;
        private System.Windows.Forms.Button btn_deleteEmail;
        private System.Windows.Forms.Button btn_addReceiver;
        private System.Windows.Forms.Label lb_listMail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_languageConfig;
        private System.Windows.Forms.Button btn_languageVietnam;
        private System.Windows.Forms.Button btn_languageEnglish;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_receiverConfig;
        private System.Windows.Forms.Button btn_saveReceiver;
        private System.Windows.Forms.Button btn_deleteAllReceiver;
    }
}