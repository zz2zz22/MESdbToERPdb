
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_checkMailCon = new System.Windows.Forms.Button();
            this.txb_password = new System.Windows.Forms.TextBox();
            this.txb_email = new System.Windows.Forms.TextBox();
            this.lb_mailPW = new System.Windows.Forms.Label();
            this.lb_username = new System.Windows.Forms.Label();
            this.lb_configMailTitle = new System.Windows.Forms.Label();
            this.btn_settingCancel = new System.Windows.Forms.Button();
            this.btn_settingSave = new System.Windows.Forms.Button();
            this.lb_listMail = new System.Windows.Forms.Label();
            this.btn_addEmail = new System.Windows.Forms.Button();
            this.btn_editEmail = new System.Windows.Forms.Button();
            this.btn_deleteEmail = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_languageConfig = new System.Windows.Forms.Label();
            this.btn_languageEnglish = new System.Windows.Forms.Button();
            this.btn_languageVietnam = new System.Windows.Forms.Button();
            this.pn_mail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.pn_mail.Controls.Add(this.btn_deleteEmail);
            this.pn_mail.Controls.Add(this.btn_editEmail);
            this.pn_mail.Controls.Add(this.btn_addEmail);
            this.pn_mail.Controls.Add(this.lb_listMail);
            this.pn_mail.Controls.Add(this.dataGridView1);
            this.pn_mail.Controls.Add(this.btn_checkMailCon);
            this.pn_mail.Controls.Add(this.txb_password);
            this.pn_mail.Controls.Add(this.txb_email);
            this.pn_mail.Controls.Add(this.lb_mailPW);
            this.pn_mail.Controls.Add(this.lb_username);
            this.pn_mail.Controls.Add(this.lb_configMailTitle);
            this.pn_mail.Location = new System.Drawing.Point(806, 12);
            this.pn_mail.Name = "pn_mail";
            this.pn_mail.Size = new System.Drawing.Size(444, 457);
            this.pn_mail.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 137);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(309, 317);
            this.dataGridView1.TabIndex = 6;
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
            this.lb_mailPW.Location = new System.Drawing.Point(3, 76);
            this.lb_mailPW.Name = "lb_mailPW";
            this.lb_mailPW.Size = new System.Drawing.Size(79, 18);
            this.lb_mailPW.TabIndex = 2;
            this.lb_mailPW.Text = "Password:";
            // 
            // lb_username
            // 
            this.lb_username.AutoSize = true;
            this.lb_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_username.Location = new System.Drawing.Point(3, 42);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(53, 18);
            this.lb_username.TabIndex = 1;
            this.lb_username.Text = "Email: ";
            // 
            // lb_configMailTitle
            // 
            this.lb_configMailTitle.AutoSize = true;
            this.lb_configMailTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_configMailTitle.Location = new System.Drawing.Point(3, 10);
            this.lb_configMailTitle.Name = "lb_configMailTitle";
            this.lb_configMailTitle.Size = new System.Drawing.Size(239, 18);
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
            // lb_listMail
            // 
            this.lb_listMail.AutoSize = true;
            this.lb_listMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_listMail.Location = new System.Drawing.Point(3, 116);
            this.lb_listMail.Name = "lb_listMail";
            this.lb_listMail.Size = new System.Drawing.Size(112, 18);
            this.lb_listMail.TabIndex = 7;
            this.lb_listMail.Text = "List of receivers";
            // 
            // btn_addEmail
            // 
            this.btn_addEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addEmail.Location = new System.Drawing.Point(322, 137);
            this.btn_addEmail.Name = "btn_addEmail";
            this.btn_addEmail.Size = new System.Drawing.Size(119, 65);
            this.btn_addEmail.TabIndex = 8;
            this.btn_addEmail.Text = "ADD";
            this.btn_addEmail.UseVisualStyleBackColor = true;
            // 
            // btn_editEmail
            // 
            this.btn_editEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editEmail.Location = new System.Drawing.Point(321, 208);
            this.btn_editEmail.Name = "btn_editEmail";
            this.btn_editEmail.Size = new System.Drawing.Size(119, 65);
            this.btn_editEmail.TabIndex = 9;
            this.btn_editEmail.Text = "EDIT";
            this.btn_editEmail.UseVisualStyleBackColor = true;
            // 
            // btn_deleteEmail
            // 
            this.btn_deleteEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deleteEmail.Location = new System.Drawing.Point(321, 279);
            this.btn_deleteEmail.Name = "btn_deleteEmail";
            this.btn_deleteEmail.Size = new System.Drawing.Size(119, 65);
            this.btn_deleteEmail.TabIndex = 10;
            this.btn_deleteEmail.Text = "DELETE";
            this.btn_deleteEmail.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_languageVietnam);
            this.panel1.Controls.Add(this.btn_languageEnglish);
            this.panel1.Controls.Add(this.lb_languageConfig);
            this.panel1.Location = new System.Drawing.Point(806, 475);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 109);
            this.panel1.TabIndex = 3;
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
            // btn_languageEnglish
            // 
            this.btn_languageEnglish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_languageEnglish.Location = new System.Drawing.Point(29, 37);
            this.btn_languageEnglish.Name = "btn_languageEnglish";
            this.btn_languageEnglish.Size = new System.Drawing.Size(190, 51);
            this.btn_languageEnglish.TabIndex = 1;
            this.btn_languageEnglish.Text = "English";
            this.btn_languageEnglish.UseVisualStyleBackColor = true;
            this.btn_languageEnglish.Click += new System.EventHandler(this.btn_languageEnglish_Click);
            // 
            // btn_languageVietnam
            // 
            this.btn_languageVietnam.Enabled = false;
            this.btn_languageVietnam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_languageVietnam.Location = new System.Drawing.Point(225, 37);
            this.btn_languageVietnam.Name = "btn_languageVietnam";
            this.btn_languageVietnam.Size = new System.Drawing.Size(190, 51);
            this.btn_languageVietnam.TabIndex = 2;
            this.btn_languageVietnam.Text = "Vietnamese";
            this.btn_languageVietnam.UseVisualStyleBackColor = true;
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
            this.Text = "Setting";
            this.pn_mail.ResumeLayout(false);
            this.pn_mail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_deleteEmail;
        private System.Windows.Forms.Button btn_editEmail;
        private System.Windows.Forms.Button btn_addEmail;
        private System.Windows.Forms.Label lb_listMail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_languageConfig;
        private System.Windows.Forms.Button btn_languageVietnam;
        private System.Windows.Forms.Button btn_languageEnglish;
    }
}