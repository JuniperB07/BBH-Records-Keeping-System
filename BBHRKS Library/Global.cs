using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JunX.NET8.MySQL;

namespace BBHRKS.Global
{
    /// <summary>
    /// Provides data and functionalities across BBH Records Keeping System Forms.
    /// </summary>
    public static class Global
    {
        internal static DBConnect DBC;
        

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Retrieves a sorted list of tenant names from the database in ascending order.
        /// </summary>
        /// <returns>
        /// A <c>List&lt;string&gt;</c> containing tenant names.
        /// </returns>
        public static List<string> TenantsList
        {
            get
            {
                DBC.CommandString = new SQLBuilder.SQLSelect()
                    .Column(tbtenants.FullName.ToString())
                    .From(tbtenants.tbtenants.ToString())
                    .OrderBy(tbtenants.FullName.ToString(), MySQLOrderBy.ASC).ToString();

                DBC.ExecuteReader();
                DBC.GetValues();
                return DBC.Values;
            }
        }
        #endregion

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Establishes the execution context required for database operations.
        /// </summary>
        /// <param name="mySQLExecute">
        /// The external execution handler used for command execution.
        /// </param>
        public static void Initialize(DBConnect dbConnect)
        {
            DBC = dbConnect;
        }
        /// <summary>
        /// Filters and sorts tenant names that contain the specified search value.
        /// </summary>
        /// <param name="Value">
        /// The substring used to match tenant names.
        /// </param>
        /// <returns>
        /// A <c>List&lt;string&gt;</c> containing matched tenant names in ascending order.
        /// </returns>
        public static List<string> SearchTenantsList(string Value)
        {
            DBC.CommandString = new SQLBuilder.SQLSelect()
                .Column(tbtenants.FullName.ToString())
                .From(tbtenants.tbtenants.ToString())
                .Where(tbtenants.FullName.ToString() + " LIKE @SearchValue")
                .OrderBy(tbtenants.FullName.ToString(), MySQLOrderBy.ASC).ToString();
            DBC.ExecuteReader(new ParametersMetadata("@SearchValue", "%" + Value + "%"));
            DBC.GetValues();
            return DBC.Values;
        }
        /// <summary>
        /// Retrieves the unique tenant ID based on the provided full name.
        /// </summary>
        /// <remarks>
        /// Executes a parameterized SELECT query on the <c>tbtenants</c> table using the <c>@FullName</c> parameter.
        /// If a matching record is found, the corresponding <c>TenantID</c> is returned; otherwise, returns <c>-1</c>.
        /// </remarks>
        /// <param name="TenantName">The full name of the tenant to search for.</param>
        /// <returns>
        /// The <c>TenantID</c> as an integer if found; otherwise <c>-1</c>.
        /// </returns>
        public static int GetTenantID(string TenantName)
        {
            DBC.CommandString = Construct.SelectCommand(
                Select: tbtenants.TenantID.ToString(),
                From: tbtenants.tbtenants.ToString(),
                Where: tbtenants.FullName.ToString() + "=@FullName");
            DBC.ExecuteReader(new ParametersMetadata("@FullName", TenantName));
            if (DBC.HasRows)
            {
                DBC.GetValues();
                return Convert.ToInt32(DBC.Values[0]);
            }
            DBC.CloseReader();
            return -1;
        }
        #endregion
    }
}
