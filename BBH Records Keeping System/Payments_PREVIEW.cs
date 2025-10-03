using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using JunX.NET8.MySQL;
using BBHRKS.Reports;
using BBHRKS.Interface;
using MySql.Data.MySqlClient;

namespace BBH_Records_Keeping_System
{
    public partial class Payments_PREVIEW : Form
    {
        private ReportViewer rvReceipt = new ReportViewer();
        private DBConnect DBC;
        private ReportParameter[] rp;
        private MySqlDataAdapter adapter;
        private DataSet ds;
        private BBHRKS_Database BBHRKS_DB = new BBHRKS_Database();
        private ReportDataSource rds;

        public Payments_PREVIEW()
        {
            InitializeComponent();
        }

        #region PRIVATE FUNCTIONS
        private void InitializeReportViewer()
        {
            rvReceipt.Dock = DockStyle.Fill;
            rvReceipt.LocalReport.ReportPath = "ReceiptPreview.rdlc";
            rvReceipt.SetDisplayMode(DisplayMode.PrintLayout);
            rvReceipt.RefreshReport();
            this.Controls.Add(rvReceipt);
        }
        private void FillReceipt()
        {
            rp = new ReportParameter[]
            {
                new ReportParameter("prmTenantName", PaymentsPage1.TenantName),
                new ReportParameter("prmRoomNumber", PaymentsPage1.RoomNumber),
                new ReportParameter("prmTenancyStatus", PaymentsPage1.TenancyStatus),
                new ReportParameter("prmInvoiceNumber", PaymentsPage1.InvoiceNumber),
                new ReportParameter("prmNumeric_TotalAmountReceived", PaymentsPage1.Numeric_TotalAmountReceived.ToString("0,0.00")),
                new ReportParameter("prmWords_TotalAmountReceived", PaymentsPage1.Words_TotalAmountReceived),
                new ReportParameter("prmPaymentMethod", PaymentsPage1.PaymentMethod)
            };
        }
        private void LoadReceiptsData()
        {
            DBC.CommandString = Construct.SelectAllCommand(
                From: tbpaymentpreview_receipts.tbpaymentpreview_receipts.ToString());
            DBC.ExecuteAdapter();
            adapter = DBC.Adapter;
            adapter.Fill(BBHRKS_DB.tbpaymentpreview_receipts);
        }
        #endregion

        private void Payments_PREVIEW_Load(object sender, EventArgs e)
        {
            MSG_Processing MSG_P = new MSG_Processing();
            MSG_P.Show();
            Application.DoEvents();

            InitializeReportViewer();
            DBC = new DBConnect(Database.Connection);
            DBC.CommandString = Construct.TruncateCommand(
                Table: tbpaymentpreview_receipts.tbpaymentpreview_receipts.ToString());
            DBC.ExecuteNonQuery();

            PaymentsPage1.Connection = Database.Connection;
            PaymentsPage1.Initialize();
            PaymentsPage1.InvoiceNumber = ReceiptPreviewHelper.InvoiceNumber;
            PaymentsPage1.ReceiptNumber = ReceiptPreviewHelper.ReceiptNumber;
            PaymentsPage1.EnableAllInvoice = ReceiptPreviewHelper.ForAllOR;

            if (PaymentsPage1.ReceiptCount == 0)
            {
                MessageBox.Show("No transactions found for this invoice.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            FillReceipt();
            PaymentsPage1.PreparePaymentsPreviewTable();
            LoadReceiptsData();

            ds = new DataSet();
            adapter.Fill(ds);
            rds = new ReportDataSource("dsPaymentPreview_Receipts", ds.Tables[0]);

            rvReceipt.LocalReport.SetParameters(rp);
            rvReceipt.LocalReport.DataSources.Clear();
            rvReceipt.LocalReport.DataSources.Add(rds);
            rvReceipt.RefreshReport();

            this.Text = "BBH Records Keeping System - Receipt Preview [" + PaymentsPage1.TenantName + "]";

            MSG_P.Close();
        }

        private void Payments_PREVIEW_FormClosing(object sender, FormClosingEventArgs e)
        {
            DBC.CommandString = Construct.TruncateCommand(
                Table: tbpaymentpreview_receipts.tbpaymentpreview_receipts.ToString());
            DBC.ExecuteNonQuery();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
