namespace BBH_Records_Keeping_System
{
    partial class Settings_MENU
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
            pictureBox1 = new PictureBox();
            btnBillPreviewExportPath = new Button();
            pictureBox2 = new PictureBox();
            btnUserManagement = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.EXPORTS_PATH;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(130, 121);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // btnBillPreviewExportPath
            // 
            btnBillPreviewExportPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnBillPreviewExportPath.BackColor = Color.Olive;
            btnBillPreviewExportPath.FlatAppearance.BorderSize = 0;
            btnBillPreviewExportPath.FlatStyle = FlatStyle.Flat;
            btnBillPreviewExportPath.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBillPreviewExportPath.ForeColor = Color.GhostWhite;
            btnBillPreviewExportPath.Location = new Point(148, 26);
            btnBillPreviewExportPath.Name = "btnBillPreviewExportPath";
            btnBillPreviewExportPath.Size = new Size(348, 92);
            btnBillPreviewExportPath.TabIndex = 5;
            btnBillPreviewExportPath.Text = "BILL PREVIEW EXPORT PATH";
            btnBillPreviewExportPath.UseVisualStyleBackColor = false;
            btnBillPreviewExportPath.Click += btnBillPreviewExportPath_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.USER_MANAGEMENT1;
            pictureBox2.Location = new Point(12, 159);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(130, 121);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // btnUserManagement
            // 
            btnUserManagement.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnUserManagement.BackColor = Color.FromArgb(64, 64, 64);
            btnUserManagement.FlatAppearance.BorderSize = 0;
            btnUserManagement.FlatStyle = FlatStyle.Flat;
            btnUserManagement.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUserManagement.ForeColor = Color.GhostWhite;
            btnUserManagement.Location = new Point(148, 173);
            btnUserManagement.Name = "btnUserManagement";
            btnUserManagement.Size = new Size(348, 92);
            btnUserManagement.TabIndex = 7;
            btnUserManagement.Text = "USER MANAGEMENT";
            btnUserManagement.UseVisualStyleBackColor = false;
            btnUserManagement.Click += btnUserManagement_Click;
            // 
            // Settings_MENU
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(508, 294);
            Controls.Add(btnUserManagement);
            Controls.Add(pictureBox2);
            Controls.Add(btnBillPreviewExportPath);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Settings_MENU";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BBH Records Keeping System - Settings Menu";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnBillPreviewExportPath;
        private PictureBox pictureBox2;
        private Button btnUserManagement;
    }
}