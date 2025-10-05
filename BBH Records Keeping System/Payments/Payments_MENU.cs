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
    public partial class Payments_MENU : Form
    {
        public Payments_MENU()
        {
            InitializeComponent();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            Hide();
            Payments_BILL PB = new Payments_BILL();
            PB.ShowDialog();
            Show();
        }
    }
}
