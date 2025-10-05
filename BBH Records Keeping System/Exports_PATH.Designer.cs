namespace BBH_Records_Keeping_System
{
    partial class Exports_PATH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Exports_PATH));
            label1 = new Label();
            rtxtPath = new RichTextBox();
            label2 = new Label();
            btnChange = new Button();
            btnConfirm = new Button();
            fbdSelectFolder = new FolderBrowserDialog();
            rtxtNewPath = new RichTextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(138, 23);
            label1.TabIndex = 0;
            label1.Text = "Current Path:";
            // 
            // rtxtPath
            // 
            rtxtPath.BackColor = Color.White;
            rtxtPath.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rtxtPath.Location = new Point(12, 35);
            rtxtPath.Name = "rtxtPath";
            rtxtPath.ReadOnly = true;
            rtxtPath.Size = new Size(590, 113);
            rtxtPath.TabIndex = 1;
            rtxtPath.Text = "";
            // 
            // label2
            // 
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 151);
            label2.Name = "label2";
            label2.Size = new Size(590, 78);
            label2.TabIndex = 2;
            label2.Text = "*If a folder with the Tenant's name doesn't already exist, a new folder with their name will be created in this directory. The Bill Preview Exports will then be saved to their respective folders.";
            // 
            // btnChange
            // 
            btnChange.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnChange.BackColor = Color.FromArgb(0, 0, 192);
            btnChange.FlatAppearance.BorderSize = 0;
            btnChange.FlatStyle = FlatStyle.Flat;
            btnChange.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChange.ForeColor = Color.LightCyan;
            btnChange.Location = new Point(12, 414);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(199, 49);
            btnChange.TabIndex = 8;
            btnChange.Text = "CHANGE PATH";
            btnChange.UseVisualStyleBackColor = false;
            btnChange.Click += btnChange_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnConfirm.BackColor = Color.FromArgb(0, 192, 0);
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirm.ForeColor = Color.LightCyan;
            btnConfirm.Location = new Point(403, 414);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(199, 49);
            btnConfirm.TabIndex = 9;
            btnConfirm.Text = "CONFIRM";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // fbdSelectFolder
            // 
            fbdSelectFolder.Description = "Select Folder for Exports";
            fbdSelectFolder.ShowNewFolderButton = false;
            fbdSelectFolder.UseDescriptionForTitle = true;
            // 
            // rtxtNewPath
            // 
            rtxtNewPath.BackColor = Color.White;
            rtxtNewPath.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rtxtNewPath.Location = new Point(12, 295);
            rtxtNewPath.Name = "rtxtNewPath";
            rtxtNewPath.ReadOnly = true;
            rtxtNewPath.Size = new Size(590, 113);
            rtxtNewPath.TabIndex = 10;
            rtxtNewPath.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 269);
            label3.Name = "label3";
            label3.Size = new Size(112, 23);
            label3.TabIndex = 11;
            label3.Text = "New Path:";
            // 
            // Exports_PATH
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(614, 477);
            Controls.Add(label3);
            Controls.Add(rtxtNewPath);
            Controls.Add(btnConfirm);
            Controls.Add(btnChange);
            Controls.Add(label2);
            Controls.Add(rtxtPath);
            Controls.Add(label1);
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Exports_PATH";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BBH Records Keeping System - Settings - PDF Export Path";
            Load += Exports_PATH_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RichTextBox rtxtPath;
        private Label label2;
        private Button btnChange;
        private Button btnConfirm;
        private FolderBrowserDialog fbdSelectFolder;
        private RichTextBox rtxtNewPath;
        private Label label3;
    }
}