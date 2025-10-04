# BBH-Records-Keeping-System
<img src="BBH Records Keeping System/bbhLogo.png" align="right" width="150px" height="150px" /> 
<p>This Records Keeping System is created for Bolabon Boarding House (BBH). It allows automated bill creation, transaction processing &amp; tracking, and tenant management.</p>
<p>This system create bills for Water, Electricity, Internet, and Rental Bills.</p>
<p><strong>TARGET FRAMEWORK:</strong> .net8.0-windows</p>
<p><strong>FOR PDF EXPORT:</strong> Exported PDF files are saved to (C:\Users\USER\Documents\BOLABON BOARDING HOUSE)</p>

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

# BBHRKS Library
A C#.NET Library used to provide functionalities to BBH Records Keeping System.
