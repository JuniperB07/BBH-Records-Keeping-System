# BBH Records Keeping System
<img src="BBH Records Keeping System/bbhLogo.png" align="right" width="150px" height="150px" /> 
<p>This Records Keeping System is created for Bolabon Boarding House (BBH). It allows automated bill creation, transaction processing &amp; tracking, and tenant management.</p>
<p><strong>TARGET FRAMEWORK:</strong> .net8.0-windows</p>
<p><strong>FOR PDF EXPORT:</strong> Exported PDF files are saved to (C:\Users\USER\Documents\BOLABON BOARDING HOUSE)</p>
<br/>
<strong>BUILT-IN FORMS </strong>
<ul>
  <li><strong>Login.cs</strong> - BBH Records Keeping System login form.</li>
  <li><strong>Dashboard.cs</strong> - BBH RKS's dashboard UI and code. Contains menu buttons to redirect to <b>Billing</b>, <b>Payments</b>, <b>Tenants</b>, and <b>Settings</b> Menu. Also contains Tenant 
    Quick View Panel and tables to display Unpaid and Overdue bills.</li>
  <li><strong>Additionals_NEW.cs</strong> - Subform to create Additional Charge to a particular tenant to be charged on the same tenant's next bill.</li>
  <li><strong>Additionals_VIEW.cs</strong> - Subform that shows the details of a selected Additional Charge.</li>
  <li><strong>Billing_MENU.cs</strong> - Subform that shows the Billing Menu.</li>
  <li><strong>Billing_NEW.cs</strong> - Subform that allows creation of new bills.</li>
  <li><strong>BillingPreview_SEARCH.cs</strong> - An intermediary subform that allows bill selection for bill preview or exportation to PDF.</li>
  <li><strong>BillPreview_EXPORT.cs</strong> - Subform that exports the selected bill into a PDF file.</li>
  <li><strong>BillPreview_PREVIEW.cs</strong> - Subform that displays the Print Preview of the selected bill.</li>
  <li><strong>MSG_Processing.cs</strong> - An intermediary subform that appears during bill/receipt preview generation for viewing and exportation.</li>
  <li><strong>Payments_ADVANCES.cs</strong> - Subform that allows Advance Payments for future bill/s to be made.</li>
  <li><strong>Payments_ALL_ORs.cs</strong> - An intermediary subform that allows OR selection for print preview or printing.</li>
  <li><strong>Payments_BILL.cs</strong> - Subform that allows payment of bills.</li>
  <li><strong>Payments_MENU.cs</strong> - Subform that shows the Payments Menu.</li>
  <li><strong>Payments_PREVIEW.cs</strong> - Subform that displays the Print Preview of the selected OR.</li>
  <li><strong>Tenants_MENU.cs</strong> - Subform that shows the Tenants Menu.</li>
  <li><strong>Tenants_NEW.cs</strong> - Subform that allows adding new tenant information.</li>
  <li><strong>Tenants_UPDATE.cs</strong> - Subform that allows editing of an existing tenant's tenant information.</li>
  <li><strong>User_MANAGEMENT.cs</strong> - Subform that allows creation, editing, enabling, disabling, and setting the access level of users to access the entire system. Credentials, particularly the
    password, are encrypted before storing to database. The encryption and decryption process is accomplished with the use of JunX.NET8.EncryptionService. For more information about JunX.NET8 Library:
    </li>
    <ul>
      <li><a href="https://github.com/JuniperB07/JunX.NET">JunX.NET8 GitHub Repository</a></li>
      <li><a href="https://www.nuget.org/packages/JunX.NET8">JunX.NET8 NuGet Package</li>
    </ul>
  <li><strong>Settings_MENU.cs</strong> - An intermediary subform that displays the Settings Menu.</li>
  <li></li>
</ul>
<strong>CLASSES</strong>
<ul>
  <li><strong>AdditionalsHelper.cs</strong> - Contains properties to be passed to other subforms under the <b>Additionals</b> category.</li>
  <li><strong>BillPreviewHelper.cs</strong> - Contains properties to be used by or passed to other subforms under the <b>Billing</b> category</li>
  <li><strong>DashboardHelper.cs</strong> - Used for passing data to or from <b>Dashbaord.cs</b>.</li>
  <li><strong>ExportToPDF.cs</strong> - Used for passing data to <b>BillPreview_EXPORT.cs</b>.</li>
  <li><strong>LoginHelper.cs</strong> - Used for passing data to or from <b>Login.cs</b>.</li>
  <li><strong>Program.cs</strong> - Contains the MAIN method. This class is the applications entry point. Edit with caution.</li>
  <li><strong>ReceiptPreviewHelper.cs</strong> - Used for passing data to or from <b>Payments_PREVIEW.cs</b>.</li>
  <li><strong>UserManagementHelper.cs</strong> - Used for passing data to or from <b>User_MANAGEMENT.cs</b>.</li>
</ul>
<strong>RDLCs</strong>
<ul>
  <li>BillPreview.rdlc</li>
  <li>ReceiptPreview.rdlc</li>
</ul>
<strong>PROJECT REFERENCES</strong>
<ul>
  <li><a href="https://github.com/JuniperB07/BBH-Records-Keeping-System/tree/f6f30b508ce5c1e29a0336a097f4186ffd35de1b/BBHRKS%20Library">BBHRKS Library 
  (.csproj file)</a>
  </li>
  <li><a href="https://github.com/JuniperB07/JunX.NET">JunX.NET8 (.csproj file)</a></li>
</ul>
<strong>DEPENDENCIES</strong>
<ul>
  <li><a href="https://www.nuget.org/packages/MySql.Data/9.4.0?_src=template">MySql.Data v9.4.0 NuGet Package</a></li>
  <li><a href="https://www.nuget.org/packages/ReportViewerCore.WinForms/15.1.26?_src=template">ReportViewerCore.WinForms v15.1.26 NuGet Package</li>
</ul>
<strong>VS EXTENSION REQUIREMENTS</strong>
<ul>
  <li><a href="https://marketplace.visualstudio.com/items?itemName=ProBITools.MicrosoftRdlcReportDesignerforVisualStudio2022">
    Microsoft RDLC Report Designer </a>
  </li>
</ul>
<strong>DATABASE MANAGEMENT SOFTWARE</strong>
<ul>
  <li><a href="https://www.wampserver.com/en/download-wampserver-64bits">WampServer 3.3.7 64bits</a></li>
</ul>
<strong>NOTES</strong>
<ul>
  <li>This Solution generates C# enum files when the application starts. These files are stored in <b><i>\bin\Debug\net8.0-windows\TableEnums</i></b> and <b><i>\bin\Debug\net8.0-windows7.0\TableEnums</i>
  </b>. You may need to recreate these paths and folders in order to for the solution and program to function properly.</li>
  <li>Connection to WampServer MySQL Database uses the default <i>'root'</i> credentials with no passwords. If you want to change this, edit the connection string found in the method: 
    <b><i>BBHRKS.MySQL.Database.Initialize().</i></b></li>
</ul>

# BBHRKS Library
<p>This Library is custom made specifically for BBH Records Keeping System. This solution needs to be project referenced in the BBH Records Keeping System Solution.</p>
<p>The following are the namespaces in this Library.</p>
<br/>
<strong>BBHRKS.Global</strong>
<ul>
  <li><strong>BBHRKS.Global.Global</strong> - Provides data and functionalities across the BBH Records Keeping System Forms and Subforms.</li>
</ul>
<strong>BBHRKS.Interface</strong>
<ul>
  <li><strong>BBHRKS.Interface.Interface</strong> - Provides methods for manipulating the BBH Records Keeping System Form Controls.</li>
</ul>
<strong>BBHRKS.Metadata</strong>
<ul>
  <li><strong>BBHRKS.Metadata.Metadata</strong> - Provides crucial metadata necessary for the proper functionality of the BBH Records Keeping System Form Controls.</li>
</ul>
<strong>BBHRKS.MySQL</strong>
<ul>
  <li><strong>BBHRKS.MySQL.Database</strong> - Allows the entirety of BBH Records Keeping System access to its database.</li>
  <li><strong>BBHRKS.MySQL.Generate</strong> - Provides methods for generating MySQL command strings. Gradualy being replaced by JunX.NET8.MySQL.Construct.</li>
</ul>
<strong>BBHRKS.Payments</strong>
<ul>
  <li><strong>BBHRKS.Payments.Payments</strong> - Provides functionalities and data for BBH Records Keeping System - Payments</li>
</ul>
<strong>BBHRKS.Reports</strong>
<ul>
  <li><strong>BBHRKS.Reports.InvoicePage1</strong> - Provides ReportViewer Paramater Values for BBH RKS Invoice Page 1.</li>
  <li><strong>BBHRKS.Reports.InvoicePage2</strong>- Provides ReportViewer Parameter Values for BBH RKS Invoice Page 2.</li>
  <li><strong>BBHRKS.Reports.InvoicePage3</strong> - Provides ReportViewer Parameter Values for BBH RKS Invoice Page 3.</li>
  <li><strong>BBHRKS.Reports.InvoicePage4</strong> - Provides ReportViewer Parameter Values for BBH RKS Invoice Page 4.</li>
  <li><strong>BBHRKS.Reports.PaymentsPage1</strong> - Provides ReportViewer Parameter Values for BBH RKS Official Receipt Page 1.</li>
</ul>
<strong>BBHRKS.UserManagement</strong>
<ul>
  <li><strong>BBHRKS.UserManagement.UserManagement</strong> - Provides data and functionalities to BBH RKS User Management Form.</li>
</ul>
<strong>BBHRKS.Utilities</strong>
<ul>
  <li><strong>BBHRKS.Utilities.Utilities</strong> - Provides data and functionalities to various BBH RKS Forms.</li>
</ul>
<strong>PROJECT REFERENCES</strong>
<ul>
  <li><a href="https://github.com/JuniperB07/JunX.NET">JunX.NET8 (.csproj file)</a></li>
</ul>
<strong>DEPENDENCIES</strong>
<ul>
  <li><a href="https://www.nuget.org/packages/MySql.Data/9.4.0?_src=template">MySql.Data v9.4.0 NuGet Package</a></li>
</ul>
<strong>NOTES</strong>
<ul>
  <li>This Library uses the same C# Enum files and is added as links.</li>
</ul>

# Database (dbBBHRKS)
<p>This SQL Database contains tables that are necessary for data storage. This is necessary for proper functionality of BBH Records Keeping System.</p>
<br/>
<strong>LIST OF TABLES</strong>
<ul>
  <li>tbadditionals</li>
  <li>tbbillpreview_receipts</li>
  <li>tbbills</li>
  <li>tbdashboard_overdues</li>
  <li>tbdashboard_unpaidbills</li>
  <li>tbdeductions</li>
  <li>tbelectricitybill</li>
  <li>tbemergency</li>
  <li>tbinternetbill</li>
  <li>tbinternetplans</li>
  <li>tbmetadata</li>
  <li>tbpaymentmethod</li>
  <li>tbpaymentpreview_receipts</li>
  <li>tbpayments</li>
  <li>tbrentalbill</li>
  <li>tbrooms</li>
  <li>tbtenants</li>
  <li>tbusers</li>
  <li>tbwaterbill</li>
</ul>
