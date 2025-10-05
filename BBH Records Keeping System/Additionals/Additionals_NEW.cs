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
    public partial class Additionals_NEW : Form
    {
        DBConnect DBC;
        string cmdStr;
        string TenantName;

        public Additionals_NEW()
        {
            InitializeComponent();
        }

        #region PRIVATE FUNCTIONS
        private void ClearForm()
        {
            Forms.ClearControlText(Forms.ControlType<TextBox>.Extract(this, "txt"));

            lstTenants.Items.Clear();
            dgvAdditionalCharges.DataSource = null;
        }
        private void ResetForm()
        {
            cmdStr = "";
            TenantName = "";
            AdditionalsHelper.TenantName = "";
            AdditionalsHelper.AdditionalID = 0;

            lstTenants.Items.Clear();
            foreach (string tenant in Global.TenantsList)
                lstTenants.Items.Add(tenant);

            dgvAdditionalCharges.DataSource = null;
            cmdStr = Construct.InnerJoinAliasCommand(
                SelectWithAlias: new JoinMetadata[]
                {
                    new JoinMetadata(
                        FromTable: tbtenants.tbtenants.ToString(),
                        SelectColumn: tbtenants.FullName.ToString(),
                        As: "Tenant Name"),
                    new JoinMetadata(
                        tbadditionals.tbadditionals.ToString(),
                        tbadditionals.Details.ToString(),
                        "Details"),
                    new JoinMetadata(
                        tbadditionals.tbadditionals.ToString(),
                        tbadditionals.EnforcementDate.ToString(),
                        "Enforcement Date"),
                    new JoinMetadata(
                        tbadditionals.tbadditionals.ToString(),
                        tbadditionals.Status.ToString(),
                        "Status"),
                    new JoinMetadata(
                        tbadditionals.tbadditionals.ToString(),
                        tbadditionals.AdditionalID.ToString(),
                        "AID") },
                From: tbadditionals.tbadditionals.ToString(),
                InnerJoin: tbtenants.tbtenants.ToString(),
                OnLeft: new JoinMetadata(
                    tbtenants.tbtenants.ToString(),
                    tbtenants.TenantID.ToString()),
                OnRight: new JoinMetadata(
                    tbadditionals.tbadditionals.ToString(),
                    tbadditionals.TenantID.ToString()),
                Where:
                    tbadditionals.tbadditionals.ToString() + "." + tbadditionals.Status.ToString() + "='" + Metadata.Additionals.Status.Unpaid + "' OR " +
                    tbadditionals.tbadditionals.ToString() + "." + tbadditionals.Status.ToString() + "='" + Metadata.Additionals.Status.Partial + "'");
            cmdStr = Construct.AppendOrderBy(
                cmdStr,
                OrderBy: tbadditionals.tbadditionals.ToString() + "." + tbadditionals.EnforcementDate.ToString(),
                OrderMode: MySQLOrderBy.DESC);
            DBC.CommandString = cmdStr;
            DBC.ExecuteDataSet();
            dgvAdditionalCharges.DataSource = DBC.DataSet.Tables[0];

            dtpEnforcementDate.MaxDate = DateTime.Now.AddDays(365);
            dtpEnforcementDate.MinDate = DateTime.Now.AddDays(-1);
            dtpEnforcementDate.Value = DateTime.Now;
            grpAdditionalsInformation.Enabled = false;
        }
        #endregion

        private void Additionals_NEW_Load(object sender, EventArgs e)
        {
            DBC = new DBConnect(Database.Connection);
            Global.Initialize(DBC);

            ClearForm();
            ResetForm();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                lstTenants.Items.Clear();

                foreach (string tenant in Global.SearchTenantsList(txtSearch.Text))
                    lstTenants.Items.Add(tenant);
            }
            else
            {
                lstTenants.Items.Clear();
                foreach (string tenant in Global.TenantsList)
                    lstTenants.Items.Add(tenant);
            }
        }

        private void lstTenants_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstTenants.SelectedItems.Count > 0)
            {
                TenantName = lstTenants.SelectedItem.ToString();
                grpAdditionalsInformation.Enabled = true;
            }
        }

        private void lklToday_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dtpEnforcementDate.Value = DateTime.Now;
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            if (txtDetails.Text != "" && txtTotalFee.Text != "")
            {
                if (double.TryParse(txtTotalFee.Text, out _))
                {
                    if (Global.GetTenantID(TenantName) == -1)
                    {
                        MessageBox.Show("Unable to find tenant.\nPlease contact administrator.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DBC.CommandString = Construct.InsertIntoCommand(
                        InsertInto: tbadditionals.tbadditionals.ToString(),
                        InsertMetadata: new InsertColumnMetadata[]
                        {
                            new InsertColumnMetadata(
                                ToColumn: tbadditionals.TenantID.ToString(),
                                WithDataType: MySQLDataType.Int,
                                WithValue: Global.GetTenantID(TenantName).ToString()),
                            new InsertColumnMetadata(
                                tbadditionals.EnforcementDate.ToString(),
                                MySQLDataType.Date,
                                dtpEnforcementDate.Value.ToString("yyyy-MM-dd")),
                            new InsertColumnMetadata(
                                tbadditionals.Details.ToString(),
                                MySQLDataType.Text,
                                txtDetails.Text),
                            new InsertColumnMetadata(
                                tbadditionals.TotalFee.ToString(),
                                MySQLDataType.Decimal,
                                txtTotalFee.Text),
                            new InsertColumnMetadata(
                                tbadditionals.AmountPaid.ToString(),
                                MySQLDataType.Decimal,
                                "0"),
                            new InsertColumnMetadata(
                                tbadditionals.RemainingBalance.ToString(),
                                MySQLDataType.Decimal,
                                txtTotalFee.Text),
                            new InsertColumnMetadata(
                                tbadditionals.Status.ToString(),
                                MySQLDataType.VarChar,
                                Metadata.Additionals.Status.Unpaid) });
                    DBC.ExecuteNonQuery();

                    MessageBox.Show("Additional Charge saved.\nThis charge will be added to the selected tenant's next bill.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Additionals_NEW_Load(this, EventArgs.Empty);
                }
                else
                    MessageBox.Show("Please enter a valid Total Fee.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Please fill Details & Total Fee.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvAdditionalCharges_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AdditionalsHelper.AdditionalID = Convert.ToInt32(dgvAdditionalCharges.SelectedCells[4].Value.ToString());
            AdditionalsHelper.TenantName = dgvAdditionalCharges.SelectedCells[0].Value.ToString();
            Additionals_VIEW AV = new Additionals_VIEW();
            AV.ShowDialog();
            Additionals_NEW_Load(this, EventArgs.Empty);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
            ResetForm();
        }
    }
}
