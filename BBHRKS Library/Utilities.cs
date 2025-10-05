using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JunX.NET8.MySQL;

namespace BBHRKS.Utilities
{
    public static class Utilities
    {
        #region PRIVATE VARIABLES
        private static TenantsMenu TMAction;
        #endregion

        #region PUBLIC CONSTANTS
        public const string DefaultDateFallback = "2000-01-01";
        #endregion

        #region ENUMS
        /// <summary>
        /// Defines the set of actions available in the tenant menu interface.
        /// </summary>
        public enum TenantsMenuAction
        {
            None,
            NewTenant,
            UpdateTenant
        }
        public enum BillPreviewMode
        {
            Preview,
            ExportToPDF
        }
        #endregion

        #region STRUCTS
        /// <summary>
        /// Represents a structured menu context for tenant-related operations, including the intended action and associated tenant name.
        /// </summary>
        public struct TenantsMenu
        {
            public TenantsMenuAction Action { get; set; }
            public string TenantName { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="TenantsMenu"/> class with the specified action and tenant name.
            /// </summary>
            /// <param name="action">
            /// The action to be performed by the menu, represented by a <see cref="TenantsMenuAction"/> enumeration.
            /// Defaults to <c>TenantsMenuAction.None</c> if not specified.
            /// </param>
            /// <param name="tenantName">
            /// An optional tenant name associated with the menu context. Defaults to an empty string if not specified.
            /// </param>
            /// <remarks>
            /// This constructor sets the <c>Action</c> and <c>TenantName</c> properties based on the provided parameters.
            /// It is typically used to initialize menu behavior for tenant-related operations in BBHRKS modules.
            /// </remarks>
            public TenantsMenu(TenantsMenuAction action = TenantsMenuAction.None, string tenantName = "")
            {
                Action = action;
                TenantName = tenantName;
            }
        }
        #endregion

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets the current tenant menu context, including the selected action and associated tenant name.
        /// </summary>
        /// <value>
        /// A <see cref="TenantsMenu"/> structure representing the active state of tenant-related operations.
        /// </value>
        /// <remarks>
        /// This static property provides controlled access to an internal store that maintains the current tenant menu state.
        /// It is commonly used across BBHRKS modules to coordinate form behavior, menu routing, and tenant-specific workflows.
        /// </remarks>
        public static TenantsMenu TMenuAction
        {
            get { return TMAction; }
            set { TMAction = value; }
        }
        public static string BillPreview_SearchBillNumber { get; set; }
        public static BillPreviewMode SetBillPreviewMode { get; set; }
        #endregion

        #region PUBLIC FUNCTIONS
        /// <summary>
        /// Replaces an empty string with a default placeholder value.
        /// </summary>
        /// <param name="field">The input string to evaluate.</param>
        /// <returns>
        /// <c>"N/A"</c> if the input is empty; otherwise, returns the original string.
        /// </returns>
        /// <remarks>
        /// Commonly used in BBHRKS modules to ensure display consistency when optional fields are left blank.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="field"/> is <c>null</c>.
        /// </exception>
        public static string FillEmptyField(string field)
        {
            if (field == "")
                return "N/A";
            else
                return field;
        }
        /// <summary>
        /// Generates a unique invoice number for a tenant using their ID and the current timestamp.
        /// </summary>
        /// <param name="TenantID">The numeric identifier of the tenant.</param>
        /// <returns>
        /// A formatted invoice number string in the pattern <c>BBH-B####yyyyMMddHHmmss</c>, where:
        /// <list type="bullet">
        /// <item><description><c>####</c> is the zero-padded tenant ID (e.g., 0007)</description></item>
        /// <item><description><c>yyyyMMddHHmmss</c> is the current date and time in 24-hour format</description></item>
        /// </list>
        /// </returns>
        /// <remarks>
        /// This method ensures invoice uniqueness by combining tenant identity with a precise timestamp.
        /// Useful for logging, billing, and audit tracking within BBH workflows.
        /// </remarks>
        public static string GenerateInvoiceNumber(int TenantID)
        {
            return "BBH-B" + TenantID.ToString("0000") + DateTime.Now.ToString("yyyyMMddHHmmss");
        }
        /// <summary>
        /// Generates a full file path for saving a tenant-specific billing invoice as a PDF.
        /// Ensures the target directory exists by creating it if necessary.
        /// </summary>
        /// <param name="TenantName">
        /// The name of the tenant, used to create a subfolder and personalize the filename.
        /// </param>
        /// <param name="DueDate">
        /// The billing due date, formatted as "MMMM_yyyy" and embedded in the filename.
        /// </param>
        /// <returns>
        /// A <c>string</c> representing the full file path for the PDF invoice, including folder and filename.
        /// </returns>
        /// <exception cref="IOException">
        /// Thrown if the directory cannot be created due to an I/O error.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">
        /// Thrown if the application lacks permission to create the directory or write to the path.
        /// </exception>
        public static string GeneratePDFOutputPath(string TenantName, DateTime DueDate)
        {
            DBConnect DBC = new DBConnect(MySQL.Database.Connection);
            string output = "";
            string fileName = $"Invoice_[" + TenantName.ToUpper() + "_" + DueDate.ToString("MMMM_yyyy") + "].pdf";

            DBC.CommandString = Construct.SelectCommand(
                Select: tbmetadata.Value.ToString(),
                From: tbmetadata.tbmetadata.ToString(),
                Where: tbmetadata.MID.ToString() + "=9");
            DBC.ExecuteReader();
            DBC.GetValues();
            output = @"" + DBC.Values[0] + "\\" + TenantName;

            if (!Directory.Exists(output))
                Directory.CreateDirectory(output);

            return Path.Combine(output, fileName);
        }
        #endregion
    }
}
