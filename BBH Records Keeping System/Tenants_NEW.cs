using BBHRKS.Interface;
using BBHRKS.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BBHRKS.Utilities;

namespace BBH_Records_Keeping_System
{
    public partial class Tenants_NEW : Form
    {
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader reader;

        public Tenants_NEW()
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Tenants_NEW_Load(object sender, EventArgs e)
        {
            Database.Initialize();
            Database.SetupMySQLCommandConnection(cmd, Database.Connection, CommandType.Text);

            FillComboBoxes();
            ClearForm();

            dtpStartDate.MaxDate = DateTime.Now;
            dtpEndDate.MaxDate = DateTime.Now;
            dtpStartDate.Value = DateTime.Now.AddDays(-1);
            dtpEndDate.Value = DateTime.Now.AddDays(-1);

            tbcNewTenant.SelectedTab = tbpTenantInfo;
        }

        private void Tenants_NEW_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Tenants_NEW_Load(this, EventArgs.Empty);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string tenantName = "";
            string currentRoomStatus = "";
            int tenantID = 0;

            bool hasEmpty = Interface.CheckForEmptyField(new TextBox[]
            {
                txtFirstName,
                txtLastName,
                txtPhone,
                txtEmergencyPerson,
                txtEmergencyPhone,
                txtEmergencyRelationship });
            if (hasEmpty)
            {
                MessageBox.Show("Please fill all required text fields.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            hasEmpty = Interface.CheckForEmptyField(new ComboBox[]
            {
                cmbRentType,
                cmbInternetPlan,
                cmbRoom,
                cmbStatus });
            if (hasEmpty)
            {
                MessageBox.Show("Please fill all required dropdowns.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            tenantName = txtLastName.Text + ", " + txtFirstName.Text;

            //CHECK IF ROOM IS AVAILABLE
            cmd.CommandText = Generate.SelectCommand(
                new string[] { "Status" },
                "tbRooms",
                "RoomName = '" + cmbRoom.Text + "'");
            reader = cmd.ExecuteReader();
            reader.Read();
            currentRoomStatus = reader[0].ToString();
            reader.Close();
            if (currentRoomStatus == Metadata.Rooms.Status.Occupied && cmbStatus.Text == Metadata.Tenants.TenancyStatus.Active)
            {
                MessageBox.Show("Selected room is currently occupied.\nSelect another room or set Tenancy Status to 'Inactive'", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //CHECK IF TENANT ALREADY EXISTS
            bool exists = false;
            cmd.CommandText = Generate.SelectAllCommand("tbTenants", "FullName='" + tenantName + "'");
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show("Tenant already exists.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            reader.Close();

            //INSERT TENANT & TENANCY DATA
            if (cmbRentType.Text == Metadata.Tenants.RentType.Fixed)
            {
                cmd.CommandText = Generate.InsertIntoCommand(
                    "tbTenants",
                    new Generate.InsertInfo[]
                    {
                        new Generate.InsertInfo("FirstName", txtFirstName.Text, Generate.DataTypes.String),
                        new Generate.InsertInfo("LastName", txtLastName.Text, Generate.DataTypes.String),
                        new Generate.InsertInfo("FullName", tenantName, Generate.DataTypes.String),
                        new Generate.InsertInfo("DateOfBirth", dtpDateOfBirth.Value.ToString("yyyy-MM-dd"), Generate.DataTypes.DateTime),
                        new Generate.InsertInfo("Phone", txtPhone.Text, Generate.DataTypes.String),
                        new Generate.InsertInfo("Address", Utilities.FillEmptyField(txtAddress.Text), Generate.DataTypes.String),
                        new Generate.InsertInfo("RentType", cmbRentType.Text, Generate.DataTypes.String),
                        new Generate.InsertInfo("Room", cmbRoom.Text, Generate.DataTypes.String),
                        new Generate.InsertInfo("StartDate", dtpStartDate.Value.ToString("yyyy-MM-dd"), Generate.DataTypes.DateTime),
                        new Generate.InsertInfo("EndDate", dtpEndDate.Value.ToString("yyyy-MM-dd"), Generate.DataTypes.DateTime),
                        new Generate.InsertInfo("InternetPlan", cmbInternetPlan.Text, Generate.DataTypes.String),
                        new Generate.InsertInfo("Status", cmbStatus.Text, Generate.DataTypes.String) });
                cmd.ExecuteNonQuery();
            }
            else if (cmbRentType.Text == Metadata.Tenants.RentType.Monthly)
            {
                cmd.CommandText = Generate.InsertIntoCommand(
                    "tbTenants",
                    new Generate.InsertInfo[]
                    {
                        new Generate.InsertInfo("FirstName", txtFirstName.Text, Generate.DataTypes.String),
                        new Generate.InsertInfo("LastName", txtLastName.Text, Generate.DataTypes.String),
                        new Generate.InsertInfo("FullName", tenantName, Generate.DataTypes.String),
                        new Generate.InsertInfo("DateOfBirth", dtpDateOfBirth.Value.ToString("yyyy-MM-dd"), Generate.DataTypes.DateTime),
                        new Generate.InsertInfo("Phone", txtPhone.Text, Generate.DataTypes.String),
                        new Generate.InsertInfo("Address", Utilities.FillEmptyField(txtAddress.Text), Generate.DataTypes.String),
                        new Generate.InsertInfo("RentType", cmbRentType.Text, Generate.DataTypes.String),
                        new Generate.InsertInfo("Room", cmbRoom.Text, Generate.DataTypes.String),
                        new Generate.InsertInfo("StartDate", dtpStartDate.Value.ToString("yyyy-MM-dd"), Generate.DataTypes.DateTime),
                        new Generate.InsertInfo("InternetPlan", cmbInternetPlan.Text, Generate.DataTypes.String),
                        new Generate.InsertInfo("Status", cmbStatus.Text, Generate.DataTypes.String) });
                cmd.ExecuteNonQuery();
            }

            //RETRIEVE NEW TENANT'S ID
            cmd.CommandText = Generate.SelectCommand(
                new string[] { "TenantID" },
                "tbTenants",
                "FullName='" + tenantName + "'");
            reader = cmd.ExecuteReader();
            reader.Read();
            tenantID = Convert.ToInt32(reader[0].ToString());
            reader.Close();

            //INSERT EMERGENCY DATA
            cmd.CommandText = Generate.InsertIntoCommand(
                "tbemergency",
                new Generate.InsertInfo[]
                {
                    new Generate.InsertInfo("TenantID", tenantID.ToString(), Generate.DataTypes.Int),
                    new Generate.InsertInfo("ContactPerson", txtEmergencyPerson.Text, Generate.DataTypes.String),
                    new Generate.InsertInfo("Phone", txtPhone.Text, Generate.DataTypes.String),
                    new Generate.InsertInfo("Address", Utilities.FillEmptyField(txtEmergencyAddress.Text), Generate.DataTypes.String),
                    new Generate.InsertInfo("Relationship", txtEmergencyRelationship.Text, Generate.DataTypes.String) });
            cmd.ExecuteNonQuery();

            //UPDATE ROOM STATUS
            cmd.CommandText = Generate.UpdateCommand(
                "tbrooms",
                new Generate.UpdateInfo[]
                {
                    new Generate.UpdateInfo("Status",Metadata.Rooms.Status.Occupied, Generate.DataTypes.String) },
                "RoomName='" + cmbRoom.Text + "'");
            cmd.ExecuteNonQuery();

            MessageBox.Show("Tenant added.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Tenants_NEW_Load(this, EventArgs.Empty);
        }

        private void cmbRentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRentType.Text == Metadata.Tenants.RentType.Fixed)
                dtpEndDate.Enabled = true;
            else
                dtpEndDate.Enabled = false;
        }

        #region PRIVATE FUNCTIONS
        private void ClearForm()
        {
            Interface.ClearControlText(new Control[]
            {
                txtFirstName,
                txtLastName,
                txtPhone,
                txtAddress,
                txtEmergencyPerson,
                txtEmergencyPhone,
                txtEmergencyAddress,
                txtEmergencyRelationship,
                cmbInternetPlan,
                cmbRentType,
                cmbRoom,
                cmbStatus
            });
            dtpDateOfBirth.Value = Convert.ToDateTime("2000-01-01");
            dtpEndDate.Value = Convert.ToDateTime("2000-01-01");
            dtpStartDate.Value = Convert.ToDateTime("2000-01-01");
        }
        private void FillComboBoxes()
        {
            Interface.FillComboBox(cmbRentType, Metadata.Tenants.RentType.Values);
            Interface.FillComboBox(cmbStatus, Metadata.Tenants.TenancyStatus.Values);

            Interface.FillComboBox(
                cmbInternetPlan,
                Database.ExtractToList(
                    Database.Connection,
                    cmd,
                    Generate.SelectCommand(
                        new string[] { "Details" },
                        "tbInternetPlans",
                        "status='Available'",
                        "PlanID",
                        Generate.SortBy.Ascending)));
            Interface.FillComboBox(
                cmbRoom,
                Database.ExtractToList(
                    Database.Connection,
                    cmd,
                    Generate.SelectCommand(
                        new string[] { "RoomName" },
                        "tbRooms",
                        "",
                        "RoomID",
                        Generate.SortBy.Ascending)));
        }
        #endregion
    }
}
