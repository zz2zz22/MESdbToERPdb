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
        mes2ERPMainWin mainWin = new mes2ERPMainWin();
        
        public Setting()
        {
            InitializeComponent();
        }

        private void btn_editSender_Click(object sender, EventArgs e)
        {
            txb_email.Enabled = true;
            txb_password.Enabled = true;
            btn_saveSender.Enabled = true;
        }
        private void btn_saveSender_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            if (Properties.Settings.Default.cfg_language == 1)
            {
                dialogResult = MessageBox.Show("Do you want to set this sender ?", "Confirmation", MessageBoxButtons.OKCancel);
            }
            else
            {
                dialogResult = MessageBox.Show("Bạn có muốn lưu người gửi này không ?", "Confirmation", MessageBoxButtons.OKCancel);
            }
            if (dialogResult == DialogResult.OK)
            {
                Properties.Settings.Default.cfg_senders = txb_email.Text;
                Properties.Settings.Default.cfg_senderPW = txb_password.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Lưu người gửi thành công!");
            }
            txb_email.Enabled = false;
            txb_password.Enabled = false;
            btn_saveSender.Enabled = false;
        }

        private void btn_languageEnglish_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.cfg_language = 1;
            Properties.Settings.Default.Save();
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
            lb_bgIntervalPicker.Text = "D2 fetching interval:";
            lb_bgIntervalD1Picker.Text = "D1 fetching interval:";
            lb_bgIntervalUnit.Text = "hours";
            lb_bgIntervalD1Unit.Text = "minutes";
            lb_productionCodeConfig.Text = "Production code header:";
            btn_saveProductionCodeConfig.Text = "SAVE";
            lb_listProductionCodes.Text = "List of production code headers:";
            btn_addProductionCode.Text = "ADD";
            btn_deleteProductionCode.Text = "DELETE";
            btn_saveSender.Text = "SAVE";
            btn_editSender.Text = "EDIT";
            lb_sendMailInterval.Text = "Send mail interval:";
            lb_sendMailIntervalUnit.Text = "hours";
            lb_d1Status.Text = "D1 status";
            cbx_d1Status.Items[0] = "N - Not comfirmed";
            cbx_d1Status.Items[1] = "Y - Confirmed";
            lb_d2Status.Text = "D2 status";
            cbx_d2Status.Items[0] = "N - Not comfirmed";
            cbx_d2Status.Items[1] = "Automatic";
        }
        private void btn_languageVietnam_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.cfg_language = 0;
            Properties.Settings.Default.Save();
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
            lb_bgIntervalPicker.Text = "Thời gian chuyển đổi phiếu D2:";
            lb_bgIntervalD1Picker.Text = "Thời gian chuyển đổi phiếu D1:";
            lb_bgIntervalUnit.Text = "giờ";
            lb_bgIntervalD1Unit.Text = "phút";
            lb_productionCodeConfig.Text = "Đầu mã sản xuất:";
            btn_saveProductionCodeConfig.Text = "LƯU";
            lb_listProductionCodes.Text = "Danh sách các đầu mã:";
            btn_addProductionCode.Text = "THÊM";
            btn_deleteProductionCode.Text = "XÓA";
            btn_saveSender.Text = "LƯU";
            btn_editSender.Text = "SỬA";
            lb_sendMailInterval.Text = "Khoảng thời gian gửi mail:";
            lb_sendMailIntervalUnit.Text = "giờ";
            lb_d1Status.Text = "Trạng thái xác nhận D1";
            cbx_d1Status.Items[0] = "N - Không xác nhận";
            cbx_d1Status.Items[1] = "Y - Xác nhận";
            lb_d2Status.Text = "Trạng thái xác nhận D2";
            cbx_d2Status.Items[0] = "N - Không xác nhận";
            cbx_d2Status.Items[1] = "Tự động xét điều kiện";
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.cfg_receivers == "")
            {
                Properties.Settings.Default.cfg_receivers = null;
            }
            if (Properties.Settings.Default.cfg_language == 1)
            {
                ChangeLanguageToEnglish();
            }else if (Properties.Settings.Default.cfg_language == 0) {
                ChangeLanguageToVietnamese();
            }
            nud_bgIntervalPicker.Value = Convert.ToDecimal(Properties.Settings.Default.interval.ToString());
            nud_sendMailIntervalPicker.Value = Convert.ToDecimal(Properties.Settings.Default.intervalMail.ToString());
            nud_bgIntervalD1Picker.Value = Convert.ToDecimal(Properties.Settings.Default.intervalD1.ToString());
            txb_email.Text = Properties.Settings.Default.cfg_senders;
            txb_password.Text = Properties.Settings.Default.cfg_senderPW;
            txb_email.Enabled = false;
            txb_password.Enabled = false;
            btn_saveSender.Enabled = false;
            if (Properties.Settings.Default.d1Status == "Y")
            {
                cbx_d1Status.Text = cbx_d1Status.Items[1].ToString();
            }else
            {
                if (Properties.Settings.Default.d1Status == "N")
                    cbx_d1Status.Text = cbx_d1Status.Items[0].ToString();
            }
            if (Properties.Settings.Default.d2Status == "Y")
            {
                cbx_d2Status.Text = cbx_d2Status.Items[1].ToString();
            }
            else
            {
                if (Properties.Settings.Default.d2Status == "N")
                    cbx_d2Status.Text = cbx_d2Status.Items[0].ToString();
            }

            LoadReceiverGrid();
            LoadProductionCodes();
        }
        
        public void LoadReceiverGrid()
        {
            if (Properties.Settings.Default.cfg_receivers == "")
            {
                Properties.Settings.Default.cfg_receivers = null;
            }
            this.dtgv_receivers.Rows.Clear();
            this.dtgv_receivers.Columns.Clear();
            string[] receivers;
            if (Properties.Settings.Default.cfg_receivers != null)
            {
                receivers = Properties.Settings.Default.cfg_receivers.Split('-');
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
            if (Properties.Settings.Default.cfg_produceCodes == "")
            {
                Properties.Settings.Default.cfg_produceCodes = null;
            }
            dtgv_productionCodeList.Rows.Clear();
            dtgv_productionCodeList.Columns.Clear();
            string[] productionCode;
            if (Properties.Settings.Default.cfg_produceCodes != null)
            {
                productionCode = Properties.Settings.Default.cfg_produceCodes.Split('-');
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
            if (!string.IsNullOrWhiteSpace(txb_searchReceivers.Text))
            {
                this.dtgv_receivers.Rows.Clear();
                this.dtgv_receivers.Columns.Clear();
                dtgv_receivers.RowHeadersVisible = false;
                dtgv_receivers.ColumnHeadersVisible = false;
                dtgv_receivers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtgv_receivers.Columns.Add("receiver", "Receivers");
                string receiverSearch = "";
                string[] receivers;
                if (Properties.Settings.Default.cfg_receivers != null)
                {
                    receivers = Properties.Settings.Default.cfg_receivers.Split('-');
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
               
            }
            else
            {
                LoadReceiverGrid();
            }
            
        }
        

        private void btn_deleteEmail_Click(object sender, EventArgs e)
        {
            if(txb_receiverConfig.Text == "")
            {
                if (Properties.Settings.Default.cfg_language == 1)
                    MessageBox.Show("Please select receiver need to delete !");
                else
                    MessageBox.Show("Xin hãy chọn người nhận cần xóa !");
            }
            else
            {
                DialogResult dialogResult;
                if (Properties.Settings.Default.cfg_language == 1)
                {
                    dialogResult = MessageBox.Show("Delete '" + txb_receiverConfig.Text + "' from receivers list ?", "Delete receiver confirmation", MessageBoxButtons.OKCancel);
                }
                else
                {
                    dialogResult = MessageBox.Show("Xóa địa chỉ '" + txb_receiverConfig.Text + "' khỏi danh sách người nhận ?", "Xác nhận xóa", MessageBoxButtons.OKCancel);
                }
                if ( dialogResult == DialogResult.OK)
                {
                    string remainReceiver = Properties.Settings.Default.cfg_receivers;
                    string[] receivers = Properties.Settings.Default.cfg_receivers.Split('-');
                    if (receivers[0] == Properties.Settings.Default.selectedReceiver)
                    {
                        if (remainReceiver == Properties.Settings.Default.selectedReceiver)
                        {
                            Properties.Settings.Default.cfg_receivers = remainReceiver.Replace(Properties.Settings.Default.selectedReceiver, null);
                        }
                        else
                        {
                            Properties.Settings.Default.cfg_receivers = remainReceiver.Replace(Properties.Settings.Default.selectedReceiver + "-", null);
                        }
                    }
                    else
                    {
                        Properties.Settings.Default.cfg_receivers = remainReceiver.Replace("-" + Properties.Settings.Default.selectedReceiver, null);
                    }
                    MessageBox.Show("Xóa thành công " + Properties.Settings.Default.selectedReceiver +" khỏi danh sách người nhận!");
                    Properties.Settings.Default.Save();
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
            if (Properties.Settings.Default.cfg_receivers != null && Properties.Settings.Default.cfg_receivers.Contains(txb_receiverConfig.Text))
            {
                if (txb_receiverConfig.Text == "")
                {
                    if (Properties.Settings.Default.cfg_language == 1) { MessageBox.Show("Receiver address is empty! Please input a value before press save!"); }

                    else { MessageBox.Show("Địa chỉ mail người nhận trống! Xin hãy nhập địa chỉ mail trước khi chọn lưu!"); }
                }
                else
                {
                    if (Properties.Settings.Default.cfg_language == 1) { MessageBox.Show("Receiver '" + txb_receiverConfig.Text + "' have existed!"); }

                    else { MessageBox.Show("Địa chỉ '" + txb_receiverConfig.Text + "' đã tồn tại!"); }
                }
                txb_receiverConfig.Clear();
                txb_receiverConfig.Enabled = false;
                btn_saveReceiver.Enabled = false;
            }
            else
            {
                DialogResult dialogResult; 
                if (Properties.Settings.Default.cfg_language == 1)
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
                        if (Properties.Settings.Default.cfg_receivers == null)
                        {
                            Properties.Settings.Default.cfg_receivers += txb_receiverConfig.Text;
                            Properties.Settings.Default.Save();
                        }
                        else if (Properties.Settings.Default.cfg_receivers != null)
                        {
                            Properties.Settings.Default.cfg_receivers += "-" + txb_receiverConfig.Text;
                            Properties.Settings.Default.Save();
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
                Properties.Settings.Default.selectedReceiver = txb_receiverConfig.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void btn_deleteAllReceiver_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            if ( Properties.Settings.Default.cfg_language == 1)
            {
                dialogResult = MessageBox.Show("Are you sure you want to clear all receivers in the list ?", "Delete confirmation", MessageBoxButtons.OKCancel);
            }
            else
            {
                dialogResult = MessageBox.Show("Bạn có muốn xóa tất cả người nhận trong danh sách ?", "Xác nhận xóa", MessageBoxButtons.OKCancel);
            }
            if ( dialogResult == DialogResult.OK)
            {
                Properties.Settings.Default.cfg_receivers = null;
                Properties.Settings.Default.Save();
            }
            LoadReceiverGrid();
            
        }

        private void btn_settingCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nud_bgIntervalPicker_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.interval = int.Parse(nud_bgIntervalPicker.Value.ToString());
            Properties.Settings.Default.Save();
            
        }

        private void nud_sendMailIntervalPicker_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.intervalMail = int.Parse(nud_sendMailIntervalPicker.Value.ToString());
            Properties.Settings.Default.Save();
            
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
            if (Properties.Settings.Default.cfg_produceCodes != null && Properties.Settings.Default.cfg_produceCodes.Contains(txb_productionCodeConfig.Text))
            {
                if (txb_productionCodeConfig.Text == "")
                {
                    if (Properties.Settings.Default.cfg_language == 1) { MessageBox.Show("Production code is empty! Please input a value before press save!"); }

                    else { MessageBox.Show("Đầu mã sản xuất trống! Xin hãy nhập đầu mã sản xuất trước khi chọn lưu!"); }
                }
                else
                {
                    if (Properties.Settings.Default.cfg_language == 1) { MessageBox.Show("Production code '" + txb_productionCodeConfig.Text + "' have existed!"); }

                    else { MessageBox.Show("Đầu mã '" + txb_productionCodeConfig.Text + "' đã tồn tại!"); }
                }
                txb_productionCodeConfig.Clear();
                txb_productionCodeConfig.Enabled = false;
                btn_saveProductionCodeConfig.Enabled = false;
            }
            else
            {
                DialogResult dialogResult;
                if (Properties.Settings.Default.cfg_language == 1)
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
                        if (Properties.Settings.Default.cfg_produceCodes == null)
                        {
                            Properties.Settings.Default.cfg_produceCodes += txb_productionCodeConfig.Text;
                            Properties.Settings.Default.Save();
                        }
                        else if (Properties.Settings.Default.cfg_produceCodes != null)
                        {
                            Properties.Settings.Default.cfg_produceCodes += "-" + txb_productionCodeConfig.Text;
                            Properties.Settings.Default.Save();
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
                if (Properties.Settings.Default.cfg_language == 1)
                    MessageBox.Show("Please select production code header need to delete !");
                else
                    MessageBox.Show("Xin hãy chọn đầu mã cần xóa !");
            }
            else
            {
                DialogResult dialogResult;
                if (Properties.Settings.Default.cfg_language == 1)
                {
                    dialogResult = MessageBox.Show("Delete '" + txb_productionCodeConfig.Text + "' from production code headers list ?", "Delete confirmation", MessageBoxButtons.OKCancel);
                }
                else
                {
                    dialogResult = MessageBox.Show("Xóa đầu mã '" + txb_productionCodeConfig.Text + "' khỏi danh sách ?", "Xác nhận xóa", MessageBoxButtons.OKCancel);
                }
                if (dialogResult == DialogResult.OK)
                {
                    string remainProductionCode = Properties.Settings.Default.cfg_produceCodes;
                    string[] productionCodes = Properties.Settings.Default.cfg_produceCodes.Split('-');
                    if (productionCodes[0] == Properties.Settings.Default.selectedProduceCode)
                    {
                        if (remainProductionCode == Properties.Settings.Default.selectedProduceCode)
                        {
                            Properties.Settings.Default.cfg_produceCodes = remainProductionCode.Replace(Properties.Settings.Default.selectedProduceCode, null);
                        }
                        else
                        {
                            Properties.Settings.Default.cfg_produceCodes = remainProductionCode.Replace(Properties.Settings.Default.selectedProduceCode + "-", null);
                        }
                    }
                    else
                    {
                        Properties.Settings.Default.cfg_produceCodes = remainProductionCode.Replace("-" + Properties.Settings.Default.selectedProduceCode, null);
                    }
                    MessageBox.Show("Xóa thành công " + Properties.Settings.Default.selectedProduceCode + " khỏi danh sách!");
                    Properties.Settings.Default.Save();
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
                Properties.Settings.Default.selectedProduceCode = txb_productionCodeConfig.Text;
                Properties.Settings.Default.Save();
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
            if (Properties.Settings.Default.cfg_produceCodes != null)
            {
                codes = Properties.Settings.Default.cfg_produceCodes.Split('-');
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

        private void nud_bgIntervalD1Picker_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.intervalD1 = int.Parse(nud_bgIntervalD1Picker.Value.ToString());
            Properties.Settings.Default.Save();
        }

        private void cbx_d1Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbx_d1Status.SelectedIndex;
            if (selectedIndex == 0)
                Properties.Settings.Default.d1Status = "N";
            else
            {
                if (selectedIndex == 1)
                    Properties.Settings.Default.d1Status = "Y";
            }
            Properties.Settings.Default.Save();
        }

        private void cbx_d2Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbx_d2Status.SelectedIndex;
            if (selectedIndex == 0)
                Properties.Settings.Default.d2Status = "N";
            else
            {
                if (selectedIndex == 1)
                    Properties.Settings.Default.d2Status = "Y";
            }
            Properties.Settings.Default.Save();
        }
    }
}
