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
        public delegate void AdviseParentEventHandler(string text);
        public event AdviseParentEventHandler AdviseParent;
        Properties.Settings settings = new Properties.Settings();
        mes2ERPMainWin mainWin = new mes2ERPMainWin();
        
        public Setting()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

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
            mainWin.lb_pickTime.Text = "Fetching interval:";
            mainWin.lb_timeDV.Text = "hour";
            lb_languageConfig.Text = "Choose your language";
            lb_configMailTitle.Text = "Input sender's email and password:";
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
            if (AdviseParent != null)
                AdviseParent("Khoảng thời gian nạp:");
            mainWin.lb_pickTime.Text = "Khoảng thời gian nạp:";
            mainWin.lb_timeDV.Text = "giờ";
            lb_languageConfig.Text = "Chọn ngôn ngữ của bạn";
            lb_configMailTitle.Text = "Nhập vào địa chỉ email và password email của người gửi:";
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
            LoadReceiverGrid();
        }
        
        public void LoadReceiverGrid()
        {
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
            if(settings.selectedReceiver == null)
            {
                if (settings.cfg_language == 1)
                    MessageBox.Show("Please select receiver need to delete !");
                else
                    MessageBox.Show("Xin hãy chọn người nhận cần xóa !");
            }
            else
            {
                string remainReceiver = settings.cfg_receivers;
                settings.cfg_receivers = remainReceiver.Replace("-" + settings.selectedReceiver, String.Empty);
                txb_receiverConfig.Clear();
                settings.Save();
                LoadReceiverGrid();
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
                    txb_receiverConfig.Enabled = false;
                    btn_saveReceiver.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Please in put receiver email address !");
                }
            }
            else
            {
                if(dialogResult == DialogResult.Cancel)
                {
                    txb_receiverConfig.Enabled = false;
                    btn_saveReceiver.Enabled = false;
                }
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
    }
}
