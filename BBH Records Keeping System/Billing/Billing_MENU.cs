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
    public partial class Billing_MENU : Form
    {
        public Billing_MENU()
        {
            InitializeComponent();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            Hide();
            Billing_New BN = new Billing_New();
            BN.ShowDialog();
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Additionals_NEW AN = new Additionals_NEW();
            AN.ShowDialog();
            Show();
        }
    }
}
