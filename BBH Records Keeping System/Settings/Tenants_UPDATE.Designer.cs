namespace BBH_Records_Keeping_System
{
    partial class Tenants_UPDATE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tenants_UPDATE));
            grpButtons = new GroupBox();
            btnSave = new Button();
            btnClear = new Button();
            tbcUpdateTenant = new TabControl();
            tbpTenantInfo = new TabPage();
            label5 = new Label();
            txtAddress = new TextBox();
            label4 = new Label();
            txtPhone = new TextBox();
            label3 = new Label();
            dtpDateOfBirth = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            tbpEmergency = new TabPage();
            label9 = new Label();
            txtEmergencyRelationship = new TextBox();
            label8 = new Label();
            txtEmergencyAddress = new TextBox();
            label7 = new Label();
            txtEmergencyPhone = new TextBox();
            label6 = new Label();
            txtEmergencyPerson = new TextBox();
            tbpTenancy = new TabPage();
            cmbStatus = new ComboBox();
            label15 = new Label();
            cmbInternetPlan = new ComboBox();
            label14 = new Label();
            cmbRoom = new ComboBox();
            label13 = new Label();
            label12 = new Label();
            dtpEndDate = new DateTimePicker();
            label11 = new Label();
            dtpStartDate = new DateTimePicker();
            cmbRentType = new ComboBox();
            label10 = new Label();
            grpSearch = new GroupBox();
            lstTenants = new ListBox();
            txtSearch = new TextBox();
            grpButtons.SuspendLayout();
            tbcUpdateTenant.SuspendLayout();
            tbpTenantInfo.SuspendLayout();
            tbpEmergency.SuspendLayout();
            tbpTenancy.SuspendLayout();
            grpSearch.SuspendLayout();
            SuspendLayout();
            // 
            // grpButtons
            // 
            grpButtons.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            grpButtons.Controls.Add(btnSave);
            grpButtons.Controls.Add(btnClear);
            grpButtons.Location = new Point(420, 447);
            grpButtons.Name = "grpButtons";
            grpButtons.Size = new Size(512, 112);
            grpButtons.TabIndex = 3;
            grpButtons.TabStop = false;
            grpButtons.Text = "Buttons";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DarkGreen;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(326, 31);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 75);
            btnSave.TabIndex = 8;
            btnSave.Text = "SAVE TENANT";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.DarkRed;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(6, 31);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(180, 75);
            btnClear.TabIndex = 7;
            btnClear.Text = "RESET";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // tbcUpdateTenant
            // 
            tbcUpdateTenant.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbcUpdateTenant.Controls.Add(tbpTenantInfo);
            tbcUpdateTenant.Controls.Add(tbpEmergency);
            tbcUpdateTenant.Controls.Add(tbpTenancy);
            tbcUpdateTenant.Location = new Point(416, 12);
            tbcUpdateTenant.Name = "tbcUpdateTenant";
            tbcUpdateTenant.SelectedIndex = 0;
            tbcUpdateTenant.Size = new Size(520, 429);
            tbcUpdateTenant.TabIndex = 2;
            // 
            // tbpTenantInfo
            // 
            tbpTenantInfo.BackColor = Color.SeaShell;
            tbpTenantInfo.Controls.Add(label5);
            tbpTenantInfo.Controls.Add(txtAddress);
            tbpTenantInfo.Controls.Add(label4);
            tbpTenantInfo.Controls.Add(txtPhone);
            tbpTenantInfo.Controls.Add(label3);
            tbpTenantInfo.Controls.Add(dtpDateOfBirth);
            tbpTenantInfo.Controls.Add(label2);
            tbpTenantInfo.Controls.Add(label1);
            tbpTenantInfo.Controls.Add(txtLastName);
            tbpTenantInfo.Controls.Add(txtFirstName);
            tbpTenantInfo.Location = new Point(4, 32);
            tbpTenantInfo.Name = "tbpTenantInfo";
            tbpTenantInfo.Padding = new Padding(3);
            tbpTenantInfo.Size = new Size(512, 393);
            tbpTenantInfo.TabIndex = 0;
            tbpTenantInfo.Text = "Tenant Info";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 179);
            label5.Name = "label5";
            label5.Size = new Size(179, 23);
            label5.TabIndex = 9;
            label5.Text = "Previous Address:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(191, 173);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(315, 112);
            txtAddress.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(41, 131);
            label4.Name = "label4";
            label4.Size = new Size(147, 23);
            label4.TabIndex = 7;
            label4.Text = "Phone/Email*:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(191, 125);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(315, 32);
            txtPhone.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 87);
            label3.Name = "label3";
            label3.Size = new Size(134, 23);
            label3.TabIndex = 5;
            label3.Text = "Date of Birth:";
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.CustomFormat = "MMMM d, yyyy";
            dtpDateOfBirth.Format = DateTimePickerFormat.Custom;
            dtpDateOfBirth.Location = new Point(191, 77);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(315, 32);
            dtpDateOfBirth.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 10.2F);
            label2.Location = new Point(335, 44);
            label2.Name = "label2";
            label2.Size = new Size(106, 21);
            label2.TabIndex = 3;
            label2.Text = "Last Name*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.2F);
            label1.Location = new Point(84, 44);
            label1.Name = "label1";
            label1.Size = new Size(102, 21);
            label1.TabIndex = 2;
            label1.Text = "First Name*";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(259, 6);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(247, 32);
            txtLastName.TabIndex = 1;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(6, 6);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(247, 32);
            txtFirstName.TabIndex = 0;
            // 
            // tbpEmergency
            // 
            tbpEmergency.BackColor = Color.SeaShell;
            tbpEmergency.Controls.Add(label9);
            tbpEmergency.Controls.Add(txtEmergencyRelationship);
            tbpEmergency.Controls.Add(label8);
            tbpEmergency.Controls.Add(txtEmergencyAddress);
            tbpEmergency.Controls.Add(label7);
            tbpEmergency.Controls.Add(txtEmergencyPhone);
            tbpEmergency.Controls.Add(label6);
            tbpEmergency.Controls.Add(txtEmergencyPerson);
            tbpEmergency.Location = new Point(4, 29);
            tbpEmergency.Name = "tbpEmergency";
            tbpEmergency.Padding = new Padding(3);
            tbpEmergency.Size = new Size(512, 396);
            tbpEmergency.TabIndex = 1;
            tbpEmergency.Text = "Emergency";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(48, 236);
            label9.Name = "label9";
            label9.Size = new Size(140, 23);
            label9.TabIndex = 15;
            label9.Text = "Relationship*:";
            // 
            // txtEmergencyRelationship
            // 
            txtEmergencyRelationship.Location = new Point(191, 230);
            txtEmergencyRelationship.Name = "txtEmergencyRelationship";
            txtEmergencyRelationship.Size = new Size(315, 32);
            txtEmergencyRelationship.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(95, 108);
            label8.Name = "label8";
            label8.Size = new Size(93, 23);
            label8.TabIndex = 13;
            label8.Text = "Address:";
            // 
            // txtEmergencyAddress
            // 
            txtEmergencyAddress.Location = new Point(191, 102);
            txtEmergencyAddress.Multiline = true;
            txtEmergencyAddress.Name = "txtEmergencyAddress";
            txtEmergencyAddress.Size = new Size(315, 112);
            txtEmergencyAddress.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(41, 60);
            label7.Name = "label7";
            label7.Size = new Size(147, 23);
            label7.TabIndex = 11;
            label7.Text = "Phone/Email*:";
            // 
            // txtEmergencyPhone
            // 
            txtEmergencyPhone.Location = new Point(191, 54);
            txtEmergencyPhone.Name = "txtEmergencyPhone";
            txtEmergencyPhone.Size = new Size(315, 32);
            txtEmergencyPhone.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 12);
            label6.Name = "label6";
            label6.Size = new Size(176, 23);
            label6.TabIndex = 9;
            label6.Text = "Contact Person*:";
            // 
            // txtEmergencyPerson
            // 
            txtEmergencyPerson.Location = new Point(191, 6);
            txtEmergencyPerson.Name = "txtEmergencyPerson";
            txtEmergencyPerson.Size = new Size(315, 32);
            txtEmergencyPerson.TabIndex = 8;
            // 
            // tbpTenancy
            // 
            tbpTenancy.BackColor = Color.SeaShell;
            tbpTenancy.Controls.Add(cmbStatus);
            tbpTenancy.Controls.Add(label15);
            tbpTenancy.Controls.Add(cmbInternetPlan);
            tbpTenancy.Controls.Add(label14);
            tbpTenancy.Controls.Add(cmbRoom);
            tbpTenancy.Controls.Add(label13);
            tbpTenancy.Controls.Add(label12);
            tbpTenancy.Controls.Add(dtpEndDate);
            tbpTenancy.Controls.Add(label11);
            tbpTenancy.Controls.Add(dtpStartDate);
            tbpTenancy.Controls.Add(cmbRentType);
            tbpTenancy.Controls.Add(label10);
            tbpTenancy.Location = new Point(4, 32);
            tbpTenancy.Name = "tbpTenancy";
            tbpTenancy.Padding = new Padding(3);
            tbpTenancy.Size = new Size(512, 393);
            tbpTenancy.TabIndex = 2;
            tbpTenancy.Text = "Tenancy";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(191, 243);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(315, 31);
            cmbStatus.TabIndex = 24;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(106, 249);
            label15.Name = "label15";
            label15.Size = new Size(82, 23);
            label15.TabIndex = 23;
            label15.Text = "Status*:";
            // 
            // cmbInternetPlan
            // 
            cmbInternetPlan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInternetPlan.FormattingEnabled = true;
            cmbInternetPlan.Location = new Point(191, 196);
            cmbInternetPlan.Name = "cmbInternetPlan";
            cmbInternetPlan.Size = new Size(315, 31);
            cmbInternetPlan.TabIndex = 22;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(40, 202);
            label14.Name = "label14";
            label14.Size = new Size(148, 23);
            label14.TabIndex = 21;
            label14.Text = "Internet Plan*:";
            // 
            // cmbRoom
            // 
            cmbRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoom.FormattingEnabled = true;
            cmbRoom.Location = new Point(191, 149);
            cmbRoom.Name = "cmbRoom";
            cmbRoom.Size = new Size(315, 31);
            cmbRoom.TabIndex = 20;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(87, 155);
            label13.Name = "label13";
            label13.Size = new Size(101, 23);
            label13.TabIndex = 19;
            label13.Text = "Room #*:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(81, 111);
            label12.Name = "label12";
            label12.Size = new Size(107, 23);
            label12.TabIndex = 18;
            label12.Text = "End Date:";
            // 
            // dtpEndDate
            // 
            dtpEndDate.CustomFormat = "MMMM d, yyyy";
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.Location = new Point(191, 101);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(315, 32);
            dtpEndDate.TabIndex = 17;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(65, 63);
            label11.Name = "label11";
            label11.Size = new Size(123, 23);
            label11.TabIndex = 16;
            label11.Text = "Start Date*:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.CustomFormat = "MMMM d, yyyy";
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.Location = new Point(191, 53);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(315, 32);
            dtpStartDate.TabIndex = 15;
            // 
            // cmbRentType
            // 
            cmbRentType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRentType.FormattingEnabled = true;
            cmbRentType.Location = new Point(191, 6);
            cmbRentType.Name = "cmbRentType";
            cmbRentType.Size = new Size(315, 31);
            cmbRentType.TabIndex = 14;
            cmbRentType.SelectedIndexChanged += cmbRentType_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(68, 12);
            label10.Name = "label10";
            label10.Size = new Size(120, 23);
            label10.TabIndex = 13;
            label10.Text = "Rent Type*:";
            // 
            // grpSearch
            // 
            grpSearch.Controls.Add(lstTenants);
            grpSearch.Controls.Add(txtSearch);
            grpSearch.Location = new Point(12, 12);
            grpSearch.Name = "grpSearch";
            grpSearch.Size = new Size(395, 547);
            grpSearch.TabIndex = 4;
            grpSearch.TabStop = false;
            grpSearch.Text = "Search Tenant:";
            // 
            // lstTenants
            // 
            lstTenants.BackColor = Color.SeaShell;
            lstTenants.FormattingEnabled = true;
            lstTenants.ItemHeight = 23;
            lstTenants.Location = new Point(6, 69);
            lstTenants.Name = "lstTenants";
            lstTenants.Size = new Size(383, 464);
            lstTenants.TabIndex = 1;
            lstTenants.MouseDoubleClick += lstTenants_MouseDoubleClick;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(6, 31);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(383, 32);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // Tenants_UPDATE
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SeaShell;
            ClientSize = new Size(948, 571);
            Controls.Add(grpSearch);
            Controls.Add(grpButtons);
            Controls.Add(tbcUpdateTenant);
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Tenants_UPDATE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BBH Records Keeping System - Update Tenant";
            Load += Tenants_UPDATE_Load;
            grpButtons.ResumeLayout(false);
            tbcUpdateTenant.ResumeLayout(false);
            tbpTenantInfo.ResumeLayout(false);
            tbpTenantInfo.PerformLayout();
            tbpEmergency.ResumeLayout(false);
            tbpEmergency.PerformLayout();
            tbpTenancy.ResumeLayout(false);
            tbpTenancy.PerformLayout();
            grpSearch.ResumeLayout(false);
            grpSearch.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpButtons;
        private Button btnSave;
        private Button btnClear;
        private TabControl tbcUpdateTenant;
        private TabPage tbpTenantInfo;
        private Label label5;
        private TextBox txtAddress;
        private Label label4;
        private TextBox txtPhone;
        private Label label3;
        private DateTimePicker dtpDateOfBirth;
        private Label label2;
        private Label label1;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private TabPage tbpEmergency;
        private Label label9;
        private TextBox txtEmergencyRelationship;
        private Label label8;
        private TextBox txtEmergencyAddress;
        private Label label7;
        private TextBox txtEmergencyPhone;
        private Label label6;
        private TextBox txtEmergencyPerson;
        private TabPage tbpTenancy;
        private ComboBox cmbStatus;
        private Label label15;
        private ComboBox cmbInternetPlan;
        private Label label14;
        private ComboBox cmbRoom;
        private Label label13;
        private Label label12;
        private DateTimePicker dtpEndDate;
        private Label label11;
        private DateTimePicker dtpStartDate;
        private ComboBox cmbRentType;
        private Label label10;
        private GroupBox grpSearch;
        private ListBox lstTenants;
        private TextBox txtSearch;
    }
}