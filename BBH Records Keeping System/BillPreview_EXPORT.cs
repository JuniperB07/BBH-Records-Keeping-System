using BBHRKS.Interface;
using BBHRKS.Reports;
using BBHRKS.Utilities;
using Microsoft.Reporting.WinForms;
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
    public partial class BillPreview_EXPORT : Form
    {
        public BillPreview_EXPORT()
        {
            InitializeComponent();
        }

        private void BillPreview_EXPORT_Load(object sender, EventArgs e)
        {
            Show();
            Application.DoEvents();

            LocalReport invoice = new LocalReport
            {
                ReportPath = "BillPreview.rdlc"
            };

            invoice.SetParameters(ExportToPDFHelper.Parameters);
            invoice.DataSources.Clear();
            invoice.DataSources.Add(ExportToPDFHelper.DataSource);

            string outputPath = Utilities.GeneratePDFOutputPath(InvoicePage1.TenantName, InvoicePage1.DueDate);
            string mimeType, encoding, fileNameExtension;
            string[] streams;
            Warning[] warnings;

            byte[] pdfBytes = invoice.Render(
                "PDF",
                null,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            File.WriteAllBytes(outputPath, pdfBytes);

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer { Interval = 5000 };
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                if (File.Exists(outputPath))
                    MessageBox.Show("Invoice successfully exported to PDF.\nFile Path:\n\n" + outputPath, Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("An error ocurred while trying to export invoice to PDF.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            };
            timer.Start();
        }

        private void BillPreview_EXPORT_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
