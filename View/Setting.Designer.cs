
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.pn_general = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txb_excelFilePath = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lb_sendMailIntervalUnit = new System.Windows.Forms.Label();
            this.nud_sendMailIntervalPicker = new System.Windows.Forms.NumericUpDown();
            this.lb_bgIntervalPicker = new System.Windows.Forms.Label();
            this.lb_sendMailInterval = new System.Windows.Forms.Label();
            this.nud_bgIntervalPicker = new System.Windows.Forms.NumericUpDown();
            this.lb_bgIntervalUnit = new System.Windows.Forms.Label();
            this.lb_excelFilePath = new System.Windows.Forms.Label();
            this.pn_mainSetting = new System.Windows.Forms.Panel();
            this.txb_produceCodeSearch = new System.Windows.Forms.TextBox();
            this.btn_deleteProduceCode = new System.Windows.Forms.Button();
            this.btn_addProduceCode = new System.Windows.Forms.Button();
            this.dtgv_produceCodeList = new System.Windows.Forms.DataGridView();
            this.lb_listProduceCodes = new System.Windows.Forms.Label();
            this.btn_saveProduceCodeConfig = new System.Windows.Forms.Button();
            this.lb_produceCodeConfig = new System.Windows.Forms.Label();
            this.txb_produceCodeConfig = new System.Windows.Forms.TextBox();
            this.lb_mainSettingWarning = new System.Windows.Forms.Label();
            this.pn_mailSetting = new System.Windows.Forms.Panel();
            this.btn_saveSender = new System.Windows.Forms.Button();
            this.txb_searchReceivers = new System.Windows.Forms.TextBox();
            this.btn_deleteAllReceiver = new System.Windows.Forms.Button();
            this.btn_saveReceiver = new System.Windows.Forms.Button();
            this.lb_receiverConfig = new System.Windows.Forms.Label();
            this.txb_receiverConfig = new System.Windows.Forms.TextBox();
            this.btn_deleteEmail = new System.Windows.Forms.Button();
            this.btn_addReceiver = new System.Windows.Forms.Button();
            this.lb_listMail = new System.Windows.Forms.Label();
            this.dtgv_receivers = new System.Windows.Forms.DataGridView();
            this.btn_editSender = new System.Windows.Forms.Button();
            this.txb_password = new System.Windows.Forms.TextBox();
            this.txb_email = new System.Windows.Forms.TextBox();
            this.lb_mailPW = new System.Windows.Forms.Label();
            this.lb_username = new System.Windows.Forms.Label();
            this.lb_configMailTitle = new System.Windows.Forms.Label();
            this.btn_settingCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_languageVietnam = new System.Windows.Forms.Button();
            this.btn_languageEnglish = new System.Windows.Forms.Button();
            this.lb_languageConfig = new System.Windows.Forms.Label();
            this.pn_general.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sendMailIntervalPicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_bgIntervalPicker)).BeginInit();
            this.pn_mainSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_produceCodeList)).BeginInit();
            this.pn_mailSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_receivers)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_general
            // 
            this.pn_general.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pn_general.Controls.Add(this.pictureBox1);
            this.pn_general.Controls.Add(this.txb_excelFilePath);
            this.pn_general.Controls.Add(this.panel3);
            this.pn_general.Controls.Add(this.lb_excelFilePath);
            this.pn_general.Controls.Add(this.pn_mainSetting);
            this.pn_general.Controls.Add(this.lb_mainSettingWarning);
            this.pn_general.Location = new System.Drawing.Point(12, 12);
            this.pn_general.Name = "pn_general";
            this.pn_general.Size = new System.Drawing.Size(788, 572);
            this.pn_general.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(374, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // txb_excelFilePath
            // 
            this.txb_excelFilePath.Location = new System.Drawing.Point(9, 521);
            this.txb_excelFilePath.Name = "txb_excelFilePath";
            this.txb_excelFilePath.Size = new System.Drawing.Size(566, 22);
            this.txb_excelFilePath.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.lb_sendMailIntervalUnit);
            this.panel3.Controls.Add(this.nud_sendMailIntervalPicker);
            this.panel3.Controls.Add(this.lb_bgIntervalPicker);
            this.panel3.Controls.Add(this.lb_sendMailInterval);
            this.panel3.Controls.Add(this.nud_bgIntervalPicker);
            this.panel3.Controls.Add(this.lb_bgIntervalUnit);
            this.panel3.Location = new System.Drawing.Point(3, 170);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(374, 311);
            this.panel3.TabIndex = 10;
            // 
            // lb_sendMailIntervalUnit
            // 
            this.lb_sendMailIntervalUnit.AutoSize = true;
            this.lb_sendMailIntervalUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sendMailIntervalUnit.Location = new System.Drawing.Point(135, 174);
            this.lb_sendMailIntervalUnit.Name = "lb_sendMailIntervalUnit";
            this.lb_sendMailIntervalUnit.Size = new System.Drawing.Size(46, 20);
            this.lb_sendMailIntervalUnit.TabIndex = 2;
            this.lb_sendMailIntervalUnit.Text = "hour";
            // 
            // nud_sendMailIntervalPicker
            // 
            this.nud_sendMailIntervalPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_sendMailIntervalPicker.Location = new System.Drawing.Point(10, 169);
            this.nud_sendMailIntervalPicker.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_sendMailIntervalPicker.Name = "nud_sendMailIntervalPicker";
            this.nud_sendMailIntervalPicker.Size = new System.Drawing.Size(119, 27);
            this.nud_sendMailIntervalPicker.TabIndex = 1;
            this.nud_sendMailIntervalPicker.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_sendMailIntervalPicker.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_sendMailIntervalPicker.ValueChanged += new System.EventHandler(this.nud_sendMailIntervalPicker_ValueChanged);
            // 
            // lb_bgIntervalPicker
            // 
            this.lb_bgIntervalPicker.AutoSize = true;
            this.lb_bgIntervalPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_bgIntervalPicker.Location = new System.Drawing.Point(6, 24);
            this.lb_bgIntervalPicker.Name = "lb_bgIntervalPicker";
            this.lb_bgIntervalPicker.Size = new System.Drawing.Size(196, 20);
            this.lb_bgIntervalPicker.TabIndex = 1;
            this.lb_bgIntervalPicker.Text = "Data fetching interval:";
            // 
            // lb_sendMailInterval
            // 
            this.lb_sendMailInterval.AutoSize = true;
            this.lb_sendMailInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sendMailInterval.Location = new System.Drawing.Point(6, 146);
            this.lb_sendMailInterval.Name = "lb_sendMailInterval";
            this.lb_sendMailInterval.Size = new System.Drawing.Size(166, 20);
            this.lb_sendMailInterval.TabIndex = 0;
            this.lb_sendMailInterval.Text = "Send mail interval:";
            // 
            // nud_bgIntervalPicker
            // 
            this.nud_bgIntervalPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_bgIntervalPicker.Location = new System.Drawing.Point(10, 51);
            this.nud_bgIntervalPicker.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_bgIntervalPicker.Name = "nud_bgIntervalPicker";
            this.nud_bgIntervalPicker.Size = new System.Drawing.Size(118, 27);
            this.nud_bgIntervalPicker.TabIndex = 2;
            this.nud_bgIntervalPicker.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_bgIntervalPicker.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_bgIntervalPicker.ValueChanged += new System.EventHandler(this.nud_bgIntervalPicker_ValueChanged);
            // 
            // lb_bgIntervalUnit
            // 
            this.lb_bgIntervalUnit.AutoSize = true;
            this.lb_bgIntervalUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_bgIntervalUnit.Location = new System.Drawing.Point(134, 53);
            this.lb_bgIntervalUnit.Name = "lb_bgIntervalUnit";
            this.lb_bgIntervalUnit.Size = new System.Drawing.Size(46, 20);
            this.lb_bgIntervalUnit.TabIndex = 3;
            this.lb_bgIntervalUnit.Text = "hour";
            // 
            // lb_excelFilePath
            // 
            this.lb_excelFilePath.AutoSize = true;
            this.lb_excelFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_excelFilePath.Location = new System.Drawing.Point(10, 498);
            this.lb_excelFilePath.Name = "lb_excelFilePath";
            this.lb_excelFilePath.Size = new System.Drawing.Size(247, 20);
            this.lb_excelFilePath.TabIndex = 3;
            this.lb_excelFilePath.Text = "Excel report export location:";
            // 
            // pn_mainSetting
            // 
            this.pn_mainSetting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pn_mainSetting.Controls.Add(this.txb_produceCodeSearch);
            this.pn_mainSetting.Controls.Add(this.btn_deleteProduceCode);
            this.pn_mainSetting.Controls.Add(this.btn_addProduceCode);
            this.pn_mainSetting.Controls.Add(this.dtgv_produceCodeList);
            this.pn_mainSetting.Controls.Add(this.lb_listProduceCodes);
            this.pn_mainSetting.Controls.Add(this.btn_saveProduceCodeConfig);
            this.pn_mainSetting.Controls.Add(this.lb_produceCodeConfig);
            this.pn_mainSetting.Controls.Add(this.txb_produceCodeConfig);
            this.pn_mainSetting.Location = new System.Drawing.Point(383, 3);
            this.pn_mainSetting.Name = "pn_mainSetting";
            this.pn_mainSetting.Size = new System.Drawing.Size(400, 478);
            this.pn_mainSetting.TabIndex = 9;
            // 
            // txb_produceCodeSearch
            // 
            this.txb_produceCodeSearch.Location = new System.Drawing.Point(4, 129);
            this.txb_produceCodeSearch.Name = "txb_produceCodeSearch";
            this.txb_produceCodeSearch.Size = new System.Drawing.Size(249, 22);
            this.txb_produceCodeSearch.TabIndex = 11;
            // 
            // btn_deleteProduceCode
            // 
            this.btn_deleteProduceCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deleteProduceCode.Location = new System.Drawing.Point(267, 217);
            this.btn_deleteProduceCode.Name = "btn_deleteProduceCode";
            this.btn_deleteProduceCode.Size = new System.Drawing.Size(125, 54);
            this.btn_deleteProduceCode.TabIndex = 10;
            this.btn_deleteProduceCode.Text = "DELETE";
            this.btn_deleteProduceCode.UseVisualStyleBackColor = true;
            // 
            // btn_addProduceCode
            // 
            this.btn_addProduceCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addProduceCode.Location = new System.Drawing.Point(268, 157);
            this.btn_addProduceCode.Name = "btn_addProduceCode";
            this.btn_addProduceCode.Size = new System.Drawing.Size(124, 54);
            this.btn_addProduceCode.TabIndex = 9;
            this.btn_addProduceCode.Text = "ADD";
            this.btn_addProduceCode.UseVisualStyleBackColor = true;
            // 
            // dtgv_produceCodeList
            // 
            this.dtgv_produceCodeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_produceCodeList.Location = new System.Drawing.Point(3, 157);
            this.dtgv_produceCodeList.Name = "dtgv_produceCodeList";
            this.dtgv_produceCodeList.RowHeadersWidth = 51;
            this.dtgv_produceCodeList.RowTemplate.Height = 24;
            this.dtgv_produceCodeList.Size = new System.Drawing.Size(250, 316);
            this.dtgv_produceCodeList.TabIndex = 8;
            // 
            // lb_listProduceCodes
            // 
            this.lb_listProduceCodes.AutoSize = true;
            this.lb_listProduceCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_listProduceCodes.Location = new System.Drawing.Point(-1, 103);
            this.lb_listProduceCodes.Name = "lb_listProduceCodes";
            this.lb_listProduceCodes.Size = new System.Drawing.Size(261, 20);
            this.lb_listProduceCodes.TabIndex = 7;
            this.lb_listProduceCodes.Text = "List of produce code headers:";
            // 
            // btn_saveProduceCodeConfig
            // 
            this.btn_saveProduceCodeConfig.BackColor = System.Drawing.Color.OldLace;
            this.btn_saveProduceCodeConfig.Enabled = false;
            this.btn_saveProduceCodeConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_saveProduceCodeConfig.Location = new System.Drawing.Point(267, 28);
            this.btn_saveProduceCodeConfig.Name = "btn_saveProduceCodeConfig";
            this.btn_saveProduceCodeConfig.Size = new System.Drawing.Size(125, 50);
            this.btn_saveProduceCodeConfig.TabIndex = 6;
            this.btn_saveProduceCodeConfig.Text = "SAVE";
            this.btn_saveProduceCodeConfig.UseVisualStyleBackColor = false;
            // 
            // lb_produceCodeConfig
            // 
            this.lb_produceCodeConfig.AutoSize = true;
            this.lb_produceCodeConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_produceCodeConfig.Location = new System.Drawing.Point(3, 28);
            this.lb_produceCodeConfig.Name = "lb_produceCodeConfig";
            this.lb_produceCodeConfig.Size = new System.Drawing.Size(193, 20);
            this.lb_produceCodeConfig.TabIndex = 4;
            this.lb_produceCodeConfig.Text = "Produce code header:";
            // 
            // txb_produceCodeConfig
            // 
            this.txb_produceCodeConfig.Enabled = false;
            this.txb_produceCodeConfig.Location = new System.Drawing.Point(3, 51);
            this.txb_produceCodeConfig.Name = "txb_produceCodeConfig";
            this.txb_produceCodeConfig.Size = new System.Drawing.Size(254, 22);
            this.txb_produceCodeConfig.TabIndex = 5;
            // 
            // lb_mainSettingWarning
            // 
            this.lb_mainSettingWarning.AutoSize = true;
            this.lb_mainSettingWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_mainSettingWarning.ForeColor = System.Drawing.Color.Red;
            this.lb_mainSettingWarning.Location = new System.Drawing.Point(5, 107);
            this.lb_mainSettingWarning.Name = "lb_mainSettingWarning";
            this.lb_mainSettingWarning.Size = new System.Drawing.Size(330, 60);
            this.lb_mainSettingWarning.TabIndex = 0;
            this.lb_mainSettingWarning.Text = "Settings in \"bold\" style can ONLY be \r\nconfig before started or after stopped \r\nt" +
    "he program!";
            // 
            // pn_mailSetting
            // 
            this.pn_mailSetting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pn_mailSetting.Controls.Add(this.btn_saveSender);
            this.pn_mailSetting.Controls.Add(this.txb_searchReceivers);
            this.pn_mailSetting.Controls.Add(this.btn_deleteAllReceiver);
            this.pn_mailSetting.Controls.Add(this.btn_saveReceiver);
            this.pn_mailSetting.Controls.Add(this.lb_receiverConfig);
            this.pn_mailSetting.Controls.Add(this.txb_receiverConfig);
            this.pn_mailSetting.Controls.Add(this.btn_deleteEmail);
            this.pn_mailSetting.Controls.Add(this.btn_addReceiver);
            this.pn_mailSetting.Controls.Add(this.lb_listMail);
            this.pn_mailSetting.Controls.Add(this.dtgv_receivers);
            this.pn_mailSetting.Controls.Add(this.btn_editSender);
            this.pn_mailSetting.Controls.Add(this.txb_password);
            this.pn_mailSetting.Controls.Add(this.txb_email);
            this.pn_mailSetting.Controls.Add(this.lb_mailPW);
            this.pn_mailSetting.Controls.Add(this.lb_username);
            this.pn_mailSetting.Controls.Add(this.lb_configMailTitle);
            this.pn_mailSetting.Location = new System.Drawing.Point(806, 12);
            this.pn_mailSetting.Name = "pn_mailSetting";
            this.pn_mailSetting.Size = new System.Drawing.Size(444, 572);
            this.pn_mailSetting.TabIndex = 1;
            // 
            // btn_saveSender
            // 
            this.btn_saveSender.BackColor = System.Drawing.Color.OldLace;
            this.btn_saveSender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_saveSender.Location = new System.Drawing.Point(338, 33);
            this.btn_saveSender.Name = "btn_saveSender";
            this.btn_saveSender.Size = new System.Drawing.Size(99, 38);
            this.btn_saveSender.TabIndex = 16;
            this.btn_saveSender.Text = "SAVE";
            this.btn_saveSender.UseVisualStyleBackColor = false;
            this.btn_saveSender.Click += new System.EventHandler(this.btn_saveSender_Click);
            // 
            // txb_searchReceivers
            // 
            this.txb_searchReceivers.Location = new System.Drawing.Point(6, 252);
            this.txb_searchReceivers.Name = "txb_searchReceivers";
            this.txb_searchReceivers.Size = new System.Drawing.Size(308, 22);
            this.txb_searchReceivers.TabIndex = 15;
            this.txb_searchReceivers.TextChanged += new System.EventHandler(this.txb_searchReceivers_TextChanged);
            // 
            // btn_deleteAllReceiver
            // 
            this.btn_deleteAllReceiver.BackColor = System.Drawing.Color.Red;
            this.btn_deleteAllReceiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deleteAllReceiver.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_deleteAllReceiver.Location = new System.Drawing.Point(318, 493);
            this.btn_deleteAllReceiver.Name = "btn_deleteAllReceiver";
            this.btn_deleteAllReceiver.Size = new System.Drawing.Size(119, 72);
            this.btn_deleteAllReceiver.TabIndex = 14;
            this.btn_deleteAllReceiver.Text = "DELETE ALL";
            this.btn_deleteAllReceiver.UseVisualStyleBackColor = false;
            this.btn_deleteAllReceiver.Click += new System.EventHandler(this.btn_deleteAllReceiver_Click);
            // 
            // btn_saveReceiver
            // 
            this.btn_saveReceiver.BackColor = System.Drawing.Color.OldLace;
            this.btn_saveReceiver.Enabled = false;
            this.btn_saveReceiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_saveReceiver.Location = new System.Drawing.Point(318, 158);
            this.btn_saveReceiver.Name = "btn_saveReceiver";
            this.btn_saveReceiver.Size = new System.Drawing.Size(119, 45);
            this.btn_saveReceiver.TabIndex = 13;
            this.btn_saveReceiver.Text = "SAVE";
            this.btn_saveReceiver.UseVisualStyleBackColor = false;
            this.btn_saveReceiver.Click += new System.EventHandler(this.btn_saveReceiver_Click);
            // 
            // lb_receiverConfig
            // 
            this.lb_receiverConfig.AutoSize = true;
            this.lb_receiverConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_receiverConfig.Location = new System.Drawing.Point(2, 151);
            this.lb_receiverConfig.Name = "lb_receiverConfig";
            this.lb_receiverConfig.Size = new System.Drawing.Size(80, 20);
            this.lb_receiverConfig.TabIndex = 12;
            this.lb_receiverConfig.Text = "Receiver:";
            // 
            // txb_receiverConfig
            // 
            this.txb_receiverConfig.Enabled = false;
            this.txb_receiverConfig.Location = new System.Drawing.Point(6, 181);
            this.txb_receiverConfig.Name = "txb_receiverConfig";
            this.txb_receiverConfig.Size = new System.Drawing.Size(295, 22);
            this.txb_receiverConfig.TabIndex = 11;
            // 
            // btn_deleteEmail
            // 
            this.btn_deleteEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deleteEmail.Location = new System.Drawing.Point(318, 346);
            this.btn_deleteEmail.Name = "btn_deleteEmail";
            this.btn_deleteEmail.Size = new System.Drawing.Size(119, 54);
            this.btn_deleteEmail.TabIndex = 10;
            this.btn_deleteEmail.Text = "DELETE";
            this.btn_deleteEmail.UseVisualStyleBackColor = true;
            this.btn_deleteEmail.Click += new System.EventHandler(this.btn_deleteEmail_Click);
            // 
            // btn_addReceiver
            // 
            this.btn_addReceiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addReceiver.Location = new System.Drawing.Point(318, 284);
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
            this.lb_listMail.Location = new System.Drawing.Point(2, 229);
            this.lb_listMail.Name = "lb_listMail";
            this.lb_listMail.Size = new System.Drawing.Size(135, 20);
            this.lb_listMail.TabIndex = 7;
            this.lb_listMail.Text = "List of receivers:";
            // 
            // dtgv_receivers
            // 
            this.dtgv_receivers.AllowUserToAddRows = false;
            this.dtgv_receivers.AllowUserToDeleteRows = false;
            this.dtgv_receivers.AllowUserToResizeColumns = false;
            this.dtgv_receivers.AllowUserToResizeRows = false;
            this.dtgv_receivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_receivers.Location = new System.Drawing.Point(6, 280);
            this.dtgv_receivers.Name = "dtgv_receivers";
            this.dtgv_receivers.ReadOnly = true;
            this.dtgv_receivers.RowHeadersWidth = 51;
            this.dtgv_receivers.RowTemplate.Height = 24;
            this.dtgv_receivers.Size = new System.Drawing.Size(309, 285);
            this.dtgv_receivers.TabIndex = 6;
            this.dtgv_receivers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_receivers_CellClick);
            // 
            // btn_editSender
            // 
            this.btn_editSender.BackColor = System.Drawing.Color.OldLace;
            this.btn_editSender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editSender.Location = new System.Drawing.Point(338, 72);
            this.btn_editSender.Name = "btn_editSender";
            this.btn_editSender.Size = new System.Drawing.Size(99, 38);
            this.btn_editSender.TabIndex = 5;
            this.btn_editSender.Text = "EDIT";
            this.btn_editSender.UseVisualStyleBackColor = false;
            this.btn_editSender.Click += new System.EventHandler(this.btn_editSender_Click);
            // 
            // txb_password
            // 
            this.txb_password.Location = new System.Drawing.Point(90, 81);
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
            this.lb_mailPW.Location = new System.Drawing.Point(5, 82);
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
            this.btn_settingCancel.Location = new System.Drawing.Point(1110, 601);
            this.btn_settingCancel.Name = "btn_settingCancel";
            this.btn_settingCancel.Size = new System.Drawing.Size(140, 60);
            this.btn_settingCancel.TabIndex = 0;
            this.btn_settingCancel.Text = "CANCEL";
            this.btn_settingCancel.UseVisualStyleBackColor = true;
            this.btn_settingCancel.Click += new System.EventHandler(this.btn_settingCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btn_languageVietnam);
            this.panel1.Controls.Add(this.btn_languageEnglish);
            this.panel1.Controls.Add(this.lb_languageConfig);
            this.panel1.Location = new System.Drawing.Point(12, 590);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 79);
            this.panel1.TabIndex = 3;
            // 
            // btn_languageVietnam
            // 
            this.btn_languageVietnam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_languageVietnam.Location = new System.Drawing.Point(230, 25);
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
            this.btn_languageEnglish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_languageEnglish.Location = new System.Drawing.Point(26, 25);
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
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.btn_settingCancel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pn_mailSetting);
            this.Controls.Add(this.pn_general);
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.pn_general.ResumeLayout(false);
            this.pn_general.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sendMailIntervalPicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_bgIntervalPicker)).EndInit();
            this.pn_mainSetting.ResumeLayout(false);
            this.pn_mainSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_produceCodeList)).EndInit();
            this.pn_mailSetting.ResumeLayout(false);
            this.pn_mailSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_receivers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_general;
        private System.Windows.Forms.Panel pn_mailSetting;
        private System.Windows.Forms.Button btn_editSender;
        private System.Windows.Forms.TextBox txb_password;
        private System.Windows.Forms.TextBox txb_email;
        private System.Windows.Forms.Label lb_mailPW;
        private System.Windows.Forms.Label lb_username;
        private System.Windows.Forms.Label lb_configMailTitle;
        private System.Windows.Forms.Button btn_settingCancel;
        public System.Windows.Forms.DataGridView dtgv_receivers;
        private System.Windows.Forms.Button btn_deleteEmail;
        private System.Windows.Forms.Button btn_addReceiver;
        private System.Windows.Forms.Label lb_listMail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_languageConfig;
        private System.Windows.Forms.Button btn_languageVietnam;
        private System.Windows.Forms.Button btn_languageEnglish;
        private System.Windows.Forms.Label lb_receiverConfig;
        private System.Windows.Forms.TextBox txb_receiverConfig;
        private System.Windows.Forms.Button btn_saveReceiver;
        private System.Windows.Forms.Button btn_deleteAllReceiver;
        private System.Windows.Forms.Label lb_bgIntervalPicker;
        private System.Windows.Forms.Label lb_mainSettingWarning;
        private System.Windows.Forms.Label lb_bgIntervalUnit;
        private System.Windows.Forms.NumericUpDown nud_bgIntervalPicker;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pn_mainSetting;
        private System.Windows.Forms.Button btn_deleteProduceCode;
        private System.Windows.Forms.Button btn_addProduceCode;
        private System.Windows.Forms.DataGridView dtgv_produceCodeList;
        private System.Windows.Forms.Label lb_listProduceCodes;
        private System.Windows.Forms.Button btn_saveProduceCodeConfig;
        private System.Windows.Forms.Label lb_produceCodeConfig;
        private System.Windows.Forms.TextBox txb_produceCodeConfig;
        private System.Windows.Forms.Label lb_sendMailIntervalUnit;
        private System.Windows.Forms.NumericUpDown nud_sendMailIntervalPicker;
        private System.Windows.Forms.Label lb_sendMailInterval;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txb_excelFilePath;
        private System.Windows.Forms.Label lb_excelFilePath;
        private System.Windows.Forms.TextBox txb_produceCodeSearch;
        private System.Windows.Forms.TextBox txb_searchReceivers;
        private System.Windows.Forms.Button btn_saveSender;
    }
}