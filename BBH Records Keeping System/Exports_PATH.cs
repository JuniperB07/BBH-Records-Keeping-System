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
using JunX.NET8.WinForms;
using BBHRKS.MySQL;
using BBHRKS.Interface;

namespace BBH_Records_Keeping_System
{
    public partial class Exports_PATH : Form
    {
        DBConnect DBC;

        public Exports_PATH()
        {
            InitializeComponent();
        }

        #region PRIVATE FUNCTIONS
        private void GetPath()
        {
            DBC.CommandString = Construct.SelectCommand(
                Select: tbmetadata.Value.ToString(),
                From: tbmetadata.tbmetadata.ToString(),
                Where: tbmetadata.MID.ToString() + "=9");
            DBC.ExecuteReader();
            DBC.GetValues();
            rtxtPath.Text = DBC.Values[0];
        }
        #endregion

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(rtxtPath.Text))
            {
                MessageBox.Show("Invalid path.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DBC.CommandString = Construct.UpdateCommand(
                Update: tbmetadata.tbmetadata.ToString(),
                UpdateMetadata: new UpdateColumnMetadata(
                    UpdateColumn: tbmetadata.Value.ToString(),
                    WithDataType: MySQLDataType.Text,
                    SetValueTo: rtxtPath.Text.Replace("\\", "\\\\")),
                Where: tbmetadata.MID.ToString() + "=9");
            DBC.ExecuteNonQuery();

            MessageBox.Show("Export Path Changed.", Interface.MSGBOX_BBHRKS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Exports_PATH_Load(this, EventArgs.Empty);
        }

        private void Exports_PATH_Load(object sender, EventArgs e)
        {
            DBC = new DBConnect(Database.Connection);

            Forms.ClearControlText(Forms.ControlType<RichTextBox>.Extract(this, "rtxt"));
            
            GetPath();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            fbdSelectFolder.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (fbdSelectFolder.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbdSelectFolder.SelectedPath))
            {
                rtxtNewPath.Text = fbdSelectFolder.SelectedPath;
            }
        }
    }
}
