namespace BBH_Records_Keeping_System
{
    partial class Billing_New
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Billing_New));
            grpSelectTenant = new GroupBox();
            lstTenants = new ListBox();
            txtSearch = new TextBox();
            grpButtons = new GroupBox();
            btnExportToPDF = new Button();
            btnBillPreview = new Button();
            btnSave = new Button();
            btnReset = new Button();
            tbcBillSummary = new TabControl();
            tbpWaterBill = new TabPage();
            lblWater_Subtotal = new Label();
            label18 = new Label();
            lblWater_Deductions = new Label();
            label16 = new Label();
            lblWater_Balance = new Label();
            label14 = new Label();
            lblWater_CurrentCharge = new Label();
            label12 = new Label();
            lblWater_Consumption = new Label();
            label10 = new Label();
            lblWater_Present = new Label();
            label8 = new Label();
            lblWater_Previous = new Label();
            label6 = new Label();
            tbpElectricityBill = new TabPage();
            lblElectricity_Subtotal = new Label();
            label7 = new Label();
            lblElectricity_Deductions = new Label();
            label22 = new Label();
            lblElectricity_Balance = new Label();
            label24 = new Label();
            lblElectricity_CurrentCharge = new Label();
            label26 = new Label();
            lblElectricity_Consumption = new Label();
            label28 = new Label();
            lblElectricity_Present = new Label();
            label30 = new Label();
            lblElectricity_Previous = new Label();
            label32 = new Label();
            tbpRentalBill = new TabPage();
            lblRental_Subtotal = new Label();
            label11 = new Label();
            lblRental_Deductions = new Label();
            label36 = new Label();
            lblRental_Balance = new Label();
            label38 = new Label();
            lblRental_CurrentCharge = new Label();
            label40 = new Label();
            lblRental_Additionals = new Label();
            label44 = new Label();
            lblRental_MonthlyDue = new Label();
            label46 = new Label();
            tbpInternetBill = new TabPage();
            lblInternet_DueDate = new Label();
            label21 = new Label();
            lblInternet_Subtotal = new Label();
            label15 = new Label();
            lblInternet_Deductions = new Label();
            label48 = new Label();
            lblInternet_Balance = new Label();
            label50 = new Label();
            lblInternet_CurrentCharge = new Label();
            label52 = new Label();
            lblInternet_SubscriptionFee = new Label();
            label54 = new Label();
            lblInternet_Plan = new Label();
            label56 = new Label();
            tbcReadings = new TabControl();
            tbpWaterReadings = new TabPage();
            btnWater_ConfirmReading = new Button();
            label2 = new Label();
            label1 = new Label();
            txtWater_PresentReading = new TextBox();
            txtWater_PreviousReading = new TextBox();
            tbpElectricityReadings = new TabPage();
            btnElectricity_ConfirmReading = new Button();
            label3 = new Label();
            label4 = new Label();
            txtElectricity_PresentReading = new TextBox();
            txtElectricity_PreviousReading = new TextBox();
            grpBillInformation = new GroupBox();
            lblBillTotal = new Label();
            label39 = new Label();
            lblInternetBillSubtotal = new Label();
            label35 = new Label();
            lblRentalBillSubtotal = new Label();
            label33 = new Label();
            lblElectricityBillSubtotal = new Label();
            label29 = new Label();
            lblWaterBillSubtotal = new Label();
            label25 = new Label();
            lblInvoiceDueDate = new Label();
            label20 = new Label();
            lblInvoiceDate = new Label();
            label13 = new Label();
            lblInvoiceNumber = new Label();
            label5 = new Label();
            grpSelectTenant.SuspendLayout();
            grpButtons.SuspendLayout();
            tbcBillSummary.SuspendLayout();
            tbpWaterBill.SuspendLayout();
            tbpElectricityBill.SuspendLayout();
            tbpRentalBill.SuspendLayout();
            tbpInternetBill.SuspendLayout();
            tbcReadings.SuspendLayout();
            tbpWaterReadings.SuspendLayout();
            tbpElectricityReadings.SuspendLayout();
            grpBillInformation.SuspendLayout();
            SuspendLayout();
            // 
            // grpSelectTenant
            // 
            grpSelectTenant.Controls.Add(lstTenants);
            grpSelectTenant.Controls.Add(txtSearch);
            grpSelectTenant.Location = new Point(12, 12);
            grpSelectTenant.Name = "grpSelectTenant";
            grpSelectTenant.Size = new Size(338, 498);
            grpSelectTenant.TabIndex = 0;
            grpSelectTenant.TabStop = false;
            grpSelectTenant.Text = "Select Tenant";
            // 
            // lstTenants
            // 
            lstTenants.BackColor = Color.Snow;
            lstTenants.FormattingEnabled = true;
            lstTenants.ItemHeight = 23;
            lstTenants.Location = new Point(6, 69);
            lstTenants.Name = "lstTenants";
            lstTenants.Size = new Size(326, 418);
            lstTenants.TabIndex = 2;
            lstTenants.MouseDoubleClick += lstTenants_MouseDoubleClick;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(6, 31);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(326, 32);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // grpButtons
            // 
            grpButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpButtons.Controls.Add(btnExportToPDF);
            grpButtons.Controls.Add(btnBillPreview);
            grpButtons.Controls.Add(btnSave);
            grpButtons.Controls.Add(btnReset);
            grpButtons.Location = new Point(12, 516);
            grpButtons.Name = "grpButtons";
            grpButtons.Size = new Size(1153, 108);
            grpButtons.TabIndex = 1;
            grpButtons.TabStop = false;
            grpButtons.Text = "Buttons";
            // 
            // btnExportToPDF
            // 
            btnExportToPDF.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btnExportToPDF.BackColor = Color.Red;
            btnExportToPDF.FlatAppearance.BorderSize = 0;
            btnExportToPDF.FlatStyle = FlatStyle.Flat;
            btnExportToPDF.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportToPDF.ForeColor = Color.Snow;
            btnExportToPDF.Location = new Point(566, 31);
            btnExportToPDF.Name = "btnExportToPDF";
            btnExportToPDF.Size = new Size(222, 71);
            btnExportToPDF.TabIndex = 11;
            btnExportToPDF.Text = "EXPORT INVOICE TO PDF";
            btnExportToPDF.UseVisualStyleBackColor = false;
            btnExportToPDF.Click += btnExportToPDF_Click;
            // 
            // btnBillPreview
            // 
            btnBillPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btnBillPreview.BackColor = Color.DarkBlue;
            btnBillPreview.FlatAppearance.BorderSize = 0;
            btnBillPreview.FlatStyle = FlatStyle.Flat;
            btnBillPreview.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBillPreview.ForeColor = Color.AliceBlue;
            btnBillPreview.Location = new Point(392, 31);
            btnBillPreview.Name = "btnBillPreview";
            btnBillPreview.Size = new Size(168, 71);
            btnBillPreview.TabIndex = 10;
            btnBillPreview.Text = "BILL PREVIEW";
            btnBillPreview.UseVisualStyleBackColor = false;
            btnBillPreview.Click += btnBillPreview_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.DarkGreen;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.Honeydew;
            btnSave.Location = new Point(978, 31);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(168, 71);
            btnSave.TabIndex = 9;
            btnSave.Text = "SAVE BILL";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnReset.BackColor = Color.DarkRed;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReset.ForeColor = Color.Snow;
            btnReset.Location = new Point(6, 31);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(168, 71);
            btnReset.TabIndex = 8;
            btnReset.Text = "RESET";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // tbcBillSummary
            // 
            tbcBillSummary.Anchor = AnchorStyles.Left;
            tbcBillSummary.Controls.Add(tbpWaterBill);
            tbcBillSummary.Controls.Add(tbpElectricityBill);
            tbcBillSummary.Controls.Add(tbpRentalBill);
            tbcBillSummary.Controls.Add(tbpInternetBill);
            tbcBillSummary.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbcBillSummary.Location = new Point(356, 224);
            tbcBillSummary.Name = "tbcBillSummary";
            tbcBillSummary.SelectedIndex = 0;
            tbcBillSummary.Size = new Size(408, 286);
            tbcBillSummary.TabIndex = 2;
            // 
            // tbpWaterBill
            // 
            tbpWaterBill.BackColor = Color.AliceBlue;
            tbpWaterBill.Controls.Add(lblWater_Subtotal);
            tbpWaterBill.Controls.Add(label18);
            tbpWaterBill.Controls.Add(lblWater_Deductions);
            tbpWaterBill.Controls.Add(label16);
            tbpWaterBill.Controls.Add(lblWater_Balance);
            tbpWaterBill.Controls.Add(label14);
            tbpWaterBill.Controls.Add(lblWater_CurrentCharge);
            tbpWaterBill.Controls.Add(label12);
            tbpWaterBill.Controls.Add(lblWater_Consumption);
            tbpWaterBill.Controls.Add(label10);
            tbpWaterBill.Controls.Add(lblWater_Present);
            tbpWaterBill.Controls.Add(label8);
            tbpWaterBill.Controls.Add(lblWater_Previous);
            tbpWaterBill.Controls.Add(label6);
            tbpWaterBill.Location = new Point(4, 32);
            tbpWaterBill.Name = "tbpWaterBill";
            tbpWaterBill.Padding = new Padding(3);
            tbpWaterBill.Size = new Size(400, 250);
            tbpWaterBill.TabIndex = 0;
            tbpWaterBill.Text = "Water";
            // 
            // lblWater_Subtotal
            // 
            lblWater_Subtotal.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
            lblWater_Subtotal.ForeColor = Color.FromArgb(0, 0, 64);
            lblWater_Subtotal.Location = new Point(227, 218);
            lblWater_Subtotal.Name = "lblWater_Subtotal";
            lblWater_Subtotal.Size = new Size(167, 25);
            lblWater_Subtotal.TabIndex = 17;
            lblWater_Subtotal.Text = "label17";
            lblWater_Subtotal.TextAlign = ContentAlignment.TopRight;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
            label18.ForeColor = Color.FromArgb(0, 0, 64);
            label18.Location = new Point(108, 215);
            label18.Name = "label18";
            label18.Size = new Size(112, 28);
            label18.TabIndex = 16;
            label18.Text = "Subtotal:";
            // 
            // lblWater_Deductions
            // 
            lblWater_Deductions.Font = new Font("Century Gothic", 12F, FontStyle.Italic);
            lblWater_Deductions.ForeColor = Color.FromArgb(0, 0, 64);
            lblWater_Deductions.Location = new Point(227, 168);
            lblWater_Deductions.Name = "lblWater_Deductions";
            lblWater_Deductions.Size = new Size(167, 25);
            lblWater_Deductions.TabIndex = 15;
            lblWater_Deductions.Text = "label15";
            lblWater_Deductions.TextAlign = ContentAlignment.TopRight;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Century Gothic", 12F, FontStyle.Italic);
            label16.ForeColor = Color.FromArgb(0, 0, 64);
            label16.Location = new Point(95, 168);
            label16.Name = "label16";
            label16.Size = new Size(126, 23);
            label16.TabIndex = 14;
            label16.Text = "Deductions:";
            // 
            // lblWater_Balance
            // 
            lblWater_Balance.ForeColor = Color.FromArgb(0, 0, 64);
            lblWater_Balance.Location = new Point(227, 138);
            lblWater_Balance.Name = "lblWater_Balance";
            lblWater_Balance.Size = new Size(167, 25);
            lblWater_Balance.TabIndex = 13;
            lblWater_Balance.Text = "label13";
            lblWater_Balance.TextAlign = ContentAlignment.TopRight;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.ForeColor = Color.FromArgb(0, 0, 64);
            label14.Location = new Point(17, 138);
            label14.Name = "label14";
            label14.Size = new Size(204, 23);
            label14.TabIndex = 12;
            label14.Text = "Remaining Balance:";
            // 
            // lblWater_CurrentCharge
            // 
            lblWater_CurrentCharge.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblWater_CurrentCharge.ForeColor = Color.FromArgb(0, 0, 64);
            lblWater_CurrentCharge.Location = new Point(227, 98);
            lblWater_CurrentCharge.Name = "lblWater_CurrentCharge";
            lblWater_CurrentCharge.Size = new Size(167, 25);
            lblWater_CurrentCharge.TabIndex = 11;
            lblWater_CurrentCharge.Text = "label11";
            lblWater_CurrentCharge.TextAlign = ContentAlignment.TopRight;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            label12.ForeColor = Color.FromArgb(0, 0, 64);
            label12.Location = new Point(54, 98);
            label12.Name = "label12";
            label12.Size = new Size(166, 23);
            label12.TabIndex = 10;
            label12.Text = "Current Charge:";
            // 
            // lblWater_Consumption
            // 
            lblWater_Consumption.ForeColor = Color.FromArgb(0, 0, 64);
            lblWater_Consumption.Location = new Point(227, 68);
            lblWater_Consumption.Name = "lblWater_Consumption";
            lblWater_Consumption.Size = new Size(167, 25);
            lblWater_Consumption.TabIndex = 9;
            lblWater_Consumption.Text = "label9";
            lblWater_Consumption.TextAlign = ContentAlignment.TopRight;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.FromArgb(0, 0, 64);
            label10.Location = new Point(77, 68);
            label10.Name = "label10";
            label10.Size = new Size(144, 23);
            label10.TabIndex = 8;
            label10.Text = "Consumption:";
            // 
            // lblWater_Present
            // 
            lblWater_Present.ForeColor = Color.FromArgb(0, 0, 64);
            lblWater_Present.Location = new Point(227, 38);
            lblWater_Present.Name = "lblWater_Present";
            lblWater_Present.Size = new Size(167, 25);
            lblWater_Present.TabIndex = 7;
            lblWater_Present.Text = "label7";
            lblWater_Present.TextAlign = ContentAlignment.TopRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.FromArgb(0, 0, 64);
            label8.Location = new Point(48, 38);
            label8.Name = "label8";
            label8.Size = new Size(173, 23);
            label8.TabIndex = 6;
            label8.Text = "Present Reading:";
            // 
            // lblWater_Previous
            // 
            lblWater_Previous.ForeColor = Color.FromArgb(0, 0, 64);
            lblWater_Previous.Location = new Point(227, 8);
            lblWater_Previous.Name = "lblWater_Previous";
            lblWater_Previous.Size = new Size(167, 25);
            lblWater_Previous.TabIndex = 5;
            lblWater_Previous.Text = "label5";
            lblWater_Previous.TextAlign = ContentAlignment.TopRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.FromArgb(0, 0, 64);
            label6.Location = new Point(39, 8);
            label6.Name = "label6";
            label6.Size = new Size(182, 23);
            label6.TabIndex = 4;
            label6.Text = "Previous Reading:";
            // 
            // tbpElectricityBill
            // 
            tbpElectricityBill.BackColor = Color.Ivory;
            tbpElectricityBill.Controls.Add(lblElectricity_Subtotal);
            tbpElectricityBill.Controls.Add(label7);
            tbpElectricityBill.Controls.Add(lblElectricity_Deductions);
            tbpElectricityBill.Controls.Add(label22);
            tbpElectricityBill.Controls.Add(lblElectricity_Balance);
            tbpElectricityBill.Controls.Add(label24);
            tbpElectricityBill.Controls.Add(lblElectricity_CurrentCharge);
            tbpElectricityBill.Controls.Add(label26);
            tbpElectricityBill.Controls.Add(lblElectricity_Consumption);
            tbpElectricityBill.Controls.Add(label28);
            tbpElectricityBill.Controls.Add(lblElectricity_Present);
            tbpElectricityBill.Controls.Add(label30);
            tbpElectricityBill.Controls.Add(lblElectricity_Previous);
            tbpElectricityBill.Controls.Add(label32);
            tbpElectricityBill.Location = new Point(4, 32);
            tbpElectricityBill.Name = "tbpElectricityBill";
            tbpElectricityBill.Padding = new Padding(3);
            tbpElectricityBill.Size = new Size(400, 250);
            tbpElectricityBill.TabIndex = 1;
            tbpElectricityBill.Text = "Electricity";
            // 
            // lblElectricity_Subtotal
            // 
            lblElectricity_Subtotal.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
            lblElectricity_Subtotal.ForeColor = Color.FromArgb(64, 64, 0);
            lblElectricity_Subtotal.Location = new Point(222, 218);
            lblElectricity_Subtotal.Name = "lblElectricity_Subtotal";
            lblElectricity_Subtotal.Size = new Size(167, 25);
            lblElectricity_Subtotal.TabIndex = 19;
            lblElectricity_Subtotal.Text = "label17";
            lblElectricity_Subtotal.TextAlign = ContentAlignment.TopRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(64, 64, 0);
            label7.Location = new Point(103, 215);
            label7.Name = "label7";
            label7.Size = new Size(112, 28);
            label7.TabIndex = 18;
            label7.Text = "Subtotal:";
            // 
            // lblElectricity_Deductions
            // 
            lblElectricity_Deductions.Font = new Font("Century Gothic", 12F, FontStyle.Italic);
            lblElectricity_Deductions.ForeColor = Color.FromArgb(64, 64, 0);
            lblElectricity_Deductions.Location = new Point(222, 166);
            lblElectricity_Deductions.Name = "lblElectricity_Deductions";
            lblElectricity_Deductions.Size = new Size(167, 25);
            lblElectricity_Deductions.TabIndex = 29;
            lblElectricity_Deductions.Text = "label21";
            lblElectricity_Deductions.TextAlign = ContentAlignment.TopRight;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Century Gothic", 12F, FontStyle.Italic);
            label22.ForeColor = Color.FromArgb(64, 64, 0);
            label22.Location = new Point(90, 166);
            label22.Name = "label22";
            label22.Size = new Size(126, 23);
            label22.TabIndex = 28;
            label22.Text = "Deductions:";
            // 
            // lblElectricity_Balance
            // 
            lblElectricity_Balance.ForeColor = Color.FromArgb(64, 64, 0);
            lblElectricity_Balance.Location = new Point(222, 136);
            lblElectricity_Balance.Name = "lblElectricity_Balance";
            lblElectricity_Balance.Size = new Size(167, 25);
            lblElectricity_Balance.TabIndex = 27;
            lblElectricity_Balance.Text = "label23";
            lblElectricity_Balance.TextAlign = ContentAlignment.TopRight;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.ForeColor = Color.FromArgb(64, 64, 0);
            label24.Location = new Point(12, 136);
            label24.Name = "label24";
            label24.Size = new Size(204, 23);
            label24.TabIndex = 26;
            label24.Text = "Remaining Balance:";
            // 
            // lblElectricity_CurrentCharge
            // 
            lblElectricity_CurrentCharge.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblElectricity_CurrentCharge.ForeColor = Color.FromArgb(64, 64, 0);
            lblElectricity_CurrentCharge.Location = new Point(222, 96);
            lblElectricity_CurrentCharge.Name = "lblElectricity_CurrentCharge";
            lblElectricity_CurrentCharge.Size = new Size(167, 25);
            lblElectricity_CurrentCharge.TabIndex = 25;
            lblElectricity_CurrentCharge.Text = "label25";
            lblElectricity_CurrentCharge.TextAlign = ContentAlignment.TopRight;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            label26.ForeColor = Color.FromArgb(64, 64, 0);
            label26.Location = new Point(49, 96);
            label26.Name = "label26";
            label26.Size = new Size(166, 23);
            label26.TabIndex = 24;
            label26.Text = "Current Charge:";
            // 
            // lblElectricity_Consumption
            // 
            lblElectricity_Consumption.ForeColor = Color.FromArgb(64, 64, 0);
            lblElectricity_Consumption.Location = new Point(222, 66);
            lblElectricity_Consumption.Name = "lblElectricity_Consumption";
            lblElectricity_Consumption.Size = new Size(167, 25);
            lblElectricity_Consumption.TabIndex = 23;
            lblElectricity_Consumption.Text = "label27";
            lblElectricity_Consumption.TextAlign = ContentAlignment.TopRight;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.ForeColor = Color.FromArgb(64, 64, 0);
            label28.Location = new Point(72, 66);
            label28.Name = "label28";
            label28.Size = new Size(144, 23);
            label28.TabIndex = 22;
            label28.Text = "Consumption:";
            // 
            // lblElectricity_Present
            // 
            lblElectricity_Present.ForeColor = Color.FromArgb(64, 64, 0);
            lblElectricity_Present.Location = new Point(222, 36);
            lblElectricity_Present.Name = "lblElectricity_Present";
            lblElectricity_Present.Size = new Size(167, 25);
            lblElectricity_Present.TabIndex = 21;
            lblElectricity_Present.Text = "label29";
            lblElectricity_Present.TextAlign = ContentAlignment.TopRight;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.ForeColor = Color.FromArgb(64, 64, 0);
            label30.Location = new Point(43, 36);
            label30.Name = "label30";
            label30.Size = new Size(173, 23);
            label30.TabIndex = 20;
            label30.Text = "Present Reading:";
            // 
            // lblElectricity_Previous
            // 
            lblElectricity_Previous.ForeColor = Color.FromArgb(64, 64, 0);
            lblElectricity_Previous.Location = new Point(222, 6);
            lblElectricity_Previous.Name = "lblElectricity_Previous";
            lblElectricity_Previous.Size = new Size(167, 25);
            lblElectricity_Previous.TabIndex = 19;
            lblElectricity_Previous.Text = "label31";
            lblElectricity_Previous.TextAlign = ContentAlignment.TopRight;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.ForeColor = Color.FromArgb(64, 64, 0);
            label32.Location = new Point(34, 6);
            label32.Name = "label32";
            label32.Size = new Size(182, 23);
            label32.TabIndex = 18;
            label32.Text = "Previous Reading:";
            // 
            // tbpRentalBill
            // 
            tbpRentalBill.BackColor = Color.LavenderBlush;
            tbpRentalBill.Controls.Add(lblRental_Subtotal);
            tbpRentalBill.Controls.Add(label11);
            tbpRentalBill.Controls.Add(lblRental_Deductions);
            tbpRentalBill.Controls.Add(label36);
            tbpRentalBill.Controls.Add(lblRental_Balance);
            tbpRentalBill.Controls.Add(label38);
            tbpRentalBill.Controls.Add(lblRental_CurrentCharge);
            tbpRentalBill.Controls.Add(label40);
            tbpRentalBill.Controls.Add(lblRental_Additionals);
            tbpRentalBill.Controls.Add(label44);
            tbpRentalBill.Controls.Add(lblRental_MonthlyDue);
            tbpRentalBill.Controls.Add(label46);
            tbpRentalBill.Location = new Point(4, 32);
            tbpRentalBill.Name = "tbpRentalBill";
            tbpRentalBill.Padding = new Padding(3);
            tbpRentalBill.Size = new Size(400, 250);
            tbpRentalBill.TabIndex = 2;
            tbpRentalBill.Text = "Rental";
            // 
            // lblRental_Subtotal
            // 
            lblRental_Subtotal.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
            lblRental_Subtotal.ForeColor = Color.FromArgb(64, 0, 64);
            lblRental_Subtotal.Location = new Point(222, 218);
            lblRental_Subtotal.Name = "lblRental_Subtotal";
            lblRental_Subtotal.Size = new Size(167, 25);
            lblRental_Subtotal.TabIndex = 19;
            lblRental_Subtotal.Text = "label17";
            lblRental_Subtotal.TextAlign = ContentAlignment.TopRight;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
            label11.ForeColor = Color.FromArgb(64, 0, 64);
            label11.Location = new Point(103, 215);
            label11.Name = "label11";
            label11.Size = new Size(112, 28);
            label11.TabIndex = 18;
            label11.Text = "Subtotal:";
            // 
            // lblRental_Deductions
            // 
            lblRental_Deductions.Font = new Font("Century Gothic", 12F, FontStyle.Italic);
            lblRental_Deductions.ForeColor = Color.FromArgb(64, 0, 64);
            lblRental_Deductions.Location = new Point(222, 157);
            lblRental_Deductions.Name = "lblRental_Deductions";
            lblRental_Deductions.Size = new Size(167, 25);
            lblRental_Deductions.TabIndex = 29;
            lblRental_Deductions.Text = "label35";
            lblRental_Deductions.TextAlign = ContentAlignment.TopRight;
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Font = new Font("Century Gothic", 12F, FontStyle.Italic);
            label36.ForeColor = Color.FromArgb(64, 0, 64);
            label36.Location = new Point(90, 157);
            label36.Name = "label36";
            label36.Size = new Size(126, 23);
            label36.TabIndex = 28;
            label36.Text = "Deductions:";
            // 
            // lblRental_Balance
            // 
            lblRental_Balance.ForeColor = Color.FromArgb(64, 0, 64);
            lblRental_Balance.Location = new Point(222, 127);
            lblRental_Balance.Name = "lblRental_Balance";
            lblRental_Balance.Size = new Size(167, 25);
            lblRental_Balance.TabIndex = 27;
            lblRental_Balance.Text = "label37";
            lblRental_Balance.TextAlign = ContentAlignment.TopRight;
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.ForeColor = Color.FromArgb(64, 0, 64);
            label38.Location = new Point(12, 127);
            label38.Name = "label38";
            label38.Size = new Size(204, 23);
            label38.TabIndex = 26;
            label38.Text = "Remaining Balance:";
            // 
            // lblRental_CurrentCharge
            // 
            lblRental_CurrentCharge.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblRental_CurrentCharge.ForeColor = Color.FromArgb(64, 0, 64);
            lblRental_CurrentCharge.Location = new Point(222, 66);
            lblRental_CurrentCharge.Name = "lblRental_CurrentCharge";
            lblRental_CurrentCharge.Size = new Size(167, 25);
            lblRental_CurrentCharge.TabIndex = 25;
            lblRental_CurrentCharge.Text = "label39";
            lblRental_CurrentCharge.TextAlign = ContentAlignment.TopRight;
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            label40.ForeColor = Color.FromArgb(64, 0, 64);
            label40.Location = new Point(49, 66);
            label40.Name = "label40";
            label40.Size = new Size(166, 23);
            label40.TabIndex = 24;
            label40.Text = "Current Charge:";
            // 
            // lblRental_Additionals
            // 
            lblRental_Additionals.ForeColor = Color.FromArgb(64, 0, 64);
            lblRental_Additionals.Location = new Point(222, 36);
            lblRental_Additionals.Name = "lblRental_Additionals";
            lblRental_Additionals.Size = new Size(167, 25);
            lblRental_Additionals.TabIndex = 21;
            lblRental_Additionals.Text = "label43";
            lblRental_Additionals.TextAlign = ContentAlignment.TopRight;
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.ForeColor = Color.FromArgb(64, 0, 64);
            label44.Location = new Point(13, 36);
            label44.Name = "label44";
            label44.Size = new Size(203, 23);
            label44.TabIndex = 20;
            label44.Text = "Additional Charges:";
            // 
            // lblRental_MonthlyDue
            // 
            lblRental_MonthlyDue.ForeColor = Color.FromArgb(64, 0, 64);
            lblRental_MonthlyDue.Location = new Point(222, 6);
            lblRental_MonthlyDue.Name = "lblRental_MonthlyDue";
            lblRental_MonthlyDue.Size = new Size(167, 25);
            lblRental_MonthlyDue.TabIndex = 19;
            lblRental_MonthlyDue.Text = "label45";
            lblRental_MonthlyDue.TextAlign = ContentAlignment.TopRight;
            // 
            // label46
            // 
            label46.AutoSize = true;
            label46.ForeColor = Color.FromArgb(64, 0, 64);
            label46.Location = new Point(78, 6);
            label46.Name = "label46";
            label46.Size = new Size(138, 23);
            label46.TabIndex = 18;
            label46.Text = "Monthly Due:";
            // 
            // tbpInternetBill
            // 
            tbpInternetBill.BackColor = Color.Azure;
            tbpInternetBill.Controls.Add(lblInternet_DueDate);
            tbpInternetBill.Controls.Add(label21);
            tbpInternetBill.Controls.Add(lblInternet_Subtotal);
            tbpInternetBill.Controls.Add(label15);
            tbpInternetBill.Controls.Add(lblInternet_Deductions);
            tbpInternetBill.Controls.Add(label48);
            tbpInternetBill.Controls.Add(lblInternet_Balance);
            tbpInternetBill.Controls.Add(label50);
            tbpInternetBill.Controls.Add(lblInternet_CurrentCharge);
            tbpInternetBill.Controls.Add(label52);
            tbpInternetBill.Controls.Add(lblInternet_SubscriptionFee);
            tbpInternetBill.Controls.Add(label54);
            tbpInternetBill.Controls.Add(lblInternet_Plan);
            tbpInternetBill.Controls.Add(label56);
            tbpInternetBill.Location = new Point(4, 32);
            tbpInternetBill.Name = "tbpInternetBill";
            tbpInternetBill.Padding = new Padding(3);
            tbpInternetBill.Size = new Size(400, 250);
            tbpInternetBill.TabIndex = 3;
            tbpInternetBill.Text = "Internet";
            // 
            // lblInternet_DueDate
            // 
            lblInternet_DueDate.ForeColor = Color.FromArgb(0, 64, 64);
            lblInternet_DueDate.Location = new Point(122, 3);
            lblInternet_DueDate.Name = "lblInternet_DueDate";
            lblInternet_DueDate.Size = new Size(267, 25);
            lblInternet_DueDate.TabIndex = 43;
            lblInternet_DueDate.Text = "label23";
            lblInternet_DueDate.TextAlign = ContentAlignment.TopRight;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.ForeColor = Color.FromArgb(0, 64, 64);
            label21.Location = new Point(6, 3);
            label21.Name = "label21";
            label21.Size = new Size(110, 23);
            label21.TabIndex = 42;
            label21.Text = "Due Date:";
            // 
            // lblInternet_Subtotal
            // 
            lblInternet_Subtotal.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
            lblInternet_Subtotal.ForeColor = Color.FromArgb(0, 64, 64);
            lblInternet_Subtotal.Location = new Point(222, 218);
            lblInternet_Subtotal.Name = "lblInternet_Subtotal";
            lblInternet_Subtotal.Size = new Size(167, 25);
            lblInternet_Subtotal.TabIndex = 19;
            lblInternet_Subtotal.Text = "label17";
            lblInternet_Subtotal.TextAlign = ContentAlignment.TopRight;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
            label15.ForeColor = Color.FromArgb(0, 64, 64);
            label15.Location = new Point(103, 215);
            label15.Name = "label15";
            label15.Size = new Size(112, 28);
            label15.TabIndex = 18;
            label15.Text = "Subtotal:";
            // 
            // lblInternet_Deductions
            // 
            lblInternet_Deductions.Font = new Font("Century Gothic", 12F, FontStyle.Italic);
            lblInternet_Deductions.ForeColor = Color.FromArgb(0, 64, 64);
            lblInternet_Deductions.Location = new Point(222, 177);
            lblInternet_Deductions.Name = "lblInternet_Deductions";
            lblInternet_Deductions.Size = new Size(167, 25);
            lblInternet_Deductions.TabIndex = 41;
            lblInternet_Deductions.Text = "label47";
            lblInternet_Deductions.TextAlign = ContentAlignment.TopRight;
            // 
            // label48
            // 
            label48.AutoSize = true;
            label48.Font = new Font("Century Gothic", 12F, FontStyle.Italic);
            label48.ForeColor = Color.FromArgb(0, 64, 64);
            label48.Location = new Point(90, 177);
            label48.Name = "label48";
            label48.Size = new Size(126, 23);
            label48.TabIndex = 40;
            label48.Text = "Deductions:";
            // 
            // lblInternet_Balance
            // 
            lblInternet_Balance.ForeColor = Color.FromArgb(0, 64, 64);
            lblInternet_Balance.Location = new Point(222, 147);
            lblInternet_Balance.Name = "lblInternet_Balance";
            lblInternet_Balance.Size = new Size(167, 25);
            lblInternet_Balance.TabIndex = 39;
            lblInternet_Balance.Text = "label49";
            lblInternet_Balance.TextAlign = ContentAlignment.TopRight;
            // 
            // label50
            // 
            label50.AutoSize = true;
            label50.ForeColor = Color.FromArgb(0, 64, 64);
            label50.Location = new Point(12, 147);
            label50.Name = "label50";
            label50.Size = new Size(204, 23);
            label50.TabIndex = 38;
            label50.Text = "Remaining Balance:";
            // 
            // lblInternet_CurrentCharge
            // 
            lblInternet_CurrentCharge.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblInternet_CurrentCharge.ForeColor = Color.FromArgb(0, 64, 64);
            lblInternet_CurrentCharge.Location = new Point(222, 106);
            lblInternet_CurrentCharge.Name = "lblInternet_CurrentCharge";
            lblInternet_CurrentCharge.Size = new Size(167, 25);
            lblInternet_CurrentCharge.TabIndex = 37;
            lblInternet_CurrentCharge.Text = "label51";
            lblInternet_CurrentCharge.TextAlign = ContentAlignment.TopRight;
            // 
            // label52
            // 
            label52.AutoSize = true;
            label52.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            label52.ForeColor = Color.FromArgb(0, 64, 64);
            label52.Location = new Point(49, 106);
            label52.Name = "label52";
            label52.Size = new Size(166, 23);
            label52.TabIndex = 36;
            label52.Text = "Current Charge:";
            // 
            // lblInternet_SubscriptionFee
            // 
            lblInternet_SubscriptionFee.ForeColor = Color.FromArgb(0, 64, 64);
            lblInternet_SubscriptionFee.Location = new Point(222, 76);
            lblInternet_SubscriptionFee.Name = "lblInternet_SubscriptionFee";
            lblInternet_SubscriptionFee.Size = new Size(167, 25);
            lblInternet_SubscriptionFee.TabIndex = 35;
            lblInternet_SubscriptionFee.Text = "label53";
            lblInternet_SubscriptionFee.TextAlign = ContentAlignment.TopRight;
            // 
            // label54
            // 
            label54.AutoSize = true;
            label54.ForeColor = Color.FromArgb(0, 64, 64);
            label54.Location = new Point(44, 76);
            label54.Name = "label54";
            label54.Size = new Size(172, 23);
            label54.TabIndex = 34;
            label54.Text = "Subscription Fee:";
            // 
            // lblInternet_Plan
            // 
            lblInternet_Plan.ForeColor = Color.FromArgb(0, 64, 64);
            lblInternet_Plan.Location = new Point(222, 46);
            lblInternet_Plan.Name = "lblInternet_Plan";
            lblInternet_Plan.Size = new Size(167, 25);
            lblInternet_Plan.TabIndex = 33;
            lblInternet_Plan.Text = "lblInternet_Plan";
            lblInternet_Plan.TextAlign = ContentAlignment.TopRight;
            // 
            // label56
            // 
            label56.AutoSize = true;
            label56.ForeColor = Color.FromArgb(0, 64, 64);
            label56.Location = new Point(75, 46);
            label56.Name = "label56";
            label56.Size = new Size(141, 23);
            label56.TabIndex = 32;
            label56.Text = "Availed Plan:";
            // 
            // tbcReadings
            // 
            tbcReadings.Controls.Add(tbpWaterReadings);
            tbcReadings.Controls.Add(tbpElectricityReadings);
            tbcReadings.Location = new Point(360, 12);
            tbcReadings.Name = "tbcReadings";
            tbcReadings.SelectedIndex = 0;
            tbcReadings.Size = new Size(404, 206);
            tbcReadings.TabIndex = 3;
            // 
            // tbpWaterReadings
            // 
            tbpWaterReadings.BackColor = Color.AliceBlue;
            tbpWaterReadings.Controls.Add(btnWater_ConfirmReading);
            tbpWaterReadings.Controls.Add(label2);
            tbpWaterReadings.Controls.Add(label1);
            tbpWaterReadings.Controls.Add(txtWater_PresentReading);
            tbpWaterReadings.Controls.Add(txtWater_PreviousReading);
            tbpWaterReadings.Location = new Point(4, 32);
            tbpWaterReadings.Name = "tbpWaterReadings";
            tbpWaterReadings.Padding = new Padding(3);
            tbpWaterReadings.Size = new Size(396, 170);
            tbpWaterReadings.TabIndex = 0;
            tbpWaterReadings.Text = "Water Readings";
            // 
            // btnWater_ConfirmReading
            // 
            btnWater_ConfirmReading.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnWater_ConfirmReading.BackColor = Color.RoyalBlue;
            btnWater_ConfirmReading.FlatAppearance.BorderSize = 0;
            btnWater_ConfirmReading.FlatStyle = FlatStyle.Flat;
            btnWater_ConfirmReading.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWater_ConfirmReading.ForeColor = Color.Honeydew;
            btnWater_ConfirmReading.Location = new Point(134, 119);
            btnWater_ConfirmReading.Name = "btnWater_ConfirmReading";
            btnWater_ConfirmReading.Size = new Size(256, 45);
            btnWater_ConfirmReading.TabIndex = 11;
            btnWater_ConfirmReading.Text = "CONFIRM READINGS";
            btnWater_ConfirmReading.UseVisualStyleBackColor = false;
            btnWater_ConfirmReading.Click += btnWater_ConfirmReading_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 52);
            label2.Name = "label2";
            label2.Size = new Size(173, 23);
            label2.TabIndex = 3;
            label2.Text = "Present Reading:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 9);
            label1.Name = "label1";
            label1.Size = new Size(182, 23);
            label1.TabIndex = 2;
            label1.Text = "Previous Reading:";
            // 
            // txtWater_PresentReading
            // 
            txtWater_PresentReading.Location = new Point(223, 49);
            txtWater_PresentReading.Name = "txtWater_PresentReading";
            txtWater_PresentReading.Size = new Size(167, 32);
            txtWater_PresentReading.TabIndex = 1;
            txtWater_PresentReading.TextAlign = HorizontalAlignment.Center;
            // 
            // txtWater_PreviousReading
            // 
            txtWater_PreviousReading.Location = new Point(223, 6);
            txtWater_PreviousReading.Name = "txtWater_PreviousReading";
            txtWater_PreviousReading.Size = new Size(167, 32);
            txtWater_PreviousReading.TabIndex = 0;
            txtWater_PreviousReading.TextAlign = HorizontalAlignment.Center;
            // 
            // tbpElectricityReadings
            // 
            tbpElectricityReadings.BackColor = Color.Ivory;
            tbpElectricityReadings.Controls.Add(btnElectricity_ConfirmReading);
            tbpElectricityReadings.Controls.Add(label3);
            tbpElectricityReadings.Controls.Add(label4);
            tbpElectricityReadings.Controls.Add(txtElectricity_PresentReading);
            tbpElectricityReadings.Controls.Add(txtElectricity_PreviousReading);
            tbpElectricityReadings.Location = new Point(4, 32);
            tbpElectricityReadings.Name = "tbpElectricityReadings";
            tbpElectricityReadings.Padding = new Padding(3);
            tbpElectricityReadings.Size = new Size(396, 170);
            tbpElectricityReadings.TabIndex = 1;
            tbpElectricityReadings.Text = "Electricity Readings";
            // 
            // btnElectricity_ConfirmReading
            // 
            btnElectricity_ConfirmReading.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnElectricity_ConfirmReading.BackColor = Color.Olive;
            btnElectricity_ConfirmReading.FlatAppearance.BorderSize = 0;
            btnElectricity_ConfirmReading.FlatStyle = FlatStyle.Flat;
            btnElectricity_ConfirmReading.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnElectricity_ConfirmReading.ForeColor = Color.Honeydew;
            btnElectricity_ConfirmReading.Location = new Point(134, 119);
            btnElectricity_ConfirmReading.Name = "btnElectricity_ConfirmReading";
            btnElectricity_ConfirmReading.Size = new Size(256, 45);
            btnElectricity_ConfirmReading.TabIndex = 16;
            btnElectricity_ConfirmReading.Text = "CONFIRM READINGS";
            btnElectricity_ConfirmReading.UseVisualStyleBackColor = false;
            btnElectricity_ConfirmReading.Click += btnElectricity_ConfirmReading_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 52);
            label3.Name = "label3";
            label3.Size = new Size(173, 23);
            label3.TabIndex = 15;
            label3.Text = "Present Reading:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 9);
            label4.Name = "label4";
            label4.Size = new Size(182, 23);
            label4.TabIndex = 14;
            label4.Text = "Previous Reading:";
            // 
            // txtElectricity_PresentReading
            // 
            txtElectricity_PresentReading.Location = new Point(223, 49);
            txtElectricity_PresentReading.Name = "txtElectricity_PresentReading";
            txtElectricity_PresentReading.Size = new Size(167, 32);
            txtElectricity_PresentReading.TabIndex = 13;
            txtElectricity_PresentReading.TextAlign = HorizontalAlignment.Center;
            // 
            // txtElectricity_PreviousReading
            // 
            txtElectricity_PreviousReading.Location = new Point(223, 6);
            txtElectricity_PreviousReading.Name = "txtElectricity_PreviousReading";
            txtElectricity_PreviousReading.Size = new Size(167, 32);
            txtElectricity_PreviousReading.TabIndex = 12;
            txtElectricity_PreviousReading.TextAlign = HorizontalAlignment.Center;
            // 
            // grpBillInformation
            // 
            grpBillInformation.Controls.Add(lblBillTotal);
            grpBillInformation.Controls.Add(label39);
            grpBillInformation.Controls.Add(lblInternetBillSubtotal);
            grpBillInformation.Controls.Add(label35);
            grpBillInformation.Controls.Add(lblRentalBillSubtotal);
            grpBillInformation.Controls.Add(label33);
            grpBillInformation.Controls.Add(lblElectricityBillSubtotal);
            grpBillInformation.Controls.Add(label29);
            grpBillInformation.Controls.Add(lblWaterBillSubtotal);
            grpBillInformation.Controls.Add(label25);
            grpBillInformation.Controls.Add(lblInvoiceDueDate);
            grpBillInformation.Controls.Add(label20);
            grpBillInformation.Controls.Add(lblInvoiceDate);
            grpBillInformation.Controls.Add(label13);
            grpBillInformation.Controls.Add(lblInvoiceNumber);
            grpBillInformation.Controls.Add(label5);
            grpBillInformation.Location = new Point(770, 12);
            grpBillInformation.Name = "grpBillInformation";
            grpBillInformation.Size = new Size(394, 498);
            grpBillInformation.TabIndex = 4;
            grpBillInformation.TabStop = false;
            grpBillInformation.Text = "Bill Information && Summary";
            // 
            // lblBillTotal
            // 
            lblBillTotal.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            lblBillTotal.Location = new Point(211, 445);
            lblBillTotal.Name = "lblBillTotal";
            lblBillTotal.Size = new Size(177, 45);
            lblBillTotal.TabIndex = 15;
            lblBillTotal.Text = "0,000.00";
            lblBillTotal.TextAlign = ContentAlignment.TopRight;
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            label39.Location = new Point(66, 445);
            label39.Name = "label39";
            label39.Size = new Size(139, 37);
            label39.TabIndex = 14;
            label39.Text = "Bill Total:";
            // 
            // lblInternetBillSubtotal
            // 
            lblInternetBillSubtotal.Location = new Point(272, 359);
            lblInternetBillSubtotal.Name = "lblInternetBillSubtotal";
            lblInternetBillSubtotal.Size = new Size(116, 25);
            lblInternetBillSubtotal.TabIndex = 13;
            lblInternetBillSubtotal.Text = "0,000.00";
            lblInternetBillSubtotal.TextAlign = ContentAlignment.TopRight;
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new Point(58, 359);
            label35.Name = "label35";
            label35.Size = new Size(208, 23);
            label35.TabIndex = 12;
            label35.Text = "Internet Bill Subtotal:";
            // 
            // lblRentalBillSubtotal
            // 
            lblRentalBillSubtotal.Location = new Point(272, 324);
            lblRentalBillSubtotal.Name = "lblRentalBillSubtotal";
            lblRentalBillSubtotal.Size = new Size(116, 25);
            lblRentalBillSubtotal.TabIndex = 11;
            lblRentalBillSubtotal.Text = "0,000.00";
            lblRentalBillSubtotal.TextAlign = ContentAlignment.TopRight;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(70, 324);
            label33.Name = "label33";
            label33.Size = new Size(196, 23);
            label33.TabIndex = 10;
            label33.Text = "Rental Bill Subtotal:";
            // 
            // lblElectricityBillSubtotal
            // 
            lblElectricityBillSubtotal.Location = new Point(272, 289);
            lblElectricityBillSubtotal.Name = "lblElectricityBillSubtotal";
            lblElectricityBillSubtotal.Size = new Size(116, 25);
            lblElectricityBillSubtotal.TabIndex = 9;
            lblElectricityBillSubtotal.Text = "0,000.00";
            lblElectricityBillSubtotal.TextAlign = ContentAlignment.TopRight;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(41, 289);
            label29.Name = "label29";
            label29.Size = new Size(225, 23);
            label29.TabIndex = 8;
            label29.Text = "Electricity Bill Subtotal:";
            // 
            // lblWaterBillSubtotal
            // 
            lblWaterBillSubtotal.Location = new Point(272, 254);
            lblWaterBillSubtotal.Name = "lblWaterBillSubtotal";
            lblWaterBillSubtotal.Size = new Size(116, 25);
            lblWaterBillSubtotal.TabIndex = 7;
            lblWaterBillSubtotal.Text = "0,000.00";
            lblWaterBillSubtotal.TextAlign = ContentAlignment.TopRight;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(76, 254);
            label25.Name = "label25";
            label25.Size = new Size(190, 23);
            label25.TabIndex = 6;
            label25.Text = "Water Bill Subtotal:";
            // 
            // lblInvoiceDueDate
            // 
            lblInvoiceDueDate.Location = new Point(154, 141);
            lblInvoiceDueDate.Name = "lblInvoiceDueDate";
            lblInvoiceDueDate.Size = new Size(234, 25);
            lblInvoiceDueDate.TabIndex = 5;
            lblInvoiceDueDate.Text = "September 01, 2000";
            lblInvoiceDueDate.TextAlign = ContentAlignment.TopRight;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(38, 141);
            label20.Name = "label20";
            label20.Size = new Size(110, 23);
            label20.TabIndex = 4;
            label20.Text = "Due Date:";
            // 
            // lblInvoiceDate
            // 
            lblInvoiceDate.Location = new Point(154, 107);
            lblInvoiceDate.Name = "lblInvoiceDate";
            lblInvoiceDate.Size = new Size(234, 25);
            lblInvoiceDate.TabIndex = 3;
            lblInvoiceDate.Text = "September 01, 2000";
            lblInvoiceDate.TextAlign = ContentAlignment.TopRight;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(6, 107);
            label13.Name = "label13";
            label13.Size = new Size(142, 23);
            label13.TabIndex = 2;
            label13.Text = "Invoice Date:";
            // 
            // lblInvoiceNumber
            // 
            lblInvoiceNumber.Font = new Font("Century Gothic", 14F);
            lblInvoiceNumber.Location = new Point(6, 67);
            lblInvoiceNumber.Name = "lblInvoiceNumber";
            lblInvoiceNumber.Size = new Size(382, 40);
            lblInvoiceNumber.TabIndex = 1;
            lblInvoiceNumber.Text = "label9";
            lblInvoiceNumber.TextAlign = ContentAlignment.TopRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 14F);
            label5.Location = new Point(6, 34);
            label5.Name = "label5";
            label5.Size = new Size(213, 30);
            label5.TabIndex = 0;
            label5.Text = "Invoice Number:";
            // 
            // Billing_New
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Snow;
            ClientSize = new Size(1177, 636);
            Controls.Add(grpBillInformation);
            Controls.Add(tbcReadings);
            Controls.Add(tbcBillSummary);
            Controls.Add(grpButtons);
            Controls.Add(grpSelectTenant);
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Billing_New";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BBH Records Keeping System - New Bill";
            FormClosing += Billing_New_FormClosing;
            Load += Billing_New_Load;
            grpSelectTenant.ResumeLayout(false);
            grpSelectTenant.PerformLayout();
            grpButtons.ResumeLayout(false);
            tbcBillSummary.ResumeLayout(false);
            tbpWaterBill.ResumeLayout(false);
            tbpWaterBill.PerformLayout();
            tbpElectricityBill.ResumeLayout(false);
            tbpElectricityBill.PerformLayout();
            tbpRentalBill.ResumeLayout(false);
            tbpRentalBill.PerformLayout();
            tbpInternetBill.ResumeLayout(false);
            tbpInternetBill.PerformLayout();
            tbcReadings.ResumeLayout(false);
            tbpWaterReadings.ResumeLayout(false);
            tbpWaterReadings.PerformLayout();
            tbpElectricityReadings.ResumeLayout(false);
            tbpElectricityReadings.PerformLayout();
            grpBillInformation.ResumeLayout(false);
            grpBillInformation.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpSelectTenant;
        private TextBox txtSearch;
        private ListBox lstTenants;
        private GroupBox grpButtons;
        private Button btnSave;
        private Button btnReset;
        private Button btnBillPreview;
        private TabControl tbcBillSummary;
        private TabPage tbpWaterBill;
        private TabPage tbpElectricityBill;
        private TabPage tbpRentalBill;
        private TabPage tbpInternetBill;
        private TabControl tbcReadings;
        private TabPage tbpWaterReadings;
        private TabPage tbpElectricityReadings;
        private GroupBox grpBillInformation;
        private Button btnWater_ConfirmReading;
        private Label label2;
        private Label label1;
        private TextBox txtWater_PresentReading;
        private TextBox txtWater_PreviousReading;
        private Button btnElectricity_ConfirmReading;
        private Label label3;
        private Label label4;
        private TextBox txtElectricity_PresentReading;
        private TextBox txtElectricity_PreviousReading;
        private Label label6;
        private Label lblWater_Previous;
        private Label lblWater_CurrentCharge;
        private Label label12;
        private Label lblWater_Consumption;
        private Label label10;
        private Label lblWater_Present;
        private Label label8;
        private Label lblWater_Subtotal;
        private Label label18;
        private Label lblWater_Deductions;
        private Label label16;
        private Label lblWater_Balance;
        private Label label14;
        private Label lblElectricity_Deductions;
        private Label label22;
        private Label lblElectricity_Balance;
        private Label label24;
        private Label lblElectricity_CurrentCharge;
        private Label label26;
        private Label lblElectricity_Consumption;
        private Label label28;
        private Label lblElectricity_Present;
        private Label label30;
        private Label lblElectricity_Previous;
        private Label label32;
        private Label lblRental_Deductions;
        private Label label36;
        private Label lblRental_Balance;
        private Label label38;
        private Label lblRental_CurrentCharge;
        private Label label40;
        private Label lblRental_Additionals;
        private Label label44;
        private Label lblRental_MonthlyDue;
        private Label label46;
        private Label lblInternet_Deductions;
        private Label label48;
        private Label lblInternet_Balance;
        private Label label50;
        private Label lblInternet_CurrentCharge;
        private Label label52;
        private Label lblInternet_SubscriptionFee;
        private Label label54;
        private Label lblInternet_Plan;
        private Label label56;
        private Label lblElectricity_Subtotal;
        private Label label7;
        private Label lblRental_Subtotal;
        private Label label11;
        private Label lblInternet_Subtotal;
        private Label label15;
        private Label lblInvoiceDate;
        private Label label13;
        private Label lblInvoiceNumber;
        private Label label5;
        private Label lblInternet_DueDate;
        private Label label21;
        private Label lblInvoiceDueDate;
        private Label label20;
        private Label lblBillTotal;
        private Label label39;
        private Label lblInternetBillSubtotal;
        private Label label35;
        private Label lblRentalBillSubtotal;
        private Label label33;
        private Label lblElectricityBillSubtotal;
        private Label label29;
        private Label lblWaterBillSubtotal;
        private Label label25;
        private Button btnExportToPDF;
    }
}