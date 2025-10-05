namespace BBH_Records_Keeping_System
{
    partial class Payments_ALL_ORs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Payments_ALL_ORs));
            grpSelectTenant = new GroupBox();
            lstTenants = new ListBox();
            txtSearch = new TextBox();
            dgvBills = new DataGridView();
            grpSelectTenant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBills).BeginInit();
            SuspendLayout();
            // 
            // grpSelectTenant
            // 
            grpSelectTenant.Controls.Add(lstTenants);
            grpSelectTenant.Controls.Add(txtSearch);
            grpSelectTenant.Location = new Point(12, 12);
            grpSelectTenant.Name = "grpSelectTenant";
            grpSelectTenant.Size = new Size(320, 615);
            grpSelectTenant.TabIndex = 2;
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
            // dgvBills
            // 
            dgvBills.AllowUserToAddRows = false;
            dgvBills.AllowUserToDeleteRows = false;
            dgvBills.AllowUserToResizeColumns = false;
            dgvBills.AllowUserToResizeRows = false;
            dgvBills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBills.BackgroundColor = Color.MintCream;
            dgvBills.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBills.GridColor = Color.LightSteelBlue;
            dgvBills.Location = new Point(338, 12);
            dgvBills.Name = "dgvBills";
            dgvBills.ReadOnly = true;
            dgvBills.RowHeadersVisible = false;
            dgvBills.RowHeadersWidth = 51;
            dgvBills.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBills.Size = new Size(782, 615);
            dgvBills.TabIndex = 3;
            dgvBills.MouseDoubleClick += dgvBills_MouseDoubleClick;
            // 
            // Payments_ALL_ORs
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MintCream;
            ClientSize = new Size(1132, 639);
            Controls.Add(grpSelectTenant);
            Controls.Add(dgvBills);
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Payments_ALL_ORs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BBH Records Keeping System - Select Invoice";
            FormClosing += Payments_ALL_ORs_FormClosing;
            Load += Payments_ALL_ORs_Load;
            grpSelectTenant.ResumeLayout(false);
            grpSelectTenant.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBills).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpSelectTenant;
        private ListBox lstTenants;
        private TextBox txtSearch;
        private DataGridView dgvBills;
    }
}