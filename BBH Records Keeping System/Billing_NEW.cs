using BBHRKS.Interface;
using BBHRKS.Metadata;
using BBHRKS.Utilities;
using MySql.Data.MySqlClient;
using JunX.NET8.MySQL;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;

namespace BBH_Records_Keeping_System
{
    public partial class Billing_New : Form
    {
        #region VARIABLES
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader reader;
        DBConnect DBC;
        int TenantID = 0;
        string InvoiceNumber = "";
        DateTime InvoiceDate = DateTime.Now;
        DateTime DueDate = DateTime.Now;
        DateTime InternetDueDate = DateTime.Now;
        double WaterSubtotal = 0, ElectricitySubtotal = 0, RentalSubtotal = 0, InternetSubtotal = 0;
        #endregion

        public Billing_New()
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
            this.Text = "BBH Records Keeping System - New Bill";
            tbcReadings.SelectedTab = tbpWaterReadings;
            tbcBillSummary.SelectedTab = tbpWaterBill;
            grpSelectTenant.Enabled = true;
            Interface.SetControlEnabled(new Control[]
                    {
                        txtWater_PresentReading,
                        txtWater_PreviousReading,
                        btnWater_ConfirmReading,
                        txtElectricity_PresentReading,
                        txtElectricity_PreviousReading,
                        btnElectricity_ConfirmReading
                    }, true);
            Interface.SetControlEnabled(new Control[]
            {
                grpBillInformation,
                tbcBillSummary,
                tbcReadings,
                btnReset,
                btnSave
            }, false);
        }
        private void FillListBox()
        {
            lstTenants.Items.Clear();

            DBC.CommandString = Construct.SelectOrderByCommand(
                Select: tbtenants.FullName.ToString(),
                From: "tbTenants",
                OrderBy: tbtenants.FullName.ToString(),
                OrderMode: MySQLOrderBy.ASC);
            DBC.ExecuteReader();
            DBC.GetValues();
            foreach (string item in DBC.Values)
                lstTenants.Items.Add(item);
        }
        private void ResetGlobalVariables()
        {
            TenantID = 0;
            InvoiceNumber = "";
            InvoiceDate = DateTime.Now;
            DueDate = DateTime.Now;
            InternetDueDate = DateTime.Now;
            WaterSubtotal = 0;
            ElectricitySubtotal = 0;
            RentalSubtotal = 0;
            InternetSubtotal = 0;
        }

        /// <summary>
        /// Retrieves the unique tenant ID from the database based on the provided tenant name.
        /// </summary>
        /// <param name="tenantName">The full name of the tenant to search for.</param>
        /// <remarks>
        /// This method constructs a parameterized SQL query to safely retrieve the <c>TenantID</c>
        /// from the <c>tbTenants</c> table where the <c>FullName</c> matches the given input.
        /// The result is read from the first column of the query result and stored in the <c>TenantID</c> field.
        /// </remarks>
        private void RetrieveTenantID(string tenantName)
        {
            DBC.CommandString = Construct.SelectCommand(
                Select: tbtenants.TenantID.ToString(),
                From: tbtenants.tbtenants.ToString(),
                Where: tbtenants.FullName.ToString() + "=@FullName");
            DBC.ExecuteReader(new ParametersMetadata("@FullName", tenantName));
            DBC.GetValues();
            TenantID = Convert.ToInt32(DBC.Values[0]);
        }
        /// <summary>
        /// Calculates the tenant's billing due date based on their original start date and the current invoice date.
        /// </summary>
        /// <remarks>
        /// The due date is determined by comparing the day of the tenant's start date with the day of the current invoice date.
        /// If the invoice day is greater than the start date day, the due date rolls over to the same day in the next month.
        /// Otherwise, the due date remains in the current month on the same day as the start date.
        /// The method automatically adjusts for variable month lengths and leap years to ensure valid dates.
        /// </remarks>
        private void CalculateDueDate()
        {
            DateTime startDate = DateTime.Now;
            int targetDay = 0;
            DateTime baseDate = new DateTime(InvoiceDate.Year, InvoiceDate.Month, 1);

            DBC.CommandString = Construct.SelectCommand(
                Select: tbtenants.StartDate.ToString(),
                From: tbtenants.tbtenants.ToString(),
                Where: tbtenants.TenantID.ToString() + "=@TenantID");
            DBC.ExecuteReader(new ParametersMetadata("@TenantID", TenantID.ToString()));
            if (DBC.HasRows)
            {
                DBC.GetValues();
                startDate = Convert.ToDateTime(DBC.Values[0]);
            }
            DBC.CloseReader();

            targetDay = startDate.Day;
            if (InvoiceDate.Day > targetDay)
                baseDate = baseDate.AddMonths(1);

            int maxDay = DateTime.DaysInMonth(baseDate.Year, baseDate.Month);
            targetDay = Math.Min(targetDay, maxDay);

            DueDate = new DateTime(baseDate.Year, baseDate.Month, targetDay);
        }
        /// <summary>
        /// Calculates the internet billing due date based on a predefined metadata value and the current invoice date.
        /// </summary>
        /// <remarks>
        /// This method retrieves the due day value from the metadata table (where <c>MID = 6</c>) and compares it to the day of the current invoice date.
        /// If the invoice day exceeds the metadata-defined due day, the due date is deferred to the same day in the next month.
        /// Otherwise, the due date remains in the current month.
        /// The method automatically adjusts for varying month lengths and leap years to ensure a valid calendar date.
        /// The result is stored in the <c>InternetDueDate</c> field.
        /// </remarks>
        private void CalculateInternetDueDate()
        {
            DateTime baseDate = new DateTime(InvoiceDate.Year, InvoiceDate.Month, 1);
            int iDD = 0;

            DBC.CommandString = Construct.SelectCommand(
                Select: tbmetadata.Value.ToString(),
                From: tbmetadata.tbmetadata.ToString(),
                Where: tbmetadata.MID.ToString() + "=6");
            DBC.ExecuteReader();
            DBC.GetValues();
            iDD = Convert.ToInt32(DBC.Values[0]);

            if (InvoiceDate.Day > iDD)
                baseDate = baseDate.AddMonths(1);

            int maxDay = DateTime.DaysInMonth(baseDate.Year, baseDate.Month);
            iDD = Math.Min(iDD, maxDay);

            InternetDueDate = new DateTime(baseDate.Year, baseDate.Month, iDD);
        }
        /// <summary>
        /// Retrieves the invoice number for the tenant's bill from the previous billing cycle.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> representing the last invoice number associated with the current <c>TenantID</c>
        /// and the due date one month prior to the current <c>DueDate</c>. Returns an empty string if no matching record is found.
        /// </returns>
        /// <remarks>
        /// This method constructs a SQL query to fetch the <c>BillNumber</c> from the <c>tbBills</c> table
        /// where both the <c>TenantID</c> and <c>DueDate</c> match the expected values.
        /// The due date is formatted as <c>yyyy-MM-dd</c> to ensure compatibility with SQL date comparisons.
        /// It safely checks for existing rows before attempting to read, preventing runtime exceptions.
        /// </remarks>
        private string GetLastInvoiceNumber()
        {
            DateTime lastDueDate = DueDate.AddMonths(-1);
            string lIN = "";

            DBC.CommandString = Construct.SelectCommand(
                Select: tbbills.BillNumber.ToString(),
                From: tbbills.tbbills.ToString(),
                Where:
                    tbbills.TenantID.ToString() + "=" + TenantID.ToString() + " AND " +
                    tbbills.DueDate.ToString() + "='" + lastDueDate.ToString("yyyy-MM-dd") + "'");
            DBC.ExecuteReader();
            if (DBC.HasRows)
            {
                DBC.GetValues();
                lIN = DBC.Values[0];
            }
            DBC.CloseReader();

            return lIN;
        }
        /// <summary>
        /// Retrieves the last recorded present reading value for a given invoice number and bill type.
        /// </summary>
        /// <param name="invoiceNumber">The invoice number associated with the utility bill record.</param>
        /// <param name="billType">
        /// The type of bill to query, either <c>"WATER"</c> or <c>"ELECTRICITY"</c>. Case-insensitive.
        /// Determines which table to query for the present reading.
        /// </param>
        /// <returns>
        /// A <see cref="double"/> representing the present reading value from the appropriate utility billing table.
        /// </returns>
        /// <remarks>
        /// This method constructs a SQL query to fetch the <c>PresentReading</c> field from either the <c>tbWaterBill</c>
        /// or <c>tbElectricityBill</c> table, depending on the specified <paramref name="billType"/>.
        /// The result is converted to a <c>double</c> and returned. Assumes the invoice number exists and the query returns a valid row.
        /// </remarks>
        private double GetLastPresentReading(string invoiceNumber, string billType)
        {
            double lPR = 0; //Last Present Reading


            if (billType == Metadata.Bills.BillTypes.Water)
            {
                DBC.CommandString = Construct.SelectCommand(
                Select: "PresentReading",
                From: tbwaterbill.tbwaterbill.ToString(),
                Where: "BillNumber=@BillNumber");
                DBC.ExecuteReader(new ParametersMetadata[]
                {
                    new ParametersMetadata("@BillNumber", invoiceNumber)
                });
            }
            else if (billType == Metadata.Bills.BillTypes.Electricity)
            {
                DBC.CommandString = Construct.SelectCommand(
                Select: "PresentReading",
                From: tbelectricitybill.tbelectricitybill.ToString(),
                Where: "BillNumber=@BillNumber");
                DBC.ExecuteReader(new ParametersMetadata[]
                {
                    new ParametersMetadata("@BillNumber", invoiceNumber)
                });
            }
            if (DBC.HasRows)
            {
                DBC.GetValues();
                lPR = Convert.ToDouble(DBC.Values[0]);
            }
            DBC.CloseReader();

            return lPR;
        }
        /// <summary>
        /// Calculates the total remaining balance for a specific bill type by summing unpaid and partially paid entries.
        /// </summary>
        /// <param name="billType">
        /// The type of bill to evaluate. Accepted values include <c>Water</c>, <c>Electricity</c>, <c>Rental</c>, and <c>Internet</c>,
        /// as defined in <see cref="Metadata.Bills.BillTypes"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/> representing the total remaining balance across all unpaid and partially paid bills of the specified type.
        /// </returns>
        /// <remarks>
        /// This method dynamically constructs a SQL query targeting the appropriate billing table based on <paramref name="billType"/>.
        /// It filters for records with a status of <c>Unpaid</c> or <c>Partial</c>, then sums:
        /// - <c>Subtotal</c> for unpaid bills
        /// - <c>BillBalance</c> for partially paid bills
        /// The result is returned as the total remaining balance. If no matching records are found, the result is zero.
        /// </remarks>
        private double GetRemainingBalance(string billType)
        {
            double rb = 0;

            if (billType == Metadata.Bills.BillTypes.Water)
                DBC.CommandString = Construct.SelectCommand(
                                Select: new string[] { "Subtotal", "BillBalance", "Status" },
                                From: tbwaterbill.tbwaterbill.ToString(),
                                Where:
                                    "TenantID=" + TenantID.ToString() + " AND " +
                                    "(Status='" + Metadata.Bills.Status.Unpaid + "' OR " +
                                    "Status='" + Metadata.Bills.Status.Partial + "')");
            else if (billType == Metadata.Bills.BillTypes.Electricity)
                DBC.CommandString = Construct.SelectCommand(
                                Select: new string[] { "Subtotal", "BillBalance", "Status" },
                                From: tbelectricitybill.tbelectricitybill.ToString(),
                                Where:
                                    "TenantID=" + TenantID.ToString() + " AND " +
                                    "(Status='" + Metadata.Bills.Status.Unpaid + "' OR " +
                                    "Status='" + Metadata.Bills.Status.Partial + "')");
            else if (billType == Metadata.Bills.BillTypes.Rental)
                DBC.CommandString = Construct.SelectCommand(
                                Select: new string[] { "Subtotal", "BillBalance", "Status" },
                                From: tbrentalbill.tbrentalbill.ToString(),
                                Where:
                                    "TenantID=" + TenantID.ToString() + " AND " +
                                    "(Status='" + Metadata.Bills.Status.Unpaid + "' OR " +
                                    "Status='" + Metadata.Bills.Status.Partial + "')");
            else if (billType == Metadata.Bills.BillTypes.Internet)
                DBC.CommandString = Construct.SelectCommand(
                                Select: new string[] { "Subtotal", "BillBalance", "Status" },
                                From: tbinternetbill.tbinternetbill.ToString(),
                                Where:
                                    "TenantID=" + TenantID.ToString() + " AND " +
                                    "(Status='" + Metadata.Bills.Status.Unpaid + "' OR " +
                                    "Status='" + Metadata.Bills.Status.Partial + "')");
            DBC.ExecuteReader();

            if (!DBC.HasRows)
            {
                DBC.CloseReader();
                return 0;
            }
            DBC.GetValues();
            if (DBC.Values[2] == Metadata.Bills.Status.Unpaid)
                rb += Convert.ToDouble(DBC.Values[0]);
            else if (DBC.Values[2] == Metadata.Bills.Status.Partial)
                rb += Convert.ToDouble(DBC.Values[1]);

            return rb;
        }
        /// <summary>
        /// Calculates the total deductions for a specific tenant and bill type by summing unused credits and advances.
        /// </summary>
        /// <param name="tenantID">The unique identifier of the tenant whose deductions are being retrieved.</param>
        /// <param name="billType">
        /// The type of bill to evaluate. Accepted values include <c>Water</c>, <c>Electricity</c>, <c>Rental</c>, and <c>Internet</c>,
        /// as defined in <see cref="Metadata.Bills.BillTypes"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/> representing the total deductions available for the specified tenant and bill type.
        /// This includes both unused credits and unused advances. Returns zero if no matching record is found.
        /// </returns>
        /// <remarks>
        /// This method dynamically constructs a SQL query targeting the <c>tbDeductions</c> table based on the provided <paramref name="billType"/>.
        /// It filters by <paramref name="tenantID"/> and bill type, then reads and sums the <c>UnusedCredits</c> and <c>UnusedAdvances</c> fields.
        /// </remarks>
        private double GetDeductions(int tenantID, string billType)
        {
            double d = 0;

            if (billType == Metadata.Bills.BillTypes.Water)
                DBC.CommandString = Generate.SelectCommand(
                    SelectColumns: new string[]
                    {
                        Database.Tables.tbDeductions.UnusedCredits.ToString(),
                        Database.Tables.tbDeductions.UnusedAdvances.ToString() },
                    FromTable: Database.Tables.tbDeductions.tbDeductions.ToString(),
                    WhereStatement:
                        Database.Tables.tbDeductions.TenantID.ToString() + "=" + tenantID.ToString() + " AND " +
                        Database.Tables.tbDeductions.BillType.ToString() + "='" + Metadata.Bills.BillTypes.Water + "'");
            else if (billType == Metadata.Bills.BillTypes.Electricity)
                DBC.CommandString = Generate.SelectCommand(
                    SelectColumns: new string[]
                    {
                        Database.Tables.tbDeductions.UnusedCredits.ToString(),
                        Database.Tables.tbDeductions.UnusedAdvances.ToString() },
                    FromTable: Database.Tables.tbDeductions.tbDeductions.ToString(),
                    WhereStatement:
                        Database.Tables.tbDeductions.TenantID.ToString() + "=" + tenantID.ToString() + " AND " +
                        Database.Tables.tbDeductions.BillType.ToString() + "='" + Metadata.Bills.BillTypes.Electricity + "'");
            else if (billType == Metadata.Bills.BillTypes.Rental)
                DBC.CommandString = Generate.SelectCommand(
                    SelectColumns: new string[]
                    {
                        Database.Tables.tbDeductions.UnusedCredits.ToString(),
                        Database.Tables.tbDeductions.UnusedAdvances.ToString() },
                    FromTable: Database.Tables.tbDeductions.tbDeductions.ToString(),
                    WhereStatement:
                        Database.Tables.tbDeductions.TenantID.ToString() + "=" + tenantID.ToString() + " AND " +
                        Database.Tables.tbDeductions.BillType.ToString() + "='" + Metadata.Bills.BillTypes.Rental + "'");
            else if (billType == Metadata.Bills.BillTypes.Internet)
                DBC.CommandString = Generate.SelectCommand(
                    SelectColumns: new string[]
                    {
                        Database.Tables.tbDeductions.UnusedCredits.ToString(),
                        Database.Tables.tbDeductions.UnusedAdvances.ToString() },
                    FromTable: Database.Tables.tbDeductions.tbDeductions.ToString(),
                    WhereStatement:
                        Database.Tables.tbDeductions.TenantID.ToString() + "=" + tenantID.ToString() + " AND " +
                        Database.Tables.tbDeductions.BillType.ToString() + "='" + Metadata.Bills.BillTypes.Internet + "'");

            if (billType != "")
            {
                DBC.ExecuteReader();
                reader = DBC.Reader;
                if (reader.HasRows)
                {
                    d += Convert.ToDouble(reader[0].ToString());
                    d += Convert.ToDouble(reader[1].ToString());
                }
                reader.Close();
                DBC.CloseReader();
            }

            return d;
        }
        /// <summary>
        /// Populates the rental bill subtotal by aggregating unpaid and partially paid additional charges,
        /// along with the fixed monthly rental due.
        /// </summary>
        /// <remarks>
        /// This method performs two key operations:
        /// <list type="number">
        ///   <item>
        ///     Queries the <c>tbAdditionals</c> table for the current tenant's records with a status of <c>Unpaid</c> or <c>Partial</c>.
        ///     It adds the full <c>TotalFee</c> for unpaid items and the <c>RemainingBalance</c> for partial items to the subtotal.
        ///     The result is displayed in <c>lblRental_Additionals</c>.
        ///   </item>
        ///   <item>
        ///     Retrieves the fixed monthly rental due value from the <c>tbMetadata</c> table (where <c>MID = 7</c>) and adds it to the subtotal.
        ///     This value is shown in <c>lblRental_MonthlyDue</c>.
        ///   </item>
        /// </list>
        /// The combined current charge (additionals + monthly due) is shown in <c>lblRental_CurrentCharge</c>,
        /// and the cumulative subtotal is reflected in <c>lblRentalBillSubtotal</c>.
        /// </remarks>
        private void FillRentalBill()
        {
            double adds = 0, mDue = 0;

            DBC.CommandString = Generate.SelectCommand(
                SelectColumns: new string[]
                {
                    Database.Tables.tbAdditionals.TotalFee.ToString(),
                    Database.Tables.tbAdditionals.RemainingBalance.ToString(),
                    Database.Tables.tbAdditionals.Status.ToString() },
                FromTable: Database.Tables.tbAdditionals.tbAdditionals.ToString(),
                WhereStatement:
                    "(" + Database.Tables.tbAdditionals.Status.ToString() + "='" + Metadata.Additionals.Status.Unpaid + "' OR " +
                    Database.Tables.tbAdditionals.Status.ToString() + "='" + Metadata.Additionals.Status.Partial + "') AND " +
                    Database.Tables.tbAdditionals.TenantID.ToString() + "=" + TenantID);
            DBC.ExecuteReader();
            reader = DBC.Reader;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader[2].ToString() == Metadata.Additionals.Status.Unpaid)
                        adds += Convert.ToDouble(reader[0].ToString());
                    else if (reader[2].ToString() == Metadata.Additionals.Status.Partial)
                        adds += Convert.ToDouble(reader[1].ToString());
                }
            }
            reader.Close();
            DBC.CloseReader();

            RentalSubtotal += adds;
            lblRental_Additionals.Text = adds.ToString("0,0.00");

            DBC.CommandString = Generate.SelectCommand(
                SelectColumn: Database.Tables.tbMetadata.Value.ToString(),
                FromTable: Database.Tables.tbMetadata.tbMetadata.ToString(),
                WhereStatement:
                    Database.Tables.tbMetadata.MID.ToString() + "=7");
            DBC.ExecuteReader();
            reader = DBC.Reader;
            reader.Read();
            mDue = Convert.ToDouble(reader[0].ToString());
            reader.Close();
            DBC.CloseReader();

            RentalSubtotal += mDue;
            lblRental_MonthlyDue.Text = mDue.ToString("0,0.00");

            lblRental_CurrentCharge.Text = (adds + mDue).ToString("0,0.00");
            lblRentalBillSubtotal.Text = RentalSubtotal.ToString("0,0.00");
        }
        /// <summary>
        /// Populates the internet billing fields by retrieving the tenant's subscribed plan and its corresponding fee.
        /// </summary>
        /// <remarks>
        /// This method performs the following operations:
        /// <list type="number">
        ///   <item>
        ///     Queries the <c>tbTenants</c> table to retrieve the internet plan assigned to the current tenant.
        ///   </item>
        ///   <item>
        ///     Uses the retrieved plan name to query the <c>tbInternetPlans</c> table and fetch the associated <c>PlanPrice</c>.
        ///   </item>
        ///   <item>
        ///     Adds the subscription fee to <c>InternetSubtotal</c> and updates the UI labels:
        ///     <c>lblInternet_Plan</c>, <c>lblInternet_SubscriptionFee</c>, <c>lblInternet_CurrentCharge</c>, and <c>lblInternetBillSubtotal</c>.
        ///   </item>
        /// </list>
        /// Assumes both queries return valid results. Consider adding error handling for missing or mismatched plan data to avoid runtime exceptions.
        /// </remarks>
        private void FillInternetBill()
        {
            double sFee = 0;
            string plan = "";

            DBC.CommandString = Generate.SelectCommand(
                SelectColumn: Database.Tables.tbTenants.InternetPlan.ToString(),
                FromTable: Database.Tables.tbTenants.tbTenants.ToString(),
                WhereStatement:
                    Database.Tables.tbTenants.TenantID.ToString() + "=" + TenantID.ToString());
            DBC.ExecuteReader();
            reader = DBC.Reader;
            plan = reader[0].ToString();
            reader.Close();
            DBC.CloseReader();

            DBC.CommandString = Generate.SelectCommand(
                SelectColumn: Database.Tables.tbInternetPlans.PlanPrice.ToString(),
                FromTable: Database.Tables.tbInternetPlans.tbInternetPlans.ToString(),
                WhereStatement:
                    Database.Tables.tbInternetPlans.Details.ToString() + "='" + plan + "'");
            DBC.ExecuteReader();
            reader = DBC.Reader;
            sFee = Convert.ToDouble(reader[0].ToString());
            reader.Close();
            DBC.CloseReader();

            InternetSubtotal += sFee;

            lblInternet_Plan.Text = plan;
            lblInternet_SubscriptionFee.Text = sFee.ToString("0,0.00");
            lblInternet_CurrentCharge.Text = sFee.ToString("0,0.00");
            lblInternetBillSubtotal.Text = InternetSubtotal.ToString("0,0.00");
        }
        /// <summary>
        /// Updates the <c>Status</c> column in the specified billing table
        /// from <c>Unpaid</c> or <c>Partial</c> to <c>Transferred</c>
        /// for the tenant identified by <see cref="TenantID"/>.
        /// </summary>
        /// <param name="billType">
        /// The billing category to update. Must match one of the constants in
        /// <c>Metadata.Bills.BillTypes</c> (e.g., <c>Water</c>, <c>Electricity</c>,
        /// <c>Rental</c>, <c>Internet</c>).
        /// </param>
        /// <remarks>
        /// <para>
        /// This method dynamically selects the target table based on <paramref name="billType"/>.
        /// It constructs an <c>UPDATE</c> statement using <c>Generate.UpdateCommand</c>
        /// and parameterized values to prevent SQL injection.
        /// </para>
        /// <para>
        /// The update affects only rows where:
        /// <list type="bullet">
        /// <item><description><c>TenantID</c> matches the provided value</description></item>
        /// <item><description><c>Status</c> is either <c>Unpaid</c> or <c>Partial</c></description></item>
        /// </list>
        /// </para>
        /// <para>
        /// After building the command, the method clears any existing parameters,
        /// binds the required values (<c>@TenantID</c>, <c>@Unpaid</c>, <c>@Partial</c>),
        /// and executes the update with <c>ExecuteNonQuery()</c>.
        /// </para>
        /// </remarks>
        /// <example>
        /// <code>
        /// // Mark all unpaid or partially paid water bills for tenant 123 as transferred
        /// SetUnpaidToTransferred(Metadata.Bills.BillTypes.Water);
        /// </code>
        /// </example>
        private void SetToTransferred(string billType)
        {
            if (billType == Metadata.Bills.BillTypes.Water)
            {
                DBC.CommandString = Generate.UpdateCommand(
                    "tbwaterbill",
                    new Generate.UpdateInfo[]
                    {
                        new Generate.UpdateInfo(
                            Column: tbwaterbill.Status.ToString(),
                            ColumnValue: Metadata.Bills.Status.Transferred,
                            ValueType: Generate.DataTypes.String) },
                    WhereStatement:
                        tbwaterbill.TenantID.ToString() + "=@TenantID  AND (" +
                        tbwaterbill.Status.ToString() + "=@Unpaid OR " +
                        tbwaterbill.Status.ToString() + "=@Partial)");
            }
            else if (billType == Metadata.Bills.BillTypes.Electricity)
            {
                DBC.CommandString = Generate.UpdateCommand(
                    "tbElectricityBill",
                    new Generate.UpdateInfo[]
                    {
                        new Generate.UpdateInfo(
                            Column: tbelectricitybill.Status.ToString(),
                            ColumnValue: Metadata.Bills.Status.Transferred,
                            ValueType: Generate.DataTypes.String) },
                    WhereStatement:
                        tbelectricitybill.TenantID.ToString() + "=@TenantID  AND (" +
                        tbelectricitybill.Status.ToString() + "=@Unpaid OR " +
                        tbelectricitybill.Status.ToString() + "=@Partial)");
            }
            else if (billType == Metadata.Bills.BillTypes.Rental)
            {
                DBC.CommandString = Generate.UpdateCommand(
                    "tbRentalBill",
                    new Generate.UpdateInfo[]
                    {
                        new Generate.UpdateInfo(
                            Column: tbrentalbill.Status.ToString(),
                            ColumnValue: Metadata.Bills.Status.Transferred,
                            ValueType: Generate.DataTypes.String) },
                    WhereStatement:
                        tbrentalbill.TenantID.ToString() + "=@TenantID  AND (" +
                        tbrentalbill.Status.ToString() + "=@Unpaid OR " +
                        tbrentalbill.Status.ToString() + "=@Partial)");
            }
            else if (billType == Metadata.Bills.BillTypes.Internet)
            {
                DBC.CommandString = Generate.UpdateCommand(
                    "tbInternetBill",
                    new Generate.UpdateInfo[]
                    {
                        new Generate.UpdateInfo(
                            Column: tbinternetbill.Status.ToString(),
                            ColumnValue: Metadata.Bills.Status.Transferred,
                            ValueType: Generate.DataTypes.String) },
                    WhereStatement:
                        tbinternetbill.TenantID.ToString() + "=@TenantID  AND (" +
                        tbinternetbill.Status.ToString() + "=@Unpaid OR " +
                        tbinternetbill.Status.ToString() + "=@Partial)");
            }
            DBC.ExecuteNonQuery(new ParametersMetadata[]
            {
                new ParametersMetadata("@TenantID", TenantID.ToString()),
                new ParametersMetadata("@Unpaid", Metadata.Bills.Status.Unpaid),
                new ParametersMetadata("@Partial", Metadata.Bills.Status.Partial) });
        }
        /// <summary>
        /// Clears unused financial deductions for the current tenant and specified billing type by updating the database.
        /// </summary>
        /// <param name="billType">
        /// The billing type used to filter the deduction record (e.g., "Monthly", "Advance", etc.).
        /// </param>
        /// <remarks>
        /// Constructs and executes an SQL <c>UPDATE</c> command targeting the <c>tbDeductions</c> table.  
        /// Sets <c>UnusedAdvances</c> and <c>UnusedCredits</c> to zero for the matching <c>TenantID</c> and <c>BillType</c>.  
        /// Parameters are cleared and reassigned before execution using <see cref="SetParameters(ParametersMetadata[])"/>.  
        /// This method assumes that <c>TenantID</c> is available in scope and that the <c>exec</c> instance is properly initialized.
        /// </remarks>
        /// <exception cref="Exception">
        /// Thrown if the update command fails to execute due to connection issues, invalid parameters, or SQL errors.
        /// </exception>
        private void ConsumeDeductions(string billType)
        {
            DBC.CommandString = Construct.UpdateCommand(
                Update: "tbDeductions",
                UpdateMetadata: new UpdateColumnMetadata[]
                {
                    new UpdateColumnMetadata(
                        UpdateColumn: tbdeductions.UnusedAdvances.ToString(),
                        WithDataType: MySQLDataType.Double,
                        SetValueTo: "0"),
                    new UpdateColumnMetadata(
                        UpdateColumn: tbdeductions.UnusedCredits.ToString(),
                        WithDataType: MySQLDataType.Double,
                        SetValueTo: "0") },
                Where:
                    tbdeductions.TenantID.ToString() + "=@TenantID AND " +
                    tbdeductions.BillType.ToString() + "=@BillType");
            DBC.ExecuteNonQuery(new ParametersMetadata[]
            {
                new ParametersMetadata("@TenantID", TenantID.ToString()),
                new ParametersMetadata("@BillType", billType) });
        }
        /// <summary>
        /// Saves a new water bill record to the corresponding table using the current form data and billing metadata.
        /// </summary>
        private void SaveWaterBill()
        {
            DBC.CommandString = Construct.InsertIntoCommand(
                "tbWaterBill",
                new InsertColumnMetadata[]
                {
                    new InsertColumnMetadata(
                        tbwaterbill.BillNumber.ToString(),
                        MySQLDataType.VarChar,
                        InvoiceNumber),
                    new InsertColumnMetadata(
                        tbwaterbill.TenantID.ToString(),
                        MySQLDataType.Int,
                        TenantID.ToString()),
                    new InsertColumnMetadata(
                        tbwaterbill.PreviousReading.ToString(),
                        MySQLDataType.Double,
                        txtWater_PreviousReading.Text),
                    new InsertColumnMetadata(
                        tbwaterbill.PresentReading.ToString(),
                        MySQLDataType.Double,
                        txtWater_PresentReading.Text),
                    new InsertColumnMetadata(
                        tbwaterbill.Consumption.ToString(),
                        MySQLDataType.Double,
                        Convert.ToDouble(lblWater_Consumption.Text).ToString()),
                    new InsertColumnMetadata(
                        tbwaterbill.CurrentCharge.ToString(),
                        MySQLDataType.Double,
                        Convert.ToDouble(lblWater_CurrentCharge.Text).ToString()),
                    new InsertColumnMetadata(
                        tbwaterbill.RemainingBalance.ToString(),
                        MySQLDataType.Double,
                        Convert.ToDouble(lblWater_Balance.Text).ToString()),
                    new InsertColumnMetadata(
                        tbwaterbill.Deductions.ToString(),
                        MySQLDataType.Double,
                        Convert.ToDouble(lblWater_Deductions.Text).ToString()),
                    new InsertColumnMetadata(
                        tbwaterbill.Subtotal.ToString(),
                        MySQLDataType.Double,
                        WaterSubtotal.ToString()),
                    new InsertColumnMetadata(
                        tbwaterbill.BillBalance.ToString(),
                        MySQLDataType.Double,
                        WaterSubtotal.ToString()),
                    new InsertColumnMetadata(
                        tbwaterbill.Status.ToString(),
                        MySQLDataType.VarChar,
                        Metadata.Bills.Status.Unpaid) });
            DBC.ExecuteNonQuery();
        }
        private void SaveElectricityBill()
        {
            DBC.CommandString = Construct.InsertIntoCommand(
                tbelectricitybill.tbelectricitybill.ToString(),
                new InsertColumnMetadata[]
                {
                    new InsertColumnMetadata(
                        tbelectricitybill.BillNumber.ToString(),
                        MySQLDataType.VarChar,
                        InvoiceNumber),
                    new InsertColumnMetadata(
                        tbelectricitybill.TenantID.ToString(),
                        MySQLDataType.Int,
                        TenantID.ToString()),
                    new InsertColumnMetadata(
                        tbelectricitybill.PreviousReading.ToString(),
                        MySQLDataType.Double,
                        txtElectricity_PreviousReading.Text),
                    new InsertColumnMetadata(
                        tbelectricitybill.PresentReading.ToString(),
                        MySQLDataType.Double,
                        txtElectricity_PresentReading.Text),
                    new InsertColumnMetadata(
                        tbelectricitybill.Consumption.ToString(),
                        MySQLDataType.Double,
                        Convert.ToDouble(lblElectricity_Consumption.Text).ToString()),
                    new InsertColumnMetadata(
                        tbelectricitybill.CurrentCharge.ToString(),
                        MySQLDataType.Double,
                        Convert.ToDouble(lblElectricity_CurrentCharge.Text).ToString()),
                    new InsertColumnMetadata(
                        tbelectricitybill.RemainingBalance.ToString(),
                        MySQLDataType.Double,
                        Convert.ToDouble(lblElectricity_Balance.Text).ToString()),
                    new InsertColumnMetadata(
                        tbelectricitybill.Deductions.ToString(),
                        MySQLDataType.Double,
                        Convert.ToDouble(lblElectricity_Deductions.Text).ToString()),
                    new InsertColumnMetadata(
                        tbelectricitybill.Subtotal.ToString(),
                        MySQLDataType.Double,
                        ElectricitySubtotal.ToString()),
                    new InsertColumnMetadata(
                        tbelectricitybill.BillBalance.ToString(),
                        MySQLDataType.Double,
                        ElectricitySubtotal.ToString()),
                    new InsertColumnMetadata(
                        tbelectricitybill.Status.ToString(),
                        MySQLDataType.VarChar,
                        Metadata.Bills.Status.Unpaid) });
            DBC.ExecuteNonQuery();
        }
        private void SaveInternetBill()
        {
            DBC.CommandString = Construct.InsertIntoCommand(
                InsertInto: tbinternetbill.tbinternetbill.ToString(),
                InsertMetadata: new InsertColumnMetadata[]
                {
                    new InsertColumnMetadata(
                        tbinternetbill.BillNumber.ToString(),
                        MySQLDataType.VarChar,
                        InvoiceNumber),
                    new InsertColumnMetadata(
                        tbinternetbill.TenantID.ToString(),
                        MySQLDataType.Int,
                        TenantID.ToString()),
                    new InsertColumnMetadata(
                        tbinternetbill.DueDate.ToString(),
                        MySQLDataType.Date,
                        InternetDueDate.ToString("yyyy-MM-dd")),
                    new InsertColumnMetadata(
                        tbinternetbill.Plan.ToString(),
                        MySQLDataType.VarChar,
                        lblInternet_Plan.Text),
                    new InsertColumnMetadata(
                        tbinternetbill.SubscriptionFee.ToString(),
                        MySQLDataType.Double,
                        Convert.ToDouble(lblInternet_SubscriptionFee.Text).ToString()),
                    new InsertColumnMetadata(
                        tbinternetbill.RemainingBalance.ToString(),
                        MySQLDataType.Double,
                        Convert.ToDouble(lblInternetBillSubtotal.Text).ToString()),
                    new InsertColumnMetadata(
                        tbinternetbill.Deductions.ToString(),
                        MySQLDataType.Double,
                        Convert.ToDouble(lblInternet_Deductions.Text).ToString()),
                    new InsertColumnMetadata(
                        tbinternetbill.Subtotal.ToString(),
                        MySQLDataType.Double,
                        InternetSubtotal.ToString()),
                    new InsertColumnMetadata(
                        tbinternetbill.BillBalance.ToString(),
                        MySQLDataType.Double,
                        InternetSubtotal.ToString()),
                    new InsertColumnMetadata(
                        tbinternetbill.Status.ToString(),
                        MySQLDataType.VarChar,
                        Metadata.Bills.Status.Unpaid) });
            DBC.ExecuteNonQuery();
        }
        private void SaveRentalBill()
        {
            DBC.CommandString = Construct.InsertIntoCommand(
                InsertInto: tbrentalbill.tbrentalbill.ToString(),
                InsertMetadata: new InsertColumnMetadata[]
                {
                    new InsertColumnMetadata(
                        tbrentalbill.BillNumber.ToString(),
                        MySQLDataType.VarChar,
                        InvoiceNumber),
                    new InsertColumnMetadata(
                        tbrentalbill.TenantID.ToString(),
                        MySQLDataType.Int,
                        TenantID.ToString()),
                    new InsertColumnMetadata(
                        tbrentalbill.MonthlyDue.ToString(),
                        MySQLDataType.Double,
                        Convert.ToDouble(lblRental_MonthlyDue.Text).ToString()),
                    new InsertColumnMetadata(
                        tbrentalbill.AdditionalCharges.ToString(),
                        MySQLDataType.Double,
                        Convert.ToDouble(lblRental_Additionals.Text).ToString()),
                    new InsertColumnMetadata(
                        tbrentalbill.CurrentCharges.ToString(),
                        MySQLDataType.Double,
                        Convert.ToDouble(lblRental_CurrentCharge.Text).ToString()),
                    new InsertColumnMetadata(
                        tbrentalbill.RemainingBalance.ToString(),
                        MySQLDataType.Double,
                        Convert.ToDouble(lblRental_Balance.Text).ToString()),
                    new InsertColumnMetadata(
                        tbrentalbill.Deductions.ToString(),
                        MySQLDataType.Double,
                        Convert.ToDouble(lblRental_Deductions.Text).ToString()),
                    new InsertColumnMetadata(
                        tbrentalbill.Subtotal.ToString(),
                        MySQLDataType.Double,
                        RentalSubtotal.ToString()),
                    new InsertColumnMetadata(
                        tbrentalbill.BillBalance.ToString(),
                        MySQLDataType.Double,
                        RentalSubtotal.ToString()),
                    new InsertColumnMetadata(
                        tbrentalbill.Status.ToString(),
                        MySQLDataType.VarChar,
                        Metadata.Bills.Status.Unpaid) });
            DBC.ExecuteNonQuery();
        }
        private void SaveOverallBill()
        {
            int WBID = 0, EBID = 0, RBID = 0, IBID = 0;

            DBC.CommandString = Construct.SelectCommand(
                Select: tbwaterbill.WaterBillID.ToString(),
                From: tbwaterbill.tbwaterbill.ToString(),
                Where: tbwaterbill.BillNumber.ToString() + "='" + InvoiceNumber + "'");
            DBC.ExecuteReader();
            DBC.GetValues();
            WBID = Convert.ToInt32(DBC.Values[0]);

            DBC.CommandString = Construct.SelectCommand(
                Select: tbelectricitybill.ElectricityBillID.ToString(),
                From: tbelectricitybill.tbelectricitybill.ToString(),
                Where: tbelectricitybill.BillNumber.ToString() + "='" + InvoiceNumber + "'");
            DBC.ExecuteReader();
            DBC.GetValues();
            EBID = Convert.ToInt32(DBC.Values[0]);

            DBC.CommandString = Construct.SelectCommand(
                Select: tbrentalbill.RentalBillID.ToString(),
                From: tbrentalbill.tbrentalbill.ToString(),
                Where: tbrentalbill.BillNumber.ToString() + "='" + InvoiceNumber + "'");
            DBC.ExecuteReader();
            DBC.GetValues();
            RBID = Convert.ToInt32(DBC.Values[0]);

            DBC.CommandString = Construct.SelectCommand(
                Select: tbinternetbill.InternetBillID.ToString(),
                From: tbinternetbill.tbinternetbill.ToString(),
                Where: tbinternetbill.BillNumber.ToString() + "='" + InvoiceNumber + "'");
            DBC.ExecuteReader();
            DBC.GetValues();
            IBID = Convert.ToInt32(DBC.Values[0]);

            DBC.CommandString = Construct.InsertIntoCommand(
                InsertInto: tbbills.tbbills.ToString(),
                InsertMetadata: new InsertColumnMetadata[]
                {
                    new InsertColumnMetadata(
                        tbbills.BillNumber.ToString(),
                        MySQLDataType.VarChar,
                        InvoiceNumber),
                    new InsertColumnMetadata(
                        tbbills.TenantID.ToString(),
                        MySQLDataType.Int,
                        TenantID.ToString()),
                    new InsertColumnMetadata(
                        tbbills.BillingDate.ToString(),
                        MySQLDataType.Date,
                        InvoiceDate.ToString("yyyy-MM-dd")),
                    new InsertColumnMetadata(
                        tbbills.DueDate.ToString(),
                        MySQLDataType.Date,
                        DueDate.ToString("yyyy-MM-dd")),
                    new InsertColumnMetadata(
                        tbbills.WaterBillID.ToString(),
                        MySQLDataType.Int,
                        WBID.ToString()),
                    new InsertColumnMetadata(
                        tbbills.ElectricityBillID.ToString(),
                        MySQLDataType.Int,
                        EBID.ToString()),
                    new InsertColumnMetadata(
                        tbbills.RentalBillID.ToString(),
                        MySQLDataType.Int,
                        RBID.ToString()),
                    new InsertColumnMetadata(
                        tbbills.InternetBillID.ToString(),
                        MySQLDataType.Int,
                        IBID.ToString()),
                    new InsertColumnMetadata(
                        tbbills.BillTotal.ToString(),
                        MySQLDataType.Double,
                        (WaterSubtotal + ElectricitySubtotal + RentalSubtotal + InternetSubtotal).ToString()),
                    new InsertColumnMetadata(
                        tbbills.Status.ToString(),
                        MySQLDataType.VarChar,
                        Metadata.Bills.Status.Unpaid) });
            DBC.ExecuteNonQuery();
        }
        #endregion

        private void btnBillPreview_Click(object sender, EventArgs e)
        {
            Utilities.BillPreview_SearchBillNumber = "";
            Utilities.SetBillPreviewMode = Utilities.BillPreviewMode.Preview;

            BillingPreview_SEARCH BPS = new BillingPreview_SEARCH();
            BPS.ShowDialog();

            if(Utilities.BillPreview_SearchBillNumber != "")
            {
                BillPreviewHelper.FromBillPreview = true;
                BillPreview_PREVIEW BPP = new BillPreview_PREVIEW();
                BPP.ShowDialog();
            }
        }

        private void Billing_New_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Billing_New_Load(object sender, EventArgs e)
        {
            DBC = new DBConnect(Database.Connection);
            Database.SetupMySQLCommandConnection(cmd, Database.Connection, CommandType.Text);
            cmd.Parameters.Clear();

            ClearForm();
            ResetForm();
            FillListBox();
            ResetGlobalVariables();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstTenants.Items.Clear();

            if (txtSearch.Text != "")
            {
                DBC.ConnectionString = Generate.SelectCommand(
                    SelectColumns: new string[] { Database.Tables.tbTenants.FullName.ToString() },
                    FromTable: Database.Tables.tbTenants.tbTenants.ToString(),
                    WhereStatement: Database.Tables.tbTenants.FullName.ToString() + " LIKE @Search",
                    SortColumn: Database.Tables.tbTenants.FullName.ToString(),
                    Sort: Generate.SortBy.Ascending);
                DBC.ExecuteReader(new ParametersMetadata("@Search", "%" + txtSearch.Text + "%"));
            }
            else
            {
                DBC.ConnectionString = Generate.SelectCommand(
                    SelectColumns: new string[] { Database.Tables.tbTenants.FullName.ToString() },
                    FromTable: Database.Tables.tbTenants.tbTenants.ToString(),
                    SortColumn: Database.Tables.tbTenants.FullName.ToString(),
                    Sort: Generate.SortBy.Ascending);
                DBC.ExecuteReader();
            }

            reader = DBC.Reader;
            while (reader.Read())
                lstTenants.Items.Add(reader[0].ToString());
            reader.Close();
            DBC.CloseReader();
        }

        private void lstTenants_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstTenants.SelectedIndex != -1)
            {
                string lastInvoiceNumber = "";
                string tStatus = ""; //Tenantcy Status

                RetrieveTenantID(lstTenants.SelectedItem.ToString());
                this.Text = "BBH Records Keeping System - New Bill - [" + lstTenants.SelectedItem.ToString().ToUpper() + "]";

                //Check TENANCY STATUS. Proceed if TENANCY STATUS == ACTIVE
                DBC.ConnectionString = Generate.SelectCommand(
                    SelectColumn: Database.Tables.tbTenants.Status.ToString(),
                    FromTable: Database.Tables.tbTenants.tbTenants.ToString(),
                    WhereStatement:
                        Database.Tables.tbTenants.TenantID.ToString() + "=" + TenantID.ToString());
                DBC.ExecuteReader();
                reader = DBC.Reader;
                reader.Read();
                tStatus = reader[0].ToString();
                reader.Close();
                DBC.CloseReader();
                if (tStatus == Metadata.Tenants.TenancyStatus.Inactive)
                {
                    MessageBox.Show("This tenant is INACTIVE.\nUnable to create bill.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Generate & Display INVOICE NUMBER
                InvoiceNumber = Utilities.GenerateInvoiceNumber(TenantID);
                lblInvoiceNumber.Text = InvoiceNumber;

                //Calculate & Display INVOICE DATE
                InvoiceDate = DateTime.Now;
                lblInvoiceDate.Text = InvoiceDate.ToString("MMMM d, yyyy");

                //Calculate & Display DUE DATE
                CalculateDueDate();
                lblInvoiceDueDate.Text = DueDate.ToString("MMMM d, yyyy");

                //Check if BILL EXISTS
                DBC.CommandString = Construct.SelectAllCommand(
                    From: tbbills.tbbills.ToString(),
                    Where:
                        tbbills.TenantID.ToString() + "=" + TenantID + " AND " +
                        tbbills.DueDate.ToString() + "='" + DueDate.ToString("yyyy-MM-dd") + "'");
                DBC.ExecuteReader();
                if (DBC.HasRows)
                {
                    MessageBox.Show("This tenant already have an existing bill for the upcoming due date.",
                        Interface.MSGBOX_BBHRKS,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Billing_New_Load(this, EventArgs.Empty);
                    DBC.CloseReader();
                    return;
                }
                DBC.CloseReader();

                //Retrieve, Calculate, & Display INTERNET DUE DATE
                CalculateInternetDueDate();
                lblInternet_DueDate.Text = InternetDueDate.ToString("MMMM d, yyyy");

                //Get INVOICE NUMBER of LATEST INVOICE
                lastInvoiceNumber = GetLastInvoiceNumber();

                //Get PRESENT WATER READING from LATEST INVOICE if exists
                if (lastInvoiceNumber != "")
                    txtWater_PreviousReading.Text = GetLastPresentReading(lastInvoiceNumber, Metadata.Bills.BillTypes.Water).ToString();

                //Get PRESENT ELECTRICITY READING from LATEST INVOICE if exists
                if (lastInvoiceNumber != "")
                    txtElectricity_PreviousReading.Text = GetLastPresentReading(lastInvoiceNumber, Metadata.Bills.BillTypes.Electricity).ToString();

                //Get REMAINING BALANCE for WATER BILL
                WaterSubtotal += GetRemainingBalance(Metadata.Bills.BillTypes.Water);
                lblWater_Balance.Text = GetRemainingBalance(Metadata.Bills.BillTypes.Water).ToString("0,0.00");

                //Get REMAINING BALANCE for ELECTRICITY BILL
                ElectricitySubtotal += GetRemainingBalance(Metadata.Bills.BillTypes.Electricity);
                lblElectricity_Balance.Text = GetRemainingBalance(Metadata.Bills.BillTypes.Electricity).ToString("0,0.00");

                //Get REMAINING BALANCE for RENTAL BILL
                RentalSubtotal += GetRemainingBalance(Metadata.Bills.BillTypes.Rental);
                lblRental_Balance.Text = GetRemainingBalance(Metadata.Bills.BillTypes.Rental).ToString("0,0.00");

                //Get REMAINING BALANCE for INTERNET BILL
                InternetSubtotal += GetRemainingBalance(Metadata.Bills.BillTypes.Internet);
                lblInternet_Balance.Text = GetRemainingBalance(Metadata.Bills.BillTypes.Internet).ToString("0,0.00");

                //Get WATER BILL DEDUCTIONS
                WaterSubtotal -= GetDeductions(TenantID, Metadata.Bills.BillTypes.Water);
                lblWater_Deductions.Text = GetDeductions(TenantID, Metadata.Bills.BillTypes.Water).ToString("0,0.00");

                //Get ELECTRICITY BILL DEDUCTIONS
                ElectricitySubtotal -= GetDeductions(TenantID, Metadata.Bills.BillTypes.Electricity);
                lblElectricity_Deductions.Text = GetDeductions(TenantID, Metadata.Bills.BillTypes.Electricity).ToString("0,0.00");

                //Get RENTAL BILL DEDUCTIONS
                RentalSubtotal -= GetDeductions(TenantID, Metadata.Bills.BillTypes.Rental);
                lblRental_Deductions.Text = GetDeductions(TenantID, Metadata.Bills.BillTypes.Rental).ToString("0,0.00");

                //Get INTERNET BILL DEDUCTIONS
                InternetSubtotal -= GetDeductions(TenantID, Metadata.Bills.BillTypes.Internet);
                lblInternet_Deductions.Text = GetDeductions(TenantID, Metadata.Bills.BillTypes.Internet).ToString("0,0.00");

                FillRentalBill();
                FillInternetBill();

                lblWater_Subtotal.Text = WaterSubtotal.ToString("0,0.00");
                lblWaterBillSubtotal.Text = WaterSubtotal.ToString("0,0.00");
                lblElectricity_Subtotal.Text = ElectricitySubtotal.ToString("0,0.00");
                lblElectricityBillSubtotal.Text = ElectricitySubtotal.ToString("0,0.00");
                lblRental_Subtotal.Text = RentalSubtotal.ToString("0,0.00");
                lblRentalBillSubtotal.Text = RentalSubtotal.ToString("0,0.00");
                lblInternet_Subtotal.Text = InternetSubtotal.ToString("0,0.00");
                lblInternetBillSubtotal.Text = InternetSubtotal.ToString("0,0.00");
                lblBillTotal.Text = (WaterSubtotal + ElectricitySubtotal + RentalSubtotal + InternetSubtotal).ToString("0,0.00");

                tbcReadings.SelectedTab = tbpWaterReadings;
                tbcBillSummary.SelectedTab = tbpWaterBill;
                Interface.SetControlEnabled(new Control[]
                {
                    tbcBillSummary,
                    tbcReadings,
                    grpBillInformation,
                    btnReset,
                    btnSave }, true);
                grpSelectTenant.Enabled = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Billing_New_Load(this, EventArgs.Empty);
        }

        private void btnWater_ConfirmReading_Click(object sender, EventArgs e)
        {
            if (txtWater_PresentReading.Text != "" && txtWater_PreviousReading.Text != "")
            {
                if (double.TryParse(txtWater_PresentReading.Text, out _) && double.TryParse(txtWater_PreviousReading.Text, out _))
                {
                    double presRead = Convert.ToDouble(txtWater_PresentReading.Text);
                    double prevRead = Convert.ToDouble(txtWater_PreviousReading.Text);
                    double currCharge = 0, unitPrice = 0, cons = 0;

                    if (presRead < 0 || prevRead < 0)
                    {
                        MessageBox.Show("Invalid input.\nReadings must be greater than 0.",
                            Interface.MSGBOX_BBHRKS,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    if (presRead < prevRead)
                    {
                        MessageBox.Show("Invalid input.\nPresent Reading must be greater than or equal to the Previous Reading.",
                            Interface.MSGBOX_BBHRKS,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    cons = presRead - prevRead;

                    DBC.ConnectionString = Generate.SelectCommand(
                        SelectColumn: Database.Tables.tbMetadata.Value.ToString(),
                        FromTable: Database.Tables.tbMetadata.tbMetadata.ToString(),
                        WhereStatement:
                            Database.Tables.tbMetadata.MID.ToString() + "=1");
                    DBC.ExecuteReader();
                    reader = DBC.Reader;
                    reader.Read();
                    unitPrice = Convert.ToDouble(reader[0].ToString());
                    reader.Close();
                    DBC.CloseReader();

                    currCharge = cons * unitPrice;
                    WaterSubtotal += currCharge;

                    lblWater_Previous.Text = prevRead.ToString();
                    lblWater_Present.Text = presRead.ToString();
                    lblWater_Consumption.Text = cons.ToString();
                    lblWater_CurrentCharge.Text = currCharge.ToString("0,0.00");
                    lblWater_Subtotal.Text = WaterSubtotal.ToString("0,0.00");
                    lblWaterBillSubtotal.Text = WaterSubtotal.ToString("0,0.00");
                    lblBillTotal.Text = (WaterSubtotal + ElectricitySubtotal + RentalSubtotal + InternetSubtotal).ToString("0,0.00");

                    Interface.SetControlEnabled(new Control[]
                    {
                        txtWater_PresentReading,
                        txtWater_PreviousReading,
                        btnWater_ConfirmReading }, false);
                }
                else
                    MessageBox.Show("Invalid input.", Interface.MSGBOX_BBHRKS,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Missing field.", Interface.MSGBOX_BBHRKS,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        private void btnElectricity_ConfirmReading_Click(object sender, EventArgs e)
        {
            if (txtElectricity_PresentReading.Text != "" && txtElectricity_PreviousReading.Text != "")
            {
                if (double.TryParse(txtElectricity_PresentReading.Text, out _) && double.TryParse(txtElectricity_PreviousReading.Text, out _))
                {
                    double presRead = Convert.ToDouble(txtElectricity_PresentReading.Text);
                    double prevRead = Convert.ToDouble(txtElectricity_PreviousReading.Text);
                    double currCharge = 0, unitPrice = 0, cons = 0;

                    if (presRead < 0 || prevRead < 0)
                    {
                        MessageBox.Show("Invalid input.\nReadings must be greater than 0.",
                            Interface.MSGBOX_BBHRKS,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    if (presRead < prevRead)
                    {
                        MessageBox.Show("Invalid input.\nPresent Reading must be greater than or equal to the Previous Reading.",
                            Interface.MSGBOX_BBHRKS,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    cons = presRead - prevRead;

                    DBC.ConnectionString = Generate.SelectCommand(
                        SelectColumn: Database.Tables.tbMetadata.Value.ToString(),
                        FromTable: Database.Tables.tbMetadata.tbMetadata.ToString(),
                        WhereStatement:
                            Database.Tables.tbMetadata.MID.ToString() + "=3");
                    DBC.ExecuteReader();
                    reader = DBC.Reader;
                    reader.Read();
                    unitPrice = Convert.ToDouble(reader[0].ToString());
                    reader.Close();
                    DBC.CloseReader();

                    currCharge = cons * unitPrice;
                    ElectricitySubtotal += currCharge;

                    lblElectricity_Previous.Text = prevRead.ToString();
                    lblElectricity_Present.Text = presRead.ToString();
                    lblElectricity_Consumption.Text = cons.ToString();
                    lblElectricity_CurrentCharge.Text = currCharge.ToString("0,0.00");
                    lblElectricity_Subtotal.Text = ElectricitySubtotal.ToString("0,0.00");
                    lblElectricityBillSubtotal.Text = ElectricitySubtotal.ToString("0,0.00");
                    lblBillTotal.Text = (WaterSubtotal + ElectricitySubtotal + RentalSubtotal + InternetSubtotal).ToString("0,0.00");

                    Interface.SetControlEnabled(new Control[]
                    {
                        txtElectricity_PresentReading,
                        txtElectricity_PreviousReading,
                        btnElectricity_ConfirmReading }, false);
                }
                else
                    MessageBox.Show("Invalid input.", Interface.MSGBOX_BBHRKS,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Missing field.", Interface.MSGBOX_BBHRKS,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnWater_ConfirmReading.Enabled == true || btnElectricity_ConfirmReading.Enabled == true)
            {
                MessageBox.Show("Please enter readings.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Update previous UNPAID/PARTIAL Bill Status to TRANSFERRED
            SetToTransferred(Metadata.Bills.BillTypes.Water);
            SetToTransferred(Metadata.Bills.BillTypes.Electricity);
            SetToTransferred(Metadata.Bills.BillTypes.Rental);
            SetToTransferred(Metadata.Bills.BillTypes.Internet);

            //Clear DEDUCTIONS
            ConsumeDeductions(Metadata.Bills.BillTypes.Water);
            ConsumeDeductions(Metadata.Bills.BillTypes.Electricity);
            ConsumeDeductions(Metadata.Bills.BillTypes.Rental);
            ConsumeDeductions(Metadata.Bills.BillTypes.Internet);

            //SAVE BILLS
            SaveWaterBill();
            SaveElectricityBill();
            SaveInternetBill();
            SaveRentalBill();
            SaveOverallBill();

            MessageBox.Show("Bill saved.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Billing_New_Load(this, EventArgs.Empty);
        }

        private void btnExportToPDF_Click(object sender, EventArgs e)
        {
            Utilities.BillPreview_SearchBillNumber = "";
            
            Utilities.SetBillPreviewMode = Utilities.BillPreviewMode.ExportToPDF;

            BillingPreview_SEARCH BPS = new BillingPreview_SEARCH();
            BPS.ShowDialog();

            if (Utilities.BillPreview_SearchBillNumber != "")
            {
                BillPreviewHelper.FromBillPreview = true;
                BillPreview_PREVIEW BPP = new BillPreview_PREVIEW();
                BPP.ShowDialog();
            }
        }
    }
}
