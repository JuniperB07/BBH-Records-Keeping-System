using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BBHRKS.Interface;
using BBHRKS.Metadata;
using BBHRKS.Utilities;
using JunX.NET8.MySQL;

namespace BBH_Records_Keeping_System
{
    public partial class BillingPreview_SEARCH : Form
    {
        private const string FormText = "BBH Records Keeping System - Billing - Bill Preview";
        DBConnect DBC;

        public BillingPreview_SEARCH()
        {
            InitializeComponent();
        }

        #region PRIVATE FUNCTION
        private void FillListBox()
        {
            lstTenants.Items.Clear();

            DBC.CommandString = Construct.SelectOrderByCommand(
                Select: tbtenants.FullName.ToString(),
                From: tbtenants.tbtenants.ToString(),
                OrderBy: tbtenants.FullName.ToString(),
                OrderMode: MySQLOrderBy.ASC);
            DBC.ExecuteReader();
            if (DBC.HasRows)
            {
                DBC.GetValues();
                foreach (string item in DBC.Values)
                    lstTenants.Items.Add(item);
            }
            DBC.CloseReader();
        }
        #endregion

        private void BillingPreview_SEARCH_Load(object sender, EventArgs e)
        {
            this.Text = FormText;
            DBC = new DBConnect(Database.Connection);

            txtSearch.Text = "";
            lstTenants.Items.Clear();
            dgvBills.DataSource = null;

            FillListBox();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstTenants.Items.Clear();

            if (txtSearch.Text != "")
            {
                DBC.CommandString = Construct.SelectOrderByCommand(
                    Select: tbtenants.FullName.ToString(),
                    From: tbtenants.tbtenants.ToString(),
                    OrderBy: tbtenants.FullName.ToString(),
                    OrderMode: MySQLOrderBy.ASC,
                    Where:
                        tbtenants.FullName.ToString() + " LIKE '%" + txtSearch.Text + "%'");
                DBC.ExecuteReader();
                DBC.GetValues();
                foreach (string item in DBC.Values)
                    lstTenants.Items.Add(item);
            }
            else
                FillListBox();
        }

        private void lstTenants_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstTenants.SelectedIndex != -1)
            {
                string tName = lstTenants.SelectedItem.ToString();
                int tID = 0;

                dgvBills.DataSource = null;

                DBC.CommandString = Construct.SelectCommand(
                    Select: tbtenants.TenantID.ToString(),
                    From: tbtenants.tbtenants.ToString(),
                    Where:
                        tbtenants.FullName.ToString() + "='" + tName + "'");
                DBC.ExecuteReader();
                DBC.GetValues();
                tID = Convert.ToInt32(DBC.Values[0]);

                DBC.CommandString = Construct.SelectAliasOrderByCommand(
                    AliasMetadata: new SelectAsMetadata[]
                    {
                        new SelectAsMetadata(
                            tbbills.DueDate.ToString(),
                            "Due Date"),
                        new SelectAsMetadata(
                            tbbills.BillNumber.ToString(),
                            "Bill Number") },
                    From: tbbills.tbbills.ToString(),
                    OrderBy: tbbills.DueDate.ToString(),
                    OrderMode: MySQLOrderBy.DESC,
                    Where:
                        tbbills.TenantID.ToString() + "=" + tID.ToString());
                DBC.ExecuteDataSet();
                dgvBills.DataSource = DBC.DataSet.Tables[0];
            }
        }

        private void dgvBills_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Utilities.BillPreview_SearchBillNumber = dgvBills.SelectedCells[1].Value.ToString();
            Close();
        }

        private void BillingPreview_SEARCH_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
