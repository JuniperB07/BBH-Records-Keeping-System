using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Reporting.WinForms;

namespace BBH_Records_Keeping_System
{
    internal static class ExportToPDFHelper
    {
        public static ReportParameter[] Parameters { get; set; }
        public static ReportDataSource DataSource { get; set; }
    }
}
