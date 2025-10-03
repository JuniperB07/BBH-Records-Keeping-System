using JunX.NET8.MySQL;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BBHRKS.Reports
{
    /// <summary>
    /// Provides ReportViewer Parameter values for BBH Records Keeping System Bill Invoice Page 1.
    /// </summary>
    public static class InvoicePage1
    {
        internal static MySqlConnection _connection;
        internal static MySQLExecute _exec;

        #region INTERNAL PROPERTIES
        internal static int TenantID
        {
            get
            {
                int tid = 0;

                _exec.CommandString = Construct.SelectCommand(
                    Select: tbbills.TenantID.ToString(),
                    From: tbbills.tbbills.ToString(),
                    Where:
                        tbbills.BillNumber.ToString() + "='" + InvoiceNumber + "'");
                _exec.ExecuteSelect();
                if (_exec.HasRows)
                    tid = Convert.ToInt32(_exec.GetValues[0]);

                return tid;
            }
        }
        internal static int WaterBillID
        {
            get
            {
                int wbid = 0;

                _exec.CommandString = Construct.SelectCommand(
                    Select: tbbills.WaterBillID.ToString(),
                    From: tbbills.tbbills.ToString(),
                    Where:
                        tbbills.BillNumber.ToString() + "='" + InvoiceNumber + "'");
                _exec.ExecuteSelect();
                wbid = Convert.ToInt32(_exec.GetValues[0]);

                return wbid;
            }
        }
        internal static int ElectricityBillID
        {
            get
            {
                int ebid = 0;

                _exec.CommandString = Construct.SelectCommand(
                    Select: tbbills.ElectricityBillID.ToString(),
                    From: tbbills.tbbills.ToString(),
                    Where:
                        tbbills.BillNumber.ToString() + "='" + InvoiceNumber + "'");
                _exec.ExecuteSelect();
                ebid = Convert.ToInt32(_exec.GetValues[0]);

                return ebid;
            }
        }
        internal static int RentalBillID
        {
            get
            {
                int rbid = 0;

                _exec.CommandString = Construct.SelectCommand(
                    Select: tbbills.RentalBillID.ToString(),
                    From: tbbills.tbbills.ToString(),
                    Where:
                        tbbills.BillNumber.ToString() + "='" + InvoiceNumber + "'");
                _exec.ExecuteSelect();
                rbid = Convert.ToInt32(_exec.GetValues[0]);

                return rbid;
            }
        }
        internal static int InternetBillID
        {
            get
            {
                int ibid = 0;

                _exec.CommandString = Construct.SelectCommand(
                    Select: tbbills.InternetBillID.ToString(),
                    From: tbbills.tbbills.ToString(),
                    Where:
                        tbbills.BillNumber.ToString() + "='" + InvoiceNumber + "'");
                _exec.ExecuteSelect();
                ibid = Convert.ToInt32(_exec.GetValues[0]);

                return ibid;
            }
        }
        internal static DateTime PreviousBillDueDate
        {
            get
            {
                return DueDate.AddMonths(-1);
            }
        }
        #endregion

        #region INTERNAL FUNCTIONS
        internal static double GetTotalPreviousBillPayments(string billType)
        {
            MySqlDataReader reader;
            double tpbp = 0;

            _exec.CommandString = Construct.SelectCommand(
                Select: tbpayments.AmountPaid.ToString(),
                From: tbpayments.tbpayments.ToString(),
                Where:
                    tbpayments.BillNumber.ToString() + "='" + PreviousBillNumber + "' AND " +
                    tbpayments.BillType.ToString() + "='" + billType + "'");
            reader = _exec.Reader;
            while (reader.Read())
                tpbp += Convert.ToDouble(reader[0].ToString());
            _exec.CloseReader();
            reader.Close();

            return tpbp;
        }
        #endregion

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Sets the active <c>MySqlConnection</c> instance used for executing SQL commands.
        /// </summary>
        /// <param name="value">
        /// A valid <c>MySqlConnection</c> object representing the target database connection.
        /// </param>
        public static MySqlConnection Connection { set { _connection = value; } }
        /// <summary>
        /// Retrieves the bill number associated with the tenant's previous billing cycle, based on the due date.
        /// Executes a parameterized SQL <c>SELECT</c> command to query the <c>tbbills</c> table.
        /// </summary>
        /// <returns>
        /// A <c>string</c> containing the bill number if a matching record is found; otherwise, an empty string.
        /// </returns>
        public static string PreviousBillNumber
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbbills.BillNumber.ToString(),
                    From: tbbills.tbbills.ToString(),
                    Where:
                        tbbills.TenantID.ToString() + "=" + TenantID + " AND " +
                        tbbills.DueDate.ToString() + "='" + PreviousBillDueDate.ToString("yyyy-MM-dd") + "'");
                _exec.ExecuteSelect();
                if (_exec.HasRows)
                    return _exec.GetValues[0];
                return "";
            }
        }
        /// <summary>
        /// Gets or sets the invoice number associated with the current transaction context.
        /// </summary>
        /// <returns>
        /// A string representing the invoice number.
        /// </returns>
        /// <remarks>
        /// This property must be set before accessing or using other properties under this class,  
        /// as it serves as the primary reference for invoice-related operations and data retrieval.
        /// </remarks>
        public static string InvoiceNumber { get; set; }
        /// <summary>
        /// Gets the full name of the tenant associated with the current <c>BillNumber</c>.
        /// </summary>
        /// <returns>
        /// A string containing the tenant's full name.
        /// </returns>
        /// <remarks>
        /// This property dynamically executes a SELECT query to retrieve the tenant's name from the database.  
        /// It depends on a valid <c>TenantID</c> and an initialized execution context.  
        /// The <c>InvoiceNumber</c> property must be set before accessing this property or others under this class.
        /// </remarks>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is empty.
        /// </exception>
        public static string TenantName
        {
            get
            {
                string tn = "";

                _exec.CommandString = Construct.SelectCommand(
                    Select: tbtenants.FullName.ToString(),
                    From: tbtenants.tbtenants.ToString(),
                    Where:
                        tbtenants.TenantID.ToString() + "=" + TenantID.ToString());
                _exec.ExecuteSelect();
                tn = _exec.GetValues[0];

                return tn;
            }
        }
        /// <summary>
        /// Gets the room assignment of the tenant associated with the current <c>TenantID</c>.
        /// </summary>
        /// <returns>
        /// A string containing the room identifier assigned to the tenant.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is empty.
        /// </exception>
        public static string Room
        {
            get
            {
                string r = "";

                _exec.CommandString = Construct.SelectCommand(
                    Select: tbtenants.Room.ToString(),
                    From: tbtenants.tbtenants.ToString(),
                    Where: tbtenants.TenantID.ToString() + "=" + TenantID);
                _exec.ExecuteSelect();
                r = _exec.GetValues[0];

                return r;
            }
        }
        /// <summary>
        /// Gets the rent type assigned to the tenant associated with the current <c>TenantID</c>.
        /// </summary>
        /// <returns>
        /// A string representing the tenant's rent type.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is empty.
        /// </exception>
        public static string RentType
        {
            get
            {
                string rt = "";
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbtenants.RentType.ToString(),
                    From: tbtenants.tbtenants.ToString(),
                    Where: tbtenants.TenantID.ToString() + "=" + TenantID);
                _exec.ExecuteSelect();
                rt = _exec.GetValues[0];
                return rt;
            }
        }
        /// <summary>
        /// Gets the tenancy status of the tenant associated with the current <c>TenantID</c>.
        /// </summary>
        /// <returns>
        /// A string representing the tenant's tenancy status.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is empty.
        /// </exception>
        public static string TenancyStatus
        {
            get
            {
                string ts = "";
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbtenants.Status.ToString(),
                    From: tbtenants.tbtenants.ToString(),
                    Where: tbtenants.TenantID.ToString() + "=" + TenantID);
                _exec.ExecuteSelect();
                ts = _exec.GetValues[0];
                return ts;
            }
        }
        /// <summary>
        /// Gets the billing date associated with the current <c>InvoiceNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>DateTime</c> value representing the invoice date.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is empty.
        /// </exception>
        public static DateTime InvoiceDate
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbbills.BillingDate.ToString(),
                    From: tbbills.tbbills.ToString(),
                    Where: tbbills.BillNumber.ToString() + "='" + InvoiceNumber + "'");
                _exec.ExecuteSelect();
                return Convert.ToDateTime(_exec.GetValues[0]);
            }
        }
        /// <summary>
        /// Gets the due date of the bill associated with the current <c>InvoiceNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>DateTime</c> value representing the bill's due date.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is empty.
        /// </exception>
        public static DateTime DueDate
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbbills.DueDate.ToString(),
                    From: tbbills.tbbills.ToString(),
                    Where: tbbills.BillNumber.ToString() + "='" + InvoiceNumber + "'");
                _exec.ExecuteSelect();
                return Convert.ToDateTime(_exec.GetValues[0]);
            }
        }
        /// <summary>
        /// Gets the total amount of the previous bill associated with <c>PreviousBillNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the previous bill total. Returns 0 if no previous bill is found.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static double PreviousBillTotal
        {
            get
            {
                if(PreviousBillNumber != "")
                {
                    _exec.CommandString = Construct.SelectCommand(
                        Select: tbbills.BillTotal.ToString(),
                        From: tbbills.tbbills.ToString(),
                        Where: tbbills.BillNumber.ToString() + "='" + PreviousBillNumber + "'");
                    _exec.ExecuteSelect();
                    if (_exec.HasRows)
                        return Convert.ToDouble(_exec.GetValues[0]);
                    return 0;
                }
                return 0;
            }
        }
        /// <summary>
        /// Gets the total amount of payments received for the previous bill across all bill types.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the sum of payments for water, electricity, rental, and internet.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if any payment retrieval operation fails or returns invalid data.
        /// </exception>
        public static double PreviousPaymentsReceived
        {
            get
            {
                double ppr = 0;

                ppr += GetTotalPreviousBillPayments(Metadata.Metadata.Bills.BillTypes.Water);
                ppr += GetTotalPreviousBillPayments(Metadata.Metadata.Bills.BillTypes.Electricity);
                ppr += GetTotalPreviousBillPayments(Metadata.Metadata.Bills.BillTypes.Rental);
                ppr += GetTotalPreviousBillPayments(Metadata.Metadata.Bills.BillTypes.Internet);

                return ppr;
            }
        }
        /// <summary>
        /// Gets the remaining balance of the previous bill after subtracting received payments.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the outstanding balance.
        /// </returns>
        public static double PreviousBillBalance
        {
            get
            {
                return PreviousBillTotal - PreviousPaymentsReceived;
            }
        }
        /// <summary>
        /// Gets the combined subtotal of rental, water, and electricity charges for the current <c>InvoiceNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the total rental and utilities charges.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if any SQL execution fails or the result set is invalid.
        /// </exception>
        public static double RentalUtilitiesCharges
        {
            get
            {
                double ruc = 0;

                _exec.CommandString = Construct.SelectCommand(
                    Select: tbrentalbill.Subtotal.ToString(),
                    From: tbrentalbill.tbrentalbill.ToString(),
                    Where: tbrentalbill.BillNumber.ToString() + "='" + InvoiceNumber + "'");
                _exec.ExecuteSelect();
                ruc += Convert.ToDouble(_exec.GetValues[0]);

                _exec.CommandString = Construct.SelectCommand(
                    Select: tbwaterbill.Subtotal.ToString(),
                    From: tbwaterbill.tbwaterbill.ToString(),
                    Where: tbwaterbill.BillNumber.ToString() + "='" + InvoiceNumber + "'");
                _exec.ExecuteSelect();
                ruc += Convert.ToDouble(_exec.GetValues[0]);

                _exec.CommandString = Construct.SelectCommand(
                    Select: tbelectricitybill.Subtotal.ToString(),
                    From: tbelectricitybill.tbelectricitybill.ToString(),
                    Where: tbelectricitybill.BillNumber.ToString() + "='" + InvoiceNumber + "'");
                _exec.ExecuteSelect();
                ruc += Convert.ToDouble(_exec.GetValues[0]);

                return ruc;
            }
        }
        /// <summary>
        /// Gets the subtotal of internet charges for the current <c>InvoiceNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the internet bill subtotal.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static double InternetCharges
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbinternetbill.Subtotal.ToString(),
                    From: tbinternetbill.tbinternetbill.ToString(),
                    Where: tbinternetbill.BillNumber.ToString() + "='" + InvoiceNumber + "'");
                _exec.ExecuteSelect();
                return Convert.ToDouble(_exec.GetValues[0]);
            }
        }
        /// <summary>
        /// Gets the total current charges by summing rental, utilities, and internet charges for the current <c>InvoiceNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the total current bill charges.
        /// </returns>
        public static double TotalCurrentCharges
        {
            get
            {
                return RentalUtilitiesCharges + InternetCharges;
            }
        }
        /// <summary>
        /// Gets the total amount due by summing the previous bill balance and current charges.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the total amount payable.
        /// </returns>
        public static double TotalAmountDue
        {
            get
            {
                return PreviousBillBalance + TotalCurrentCharges;
            }
        }
        /// <summary>
        /// Gets the due date of the internet bill associated with the current <c>InvoiceNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>DateTime</c> value representing the internet bill's due date.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static DateTime InternetDueDate
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbinternetbill.DueDate.ToString(),
                    From: tbinternetbill.tbinternetbill.ToString(),
                    Where: tbinternetbill.BillNumber.ToString() + "='" + InvoiceNumber + "'");
                _exec.ExecuteSelect();
                return Convert.ToDateTime(_exec.GetValues[0]);
            }
        }
        #endregion

        #region PUBLIC FUNCTIONS
        /// <summary>
        /// Initializes the internal execution handler using the current database connection.
        /// </summary>
        public static void Initialize()
        {
            _exec = new MySQLExecute(_connection);
        }
        #endregion
    }

    /// <summary>
    /// Provides ReportViewer Parameter values for BBH Records Keeping System Bill Invoice Page 2.
    /// </summary>
    /// <remarks>
    /// This class can only function properly after <c>InvoicePage1</c> is initialized and its required properties are set.
    /// </remarks>
    public static class InvoicePage2
    {
        private static MySQLExecute _exec;

        #region PUBLIC PROPERTY
        /// <summary>
        /// Gets the subtotal of water charges from the previous bill identified by <c>PreviousBillNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the previous water bill subtotal.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static double PreviousWaterCharges
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbwaterbill.Subtotal.ToString(),
                    From: tbwaterbill.tbwaterbill.ToString(),
                    Where: tbwaterbill.BillNumber.ToString() + "='" + InvoicePage1.PreviousBillNumber + "'");
                _exec.ExecuteSelect();
                if(_exec.HasRows)
                    return Convert.ToDouble(_exec.GetValues[0]);
                return 0;
            }
        }
        /// <summary>
        /// Gets the total amount of payments made toward the previous water bill.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the sum of all water bill payments for <c>PreviousBillNumber</c>.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the data reader encounters an error.
        /// </exception>
        public static double PreviousWaterPayments
        {
            get
            {
                MySqlDataReader reader;
                double pwp = 0;

                _exec.CommandString = Construct.SelectCommand(
                    Select: tbpayments.AmountPaid.ToString(),
                    From: tbpayments.tbpayments.ToString(),
                    Where:
                        tbpayments.BillNumber.ToString() + "='" + InvoicePage1.PreviousBillNumber + "' AND " +
                        tbpayments.BillType.ToString() + "='" + Metadata.Metadata.Bills.BillTypes.Water + "'");
                reader = _exec.Reader;
                while (reader.Read())
                    pwp += Convert.ToDouble(reader[0].ToString());
                reader.Close();
                _exec.CloseReader();
                return pwp;
            }
        }
        /// <summary>
        /// Gets the subtotal of electricity charges from the previous bill identified by <c>PreviousBillNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the previous electricity bill subtotal.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static double PreviousElectricityCharges
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbelectricitybill.Subtotal.ToString(),
                    From: tbelectricitybill.tbelectricitybill.ToString(),
                    Where: tbelectricitybill.BillNumber.ToString() + "='" + InvoicePage1.PreviousBillNumber + "'");
                _exec.ExecuteSelect();
                if (_exec.HasRows)
                    return Convert.ToDouble(_exec.GetValues[0]);
                return 0;
            }
        }
        /// <summary>
        /// Gets the total amount of payments made toward the previous electricity bill.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the sum of all electricity bill payments for <c>PreviousBillNumber</c>.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the data reader encounters an error.
        /// </exception>
        public static double PreviousElectricityPayments
        {
            get
            {
                MySqlDataReader reader;
                double pep = 0;

                _exec.ConnectionString = Construct.SelectCommand(
                    Select: tbpayments.AmountPaid.ToString(),
                    From: tbpayments.tbpayments.ToString(),
                    Where:
                        tbpayments.BillNumber.ToString() + "='" + InvoicePage1.PreviousBillNumber + "' AND " +
                        tbpayments.BillType.ToString() + "='" + Metadata.Metadata.Bills.BillTypes.Electricity + "'");
                reader = _exec.Reader;
                while (reader.Read())
                    pep = Convert.ToDouble(reader[0].ToString());
                reader.Close();
                _exec.CloseReader();
                return pep;
            }
        }
        /// <summary>
        /// Gets the subtotal of rental charges from the previous bill identified by <c>PreviousBillNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the previous rental bill subtotal.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static double PreviousRentalCharges
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbrentalbill.Subtotal.ToString(),
                    From: tbrentalbill.tbrentalbill.ToString(),
                    Where: tbrentalbill.BillNumber.ToString() + "='" + InvoicePage1.PreviousBillNumber + "'");
                _exec.ExecuteSelect();
                if (_exec.HasRows)
                    return Convert.ToDouble(_exec.GetValues[0]);
                return 0;
            }
        }
        /// <summary>
        /// Gets the total amount of payments made toward the previous rental bill.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the sum of all rental bill payments for <c>PreviousBillNumber</c>.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the data reader encounters an error.
        /// </exception>
        public static double PreviousRentalPayments
        {
            get
            {
                MySqlDataReader reader;
                double prp = 0;

                _exec.ConnectionString = Construct.SelectCommand(
                    Select: tbpayments.AmountPaid.ToString(),
                    From: tbpayments.tbpayments.ToString(),
                    Where: tbpayments.BillNumber.ToString() + "='" + InvoicePage1.PreviousBillNumber + "' AND " +
                        tbpayments.BillType.ToString() + "='" + Metadata.Metadata.Bills.BillTypes.Rental + "'");
                reader = _exec.Reader;
                while (reader.Read())
                    prp += Convert.ToDouble(reader[0].ToString());
                reader.Close();
                _exec.CloseReader();
                return prp;
            }
        }
        /// <summary>
        /// Gets the subtotal of internet charges from the previous bill identified by <c>PreviousBillNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the previous internet bill subtotal.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static double PreviousInternetCharges
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbinternetbill.Subtotal.ToString(),
                    From: tbinternetbill.tbinternetbill.ToString(),
                    Where: tbinternetbill.BillNumber.ToString() + "='" + InvoicePage1.PreviousBillNumber + "'");
                _exec.ExecuteSelect();
                if (_exec.HasRows)
                    return Convert.ToDouble(_exec.GetValues[0]);
                return 0;
            }
        }
        /// <summary>
        /// Gets the total amount of payments made toward the previous internet bill.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the sum of all internet bill payments for <c>PreviousBillNumber</c>.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the data reader encounters an error.
        /// </exception>
        public static double PreviousInternetPayments
        {
            get
            {
                MySqlDataReader reader;
                double pip = 0;

                _exec.ConnectionString = Construct.SelectCommand(
                    Select: tbpayments.AmountPaid.ToString(),
                    From: tbpayments.tbpayments.ToString(),
                    Where: tbpayments.BillNumber.ToString() + "='" + InvoicePage1.PreviousBillNumber + "' AND " +
                        tbpayments.BillType.ToString() + "='" + Metadata.Metadata.Bills.BillTypes.Internet + "'");
                reader = _exec.Reader;
                while (reader.Read())
                    pip += Convert.ToDouble(reader[0].ToString());
                reader.Close();
                _exec.CloseReader();
                return pip;
            }
        }
        /// <summary>
        /// Gets the total outstanding balance from the previous bill by subtracting payments from charges across all bill types.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the cumulative unpaid amount for water, electricity, rental, and internet.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if any underlying property access or calculation fails due to invalid data or execution errors.
        /// </exception>
        public static double PreviousBalance
        {
            get
            {
                double pb = 0;

                pb += PreviousWaterCharges - PreviousWaterPayments;
                pb += PreviousElectricityCharges - PreviousElectricityPayments;
                pb += PreviousRentalCharges - PreviousRentalPayments;
                pb += PreviousInternetCharges - PreviousInternetPayments;

                return pb;
            }
        }
        /// <summary>
        /// Gets the previous water meter reading for the current <c>InvoiceNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the previous water reading. Returns 0 if no record is found.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static double WaterPreviousReading
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbwaterbill.PreviousReading.ToString(),
                    From: tbwaterbill.tbwaterbill.ToString(),
                    Where: tbwaterbill.BillNumber.ToString() + "='" + InvoicePage1.InvoiceNumber + "'");
                _exec.ExecuteSelect();
                if (_exec.HasRows)
                    return Convert.ToDouble(_exec.GetValues[0]);
                return 0;
            }
        }
        /// <summary>
        /// Gets the present water meter reading for the current <c>InvoiceNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the present water reading. Returns 0 if no record is found.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static double WaterPresentReading
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbwaterbill.PresentReading.ToString(),
                    From: tbwaterbill.tbwaterbill.ToString(),
                    Where: tbwaterbill.BillNumber.ToString() + "='" + InvoicePage1.InvoiceNumber + "'");
                _exec.ExecuteSelect();
                if (_exec.HasRows)
                    return Convert.ToDouble(_exec.GetValues[0]);
                return 0;
            }
        }
        /// <summary>
        /// Gets the formatted water consumption value for the current <c>InvoiceNumber</c>, including its unit.
        /// </summary>
        /// <returns>
        /// A <c>string</c> representing the water consumption amount followed by its unit (e.g., "15 m³").
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static string WaterConsumption
        {
            get
            {
                var wc = new StringBuilder();

                _exec.CommandString = Construct.SelectCommand(
                    Select: tbwaterbill.Consumption.ToString(),
                    From: tbwaterbill.tbwaterbill.ToString(),
                    Where: tbwaterbill.BillNumber.ToString() + "='" + InvoicePage1.InvoiceNumber + "'");
                _exec.ExecuteSelect();
                wc.Append(Convert.ToDouble(_exec.GetValues[0]).ToString("0.00"));
                wc.Append(Metadata.Metadata.Water.Consumption.Unit);
                return wc.ToString();
            }
        }
        /// <summary>
        /// Gets the current charge for water consumption associated with the current <c>InvoiceNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the water consumption charge.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static double WaterConsumptionCharge
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbwaterbill.CurrentCharge.ToString(),
                    From: tbwaterbill.tbwaterbill.ToString(),
                    Where: tbwaterbill.BillNumber.ToString() + "='" + InvoicePage1.InvoiceNumber + "'");
                _exec.ExecuteSelect();
                return Convert.ToDouble(_exec.GetValues[0]);
            }
        }
        /// <summary>
        /// Gets the total deductions applied to the water bill for the current <c>InvoiceNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the water bill deductions. Returns 0 if no record is found.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static double WaterDeductions
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbwaterbill.Deductions.ToString(),
                    From: tbwaterbill.tbwaterbill.ToString(),
                    Where: tbwaterbill.BillNumber.ToString() + "='" + InvoicePage1.InvoiceNumber + "'");
                _exec.ExecuteSelect();
                if (_exec.HasRows)
                    return Convert.ToDouble(_exec.GetValues[0]);
                return 0;
            }
        }
        /// <summary>
        /// Gets the net amount due for water charges by subtracting deductions from the current consumption charge.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the payable water amount.
        /// </returns>
        public static double WaterAmountDue
        {
            get
            {
                return WaterConsumptionCharge - WaterDeductions;
            }
        }
        /// <summary>
        /// Gets the previous electricity meter reading for the current <c>InvoiceNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the previous electricity reading. Returns 0 if no record is found.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static double ElectricityPreviousReading
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbelectricitybill.PreviousReading.ToString(),
                    From: tbelectricitybill.tbelectricitybill.ToString(),
                    Where: tbelectricitybill.BillNumber.ToString() + "='" + InvoicePage1.InvoiceNumber + "'");
                _exec.ExecuteSelect();
                if (_exec.HasRows)
                    return Convert.ToDouble(_exec.GetValues[0]);
                return 0;
            }
        }
        /// <summary>
        /// Gets the present electricity meter reading for the current <c>InvoiceNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the present electricity reading. Returns 0 if no record is found.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static double ElectricityPresentReading
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbelectricitybill.PresentReading.ToString(),
                    From: tbelectricitybill.tbelectricitybill.ToString(),
                    Where: tbelectricitybill.BillNumber.ToString() + "='" + InvoicePage1.InvoiceNumber + "'");
                _exec.ExecuteSelect();
                if (_exec.HasRows)
                    return Convert.ToDouble(_exec.GetValues[0]);
                return 0;
            }
        }
        /// <summary>
        /// Gets the formatted electricity consumption value for the current <c>InvoiceNumber</c>, including its unit.
        /// </summary>
        /// <returns>
        /// A <c>string</c> representing the electricity consumption amount followed by its unit (e.g., "120 kWh").
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static string ElectricityConsumption
        {
            get
            {
                var ec = new StringBuilder();

                _exec.CommandString = Construct.SelectCommand(
                    Select: tbelectricitybill.Consumption.ToString(),
                    From: tbelectricitybill.tbelectricitybill.ToString(),
                    Where: tbelectricitybill.BillNumber.ToString() + "='" + InvoicePage1.InvoiceNumber + "'");
                _exec.ExecuteSelect();
                ec.Append(Convert.ToDouble(_exec.GetValues[0]).ToString("0.00"));
                ec.Append(Metadata.Metadata.Electricity.Consumption.Unit);
                return ec.ToString();
            }
        }
        /// <summary>
        /// Gets the current charge for electricity consumption associated with the current <c>InvoiceNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the electricity consumption charge. Returns 0 if no record is found.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static double ElectricityConsumptionCharge
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbelectricitybill.CurrentCharge.ToString(),
                    From: tbelectricitybill.tbelectricitybill.ToString(),
                    Where: tbelectricitybill.BillNumber.ToString() + "='" + InvoicePage1.InvoiceNumber + "'");
                _exec.ExecuteSelect();
                if (_exec.HasRows)
                    return Convert.ToDouble(_exec.GetValues[0]);
                return 0;
            }
        }
        /// <summary>
        /// Gets the total deductions applied to the electricity bill for the current <c>InvoiceNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the electricity bill deductions. Returns 0 if no record is found.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static double ElectricityDeductions
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbelectricitybill.Deductions.ToString(),
                    From: tbelectricitybill.tbelectricitybill.ToString(),
                    Where: tbelectricitybill.BillNumber.ToString() + "='" + InvoicePage1.InvoiceNumber + "'");
                _exec.ExecuteSelect();
                if (_exec.HasRows)
                    return Convert.ToDouble(_exec.GetValues[0]);
                return 0;
            }
        }
        /// <summary>
        /// Gets the net amount due for electricity charges by subtracting deductions from the current consumption charge.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the payable electricity amount.
        /// </returns>
        public static double ElectricityAmountDue
        {
            get
            {
                return ElectricityConsumptionCharge - ElectricityDeductions;
            }
        }
        /// <summary>
        /// Gets the monthly rental charge associated with the current <c>InvoiceNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the rental amount due for the current billing cycle. Returns 0 if no record is found.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static double RentalMonthlyCharge
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbrentalbill.MonthlyDue.ToString(),
                    From: tbrentalbill.tbrentalbill.ToString(),
                    Where: tbrentalbill.BillNumber.ToString() + "='" + InvoicePage1.InvoiceNumber + "'");
                _exec.ExecuteSelect();
                if (_exec.HasRows)
                    return Convert.ToDouble(_exec.GetValues[0]);
                return 0;
            }
        }
        /// <summary>
        /// Gets the total additional charges applied to the rental bill for the current <c>InvoiceNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the rental bill's additional charges. Returns 0 if no record is found.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static double RentalAdditionals
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbrentalbill.AdditionalCharges.ToString(),
                    From: tbrentalbill.tbrentalbill.ToString(),
                    Where: tbrentalbill.BillNumber.ToString() + "='" + InvoicePage1.InvoiceNumber + "'");
                _exec.ExecuteSelect();
                if (_exec.HasRows)
                    return Convert.ToDouble(_exec.GetValues[0]);
                return 0;
            }
        }
        /// <summary>
        /// Gets the total deductions applied to the rental bill for the current <c>InvoiceNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the rental bill deductions. Returns 0 if no record is found.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static double RentalDeductions
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbrentalbill.Deductions.ToString(),
                    From: tbrentalbill.tbrentalbill.ToString(),
                    Where: tbrentalbill.BillNumber.ToString() + "='" + InvoicePage1.InvoiceNumber + "'");
                _exec.ExecuteSelect();
                if (_exec.HasRows)
                    return Convert.ToDouble(_exec.GetValues[0]);
                return 0;
            }
        }
        /// <summary>
        /// Gets the net amount due for rental charges by adding monthly and additional charges, then subtracting deductions.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the total payable rental amount.
        /// </returns>
        public static double RentalAmountDue
        {
            get
            {
                return (RentalMonthlyCharge + RentalAdditionals) - RentalDeductions;
            }
        }
        /// <summary>
        /// Gets the name of the internet plan assigned to the tenant.
        /// </summary>
        /// <returns>
        /// A <c>string</c> representing the tenant's internet plan.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static string InternetPlan
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbtenants.InternetPlan.ToString(),
                    From: tbtenants.tbtenants.ToString(),
                    Where: tbtenants.TenantID.ToString() + "=" + InvoicePage1.TenantID);
                _exec.ExecuteSelect();
                return _exec.GetValues[0];
            }
        }
        /// <summary>
        /// Gets the monthly subscription fee for internet service associated with the current <c>InvoiceNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the internet subscription charge. Returns 0 if no record is found.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static double InternetMonthlyCharge
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbinternetbill.SubscriptionFee.ToString(),
                    From: tbinternetbill.tbinternetbill.ToString(),
                    Where: tbinternetbill.BillNumber.ToString() + "='" + InvoicePage1.InvoiceNumber + "'");
                _exec.ExecuteSelect();
                if (_exec.HasRows)
                    return Convert.ToDouble(_exec.GetValues[0]);
                return 0;
            }
        }
        /// <summary>
        /// Gets the total deductions applied to the internet bill for the current <c>InvoiceNumber</c>.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the internet bill deductions. Returns 0 if no record is found.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if the SQL execution fails or the result set is invalid.
        /// </exception>
        public static double InternetDeductions
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbinternetbill.Deductions.ToString(),
                    From: tbinternetbill.tbinternetbill.ToString(),
                    Where: tbinternetbill.BillNumber.ToString() + "='" + InvoicePage1.InvoiceNumber + "'");
                _exec.ExecuteSelect();
                if (_exec.HasRows)
                    return Convert.ToDouble(_exec.GetValues[0]);
                return 0;
            }
        }
        /// <summary>
        /// Gets the net amount due for internet service by subtracting deductions from the monthly subscription charge.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the total payable internet amount.
        /// </returns>
        public static double InternetAmountDue
        {
            get
            {
                return InternetMonthlyCharge - InternetDeductions;
            }
        }
        #endregion

        #region PUBLIC FUNCTIONS
        /// <summary>
        /// Initializes the execution context by assigning shared connection and executor instances from <c>InvoicePage1</c>.
        /// </summary>
        /// <exception cref="Exception">
        /// Thrown if the source connection or executor is invalid or inaccessible.
        /// </exception>
        public static void Initialize()
        {
            _exec = InvoicePage1._exec;
        }
        #endregion
    }

    /// <summary>
    /// Provides ReportViewer Parameter values for BBH Records Keeping System Bill Invoice Page 3.
    /// </summary>
    /// <remarks>
    /// This class can only function properly after <c>InvoicePage1</c> and <c>InvoicePage2</c> is initialized and its required properties are set.
    /// </remarks>
    public static class InvoicePage3
    {
        private static MySQLExecute _exec;
        private static MySqlDataReader reader;

        /// <summary>
        /// Retrieves a formatted list of additional charges applied to the current tenant.
        /// </summary>
        /// <remarks>
        /// Executes a SELECT query against the <c>tbadditionals</c> table using the current <c>TenantID</c>.
        /// Each record includes the enforcement date and charge details, formatted as:
        /// <c>[MMM-d-yyyy] Details</c>. If no records are found, returns <c>"N/A"</c>.
        /// </remarks>
        /// <returns>
        /// A newline-separated string of additional charges with dates, or <c>"N/A"</c> if none exist.
        /// </returns>
        public static string AdditionalCharges
        {
            get
            {
                var AC = new StringBuilder();
                bool rowsFound = false;

                _exec.CommandString = Construct.SelectCommand(
                    Select: new string[]
                    {
                        tbadditionals.EnforcementDate.ToString(),
                        tbadditionals.Details.ToString() },
                    From: tbadditionals.tbadditionals.ToString(),
                    Where:
                        tbadditionals.TenantID.ToString() + "=" + InvoicePage1.TenantID + " AND (" +
                        tbadditionals.Status.ToString() + "='" + Metadata.Metadata.Additionals.Status.Unpaid + "' OR " +
                        tbadditionals.Status.ToString() + "='" + Metadata.Metadata.Additionals.Status.Partial + "')");
                reader = _exec.Reader;
                while (reader.Read())
                {
                    AC.Append("[" + Convert.ToDateTime(reader[0].ToString()).ToString("MMM-d-yyy") + "] ");
                    AC.Append(reader[1].ToString() + "\n");
                    rowsFound = true;
                }
                reader.Close();
                _exec.CloseReader();

                if (rowsFound)
                    return AC.ToString();
                return "N/A";
            }
        }

        public static void Initialize()
        {
            _exec = InvoicePage1._exec;
        }
    }

    /// <summary>
    /// Provides ReportViewer Parameter values for BBH Records Keeping System Bill Invoice Page 4.
    /// </summary>
    /// <remarks>
    /// This class can only function properly after <c>InvoicePage1</c> and <c>InvoicePage2</c> is initialized and its required properties are set.
    /// </remarks>
    public static class InvoicePage4
    {
        private static MySQLExecute _exec;

        /// <summary>
        /// Gets the bill number from the previous billing cycle as provided by <c>InvoicePage1</c>.
        /// </summary>
        /// <returns>
        /// A <c>string</c> representing the previous bill number.
        /// </returns>
        public static string PreviousBillNumber
        {
            get
            {
                return InvoicePage1.PreviousBillNumber;
            }
        }
        /// <summary>
        /// Retrieves the billing date of the previous invoice by executing a SQL <c>SELECT</c> command against the <c>tbbills</c> table.
        /// </summary>
        /// <returns>
        /// A <c>DateTime</c> value representing the billing date of the previous invoice if found; otherwise, the current system date and time.
        /// </returns>
        public static DateTime PreviousInvoiceDate
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbbills.BillingDate.ToString(),
                    From: tbbills.tbbills.ToString(),
                    Where: tbbills.BillNumber.ToString() + "='" + PreviousBillNumber + "'");
                _exec.ExecuteSelect();
                if(_exec.HasRows)
                    return Convert.ToDateTime(_exec.GetValues[0]);
                return DateTime.Now;
            }
        }
        /// <summary>
        /// Retrieves the due date of the previous bill by executing a SQL <c>SELECT</c> command against the <c>tbbills</c> table.
        /// </summary>
        /// <returns>
        /// A <c>DateTime</c> value representing the due date of the previous bill if found; otherwise, the current system date and time.
        /// </returns>
        public static DateTime PreviousDueDate
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbbills.DueDate.ToString(),
                    From: tbbills.tbbills.ToString(),
                    Where: tbbills.BillNumber.ToString() + "='" + PreviousBillNumber + "'");
                _exec.ExecuteSelect();
                if (_exec.HasRows)
                    return Convert.ToDateTime(_exec.GetValues[0]);
                return DateTime.Now;
            }
        }
        /// <summary>
        /// Evaluates the payment status of the previous invoice by comparing the total amount due with the payments received.
        /// </summary>
        /// <returns>
        /// A <c>string</c> representing the invoice status: <c>Paid</c>, <c>Partial</c>, or <c>Unpaid</c>, based on the computed balance.
        /// </returns>
        public static string PreviousInvoiceStatus
        {
            get
            {
                double prevBal = InvoicePage1.TotalAmountDue - InvoicePage1.PreviousPaymentsReceived;

                if (prevBal == 0)
                    return Metadata.Metadata.Bills.Status.Paid;
                else if (prevBal > 0 && prevBal < InvoicePage1.TotalAmountDue)
                    return Metadata.Metadata.Bills.Status.Partial;
                else if (prevBal >= InvoicePage1.TotalAmountDue)
                    return Metadata.Metadata.Bills.Status.Unpaid;
                return "";
            }
        }
        /// <summary>
        /// Gets the total amount of payments received for the previous billing cycle from <c>InvoicePage1</c>.
        /// </summary>
        /// <returns>
        /// A <c>double</c> value representing the total payments received.
        /// </returns>
        public static double TotalPaymentsReceived
        {
            get { return InvoicePage1.PreviousPaymentsReceived; }
        }

        /// <summary>
        /// Sets up the shared execution context required for invoice-related operations.
        /// </summary>
        public static void Initialize()
        {
            _exec = InvoicePage1._exec;
        }
        /// <summary>
        /// Loads receipt records associated with the previous bill and inserts them into the bill preview receipts table.
        /// </summary>
        /// <param name="Rows">
        /// Outputs the total number of receipt records processed.
        /// </param>
        public static void FillBillPreviewReceiptsTable(out int Rows)
        {
            MySqlDataReader reader;
            List<ReceiptsData> receipts = new List<ReceiptsData>();
            int r = 0;

            if(PreviousBillNumber == "")
            {
                Rows = 0;
                return;
            }

            _exec.CommandString = Construct.SelectCommand(
                Select: new string[]
                {
                    tbpayments.ReceiptNumber.ToString(),
                    tbpayments.TransactionDateTime.ToString(),
                    tbpayments.BillType.ToString(),
                    tbpayments.AmountPaid.ToString() },
                From: tbpayments.tbpayments.ToString(),
                Where: tbpayments.BillNumber.ToString() + "='" + PreviousBillNumber + "'");
            reader = _exec.Reader;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    receipts.Add(new ReceiptsData(
                        SetORNumber: reader[0].ToString(),
                        SetTransactionDT: Convert.ToDateTime(reader[1].ToString()),
                        SetBillType: reader[2].ToString(),
                        SetAmountPaid: Convert.ToDouble(reader[3].ToString())));
                    r++;
                }
            }
            reader.Close();
            _exec.CloseReader();

            if (r > 0)
            {
                foreach(ReceiptsData rd in receipts)
                {
                    _exec.CommandString = Construct.InsertIntoCommand(
                        InsertInto: tbbillpreview_receipts.tbbillpreview_receipts.ToString(),
                        InsertMetadata: new InsertColumnMetadata[]
                        {
                            new InsertColumnMetadata(
                                ToColumn: tbbillpreview_receipts.ORNumber.ToString(),
                                WithDataType: MySQLDataType.VarChar,
                                rd.ORNumber),
                            new InsertColumnMetadata(
                                tbbillpreview_receipts.TransactionDateTime.ToString(),
                                MySQLDataType.Date,
                                rd.TransactionDateTime.ToString("yyyy-MM-dd")),
                            new InsertColumnMetadata(
                                tbbillpreview_receipts.BillType.ToString(),
                                MySQLDataType.VarChar,
                                rd.BillType),
                            new InsertColumnMetadata(
                                tbbillpreview_receipts.AmountPaid.ToString(),
                                MySQLDataType.Decimal,
                                rd.AmountPaid.ToString()) });
                    _exec.ExecuteNonQuery();
                }
            }
            else
            {
                _exec.CommandString = Construct.InsertIntoCommand(
                        InsertInto: tbbillpreview_receipts.tbbillpreview_receipts.ToString(),
                        InsertMetadata: new InsertColumnMetadata[]
                        {
                            new InsertColumnMetadata(
                                ToColumn: tbbillpreview_receipts.ORNumber.ToString(),
                                WithDataType: MySQLDataType.VarChar,
                                "N/A"),
                            new InsertColumnMetadata(
                                tbbillpreview_receipts.TransactionDateTime.ToString(),
                                MySQLDataType.Date,
                                "2000-01-01"),
                            new InsertColumnMetadata(
                                tbbillpreview_receipts.BillType.ToString(),
                                MySQLDataType.VarChar,
                                "N/A"),
                            new InsertColumnMetadata(
                                tbbillpreview_receipts.AmountPaid.ToString(),
                                MySQLDataType.Decimal,
                                "0") });
                _exec.ExecuteNonQuery();
            }

            Rows = r;
        }

        private struct ReceiptsData
        {
            public string ORNumber { get; set; }
            public DateTime TransactionDateTime { get; set; }
            public string BillType { get; set; }
            public double AmountPaid { get; set; }


            public ReceiptsData(string SetORNumber, DateTime SetTransactionDT, string SetBillType, double SetAmountPaid)
            {
                ORNumber = SetORNumber;
                TransactionDateTime = SetTransactionDT;
                BillType = SetBillType;
                AmountPaid = SetAmountPaid;
            }
        }
    }

    /// <summary>
    /// Provides ReportViewer Parameter values for BBH Records Keeping System - Payments Preview
    /// </summary>
    public static class PaymentsPage1
    {
        private static MySqlConnection _connection;
        private static MySQLExecute _exec;
        private static MySqlDataReader _reader;
        private static bool _allInvoice;

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Stores the current invoice number used for transaction tracking.
        /// </summary>
        /// <remarks>
        /// Acts as a reference identifier for billing operations and metadata updates.
        /// </remarks>
        public static string InvoiceNumber { get; set; }
        /// <summary>
        /// Stores the current receipt number used for official transaction referencing.
        /// </summary>
        /// <remarks>
        /// Acts as a unique identifier for payment records and metadata updates.
        /// </remarks>
        public static string ReceiptNumber { get; set; }


        /// <summary>
        /// Assigns the active MySQL connection to the internal execution context.
        /// </summary>
        /// <remarks>
        /// Used to bind the external connection source before executing database commands.
        /// </remarks>
        public static MySqlConnection Connection { set { _connection = value; } }
        /// <summary>
        /// Enables or disables the global invoice flag for batch operations.
        /// </summary>
        /// <remarks>
        /// Used to toggle invoice-wide logic across modules, such as status evaluation or export behavior.
        /// </remarks>
        public static bool EnableAllInvoice { set { _allInvoice = value; } }


        /// <summary>
        /// Retrieves the full name of the tenant associated with the current invoice.
        /// </summary>
        public static string TenantName
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbtenants.FullName.ToString(),
                    From: tbtenants.tbtenants.ToString(),
                    Where: tbtenants.TenantID.ToString() + "=" + TenantID);
                _exec.ExecuteSelect();
                return _exec.GetValues[0];
            }
        }
        /// <summary>
        /// Retrieves the room number assigned to the tenant associated with the current invoice.
        /// </summary>
        public static string RoomNumber
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbtenants.Room.ToString(),
                    From: tbtenants.tbtenants.ToString(),
                    Where: tbtenants.TenantID.ToString() + "=" + TenantID);
                _exec.ExecuteSelect();
                return _exec.GetValues[0];
            }
        }
        /// <summary>
        /// Retrieves the tenancy status of the tenant associated with the current invoice.
        /// </summary>
        public static string TenancyStatus
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbtenants.Status.ToString(),
                    From: tbtenants.tbtenants.ToString(),
                    Where: tbtenants.TenantID.ToString() + "=" + TenantID);
                _exec.ExecuteSelect();
                return _exec.GetValues[0];
            }
        }
        /// <summary>
        /// Calculates the total amount received for the current invoice, optionally scoped by receipt number.
        /// </summary>
        /// <remarks>
        /// If the global invoice flag is disabled, the calculation is restricted to the current receipt.
        /// Otherwise, it aggregates all payments tied to the invoice number across multiple receipts.
        /// </remarks>
        public static double Numeric_TotalAmountReceived
        {
            get
            {
                double ar = 0;

                if(_allInvoice == false)
                { 
                    _exec.CommandString = Construct.SelectCommand(
                        Select: tbpayments.AmountPaid.ToString(),
                        From: tbpayments.tbpayments.ToString(),
                        Where:
                            tbpayments.BillNumber.ToString() + "='" + InvoiceNumber + "' AND " +
                            tbpayments.ReceiptNumber.ToString() + "='" + ReceiptNumber + "'");
                    _reader = _exec.Reader;
                    while (_reader.Read())
                        ar += Convert.ToDouble(_reader[0].ToString());
                    _reader.Close();
                    _exec.CloseReader();

                    return ar;
                }
                else
                {
                    _exec.CommandString = Construct.SelectCommand(
                        Select: tbpayments.AmountPaid.ToString(),
                        From: tbpayments.tbpayments.ToString(),
                        Where: tbpayments.BillNumber.ToString() + "='" + InvoiceNumber + "'");
                    _reader = _exec.Reader;
                    while (_reader.Read())
                        ar += Convert.ToDouble(_reader[0].ToString());
                    _reader.Close();
                    _exec.CloseReader();

                    return ar;
                }
            }
        }
        /// <summary>
        /// Converts the total amount received into its full word representation.
        /// </summary>
        /// <remarks>
        /// Formats the numeric value into pesos and centavos, using word-based currency phrasing for display or reporting.
        /// </remarks>
        public static string Words_TotalAmountReceived
        {
            get
            {
                if (Numeric_TotalAmountReceived == 0)
                    return "Zero pesos";

                long pesos = (long)Math.Floor(Numeric_TotalAmountReceived);
                int centavos = (int)((Numeric_TotalAmountReceived - pesos) * 100);

                string words = ConvertNumberToWords(pesos) + " pesos";

                if (centavos > 0)
                    words += " and " + ConvertNumberToWords(centavos) + " centavos";

                return words;

            }
        }
        /// <summary>
        /// Retrieves the payment method used for the current invoice, or returns "Various" if multiple methods are detected.
        /// </summary>
        /// <remarks>
        /// If the global invoice flag is disabled, the method is resolved per receipt.
        /// Otherwise, it aggregates all payment methods tied to the invoice and returns "Various" if inconsistencies are found.
        /// </remarks>
        public static string PaymentMethod
        {
            get
            {
                List<string> PMs = new List<string>();

                if(_allInvoice == false)
                {
                    _exec.CommandString = Construct.SelectCommand(
                        Select: tbpayments.PaymentMethod.ToString(),
                        From: tbpayments.tbpayments.ToString(),
                        Where:
                            tbpayments.BillNumber.ToString() + "='" + InvoiceNumber + "' AND " +
                            tbpayments.ReceiptNumber.ToString() + "='" + ReceiptNumber + "'");
                    _reader = _exec.Reader;
                    while (_reader.Read())
                        PMs.Add(_reader[0].ToString());
                    _reader.Close();
                    _exec.CloseReader();

                    if (PMs.Distinct().Count() == 1)
                        return PMs[0];
                    else
                        return "Various";
                }
                else
                {
                    _exec.CommandString = Construct.SelectCommand(
                        Select: tbpayments.PaymentMethod.ToString(),
                        From: tbpayments.tbpayments.ToString(),
                        Where:
                            tbpayments.BillNumber.ToString() + "='" + InvoiceNumber + "'");
                    _reader = _exec.Reader;
                    while (_reader.Read())
                        PMs.Add(_reader[0].ToString());
                    _reader.Close();
                    _exec.CloseReader();

                    if (PMs.Distinct().Count() == 1)
                        return PMs[0];
                    else
                        return "Various";
                }
            }
        }
        /// <summary>
        /// Counts the number of payment entries associated with the current invoice.
        /// </summary>
        /// <remarks>
        /// If the global invoice flag is disabled, the count is scoped to the current receipt.
        /// Otherwise, it aggregates all payments tied to the invoice number.
        /// </remarks>
        public static int ReceiptCount
        {
            get
            {
                int i = 0;

                if (_allInvoice == false)
                    _exec.CommandString = Construct.SelectCommand(
                        Select: tbpayments.PaymentID.ToString(),
                        From: tbpayments.tbpayments.ToString(),
                        Where:
                            tbpayments.BillNumber.ToString() + "='" + InvoiceNumber + "' AND " +
                            tbpayments.ReceiptNumber.ToString() + "='" + ReceiptNumber + "'");
                else
                    _exec.CommandString = Construct.SelectCommand(
                        Select: tbpayments.PaymentID.ToString(),
                        From: tbpayments.tbpayments.ToString(),
                        Where: tbpayments.BillNumber.ToString() + "='" + InvoiceNumber + "'");
                _reader = _exec.Reader;
                while (_reader.Read())
                    i++;
                _reader.Close();
                _exec.CloseReader();

                return i;
            }
        }
        #endregion

        #region PUBLIC FUNCTIONS
        /// <summary>
        /// Initializes the execution context by binding the active database connection to the command executor.
        /// </summary>
        /// <remarks>
        /// Prepares the system for executing SQL commands by instantiating the MySQL execution engine.
        /// </remarks>
        public static void Initialize()
        {
            _exec = new MySQLExecute(_connection);
            _allInvoice = false;
            InvoiceNumber = "";
            ReceiptNumber = "";
        }
        /// <summary>
        /// Populates the payments preview table with receipt metadata for the current invoice.
        /// </summary>
        /// <remarks>
        /// Executes a conditional query based on the global invoice flag, retrieves receipt details, and inserts them into the preview table for reporting or display.
        /// </remarks>
        public static void PreparePaymentsPreviewTable()
        {
            List<ReceiptMetadata> RM = new List<ReceiptMetadata>();

            if(_allInvoice == false)
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: new string[]
                    {
                        tbpayments.ReceiptNumber.ToString(),
                        tbpayments.TransactionDateTime.ToString(),
                        tbpayments.BillType.ToString(),
                        tbpayments.AmountPaid.ToString(),
                    },
                    From: tbpayments.tbpayments.ToString(),
                    Where:
                        tbpayments.BillNumber.ToString() + "='" + InvoiceNumber + "' AND " +
                        tbpayments.ReceiptNumber.ToString() + "='" + ReceiptNumber + "'");
            }
            else
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: new string[]
                    {
                        tbpayments.ReceiptNumber.ToString(),
                        tbpayments.TransactionDateTime.ToString(),
                        tbpayments.BillType.ToString(),
                        tbpayments.AmountPaid.ToString(),
                    },
                    From: tbpayments.tbpayments.ToString(),
                    Where:
                        tbpayments.BillNumber.ToString() + "='" + InvoiceNumber + "'");
            }
            _reader = _exec.Reader;
            while (_reader.Read())
            {
                RM.Add(new ReceiptMetadata(
                    SetORNumber: _reader[0].ToString(),
                    SetTransactionDT: Convert.ToDateTime(_reader[1].ToString()),
                    SetBillType: _reader[2].ToString(),
                    SetAmountPaid: Convert.ToDouble(_reader[3].ToString())));
            }
            _reader.Close();
            _exec.CloseReader();

            foreach (ReceiptMetadata rm in RM)
            {
                _exec.CommandString = Construct.InsertIntoCommand(
                    InsertInto: tbpaymentpreview_receipts.tbpaymentpreview_receipts.ToString(),
                    InsertMetadata: new InsertColumnMetadata[]
                    {
                            new InsertColumnMetadata(
                                ToColumn: tbpaymentpreview_receipts.ORNumber.ToString(),
                                WithDataType: MySQLDataType.VarChar,
                                WithValue: rm.ORNumber),
                            new InsertColumnMetadata(
                                tbpaymentpreview_receipts.TransactionDateTime.ToString(),
                                MySQLDataType.DateTime,
                                rm.TransactionDT.ToString("yyyy-MM-dd HH:mm:ss")),
                            new InsertColumnMetadata(
                                tbpaymentpreview_receipts.BillType.ToString(),
                                MySQLDataType.VarChar,
                                rm.BillType),
                            new InsertColumnMetadata(
                                tbpaymentpreview_receipts.AmountPaid.ToString(),
                                MySQLDataType.Double,
                                rm.AmountPaid.ToString()) });
                _exec.ExecuteNonQuery();
            }
        }
        #endregion

        #region PRIVATE PROPERTIES
        /// <summary>
        /// Retrieves the tenant ID associated with the current invoice number.
        /// </summary>
        private static int TenantID
        {
            get
            {
                _exec.CommandString = Construct.SelectCommand(
                    Select: tbpayments.TenantID.ToString(),
                    From: tbpayments.tbpayments.ToString(),
                    Where: tbpayments.BillNumber.ToString() + "='" + InvoiceNumber + "'");
                _exec.ExecuteSelect();
                return Convert.ToInt32 (_exec.GetValues[0]);
            }
        }
        /// <summary>
        /// Converts a numeric value into its corresponding word representation.
        /// </summary>
        private static string ConvertNumberToWords(long number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + ConvertNumberToWords(Math.Abs(number));

            string[] units = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] teens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tens = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] thousands = { "", "thousand", "million", "billion" };

            string words = "";
            int thousandGroup = 0;

            while (number > 0)
            {
                int chunk = (int)(number % 1000);
                if (chunk > 0)
                {
                    string chunkWords = "";

                    int hundreds = chunk / 100;
                    int remainder = chunk % 100;

                    if (hundreds > 0)
                        chunkWords += units[hundreds] + " hundred ";

                    if (remainder >= 10 && remainder < 20)
                        chunkWords += teens[remainder - 10];
                    else
                    {
                        int ten = remainder / 10;
                        int unit = remainder % 10;

                        if (ten > 0)
                            chunkWords += tens[ten] + " ";

                        if (unit > 0)
                            chunkWords += units[unit];
                    }

                    words = chunkWords.Trim() + " " + thousands[thousandGroup] + " " + words;
                }

                number /= 1000;
                thousandGroup++;
            }

            return words.Trim();
        }
        #endregion

        #region PRIVATE STRUCT
        private struct ReceiptMetadata
        {
            public string ORNumber { get; set; }
            public DateTime TransactionDT { get; set; }
            public string BillType { get; set; }
            public double AmountPaid { get; set; }

            public ReceiptMetadata(string SetORNumber, DateTime SetTransactionDT, string SetBillType, double SetAmountPaid)
            {
                ORNumber = SetORNumber;
                TransactionDT = SetTransactionDT;
                BillType = SetBillType;
                AmountPaid = SetAmountPaid;
            }
        }
        #endregion
    }
}
