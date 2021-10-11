using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MESdbToERPdb
{
    public partial class mes2ERPMainWin : Form
    {
        public mes2ERPMainWin()
        {
            InitializeComponent();
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            View.SettingWindow settingW = new View.SettingWindow();
            settingW.ShowDialog();
        }

        private void btn_support_Click(object sender, EventArgs e)
        {
            View.SupportWindow supportW = new View.SupportWindow();
            supportW.ShowDialog();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {

        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
        }
    }
}
