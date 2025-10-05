using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using BBHRKS.Interface;
using BBHRKS.Metadata;
using BBHRKS.Utilities;
using BBHRKS.Reports;
using MySql.Data.MySqlClient;
using JunX.NET8.MySQL;

namespace BBH_Records_Keeping_System
{
    public partial class BillPreview_PREVIEW : Form
    {
        ReportViewer rvInvoice = new ReportViewer();
        ReportParameter[] rp;
        ReportParameter[] rpPage1, rpPage2, rpPage4, rpPage3;
        ReportDataSource rds;
        private BBHRKS_Database BBHRKS_DB = new BBHRKS_Database();
        MySqlDataAdapter adapter;
        DBConnect DBC;
        DataSet ds;
        int PG4Rows;

        public BillPreview_PREVIEW()
        {

            InitializeComponent();
        }

        #region PRIVATE FUNCTIONS
        private void InitializeReportViewer()
        {
            rvInvoice.Dock = DockStyle.Fill;
            rvInvoice.LocalReport.ReportPath = @"Billing\BillPreview.rdlc";
            rvInvoice.SetDisplayMode(DisplayMode.PrintLayout);
            rvInvoice.RefreshReport();
            this.Controls.Add(rvInvoice);
        }
        private void FillPage1()
        {
            rpPage1 = new ReportParameter[]
            {
                new ReportParameter("prmTenantName", InvoicePage1.TenantName),
                new ReportParameter("prmRoom", InvoicePage1.Room),
                new ReportParameter("prmRentType", InvoicePage1.RentType),
                new ReportParameter("prmTenancyStatus", InvoicePage1.TenancyStatus),
                new ReportParameter("prmInvoiceNumber", InvoicePage1.InvoiceNumber),
                new ReportParameter("prmInvoiceDate", InvoicePage1.InvoiceDate.ToString("MMMM d, yyyy")),
                new ReportParameter("prmDueDate", InvoicePage1.DueDate.ToString("MMMM d, yyyy")),
                new ReportParameter("prmPreviousBillTotal", InvoicePage1.PreviousBillTotal.ToString("0,0.00")),
                new ReportParameter("prmPreviousPaymentsReceived", "(" + InvoicePage1.PreviousPaymentsReceived.ToString("0,0.00") + ")"),
                new ReportParameter("prmSummary_Balance", InvoicePage1.PreviousBillBalance.ToString("0,0.00")),
                new ReportParameter("prmSummary_RentUtilitiesCharges", InvoicePage1.RentalUtilitiesCharges.ToString("0,0.00")),
                new ReportParameter("prmSummary_InternetCharges", InvoicePage1.InternetCharges.ToString("0,0.00")),
                new ReportParameter("prmSummary_TotalCurrentCharges", InvoicePage1.TotalCurrentCharges.ToString("0,0.00")),
                new ReportParameter("prmSummary_InternetDueDate", InvoicePage1.InternetDueDate.ToString("MMMM d, yyyy")),
                new ReportParameter("prmTotalAmountDue", InvoicePage1.TotalAmountDue.ToString("0,0.00")),
            };
        }
        private void FillPage2()
        {
            rpPage2 = new ReportParameter[]
            {
                new ReportParameter("prmPG2_PreviousWaterCharges", InvoicePage2.PreviousWaterCharges.ToString("0,0.00")),
                new ReportParameter("prmPG2_PreviousWaterPayments", "(" + InvoicePage2.PreviousWaterPayments.ToString("0,0.00") + ")"),
                
                new ReportParameter("prmPG2_PreviousElectricityCharges", InvoicePage2.PreviousElectricityCharges.ToString("0,0.00")),
                new ReportParameter("prmPG2_PreviousElectricityPayments", "(" + InvoicePage2.PreviousElectricityPayments.ToString("0,0.00") + ")"),
               
                new ReportParameter("prmPG2_PreviousRentalCharges", InvoicePage2.PreviousRentalCharges.ToString("0,0.00")),
                new ReportParameter("prmPG2_PreviousRentalPayments", "(" + InvoicePage2.PreviousRentalPayments.ToString("0,0.00") + ")"),
                
                new ReportParameter("prmPG2_PreviousInternetCharges", InvoicePage2.PreviousInternetCharges.ToString("0,0.00")),
                new ReportParameter("prmPG2_PreviousInternetPayments", "(" + InvoicePage2.PreviousInternetPayments.ToString("0,0.00") + ")"),
                
                new ReportParameter("prmPG2_PreviousBalance", InvoicePage2.PreviousBalance.ToString("0,0.00")),
                
                new ReportParameter("prmPG2_WaterPreviousReading", InvoicePage2.WaterPreviousReading.ToString()),
                new ReportParameter("prmPG2_WaterPresentReading", InvoicePage2.WaterPresentReading.ToString()),
                new ReportParameter("prmPG2_WaterConsumption", InvoicePage2.WaterConsumption),
                new ReportParameter("prmPG2_WaterConsumptionCharge", InvoicePage2.WaterConsumptionCharge.ToString("0,0.00")),
                new ReportParameter("prmPG2_WaterDeductions", "(" + InvoicePage2.WaterDeductions.ToString("0,0.00") + ")"),
                new ReportParameter("prmPG2_WaterAmountDue", InvoicePage2.WaterAmountDue.ToString("0,0.00")),
                
                new ReportParameter("prmPG2_ElectricityPreviousReading", InvoicePage2.ElectricityPreviousReading.ToString()),
                new ReportParameter("prmPG2_ElectricityPresentReading", InvoicePage2.ElectricityPresentReading.ToString()),
                new ReportParameter("prmPG2_ElectricityConsumption", InvoicePage2.ElectricityConsumption),
                new ReportParameter("prmPG2_ElectricityConsumptionCharge", InvoicePage2.ElectricityConsumptionCharge.ToString("0,0.00")),
                new ReportParameter("prmPG2_ElectricityDeductions", "(" + InvoicePage2.ElectricityDeductions.ToString("0,0.00") + ")"),
                new ReportParameter("prmPG2_ElectricityAmountDue", InvoicePage2.ElectricityAmountDue.ToString("0,0.00")),
                
                new ReportParameter("prmPG2_RentalMonthlyCharge", InvoicePage2.RentalMonthlyCharge.ToString("0,0.00")),
                new ReportParameter("prmPG2_RentalAdditionals", InvoicePage2.RentalAdditionals.ToString("0,0.00")),
                new ReportParameter("prmPG2_RentalDeductions", "(" + InvoicePage2.RentalDeductions.ToString("0,0.00") + ")"),
                new ReportParameter("prmPG2_RentalAmountDue", InvoicePage2.RentalAmountDue.ToString("0,0.00")),
                
                new ReportParameter("prmPG2_InternetPlan", InvoicePage2.InternetPlan),
                new ReportParameter("prmPG2_InternetMonthlyCharge", InvoicePage2.InternetMonthlyCharge.ToString("0,0.00")),
                new ReportParameter("prmPG2_InternetDeductions", "(" + InvoicePage2.InternetDeductions.ToString("0,0.00") + ")"),
                new ReportParameter("prmPG2_InternetAmountDue", InvoicePage2.InternetAmountDue.ToString("0,0.00"))
            };
        }
        private void FillPage3()
        {
            rpPage3 = new ReportParameter[]
            {
                new ReportParameter("prmPG3_AdditionalCharges", InvoicePage3.AdditionalCharges)
            };
        }
        private void FillPage4()
        {
            if(PG4Rows > 0)
            {
                rpPage4 = new ReportParameter[]
                {
                    new ReportParameter("prmPG4_PreviousBillNumber", InvoicePage4.PreviousBillNumber),
                    new ReportParameter("prmPG4_PreviousInvoiceDate", InvoicePage4.PreviousInvoiceDate.ToString("MMMM d, yyyy")),
                    new ReportParameter("prmPG4_PreviousDueDate", InvoicePage4.PreviousDueDate.ToString("MMMM d, yyyy")),
                    new ReportParameter("prmPG4_PreviousInvoiceStatus", InvoicePage4.PreviousInvoiceStatus),
                    new ReportParameter("prmPG4_TotalPaymentsReceived", InvoicePage4.TotalPaymentsReceived.ToString("0,0.00"))
                };
            }
            else
            {
                rpPage4 = new ReportParameter[]
                {
                    new ReportParameter("prmPG4_PreviousBillNumber", "N/A"),
                    new ReportParameter("prmPG4_PreviousInvoiceDate", "N/A"),
                    new ReportParameter("prmPG4_PreviousDueDate", "N/A"),
                    new ReportParameter("prmPG4_PreviousInvoiceStatus", "N/A"),
                    new ReportParameter("prmPG4_TotalPaymentsReceived", "N/A")
                };
            }
        }
        private void LoadReceiptsData()
        {
            DBC.CommandString = Construct.SelectAllCommand(
                From: tbbillpreview_receipts.tbbillpreview_receipts.ToString());
            DBC.ExecuteAdapter();
            adapter = DBC.Adapter;
            adapter.Fill(BBHRKS_DB.tbbillpreview_receipts);
        }
        #endregion

        private void Billing_PREVIEW_Load(object sender, EventArgs e)
        {
            MSG_Processing MSG_P = new MSG_Processing();
            MSG_P.Show();
            Application.DoEvents();

            InitializeReportViewer();
            this.WindowState = FormWindowState.Maximized;

            DBC = new DBConnect(Database.Connection);

            DBC.CommandString = Construct.TruncateCommand(tbbillpreview_receipts.tbbillpreview_receipts.ToString());
            DBC.ExecuteNonQuery();

            InvoicePage1.Connection = Database.Connection;
            InvoicePage1.Initialize();

            if (BillPreviewHelper.FromBillPreview == true)
                InvoicePage1.InvoiceNumber = Utilities.BillPreview_SearchBillNumber;
            else
                InvoicePage1.InvoiceNumber = BillPreviewHelper.InvoiceNumber;

            InvoicePage2.Initialize();
            InvoicePage3.Initialize();
            InvoicePage4.Initialize();
            InvoicePage4.FillBillPreviewReceiptsTable(out PG4Rows);

            FillPage1();
            FillPage2();
            FillPage3();
            FillPage4();
            LoadReceiptsData();

            rp = rpPage1
                .Concat(rpPage2)
                .Concat(rpPage3)
                .Concat(rpPage4)
                .ToArray();

            ds = new DataSet();
            adapter.Fill(ds);
            rds = new ReportDataSource("dsBillPreview_Receipts", ds.Tables[0]);
            
            if(Utilities.SetBillPreviewMode == Utilities.BillPreviewMode.ExportToPDF)
            {
                MSG_P.Close();
                Hide();
                ExportToPDFHelper.Parameters = rp;
                ExportToPDFHelper.DataSource = rds;
                BillPreview_EXPORT BPE = new BillPreview_EXPORT();
                BPE.ShowDialog();
                Close();
            }
            else
            {
                rvInvoice.LocalReport.SetParameters(rp);
                rvInvoice.LocalReport.DataSources.Clear();
                rvInvoice.LocalReport.DataSources.Add(rds);
                rvInvoice.RefreshReport();
            }

            MSG_P.Close();
        }

        private void Billing_PREVIEW_FormClosing(object sender, FormClosingEventArgs e)
        {
            DBC.CommandString = Construct.TruncateCommand(tbbillpreview_receipts.tbbillpreview_receipts.ToString());
            DBC.ExecuteNonQuery();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
