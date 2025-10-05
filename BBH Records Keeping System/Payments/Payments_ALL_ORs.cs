using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JunX.NET8.MySQL;
using BBHRKS.Global;
using BBHRKS.MySQL;
using MySql.Data.MySqlClient;

namespace BBH_Records_Keeping_System
{
    public partial class Payments_ALL_ORs : Form
    {
        DBConnect DBC;

        public Payments_ALL_ORs()
        {
            InitializeComponent();
        }

        #region PRIVATE FUNCTIONS
        private void ClearForm()
        {
            txtSearch.Text = "";
            lstTenants.Items.Clear();
            dgvBills.DataSource = null;
        }
        private void FillTenantsList()
        {
            lstTenants.Items.Clear();
            foreach (string item in Global.TenantsList)
                lstTenants.Items.Add(item);
        }
        #endregion

        private void Payments_ALL_ORs_Load(object sender, EventArgs e)
        {
            DBC = new DBConnect(Database.Connection);
            Global.Initialize(DBC);

            ClearForm();
            FillTenantsList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                lstTenants.Items.Clear();

                foreach (string item in Global.SearchTenantsList(txtSearch.Text))
                    lstTenants.Items.Add(item);
            }
            else
                FillTenantsList();
        }

        private void lstTenants_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstTenants.SelectedItems.Count > 0)
            {
                int tenantID = 0;
                string cmdStr = "";
                string tName = lstTenants.SelectedItem.ToString();

                DBC.CommandString = Construct.SelectCommand(
                    Select: tbtenants.TenantID.ToString(),
                    From: tbtenants.tbtenants.ToString(),
                    Where: tbtenants.FullName.ToString() + "='" + tName + "'");
                DBC.ExecuteReader();
                DBC.GetValues();
                tenantID = Convert.ToInt32(DBC.Values[0]);

                cmdStr = Construct.InnerJoinAliasCommand(
                    SelectWithAlias: new JoinMetadata[]
                    {
                        new JoinMetadata(
                            FromTable: tbbills.tbbills.ToString(),
                            SelectColumn: tbbills.DueDate.ToString(),
                            As: "Due Date"),
                        new JoinMetadata(
                            FromTable: tbbills.tbbills.ToString(),
                            SelectColumn: tbbills.BillNumber.ToString(),
                            As: "Invoice Number"),
                        new JoinMetadata(
                            FromTable: tbpayments.tbpayments.ToString(),
                            SelectColumn: tbpayments.ReceiptNumber.ToString(),
                            As: "Receipt Number") },
                    From: tbbills.tbbills.ToString(),
                    InnerJoin: tbpayments.tbpayments.ToString(),
                    OnLeft: new JoinMetadata(
                        FromTable: tbbills.tbbills.ToString(),
                        SelectColumn: tbbills.BillNumber.ToString()),
                    OnRight: new JoinMetadata(
                        FromTable: tbpayments.tbpayments.ToString(),
                        SelectColumn: tbpayments.BillNumber.ToString()),
                    Where:
                        tbbills.tbbills.ToString() + "." + tbbills.TenantID.ToString() +
                        "=" + tenantID);
                cmdStr = Construct.AppendOrderBy(
                    CommandString: cmdStr,
                    OrderBy: tbbills.tbbills.ToString() + "." + tbbills.DueDate.ToString(),
                    OrderMode: MySQLOrderBy.DESC);

                DBC.CommandString = cmdStr;
                DBC.ExecuteDataSet();
                dgvBills.DataSource = null;
                dgvBills.DataSource = DBC.DataSet.Tables[0];
            }
            else
                dgvBills.DataSource = null;
        }

        private void dgvBills_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ReceiptPreviewHelper.InvoiceNumber = dgvBills.SelectedCells[1].Value.ToString();
            Close();
        }

        private void Payments_ALL_ORs_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
