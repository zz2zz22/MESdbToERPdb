using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MESdbToERPdb.View
{
    public partial class Setting : Form
    {
        Properties.Settings settings = new Properties.Settings();
        mes2ERPMainWin mainWin = new mes2ERPMainWin();
        
        public Setting()
        {
            InitializeComponent();
        }

        private void btn_editSender_Click(object sender, EventArgs e)
        {
            txb_email.Enabled = true;
            txb_password.Enabled = true;
        }
        private void btn_saveSender_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            if (settings.cfg_language == 1)
            {
                dialogResult = MessageBox.Show("Do you want to set this sender ?", "Confirmation", MessageBoxButtons.OKCancel);
            }
            else
            {
                dialogResult = MessageBox.Show("Bạn có muốn lưu người gửi này không ?", "Confirmation", MessageBoxButtons.OKCancel);
            }
            if (dialogResult == DialogResult.OK)
            {
                settings.cfg_senders = txb_email.Text;
                settings.cfg_senderPW = txb_password.Text;
                settings.Save();
                MessageBox.Show("Lưu người gửi thành công!");
            }
            txb_email.Enabled = false;
            txb_password.Enabled = false;
        }

        private void btn_languageEnglish_Click(object sender, EventArgs e)
        {
            settings.cfg_language = 1;
            settings.Save();
            ChangeLanguageToEnglish();
        }
        private void ChangeLanguageToEnglish()
        {
            btn_languageEnglish.Enabled = false;
            btn_languageVietnam.Enabled = true;
            btn_languageEnglish.Text = "English";
            btn_languageVietnam.Text = "Vietnamese";
            lb_receiverConfig.Text = "Receiver:";
            btn_saveReceiver.Text = "SAVE";
            lb_listMail.Text = "List of receivers:";
            lb_languageConfig.Text = "Choose your language";
            lb_configMailTitle.Text = "Input sender's email and password:";
            btn_editSender.Text = "SAVE";
            btn_addReceiver.Text = "ADD";
            btn_deleteEmail.Text = "DELETE";
            btn_deleteAllReceiver.Text = "DELETE ALL";
            lb_mainSettingWarning.Text = "Settings in \"bold\" style can ONLY be \nconfig before started or after stopped \nthe program!";
            lb_bgIntervalPicker.Text = "Data fetching interval:";
            lb_bgIntervalUnit.Text = "hour";
            lb_productionCodeConfig.Text = "Production code header:";
            btn_saveProductionCodeConfig.Text = "SAVE";
            lb_listProductionCodes.Text = "List of production code headers:";
            btn_addProductionCode.Text = "ADD";
            btn_deleteProductionCode.Text = "DELETE";
            btn_saveSender.Text = "SAVE";
            btn_editSender.Text = "EDIT";
            lb_sendMailInterval.Text = "Send mail interval:";
            lb_sendMailIntervalUnit.Text = "hour";
        }
        private void btn_languageVietnam_Click(object sender, EventArgs e)
        {
            settings.cfg_language = 0;
            settings.Save();
            ChangeLanguageToVietnamese();
        }
        private void ChangeLanguageToVietnamese()
        {
            btn_languageVietnam.Enabled = false;
            btn_languageEnglish.Enabled = true;
            btn_languageEnglish.Text = "Anh";
            btn_languageVietnam.Text = "Việt";
            lb_receiverConfig.Text = "Người nhận:";
            btn_saveReceiver.Text = "LƯU";
            lb_listMail.Text = "Danh sách người nhận:";
            lb_languageConfig.Text = "Chọn ngôn ngữ của bạn";
            lb_configMailTitle.Text = "Nhập vào địa chỉ email và password email của người gửi:";
            btn_editSender.Text = "LƯU";
            btn_addReceiver.Text = "THÊM";
            btn_deleteEmail.Text = "XÓA";
            btn_deleteAllReceiver.Text = "XÓA TẤT CẢ";
            lb_mainSettingWarning.Text = "Những cài đặt \"in đậm\" CHỈ chỉnh sửa \nđược trước khi bắt đầu hoặc sau khi \ndừng chương trình!";
            lb_bgIntervalPicker.Text = "Khoảng lấy dữ liệu:";
            lb_bgIntervalUnit.Text = "giờ";
            lb_productionCodeConfig.Text = "Đầu mã sản xuất:";
            btn_saveProductionCodeConfig.Text = "LƯU";
            lb_listProductionCodes.Text = "Danh sách các đầu mã:";
            btn_addProductionCode.Text = "THÊM";
            btn_deleteProductionCode.Text = "XÓA";
            btn_saveSender.Text = "LƯU";
            btn_editSender.Text = "SỬA";
            lb_sendMailInterval.Text = "Khoảng thời gian gửi mail:";
            lb_sendMailIntervalUnit.Text = "giờ";
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            if ( settings.cfg_receivers == "")
            {
                settings.cfg_receivers = null;
            }
            if (settings.cfg_language == 1)
            {
                ChangeLanguageToEnglish();
            }else if (settings.cfg_language == 0) {
                ChangeLanguageToVietnamese();
            }
            nud_bgIntervalPicker.Value = Convert.ToDecimal(settings.interval.ToString());
            nud_sendMailIntervalPicker.Value = Convert.ToDecimal(settings.intervalMail.ToString());
            txb_email.Text = settings.cfg_senders;
            txb_password.Text = settings.cfg_senderPW;
            txb_email.Enabled = false;
            txb_password.Enabled = false;
            
            LoadReceiverGrid();
            LoadProductionCodes();
        }
        
        public void LoadReceiverGrid()
        {
            if (settings.cfg_receivers == "")
            {
                settings.cfg_receivers = null;
            }
            this.dtgv_receivers.Rows.Clear();
            this.dtgv_receivers.Columns.Clear();
            string[] receivers;
            if (settings.cfg_receivers != null)
            {
                receivers = settings.cfg_receivers.Split('-');
            }
            else
            {
                receivers = null;
            }
            dtgv_receivers.RowHeadersVisible = false;
            dtgv_receivers.ColumnHeadersVisible = false;
            dtgv_receivers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            dtgv_receivers.Columns.Add("receiver", "Receivers");
            if ( receivers != null)
            {
                for (int i = 0; i < receivers.Length; i++)
                {
                    this.dtgv_receivers.Rows.Add(receivers[i]);
                }
            }
            this.dtgv_receivers.Sort(this.dtgv_receivers.Columns["receiver"], ListSortDirection.Ascending);
        }
        public void LoadProductionCodes()
        {
            if (settings.cfg_produceCodes == "")
            {
                settings.cfg_produceCodes = null;
            }
            dtgv_productionCodeList.Rows.Clear();
            dtgv_productionCodeList.Columns.Clear();
            string[] productionCode;
            if (settings.cfg_produceCodes != null)
            {
                productionCode = settings.cfg_produceCodes.Split('-');
            }
            else
            {
                productionCode = null;
            }
            dtgv_productionCodeList.RowHeadersVisible = false;
            dtgv_productionCodeList.ColumnHeadersVisible = false;
            dtgv_productionCodeList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dtgv_productionCodeList.Columns.Add("code", "productionCodes");
            if (productionCode != null)
            {
                for (int i = 0; i < productionCode.Length; i++)
                {
                    this.dtgv_productionCodeList.Rows.Add(productionCode[i]);
                }
            }
            this.dtgv_productionCodeList.Sort(this.dtgv_productionCodeList.Columns["code"], ListSortDirection.Ascending);
        }
        private void txb_searchReceivers_TextChanged(object sender, EventArgs e)
        {

            this.dtgv_receivers.Rows.Clear();
            this.dtgv_receivers.Columns.Clear();
            dtgv_receivers.RowHeadersVisible = false;
            dtgv_receivers.ColumnHeadersVisible = false;
            dtgv_receivers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgv_receivers.Columns.Add("receiver", "Receivers");
            string receiverSearch = "";
            string[] receivers;
            if (settings.cfg_receivers != null)
            {
                receivers = settings.cfg_receivers.Split('-');
            }
            else
            {
                receivers = null;
            }

            for (int i = 0; i < receivers.Length; i++)
            {
                if (receivers[i].Contains(txb_searchReceivers.Text))
                {
                    if (receiverSearch == "")
                    {
                        receiverSearch += receivers[i];
                    }
                    else
                    {
                        receiverSearch += "-" + receivers[i];
                    }

                }
            }
            string[] receiverSearchList = receiverSearch.Split('-');
            if (receiverSearchList != null)
            {
                for (int j = 0; j < receiverSearchList.Length; j++)
                {
                    this.dtgv_receivers.Rows.Add(receiverSearchList[j]);
                }
            }
            if (string.IsNullOrWhiteSpace(txb_searchReceivers.Text))
            {
                LoadReceiverGrid();
            }
        }
        

        private void btn_deleteEmail_Click(object sender, EventArgs e)
        {
            if(txb_receiverConfig.Text == "")
            {
                if (settings.cfg_language == 1)
                    MessageBox.Show("Please select receiver need to delete !");
                else
                    MessageBox.Show("Xin hãy chọn người nhận cần xóa !");
            }
            else
            {
                DialogResult dialogResult;
                if (settings.cfg_language == 1)
                {
                    dialogResult = MessageBox.Show("Delete '" + txb_receiverConfig.Text + "' from receivers list ?", "Delete receiver confirmation", MessageBoxButtons.OKCancel);
                }
                else
                {
                    dialogResult = MessageBox.Show("Xóa địa chỉ '" + txb_receiverConfig.Text + "' khỏi danh sách người nhận ?", "Xác nhận xóa", MessageBoxButtons.OKCancel);
                }
                if ( dialogResult == DialogResult.OK)
                {
                    string remainReceiver = settings.cfg_receivers;
                    string[] receivers = settings.cfg_receivers.Split('-');
                    if (receivers[0] == settings.selectedReceiver)
                    {
                        if (remainReceiver == settings.selectedReceiver)
                        {
                            settings.cfg_receivers = remainReceiver.Replace(settings.selectedReceiver, null);
                        }
                        else
                        {
                            settings.cfg_receivers = remainReceiver.Replace(settings.selectedReceiver + "-", null);
                        }
                    }
                    else
                    {
                        settings.cfg_receivers = remainReceiver.Replace("-" + settings.selectedReceiver, null);
                    }
                    MessageBox.Show("Xóa thành công " + settings.selectedReceiver +" khỏi danh sách người nhận!");
                    settings.Save();
                    LoadReceiverGrid();
                }
                txb_receiverConfig.Clear();
                txb_searchReceivers.Clear();
            }
        }

        private void btn_addReceiver_Click(object sender, EventArgs e)
        {
            txb_receiverConfig.Enabled = true;
            btn_saveReceiver.Enabled = true;
            txb_receiverConfig.Clear();
            txb_receiverConfig.Focus();
        }

        private void btn_saveReceiver_Click(object sender, EventArgs e)
        {
            if (settings.cfg_receivers != null && settings.cfg_receivers.Contains(txb_receiverConfig.Text))
            {
                if (txb_receiverConfig.Text == "")
                {
                    if (settings.cfg_language == 1) { MessageBox.Show("Receiver address is empty! Please input a value before press save!"); }

                    else { MessageBox.Show("Địa chỉ mail người nhận trống! Xin hãy nhập địa chỉ mail trước khi chọn lưu!"); }
                }
                else
                {
                    if (settings.cfg_language == 1) { MessageBox.Show("Receiver '" + txb_receiverConfig.Text + "' have existed!"); }

                    else { MessageBox.Show("Địa chỉ '" + txb_receiverConfig.Text + "' đã tồn tại!"); }
                }
                txb_receiverConfig.Clear();
                txb_receiverConfig.Enabled = false;
                btn_saveReceiver.Enabled = false;
            }
            else
            {
                DialogResult dialogResult; 
                if ( settings.cfg_language == 1)
                {
                    dialogResult = MessageBox.Show("Do you want to add '" + txb_receiverConfig.Text + "' to list of receivers ?", "Confirmation", MessageBoxButtons.OKCancel);
                }
                else
                {
                    dialogResult = MessageBox.Show("Thêm người nhận '" + txb_receiverConfig.Text + "' vào danh sách người nhận ?", "Xác nhận", MessageBoxButtons.OKCancel);
                }
                if (dialogResult == DialogResult.OK)
                {
                    if (txb_receiverConfig != null)
                    {
                        if (settings.cfg_receivers == null)
                        {
                            settings.cfg_receivers += txb_receiverConfig.Text;
                            settings.Save();
                        }
                        else if (settings.cfg_receivers != null)
                        {
                            settings.cfg_receivers += "-" + txb_receiverConfig.Text;
                            settings.Save();
                        }
                        LoadReceiverGrid();
                        txb_receiverConfig.Clear();
                        
                    }
                    else
                    {
                        MessageBox.Show("Please in put receiver email address !");
                    }
                }
                txb_receiverConfig.Enabled = false;
                btn_saveReceiver.Enabled = false;
            }
            
        }

        private void dtgv_receivers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgv_receivers.Rows[e.RowIndex];
                
                txb_receiverConfig.Text = row.Cells[0].Value.ToString();
                settings.selectedReceiver = txb_receiverConfig.Text;
                settings.Save();
            }
        }

        private void btn_deleteAllReceiver_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to clear all receivers in the list ?", "Delete confirmation", MessageBoxButtons.OKCancel);
            if ( dialogResult == DialogResult.OK)
            {
                settings.cfg_receivers = null;
                settings.Save();
            }
            LoadReceiverGrid();
            
        }

        private void btn_settingCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nud_bgIntervalPicker_ValueChanged(object sender, EventArgs e)
        {
            settings.interval = int.Parse(nud_bgIntervalPicker.Value.ToString());
            settings.Save();
        }

        private void nud_sendMailIntervalPicker_ValueChanged(object sender, EventArgs e)
        {
            settings.intervalMail = int.Parse(nud_sendMailIntervalPicker.Value.ToString());
            settings.Save();
        }

        private void btn_addProductionCode_Click(object sender, EventArgs e)
        {
            txb_productionCodeConfig.Enabled = true;
            btn_saveProductionCodeConfig.Enabled = true;
            txb_productionCodeConfig.Clear();
            txb_productionCodeConfig.Focus();
        }

        private void btn_saveProductionCodeConfig_Click(object sender, EventArgs e)
        {
            if (settings.cfg_produceCodes != null && settings.cfg_produceCodes.Contains(txb_productionCodeConfig.Text))
            {
                if (txb_productionCodeConfig.Text == "")
                {
                    if (settings.cfg_language == 1) { MessageBox.Show("Production code is empty! Please input a value before press save!"); }

                    else { MessageBox.Show("Đầu mã sản xuất trống! Xin hãy nhập đầu mã sản xuất trước khi chọn lưu!"); }
                }
                else
                {
                    if (settings.cfg_language == 1) { MessageBox.Show("Production code '" + txb_productionCodeConfig.Text + "' have existed!"); }

                    else { MessageBox.Show("Đầu mã '" + txb_productionCodeConfig.Text + "' đã tồn tại!"); }
                }
                txb_productionCodeConfig.Clear();
                txb_productionCodeConfig.Enabled = false;
                btn_saveProductionCodeConfig.Enabled = false;
            }
            else
            {
                DialogResult dialogResult;
                if (settings.cfg_language == 1)
                {
                    dialogResult = MessageBox.Show("Do you want to add '" + txb_productionCodeConfig.Text + "' to list of receivers codes?", "Confirmation", MessageBoxButtons.OKCancel);
                }
                else
                {
                    dialogResult = MessageBox.Show("Thêm đầu mã '" + txb_productionCodeConfig.Text + "' vào danh sách?", "Xác nhận", MessageBoxButtons.OKCancel);
                }
                if (dialogResult == DialogResult.OK)
                {
                    if (txb_productionCodeConfig != null)
                    {
                        if (settings.cfg_produceCodes == null)
                        {
                            settings.cfg_produceCodes += txb_productionCodeConfig.Text;
                            settings.Save();
                        }
                        else if (settings.cfg_produceCodes != null)
                        {
                            settings.cfg_produceCodes += "-" + txb_productionCodeConfig.Text;
                            settings.Save();
                        }
                        LoadProductionCodes();
                        txb_productionCodeConfig.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Please in put a production code !");
                    }
                }
                txb_productionCodeConfig.Enabled = false;
                btn_saveProductionCodeConfig.Enabled = false;
            }
        }

        private void btn_deleteProductionCode_Click(object sender, EventArgs e)
        {
            if (txb_productionCodeConfig.Text == "")
            {
                if (settings.cfg_language == 1)
                    MessageBox.Show("Please select production code header need to delete !");
                else
                    MessageBox.Show("Xin hãy chọn đầu mã cần xóa !");
            }
            else
            {
                DialogResult dialogResult;
                if (settings.cfg_language == 1)
                {
                    dialogResult = MessageBox.Show("Delete '" + txb_productionCodeConfig.Text + "' from production code headers list ?", "Delete confirmation", MessageBoxButtons.OKCancel);
                }
                else
                {
                    dialogResult = MessageBox.Show("Xóa đầu mã '" + txb_productionCodeConfig.Text + "' khỏi danh sách ?", "Xác nhận xóa", MessageBoxButtons.OKCancel);
                }
                if (dialogResult == DialogResult.OK)
                {
                    string remainProductionCode = settings.cfg_produceCodes;
                    string[] productionCodes = settings.cfg_produceCodes.Split('-');
                    if (productionCodes[0] == settings.selectedProduceCode)
                    {
                        if (remainProductionCode == settings.selectedProduceCode)
                        {
                            settings.cfg_produceCodes = remainProductionCode.Replace(settings.selectedProduceCode, null);
                        }
                        else
                        {
                            settings.cfg_produceCodes = remainProductionCode.Replace(settings.selectedProduceCode + "-", null);
                        }
                    }
                    else
                    {
                        settings.cfg_produceCodes = remainProductionCode.Replace("-" + settings.selectedProduceCode, null);
                    }
                    MessageBox.Show("Xóa thành công " + settings.selectedProduceCode + " khỏi danh sách!");
                    settings.Save();
                    LoadProductionCodes();
                }
                txb_productionCodeConfig.Clear();
                txb_productionCodeSearch.Clear();
            }
        }

        private void dtgv_productionCodeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgv_productionCodeList.Rows[e.RowIndex];

                txb_productionCodeConfig.Text = row.Cells[0].Value.ToString();
                settings.selectedProduceCode = txb_productionCodeConfig.Text;
                settings.Save();
            }
        }

        private void txb_productionCodeSearch_Enter(object sender, EventArgs e)
        {
            if (txb_productionCodeSearch.Text == "Search")
            {
                txb_productionCodeSearch.Text = "";
                txb_productionCodeSearch.ForeColor = Color.Black;
            }
        }

        private void txb_productionCodeSearch_Leave(object sender, EventArgs e)
        {
            if (txb_productionCodeSearch.Text == "")
            {
                txb_productionCodeSearch.Text = "Search";
                txb_productionCodeSearch.ForeColor = Color.DimGray;
            }
            LoadProductionCodes();
        }

        private void txb_searchReceivers_Enter(object sender, EventArgs e)
        {
            if (txb_searchReceivers.Text == "Search")
            {
                txb_searchReceivers.Text = "";
                txb_searchReceivers.ForeColor = Color.Black;
            }
        }

        private void txb_searchReceivers_Leave(object sender, EventArgs e)
        {
            if (txb_searchReceivers.Text == "")
            {
                txb_searchReceivers.Text = "Search";
                txb_searchReceivers.ForeColor = Color.DimGray;
            }
            LoadReceiverGrid();
        }

        private void txb_productionCodeSearch_TextChanged(object sender, EventArgs e)
        {

            this.dtgv_productionCodeList.Rows.Clear();
            this.dtgv_productionCodeList.Columns.Clear();
            dtgv_productionCodeList.RowHeadersVisible = false;
            dtgv_productionCodeList.ColumnHeadersVisible = false;
            dtgv_productionCodeList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgv_productionCodeList.Columns.Add("code", "productionCodes");
            string codeSearch = "";
            string[] codes;
            if (settings.cfg_produceCodes != null)
            {
                codes = settings.cfg_produceCodes.Split('-');
            }
            else
            {
                codes = null;
            }

            for (int i = 0; i < codes.Length; i++)
            {
                if (codes[i].Contains(txb_productionCodeSearch.Text))
                {
                    if (codeSearch == "")
                    {
                        codeSearch += codes[i];
                    }
                    else
                    {
                        codeSearch += "-" + codes[i];
                    }

                }
            }
            string[] codeSearchList = codeSearch.Split('-');
            if (codeSearchList != null)
            {
                for (int j = 0; j < codeSearchList.Length; j++)
                {
                    this.dtgv_productionCodeList.Rows.Add(codeSearchList[j]);
                }
            }
            if (string.IsNullOrWhiteSpace(txb_productionCodeSearch.Text))
            {
                LoadProductionCodes();
            }
        }
    }
}
