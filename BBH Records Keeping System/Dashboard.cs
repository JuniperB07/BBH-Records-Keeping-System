using BBHRKS.Interface;
using BBHRKS.Metadata;
using BBHRKS.MySQL;
using BBHRKS.Utilities;
using JunX.NET8.MySQL;
using JunX.NET8.WinForms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System.Data;

namespace BBH_Records_Keeping_System
{
    public partial class Dashboard : Form
    {
        DBConnect DBC;
        MySqlDataReader reader;
        MySqlDataAdapter adapter;
        DataSet dataset;
        int TenantID;

        public Dashboard()
        {
            InitializeComponent();
            Database.Initialize();
            
        }

        #region PRIVATE FUNCTIONS
        private void ClearTenantQuickView()
        {
            Forms.ClearControlText(Forms.ControlType<Label>.Extract(pnlTenantQuickView, "lbl"));
        }
        private void ResetTenantQuickViewPanel()
        {
            Forms.SetControlEnabled(Forms.ControlType<LinkLabel>.Extract(pnlTenantQuickView, "lkl"), false);

            TenantID = 0;
        }
        private void FillQuickViewComboBox()
        {
            cmbTenantsList.Items.Clear();

            DBC.CommandString = new SQLBuilder.SQLSelect()
                .Column(tbtenants.FullName.ToString())
                .From(tbtenants.tbtenants.ToString())
                .OrderBy(tbtenants.FullName.ToString(), MySQLOrderBy.ASC)
                .ToString();
            DBC.ExecuteReader();
            reader = DBC.Reader;
            while (reader.Read())
                cmbTenantsList.Items.Add(reader[0].ToString());
            reader.Close();
            DBC.CloseReader();

            cmbTenantsList.SelectedIndex = -1;
        }
        private void RefreshDataGrids()
        {
            List<DashboardHelper.UnpaidBills> UnpaidBills = new List<DashboardHelper.UnpaidBills>();
            string cmdSTR = "";

            cmdSTR = Construct.InnerJoinCommand(
                Select: new JoinMetadata[]
                {
                    new JoinMetadata(
                        FromTable: tbbills.tbbills.ToString(),
                        SelectColumn: tbbills.TenantID.ToString()),
                    new JoinMetadata(
                        tbtenants.tbtenants.ToString(),
                        tbtenants.FullName.ToString()),
                    new JoinMetadata(
                        tbbills.tbbills.ToString(),
                        tbbills.DueDate.ToString()),
                    new JoinMetadata(
                        tbbills.tbbills.ToString(),
                        tbbills.BillTotal.ToString()),
                    new JoinMetadata(
                        tbbills.tbbills.ToString(),
                        tbbills.Status.ToString()),
                    new JoinMetadata(
                        tbbills.tbbills.ToString(),
                        tbbills.BillNumber.ToString()) },
                From: tbbills.tbbills.ToString(),
                InnerJoin: tbtenants.tbtenants.ToString(),
                OnLeft: new JoinMetadata(
                    tbtenants.tbtenants.ToString(),
                    tbtenants.TenantID.ToString()),
                OnRight: new JoinMetadata(
                    tbbills.tbbills.ToString(),
                    tbbills.TenantID.ToString()),
                Where:
                    tbbills.tbbills.ToString() + "." + tbbills.Status.ToString() + "='" + Metadata.Bills.Status.Unpaid + "' OR " +
                    tbbills.tbbills.ToString() + "." + tbbills.Status.ToString() + "='" + Metadata.Bills.Status.Partial + "'");
            cmdSTR = Construct.AppendOrderBy(
                CommandString: cmdSTR,
                OrderBy: tbbills.DueDate.ToString(),
                OrderMode: MySQLOrderBy.DESC);

            DBC.CommandString = cmdSTR;
            DBC.ExecuteReader();
            reader = DBC.Reader;
            while (reader.Read())
            {
                UnpaidBills.Add(new DashboardHelper.UnpaidBills(
                    SetTenantID: Convert.ToInt32(reader[0].ToString()),
                    SetTenantName: reader[1].ToString(),
                    SetDueDate: Convert.ToDateTime(reader[2].ToString()),
                    SetAmountDue: Convert.ToDouble(reader[3].ToString()),
                    SetStatus: reader[4].ToString(),
                    SetBillNumber: reader[5].ToString()));
            }
            reader.Close();
            DBC.CloseReader();

            DBC.CommandString = Construct.TruncateCommand(tbdashboard_unpaidbills.tbdashboard_unpaidbills.ToString());
            DBC.ExecuteNonQuery();
            DBC.CommandString = Construct.TruncateCommand(tbdashboard_overdues.tbdashboard_overdues.ToString());
            DBC.ExecuteNonQuery();

            foreach (DashboardHelper.UnpaidBills UP in UnpaidBills)
            {
                if (UP.DaysToDueDate >= 0)
                {
                    DBC.CommandString = Construct.InsertIntoCommand(
                        InsertInto: tbdashboard_unpaidbills.tbdashboard_unpaidbills.ToString(),
                        InsertMetadata: new InsertColumnMetadata[]
                        {
                            new InsertColumnMetadata(
                                ToColumn: tbdashboard_unpaidbills.TenantName.ToString(),
                                WithDataType: MySQLDataType.VarChar,
                                WithValue: UP.TenantName),
                            new InsertColumnMetadata(
                                tbdashboard_unpaidbills.DaysToDueDate.ToString(),
                                MySQLDataType.Int,
                                UP.DaysToDueDate.ToString()),
                            new InsertColumnMetadata(
                                tbdashboard_unpaidbills.DueDate.ToString(),
                                MySQLDataType.DateTime,
                                UP.DueDate.ToString("yyyy-MM-dd")),
                            new InsertColumnMetadata(
                                tbdashboard_unpaidbills.AmountDue.ToString(),
                                MySQLDataType.Double,
                                UP.AmountDue.ToString()),
                            new InsertColumnMetadata(
                                tbdashboard_unpaidbills.Status.ToString(),
                                MySQLDataType.VarChar,
                                UP.Status),
                            new InsertColumnMetadata(
                                tbdashboard_unpaidbills.BillNumber.ToString(),
                                MySQLDataType.VarChar,
                                UP.BillNumber) });
                    DBC.ExecuteNonQuery();
                }
                else
                {
                    DBC.CommandString = Construct.InsertIntoCommand(
                        InsertInto: tbdashboard_overdues.tbdashboard_overdues.ToString(),
                        InsertMetadata: new InsertColumnMetadata[]
                        {
                            new InsertColumnMetadata(
                                ToColumn: tbdashboard_overdues.TenantName.ToString(),
                                WithDataType: MySQLDataType.VarChar,
                                WithValue: UP.TenantName),
                            new InsertColumnMetadata(
                                tbdashboard_overdues.DaysOverdue.ToString(),
                                MySQLDataType.Int,
                                Math.Abs(UP.DaysToDueDate).ToString()),
                            new InsertColumnMetadata(
                                tbdashboard_overdues.DueDate.ToString(),
                                MySQLDataType.DateTime,
                                UP.DueDate.ToString("yyyy-MM-dd")),
                            new InsertColumnMetadata(
                                tbdashboard_overdues.AmountDue.ToString(),
                                MySQLDataType.Double,
                                UP.AmountDue.ToString()),
                            new InsertColumnMetadata(
                                tbdashboard_overdues.Status.ToString(),
                                MySQLDataType.VarChar,
                                UP.Status),
                            new InsertColumnMetadata(
                                tbdashboard_overdues.BillNumber.ToString(),
                                MySQLDataType.VarChar,
                                UP.BillNumber) });
                    DBC.ExecuteNonQuery();
                }
            }

            DBC.CommandString = Construct.SelectAliasOrderByCommand(
                AliasMetadata: new SelectAsMetadata[]
                {
                    new SelectAsMetadata(
                        tbdashboard_unpaidbills.TenantName.ToString(),
                        "Tenant Name"),
                    new SelectAsMetadata(
                        tbdashboard_unpaidbills.DaysToDueDate.ToString(),
                        "Days to Due Date"),
                    new SelectAsMetadata(
                        tbdashboard_unpaidbills.DueDate.ToString(),
                        "Due Date"),
                    new SelectAsMetadata(
                        tbdashboard_unpaidbills.AmountDue.ToString(),
                        "Amount Due"),
                    new SelectAsMetadata(
                        tbdashboard_unpaidbills.Status.ToString(),
                        "Status"),
                    new SelectAsMetadata(
                        tbdashboard_unpaidbills.BillNumber.ToString(),
                        "Bill Number") },
                From: tbdashboard_unpaidbills.tbdashboard_unpaidbills.ToString(),
                OrderBy: tbdashboard_unpaidbills.DaysToDueDate.ToString(),
                OrderMode: MySQLOrderBy.DESC);
            DBC.ExecuteDataSet();
            dgvUnpaids.DataSource = null;
            dgvUnpaids.DataSource = DBC.DataSet.Tables[0];

            DBC.CommandString = Construct.SelectAliasOrderByCommand(
                AliasMetadata: new SelectAsMetadata[]
                {
                    new SelectAsMetadata(
                        tbdashboard_overdues.TenantName.ToString(),
                        "Tenant Name"),
                    new SelectAsMetadata(
                        tbdashboard_overdues.DaysOverdue.ToString(),
                        "Days Overdue"),
                    new SelectAsMetadata(
                        tbdashboard_overdues.DueDate.ToString(),
                        "Due Date"),
                    new SelectAsMetadata(
                        tbdashboard_overdues.AmountDue.ToString(),
                        "Amount Due"),
                    new SelectAsMetadata(
                        tbdashboard_overdues.Status.ToString(),
                        "Status"),
                    new SelectAsMetadata(
                        tbdashboard_overdues.BillNumber.ToString(),
                        "Bill Number") },
                From: tbdashboard_overdues.tbdashboard_overdues.ToString(),
                OrderBy: tbdashboard_overdues.DaysOverdue.ToString(),
                OrderMode: MySQLOrderBy.DESC);
            DBC.ExecuteDataSet();
            dgvOverdues.DataSource = null;
            dgvOverdues.DataSource = DBC.DataSet.Tables[0];
        }

        #endregion

        private void Dashboard_Load(object sender, EventArgs e)
        {
            Database.Initialize();
            DBC = new DBConnect(Database.Connection);

            LoginHelper.Allowed = false;
            LoginHelper.User = "";

            Hide();
            lblUserName.Text = LoginHelper.User;
            Login L = new Login();
            L.ShowDialog();

            if (LoginHelper.Allowed)
            {
                Show();
                lblUserName.Text = LoginHelper.User;
            }
            else
                Close();

            Forms.ClearControlText(new Control[] { lblDate, lblTime });
            Forms.ResetDataGridView(new DataGridView[] { dgvOverdues, dgvUnpaids });
            ClearTenantQuickView();
            FillQuickViewComboBox();
            ResetTenantQuickViewPanel();

            TenantID = 0;

            RefreshDataGrids();
        }

        private void tmrDateTime_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("MMMM d, yyyy");
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            Payments_MENU PM = new Payments_MENU();
            PM.ShowDialog();
            RefreshDataGrids();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            UserManagementHelper.Username = LoginHelper.User;
            User_MANAGEMENT UM = new User_MANAGEMENT();
            UM.ShowDialog();
        }

        private void btnTenants_Click(object sender, EventArgs e)
        {
            Utilities.TenantsMenu tm;
            tm = new Utilities.TenantsMenu(Utilities.TenantsMenuAction.None);
            Utilities.TMenuAction = tm;

            Tenants_MENU tenants_MENU = new Tenants_MENU();
            tenants_MENU.ShowDialog();

            if (Utilities.TMenuAction.Action != Utilities.TenantsMenuAction.None)
            {
                if (Utilities.TMenuAction.Action == Utilities.TenantsMenuAction.UpdateTenant)
                {
                    Tenants_UPDATE TU = new Tenants_UPDATE();
                    TU.ShowDialog();
                }
                else
                {
                    Tenants_NEW TN = new Tenants_NEW();
                    TN.ShowDialog();
                }
            }
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            DBC.CommandString = Construct.TruncateCommand(tbdashboard_overdues.tbdashboard_overdues.ToString());
            DBC.ExecuteNonQuery();
            DBC.CommandString = Construct.TruncateCommand(tbdashboard_unpaidbills.tbdashboard_unpaidbills.ToString());
            DBC.ExecuteNonQuery();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            Billing_MENU BM = new Billing_MENU();
            BM.ShowDialog();
            RefreshDataGrids();
        }

        private void cmbTenantsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTenantsList.SelectedIndex != -1)
            {
                if (cmbTenantsList.Text != "")
                {
                    int tid = 0;

                    DBC.CommandString = new SQLBuilder.SQLSelect()
                        .Column(tbtenants.TenantID.ToString())
                        .From(tbtenants.tbtenants.ToString())
                        .Where(tbtenants.FullName.ToString() + "='" + cmbTenantsList.Text + "'")
                        .ToString();
                    DBC.ExecuteReader();
                    DBC.GetValues();
                    tid = Convert.ToInt32(DBC.Values[0]);

                    DBC.CommandString = Construct.SelectCommand(
                        Select: new string[]
                        {
                            tbtenants.DateOfBirth.ToString(),
                            tbtenants.Phone.ToString(),
                            tbtenants.RentType.ToString(),
                            tbtenants.Room.ToString(),
                            tbtenants.StartDate.ToString(),
                            tbtenants.EndDate.ToString(),
                            tbtenants.InternetPlan.ToString(),
                            tbtenants.Status.ToString() },
                        From: tbtenants.tbtenants.ToString(),
                        Where: tbtenants.TenantID.ToString() + "=" + tid);
                    DBC.ExecuteReader();
                    DBC.GetValues();
                    lblDateOfBirth.Text = Convert.ToDateTime(DBC.Values[0]).ToString("MMM-d-yyyy");
                    lblPhone.Text = DBC.Values[1];
                    lblRentType.Text = DBC.Values[2].ToString();
                    lblRoom.Text = DBC.Values[3].ToString();
                    lblStartDate.Text = Convert.ToDateTime(DBC.Values[4]).ToString("MMM-d-yyyy");
                    lblInternetPlan.Text = DBC.Values[6];
                    lblTenancyStatus.Text = DBC.Values[7].ToString();

                    if (DBC.Values[2] == Metadata.Tenants.RentType.Fixed)
                        lblEndDate.Text = Convert.ToDateTime(DBC.Values[5]).ToString("MMM-d-yyyy");
                    else
                        lblEndDate.Text = "N/A";

                    DBC.CommandString = Construct.SelectCommand(
                        Select: new string[]
                        {
                            tbemergency.ContactPerson.ToString(),
                            tbemergency.Phone.ToString(),
                            tbemergency.Relationship.ToString() },
                        From: tbemergency.tbemergency.ToString(),
                        Where: tbemergency.TenantID.ToString() + "=" + tid);
                    DBC.ExecuteReader();
                    DBC.GetValues();
                    lblEmergency_ContactPerson.Text = DBC.Values[0];
                    lblEmergency_Phone.Text = DBC.Values[1];
                    lblRelationship.Text = DBC.Values[2];

                    TenantID = tid;
                    Interface.SetControlEnabled(new Control[]
                    {
                        lklEmergency_Copy,
                        lklTenant_Copy,
                        lklViewEmergencyAddress,
                        lklViewTenantAddress }, true);
                }
            }
            else
                ResetTenantQuickViewPanel();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ClearTenantQuickView();
            FillQuickViewComboBox();
            ResetTenantQuickViewPanel();
        }

        private void lklTenant_Copy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(lblPhone.Text);
            MessageBox.Show("Tenant's Phone/Email information copied to clipboard.",
                Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lklEmergency_Copy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(lblEmergency_Phone.Text);
            MessageBox.Show("Emergency Contact's Phone/Email information copied to clipboard.",
                Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lklViewTenantAddress_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DBC.CommandString = new SQLBuilder.SQLSelect()
                .Column(tbtenants.Address.ToString())
                .From(tbtenants.tbtenants.ToString())
                .Where(tbtenants.TenantID.ToString() + "=" + TenantID)
                .ToString();
            DBC.ExecuteReader();

            DialogResult dr = MessageBox.Show(
                "Tenant Address:\n" + DBC.Values[0] + "\n\nCopy?",
                Interface.MSGBOX_BBHRKS,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
                Clipboard.SetText(DBC.Values[0]);
        }

        private void lklViewEmergencyAddress_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DBC.CommandString = new SQLBuilder.SQLSelect()
                .Column(tbemergency.Address.ToString())
                .From(tbemergency.tbemergency.ToString())
                .Where(tbemergency.TenantID.ToString() + "=" + TenantID)
                .ToString();
            DBC.ExecuteReader();

            DialogResult dr = MessageBox.Show(
                "Emergency Address:\n" + DBC.Values[0] + "\n\nCopy?",
                Interface.MSGBOX_BBHRKS,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
                Clipboard.SetText(DBC.Values[0]);
        }

        private void tmrUnpaidUpdater_Tick(object sender, EventArgs e)
        {
            RefreshDataGrids();
        }

        private void dgvUnpaids_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BillPreviewHelper.FromBillPreview = false;
            BillPreviewHelper.InvoiceNumber = dgvUnpaids.SelectedCells[5].Value.ToString();
            BillPreview_PREVIEW BPP = new BillPreview_PREVIEW();
            BPP.ShowDialog();
        }

        private void dgvOverdues_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BillPreviewHelper.FromBillPreview = false;
            BillPreviewHelper.InvoiceNumber = dgvOverdues.SelectedCells[5].Value.ToString();
            BillPreview_PREVIEW BPP = new BillPreview_PREVIEW();
            BPP.ShowDialog();
        }

        private void pcbLogout_Click(object sender, EventArgs e)
        {
            Interface.ClearLabels(
                    new Label[]
                    {
                    lblDate,
                    lblTime });
            dgvOverdues.DataSource = null;
            dgvUnpaids.DataSource = null;
            ClearTenantQuickView();
            FillQuickViewComboBox();
            ResetTenantQuickViewPanel();

            TenantID = 0;

            LoginHelper.Allowed = false;
            LoginHelper.User = "";

            Hide();
            lblUserName.Text = LoginHelper.User;
            Login L = new Login();
            L.ShowDialog();

            if (LoginHelper.Allowed)
            {
                Show();
                lblUserName.Text = LoginHelper.User;
            }
            else
                Close();

            RefreshDataGrids();
        }
    }
}
