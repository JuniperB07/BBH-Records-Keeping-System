namespace BBH_Records_Keeping_System
{
    partial class Additionals_VIEW
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Additionals_VIEW));
            lblTenantName = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            lblEnforcementDate = new Label();
            lblTotalFee = new Label();
            lblAmountPaid = new Label();
            lblRemainingBalance = new Label();
            lblStatus = new Label();
            label11 = new Label();
            rtxtAddress = new RichTextBox();
            btnMarkAsPaid = new Button();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // lblTenantName
            // 
            lblTenantName.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenantName.Location = new Point(12, 9);
            lblTenantName.Name = "lblTenantName";
            lblTenantName.Size = new Size(534, 41);
            lblTenantName.TabIndex = 0;
            lblTenantName.Text = "label1";
            lblTenantName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 70);
            label1.Name = "label1";
            label1.Size = new Size(195, 23);
            label1.TabIndex = 1;
            label1.Text = "Enforcement Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(112, 102);
            label2.Name = "label2";
            label2.Size = new Size(104, 23);
            label2.TabIndex = 2;
            label2.Text = "Total Fee:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(74, 134);
            label3.Name = "label3";
            label3.Size = new Size(142, 23);
            label3.TabIndex = 3;
            label3.Text = "Amount Paid:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 167);
            label4.Name = "label4";
            label4.Size = new Size(204, 23);
            label4.TabIndex = 4;
            label4.Text = "Remaining Balance:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(143, 200);
            label5.Name = "label5";
            label5.Size = new Size(73, 23);
            label5.TabIndex = 5;
            label5.Text = "Status:";
            // 
            // lblEnforcementDate
            // 
            lblEnforcementDate.Location = new Point(222, 70);
            lblEnforcementDate.Name = "lblEnforcementDate";
            lblEnforcementDate.Size = new Size(324, 25);
            lblEnforcementDate.TabIndex = 6;
            lblEnforcementDate.Text = "label6";
            // 
            // lblTotalFee
            // 
            lblTotalFee.Location = new Point(222, 102);
            lblTotalFee.Name = "lblTotalFee";
            lblTotalFee.Size = new Size(324, 25);
            lblTotalFee.TabIndex = 7;
            lblTotalFee.Text = "label7";
            // 
            // lblAmountPaid
            // 
            lblAmountPaid.Location = new Point(222, 134);
            lblAmountPaid.Name = "lblAmountPaid";
            lblAmountPaid.Size = new Size(324, 25);
            lblAmountPaid.TabIndex = 8;
            lblAmountPaid.Text = "label8";
            // 
            // lblRemainingBalance
            // 
            lblRemainingBalance.Location = new Point(222, 167);
            lblRemainingBalance.Name = "lblRemainingBalance";
            lblRemainingBalance.Size = new Size(324, 25);
            lblRemainingBalance.TabIndex = 9;
            lblRemainingBalance.Text = "label9";
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(222, 200);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(324, 25);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "label10";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(123, 233);
            label11.Name = "label11";
            label11.Size = new Size(93, 23);
            label11.TabIndex = 11;
            label11.Text = "Address:";
            // 
            // rtxtAddress
            // 
            rtxtAddress.Location = new Point(222, 233);
            rtxtAddress.Name = "rtxtAddress";
            rtxtAddress.ReadOnly = true;
            rtxtAddress.Size = new Size(324, 120);
            rtxtAddress.TabIndex = 12;
            rtxtAddress.Text = "";
            // 
            // btnMarkAsPaid
            // 
            btnMarkAsPaid.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnMarkAsPaid.BackColor = Color.FromArgb(0, 192, 0);
            btnMarkAsPaid.FlatAppearance.BorderSize = 0;
            btnMarkAsPaid.FlatStyle = FlatStyle.Flat;
            btnMarkAsPaid.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMarkAsPaid.ForeColor = Color.White;
            btnMarkAsPaid.Location = new Point(342, 358);
            btnMarkAsPaid.Name = "btnMarkAsPaid";
            btnMarkAsPaid.Size = new Size(204, 47);
            btnMarkAsPaid.TabIndex = 13;
            btnMarkAsPaid.Text = "MARK AS PAID";
            btnMarkAsPaid.UseVisualStyleBackColor = false;
            btnMarkAsPaid.Click += btnMarkAsPaid_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnDelete.BackColor = Color.FromArgb(192, 0, 0);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(12, 358);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(204, 47);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // Additionals_VIEW
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Snow;
            ClientSize = new Size(558, 417);
            Controls.Add(btnDelete);
            Controls.Add(btnMarkAsPaid);
            Controls.Add(rtxtAddress);
            Controls.Add(label11);
            Controls.Add(lblStatus);
            Controls.Add(lblRemainingBalance);
            Controls.Add(lblAmountPaid);
            Controls.Add(lblTotalFee);
            Controls.Add(lblEnforcementDate);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblTenantName);
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Additionals_VIEW";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BBH Records Keeping System - Additionals - View Details";
            Load += Additionals_VIEW_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTenantName;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lblEnforcementDate;
        private Label lblTotalFee;
        private Label lblAmountPaid;
        private Label lblRemainingBalance;
        private Label lblStatus;
        private Label label11;
        private RichTextBox rtxtAddress;
        private Button btnMarkAsPaid;
        private Button btnDelete;
    }
}