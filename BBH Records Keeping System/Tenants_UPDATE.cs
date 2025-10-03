using MySql.Data.MySqlClient;
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
using BBHRKS.Utilities;
using BBHRKS.Metadata;
using BBHRKS.Interface;
using JunX.NET8.MySQL;

namespace BBH_Records_Keeping_System
{
    public partial class Tenants_UPDATE : Form
    {
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader reader;
        MySQLExecute Exec;
        int TenantID = 0;
        string TenantRoom = "", TenantName = "";
        string TenantStatus = "";

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

        public Tenants_UPDATE()
        {
            InitializeComponent();
            Database.Initialize();
        }

        private void Tenants_UPDATE_Load(object sender, EventArgs e)
        {
            cmd = new MySqlCommand();
            Database.SetupMySQLCommandConnection(cmd, Database.Connection, CommandType.Text);
            Exec = new MySQLExecute(Database.Connection);

            FillComboBoxes();
            ClearForm();

            dtpStartDate.MaxDate = DateTime.Now;
            dtpEndDate.MaxDate = DateTime.Now;
            dtpStartDate.Value = DateTime.Now.AddDays(-1);
            dtpEndDate.Value = DateTime.Now.AddDays(-1);
            dtpEndDate.Value = Convert.ToDateTime("2000-01-01");
            txtSearch.Text = "";
            lstTenants.Items.Clear();

            cmd.CommandText = Generate.SelectCommand(
                new string[] { "FullName" },
                "tbTenants",
                SortColumn: "FullName",
                Sort: Generate.SortBy.Ascending);
            reader = cmd.ExecuteReader();
            while (reader.Read())
                lstTenants.Items.Add(reader[0].ToString());
            reader.Close();

            TenantID = 0;
            TenantRoom = "";
            TenantName = "";

            dtpEndDate.Enabled = false;
            tbcUpdateTenant.SelectedTab = tbpTenantInfo;
            tbcUpdateTenant.Enabled = false;
            grpButtons.Enabled = false;
            grpSearch.Enabled = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstTenants.Items.Clear();

            if (txtSearch.Text != "")
                cmd.CommandText = "SELECT FullName FROM tbTenants WHERE FullName LIKE '%" + txtSearch.Text + "%' ORDER BY FullName ASC;";
            else
                cmd.CommandText = Generate.SelectCommand(
                    new string[] { "FullName" },
                    "tbTenants",
                    SortColumn: "FullName",
                    Sort: Generate.SortBy.Ascending);

            reader = cmd.ExecuteReader();
            while (reader.Read())
                lstTenants.Items.Add(reader[0].ToString());
            reader.Close();
        }

        private void lstTenants_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstTenants.SelectedIndex != -1)
            {
                TenantName = lstTenants.SelectedItem.ToString();

                //RETRIEVE TENANT ID
                cmd.CommandText = Generate.SelectCommand(
                    new string[] { Database.Tables.tbTenants.TenantID.ToString() },
                    Database.Tables.tbTenants.tbTenants.ToString(),
                    Database.Tables.tbTenants.FullName.ToString() + "='" + TenantName + "'");
                reader = cmd.ExecuteReader();
                reader.Read();
                TenantID = Convert.ToInt32(reader[0].ToString());
                reader.Close();

                //RETRIEVE TENANT & TENANCY INFORMATION
                cmd.CommandText = Generate.SelectCommand(
                    new string[]
                    {
                        Database.Tables.tbTenants.FirstName.ToString(),
                        Database.Tables.tbTenants.LastName.ToString(),
                        Database.Tables.tbTenants.DateOfBirth.ToString(),
                        Database.Tables.tbTenants.Phone.ToString(),
                        Database.Tables.tbTenants.Address.ToString(),
                        Database.Tables.tbTenants.RentType.ToString(),
                        Database.Tables.tbTenants.Room.ToString(),
                        Database.Tables.tbTenants.StartDate.ToString(),
                        Database.Tables.tbTenants.EndDate.ToString(),
                        Database.Tables.tbTenants.InternetPlan.ToString(),
                        Database.Tables.tbTenants.Status.ToString() },
                    Database.Tables.tbTenants.tbTenants.ToString(),
                    Database.Tables.tbTenants.TenantID.ToString() + "=" + TenantID);
                reader = cmd.ExecuteReader();
                reader.Read();
                txtFirstName.Text = reader[0].ToString();
                txtLastName.Text = reader[1].ToString();
                dtpDateOfBirth.Value = Convert.ToDateTime(reader[2].ToString());
                txtPhone.Text = reader[3].ToString();
                txtAddress.Text = reader[4].ToString();
                cmbRentType.Text = reader[5].ToString();
                cmbRoom.Text = reader[6].ToString();
                dtpStartDate.Value = Convert.ToDateTime(reader[7].ToString());
                if (cmbRentType.Text == Metadata.Tenants.RentType.Fixed)
                    dtpEndDate.Value = Convert.ToDateTime(reader[8].ToString());
                cmbInternetPlan.Text = reader[9].ToString();
                cmbStatus.Text = reader[10].ToString();
                reader.Close();

                //RETRIEVE EMERGENCY INFORMATION
                cmd.CommandText = Generate.SelectCommand(
                    new string[]
                    {
                        Database.Tables.tbEmergency.ContactPerson.ToString(),
                        Database.Tables.tbEmergency.Phone.ToString(),
                        Database.Tables.tbEmergency.Address.ToString(),
                        Database.Tables.tbEmergency.Relationship.ToString() },
                    Database.Tables.tbEmergency.tbEmergency.ToString(),
                    Database.Tables.tbEmergency.TenantID.ToString() + "=" + TenantID);
                reader = cmd.ExecuteReader();
                reader.Read();
                txtEmergencyPerson.Text = reader[0].ToString();
                txtEmergencyPhone.Text = reader[1].ToString();
                txtEmergencyAddress.Text = reader[2].ToString();
                txtEmergencyRelationship.Text = reader[3].ToString();
                reader.Close();

                TenantRoom = cmbRoom.Text;
                TenantStatus = cmbStatus.Text;

                tbcUpdateTenant.SelectedTab = tbpTenantInfo;
                tbcUpdateTenant.Enabled = true;
                grpButtons.Enabled = true;
                grpSearch.Enabled = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Tenants_UPDATE_Load(this, EventArgs.Empty);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool hasEmpty = false, tenantExists = false;
            string newTenantName = "";

            //CHECK REQUIRED FIELDS
            hasEmpty = Interface.CheckForEmptyField(
                new Control[]
                {
                    txtFirstName,
                    txtLastName,
                    txtPhone,
                    txtEmergencyPerson,
                    txtEmergencyPhone,
                    txtEmergencyRelationship,
                    cmbRentType,
                    cmbInternetPlan,
                    cmbRoom,
                    cmbStatus});
            if (hasEmpty)
            {
                MessageBox.Show("Missing field.\nPlease make sure to fill all required fields and dropdowns.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            newTenantName = txtLastName.Text + ", " + txtFirstName.Text;

            //IF TENANT NAME IS CHANGED, CHECK FOR DUPLICATE TENANT NAME
            if (newTenantName != TenantName)
            {
                cmd.CommandText = Generate.SelectAllCommand(
                    Database.Tables.tbTenants.tbTenants.ToString(),
                    Database.Tables.tbTenants.FullName.ToString() + "='" + newTenantName + "'");
                reader = cmd.ExecuteReader();
                tenantExists = reader.HasRows;
                reader.Close();

                if (tenantExists)
                {
                    MessageBox.Show("Tenant already exists.\nUnable to change tenant's name.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //CHECK ROOM AVAILABILITY IF ROOM # HAS CHANGED.
            //UPDATE ROOM AVAILABILITIES IF NECESSARY
            //IF ROOM IS THE SAME & TENANCY STATUS CHANGED, UPDATE ROOM AVAILABILITY
            if(cmbRoom.Text != TenantRoom) //If Room has changed
            {
                if(cmbStatus.Text == Metadata.Tenants.TenancyStatus.Active) //If Tenancy Status is ACTIVE
                {
                    string selectedRoomStatus = "";

                    //Retrieve Selected Room Status
                    Exec.CommandString = Construct.SelectCommand(
                        Select: tbrooms.Status.ToString(),
                        From: tbrooms.tbrooms.ToString(),
                        Where: tbrooms.RoomName.ToString() + "='" + cmbRoom.Text + "'");
                    Exec.ExecuteSelect();
                    selectedRoomStatus = Exec.GetValues[0];

                    //Check if Occupied
                    if(selectedRoomStatus == Metadata.Rooms.Status.Vacant) //If Selected Room is Vacant: TRANSFER ROOMS
                    {
                        //Set Selected Room's Status to: OCCUPIED.
                        Exec.CommandString = Construct.UpdateCommand(
                            Update: tbrooms.tbrooms.ToString(),
                            UpdateMetadata: new UpdateColumnMetadata(
                                UpdateColumn: tbrooms.Status.ToString(),
                                WithDataType: MySQLDataType.VarChar,
                                SetValueTo: Metadata.Rooms.Status.Occupied),
                            Where: tbrooms.RoomName.ToString() + "='" + cmbRoom.Text + "'");
                        Exec.ExecuteNonQuery();

                        //Update Previous Room's Status to: VACANT:
                        Exec.CommandString = Construct.UpdateCommand(
                            Update: tbrooms.tbrooms.ToString(),
                            UpdateMetadata: new UpdateColumnMetadata(
                                UpdateColumn: tbrooms.Status.ToString(),
                                WithDataType: MySQLDataType.VarChar,
                                SetValueTo: Metadata.Rooms.Status.Vacant),
                            Where: tbrooms.RoomName.ToString() + "='" + TenantRoom + "'");
                        Exec.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Selected room occupied. Unable to transfer.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else //If Tenancy Status is INACTIVE
                {
                    if(cmbStatus.Text != TenantStatus && 
                        cmbStatus.Text == Metadata.Tenants.TenancyStatus.Inactive) //Tenancy changed from ACTIVE to INACTIVE
                    {
                        Exec.CommandString = Construct.UpdateCommand(
                            Update: tbrooms.tbrooms.ToString(),
                            UpdateMetadata: new UpdateColumnMetadata(
                                UpdateColumn: tbrooms.Status.ToString(),
                                WithDataType: MySQLDataType.VarChar,
                                SetValueTo: Metadata.Rooms.Status.Vacant),
                            Where: tbrooms.RoomName.ToString() + "='" + TenantRoom + "'");
                        Exec.ExecuteNonQuery();
                    }
                }
            }
            else //Selected Room did not change.
            {
                if(cmbStatus.Text != TenantStatus &&
                    cmbStatus.Text == Metadata.Tenants.TenancyStatus.Inactive) //Status changed from ACTIVE to INACTIVE
                {
                    Exec.CommandString = Construct.UpdateCommand(
                        Update: tbrooms.tbrooms.ToString(),
                        UpdateMetadata: new UpdateColumnMetadata(
                            UpdateColumn: tbrooms.Status.ToString(),
                            WithDataType: MySQLDataType.VarChar,
                            SetValueTo: Metadata.Rooms.Status.Vacant),
                        Where: tbrooms.RoomName.ToString() + "='" + TenantRoom + "'");
                    Exec.ExecuteNonQuery();
                }
            }

                //UPDATE TENANT INFORMATION
                string updateQuery = Generate.UpdateCommand(
                        Database.Tables.tbTenants.tbTenants.ToString(),
                        new Generate.UpdateInfo[]
                        {
                    new Generate.UpdateInfo(
                        Database.Tables.tbTenants.FirstName.ToString(),
                        txtFirstName.Text,
                        Generate.DataTypes.String),
                    new Generate.UpdateInfo(
                        Database.Tables.tbTenants.LastName.ToString(),
                        txtLastName.Text,
                        Generate.DataTypes.String),
                    new Generate.UpdateInfo(
                        Database.Tables.tbTenants.FullName.ToString(),
                        newTenantName,
                        Generate.DataTypes.String),
                    new Generate.UpdateInfo(
                        Database.Tables.tbTenants.DateOfBirth.ToString(),
                        dtpDateOfBirth.Value.ToString("yyyy-MM-dd"),
                        Generate.DataTypes.DateTime),
                    new Generate.UpdateInfo(
                        Database.Tables.tbTenants.Phone.ToString(),
                        txtPhone.Text,
                        Generate.DataTypes.String),
                    new Generate.UpdateInfo(
                        Database.Tables.tbTenants.Address.ToString(),
                        txtAddress.Text,
                        Generate.DataTypes.String),
                    new Generate.UpdateInfo(
                        Database.Tables.tbTenants.RentType.ToString(),
                        cmbRentType.Text,
                        Generate.DataTypes.String),
                    new Generate.UpdateInfo(
                        Database.Tables.tbTenants.Room.ToString(),
                        cmbRoom.Text,
                        Generate.DataTypes.String),
                    new Generate.UpdateInfo(
                        Database.Tables.tbTenants.StartDate.ToString(),
                        dtpStartDate.Value.ToString("yyyy-MM-dd"),
                        Generate.DataTypes.DateTime),
                    new Generate.UpdateInfo(
                        Database.Tables.tbTenants.InternetPlan.ToString(),
                        cmbInternetPlan.Text,
                        Generate.DataTypes.String),
                    new Generate.UpdateInfo(
                        Database.Tables.tbTenants.Status.ToString(),
                        cmbStatus.Text,
                        Generate.DataTypes.String) },
                        Database.Tables.tbTenants.TenantID.ToString() + "=" + TenantID.ToString());
            using (MySqlTransaction txn = Database.Connection.BeginTransaction())
            {
                cmd.Transaction = txn;

                try
                {
                    cmd.CommandText = updateQuery;
                    cmd.ExecuteNonQuery();

                    txn.Commit();
                }
                catch
                {
                    txn.Rollback();
                    MessageBox.Show("Update failed.\nChanges not saved.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //UPDATE EMERGENCY INFORMATION
            updateQuery = Generate.UpdateCommand(
                Database.Tables.tbEmergency.tbEmergency.ToString(),
                new Generate.UpdateInfo[]
                {
                    new Generate.UpdateInfo(
                        Database.Tables.tbEmergency.ContactPerson.ToString(),
                        txtEmergencyPerson.Text,
                        Generate.DataTypes.String),
                    new Generate.UpdateInfo(
                        Database.Tables.tbEmergency.Phone.ToString(),
                        txtPhone.Text,
                        Generate.DataTypes.String),
                    new Generate.UpdateInfo(
                        Database.Tables.tbEmergency.Address.ToString(),
                        Utilities.FillEmptyField(txtAddress.Text),
                        Generate.DataTypes.String),
                    new Generate.UpdateInfo(
                        Database.Tables.tbEmergency.Relationship.ToString(),
                        txtEmergencyRelationship.Text,
                        Generate.DataTypes.String) },
                Database.Tables.tbEmergency.TenantID.ToString() + "=" + TenantID.ToString());
            using (MySqlTransaction txn = Database.Connection.BeginTransaction())
            {
                cmd.Transaction = txn;

                try
                {
                    cmd.CommandText = updateQuery;
                    cmd.ExecuteNonQuery();
                    txn.Commit();
                }
                catch
                {
                    txn.Rollback();
                    MessageBox.Show("Update failed.\nChanges not saved.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show("Update successful.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Tenants_UPDATE_Load(this, EventArgs.Empty);
        }

        private void cmbRentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbRentType.Text == Metadata.Tenants.RentType.Fixed)
            {
                dtpEndDate.Value = DateTime.Now.AddDays(-1);
                dtpEndDate.Enabled = true;
            }
            else
            {
                dtpEndDate.Value = Convert.ToDateTime("2000-01-01");
                dtpEndDate.Enabled = false;
            }
        }
    }
}
