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

        private void btn_checkMailCon_Click(object sender, EventArgs e)
        {
            settings.cfg_senders = txb_email.Text;
            settings.cfg_senderPW = txb_password.Text;
            settings.Save();
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
            btn_checkMailCon.Text = "SAVE";
            btn_addReceiver.Text = "ADD";
            btn_deleteEmail.Text = "DELETE";
            btn_deleteAllReceiver.Text = "DELETE ALL";
            lb_mainSettingWarning.Text = "Settings in \"bold\" style can ONLY be \nconfig before started or after stopped \nthe program!";
            lb_bgIntervalPicker.Text = "Data fetching interval:";
            lb_bgIntervalUnit.Text = "hour";
            lb_produceCodeConfig.Text = "Produce code header:";
            btn_saveProduceCodeConfig.Text = "SAVE";
            lb_listProduceCodes.Text = "List of produce code headers:";
            btn_addProduceCode.Text = "ADD";
            btn_deleteProduceCode.Text = "DELETE";
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
            btn_checkMailCon.Text = "LƯU";
            btn_addReceiver.Text = "THÊM";
            btn_deleteEmail.Text = "XÓA";
            btn_deleteAllReceiver.Text = "XÓA TẤT CẢ";
            lb_mainSettingWarning.Text = "Những cài đặt \"in đậm\" CHỈ chỉnh sửa \nđược trước khi bắt đầu hoặc sau khi \ndừng chương trình!";
            lb_bgIntervalPicker.Text = "Khoảng lấy dữ liệu:";
            lb_bgIntervalUnit.Text = "giờ";
            lb_produceCodeConfig.Text = "Đầu mã sản xuất:";
            btn_saveProduceCodeConfig.Text = "LƯU";
            lb_listProduceCodes.Text = "Danh sách các đầu mã:";
            btn_addProduceCode.Text = "THÊM";
            btn_deleteProduceCode.Text = "XÓA";
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
            LoadReceiverGrid();
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
                    settings.Save();
                    LoadReceiverGrid();
                }
                txb_receiverConfig.Clear();
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
                DialogResult dialogResult = MessageBox.Show("Do you want to add '" + txb_receiverConfig.Text + "' to list of receivers ?", "Confirmation", MessageBoxButtons.OKCancel);
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
    }
}
