using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BBHRKS.Global;
using BBHRKS.Interface;
using BBHRKS.Metadata;
using BBHRKS.Utilities;
using JunX.NET8.MySQL;
using JunX.NET8.WinForms;

namespace BBH_Records_Keeping_System
{
    public partial class Additionals_VIEW : Form
    {
        DBConnect DBC;

        public Additionals_VIEW()
        {
            InitializeComponent();
        }

        #region PRIVATE FUNCTIONS
        private void ClearForm()
        {
            Forms.ClearControlText(Forms.ControlType<Label>.Extract(this, "lbl").Cast<Control>()
                .Concat(Forms.ControlType<RichTextBox>.Extract(this, "rtxt")).Cast<Control>());
        }
        private void ResetForm()
        {
            lblTenantName.Text = AdditionalsHelper.TenantName;

            DBC.CommandString = Construct.SelectCommand(
                Select: new string[]
                {
                    tbadditionals.EnforcementDate.ToString(),
                    tbadditionals.Details.ToString(),
                    tbadditionals.TotalFee.ToString(),
                    tbadditionals.AmountPaid.ToString(),
                    tbadditionals.RemainingBalance.ToString(),
                    tbadditionals.Status.ToString() },
                From: tbadditionals.tbadditionals.ToString(),
                Where: tbadditionals.AdditionalID.ToString() + "=" + AdditionalsHelper.AdditionalID.ToString());
            DBC.ExecuteReader();
            DBC.GetValues();
            lblEnforcementDate.Text = Convert.ToDateTime(DBC.Values[0]).ToString("MMMM d, yyyy");
            rtxtAddress.Text = DBC.Values[1];
            lblTotalFee.Text = Convert.ToDouble(DBC.Values[2]).ToString("0,0.00");
            lblAmountPaid.Text = Convert.ToDouble(DBC.Values[3]).ToString("0,0.00");
            lblRemainingBalance.Text = Convert.ToDouble(DBC.Values[4]).ToString("0,0.00");
            lblStatus.Text = DBC.Values[5];
        }
        #endregion

        private void Additionals_VIEW_Load(object sender, EventArgs e)
        {
            DBC = new DBConnect(Database.Connection);

            ClearForm();
            ResetForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("This will permanently delete the record.\nProceed?", Interface.MSGBOX_BBHRKS, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                DBC.CommandString = Construct.DeleteCommand(
                    From: tbadditionals.tbadditionals.ToString(),
                    Where: tbadditionals.AdditionalID.ToString() + "=" + AdditionalsHelper.AdditionalID.ToString());
                DBC.ExecuteNonQuery();

                MessageBox.Show("Record deleted.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void btnMarkAsPaid_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("This will permanently mark the record as 'PAID'.\nProceed?", Interface.MSGBOX_BBHRKS, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(dr == DialogResult.Yes)
            {
                DBC.CommandString = Construct.UpdateCommand(
                    Update: tbadditionals.tbadditionals.ToString(),
                    UpdateMetadata: new UpdateColumnMetadata(
                        tbadditionals.Status.ToString(),
                        MySQLDataType.VarChar,
                        Metadata.Additionals.Status.Paid),
                    Where: tbadditionals.AdditionalID.ToString() + "=" + AdditionalsHelper.AdditionalID.ToString());
                DBC.ExecuteNonQuery();

                MessageBox.Show("Record updated.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Additionals_VIEW_Load(this, EventArgs.Empty);
            }
        }
    }
}
