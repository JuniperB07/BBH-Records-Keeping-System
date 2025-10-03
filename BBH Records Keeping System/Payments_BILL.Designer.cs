namespace BBH_Records_Keeping_System
{
    partial class Payments_BILL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Payments_BILL));
            grpSelectTenant = new GroupBox();
            lstTenants = new ListBox();
            txtSearch = new TextBox();
            grpButtons = new GroupBox();
            btnPrintAllOR = new Button();
            btnSave = new Button();
            btnReset = new Button();
            grpOverallInvoiceInformation = new GroupBox();
            lblTotalPaymentsReceived = new Label();
            label8 = new Label();
            lblInvoiceStatus = new Label();
            label16 = new Label();
            lblOverallTotal = new Label();
            label14 = new Label();
            lblInternetTotal = new Label();
            label12 = new Label();
            lblRentUtilitiesTotal = new Label();
            label10 = new Label();
            lblInvoiceDate = new Label();
            label7 = new Label();
            lblInvoiceNumber = new Label();
            label5 = new Label();
            grpTransactionInformation = new GroupBox();
            lblTransactionDateTime = new Label();
            label3 = new Label();
            btnConfirmOR = new Button();
            lklGenerateOR = new LinkLabel();
            txtReceiptNumber = new TextBox();
            label1 = new Label();
            grpBillInformation = new GroupBox();
            lblPaymentsReceived = new Label();
            label6 = new Label();
            lblBillStatus = new Label();
            label24 = new Label();
            lblBillBalance = new Label();
            label22 = new Label();
            lblBillDueDate = new Label();
            label18 = new Label();
            label2 = new Label();
            cmbBillType = new ComboBox();
            lblChange = new Label();
            label20 = new Label();
            grpPaymentInformation = new GroupBox();
            btnCreditsToChange = new Button();
            btnChangeToCredits = new Button();
            btnConfirmPayment = new Button();
            lblCredits = new Label();
            label30 = new Label();
            lblTransactionBalance = new Label();
            label28 = new Label();
            btnConfirmAmountPaid = new Button();
            cmbPaymentMethod = new ComboBox();
            label26 = new Label();
            label25 = new Label();
            txtAmountPaid = new TextBox();
            grpSelectTenant.SuspendLayout();
            grpButtons.SuspendLayout();
            grpOverallInvoiceInformation.SuspendLayout();
            grpTransactionInformation.SuspendLayout();
            grpBillInformation.SuspendLayout();
            grpPaymentInformation.SuspendLayout();
            SuspendLayout();
            // 
            // grpSelectTenant
            // 
            grpSelectTenant.Controls.Add(lstTenants);
            grpSelectTenant.Controls.Add(txtSearch);
            grpSelectTenant.Location = new Point(12, 12);
            grpSelectTenant.Name = "grpSelectTenant";
            grpSelectTenant.Size = new Size(338, 498);
            grpSelectTenant.TabIndex = 1;
            grpSelectTenant.TabStop = false;
            grpSelectTenant.Text = "Select Tenant";
            // 
            // lstTenants
            // 
            lstTenants.BackColor = Color.MintCream;
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
            grpButtons.Controls.Add(btnPrintAllOR);
            grpButtons.Controls.Add(btnSave);
            grpButtons.Controls.Add(btnReset);
            grpButtons.Location = new Point(12, 516);
            grpButtons.Name = "grpButtons";
            grpButtons.Size = new Size(885, 164);
            grpButtons.TabIndex = 2;
            grpButtons.TabStop = false;
            grpButtons.Text = "Buttons";
            // 
            // btnPrintAllOR
            // 
            btnPrintAllOR.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrintAllOR.BackColor = Color.FromArgb(0, 0, 192);
            btnPrintAllOR.FlatAppearance.BorderSize = 0;
            btnPrintAllOR.FlatStyle = FlatStyle.Flat;
            btnPrintAllOR.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrintAllOR.ForeColor = Color.Honeydew;
            btnPrintAllOR.Location = new Point(644, 31);
            btnPrintAllOR.Name = "btnPrintAllOR";
            btnPrintAllOR.Size = new Size(232, 127);
            btnPrintAllOR.TabIndex = 45;
            btnPrintAllOR.Text = "PRINT ALL OR\r\nFROM INVOICE";
            btnPrintAllOR.UseVisualStyleBackColor = false;
            btnPrintAllOR.Click += btnPrintAllOR_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.DarkGreen;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.Honeydew;
            btnSave.Location = new Point(352, 31);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(204, 127);
            btnSave.TabIndex = 11;
            btnSave.Text = "SAVE TRANSACTION";
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
            btnReset.Size = new Size(204, 127);
            btnReset.TabIndex = 10;
            btnReset.Text = "RESET";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // grpOverallInvoiceInformation
            // 
            grpOverallInvoiceInformation.Controls.Add(lblTotalPaymentsReceived);
            grpOverallInvoiceInformation.Controls.Add(label8);
            grpOverallInvoiceInformation.Controls.Add(lblInvoiceStatus);
            grpOverallInvoiceInformation.Controls.Add(label16);
            grpOverallInvoiceInformation.Controls.Add(lblOverallTotal);
            grpOverallInvoiceInformation.Controls.Add(label14);
            grpOverallInvoiceInformation.Controls.Add(lblInternetTotal);
            grpOverallInvoiceInformation.Controls.Add(label12);
            grpOverallInvoiceInformation.Controls.Add(lblRentUtilitiesTotal);
            grpOverallInvoiceInformation.Controls.Add(label10);
            grpOverallInvoiceInformation.Controls.Add(lblInvoiceDate);
            grpOverallInvoiceInformation.Controls.Add(label7);
            grpOverallInvoiceInformation.Controls.Add(lblInvoiceNumber);
            grpOverallInvoiceInformation.Controls.Add(label5);
            grpOverallInvoiceInformation.Location = new Point(356, 163);
            grpOverallInvoiceInformation.Name = "grpOverallInvoiceInformation";
            grpOverallInvoiceInformation.Size = new Size(541, 347);
            grpOverallInvoiceInformation.TabIndex = 3;
            grpOverallInvoiceInformation.TabStop = false;
            grpOverallInvoiceInformation.Text = "Overall Invoice Information";
            // 
            // lblTotalPaymentsReceived
            // 
            lblTotalPaymentsReceived.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblTotalPaymentsReceived.ForeColor = Color.DarkGreen;
            lblTotalPaymentsReceived.Location = new Point(310, 260);
            lblTotalPaymentsReceived.Name = "lblTotalPaymentsReceived";
            lblTotalPaymentsReceived.Size = new Size(222, 23);
            lblTotalPaymentsReceived.TabIndex = 25;
            lblTotalPaymentsReceived.Text = "000000";
            lblTotalPaymentsReceived.TextAlign = ContentAlignment.TopRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            label8.Location = new Point(25, 260);
            label8.Name = "label8";
            label8.Size = new Size(210, 23);
            label8.TabIndex = 26;
            label8.Text = "Payments Received:";
            // 
            // lblInvoiceStatus
            // 
            lblInvoiceStatus.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblInvoiceStatus.Location = new Point(310, 313);
            lblInvoiceStatus.Name = "lblInvoiceStatus";
            lblInvoiceStatus.Size = new Size(222, 23);
            lblInvoiceStatus.TabIndex = 23;
            lblInvoiceStatus.Text = "000000";
            lblInvoiceStatus.TextAlign = ContentAlignment.TopRight;
            lblInvoiceStatus.TextChanged += lblInvoiceStatus_TextChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            label16.Location = new Point(84, 313);
            label16.Name = "label16";
            label16.Size = new Size(151, 23);
            label16.TabIndex = 24;
            label16.Text = "Invoice Status:";
            // 
            // lblOverallTotal
            // 
            lblOverallTotal.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblOverallTotal.Location = new Point(310, 206);
            lblOverallTotal.Name = "lblOverallTotal";
            lblOverallTotal.Size = new Size(222, 23);
            lblOverallTotal.TabIndex = 21;
            lblOverallTotal.Text = "000000";
            lblOverallTotal.TextAlign = ContentAlignment.TopRight;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            label14.Location = new Point(98, 206);
            label14.Name = "label14";
            label14.Size = new Size(137, 23);
            label14.TabIndex = 22;
            label14.Text = "Overall Total:";
            // 
            // lblInternetTotal
            // 
            lblInternetTotal.Location = new Point(310, 173);
            lblInternetTotal.Name = "lblInternetTotal";
            lblInternetTotal.Size = new Size(222, 23);
            lblInternetTotal.TabIndex = 19;
            lblInternetTotal.Text = "00000000";
            lblInternetTotal.TextAlign = ContentAlignment.TopRight;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(92, 173);
            label12.Name = "label12";
            label12.Size = new Size(143, 23);
            label12.TabIndex = 20;
            label12.Text = "Internet Total:";
            // 
            // lblRentUtilitiesTotal
            // 
            lblRentUtilitiesTotal.Location = new Point(310, 140);
            lblRentUtilitiesTotal.Name = "lblRentUtilitiesTotal";
            lblRentUtilitiesTotal.Size = new Size(222, 23);
            lblRentUtilitiesTotal.TabIndex = 17;
            lblRentUtilitiesTotal.Text = "000000";
            lblRentUtilitiesTotal.TextAlign = ContentAlignment.TopRight;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(34, 140);
            label10.Name = "label10";
            label10.Size = new Size(201, 23);
            label10.TabIndex = 18;
            label10.Text = "Rent && Utilities Total:";
            // 
            // lblInvoiceDate
            // 
            lblInvoiceDate.Location = new Point(187, 105);
            lblInvoiceDate.Name = "lblInvoiceDate";
            lblInvoiceDate.Size = new Size(345, 23);
            lblInvoiceDate.TabIndex = 15;
            lblInvoiceDate.Text = "September 30, 2000";
            lblInvoiceDate.TextAlign = ContentAlignment.TopRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(8, 105);
            label7.Name = "label7";
            label7.Size = new Size(142, 23);
            label7.TabIndex = 16;
            label7.Text = "Invoice Date:";
            // 
            // lblInvoiceNumber
            // 
            lblInvoiceNumber.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInvoiceNumber.Location = new Point(8, 62);
            lblInvoiceNumber.Name = "lblInvoiceNumber";
            lblInvoiceNumber.Size = new Size(524, 38);
            lblInvoiceNumber.TabIndex = 15;
            lblInvoiceNumber.Text = "[lblInvoiceNumber]";
            lblInvoiceNumber.TextAlign = ContentAlignment.TopRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(8, 28);
            label5.Name = "label5";
            label5.Size = new Size(240, 34);
            label5.TabIndex = 0;
            label5.Text = "Invoice Number:";
            // 
            // grpTransactionInformation
            // 
            grpTransactionInformation.Controls.Add(lblTransactionDateTime);
            grpTransactionInformation.Controls.Add(label3);
            grpTransactionInformation.Controls.Add(btnConfirmOR);
            grpTransactionInformation.Controls.Add(lklGenerateOR);
            grpTransactionInformation.Controls.Add(txtReceiptNumber);
            grpTransactionInformation.Controls.Add(label1);
            grpTransactionInformation.Location = new Point(356, 12);
            grpTransactionInformation.Name = "grpTransactionInformation";
            grpTransactionInformation.Size = new Size(541, 145);
            grpTransactionInformation.TabIndex = 4;
            grpTransactionInformation.TabStop = false;
            grpTransactionInformation.Text = "Transaction Information";
            // 
            // lblTransactionDateTime
            // 
            lblTransactionDateTime.Location = new Point(6, 117);
            lblTransactionDateTime.Name = "lblTransactionDateTime";
            lblTransactionDateTime.Size = new Size(362, 23);
            lblTransactionDateTime.TabIndex = 14;
            lblTransactionDateTime.Text = "September 30, 2000";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 84);
            label3.Name = "label3";
            label3.Size = new Size(229, 23);
            label3.TabIndex = 13;
            label3.Text = "Transaction Date Time:";
            // 
            // btnConfirmOR
            // 
            btnConfirmOR.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConfirmOR.BackColor = Color.MediumSeaGreen;
            btnConfirmOR.FlatAppearance.BorderSize = 0;
            btnConfirmOR.FlatStyle = FlatStyle.Flat;
            btnConfirmOR.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirmOR.ForeColor = Color.Honeydew;
            btnConfirmOR.Location = new Point(374, 96);
            btnConfirmOR.Name = "btnConfirmOR";
            btnConfirmOR.Size = new Size(158, 44);
            btnConfirmOR.TabIndex = 12;
            btnConfirmOR.Text = "CONFIRM";
            btnConfirmOR.UseVisualStyleBackColor = false;
            btnConfirmOR.Click += btnConfirmOR_Click;
            // 
            // lklGenerateOR
            // 
            lklGenerateOR.ActiveLinkColor = Color.Lime;
            lklGenerateOR.AutoSize = true;
            lklGenerateOR.DisabledLinkColor = Color.FromArgb(0, 64, 0);
            lklGenerateOR.LinkColor = Color.Green;
            lklGenerateOR.Location = new Point(310, 70);
            lklGenerateOR.Name = "lklGenerateOR";
            lklGenerateOR.Size = new Size(225, 23);
            lklGenerateOR.TabIndex = 2;
            lklGenerateOR.TabStop = true;
            lklGenerateOR.Text = "Generate OR Number";
            lklGenerateOR.LinkClicked += lklGenerateOR_LinkClicked;
            // 
            // txtReceiptNumber
            // 
            txtReceiptNumber.Location = new Point(187, 35);
            txtReceiptNumber.Name = "txtReceiptNumber";
            txtReceiptNumber.Size = new Size(348, 32);
            txtReceiptNumber.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 38);
            label1.Name = "label1";
            label1.Size = new Size(175, 23);
            label1.TabIndex = 0;
            label1.Text = "Receipt Number:";
            // 
            // grpBillInformation
            // 
            grpBillInformation.Controls.Add(lblPaymentsReceived);
            grpBillInformation.Controls.Add(label6);
            grpBillInformation.Controls.Add(lblBillStatus);
            grpBillInformation.Controls.Add(label24);
            grpBillInformation.Controls.Add(lblBillBalance);
            grpBillInformation.Controls.Add(label22);
            grpBillInformation.Controls.Add(lblBillDueDate);
            grpBillInformation.Controls.Add(label18);
            grpBillInformation.Controls.Add(label2);
            grpBillInformation.Controls.Add(cmbBillType);
            grpBillInformation.Location = new Point(903, 12);
            grpBillInformation.Name = "grpBillInformation";
            grpBillInformation.Size = new Size(475, 251);
            grpBillInformation.TabIndex = 5;
            grpBillInformation.TabStop = false;
            grpBillInformation.Text = "Bill Information";
            // 
            // lblPaymentsReceived
            // 
            lblPaymentsReceived.Location = new Point(231, 146);
            lblPaymentsReceived.Name = "lblPaymentsReceived";
            lblPaymentsReceived.Size = new Size(238, 23);
            lblPaymentsReceived.TabIndex = 33;
            lblPaymentsReceived.Text = "0000.00";
            lblPaymentsReceived.TextAlign = ContentAlignment.TopRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 146);
            label6.Name = "label6";
            label6.Size = new Size(211, 23);
            label6.TabIndex = 34;
            label6.Text = "Payments Received:";
            // 
            // lblBillStatus
            // 
            lblBillStatus.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBillStatus.Location = new Point(231, 212);
            lblBillStatus.Name = "lblBillStatus";
            lblBillStatus.Size = new Size(238, 23);
            lblBillStatus.TabIndex = 31;
            lblBillStatus.Text = "Unpaid";
            lblBillStatus.TextAlign = ContentAlignment.TopRight;
            lblBillStatus.TextChanged += lblBillStatus_TextChanged;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(114, 212);
            label24.Name = "label24";
            label24.Size = new Size(103, 23);
            label24.TabIndex = 32;
            label24.Text = "Bill Status:";
            // 
            // lblBillBalance
            // 
            lblBillBalance.Location = new Point(231, 179);
            lblBillBalance.Name = "lblBillBalance";
            lblBillBalance.Size = new Size(238, 23);
            lblBillBalance.TabIndex = 29;
            lblBillBalance.Text = "0000.00";
            lblBillBalance.TextAlign = ContentAlignment.TopRight;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(90, 179);
            label22.Name = "label22";
            label22.Size = new Size(127, 23);
            label22.TabIndex = 30;
            label22.Text = "Bill Balance:";
            // 
            // lblBillDueDate
            // 
            lblBillDueDate.Location = new Point(231, 96);
            lblBillDueDate.Name = "lblBillDueDate";
            lblBillDueDate.Size = new Size(238, 23);
            lblBillDueDate.TabIndex = 25;
            lblBillDueDate.Text = "September 30, 2000";
            lblBillDueDate.TextAlign = ContentAlignment.TopRight;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(77, 96);
            label18.Name = "label18";
            label18.Size = new Size(140, 23);
            label18.TabIndex = 26;
            label18.Text = "Bill Due Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 38);
            label2.Name = "label2";
            label2.Size = new Size(91, 23);
            label2.TabIndex = 6;
            label2.Text = "Bill Type:";
            // 
            // cmbBillType
            // 
            cmbBillType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBillType.FormattingEnabled = true;
            cmbBillType.Location = new Point(121, 35);
            cmbBillType.Name = "cmbBillType";
            cmbBillType.Size = new Size(348, 31);
            cmbBillType.TabIndex = 5;
            cmbBillType.SelectedIndexChanged += cmbBillType_SelectedIndexChanged;
            // 
            // lblChange
            // 
            lblChange.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblChange.ForeColor = Color.Green;
            lblChange.Location = new Point(311, 169);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(158, 23);
            lblChange.TabIndex = 27;
            lblChange.Text = "0000.00";
            lblChange.TextAlign = ContentAlignment.TopRight;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(210, 169);
            label20.Name = "label20";
            label20.Size = new Size(95, 23);
            label20.TabIndex = 28;
            label20.Text = "Change:";
            // 
            // grpPaymentInformation
            // 
            grpPaymentInformation.Controls.Add(btnCreditsToChange);
            grpPaymentInformation.Controls.Add(btnChangeToCredits);
            grpPaymentInformation.Controls.Add(btnConfirmPayment);
            grpPaymentInformation.Controls.Add(lblCredits);
            grpPaymentInformation.Controls.Add(label30);
            grpPaymentInformation.Controls.Add(lblTransactionBalance);
            grpPaymentInformation.Controls.Add(label28);
            grpPaymentInformation.Controls.Add(btnConfirmAmountPaid);
            grpPaymentInformation.Controls.Add(cmbPaymentMethod);
            grpPaymentInformation.Controls.Add(label26);
            grpPaymentInformation.Controls.Add(label25);
            grpPaymentInformation.Controls.Add(lblChange);
            grpPaymentInformation.Controls.Add(label20);
            grpPaymentInformation.Controls.Add(txtAmountPaid);
            grpPaymentInformation.Location = new Point(903, 269);
            grpPaymentInformation.Name = "grpPaymentInformation";
            grpPaymentInformation.Size = new Size(475, 411);
            grpPaymentInformation.TabIndex = 6;
            grpPaymentInformation.TabStop = false;
            grpPaymentInformation.Text = "Payment Information";
            // 
            // btnCreditsToChange
            // 
            btnCreditsToChange.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreditsToChange.BackColor = Color.DarkGoldenrod;
            btnCreditsToChange.FlatAppearance.BorderSize = 0;
            btnCreditsToChange.FlatStyle = FlatStyle.Flat;
            btnCreditsToChange.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreditsToChange.ForeColor = Color.Cornsilk;
            btnCreditsToChange.Location = new Point(258, 278);
            btnCreditsToChange.Name = "btnCreditsToChange";
            btnCreditsToChange.Size = new Size(211, 77);
            btnCreditsToChange.TabIndex = 43;
            btnCreditsToChange.Text = "CREDITS TO CHANGE";
            btnCreditsToChange.UseVisualStyleBackColor = false;
            btnCreditsToChange.Click += btnCreditsToChange_Click;
            // 
            // btnChangeToCredits
            // 
            btnChangeToCredits.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChangeToCredits.BackColor = Color.DarkGoldenrod;
            btnChangeToCredits.FlatAppearance.BorderSize = 0;
            btnChangeToCredits.FlatStyle = FlatStyle.Flat;
            btnChangeToCredits.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChangeToCredits.ForeColor = Color.Cornsilk;
            btnChangeToCredits.Location = new Point(6, 278);
            btnChangeToCredits.Name = "btnChangeToCredits";
            btnChangeToCredits.Size = new Size(211, 77);
            btnChangeToCredits.TabIndex = 42;
            btnChangeToCredits.Text = "CHANGE TO CREDITS";
            btnChangeToCredits.UseVisualStyleBackColor = false;
            btnChangeToCredits.Click += btnChangeToCredits_Click;
            // 
            // btnConfirmPayment
            // 
            btnConfirmPayment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConfirmPayment.BackColor = Color.MediumSeaGreen;
            btnConfirmPayment.FlatAppearance.BorderSize = 0;
            btnConfirmPayment.FlatStyle = FlatStyle.Flat;
            btnConfirmPayment.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirmPayment.ForeColor = Color.Honeydew;
            btnConfirmPayment.Location = new Point(6, 361);
            btnConfirmPayment.Name = "btnConfirmPayment";
            btnConfirmPayment.Size = new Size(463, 44);
            btnConfirmPayment.TabIndex = 41;
            btnConfirmPayment.Text = "CONFIRM PAYMENT";
            btnConfirmPayment.UseVisualStyleBackColor = false;
            btnConfirmPayment.Click += btnConfirmPayment_Click;
            // 
            // lblCredits
            // 
            lblCredits.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblCredits.ForeColor = Color.Goldenrod;
            lblCredits.Location = new Point(311, 236);
            lblCredits.Name = "lblCredits";
            lblCredits.Size = new Size(158, 23);
            lblCredits.TabIndex = 39;
            lblCredits.Text = "0000.00";
            lblCredits.TextAlign = ContentAlignment.TopRight;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(223, 236);
            label30.Name = "label30";
            label30.Size = new Size(82, 23);
            label30.TabIndex = 40;
            label30.Text = "Credits:";
            // 
            // lblTransactionBalance
            // 
            lblTransactionBalance.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblTransactionBalance.ForeColor = Color.Red;
            lblTransactionBalance.Location = new Point(311, 203);
            lblTransactionBalance.Name = "lblTransactionBalance";
            lblTransactionBalance.Size = new Size(158, 23);
            lblTransactionBalance.TabIndex = 37;
            lblTransactionBalance.Text = "0000.00";
            lblTransactionBalance.TextAlign = ContentAlignment.TopRight;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(92, 203);
            label28.Name = "label28";
            label28.Size = new Size(213, 23);
            label28.TabIndex = 38;
            label28.Text = "Transaction Balance:";
            // 
            // btnConfirmAmountPaid
            // 
            btnConfirmAmountPaid.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConfirmAmountPaid.BackColor = Color.MediumSeaGreen;
            btnConfirmAmountPaid.FlatAppearance.BorderSize = 0;
            btnConfirmAmountPaid.FlatStyle = FlatStyle.Flat;
            btnConfirmAmountPaid.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirmAmountPaid.ForeColor = Color.Honeydew;
            btnConfirmAmountPaid.Location = new Point(311, 113);
            btnConfirmAmountPaid.Name = "btnConfirmAmountPaid";
            btnConfirmAmountPaid.Size = new Size(158, 44);
            btnConfirmAmountPaid.TabIndex = 15;
            btnConfirmAmountPaid.Text = "CONFIRM";
            btnConfirmAmountPaid.UseVisualStyleBackColor = false;
            btnConfirmAmountPaid.Click += btnConfirmAmountPaid_Click;
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Location = new Point(223, 69);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(246, 31);
            cmbPaymentMethod.TabIndex = 36;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(32, 72);
            label26.Name = "label26";
            label26.Size = new Size(185, 23);
            label26.TabIndex = 35;
            label26.Text = "Payment Method:";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(75, 34);
            label25.Name = "label25";
            label25.Size = new Size(142, 23);
            label25.TabIndex = 33;
            label25.Text = "Amount Paid:";
            // 
            // txtAmountPaid
            // 
            txtAmountPaid.Location = new Point(223, 31);
            txtAmountPaid.Name = "txtAmountPaid";
            txtAmountPaid.Size = new Size(246, 32);
            txtAmountPaid.TabIndex = 0;
            // 
            // Payments_BILL
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MintCream;
            ClientSize = new Size(1390, 692);
            Controls.Add(grpPaymentInformation);
            Controls.Add(grpBillInformation);
            Controls.Add(grpTransactionInformation);
            Controls.Add(grpOverallInvoiceInformation);
            Controls.Add(grpButtons);
            Controls.Add(grpSelectTenant);
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Payments_BILL";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BBH Records Keeping System - Payments";
            FormClosing += Payments_BILL_FormClosing;
            Load += Payments_BILL_Load;
            grpSelectTenant.ResumeLayout(false);
            grpSelectTenant.PerformLayout();
            grpButtons.ResumeLayout(false);
            grpOverallInvoiceInformation.ResumeLayout(false);
            grpOverallInvoiceInformation.PerformLayout();
            grpTransactionInformation.ResumeLayout(false);
            grpTransactionInformation.PerformLayout();
            grpBillInformation.ResumeLayout(false);
            grpBillInformation.PerformLayout();
            grpPaymentInformation.ResumeLayout(false);
            grpPaymentInformation.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpSelectTenant;
        private ListBox lstTenants;
        private TextBox txtSearch;
        private GroupBox grpButtons;
        private GroupBox grpOverallInvoiceInformation;
        private GroupBox grpTransactionInformation;
        private LinkLabel lklGenerateOR;
        private TextBox txtReceiptNumber;
        private Label label1;
        private Button btnConfirmOR;
        private Button btnSave;
        private Button btnReset;
        private Label lblTransactionDateTime;
        private Label label3;
        private GroupBox grpBillInformation;
        private Label label2;
        private ComboBox cmbBillType;
        private Label lblInvoiceNumber;
        private Label label5;
        private Label lblOverallTotal;
        private Label label14;
        private Label lblInternetTotal;
        private Label label12;
        private Label lblRentUtilitiesTotal;
        private Label label10;
        private Label lblInvoiceDate;
        private Label label7;
        private Label lblInvoiceStatus;
        private Label label16;
        private Label lblBillDueDate;
        private Label label18;
        private Label lblBillStatus;
        private Label label24;
        private Label lblBillBalance;
        private Label label22;
        private Label lblChange;
        private Label label20;
        private GroupBox grpPaymentInformation;
        private Button btnConfirmAmountPaid;
        private ComboBox cmbPaymentMethod;
        private Label label26;
        private Label label25;
        private TextBox txtAmountPaid;
        private Button btnConfirmPayment;
        private Label lblCredits;
        private Label label30;
        private Label lblTransactionBalance;
        private Label label28;
        private Button btnCreditsToChange;
        private Button btnChangeToCredits;
        private Button btnPrintAllOR;
        private Label lblPaymentsReceived;
        private Label label6;
        private Label lblTotalPaymentsReceived;
        private Label label8;
    }
}