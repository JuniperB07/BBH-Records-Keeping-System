using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BBHRKS.MySQL;
using BBHRKS.Metadata;
using BBHRKS.Interface;
using BBHRKS.Utilities;
using BBHRKS.UserManagement;
using JunX.NET8.MySQL;
using JunX.NET8.EncryptionService;
using JunX.NET8.WinForms;
using JunX.NET8.Utilities;

namespace BBH_Records_Keeping_System
{
    public partial class User_MANAGEMENT : Form
    {
        MySQLExecute Exec = new MySQLExecute();
        string UserEnabled;
        bool isNew;
        int userID;

        public User_MANAGEMENT()
        {
            InitializeComponent();
        }

        #region PRIVATE FUNCTIONS
        private bool AllowAccess()
        {
            Exec.CommandString = Construct.SelectCommand(
                Select: tbusers.Level.ToString(),
                From: tbusers.tbusers.ToString(),
                Where: tbusers.Username.ToString() + "='" + UserManagementHelper.Username + "'");
            Exec.ExecuteSelect();
            if (Exec.GetValues[0] == Metadata.User.Level.HIGH.ToString())
                return true;
            return false;
        }
        private void ClearForm()
        {
            txtPassword.Text = "";
            txtUsername.Text = "";
            cmbAccessLevel.Items.Clear();
        }
        private void ResetForm()
        {
            Forms.FillComboBox(cmbAccessLevel, ThisEnum<Metadata.User.Level>.ToList());


            dgvUsers.DataSource = null;
            Exec.CommandString = Construct.SelectAliasOrderByCommand(
                AliasMetadata: new SelectAsMetadata[]
                {
                    new SelectAsMetadata(
                        ColumnName: tbusers.Username.ToString(),
                        As: "Username"),
                    new SelectAsMetadata(
                        tbusers.Level.ToString(),
                        "Access Level"),
                    new SelectAsMetadata(
                        tbusers.Status.ToString(),
                        "Status") },
                From: tbusers.tbusers.ToString(),
                OrderBy: tbusers.Username.ToString(),
                OrderMode: MySQLOrderBy.ASC);
            Exec.ExecuteSelectToDataSet();
            dgvUsers.DataSource = Exec.DataSet.Tables[0];

            Interface.SetControlEnabled(new Control[]
            {
                txtUsername,
                chkEnabled,
                txtPassword,
                chkShow,
                cmbAccessLevel,
                btnSave }, false);
            Interface.SetControlEnabled(new Control[]
            {
                btnReset,
                btnNew,
                dgvUsers }, true);

            isNew = false;
            UserEnabled = "Disabled";
            chkEnabled.Checked = false;
            chkShow.Checked = false;
            txtPassword.PasswordChar = '•';
            userID = 0;
        }
        private void AddNewUser()
        {
            string userKey = UserManagement.GenerateUserKey(txtUsername.Text);
            string encryptedPass = "";

            EncryptionService ES = new EncryptionService(userKey);
            encryptedPass = ES.Encrypt(txtPassword.Text);

            Exec.CommandString = Construct.InsertIntoCommand(
                InsertInto: tbusers.tbusers.ToString(),
                InsertMetadata: new InsertColumnMetadata[]
                {
                    new InsertColumnMetadata(
                        ToColumn: tbusers.Username.ToString(),
                        WithDataType: MySQLDataType.VarChar,
                        WithValue: txtUsername.Text),
                    new InsertColumnMetadata(
                        tbusers.Password.ToString(),
                        MySQLDataType.Text,
                        encryptedPass),
                    new InsertColumnMetadata(
                        tbusers.Level.ToString(),
                        MySQLDataType.VarChar,
                        cmbAccessLevel.Text),
                    new InsertColumnMetadata(
                        tbusers.Status.ToString(),
                        MySQLDataType.VarChar,
                        UserEnabled) });
            Exec.ExecuteNonQuery();

            MessageBox.Show("User added.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void UpdateUser()
        {
            string userKey = UserManagement.GenerateUserKey(txtUsername.Text);
            string encrypedPass = "";

            EncryptionService ES = new EncryptionService(userKey);
            encrypedPass = ES.Encrypt(txtPassword.Text);

            Exec.CommandString = Construct.UpdateCommand(
                Update: tbusers.tbusers.ToString(),
                UpdateMetadata: new UpdateColumnMetadata[]
                {
                    new UpdateColumnMetadata(
                        UpdateColumn: tbusers.Username.ToString(),
                        WithDataType: MySQLDataType.VarChar,
                        SetValueTo: txtUsername.Text),
                    new UpdateColumnMetadata(
                        tbusers.Password.ToString(),
                        MySQLDataType.Text,
                        encrypedPass),
                    new UpdateColumnMetadata(
                        tbusers.Level.ToString(),
                        MySQLDataType.VarChar,
                        cmbAccessLevel.Text),
                    new UpdateColumnMetadata(
                        tbusers.Status.ToString(),
                        MySQLDataType.VarChar,
                        UserEnabled) },
                Where: tbusers.UserID.ToString() + "=" + userID.ToString());
            Exec.ExecuteNonQuery();

            MessageBox.Show("User information updated.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private void User_MANAGEMENT_Load(object sender, EventArgs e)
        {
            Exec = new MySQLExecute(Database.Connection);

            if (AllowAccess() == false)
            {
                MessageBox.Show("Access denied.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }

            ClearForm();
            ResetForm();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
            ResetForm();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Interface.SetControlEnabled(new Control[]
            {
                txtUsername,
                chkEnabled,
                txtPassword,
                chkShow,
                cmbAccessLevel,
                btnSave }, true);
            dgvUsers.Enabled = false;

            chkEnabled.Checked = false;
            chkShow.Checked = false;
            isNew = true;
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShow.Checked == false)
                txtPassword.PasswordChar = '•';
            else
                txtPassword.PasswordChar = '\0';
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnabled.Checked == false)
                UserEnabled = "Disabled";
            else
                UserEnabled = "Enabled";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool hasEmpty = Interface.CheckForEmptyField(new Control[]
                {
                    txtUsername,
                    txtPassword,
                    cmbAccessLevel });

            if (hasEmpty == false)
            {
                if (isNew == true)
                {
                    if (UserManagement.UserExists(txtUsername.Text, Exec) == false)
                        AddNewUser();
                    else
                        MessageBox.Show("User already exists.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    UpdateUser();

                btnReset.PerformClick();
            }
            else
                MessageBox.Show("Please fill all fields.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvUsers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string status = "";
            string encryptedPass = "";

            Exec.CommandString = Construct.SelectCommand(
                Select: tbusers.UserID.ToString(),
                From: tbusers.tbusers.ToString(),
                Where: tbusers.Username.ToString() + "=@Username");
            Exec.ExecuteSelect(new ParametersMetadata("@Username", dgvUsers.SelectedCells[0].Value.ToString()));
            userID = Convert.ToInt32(Exec.GetValues[0]);

            txtUsername.Text = dgvUsers.SelectedCells[0].Value.ToString();

            Exec.ClearValues();
            Exec.CommandString = Construct.SelectCommand(
                Select: new string[]
                {
                    tbusers.Password.ToString(),
                    tbusers.Level.ToString(),
                    tbusers.Status.ToString() },
                From: tbusers.tbusers.ToString(),
                Where: tbusers.UserID.ToString() + "=" + userID.ToString());
            Exec.ExecuteSelect();
            encryptedPass = Exec.GetValues[0];
            cmbAccessLevel.Text = Exec.GetValues[1];
            status = Exec.GetValues[2];

            if (status == Metadata.User.Status.Enabled.ToString())
                chkEnabled.Checked = true;
            else
                chkEnabled.Checked = false;

            string userKey = UserManagement.GenerateUserKey(txtUsername.Text);
            EncryptionService ES = new EncryptionService(userKey);
            txtPassword.Text = ES.Decrypt(encryptedPass);

            Interface.SetControlEnabled(new Control[]
            {
                txtUsername,
                chkEnabled,
                txtPassword,
                chkShow,
                cmbAccessLevel,
                btnSave }, true);
            dgvUsers.Enabled = false;

            chkShow.Checked = false;
            txtPassword.PasswordChar = '•';
            isNew = true;
            dgvUsers.Enabled = false;
            isNew = false;
        }
    }
}
