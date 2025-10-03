namespace BBH_Records_Keeping_System
{
    partial class Dashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel1 = new Panel();
            pcbLogout = new PictureBox();
            pictureBox1 = new PictureBox();
            lblUserName = new Label();
            btnTenants = new Button();
            btnSettings = new Button();
            btnPayment = new Button();
            btnBilling = new Button();
            lblTime = new Label();
            lblDate = new Label();
            panel2 = new Panel();
            label1 = new Label();
            tmrDateTime = new System.Windows.Forms.Timer(components);
            dgvOverdues = new DataGridView();
            label2 = new Label();
            dgvUnpaids = new DataGridView();
            label3 = new Label();
            pnlTenantQuickView = new Panel();
            lblRelationship = new Label();
            label28 = new Label();
            lklViewTenantAddress = new LinkLabel();
            lklViewEmergencyAddress = new LinkLabel();
            lklEmergency_Copy = new LinkLabel();
            lblEmergency_Phone = new Label();
            label26 = new Label();
            lblEmergency_ContactPerson = new Label();
            label24 = new Label();
            label22 = new Label();
            lblTenancyStatus = new Label();
            lblInternetPlan = new Label();
            lblEndDate = new Label();
            lblStartDate = new Label();
            lblRoom = new Label();
            lblRentType = new Label();
            lklTenant_Copy = new LinkLabel();
            lblPhone = new Label();
            lblDateOfBirth = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label7 = new Label();
            label6 = new Label();
            cmbTenantsList = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            tmrUnpaidUpdater = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcbLogout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOverdues).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUnpaids).BeginInit();
            pnlTenantQuickView.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = Color.SeaGreen;
            panel1.Controls.Add(pcbLogout);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(lblUserName);
            panel1.Controls.Add(btnTenants);
            panel1.Controls.Add(btnSettings);
            panel1.Controls.Add(btnPayment);
            panel1.Controls.Add(btnBilling);
            panel1.Controls.Add(lblTime);
            panel1.Controls.Add(lblDate);
            panel1.Location = new Point(-2, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(230, 594);
            panel1.TabIndex = 0;
            // 
            // pcbLogout
            // 
            pcbLogout.Cursor = Cursors.Hand;
            pcbLogout.Image = Properties.Resources.LogoutICON;
            pcbLogout.Location = new Point(182, 555);
            pcbLogout.Name = "pcbLogout";
            pcbLogout.Size = new Size(45, 36);
            pcbLogout.SizeMode = PictureBoxSizeMode.Zoom;
            pcbLogout.TabIndex = 8;
            pcbLogout.TabStop = false;
            pcbLogout.Click += pcbLogout_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(9, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(213, 184);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // lblUserName
            // 
            lblUserName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.ForeColor = Color.MintCream;
            lblUserName.Location = new Point(5, 568);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(117, 23);
            lblUserName.TabIndex = 6;
            lblUserName.Text = "User Name";
            // 
            // btnTenants
            // 
            btnTenants.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnTenants.BackColor = Color.DarkGreen;
            btnTenants.FlatAppearance.BorderSize = 0;
            btnTenants.FlatStyle = FlatStyle.Flat;
            btnTenants.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTenants.ForeColor = Color.Honeydew;
            btnTenants.Location = new Point(0, 458);
            btnTenants.Name = "btnTenants";
            btnTenants.Size = new Size(231, 49);
            btnTenants.TabIndex = 5;
            btnTenants.Text = "TENANTS";
            btnTenants.UseVisualStyleBackColor = false;
            btnTenants.Click += btnTenants_Click;
            // 
            // btnSettings
            // 
            btnSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSettings.BackColor = Color.DimGray;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSettings.ForeColor = Color.WhiteSmoke;
            btnSettings.Location = new Point(0, 507);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(231, 49);
            btnSettings.TabIndex = 4;
            btnSettings.Text = "SETTINGS";
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnPayment
            // 
            btnPayment.BackColor = Color.Teal;
            btnPayment.FlatAppearance.BorderSize = 0;
            btnPayment.FlatStyle = FlatStyle.Flat;
            btnPayment.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPayment.ForeColor = Color.LightCyan;
            btnPayment.Location = new Point(0, 293);
            btnPayment.Name = "btnPayment";
            btnPayment.Size = new Size(231, 49);
            btnPayment.TabIndex = 3;
            btnPayment.Text = "PAYMENT";
            btnPayment.UseVisualStyleBackColor = false;
            btnPayment.Click += btnPayment_Click;
            // 
            // btnBilling
            // 
            btnBilling.BackColor = Color.DarkRed;
            btnBilling.FlatAppearance.BorderSize = 0;
            btnBilling.FlatStyle = FlatStyle.Flat;
            btnBilling.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBilling.ForeColor = Color.MistyRose;
            btnBilling.Location = new Point(0, 244);
            btnBilling.Name = "btnBilling";
            btnBilling.Size = new Size(231, 49);
            btnBilling.TabIndex = 2;
            btnBilling.Text = "BILLING";
            btnBilling.UseVisualStyleBackColor = false;
            btnBilling.Click += btnBilling_Click;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTime.ForeColor = Color.MintCream;
            lblTime.Location = new Point(5, 214);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(127, 23);
            lblTime.TabIndex = 1;
            lblTime.Text = "00:00:00 AM";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDate.ForeColor = Color.MintCream;
            lblDate.Location = new Point(5, 187);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(200, 23);
            lblDate.TabIndex = 0;
            lblDate.Text = "September 00, 2000";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.SeaGreen;
            panel2.Controls.Add(label1);
            panel2.Location = new Point(227, 0);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1221, 67);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.Font = new Font("Century Gothic", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.MintCream;
            label1.Location = new Point(0, 4);
            label1.Name = "label1";
            label1.Size = new Size(1221, 56);
            label1.TabIndex = 0;
            label1.Text = "BBH RECORDS KEEPING SYSTEM";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // tmrDateTime
            // 
            tmrDateTime.Enabled = true;
            tmrDateTime.Interval = 500;
            tmrDateTime.Tick += tmrDateTime_Tick;
            // 
            // dgvOverdues
            // 
            dgvOverdues.AllowUserToAddRows = false;
            dgvOverdues.AllowUserToDeleteRows = false;
            dgvOverdues.AllowUserToOrderColumns = true;
            dgvOverdues.AllowUserToResizeRows = false;
            dgvOverdues.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvOverdues.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvOverdues.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvOverdues.BackgroundColor = Color.Snow;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvOverdues.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvOverdues.ColumnHeadersHeight = 29;
            dgvOverdues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvOverdues.GridColor = Color.MistyRose;
            dgvOverdues.Location = new Point(235, 361);
            dgvOverdues.Name = "dgvOverdues";
            dgvOverdues.ReadOnly = true;
            dgvOverdues.RowHeadersVisible = false;
            dgvOverdues.RowHeadersWidth = 51;
            dgvOverdues.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvOverdues.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOverdues.Size = new Size(840, 221);
            dgvOverdues.TabIndex = 7;
            dgvOverdues.CellContentDoubleClick += dgvOverdues_CellContentDoubleClick;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label2.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(192, 0, 0);
            label2.Location = new Point(235, 324);
            label2.Name = "label2";
            label2.Size = new Size(840, 34);
            label2.TabIndex = 6;
            label2.Text = "OVERDUE TENANTS";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // dgvUnpaids
            // 
            dgvUnpaids.AllowUserToAddRows = false;
            dgvUnpaids.AllowUserToDeleteRows = false;
            dgvUnpaids.AllowUserToOrderColumns = true;
            dgvUnpaids.AllowUserToResizeRows = false;
            dgvUnpaids.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvUnpaids.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvUnpaids.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvUnpaids.BackgroundColor = Color.LightCyan;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvUnpaids.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvUnpaids.ColumnHeadersHeight = 29;
            dgvUnpaids.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvUnpaids.GridColor = Color.PaleGreen;
            dgvUnpaids.Location = new Point(235, 107);
            dgvUnpaids.Name = "dgvUnpaids";
            dgvUnpaids.ReadOnly = true;
            dgvUnpaids.RowHeadersVisible = false;
            dgvUnpaids.RowHeadersWidth = 51;
            dgvUnpaids.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvUnpaids.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUnpaids.Size = new Size(840, 214);
            dgvUnpaids.TabIndex = 9;
            dgvUnpaids.CellContentDoubleClick += dgvUnpaids_CellContentDoubleClick;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label3.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkGreen;
            label3.Location = new Point(235, 70);
            label3.Name = "label3";
            label3.Size = new Size(840, 34);
            label3.TabIndex = 8;
            label3.Text = "UNPAID BILLS";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // pnlTenantQuickView
            // 
            pnlTenantQuickView.BackColor = Color.SeaGreen;
            pnlTenantQuickView.Controls.Add(lblRelationship);
            pnlTenantQuickView.Controls.Add(label28);
            pnlTenantQuickView.Controls.Add(lklViewTenantAddress);
            pnlTenantQuickView.Controls.Add(lklViewEmergencyAddress);
            pnlTenantQuickView.Controls.Add(lklEmergency_Copy);
            pnlTenantQuickView.Controls.Add(lblEmergency_Phone);
            pnlTenantQuickView.Controls.Add(label26);
            pnlTenantQuickView.Controls.Add(lblEmergency_ContactPerson);
            pnlTenantQuickView.Controls.Add(label24);
            pnlTenantQuickView.Controls.Add(label22);
            pnlTenantQuickView.Controls.Add(lblTenancyStatus);
            pnlTenantQuickView.Controls.Add(lblInternetPlan);
            pnlTenantQuickView.Controls.Add(lblEndDate);
            pnlTenantQuickView.Controls.Add(lblStartDate);
            pnlTenantQuickView.Controls.Add(lblRoom);
            pnlTenantQuickView.Controls.Add(lblRentType);
            pnlTenantQuickView.Controls.Add(lklTenant_Copy);
            pnlTenantQuickView.Controls.Add(lblPhone);
            pnlTenantQuickView.Controls.Add(lblDateOfBirth);
            pnlTenantQuickView.Controls.Add(label14);
            pnlTenantQuickView.Controls.Add(label13);
            pnlTenantQuickView.Controls.Add(label12);
            pnlTenantQuickView.Controls.Add(label11);
            pnlTenantQuickView.Controls.Add(label10);
            pnlTenantQuickView.Controls.Add(label9);
            pnlTenantQuickView.Controls.Add(label7);
            pnlTenantQuickView.Controls.Add(label6);
            pnlTenantQuickView.Controls.Add(cmbTenantsList);
            pnlTenantQuickView.Controls.Add(label5);
            pnlTenantQuickView.Controls.Add(label4);
            pnlTenantQuickView.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pnlTenantQuickView.Location = new Point(1081, 63);
            pnlTenantQuickView.Name = "pnlTenantQuickView";
            pnlTenantQuickView.Size = new Size(367, 531);
            pnlTenantQuickView.TabIndex = 10;
            // 
            // lblRelationship
            // 
            lblRelationship.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRelationship.ForeColor = Color.MintCream;
            lblRelationship.Location = new Point(170, 470);
            lblRelationship.Name = "lblRelationship";
            lblRelationship.Size = new Size(186, 23);
            lblRelationship.TabIndex = 31;
            lblRelationship.Text = "Date of Birth:";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label28.ForeColor = Color.MintCream;
            label28.Location = new Point(30, 470);
            label28.Name = "label28";
            label28.Size = new Size(134, 23);
            label28.TabIndex = 30;
            label28.Text = "Relationship:";
            // 
            // lklViewTenantAddress
            // 
            lklViewTenantAddress.ActiveLinkColor = Color.MintCream;
            lklViewTenantAddress.AutoSize = true;
            lklViewTenantAddress.LinkColor = Color.Lime;
            lklViewTenantAddress.Location = new Point(144, 144);
            lklViewTenantAddress.Name = "lklViewTenantAddress";
            lklViewTenantAddress.Size = new Size(142, 23);
            lklViewTenantAddress.TabIndex = 29;
            lklViewTenantAddress.TabStop = true;
            lklViewTenantAddress.Text = "View Address";
            lklViewTenantAddress.VisitedLinkColor = Color.Turquoise;
            lklViewTenantAddress.LinkClicked += lklViewTenantAddress_LinkClicked;
            // 
            // lklViewEmergencyAddress
            // 
            lklViewEmergencyAddress.ActiveLinkColor = Color.MintCream;
            lklViewEmergencyAddress.AutoSize = true;
            lklViewEmergencyAddress.LinkColor = Color.Lime;
            lklViewEmergencyAddress.Location = new Point(144, 441);
            lklViewEmergencyAddress.Name = "lklViewEmergencyAddress";
            lklViewEmergencyAddress.Size = new Size(142, 23);
            lklViewEmergencyAddress.TabIndex = 28;
            lklViewEmergencyAddress.TabStop = true;
            lklViewEmergencyAddress.Text = "View Address";
            lklViewEmergencyAddress.VisitedLinkColor = Color.Turquoise;
            lklViewEmergencyAddress.LinkClicked += lklViewEmergencyAddress_LinkClicked;
            // 
            // lklEmergency_Copy
            // 
            lklEmergency_Copy.ActiveLinkColor = Color.MintCream;
            lklEmergency_Copy.AutoSize = true;
            lklEmergency_Copy.LinkColor = Color.Lime;
            lklEmergency_Copy.Location = new Point(292, 441);
            lklEmergency_Copy.Name = "lklEmergency_Copy";
            lklEmergency_Copy.Size = new Size(64, 23);
            lklEmergency_Copy.TabIndex = 27;
            lklEmergency_Copy.TabStop = true;
            lklEmergency_Copy.Text = "Copy";
            lklEmergency_Copy.VisitedLinkColor = Color.Turquoise;
            lklEmergency_Copy.LinkClicked += lklEmergency_Copy_LinkClicked;
            // 
            // lblEmergency_Phone
            // 
            lblEmergency_Phone.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmergency_Phone.ForeColor = Color.MintCream;
            lblEmergency_Phone.Location = new Point(170, 418);
            lblEmergency_Phone.Name = "lblEmergency_Phone";
            lblEmergency_Phone.Size = new Size(186, 23);
            lblEmergency_Phone.TabIndex = 26;
            lblEmergency_Phone.Text = "Date of Birth:";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label26.ForeColor = Color.MintCream;
            label26.Location = new Point(26, 418);
            label26.Name = "label26";
            label26.Size = new Size(138, 23);
            label26.TabIndex = 25;
            label26.Text = "Phone/Email:";
            // 
            // lblEmergency_ContactPerson
            // 
            lblEmergency_ContactPerson.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmergency_ContactPerson.ForeColor = Color.MintCream;
            lblEmergency_ContactPerson.Location = new Point(170, 390);
            lblEmergency_ContactPerson.Name = "lblEmergency_ContactPerson";
            lblEmergency_ContactPerson.Size = new Size(186, 23);
            lblEmergency_ContactPerson.TabIndex = 24;
            lblEmergency_ContactPerson.Text = "Date of Birth:";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label24.ForeColor = Color.MintCream;
            label24.Location = new Point(-1, 390);
            label24.Name = "label24";
            label24.Size = new Size(165, 23);
            label24.TabIndex = 23;
            label24.Text = "Contact Person:";
            // 
            // label22
            // 
            label22.Font = new Font("Century Gothic", 14F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label22.ForeColor = Color.MintCream;
            label22.Location = new Point(0, 348);
            label22.Name = "label22";
            label22.Size = new Size(367, 42);
            label22.TabIndex = 22;
            label22.Text = "EMERGENCY INFO";
            label22.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblTenancyStatus
            // 
            lblTenancyStatus.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenancyStatus.ForeColor = Color.MintCream;
            lblTenancyStatus.Location = new Point(170, 316);
            lblTenancyStatus.Name = "lblTenancyStatus";
            lblTenancyStatus.Size = new Size(186, 23);
            lblTenancyStatus.TabIndex = 21;
            lblTenancyStatus.Text = "Date of Birth:";
            // 
            // lblInternetPlan
            // 
            lblInternetPlan.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInternetPlan.ForeColor = Color.MintCream;
            lblInternetPlan.Location = new Point(170, 288);
            lblInternetPlan.Name = "lblInternetPlan";
            lblInternetPlan.Size = new Size(186, 23);
            lblInternetPlan.TabIndex = 20;
            lblInternetPlan.Text = "Date of Birth:";
            // 
            // lblEndDate
            // 
            lblEndDate.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEndDate.ForeColor = Color.MintCream;
            lblEndDate.Location = new Point(170, 260);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(186, 23);
            lblEndDate.TabIndex = 19;
            lblEndDate.Text = "Date of Birth:";
            // 
            // lblStartDate
            // 
            lblStartDate.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStartDate.ForeColor = Color.MintCream;
            lblStartDate.Location = new Point(170, 232);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(186, 23);
            lblStartDate.TabIndex = 18;
            lblStartDate.Text = "Date of Birth:";
            // 
            // lblRoom
            // 
            lblRoom.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoom.ForeColor = Color.MintCream;
            lblRoom.Location = new Point(170, 207);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(186, 23);
            lblRoom.TabIndex = 17;
            lblRoom.Text = "Date of Birth:";
            // 
            // lblRentType
            // 
            lblRentType.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRentType.ForeColor = Color.MintCream;
            lblRentType.Location = new Point(170, 175);
            lblRentType.Name = "lblRentType";
            lblRentType.Size = new Size(186, 23);
            lblRentType.TabIndex = 16;
            lblRentType.Text = "Date of Birth:";
            // 
            // lklTenant_Copy
            // 
            lklTenant_Copy.ActiveLinkColor = Color.MintCream;
            lklTenant_Copy.AutoSize = true;
            lklTenant_Copy.LinkColor = Color.Lime;
            lklTenant_Copy.Location = new Point(292, 144);
            lklTenant_Copy.Name = "lklTenant_Copy";
            lklTenant_Copy.Size = new Size(64, 23);
            lklTenant_Copy.TabIndex = 16;
            lklTenant_Copy.TabStop = true;
            lklTenant_Copy.Text = "Copy";
            lklTenant_Copy.VisitedLinkColor = Color.Turquoise;
            lklTenant_Copy.LinkClicked += lklTenant_Copy_LinkClicked;
            // 
            // lblPhone
            // 
            lblPhone.Font = new Font("Century Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPhone.ForeColor = Color.MintCream;
            lblPhone.Location = new Point(170, 121);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(186, 23);
            lblPhone.TabIndex = 15;
            lblPhone.Text = "Date of Birth:";
            // 
            // lblDateOfBirth
            // 
            lblDateOfBirth.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDateOfBirth.ForeColor = Color.MintCream;
            lblDateOfBirth.Location = new Point(170, 93);
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.Size = new Size(186, 23);
            lblDateOfBirth.TabIndex = 14;
            lblDateOfBirth.Text = "Date of Birth:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.MintCream;
            label14.Location = new Point(3, 316);
            label14.Name = "label14";
            label14.Size = new Size(161, 23);
            label14.TabIndex = 12;
            label14.Text = "Tenancy Status:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.MintCream;
            label13.Location = new Point(27, 288);
            label13.Name = "label13";
            label13.Size = new Size(137, 23);
            label13.TabIndex = 11;
            label13.Text = "Internet Plan:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.MintCream;
            label12.Location = new Point(61, 260);
            label12.Name = "label12";
            label12.Size = new Size(103, 23);
            label12.TabIndex = 10;
            label12.Text = "End Date:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.MintCream;
            label11.Location = new Point(55, 232);
            label11.Name = "label11";
            label11.Size = new Size(109, 23);
            label11.TabIndex = 9;
            label11.Text = "Start Date:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.MintCream;
            label10.Location = new Point(91, 204);
            label10.Name = "label10";
            label10.Size = new Size(73, 23);
            label10.TabIndex = 7;
            label10.Text = "Room:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.MintCream;
            label9.Location = new Point(53, 175);
            label9.Name = "label9";
            label9.Size = new Size(111, 23);
            label9.TabIndex = 6;
            label9.Text = "Rent Type:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.MintCream;
            label7.Location = new Point(26, 121);
            label7.Name = "label7";
            label7.Size = new Size(138, 23);
            label7.TabIndex = 4;
            label7.Text = "Phone/Email:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.MintCream;
            label6.Location = new Point(30, 93);
            label6.Name = "label6";
            label6.Size = new Size(134, 23);
            label6.TabIndex = 3;
            label6.Text = "Date of Birth:";
            // 
            // cmbTenantsList
            // 
            cmbTenantsList.BackColor = Color.MintCream;
            cmbTenantsList.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTenantsList.FlatStyle = FlatStyle.Flat;
            cmbTenantsList.ForeColor = Color.SeaGreen;
            cmbTenantsList.FormattingEnabled = true;
            cmbTenantsList.Location = new Point(89, 46);
            cmbTenantsList.Name = "cmbTenantsList";
            cmbTenantsList.Size = new Size(267, 31);
            cmbTenantsList.TabIndex = 2;
            cmbTenantsList.SelectedIndexChanged += cmbTenantsList_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.MintCream;
            label5.Location = new Point(3, 49);
            label5.Name = "label5";
            label5.Size = new Size(80, 23);
            label5.TabIndex = 1;
            label5.Text = "Tenant:";
            // 
            // label4
            // 
            label4.Cursor = Cursors.Hand;
            label4.Font = new Font("Century Gothic", 16F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.MintCream;
            label4.Location = new Point(0, 7);
            label4.Name = "label4";
            label4.Size = new Size(367, 42);
            label4.TabIndex = 0;
            label4.Text = "TENANT QUICK VIEW";
            label4.TextAlign = ContentAlignment.TopCenter;
            label4.Click += label4_Click;
            // 
            // tmrUnpaidUpdater
            // 
            tmrUnpaidUpdater.Enabled = true;
            tmrUnpaidUpdater.Interval = 300000;
            tmrUnpaidUpdater.Tick += tmrUnpaidUpdater_Tick;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MintCream;
            ClientSize = new Size(1449, 594);
            Controls.Add(pnlTenantQuickView);
            Controls.Add(dgvUnpaids);
            Controls.Add(label3);
            Controls.Add(dgvOverdues);
            Controls.Add(label2);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BBH Records Keeping System - DASHBOARD";
            FormClosing += Dashboard_FormClosing;
            Load += Dashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pcbLogout).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOverdues).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUnpaids).EndInit();
            pnlTenantQuickView.ResumeLayout(false);
            pnlTenantQuickView.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label lblTime;
        private Label lblDate;
        private Label label1;
        private System.Windows.Forms.Timer tmrDateTime;
        private Button btnBilling;
        private Button btnTenants;
        private Button btnSettings;
        private Button btnPayment;
        private Label lblUserName;
        private PictureBox pictureBox1;
        private DataGridView dgvOverdues;
        private Label label2;
        private DataGridView dgvUnpaids;
        private Label label3;
        private Panel pnlTenantQuickView;
        private Label label4;
        private Label label10;
        private Label label9;
        private Label label7;
        private Label label6;
        private ComboBox cmbTenantsList;
        private Label label5;
        private Label lblRentType;
        private LinkLabel lklTenant_Copy;
        private Label lblPhone;
        private Label lblDateOfBirth;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label lblRelationship;
        private Label label28;
        private LinkLabel lklViewTenantAddress;
        private LinkLabel lklViewEmergencyAddress;
        private LinkLabel lklEmergency_Copy;
        private Label lblEmergency_Phone;
        private Label label26;
        private Label lblEmergency_ContactPerson;
        private Label label24;
        private Label label22;
        private Label lblTenancyStatus;
        private Label lblInternetPlan;
        private Label lblEndDate;
        private Label lblStartDate;
        private Label lblRoom;
        private System.Windows.Forms.Timer tmrUnpaidUpdater;
        private PictureBox pcbLogout;
    }
}
