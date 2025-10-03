using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BBHRKS.Utilities;

namespace BBH_Records_Keeping_System
{
    public partial class Tenants_MENU : Form
    {
        public Tenants_MENU()
        {
            InitializeComponent();
        }

        private void Tenants_MENU_Load(object sender, EventArgs e)
        {

        }

        private void btnNewTenant_Click(object sender, EventArgs e)
        {
            Utilities.TenantsMenu tm = new Utilities.TenantsMenu(Utilities.TenantsMenuAction.NewTenant);
            Utilities.TMenuAction = tm;
            Close();
        }

        private void btnUpdateTenant_Click(object sender, EventArgs e)
        {
            Utilities.TMenuAction = new Utilities.TenantsMenu(Utilities.TenantsMenuAction.UpdateTenant, "TEST");
            Close();
        }

        private void Tenants_MENU_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
