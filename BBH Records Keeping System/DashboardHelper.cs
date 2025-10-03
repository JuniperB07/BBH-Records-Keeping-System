using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBH_Records_Keeping_System
{
    internal static class DashboardHelper
    {
        internal struct UnpaidBills
        {
            internal int TenantID { get; set; }
            internal string TenantName { get; set; }
            internal DateTime DueDate { get; set; }
            internal double AmountDue { get; set; }
            internal string Status { get; set; }
            internal string BillNumber { get; set; }
            internal int DaysToDueDate
            {
                get
                {
                    TimeSpan days = DueDate.Date - DateTime.Now.Date;

                    //if (DueDate < DateTime.Now)
                    //    return days.Days;

                    return days.Days;
                }
            }

            internal UnpaidBills(int SetTenantID, string SetTenantName, DateTime SetDueDate, double SetAmountDue, string SetStatus, string SetBillNumber)
            {
                TenantID = SetTenantID;
                TenantName = SetTenantName;
                DueDate = SetDueDate;
                AmountDue = SetAmountDue;
                Status = SetStatus;
                BillNumber = SetBillNumber;
            }
        }
    }
}
