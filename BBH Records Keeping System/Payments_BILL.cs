using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BBHRKS.Interface;
using BBHRKS.Metadata;
using BBHRKS.Utilities;
using BBHRKS.MySQL;
using BBHRKS.Global;
using BBHRKS.Payments;
using MySql.Data.MySqlClient;
using JunX.NET8.MySQL;

namespace BBH_Records_Keeping_System
{
    public partial class Payments_BILL : Form
    {
        DBConnect DBC;
        int TenantID, LastReceipt;
        string TenantName, BillNumber;
        DateTime TransactionDT;

        public Payments_BILL()
        {
            InitializeComponent();
        }

        #region PRIVATE FUNCTIONS
        private void ClearForm()
        {
            Interface.ClearControlText(Interface.GetAllControls(this)
                .Where(c => c.Name.StartsWith("txt"))
                .ToList());
            Interface.ClearControlText(Interface.GetAllControls(this)
                .Where(c => c.Name.StartsWith("lbl"))
                .ToList());
        }
        private void ResetForm()
        {
            this.Text = "BBH Records Keeping System - Payments";
            grpSelectTenant.Enabled = true;
            Interface.SetControlEnabled(new Control[]
            {
                grpBillInformation,
                grpOverallInvoiceInformation,
                grpPaymentInformation,
                grpTransactionInformation,
                btnSave, }, false);

            TenantName = "";
            BillNumber = "";
            TransactionDT = DateTime.Now;
            TenantID = 0;
            LastReceipt = 0;
        }
        private void FillTenantsList()
        {
            lstTenants.Items.Clear();
            foreach (string item in Global.TenantsList)
                lstTenants.Items.Add(item);
        }
        private void FillPaymentMethod()
        {
            cmbPaymentMethod.Items.Clear();
            DBC.CommandString = Construct.SelectOrderByCommand(
                Select: tbpaymentmethod.Method.ToString(),
                From: tbpaymentmethod.tbpaymentmethod.ToString(),
                OrderBy: tbpaymentmethod.Method.ToString(),
                OrderMode: MySQLOrderBy.ASC,
                Where: tbpaymentmethod.Status.ToString() + "='Enabled'");
            DBC.ExecuteReader();
            DBC.GetValues();
            foreach (string item in DBC.Values)
                cmbPaymentMethod.Items.Add(item);
            cmbPaymentMethod.Text = "";
        }
        private void FillBillTypes()
        {
            cmbBillType.Items.Clear();

            foreach (string item in Metadata.Bills.BillTypes.Values)
                cmbBillType.Items.Add(item);
            cmbBillType.Text = "";
        }
        private void UpdateBillStatus(string updatedStatus)
        {
            if (cmbBillType.Text == Metadata.Bills.BillTypes.Water)
                DBC.CommandString = Construct.UpdateCommand(
                    Update: tbwaterbill.tbwaterbill.ToString(),
                    UpdateMetadata: new UpdateColumnMetadata[]
                    {
                        new UpdateColumnMetadata(
                            tbwaterbill.BillBalance.ToString(),
                            MySQLDataType.Double,
                            Payments.TransactionBalance.ToString()),
                        new UpdateColumnMetadata(
                            tbwaterbill.Status.ToString(),
                            MySQLDataType.VarChar,
                            updatedStatus) },
                    Where: tbwaterbill.BillNumber.ToString() + "='" + Payments.InvoiceNumber + "'");
            else if (cmbBillType.Text == Metadata.Bills.BillTypes.Electricity)
                DBC.CommandString = Construct.UpdateCommand(
                    Update: tbelectricitybill.tbelectricitybill.ToString(),
                    UpdateMetadata: new UpdateColumnMetadata[]
                    {
                        new UpdateColumnMetadata(
                            tbelectricitybill.BillBalance.ToString(),
                            MySQLDataType.Double,
                            Payments.TransactionBalance.ToString()),
                        new UpdateColumnMetadata(
                            tbelectricitybill.Status.ToString(),
                            MySQLDataType.VarChar,
                            updatedStatus) },
                    Where: tbelectricitybill.BillNumber.ToString() + "='" + Payments.InvoiceNumber + "'");
            else if (cmbBillType.Text == Metadata.Bills.BillTypes.Rental)
                DBC.CommandString = Construct.UpdateCommand(
                    Update: tbrentalbill.tbrentalbill.ToString(),
                    UpdateMetadata: new UpdateColumnMetadata[]
                    {
                        new UpdateColumnMetadata(
                            tbrentalbill.BillBalance.ToString(),
                            MySQLDataType.Double,
                            Payments.TransactionBalance.ToString()),
                        new UpdateColumnMetadata(
                            tbrentalbill.Status.ToString(),
                            MySQLDataType.VarChar,
                            updatedStatus) },
                    Where: tbrentalbill.BillNumber.ToString() + "='" + Payments.InvoiceNumber + "'");
            else if (cmbBillType.Text == Metadata.Bills.BillTypes.Internet)
                DBC.CommandString = Construct.UpdateCommand(
                    Update: tbinternetbill.tbinternetbill.ToString(),
                    UpdateMetadata: new UpdateColumnMetadata[]
                    {
                        new UpdateColumnMetadata(
                            tbinternetbill.BillBalance.ToString(),
                            MySQLDataType.Double,
                            Payments.TransactionBalance.ToString()),
                        new UpdateColumnMetadata(
                            tbinternetbill.Status.ToString(),
                            MySQLDataType.VarChar,
                            updatedStatus) },
                    Where: tbinternetbill.BillNumber.ToString() + "='" + Payments.InvoiceNumber + "'");

            if (cmbBillType.Text != "")
                DBC.ExecuteNonQuery();
        }
        private void NewDeductionRecord()
        {
            if (Payments.HasTransactionCredits)
            {
                DBC.CommandString = Construct.InsertIntoCommand(
                    InsertInto: tbdeductions.tbdeductions.ToString(),
                    InsertMetadata: new InsertColumnMetadata[]
                    {
                        new InsertColumnMetadata(
                            ToColumn: tbdeductions.TenantID.ToString(),
                            WithDataType: MySQLDataType.Double,
                            WithValue: Payments.TenantID.ToString()),
                        new InsertColumnMetadata(
                            tbdeductions.BillType.ToString(),
                            MySQLDataType.VarChar,
                            cmbBillType.Text),
                        new InsertColumnMetadata(
                            tbdeductions.UnusedCredits.ToString(),
                            MySQLDataType.Double,
                            Payments.Credits.ToString()) });
                DBC.ExecuteNonQuery();
            }
        }
        private void UpdateDeductionRecord()
        {
            if (Payments.HasTransactionCredits)
            {
                DBC.CommandString = Construct.UpdateCommand(
                Update: tbdeductions.tbdeductions.ToString(),
                UpdateMetadata: new UpdateColumnMetadata(
                    UpdateColumn: tbdeductions.UnusedCredits.ToString(),
                    WithDataType: MySQLDataType.Double,
                    SetValueTo: Payments.Credits.ToString()),
                Where:
                    tbdeductions.TenantID.ToString() + "=" + Payments.TenantID + " AND " +
                    tbdeductions.BillType.ToString() + "='" + cmbBillType.Text + "'");
                DBC.ExecuteNonQuery();
            }
        }
        #endregion

        private void Payments_BILL_Load(object sender, EventArgs e)
        {
            DBC = new DBConnect(Database.Connection);
            Global.Initialize(DBC);
            Payments.Initialize();

            ClearForm();
            ResetForm();
            FillTenantsList();
            FillPaymentMethod();
            FillBillTypes();
            Payments.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                //List<string> FTL = Global.SearchTenantsList(txtSearch.Text); //FTL = Filtered Tenants List
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
                Payments.TenantName = lstTenants.SelectedItem.ToString();

                if (Payments.InvoiceNumber == "")
                {
                    MessageBox.Show("No active invoice found.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Payments_BILL_Load(this, EventArgs.Empty);
                    return;
                }

                Payments.TransactionDT = DateTime.Now;
                lblTransactionDateTime.Text = Payments.TransactionDT.ToString("MMMM d, yyyy");
                lblInvoiceNumber.Text = Payments.InvoiceNumber;
                lblInvoiceDate.Text = Payments.InvoiceDate.ToString("MMMM d, yyyy");
                lblRentUtilitiesTotal.Text = Payments.RentUtilitiesTotal.ToString("0,0.00");
                lblInternetTotal.Text = Payments.InternetTotal.ToString("0,0.00");
                lblOverallTotal.Text = Payments.InvoiceOverallTotal.ToString("0,0.00");
                lblInvoiceStatus.Text = Payments.InvoiceStatus;
                lblTotalPaymentsReceived.Text = Payments.TotalPaymentsReceived.ToString("0,0.00");

                Interface.SetControlEnabled(new Control[]
                {
                    grpOverallInvoiceInformation,
                    grpTransactionInformation,
                    btnPrintAllOR }, true);
                grpSelectTenant.Enabled = false;
                this.Text = "BBH Records Keeping System - Payments - [" + Payments.TenantName.ToUpper() + "]";
            }
        }

        private void Payments_BILL_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void lblInvoiceStatus_TextChanged(object sender, EventArgs e)
        {
            if (lblInvoiceStatus.Text == Metadata.Bills.Status.Paid)
                lblInvoiceStatus.ForeColor = Color.DarkGreen;
            else if (lblInvoiceStatus.Text == Metadata.Bills.Status.Partial)
                lblInvoiceStatus.ForeColor = Color.Goldenrod;
            else if (lblInvoiceStatus.Text == Metadata.Bills.Status.Unpaid)
                lblInvoiceStatus.ForeColor = Color.Red;
            else
                lblInvoiceStatus.ForeColor = Color.Black;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Payments_BILL_Load(this, EventArgs.Empty);
        }

        private void lklGenerateOR_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtReceiptNumber.Text = Payments.GenerateOR();
        }

        private void btnConfirmOR_Click(object sender, EventArgs e)
        {
            if (txtReceiptNumber.Text == "")
            {
                MessageBox.Show("Please enter OR or Generate OR to proceed.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Payments.ORExists(txtReceiptNumber.Text))
            {
                MessageBox.Show("This OR already exists.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Payments.ORInUse = txtReceiptNumber.Text;

            grpBillInformation.Enabled = true;
            grpTransactionInformation.Enabled = false;
        }

        private void lblBillStatus_TextChanged(object sender, EventArgs e)
        {
            if (lblBillStatus.Text == Metadata.Bills.Status.Paid)
                lblBillStatus.ForeColor = Color.DarkGreen;
            else if (lblBillStatus.Text == Metadata.Bills.Status.Partial)
                lblBillStatus.ForeColor = Color.Goldenrod;
            else if (lblBillStatus.Text == Metadata.Bills.Status.Unpaid)
                lblBillStatus.ForeColor = Color.Red;
            else
                lblBillStatus.ForeColor = Color.Black;
        }

        private void cmbBillType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Payments.PaymentConfirmed = false;

            if (cmbBillType.Text != "")
            {
                Payments.SelectedBillType = cmbBillType.Text;

                lblBillDueDate.Text = Payments.SelectedBillDueDate.ToString("MMMM d, yyyy");
                lblPaymentsReceived.Text = Payments.SelectedBillPaymentsReceived.ToString("0,0.00");
                lblBillBalance.Text = Payments.SelectedBillBalance.ToString("0,0.00");
                lblBillStatus.Text = Payments.SelectedBillStatus;

                foreach (Control ctrl in grpPaymentInformation.Controls)
                {
                    if (ctrl.Name.StartsWith("lbl") && ctrl is Label)
                        ctrl.Text = "";

                    if (ctrl.Name.StartsWith("txt") && ctrl is TextBox)
                        ctrl.Text = "";

                    if (ctrl.Name.StartsWith("cmb") && ctrl is ComboBox)
                        FillPaymentMethod();
                }

                if (Payments.SelectedBillStatus == Metadata.Bills.Status.Paid)
                    grpPaymentInformation.Enabled = false;
                else
                    grpPaymentInformation.Enabled = true;
            }
            else
            {
                foreach (Control ctrl in grpBillInformation.Controls)
                {
                    if (ctrl.Name.StartsWith("lbl") && ctrl is Label)
                        ctrl.Text = "";
                }

                foreach (Control ctrl in grpPaymentInformation.Controls)
                {
                    if (ctrl.Name.StartsWith("lbl") && ctrl is Label)
                        ctrl.Text = "";

                    if (ctrl.Name.StartsWith("txt") && ctrl is TextBox)
                        ctrl.Text = "";

                    if (ctrl.Name.StartsWith("cmb") && ctrl is ComboBox)
                        FillPaymentMethod();
                }

                grpPaymentInformation.Enabled = false;
            }
        }

        private void btnConfirmAmountPaid_Click(object sender, EventArgs e)
        {
            if (Payments.ValidateAmountPaid(txtAmountPaid.Text) == false)
                return;

            if (cmbPaymentMethod.Text == "")
            {
                MessageBox.Show("Please select a payment method.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Payments.AmountPaid = Convert.ToDouble(txtAmountPaid.Text);
            Payments.PaymentMethod = cmbPaymentMethod.Text;
            Payments.PaymentConfirmed = true;
            Payments.CalculateAmounts();

            lblChange.Text = Payments.Change.ToString("0,0.00");
            lblTransactionBalance.Text = Payments.TransactionBalance.ToString("0,0.00");
            lblCredits.Text = Payments.Credits.ToString("0,0.00");
        }

        private void btnChangeToCredits_Click(object sender, EventArgs e)
        {
            Payments.ConvertChangeToCredits();
            lblChange.Text = Payments.Change.ToString("0,0.00");
            lblTransactionBalance.Text = Payments.TransactionBalance.ToString("0,0.00");
            lblCredits.Text = Payments.Credits.ToString("0,0.00");
        }

        private void btnCreditsToChange_Click(object sender, EventArgs e)
        {
            Payments.ConvertCreditsToChange();
            lblChange.Text = Payments.Change.ToString("0,0.00");
            lblTransactionBalance.Text = Payments.TransactionBalance.ToString("0,0.00");
            lblCredits.Text = Payments.Credits.ToString("0,0.00");
        }

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            if (Payments.PaymentSubmissionStatus == false)
            {
                MessageBox.Show("Please confirm Amount Paid in order to proceed.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string updatedStatus = Payments.EvaluateSelectedBillStatus();

            Payments.ReadyAmountPaidForInsert();

            //INSERT TO tbPayments
            DBC.CommandString = Construct.InsertIntoCommand(
                InsertInto: tbpayments.tbpayments.ToString(),
                InsertMetadata: new InsertColumnMetadata[]
                {
                    new InsertColumnMetadata(
                        ToColumn: tbpayments.ReceiptNumber.ToString(),
                        WithDataType: MySQLDataType.VarChar,
                        WithValue: Payments.ORInUse),
                    new InsertColumnMetadata(
                        ToColumn: tbpayments.BillNumber.ToString(),
                        WithDataType: MySQLDataType.VarChar,
                        WithValue: Payments.InvoiceNumber),
                    new InsertColumnMetadata(
                        ToColumn: tbpayments.TenantID.ToString(),
                        WithDataType: MySQLDataType.Int,
                        WithValue: Payments.TenantID.ToString()),
                    new InsertColumnMetadata(
                        ToColumn: tbpayments.BillType.ToString(),
                        WithDataType: MySQLDataType.VarChar,
                        WithValue: cmbBillType.Text),
                    new InsertColumnMetadata(
                        ToColumn: tbpayments.TransactionDateTime.ToString(),
                        WithDataType: MySQLDataType.DateTime,
                        WithValue: Payments.TransactionDT.ToString("yyyy-MM-dd HH:mm:ss")),
                    new InsertColumnMetadata(
                        ToColumn: tbpayments.AmountPaid.ToString(),
                        WithDataType: MySQLDataType.Double,
                        WithValue: Payments.AmountPaid.ToString()),
                    new InsertColumnMetadata(
                        ToColumn: tbpayments.TransactionBalance.ToString(),
                        WithDataType: MySQLDataType.Double,
                        WithValue: Payments.TransactionBalance.ToString()),
                    new InsertColumnMetadata(
                        ToColumn: tbpayments.PaymentMethod.ToString(),
                        WithDataType: MySQLDataType.VarChar,
                        WithValue: Payments.PaymentMethod)
                });
            DBC.ExecuteNonQuery();

            UpdateBillStatus(updatedStatus);

            if (Payments.HasDeductionRecord(cmbBillType.Text) == true)
                UpdateDeductionRecord();
            else
                NewDeductionRecord();



            lblRentUtilitiesTotal.Text = Payments.RentUtilitiesTotal.ToString("0,0.00");
            lblInternetTotal.Text = Payments.InternetTotal.ToString("0,0.00");
            lblOverallTotal.Text = Payments.InvoiceOverallTotal.ToString("0,0.00");
            lblInvoiceStatus.Text = Payments.InvoiceStatus;
            lblTotalPaymentsReceived.Text = Payments.TotalPaymentsReceived.ToString("0,0.00");

            string bt = cmbBillType.Text;
            cmbBillType.SelectedIndex = -1;
            cmbBillType.SelectedIndex = cmbBillType.FindStringExact(bt);

            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Payments.UpdateOverallBillStatus();
            Payments.UpdateLastOR();

            Interface.SetControlEnabled(new Control[]
            {
                grpTransactionInformation,
                grpOverallInvoiceInformation,
                grpBillInformation,
                grpPaymentInformation }, false);

            MessageBox.Show("Overall transaction saved.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult dr = MessageBox.Show("Print receipt?", Interface.MSGBOX_BBHRKS, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Payments_PREVIEW PPrev = new Payments_PREVIEW();
                ReceiptPreviewHelper.InvoiceNumber = Payments.GetInvoiceFromReceipt(Payments.ORInUse);
                ReceiptPreviewHelper.ReceiptNumber = Payments.ORInUse;
                ReceiptPreviewHelper.ForAllOR = false;
                PPrev.ShowDialog();
            }

            btnSave.Enabled = false;
        }

        private void btnPrintAllOR_Click(object sender, EventArgs e)
        {
            ReceiptPreviewHelper.InvoiceNumber = "";
            Payments_ALL_ORs PAO = new Payments_ALL_ORs();
            PAO.ShowDialog();

            if (ReceiptPreviewHelper.InvoiceNumber == "")
                return;

            ReceiptPreviewHelper.ReceiptNumber = "";
            ReceiptPreviewHelper.ForAllOR = true;

            Payments_PREVIEW Pprev = new Payments_PREVIEW();
            Pprev.ShowDialog();
        }
    }
}
