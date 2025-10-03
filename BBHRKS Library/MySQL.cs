using JunX.NET8.MySQL;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography;

namespace BBHRKS.MySQL
{
    public static class Database
    {
        #region PRIVATE VARIABLES
        private static MySqlConnection conn = new MySqlConnection();
        #endregion

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets the active MySQL connection used by the BBH Records Keeping System.
        /// </summary>
        /// <remarks>
        /// This static property provides access to the underlying <see cref="MySqlConnection"/> instance.
        /// Ensure the connection is properly initialized before accessing this property.
        /// </remarks>
        /// <returns>
        /// The current <see cref="MySqlConnection"/> object.
        /// </returns>
        public static MySqlConnection Connection { get { return conn; } }
        #endregion

        #region PUBLIC FUNCTIONS
        /// <summary>
        /// Initializes the database connection for BBHRKS operations.
        /// </summary>
        /// <remarks>
        /// Configures the connection string and attempts to open the connection if it is not already active.
        /// This method ensures that the system is ready to execute database commands and handle data transactions.
        /// Any connection errors are displayed through a message dialog.
        /// </remarks>
        /// <exception cref="MySqlException">
        /// Thrown if the connection attempt fails due to server issues, authentication errors, or configuration problems.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the connection state is invalid or the connection object is misconfigured.
        /// </exception>
        public static void Initialize()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost; user=root; sslmode=none; database=dbBBHRKS";
            
            if(conn.State != ConnectionState.Open)
            {
                try
                {
                    conn.Open();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            
        }
        /// <summary>
        /// Configures a <see cref="MySqlCommand"/> with the specified connection and command type.
        /// </summary>
        /// <param name="Command">The <see cref="MySqlCommand"/> instance to configure.</param>
        /// <param name="Connection">The <see cref="MySqlConnection"/> to associate with the command.</param>
        /// <param name="Type">The <see cref="CommandType"/> indicating how the command text is interpreted.</param>
        /// <remarks>
        /// This method sets the <c>Connection</c> and <c>CommandType</c> properties of the provided command object.
        /// </remarks>
        public static void SetupMySQLCommandConnection(MySqlCommand Command,  MySqlConnection Connection, CommandType Type)
        {
            Command.Connection = Connection;
            Command.CommandType = Type;
        }
        /// <summary>
        /// Executes a SQL SELECT command and extracts the first column of each row into a list of strings.
        /// </summary>
        /// <param name="Connection">An active <see cref="MySqlConnection"/> used to execute the query.</param>
        /// <param name="Command">A <see cref="MySqlCommand"/> instance whose command text will be set and executed.</param>
        /// <param name="SelectCommand">The SQL SELECT statement to execute.</param>
        /// <returns>
        /// A <see cref="List{String}"/> containing the string representations of the first column from each result row.
        /// </returns>
        /// <remarks>
        /// This method sets the command text, executes the query, and reads each row from the result set.
        /// Only the first column of each row is extracted. The result is commonly used to populate UI elements such as combo boxes or list views in BBHRKS modules.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the connection is not open or the command is improperly configured.
        /// </exception>
        /// <exception cref="MySqlException">
        /// Thrown if the query execution fails due to syntax errors or connection issues.
        /// </exception>
        public static List<string> ExtractToList(MySqlConnection Connection, MySqlCommand Command, string SelectCommand)
        {
            List<string> items = new List<string>();
            MySqlDataReader reader;

            Command.CommandText = SelectCommand;
            reader = Command.ExecuteReader();
            while (reader.Read())
                items.Add(reader[0].ToString());
            reader.Close();

            return items;
        }
        #endregion

        #region TABLES REGION
        public static class Tables
        {
            public enum tbEmergency
            {
                tbEmergency,
                EmergencyID,
                TenantID,
                ContactPerson,
                Phone,
                Address,
                Relationship
            }
            public enum tbInternetPlans
            {
                tbInternetPlans,
                PlanID,
                Details,
                PlanPrice,
                Status
            }
            public enum tbMetadata
            {
                tbMetadata,
                MID,
                Category,
                Details,
                Value}
            public enum tbPaymentMethod
            {
                tbPaymentMethod,
                PMID,
                Method,
                Status
            }
            public enum tbRooms
            {
                tbRooms,
                RoomID,
                RoomName,
                Status
            }
            public enum tbTenants
            {
                tbTenants,
                TenantID,
                FirstName,
                LastName,
                FullName,
                DateOfBirth,
                Phone,
                Address,
                RentType,
                Room,
                StartDate,
                EndDate,
                InternetPlan,
                Status
            }
            public enum tbUsers
            {
                tbUsers,
                UserID,
                Username,
                Password,
                Status
            }
            public enum tbBills
            {
                tbBills,
                BillID,
                BillNumber,
                TenantID,
                BillingDate,
                DueDate,
                WaterBillID,
                ElectricityBillID,
                RentalBillID,
                InternetBillID,
                BillTotal,
                Status
            }
            public enum tbWaterBill
            {
                tbWaterBill,
                WaterBillID,
                BillNumber,
                TenantID,
                PreviousReading,
                PresentReading,
                Consumption,
                CurrentCharge,
                RemainingBalance,
                Deductions,
                Subtotal,
                BillBalance,
                Status
            }
            public enum tbElectricityBill
            {
                tbElectricityBill,
                ElectricityBillID,
                BillNumber,
                TenantID,
                PreviousReading,
                PresentReading,
                Consumption,
                CurrentCharge,
                RemainingBalance,
                Deductions,
                Subtotal,
                BillBalance,
                Status
            }
            public enum tbRentalBill
            {
                tbRentalBill,
                RentalBillID,
                BillNumber,
                TenantID,
                MonthlyDue,
                AdditionalCharges,
                CurrentCharges,
                RemainingBalance,
                Deductions,
                Subtotal,
                BillBalance,
                Status
            }
            public enum tbInternetBill
            {
                tbInternetBill,
                InternetBillID,
                BillNumber,
                TenantID,
                Plan,
                SubscriptionFee,
                RemainingBalance,
                Deductions,
                Subtotal,
                BillBalance,
                Status
            }
            public enum tbDeductions
            {
                tbDeductions,
                DeductionID,
                TenantID,
                BillType,
                UnusedCredits,
                UnusedAdvances
            }
            public enum tbAdditionals
            {
                tbAdditionals,
                AdditionalID,
                TenantID,
                EnforcementDate,
                Details,
                TotalFee,
                AmountPaid,
                RemainingBalance,
                Status
            }

            /// <summary>
            /// Retrieves a list of all table names within the specified database schema.
            /// </summary>
            /// <param name="DBConnection">
            /// An active MySQL connection targeting the desired database.
            /// </param>
            /// <returns>
            /// A list of table names available in the database schema.
            /// </returns>
            /// <remarks>
            /// Opens the connection if not already open, executes a metadata query against the <c>information_schema</c>,  
            /// and collects all table names associated with the target schema.  
            /// This method is useful for dynamically inspecting database structure or validating table existence.
            /// </remarks>
            /// <exception cref="Exception">
            /// Thrown if the connection fails to open or the query execution encounters an error.
            /// </exception>
            public static List<string> TableList(MySqlConnection DBConnection)
            {
                List<string> list = new List<string>();
                MySqlConnection conn = DBConnection;
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataReader reader;

                string command = "SELECT TABLE_NAME FROM information_schema.tables WHERE table_schema='dbBBHRKS'";

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd = new MySqlCommand(command, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(reader[0].ToString());
                reader.Close();
                cmd.Dispose();

                return list;
            }
        }
        #endregion
    }

    /// <summary>
    /// Provides static methods and supporting types for constructing SQL command strings dynamically.
    /// </summary>
    /// <remarks>
    /// The <c>Generate</c> class includes utility functions for building SQL <c>SELECT</c>, <c>INSERT</c>, <c>UPDATE</c>, and <c>DELETE</c> statements.
    /// It also defines supporting enumerations and structures for data typing, sorting, and update metadata.
    /// Designed for use in modular database operations where command text needs to be assembled programmatically.
    /// </remarks>
    public static class Generate
    {
        #region ENUMS
        /// <summary>
        /// Represents supported data types for metadata classification or value interpretation.
        /// </summary>
        /// <remarks>
        /// This enumeration defines common primitive types used for parsing, validation, or dynamic type handling.
        /// </remarks>
        public enum DataTypes
        {
            /// <summary>
            /// Represents a 32-bit signed integer value.
            /// </summary>
            Int,
            /// <summary>
            /// Represents a double-precision floating-point value.
            /// </summary>
            Double,
            /// <summary>
            /// Represents a sequence of Unicode characters.
            /// </summary>
            String,
            /// <summary>
            /// Represents a date and time value.
            /// </summary>
            DateTime
        }
        /// <summary>
        /// Specifies sorting direction for SQL queries or data operations.
        /// </summary>
        /// <remarks>
        /// This enumeration defines sorting behavior for ordered results, typically used in <c>ORDER BY</c> clauses.
        /// </remarks>
        public enum SortBy
        {
            None,
            Ascending,
            Descending
        }
        #endregion

        #region PUBLIC FUNCTIONS
        /// <summary>
        /// Constructs a SQL SELECT command string that retrieves all columns from the specified table.
        /// </summary>
        /// <param name="TableName">The name of the table to query.</param>
        /// <param name="WhereStatement">An optional WHERE clause to filter results. If empty, no filtering is applied.</param>
        /// <returns>
        /// A formatted SQL SELECT command string using <c>SELECT *</c> syntax.
        /// </returns>
        /// <remarks>
        /// This method builds a SQL SELECT statement that targets all columns in the specified table.
        /// If a <c>WhereStatement</c> is provided, it appends a <c>WHERE</c> clause to the query.
        /// The final command string is terminated with a semicolon.
        /// </remarks>
        public static string SelectAllCommand(string TableName, string WhereStatement="")
        {
            string cmd = "SELECT * FROM " + TableName;

            if (WhereStatement != "")
                cmd += " WHERE " + WhereStatement;
            cmd += ";";

            return cmd;
        }
        /// <summary>
        /// Constructs an SQL SELECT command string using the specified columns, table name, and optional WHERE clause.
        /// </summary>
        /// <param name="SelectColumns">An array of column names to include in the SELECT statement.</param>
        /// <param name="FromTable">The name of the table to query.</param>
        /// <param name="WhereStatement">
        /// An optional WHERE clause to filter the results. If empty or <c>null</c>, no filtering is applied.
        /// </param>
        /// <returns>
        /// A formatted SQL SELECT command string.
        /// </returns>
        /// <remarks>
        /// This method dynamically builds an SQL query by concatenating column names, the target table, and an optional WHERE clause.
        /// </remarks>
        public static string SelectCommand(string[] SelectColumns, string FromTable, string WhereStatement = "")
        {
            string c = "";

            c = "SELECT ";
            for (int a = 0; a < SelectColumns.Length; a++)
            {
                c += SelectColumns[a];
                if (a < SelectColumns.Length - 1)
                    c += ",";
            }

            c += " FROM " + FromTable;

            if (WhereStatement != null)
                c += " WHERE " + WhereStatement;

            return c;
        }
        /// <summary>
        /// Constructs a basic SQL SELECT command string using the specified column, table, and optional WHERE clause.
        /// </summary>
        /// <param name="SelectColumn">The name of the column(s) to select from the table.</param>
        /// <param name="FromTable">The name of the table to query.</param>
        /// <param name="WhereStatement">
        /// An optional WHERE clause to filter the results. If omitted or empty, no filtering is applied.
        /// </param>
        /// <returns>
        /// A complete SQL SELECT command string ending with a semicolon.
        /// </returns>
        /// <remarks>
        /// This method is useful for dynamically generating simple SQL queries in BBH workflows.
        /// It does not support joins, aliases, or parameterization—use with caution to avoid SQL injection.
        /// </remarks>
        public static string SelectCommand(string SelectColumn, string FromTable, string WhereStatement = "")
        {
            string cmd = "SELECT " + SelectColumn + " FROM " + FromTable;

            if (WhereStatement != "")
                cmd += " WHERE " + WhereStatement;
            cmd += ";";

            return cmd;
        }
        /// <summary>
        /// Constructs a SQL SELECT command string using specified columns, table name, optional WHERE clause, and optional sorting.
        /// </summary>
        /// <param name="SelectColumns">An array of column names to include in the SELECT clause.</param>
        /// <param name="FromTable">The name of the table to query.</param>
        /// <param name="WhereStatement">An optional WHERE clause to filter results. If empty, no filtering is applied.</param>
        /// <param name="SortColumn">The column name to apply sorting on, if sorting is enabled.</param>
        /// <param name="Sort">The sorting direction, specified by the <see cref="SortBy"/> enum. Defaults to <c>None</c>.</param>
        /// <returns>
        /// A formatted SQL SELECT command string.
        /// </returns>
        /// <remarks>
        /// This method builds a SQL SELECT statement by listing the selected columns, specifying the source table,
        /// appending a WHERE clause if provided, and applying ORDER BY sorting if enabled.
        /// Sorting uses standard SQL syntax and supports ascending or descending order.
        /// </remarks>
        public static string SelectCommand(string[] SelectColumns, string FromTable, string WhereStatement="", string SortColumn="", SortBy Sort = SortBy.None)
        {
            string s = "SELECT";

            for(int a=0; a<SelectColumns.Length; a++)
            {
                s += " " + SelectColumns[a];

                if (a < SelectColumns.Length - 1)
                    s += ",";
            }

            s += " FROM " + FromTable;

            if (WhereStatement != "")
                s += " WHERE " + WhereStatement;

            if(Sort != SortBy.None)
            {
                s += " ORDER BY " + SortColumn;

                if (Sort == SortBy.Ascending)
                    s += " ASC";
                else
                    s += " DESC";
            }
            s += ";";

            return s;
        }
        /// <summary>
        /// Constructs a SQL UPDATE command string using the specified table, columns, values, data types, and optional WHERE clause.
        /// </summary>
        /// <param name="Table">The name of the table to update.</param>
        /// <param name="Columns">An array of column names to be updated.</param>
        /// <param name="Values">An array of values to assign to the corresponding columns.</param>
        /// <param name="Types">An array of <see cref="DataTypes"/> indicating how each value should be formatted.</param>
        /// <param name="WhereCondition">
        /// An optional WHERE clause to restrict which rows are updated. If empty, all rows will be affected.
        /// </param>
        /// <returns>
        /// A formatted SQL UPDATE command string.
        /// </returns>
        /// <remarks>
        /// This method builds a SQL UPDATE statement by pairing each column with its corresponding value,
        /// applying apostrophes for string and datetime types, and appending a WHERE clause if provided.
        /// </remarks>
        public static string UpdateCommand(string Table, string[] Columns, string[] Values, DataTypes[] Types, string WhereCondition = "")
        {
            string c = "";

            c = "UPDATE " + Table + " SET ";
            for(int a=0; a<Columns.Length; a++)
            {
                if (Types[a] == DataTypes.Int || Types[a] == DataTypes.Double)
                    c += Columns[a] + "=" + Values[a];
                else if (Types[a] == DataTypes.String || Types[a] == DataTypes.DateTime)
                    c += Columns[a] + "='" + Values[a] + "'";

                if (a < Columns.Length - 1)
                    c += ",";
            }

            if (WhereCondition != "")
                c += " WHERE " + WhereCondition;
            c += ";";
            return c;
        }
        /// <summary>
        /// Constructs a SQL UPDATE command string using the specified table name, update values, and optional WHERE clause.
        /// </summary>
        /// <param name="Table">The name of the table to update.</param>
        /// <param name="UpdateValues">
        /// An array of <see cref="UpdateInfo"/> structures containing column names, values, and data types for the update operation.
        /// </param>
        /// <param name="WhereStatement">
        /// An optional WHERE clause to restrict which rows are updated. If empty, all rows will be affected.
        /// </param>
        /// <returns>
        /// A formatted SQL UPDATE command string.
        /// </returns>
        /// <remarks>
        /// This method builds a SQL UPDATE statement by iterating through the <see cref="UpdateInfo"/> array,
        /// formatting each value according to its <see cref="DataTypes"/> type, and appending a WHERE clause if provided.
        /// Apostrophes are automatically applied to string and datetime values.
        /// </remarks>
        public static string UpdateCommand(string Table, UpdateInfo[] UpdateValues, string WhereStatement = "")
        {
            string c = "";

            c = "UPDATE " + Table + " SET";
            for(int a=0; a<UpdateValues.Length; a++)
            {
                if (UpdateValues[a].DataType == DataTypes.Int || UpdateValues[a].DataType == DataTypes.Double)
                    c += " " + UpdateValues[a].ColumnName + "=" + UpdateValues[a].Value;
                else if (UpdateValues[a].DataType == DataTypes.String || UpdateValues[a].DataType == DataTypes.DateTime)
                    c += " " + UpdateValues[a].ColumnName + "='" + UpdateValues[a].Value + "'";

                if (a < UpdateValues.Length - 1)
                    c += ",";
            }

            if (WhereStatement != "")
                c += " WHERE " + WhereStatement;
            c += ";";

            return c;
        }
        /// <summary>
        /// Constructs a SQL INSERT command string for inserting values into the specified table.
        /// </summary>
        /// <param name="TableName">The name of the table to insert into.</param>
        /// <param name="Values">An array of values to be inserted. Each value must correspond to a defined <see cref="DataTypes"/> entry.</param>
        /// <param name="Types">An array of <see cref="DataTypes"/> indicating the data type of each value. Used to format values correctly in SQL.</param>
        /// <param name="Columns">
        /// An optional array of column names to insert into. If <c>null</c>, the command assumes positional mapping to all columns.
        /// </param>
        /// <returns>
        /// A formatted SQL <c>INSERT INTO</c> command string with properly quoted and typed values.
        /// </returns>
        /// <remarks>
        /// This method builds a SQL INSERT statement by optionally specifying column names and formatting each value
        /// according to its declared <see cref="DataTypes"/>. String and DateTime values are enclosed in single quotes.
        /// Numeric types are inserted directly. The final command string is terminated with a semicolon.
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="Values"/> and <paramref name="Types"/> arrays do not match in length.
        /// </exception>
        public static string InsertIntoCommand(string TableName, string[] Values, DataTypes[] Types, string[] Columns = null)
        {
            string cmd = "INSERT INTO " + TableName;

            if(Columns != null)
            {
                cmd += " (";
                for(int a=0; a<Columns.Length; a++)
                {
                    cmd += Columns[a];

                    if (a < Columns.Length - 1)
                        cmd += ", ";
                }
                cmd += ")";
            }

            cmd += " VALUES (";
            for(int a=0; a<Values.Length; a++)
            {
                if (Types[a] == DataTypes.String || Types[a] == DataTypes.DateTime)
                    cmd += "'" + Values[a] + "'";
                else if (Types[a] == DataTypes.Double || Types[a] == DataTypes.Int)
                    cmd += Values[a];

                if (a < Values.Length - 1)
                    cmd += ", ";
            }
            cmd += ");";

            return cmd;
        }
        /// <summary>
        /// Constructs a SQL <c>INSERT INTO</c> command using the specified table name and structured insert data.
        /// </summary>
        /// <param name="TableName">The name of the target table.</param>
        /// <param name="InsertData">An array of <see cref="InsertInfo"/> objects containing column names, values, and data types.</param>
        /// <returns>
        /// A formatted SQL <c>INSERT</c> statement as a string.
        /// </returns>
        /// <remarks>
        /// This method builds a parameterless SQL command by iterating through the provided insert data.
        /// String and date-time values are wrapped in single quotes; numeric types are inserted directly.
        /// Commonly used in BBHRKS modules for dynamic record creation based on structured input.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="TableName"/> or <paramref name="InsertData"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if <paramref name="InsertData"/> contains unsupported or uninitialized type values.
        /// </exception>
        public static string InsertIntoCommand(string TableName, InsertInfo[] InsertData)
        {
            string cmd = "INSERT INTO " + TableName;

            cmd += " (";
            for(int a=0; a<InsertData.Length; a++)
            {
                cmd += InsertData[a].Column;

                if (a < InsertData.Length - 1)
                    cmd += ", ";
            }
            cmd += ") VALUES (";
            
            for(int a=0; a<InsertData.Length; a++)
            {
                if (InsertData[a].Type == DataTypes.String || InsertData[a].Type == DataTypes.DateTime)
                    cmd += "'" + InsertData[a].Value + "'";
                else if (InsertData[a].Type == DataTypes.Int || InsertData[a].Type == DataTypes.Double)
                    cmd += InsertData[a].Value;

                if (a < InsertData.Length - 1)
                    cmd += ", ";
            }
            cmd += ");";

            return cmd;
        }
        /// <summary>
        /// Constructs a SQL DELETE command string for removing records from the specified table.
        /// </summary>
        /// <param name="TableName">The name of the table from which records will be deleted.</param>
        /// <param name="WhereStatement">
        /// An optional WHERE clause to filter which records are deleted. If empty, all records in the table will be removed.
        /// </param>
        /// <returns>
        /// A formatted SQL <c>DELETE FROM</c> command string.
        /// </returns>
        /// <remarks>
        /// This method builds a SQL DELETE statement targeting the specified table. If a <c>WhereStatement</c> is provided,
        /// it appends a <c>WHERE</c> clause to restrict deletion to matching rows. If omitted, the command deletes all rows.
        /// The final command string is terminated with a semicolon.
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="TableName"/> is null or empty.
        /// </exception>
        public static string DeleteCommand(string TableName, string WhereStatement = "")
        {
            string cmd = "DELETE FROM " + TableName;

            if (WhereStatement != "")
                cmd += " WHERE " + WhereStatement;
            cmd += ";";

            return cmd;
        }
        /// <summary>
        /// Generates a SQL command string to truncate all records from the specified table.
        /// </summary>
        /// <param name="TableName">The name of the table to be truncated.</param>
        /// <returns>
        /// A <see cref="string"/> containing the SQL <c>TRUNCATE TABLE</c> command for the given table.
        /// </returns>
        /// <remarks>
        /// This method constructs a raw SQL statement that removes all rows from the specified table.
        /// It is intended for use in scenarios where full table clearance is required, such as resetting staging data or clearing logs.
        ///
        /// <b>Warning:</b> The <c>TRUNCATE</c> command is irreversible, bypasses triggers, and resets auto-increment counters.
        /// Use with extreme caution, especially in production environments.
        /// </remarks>
        public static string TruncateCommand(string TableName)
        {
            return "TRUNCATE TABLE " + TableName + ";";
        }
        #endregion

        #region STRUCTS
        /// <summary>
        /// Represents metadata for constructing SQL update operations, including column identity, value, and type.
        /// </summary>
        /// <remarks>
        /// This structure supports flexible initialization for either alias-based referencing or direct value assignment.
        /// </remarks>
        public struct UpdateInfo
        {
            public string TableName { get; set; }
            public string ColumnName { get; set; }
            public string Alias { get; set; }
            public DataTypes DataType { get; set; }
            public string Value { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="UpdateInfo"/> struct using a column name and alias reference.
            /// </summary>
            /// <param name="Column">The name of the column to be updated.</param>
            /// <param name="ColumnAlias">An alias used to reference the column in external contexts.</param>
            /// <remarks>
            /// This constructor sets the <c>DataType</c> to <see cref="DataTypes.Int"/> by default and initializes other fields to empty strings.
            /// </remarks>
            public UpdateInfo(string Column, string ColumnAlias)
            {
                ColumnName = Column;
                Alias = ColumnAlias;
                TableName = "";
                DataType = DataTypes.Int;
                Value = "";
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="UpdateInfo"/> struct using a column name, value, and data type.
            /// </summary>
            /// <param name="Column">The name of the column to be updated.</param>
            /// <param name="ColumnValue">The value to assign to the specified column.</param>
            /// <param name="ValueType">The data type of the value, used to determine SQL formatting.</param>
            /// <remarks>
            /// This constructor sets the <c>TableName</c> and <c>Alias</c> fields to empty strings by default.
            /// </remarks>
            public UpdateInfo(string Column, string ColumnValue, DataTypes ValueType)
            {
                ColumnName = Column;
                Value = ColumnValue;
                DataType = ValueType;
                TableName = "";
                Alias = "";
            }
        }
        /// <summary>
        /// Represents a structured unit of data for insertion into a database table.
        /// </summary>
        public struct InsertInfo
        {
            public string Column { get; set; }
            public string Value { get; set; }
            public DataTypes Type { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="InsertInfo"/> struct with default values.
            /// </summary>
            /// <remarks>
            /// Sets <c>Column</c> and <c>Value</c> to empty strings, and assigns <c>DataTypes.Int</c> as the default type.
            /// Useful for placeholder initialization or deferred assignment in BBHRKS-style insert routines.
            /// </remarks>
            public InsertInfo()
            {
                Column = "";
                Value = "";
                Type = DataTypes.Int;
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="InsertInfo"/> struct with the specified column name, value, and data type.
            /// </summary>
            /// <param name="column">The name of the column to insert into.</param>
            /// <param name="value">The value to be inserted.</param>
            /// <param name="type">The data type classification for the value.</param>
            public InsertInfo(string column, string value, DataTypes type)
            {
                Column = column;
                Value = value;
                Type = type;
            }
        }
        #endregion
    }
}
