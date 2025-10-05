using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JunX.NET8.MySQL;
using JunX.NET8.EncryptionService;
using BBHRKS.MySQL;
using BBHRKS.Interface;
using BBHRKS.Metadata;
using BBHRKS.UserManagement;

namespace BBH_Records_Keeping_System
{
    public partial class Login : Form
    {
        DBConnect DBC;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            DBC = new DBConnect(Database.Connection);

            txtPassword.Text = "";
            txtUsername.Text = "";
            btnLogin.Enabled = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                string userKey = UserManagement.GenerateUserKey(txtUsername.Text);
                string encryptedPass = "";
                string decryptedPass = "";

                DBC.CommandString = Construct.SelectCommand(
                    Select: tbusers.Password.ToString(),
                    From: tbusers.tbusers.ToString(),
                    Where: tbusers.Username.ToString() + "=@Username");
                DBC.ExecuteReader(new ParametersMetadata("@Username", txtUsername.Text));
                if (DBC.HasRows == false)
                {
                    DBC.CloseReader();
                    MessageBox.Show("User not found.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DBC.GetValues();
                encryptedPass = DBC.Values[0];
                decryptedPass = new EncryptionService(userKey).Decrypt(encryptedPass);

                if(decryptedPass != txtPassword.Text)
                {
                    MessageBox.Show("Credentials is incorrect.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int userID = 0;
                DBC.CommandString = Construct.SelectCommand(
                    Select: tbusers.UserID.ToString(),
                    From: tbusers.tbusers.ToString(),
                    Where:
                        tbusers.Username.ToString() + "=@Username AND " +
                        tbusers.Password.ToString() + "=@EncryptedPass");
                DBC.ExecuteReader(new ParametersMetadata[]
                {
                    new ParametersMetadata("@Username", txtUsername.Text),
                    new ParametersMetadata("@EncryptedPass", encryptedPass) });
                DBC.GetValues();
                userID = Convert.ToInt32(DBC.Values[0]);

                DBC.CommandString = Construct.SelectCommand(
                    Select: tbusers.Status.ToString(),
                    From: tbusers.tbusers.ToString(),
                    Where: tbusers.UserID.ToString() + "=" + userID);
                DBC.ExecuteReader();
                DBC.GetValues();
                if (DBC.Values[0] == Metadata.User.Status.Disabled.ToString())
                {
                    MessageBox.Show("This user is currently disabled. Please contact support.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtPassword.Text = "";
                    txtUsername.Text = "";
                    btnLogin.Enabled = true;
                    txtUsername.Focus();

                    return;
                }

                LoginHelper.User = txtUsername.Text;
                LoginHelper.Allowed = true;
                Close();
            }
            else
                MessageBox.Show("Please enter Username and Password.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.PerformClick();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.PerformClick();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.PerformClick();
        }
    }
}
