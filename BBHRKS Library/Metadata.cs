using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using BBHRKS.MySQL;

namespace BBHRKS.Metadata
{
    /// <summary>
    /// Provides structured access to metadata values used across BBHRKS modules, including tenants, rooms, utilities, payments, and billing.
    /// </summary>
    /// <remarks>
    /// The <c>Metadata</c> class organizes static metadata into nested categories, each exposing constants, value lists, and database-driven properties.
    /// It supports both hardcoded enumerations (e.g., status labels) and dynamic retrieval from the <c>tbmetadata</c> table in <c>dbBBHRKS</c>.
    /// This class is designed for centralized reference, reducing duplication and ensuring consistency across business logic and UI components.
    /// </remarks>
    public static class Metadata
    {
        public const string CONN_STR = "server=localhost; user=root; sslmode=none; database=dbBBHRKS";

        public static class Tenants
        {
            public static class RentType
            {
                public static List<string> Values
                {
                    get
                    {
                        List<string> v = new List<string>();
                        v.Clear();
                        v.Add(Fixed);
                        v.Add(Monthly);
                        return v;
                    }
                }
                public static string Fixed { get { return "Fixed"; } }
                public static string Monthly { get { return "Monthly"; } }
            }
            public static class Employment
            {
                public static string Employed { get { return "Employed"; } }
                public static string SelfEmployed { get { return "Self-Employed"; } }
                public static string Unemployed { get { return "Unemployed"; } }
                public static string Student { get { return "Student"; } }
                public static List<string> Values
                {
                    get
                    {
                        List<string> v = new List<string>();
                        v.Clear();
                        v.Add(Employed);
                        v.Add(SelfEmployed);
                        v.Add(Unemployed);
                        v.Add(Student);
                        return v;
                    }
                }
            }
            public static class TenancyStatus
            {
                public static string Active { get { return "Active"; } }
                public static string Inactive { get { return "Inactive"; } }
                public static List<string> Values { get { return ListValues(new string[] { Active, Inactive }); } }
            }
        }
        public static class Rooms
        {
            public static class Status
            {
                public static string Vacant { get { return "Vacant"; } }
                public static string Occupied { get { return "Occupied"; } }
                public static List<string> Values
                {
                    get
                    {
                        List<string> v = new List<string>();
                        v.Clear();
                        v.Add(Vacant);
                        v.Add(Occupied);
                        return v;
                    }
                }
            }
        }
        public static class InternetPlan
        {
            public static class Status
            {
                public static string Available { get { return "Available"; } }
                public static string NotAvailable { get { return "Not Available"; } }
                public static List<string> Values
                {
                    get
                    {
                        List<string> v = new List<string>();
                        v.Clear();
                        v.Add(Available);
                        v.Add(NotAvailable);
                        return v;
                    }
                }
            }
        }
        public static class Bills
        {
            public static class Status
            {
                public const string Unpaid = "Unpaid";
                public const string Partial = "Partial";
                public const string Paid = "Paid";
                public const string Transferred = "Transferred";
                
                public static List<string> Values
                {
                    get { return ListValues(new string[] { Unpaid, Partial, Paid, Transferred }); }
                }
            }
            public static class BillTypes
            {
                public const string Water = "Water";
                public const string Electricity = "Electricity";
                public const string Rental = "Rental";
                public const string Internet = "Internet";
                
                public static string[] Values { get { return new string[] { Water, Electricity, Rental, Internet }; } }
            }
        }
        public static class Water
        {
            public static class Consumption
            {
                public const string Unit = "m^3";
                /// <summary>
                /// Retrieves the unit price value from the <c>tbmetadata</c> table where category is <c>Water Consumption</c>
                /// and details is <c>Unit Price</c>.
                /// </summary>
                /// <remarks>
                /// This property establishes a new MySQL connection to the <c>dbBBHRKS</c> database, executes a SELECT query,
                /// reads the result, and converts the first column to a <see cref="double"/>. The connection and reader are closed after use.
                /// </remarks>
                /// <exception cref="MySqlException">
                /// Thrown if the connection or command execution fails due to server issues, query errors, or other MySQL-related problems.
                /// </exception>
                /// <exception cref="InvalidCastException">
                /// Thrown if the retrieved value cannot be converted to a <see cref="double"/>.
                /// </exception>
                public static double UnitPrice
                {
                    get
                    {
                        MySqlConnection conn = new MySqlConnection();
                        MySqlCommand cmd = new MySqlCommand();
                        MySqlDataReader reader;
                        double up = 0;
                        
                        conn.ConnectionString = "server=localhost; user=root; sslmode=none; database=dbBBHRKS";
                        conn.Open();
                        Database.SetupMySQLCommandConnection(cmd, conn, System.Data.CommandType.Text);

                        cmd.CommandText = Generate.SelectCommand(new string[]
                        {
                            "Value" }, "tbmetadata", "category='Water Consumption' AND details='Unit Price'");
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        up = Convert.ToDouble(reader[0].ToString());
                        reader.Close();
                        conn.Close();
                        conn.Dispose();

                        return up;
                    }
                }
            }
        }
        public static class Electricity
        {
            public static class Consumption
            {
                public const string Unit= "kWh";
                /// <summary>
                /// Retrieves the unit price value from the <c>tbmetadata</c> table where category is <c>Electricity Consumption</c>
                /// and details is <c>Unit Price</c>.
                /// </summary>
                /// <remarks>
                /// This property initializes a new MySQL connection to the <c>dbBBHRKS</c> database, executes a SELECT query,
                /// reads the first result, and converts it to a <see cref="double"/>. The connection and reader are closed after execution.
                /// </remarks>
                /// <exception cref="MySqlException">
                /// Thrown if the connection or command execution fails due to server issues, query errors, or other MySQL-related problems.
                /// </exception>
                /// <exception cref="InvalidCastException">
                /// Thrown if the retrieved value cannot be converted to a <see cref="double"/>.
                /// </exception>
                public static double UnitPrice
                {
                    get
                    {
                        MySqlConnection conn = new MySqlConnection();
                        MySqlCommand cmd = new MySqlCommand();
                        MySqlDataReader reader;
                        double up = 0;

                        conn.ConnectionString = "server=localhost; user=root; sslmode=none; database=dbBBHRKS";
                        conn.Open();
                        Database.SetupMySQLCommandConnection(cmd, conn, System.Data.CommandType.Text);

                        cmd.CommandText = Generate.SelectCommand(new string[]
                        {
                            "Value" }, "tbmetadata", "category='Electricity Consumption' AND details='Unit Price'");
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        up = Convert.ToDouble(reader[0].ToString());
                        reader.Close();
                        conn.Close();
                        conn.Dispose();

                        return up;
                    }
                }
            }
        }
        public static class Payment
        {
            /// <summary>
            /// Retrieves the last receipt number from the <c>tbmetadata</c> table where category is <c>Payment</c>
            /// and details is <c>Last Receipt</c>.
            /// </summary>
            /// <remarks>
            /// This property creates a new MySQL connection to the <c>dbBBHRKS</c> database, executes a SELECT query,
            /// reads the first result, and converts it to an <see cref="int"/>. The connection and reader are explicitly closed and disposed after use.
            /// </remarks>
            /// <exception cref="MySqlException">
            /// Thrown if the connection or command execution fails due to server issues, query errors, or other MySQL-related problems.
            /// </exception>
            /// <exception cref="InvalidCastException">
            /// Thrown if the retrieved value cannot be converted to an <see cref="int"/>.
            /// </exception>
            public static int LastReceipt
            {
                get
                {
                    MySqlConnection conn = new MySqlConnection();
                    MySqlCommand cmd = new MySqlCommand();
                    MySqlDataReader reader;
                    int lr = 0;

                    conn.ConnectionString = "server=localhost; user=root; sslmode=none; database=dbBBHRKS";
                    conn.Open();
                    Database.SetupMySQLCommandConnection(cmd, conn, System.Data.CommandType.Text);
                    cmd.CommandText = Generate.SelectCommand(new string[]
                    {
                        "Values" }, "tbmetadata", "category='Payment' AND details='Last Receipt'");
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    lr = Convert.ToInt32(reader[0].ToString());
                    reader.Close();
                    conn.Close();
                    conn.Dispose();

                    return lr;
                }
            }
            /// <summary>
            /// Generates a new receipt number based on the current date, resetting the counter on January 1st if necessary.
            /// </summary>
            /// <param name="CurrentDate">The current date used to determine whether the receipt counter should be reset.</param>
            /// <returns>
            /// An incremented receipt number. If the date is January 1st and the last receipt is non-zero, the counter is reset before incrementing.
            /// </returns>
            /// <remarks>
            /// This method opens a MySQL connection to the <c>dbBBHRKS</c> database and checks if the current date is January 1st.
            /// If so, and the last receipt number is non-zero, it resets the <c>Last Receipt</c> value in the <c>tbmetadata</c> table to zero.
            /// The connection is closed and disposed after execution. The receipt number is then incremented and returned.
            /// </remarks>
            /// <exception cref="MySqlException">
            /// Thrown if the connection or command execution fails due to server issues, query errors, or other MySQL-related problems.
            /// </exception>
            public static int GenerateNewReceipt(DateTime CurrentDate)
            {
                MySqlConnection conn = new MySqlConnection();
                MySqlCommand cmd = new MySqlCommand();
                int lr = LastReceipt;

                conn.ConnectionString = "server=localhost; user=root; sslmode=none; database=dbBBHRKS";
                conn.Open();
                Database.SetupMySQLCommandConnection(cmd, conn, System.Data.CommandType.Text);

                if (CurrentDate.Month == 1 & CurrentDate.Day == 1)
                {
                    if(lr != 0)
                    {
                        cmd.CommandText = Generate.UpdateCommand(
                            "tbmetadata",
                            new Generate.UpdateInfo[]
                            {
                                new Generate.UpdateInfo("Value", "0", Generate.DataTypes.Int) },
                            "category='Payment' AND details='Last Receipt'");
                        cmd.ExecuteNonQuery();
                        lr = 0;
                    }
                }
                conn.Close();
                conn.Dispose();
                lr++;

                return lr;
            }

            public static class Method
            {
                /// <summary>
                /// Retrieves a sorted list of enabled payment methods from the database.
                /// </summary>
                /// <returns>
                /// A <see cref="List{string}"/> containing all enabled payment method names from <c>tbpaymentmethod</c>,
                /// sorted in ascending order by the <c>Method</c> column.
                /// </returns>
                /// <remarks>
                /// This property executes a SELECT query on the <c>tbpaymentmethod</c> table, retrieving the <c>Method</c> column
                /// where <c>Status='Enabled'</c>. The <c>Method</c> column is formatted as <c>VARCHAR</c>, and values are returned
                /// as strings. Results are ordered using <c>ORDER BY Method ASC</c>. The command connection is configured via
                /// <c>BBHRKS_DB.SetupMySQLCommandConnection</c>, and all resources are properly disposed after execution.
                /// </remarks>
                /// <exception cref="MySqlException">
                /// Thrown if the database connection or command execution fails.
                /// </exception>
                /// <exception cref="InvalidCastException">
                /// Thrown if the retrieved <c>VARCHAR</c> value cannot be converted to a string.
                /// </exception>
                public static List<string> PaymentMethods
                {
                    get
                    {
                        MySqlConnection conn = new MySqlConnection();
                        MySqlCommand cmd = new MySqlCommand();
                        MySqlDataReader reader;
                        List<string> pM = new List<string>();

                        conn.ConnectionString = "server=localhost; user=root; sslmode=none; database=dbBBHRKS";
                        conn.Open();
                        Database.SetupMySQLCommandConnection(cmd, conn, System.Data.CommandType.Text);
                        cmd.CommandText = Generate.SelectCommand(
                            new string[] { "Method" },
                            "tbpaymentmethod",
                            "Status='Enabled'",
                            "Method",
                            Generate.SortBy.Ascending);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                            pM.Add(reader[0].ToString());
                        reader.Close();
                        conn.Close();
                        conn.Dispose();

                        return pM;
                    }
                }
            }
        }
        public static class Internet
        {
            /// <summary>
            /// Retrieves the next Internet due date based on the current date and the configured due day.
            /// </summary>
            /// <returns>
            /// A <see cref="DateTime"/> value representing the next due date.
            /// If today's day exceeds the configured due day, the result rolls over to the same day in the next month.
            /// </returns>
            /// <remarks>
            /// This property queries the <c>tbmetadata</c> table for the Internet due day value under the condition
            /// <c>category='Internet' AND details='Due Date'</c>. It then calculates the next due date by comparing
            /// the current day with the configured due day, adjusting for month rollover and clamping to the last valid
            /// day of the target month (including leap year handling).
            /// </remarks>
            /// <exception cref="MySqlException">
            /// Thrown if the database connection or query execution fails.
            /// </exception>
            /// <exception cref="FormatException">
            /// Thrown if the retrieved value cannot be converted to an integer.
            /// </exception>
            public static DateTime DueDate
            {
                get
                {
                    MySqlConnection conn = new MySqlConnection();
                    MySqlCommand cmd = new MySqlCommand();
                    MySqlDataReader reader;
                    int iDD = 0;

                    conn.ConnectionString = "server=localhost; user=root; sslmode=none; database=dbBBHRKS";
                    conn.Open();
                    Database.SetupMySQLCommandConnection(cmd, conn, System.Data.CommandType.Text);
                    cmd.CommandText = Generate.SelectCommand(
                        new string[] { "value" },
                        "tbmetadata",
                        "category='Internet' AND details='Due Date'");
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    iDD = Convert.ToInt32(reader[0].ToString());
                    reader.Close();
                    conn.Close();
                    conn.Dispose();

                    DateTime baseDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                    if (DateTime.Now.Day > iDD)
                        baseDate = baseDate.AddMonths(1);

                    int maxDay = DateTime.DaysInMonth(baseDate.Year, baseDate.Month);
                    iDD = Math.Min(iDD, maxDay);

                    return new DateTime(baseDate.Year, baseDate.Month, iDD);
                }
            }
        }
        public static class Rental
        {
            /// <summary>
            /// Retrieves the configured monthly due amount for rental billing from the database.
            /// </summary>
            /// <returns>
            /// A <see cref="double"/> value representing the monthly rental charge.
            /// </returns>
            /// <remarks>
            /// This property queries the <c>tbmetadata</c> table using the condition <c>mid=7</c> to fetch the value associated with rental billing.
            /// The result is parsed as a double and returned. The connection is properly initialized, opened, and disposed after execution.
            /// </remarks>
            /// <exception cref="MySqlException">
            /// Thrown if the database connection or command execution fails.
            /// </exception>
            /// <exception cref="FormatException">
            /// Thrown if the retrieved value cannot be converted to a double.
            /// </exception>
            public static double MonthlyDue
            {
                get
                {
                    MySqlConnection conn = new MySqlConnection();
                    MySqlCommand cmd = new MySqlCommand();
                    MySqlDataReader reader;
                    double mD = 0;

                    conn.ConnectionString = "server=localhost; user=root; sslmode=none; database=dbBBHRKS";
                    conn.Open();
                    Database.SetupMySQLCommandConnection(cmd, conn, System.Data.CommandType.Text);
                    cmd.CommandText = Generate.SelectCommand(
                        new string[] { "Value" },
                        "tbmetadata",
                        "mid=7");
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    mD = Convert.ToDouble(reader[0].ToString());
                    reader.Close();
                    conn.Close();
                    conn.Dispose();

                    return mD;
                }
            }
        }
        public static class Additionals
        {
            public static class Status
            {
                public const string Unpaid = "Unpaid";
                public const string Partial = "Partial";
                public const string Paid = "Paid";
            }
        }
        public static class User
        {
            public enum Status
            {
                Enabled,
                Disabled
            }

            public enum Level
            {
                HIGH,
                LOW
            }

            public enum Keys
            {
                BBHRKS,
                BBH,
                RKS
            }
        }

        #region PRIVATE FUNCTIONS
        /// <summary>
        /// Converts an array of strings into a list of strings.
        /// </summary>
        /// <param name="Values">The array of string values to be copied into the list.</param>
        /// <returns>
        /// A <see cref="List{String}"/> containing all elements from the input array.
        /// </returns>
        /// <remarks>
        /// This method iterates through the input array and adds each element to a newly instantiated list.
        /// </remarks>
        private static List<string> ListValues(string[] Values)
        {
            List<string> v = new List<string>();
            for (int a = 0; a < Values.Length; a++)
                v.Add(Values[a]);
            return v;
        }
        #endregion
    }
}
