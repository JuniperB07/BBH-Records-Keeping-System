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
    public partial class MSG_Processing : Form
    {
        public MSG_Processing()
        {
            InitializeComponent();
        }

        private void MSG_Processing_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
