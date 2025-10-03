namespace BBH_Records_Keeping_System
{
    partial class Tenants_MENU
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tenants_MENU));
            btnNewTenant = new Button();
            btnUpdateTenant = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btnNewTenant
            // 
            btnNewTenant.BackColor = Color.MidnightBlue;
            btnNewTenant.FlatAppearance.BorderSize = 0;
            btnNewTenant.FlatStyle = FlatStyle.Flat;
            btnNewTenant.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewTenant.ForeColor = Color.White;
            btnNewTenant.Location = new Point(116, 12);
            btnNewTenant.Name = "btnNewTenant";
            btnNewTenant.Size = new Size(245, 92);
            btnNewTenant.TabIndex = 6;
            btnNewTenant.Text = "NEW TENANT";
            btnNewTenant.UseVisualStyleBackColor = false;
            btnNewTenant.Click += btnNewTenant_Click;
            // 
            // btnUpdateTenant
            // 
            btnUpdateTenant.BackColor = Color.Goldenrod;
            btnUpdateTenant.FlatAppearance.BorderSize = 0;
            btnUpdateTenant.FlatStyle = FlatStyle.Flat;
            btnUpdateTenant.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdateTenant.ForeColor = Color.White;
            btnUpdateTenant.Location = new Point(116, 121);
            btnUpdateTenant.Name = "btnUpdateTenant";
            btnUpdateTenant.Size = new Size(245, 92);
            btnUpdateTenant.TabIndex = 7;
            btnUpdateTenant.Text = "UPDATE TENANT";
            btnUpdateTenant.UseVisualStyleBackColor = false;
            btnUpdateTenant.Click += btnUpdateTenant_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(98, 92);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(12, 121);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(98, 92);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // Tenants_MENU
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(377, 225);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(btnUpdateTenant);
            Controls.Add(btnNewTenant);
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Tenants_MENU";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BBH Records Keeping System - Tenants Menu";
            FormClosing += Tenants_MENU_FormClosing;
            Load += Tenants_MENU_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnNewTenant;
        private Button btnUpdateTenant;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}