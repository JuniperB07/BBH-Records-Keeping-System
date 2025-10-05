using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBH_Records_Keeping_System
{
    public partial class Settings_MENU : Form
    {
        public Settings_MENU()
        {
            InitializeComponent();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            User_MANAGEMENT UM = new User_MANAGEMENT();
            UM.ShowDialog();
        }

        private void btnBillPreviewExportPath_Click(object sender, EventArgs e)
        {
            Exports_PATH EP = new Exports_PATH();
            EP.ShowDialog();
        }
    }
}
