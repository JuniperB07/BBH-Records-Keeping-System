namespace BBH_Records_Keeping_System
{
    partial class Additionals_NEW
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Additionals_NEW));
            grpSelectTenant = new GroupBox();
            lstTenants = new ListBox();
            txtSearch = new TextBox();
            grpAdditionalsInformation = new GroupBox();
            btnReset = new Button();
            btnBilling = new Button();
            txtTotalFee = new TextBox();
            label3 = new Label();
            txtDetails = new TextBox();
            label2 = new Label();
            lklToday = new LinkLabel();
            dtpEnforcementDate = new DateTimePicker();
            label1 = new Label();
            dgvAdditionalCharges = new DataGridView();
            grpSelectTenant.SuspendLayout();
            grpAdditionalsInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdditionalCharges).BeginInit();
            SuspendLayout();
            // 
            // grpSelectTenant
            // 
            grpSelectTenant.Controls.Add(lstTenants);
            grpSelectTenant.Controls.Add(txtSearch);
            grpSelectTenant.Location = new Point(12, 12);
            grpSelectTenant.Name = "grpSelectTenant";
            grpSelectTenant.Size = new Size(320, 615);
            grpSelectTenant.TabIndex = 1;
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
            lstTenants.Size = new Size(308, 533);
            lstTenants.TabIndex = 1;
            lstTenants.MouseDoubleClick += lstTenants_MouseDoubleClick;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(6, 31);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(308, 32);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // grpAdditionalsInformation
            // 
            grpAdditionalsInformation.Controls.Add(btnReset);
            grpAdditionalsInformation.Controls.Add(btnBilling);
            grpAdditionalsInformation.Controls.Add(txtTotalFee);
            grpAdditionalsInformation.Controls.Add(label3);
            grpAdditionalsInformation.Controls.Add(txtDetails);
            grpAdditionalsInformation.Controls.Add(label2);
            grpAdditionalsInformation.Controls.Add(lklToday);
            grpAdditionalsInformation.Controls.Add(dtpEnforcementDate);
            grpAdditionalsInformation.Controls.Add(label1);
            grpAdditionalsInformation.Location = new Point(338, 12);
            grpAdditionalsInformation.Name = "grpAdditionalsInformation";
            grpAdditionalsInformation.Size = new Size(393, 615);
            grpAdditionalsInformation.TabIndex = 2;
            grpAdditionalsInformation.TabStop = false;
            grpAdditionalsInformation.Text = "Additional Charge Information";
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnReset.BackColor = Color.FromArgb(192, 0, 0);
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(6, 553);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(179, 56);
            btnReset.TabIndex = 8;
            btnReset.Text = "RESET";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // btnBilling
            // 
            btnBilling.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnBilling.BackColor = Color.FromArgb(0, 192, 0);
            btnBilling.FlatAppearance.BorderSize = 0;
            btnBilling.FlatStyle = FlatStyle.Flat;
            btnBilling.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBilling.ForeColor = Color.White;
            btnBilling.Location = new Point(208, 553);
            btnBilling.Name = "btnBilling";
            btnBilling.Size = new Size(179, 56);
            btnBilling.TabIndex = 7;
            btnBilling.Text = "SAVE";
            btnBilling.UseVisualStyleBackColor = false;
            btnBilling.Click += btnBilling_Click;
            // 
            // txtTotalFee
            // 
            txtTotalFee.Location = new Point(116, 486);
            txtTotalFee.Name = "txtTotalFee";
            txtTotalFee.Size = new Size(271, 32);
            txtTotalFee.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 489);
            label3.Name = "label3";
            label3.Size = new Size(104, 23);
            label3.TabIndex = 5;
            label3.Text = "Total Fee:";
            // 
            // txtDetails
            // 
            txtDetails.Location = new Point(6, 138);
            txtDetails.Multiline = true;
            txtDetails.Name = "txtDetails";
            txtDetails.Size = new Size(381, 342);
            txtDetails.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 112);
            label2.Name = "label2";
            label2.Size = new Size(80, 23);
            label2.TabIndex = 3;
            label2.Text = "Details:";
            // 
            // lklToday
            // 
            lklToday.AutoSize = true;
            lklToday.Location = new Point(207, 41);
            lklToday.Name = "lklToday";
            lklToday.Size = new Size(70, 23);
            lklToday.TabIndex = 2;
            lklToday.TabStop = true;
            lklToday.Text = "Today";
            lklToday.LinkClicked += lklToday_LinkClicked;
            // 
            // dtpEnforcementDate
            // 
            dtpEnforcementDate.CustomFormat = "MMMM d, yyyy";
            dtpEnforcementDate.Format = DateTimePickerFormat.Custom;
            dtpEnforcementDate.Location = new Point(6, 67);
            dtpEnforcementDate.MaxDate = new DateTime(2025, 10, 1, 16, 9, 1, 0);
            dtpEnforcementDate.Name = "dtpEnforcementDate";
            dtpEnforcementDate.RightToLeft = RightToLeft.Yes;
            dtpEnforcementDate.Size = new Size(381, 32);
            dtpEnforcementDate.TabIndex = 1;
            dtpEnforcementDate.Value = new DateTime(2025, 10, 1, 0, 0, 0, 0);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 41);
            label1.Name = "label1";
            label1.Size = new Size(195, 23);
            label1.TabIndex = 0;
            label1.Text = "Enforcement Date:";
            // 
            // dgvAdditionalCharges
            // 
            dgvAdditionalCharges.AllowUserToAddRows = false;
            dgvAdditionalCharges.AllowUserToDeleteRows = false;
            dgvAdditionalCharges.AllowUserToOrderColumns = true;
            dgvAdditionalCharges.AllowUserToResizeRows = false;
            dgvAdditionalCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvAdditionalCharges.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvAdditionalCharges.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvAdditionalCharges.BackgroundColor = Color.Snow;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAdditionalCharges.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAdditionalCharges.ColumnHeadersHeight = 29;
            dgvAdditionalCharges.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAdditionalCharges.GridColor = Color.MistyRose;
            dgvAdditionalCharges.Location = new Point(737, 12);
            dgvAdditionalCharges.Name = "dgvAdditionalCharges";
            dgvAdditionalCharges.ReadOnly = true;
            dgvAdditionalCharges.RowHeadersVisible = false;
            dgvAdditionalCharges.RowHeadersWidth = 51;
            dgvAdditionalCharges.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvAdditionalCharges.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdditionalCharges.Size = new Size(662, 615);
            dgvAdditionalCharges.TabIndex = 8;
            dgvAdditionalCharges.CellContentDoubleClick += dgvAdditionalCharges_CellContentDoubleClick;
            // 
            // Additionals_NEW
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Snow;
            ClientSize = new Size(1411, 635);
            Controls.Add(dgvAdditionalCharges);
            Controls.Add(grpAdditionalsInformation);
            Controls.Add(grpSelectTenant);
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Additionals_NEW";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BBH Records Keeping System - New Additional Charges";
            Load += Additionals_NEW_Load;
            grpSelectTenant.ResumeLayout(false);
            grpSelectTenant.PerformLayout();
            grpAdditionalsInformation.ResumeLayout(false);
            grpAdditionalsInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdditionalCharges).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpSelectTenant;
        private ListBox lstTenants;
        private TextBox txtSearch;
        private GroupBox grpAdditionalsInformation;
        private DataGridView dgvAdditionalCharges;
        private Label label1;
        private DateTimePicker dtpEnforcementDate;
        private TextBox txtTotalFee;
        private Label label3;
        private TextBox txtDetails;
        private Label label2;
        private LinkLabel lklToday;
        private Button btnReset;
        private Button btnBilling;
    }
}