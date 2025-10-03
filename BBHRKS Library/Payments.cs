using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using BBHRKS.Global;
using JunX.NET8.MySQL;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;
using Org.BouncyCastle.Pkcs;

namespace BBHRKS.Payments
{
    /// <summary>
    /// Provides functionalities and data for BBH Records Keeping System - Payments
    /// </summary>
    public static class Payments
    {
        private static DBConnect DBC;
        private static string _selectedBT; //For Set Propert: SelectedBillType
        private static double _change, _transactionBalance, _credits;
        private static bool _paymentConfirmed;

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets the name of the tenant associated with the current payment context.
        /// </summary>
        public static string TenantName { get; set; }
        /// <summary>
        /// Gets or sets the date and time of the current transaction within the payment context.
        /// </summary>
        /// <value>
        /// A <c>DateTime</c> representing when the transaction occurred.
        /// </value>
        public static DateTime TransactionDT { get; set; }
        /// <summary>
        /// Gets or sets the official receipt (OR) number currently in use for the active transaction.
        /// </summary>
        /// <value>
        /// A <c>string</c> representing the active OR number.
        /// </value>
        public static string ORInUse { get; set; }
        /// <summary>
        /// Gets or sets the amount paid for the current transaction.
        /// </summary>
        /// <value>
        /// A <c>double</c> representing the payment amount entered or processed.
        /// </value>
        public static double AmountPaid { get; set; }
        /// <summary>
        /// Gets or sets the selected payment method for the current transaction.
        /// </summary>
        /// <value>
        /// A <c>string</c> representing the payment method (e.g., Cash, GCash, Bank Transfer).
        /// </value>
        public static string PaymentMethod { get; set; }



        /// <summary>
        /// Retrieves the subtotal amount from the current bill overview in the payment context.
        /// </summary>
        /// <returns>
        /// A <c>double</c> representing the base amount of the bill before adjustments.
        /// </returns>
        public static double SelectedBillSubtotal { get { return GetBillOverview().Subtotal; } }
        /// <summary>
        /// Retrieves the remaining amount due from the current bill overview in the payment context.
        /// </summary>
        /// <returns>
        /// A <c>double</c> representing the bill's outstanding balance.
        /// </returns>
        public static double SelectedBillBalance { get { return GetBillOverview().Balance; } }
        /// <summary>
        /// Retrieves the current payment status from the active bill overview in the payment context.
        /// </summary>
        /// <returns>
        /// A <c>string</c> representing the bill's status (e.g., Unpaid, Partial, Paid).
        /// </returns>
        public static string SelectedBillStatus { get { return GetBillOverview().Status; } }
        /// <summary>
        /// Gets the due date of the currently selected bill based on the active invoice and bill type.
        /// </summary>
        /// <value>
        /// A <c>DateTime</c> representing the bill's due date.
        /// </value>
        public static DateTime SelectedBillDueDate { get { return GetBillOverview().DueDate; } }
        /// <summary>
        /// Computes the total amount due for the current invoice, including rent, utilities, and internet charges.
        /// </summary>
        /// <returns>
        /// A <c>double</c> representing the overall invoice subtotal.
        /// </returns>
        public static double InvoiceOverallTotal { get { return RentUtilitiesTotal + InternetTotal; } }
        /// <summary>
        /// Gets the credit amount available for the current transaction, typically used to offset future payments.
        /// </summary>
        /// <value>
        /// A <c>double</c> representing the available credit balance.
        /// </value>
        public static double Credits { get { return _credits; } }
        /// <summary>
        /// Gets the current change amount available for the transaction.
        /// </summary>
        /// <value>
        /// A <c>double</c> representing the excess amount paid, typically returned or convertible to credits.
        /// </value>
        public static double Change { get { return _change; } }
        /// <summary>
        /// Gets the remaining balance for the current transaction after applying the amount paid.
        /// </summary>
        /// <value>
        /// A <c>double</c> representing the unpaid portion of the bill, or zero if fully paid or overpaid.
        /// </value>
        public static double TransactionBalance { get { return _transactionBalance; } }
        /// <summary>
        /// Indicates whether the current payment has been successfully submitted and confirmed.
        /// </summary>
        /// <value>
        /// A <c>bool</c> representing the submission status of the payment.
        /// </value>
        public static bool PaymentSubmissionStatus { get { return _paymentConfirmed; } }


        /// <summary>
        /// Sets the active bill type used to determine payment context and data source.
        /// </summary>
        /// <value>
        /// A <c>string</c> representing the selected bill type (e.g., Water, Electricity, Rental, Internet).
        /// </value>
        public static string SelectedBillType { set { _selectedBT = value; } }
        /// <summary>
        /// Sets the confirmation status of the current payment transaction.
        /// </summary>
        /// <value>
        /// A <c>bool</c> indicating whether the payment has been confirmed.
        /// </value>
        public static bool PaymentConfirmed { set { _paymentConfirmed = value; } }


        /// <summary>
        /// Retrieves the last official receipt (OR) number from metadata and resets it to zero on January 1st if the stored OR year differs from the current transaction year.
        /// </summary>
        /// <returns>
        /// An <c>int</c> representing the last OR number, or zero if reset due to year change.
        /// </returns>
        public static int LastOR
        {
            get
            {
                int LOR = 0;

                DBC.CommandString = new SQLBuilder.SQLSelect()
                    .Column(tbmetadata.Value.ToString())
                    .From(tbmetadata.tbmetadata.ToString())
                    .Where(tbmetadata.MID.ToString() + "=5").ToString();
                DBC.ExecuteReader();
                DBC.GetValues();
                LOR = Convert.ToInt32(DBC.Values[0]);

                if(TransactionDT.Month == 1 && TransactionDT.Day == 1)
                {
                    int orYear = 0;

                    DBC.CommandString = new SQLBuilder.SQLSelect()
                        .Column(tbmetadata.Value.ToString())
                        .From(tbmetadata.tbmetadata.ToString())
                        .Where(tbmetadata.MID.ToString() + "=8").ToString();
                    DBC.ExecuteReader();
                    DBC.GetValues();
                    orYear = Convert.ToInt32(DBC.Values[0]);

                    if(orYear != TransactionDT.Year)
                    {
                        DBC.CommandString = Construct.UpdateCommand(
                            Update: tbmetadata.tbmetadata.ToString(),
                            UpdateMetadata: new UpdateColumnMetadata(
                                UpdateColumn: tbmetadata.Value.ToString(),
                                WithDataType: MySQLDataType.VarChar,
                                SetValueTo: TransactionDT.Year.ToString()),
                            Where: tbmetadata.MID.ToString() + "=8");
                        DBC.ExecuteNonQuery();

                        DBC.CommandString = Construct.UpdateCommand(
                            Update: tbmetadata.tbmetadata.ToString(),
                            UpdateMetadata: new UpdateColumnMetadata(
                                UpdateColumn: tbmetadata.Value.ToString(),
                                WithDataType: MySQLDataType.VarChar,
                                SetValueTo: "0"),
                            Where: tbmetadata.MID.ToString() + "=5");
                        DBC.ExecuteNonQuery();

                        LOR = 0;
                    }
                }

                return LOR;
            }
        }
        /// <summary>
        /// Retrieves the unique identifier of the tenant based on the current payment context.
        /// </summary>
        /// <returns>
        /// An <c>int</c> representing the tenant's ID, or <c>0</c> if no match is found.
        /// </returns>
        public static int TenantID
        {
            get
            {
                DBC.CommandString = new SQLBuilder.SQLSelect()
                    .Column(tbtenants.TenantID.ToString())
                    .From(tbtenants.tbtenants.ToString())
                    .Where(tbtenants.FullName.ToString() + "='" + TenantName + "'").ToString();

                DBC.ExecuteReader();
                if (DBC.HasRows)
                {
                    DBC.GetValues();
                    return Convert.ToInt32(DBC.Values[0]);
                }
                DBC.CloseReader();
                return 0;
            }
        }
        /// <summary>
        /// Retrieves the active invoice number associated with the current tenant in the payment context.
        /// </summary>
        /// <returns>
        /// A <c>string</c> representing the invoice number, or an empty string if no active invoice is found.
        /// </returns>
        public static string InvoiceNumber
        {
            get
            {
                DBC.CommandString = Construct.SelectCommand(
                    Select: tbbills.BillNumber.ToString(),
                    From: tbbills.tbbills.ToString(),
                    Where:
                        tbbills.TenantID.ToString() + "=" + TenantID + " AND (" +
                        tbbills.Status.ToString() + "='" + Metadata.Metadata.Bills.Status.Unpaid + "' OR " +
                        tbbills.Status.ToString() + "='" + Metadata.Metadata.Bills.Status.Partial + "')");
                DBC.ExecuteReader();
                if (DBC.HasRows)
                {
                    DBC.GetValues();
                    return DBC.Values[0];
                }
                DBC.CloseReader();
                return "";
            }
        }
        /// <summary>
        /// Retrieves the billing date associated with the current invoice in the payment context.
        /// </summary>
        /// <returns>
        /// A <c>DateTime</c> value representing the invoice date, or a default fallback if no invoice is available.
        /// </returns>
        public static DateTime InvoiceDate
        {
            get
            {
                if (InvoiceNumber == "")
                    return Convert.ToDateTime(Utilities.Utilities.DefaultDateFallback);

                DBC.CommandString = Construct.SelectCommand(
                    Select: tbbills.BillingDate.ToString(),
                    From: tbbills.tbbills.ToString(),
                    Where: tbbills.BillNumber.ToString() + "='" + InvoiceNumber + "'");
                DBC.ExecuteReader();
                DBC.GetValues();
                return Convert.ToDateTime(DBC.Values[0]);
            }
        }
        /// <summary>
        /// Gets the total amount received for the selected bill type and invoice by summing all recorded payments.
        /// </summary>
        /// <value>
        /// A <c>double</c> representing the cumulative payments received for the current bill.
        /// </value>
        public static double SelectedBillPaymentsReceived
        {
            get
            {
                MySqlDataReader reader;
                double SBPR = 0;

                DBC.CommandString = Construct.SelectCommand(
                    Select: tbpayments.AmountPaid.ToString(),
                    From: tbpayments.tbpayments.ToString(),
                    Where:
                        tbpayments.BillNumber.ToString() + "='" + InvoiceNumber + "' AND " +
                        tbpayments.BillType.ToString() + "='" + _selectedBT + "'");
                DBC.ExecuteReader();
                reader = DBC.Reader;
                while (reader.Read())
                    SBPR += Convert.ToDouble(reader[0].ToString());
                reader.Close();
                DBC.CloseReader();

                return SBPR;
            }
        }
        /// <summary>
        /// Computes the combined subtotal of water, electricity, and rental bills in the current payment context.
        /// </summary>
        /// <returns>
        /// A <c>double</c> representing the total amount for rent and utilities.
        /// </returns>
        public static double RentUtilitiesTotal
        {
            get
            {
                double RUT = 0;

                Payments.SelectedBillType = Metadata.Metadata.Bills.BillTypes.Water;
                RUT += Payments.SelectedBillSubtotal;

                Payments.SelectedBillType = Metadata.Metadata.Bills.BillTypes.Electricity;
                RUT += Payments.SelectedBillSubtotal;

                Payments.SelectedBillType = Metadata.Metadata.Bills.BillTypes.Rental;
                RUT += Payments.SelectedBillSubtotal;

                return RUT;
            }
        }
        /// <summary>
        /// Retrieves the subtotal amount of the internet bill in the current payment context.
        /// </summary>
        /// <returns>
        /// A <c>double</c> representing the base amount of the internet bill.
        /// </returns>
        public static double InternetTotal
        {
            get
            {
                SelectedBillType = Metadata.Metadata.Bills.BillTypes.Internet;
                return GetBillOverview().Subtotal;
            }
        }
        /// <summary>
        /// Retrieves the current payment status of the invoice from the billing records.
        /// </summary>
        /// <returns>
        /// A <c>string</c> representing the invoice status (e.g., Unpaid, Partial, Paid).
        /// </returns>
        public static string InvoiceStatus
        {
            get
            {
                DBC.CommandString = Construct.SelectCommand(
                    Select: tbbills.Status.ToString(),
                    From: tbbills.tbbills.ToString(),
                    Where: tbbills.BillNumber.ToString() + "='" + InvoiceNumber + "'");
                DBC.ExecuteReader();
                DBC.GetValues();
                return DBC.Values[0];
            }
        }
        /// <summary>
        /// Computes the total amount received across all bill types by subtracting balances from subtotals.
        /// </summary>
        /// <returns>
        /// A <c>double</c> representing the sum of payments received for water, electricity, rental, and internet bills.
        /// </returns>
        public static double TotalPaymentsReceived
        {
            get
            {
                double TPR = 0;

                SelectedBillType = Metadata.Metadata.Bills.BillTypes.Water;
                if (SelectedBillBalance == 0)
                    TPR += SelectedBillSubtotal;
                else if (SelectedBillBalance == SelectedBillSubtotal)
                    TPR += 0;
                else
                    TPR += SelectedBillSubtotal - SelectedBillBalance;

                SelectedBillType = Metadata.Metadata.Bills.BillTypes.Electricity;
                if (SelectedBillBalance == 0)
                    TPR += SelectedBillSubtotal;
                else if (SelectedBillBalance == SelectedBillSubtotal)
                    TPR += 0;
                else
                    TPR += SelectedBillSubtotal - SelectedBillBalance;

                SelectedBillType = Metadata.Metadata.Bills.BillTypes.Rental;
                if (SelectedBillBalance == 0)
                    TPR += SelectedBillSubtotal;
                else if (SelectedBillBalance == SelectedBillSubtotal)
                    TPR += 0;
                else
                    TPR += SelectedBillSubtotal - SelectedBillBalance;

                SelectedBillType = Metadata.Metadata.Bills.BillTypes.Internet;
                if (SelectedBillBalance == 0)
                    TPR += SelectedBillSubtotal;
                else if (SelectedBillBalance == SelectedBillSubtotal)
                    TPR += 0;
                else
                    TPR += SelectedBillSubtotal - SelectedBillBalance;

                return TPR;
            }
        }
        /// <summary>
        /// Indicates whether the current context has available transaction credits.
        /// </summary>
        /// <remarks>
        /// Returns <c>true</c> if the internal <c>_credits</c> value is greater than zero; otherwise, returns <c>false</c>.
        /// </remarks>
        /// <returns>
        /// <c>true</c> if transaction credits are available; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasTransactionCredits
        {
            get
            {
                if (_credits > 0)
                    return true;
                return false;
            }
        }
        #endregion

        #region PUBLIC FUNCTIONS
        /// <summary>
        /// Sets up the shared execution context for database operations using a global reference.
        /// </summary>
        public static void Initialize()
        {
            DBC = Global.Global.DBC;
            _credits = 0;
            _change = 0;
            _transactionBalance = 0;
            _paymentConfirmed = false;
        }
        /// <summary>
        /// Resets the current payment context by clearing the tenant name, setting the transaction timestamp to now, and resetting the selected bill type.
        /// </summary>
        public static void Clear()
        {
            TenantName = "";
            TransactionDT = DateTime.Now;
            SelectedBillType = "";
        }
        /// <summary>
        /// Generates a new official receipt (OR) number using the current transaction date and the next OR sequence.
        /// </summary>
        /// <returns>
        /// A <c>string</c> representing the formatted OR number in the pattern <c>BBH-PyyyyMM####</c>.
        /// </returns>
        public static string GenerateOR()
        {
            return "BBH-P" + TransactionDT.ToString("yyyyMM") + (LastOR + 1).ToString("0000");
        }
        /// <summary>
        /// Checks whether a given official receipt (OR) number already exists in the payments table.
        /// </summary>
        /// <param name="OR">The OR number to verify.</param>
        /// <returns>
        /// <c>true</c> if the OR number exists; otherwise, <c>false</c>.
        /// </returns>
        public static bool ORExists(string OR)
        {
            DBC.CommandString = Construct.SelectAllCommand(
                From: tbpayments.tbpayments.ToString(),
                Where: tbpayments.ReceiptNumber.ToString() + "='" + OR + "'");
            DBC.ExecuteReader();
            if (DBC.HasRows)
            {
                DBC.CloseReader();
                return true;
            }
            DBC.CloseReader();
            return false;
        }
        /// <summary>
        /// Validates the entered amount paid by checking for empty input, numeric format, and non-negative value.
        /// </summary>
        /// <param name="AmountPaidEntry">The string input representing the amount paid.</param>
        /// <returns>
        /// <c>true</c> if the input is a valid non-negative number; otherwise, <c>false</c>.
        /// </returns>
        public static bool ValidateAmountPaid(string AmountPaidEntry)
        {
            if (AmountPaidEntry == "")
            {
                MessageBox.Show("Invalid entry on: Amount Paid.", Interface.Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (double.TryParse(AmountPaidEntry, out _) == false)
            {
                MessageBox.Show("Invalid entry on: Amount Paid.", Interface.Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(Convert.ToDouble(AmountPaidEntry) <= 0)
            {
                MessageBox.Show("Invalid entry on: Amount Paid.", Interface.Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        /// <summary>
        /// Converts the current change amount into credits if the payment is confirmed and change is available.
        /// </summary>
        /// <remarks>
        /// Displays an error message if the payment has not been confirmed or if no change is available.
        /// </remarks>
        public static void ConvertChangeToCredits()
        {
            if(_paymentConfirmed == false)
            {
                MessageBox.Show("Confirm Amount Paid first.", Interface.Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(_change == 0)
            {
                MessageBox.Show("No change to convert.", Interface.Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _credits = _change;
            _change = 0;
        }
        /// <summary>
        /// Converts the available credits into change if the payment is confirmed and credits are present.
        /// </summary>
        /// <remarks>
        /// Displays an error message if the payment has not been confirmed or if no credits are available.
        /// </remarks>
        public static void ConvertCreditsToChange()
        {
            if (_paymentConfirmed == false)
            {
                MessageBox.Show("Confirm Amount Paid first.", Interface.Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(_credits == 0)
            {
                MessageBox.Show("No credits to convert.", Interface.Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _change = _credits;
            _credits = 0;
        }
        /// <summary>
        /// Calculates the change and transaction balance based on the amount paid and bill subtotal.
        /// </summary>
        /// <remarks>
        /// Sets change if the amount paid exceeds the subtotal, or transaction balance if underpaid.
        /// Resets credits to zero on each invocation.
        /// </remarks>
        public static void CalculateAmounts()
        {
            if(AmountPaid >= SelectedBillSubtotal)
            {
                _change = AmountPaid - SelectedBillBalance;
                _transactionBalance = 0;
            }
            else if( AmountPaid > 0 && AmountPaid < SelectedBillBalance)
            {
                _transactionBalance = SelectedBillSubtotal - AmountPaid;
                _change = 0;
            }

            _credits = 0;
        }
        /// <summary>
        /// Prepares the payment amount for insertion by capping it to the bill balance if necessary.
        /// </summary>
        /// <remarks>
        /// Ensures that the recorded payment does not exceed the remaining balance.
        /// </remarks>
        public static void ReadyAmountPaidForInsert()
        {
            if (AmountPaid >= SelectedBillBalance)
                AmountPaid = SelectedBillBalance;
        }
        /// <summary>
        /// Determines the billing status based on the payment amount relative to the bill balance.
        /// </summary>
        /// <returns>
        /// A status string indicating whether the bill is paid, partially paid, or unpaid.
        /// </returns>
        public static string EvaluateSelectedBillStatus()
        {
            string stat = "";

            if (AmountPaid >= SelectedBillBalance)
                stat = Metadata.Metadata.Bills.Status.Paid;
            else if (AmountPaid > 0 && AmountPaid < SelectedBillBalance)
                stat = Metadata.Metadata.Bills.Status.Partial;
            else
                stat = Metadata.Metadata.Bills.Status.Unpaid;

            return stat;
        }
        /// <summary>
        /// Updates the overall bill status by evaluating individual bill types and applying a unified status if consistent.
        /// </summary>
        /// <remarks>
        /// Assigns a partial status if any bill type differs, otherwise applies the shared status across all.
        /// Commits the result to the database using a structured update command.
        /// </remarks>
        public static void UpdateOverallBillStatus()
        {
            string WBS, EBS, RBS, IBS;
            string status;

            SelectedBillType = Metadata.Metadata.Bills.BillTypes.Water;
            WBS = SelectedBillStatus;

            SelectedBillType = Metadata.Metadata.Bills.BillTypes.Electricity;
            EBS = SelectedBillStatus;

            SelectedBillType = Metadata.Metadata.Bills.BillTypes.Rental;
            RBS= SelectedBillStatus;

            SelectedBillType = Metadata.Metadata.Bills.BillTypes.Internet;
            IBS = SelectedBillStatus;

            if (new[] { WBS, EBS, RBS, IBS }.Distinct().Count() == 1)
            {
                if (WBS == Metadata.Metadata.Bills.Status.Paid)
                    status = Metadata.Metadata.Bills.Status.Paid;
                else if (WBS == Metadata.Metadata.Bills.Status.Unpaid)
                    status = Metadata.Metadata.Bills.Status.Unpaid;
                else
                    status = Metadata.Metadata.Bills.Status.Partial;
            }
            else
                status = Metadata.Metadata.Bills.Status.Partial;

            DBC.CommandString = Construct.UpdateCommand(
                Update: tbbills.tbbills.ToString(),
                UpdateMetadata: new UpdateColumnMetadata(
                    UpdateColumn: tbbills.Status.ToString(),
                    WithDataType: MySQLDataType.VarChar,
                    SetValueTo: status),
                Where: tbbills.BillNumber.ToString() + "='" + InvoiceNumber + "'");
            DBC.ExecuteNonQuery();
        }
        /// <summary>
        /// Updates the stored reference number by incrementing its value and committing the change to metadata.
        /// </summary>
        /// <remarks>
        /// Executes a database update targeting the metadata entry associated with official receipt tracking.
        /// </remarks>
        public static void UpdateLastOR()
        {
            DBC.CommandString = Construct.UpdateCommand(
                Update: tbmetadata.tbmetadata.ToString(),
                UpdateMetadata: new UpdateColumnMetadata(
                    UpdateColumn: tbmetadata.Value.ToString(),
                    WithDataType: MySQLDataType.VarChar,
                    SetValueTo: (LastOR + 1).ToString()),
                Where: tbmetadata.MID.ToString() + "=5");
            DBC.ExecuteNonQuery();
        }
        /// <summary>
        /// Retrieves the invoice number associated with the specified official receipt number.
        /// </summary>
        /// <remarks>
        /// This method assumes that all related transactions have already been saved to the database.
        /// Calling this before transaction persistence may result in null or invalid data.
        /// </remarks>
        public static string GetInvoiceFromReceipt(string ORNumber)
        {
            DBC.CommandString = Construct.SelectCommand(
                Select: tbpayments.BillNumber.ToString(),
                From: tbpayments.tbpayments.ToString(),
                Where: tbpayments.ReceiptNumber.ToString() + "='" + ORNumber + "'");
            DBC.ExecuteReader();
            DBC.GetValues();
            return DBC.Values[0];
        }
        /// <summary>
        /// Determines whether a deduction record exists for the specified bill type under the current tenant.
        /// </summary>
        /// <param name="BillType">The bill type to filter deduction records by.</param>
        /// <remarks>
        /// Executes a SELECT query against the <c>tbdeductions</c> table using the current <c>TenantID</c> and the provided <paramref name="BillType"/>.
        /// Returns <c>true</c> if at least one matching record is found; otherwise, returns <c>false</c>.
        /// </remarks>
        /// <returns>
        /// <c>true</c> if a deduction record exists for the given bill type; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasDeductionRecord(string BillType)
        {
            DBC.CommandString = Construct.SelectCommand(
                Select: tbdeductions.DeductionID.ToString(),
                From: tbdeductions.tbdeductions.ToString(),
                Where:
                    tbdeductions.TenantID.ToString() + "=" + TenantID + " AND " +
                    tbdeductions.BillType.ToString() + "='" + BillType + "'");
            DBC.ExecuteReader();
            if (DBC.HasRows)
            {
                DBC.CloseReader();
                return true;
            }
            DBC.CloseReader();
            return false;
        }
        #endregion

        #region PRIVATE STRUCTS
        /// <summary>
        /// Represents a summary of a invoice's financial state within the payment context.
        /// </summary>
        private struct BillOverview
        {
            /// <summary>
            /// The Subtotal of the invoice.
            /// </summary>
            public double Subtotal { get; set; }
            /// <summary>
            /// The Bill Balance of the invoice.
            /// </summary>
            public double Balance { get; set; }
            /// <summary>
            /// The Status of the invoice
            /// </summary>
            public string Status { get; set; }
            public DateTime DueDate { get; set; }

            // <summary>
            /// Initializes a new instance of the <c>BillOverview</c> struct with subtotal, balance, and status values.
            /// </summary>
            /// <param name="BillSubtotal">The subtotal of the bill.</param>
            /// <param name="BillBalance">The remaining amount due.</param>
            /// <param name="BillStatus">The current invoice status.</param>
            public BillOverview(double BillSubtotal, double BillBalance, string BillStatus, DateTime BillDueDate)
            {
                Subtotal = BillSubtotal;
                Balance = BillBalance;
                Status = BillStatus;
                DueDate = BillDueDate;
            }
        }
        #endregion

        #region PRIVATE FUNCTIONS
        /// <summary>
        /// Retrieves the bill overview for the selected bill type and invoice number, including subtotal, balance, status, and due date.
        /// </summary>
        /// <returns>
        /// A <c>BillOverview</c> object containing the financial and status details of the current bill.
        /// </returns>
        private static BillOverview GetBillOverview()
        {
            BillOverview BO;

            if (_selectedBT == Metadata.Metadata.Bills.BillTypes.Water)
                DBC.CommandString = Construct.SelectCommand(
                    Select: new string[]
                    {
                        tbwaterbill.Subtotal.ToString(),
                        tbwaterbill.BillBalance.ToString(),
                        tbwaterbill.Status.ToString() },
                    From: tbwaterbill.tbwaterbill.ToString(),
                    Where: tbwaterbill.BillNumber.ToString() + "='" + InvoiceNumber + "'");
            else if(_selectedBT == Metadata.Metadata.Bills.BillTypes.Electricity)
                DBC.CommandString = Construct.SelectCommand(
                    Select: new string[]
                    {
                        tbelectricitybill.Subtotal.ToString(),
                        tbelectricitybill.BillBalance.ToString(),
                        tbelectricitybill.Status.ToString() },
                    From: tbelectricitybill.tbelectricitybill.ToString(),
                    Where: tbelectricitybill.BillNumber.ToString() + "='" + InvoiceNumber + "'");
            else if(_selectedBT == Metadata.Metadata.Bills.BillTypes.Rental)
                DBC.CommandString = Construct.SelectCommand(
                    Select: new string[]
                    {
                        tbrentalbill.Subtotal.ToString(),
                        tbrentalbill.BillBalance.ToString(),
                        tbrentalbill.Status.ToString() },
                    From: tbrentalbill.tbrentalbill.ToString(),
                    Where: tbrentalbill.BillNumber.ToString() + "='" + InvoiceNumber + "'");
            else if(_selectedBT == Metadata.Metadata.Bills.BillTypes.Internet)
                DBC.CommandString = Construct.SelectCommand(
                    Select: new string[]
                    {
                        tbinternetbill.Subtotal.ToString(),
                        tbinternetbill.BillBalance.ToString(),
                        tbinternetbill.Status.ToString() },
                    From: tbinternetbill.tbinternetbill.ToString(),
                    Where: tbinternetbill.BillNumber.ToString() + "='" + InvoiceNumber + "'");

            DBC.ExecuteReader();
            DBC.GetValues();
            double BS = Convert.ToDouble(DBC.Values[0]);
            double BB = Convert.ToDouble(DBC.Values[1]);
            string BStatus = DBC.Values[2];
            DBC.CloseReader();


            if(_selectedBT == Metadata.Metadata.Bills.BillTypes.Internet)
            {
                DBC.CommandString = Construct.SelectCommand(
                    Select: tbinternetbill.DueDate.ToString(),
                    From: tbinternetbill.tbinternetbill.ToString(),
                    Where: tbinternetbill.BillNumber.ToString() + "='" + InvoiceNumber + "'");
                DBC.ExecuteReader();
                DBC.GetValues();
                BO = new BillOverview(
                    BillSubtotal: BS,
                    BillBalance: BB,
                    BillStatus: BStatus,
                    BillDueDate: Convert.ToDateTime(DBC.Values[0]));
            }
            else
            {
                DBC.CommandString = Construct.SelectCommand(
                    Select: tbbills.DueDate.ToString(),
                    From: tbbills.tbbills.ToString(),
                    Where: tbbills.BillNumber.ToString() + "='" + InvoiceNumber + "'");
                DBC.ExecuteReader();
                DBC.GetValues();
                BO = new BillOverview(
                    BillSubtotal: BS,
                    BillBalance: BB,
                    BillStatus: BStatus,
                    BillDueDate: Convert.ToDateTime(DBC.Values[0]));
            }


                return BO;
        }
        #endregion
    }
}
