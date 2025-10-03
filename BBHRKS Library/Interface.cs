using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BBHRKS.Interface
{
    public static class Interface
    {
        public const string MSGBOX_BBHRKS = "BBH Records Keeping System";

        /// <summary>
        /// Checks whether any <see cref="Control"/> in the specified array contains an empty <c>Text</c> value.
        /// </summary>
        /// <param name="TextBoxes">An array of <see cref="Control"/> objects to inspect.</param>
        /// <returns>
        /// <c>true</c> if at least one control has an empty <c>Text</c> property; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method iterates through the provided controls and returns early upon detecting an empty field.
        /// Useful in BBHRKS modules for validating required inputs across mixed control types such as <c>TextBox</c>, <c>MaskedTextBox</c>, or <c>RichTextBox</c>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="TextBoxes"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="NullReferenceException">
        /// Thrown if any element in the <paramref name="TextBoxes"/> array is <c>null</c>.
        /// </exception>
        public static bool CheckForEmptyField(Control[] TextBoxes)
        {
            bool a = false;

            for(int b=0; b<TextBoxes.Length; b++)
            {
                if (TextBoxes[b].Text == "")
                {
                    a = true;
                    break;
                }
            }

            return a;
        }
        /// <summary>
        /// Clears the text content of each <see cref="Label"/> control in the specified array, if the array is not null.
        /// </summary>
        /// <param name="Labels">An array of <see cref="Label"/> controls whose <c>Text</c> properties will be reset.</param>
        /// <remarks>
        /// This method checks whether the <paramref name="Labels"/> array is non-null before iterating.
        /// Each label's <c>Text</c> property is set to an empty string, effectively clearing its display.
        /// Commonly used to reset form fields or UI indicators in BBHRKS modules.
        /// </remarks>
        /// <exception cref="NullReferenceException">
        /// Thrown if any element within the <paramref name="Labels"/> array is <c>null</c>.
        /// </exception>
        public static void ClearLabels(Label[] Labels)
        {
            if (Labels != null)
            {
                foreach (Label l in Labels)
                    l.Text = "";
            }
        }
        /// <summary>
        /// Clears the text content of each <see cref="Control"/> in the specified array.
        /// </summary>
        /// <param name="controls">An array of <see cref="Control"/> objects whose <c>Text</c> properties will be reset.</param>
        /// <remarks>
        /// This method iterates through the provided controls and sets each control's <c>Text</c> property to an empty string.
        /// Commonly used to reset form fields or UI elements in BBHRKS modules.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the <paramref name="controls"/> array is <c>null</c>.
        /// </exception>
        /// <exception cref="NullReferenceException">
        /// Thrown if any element in the <paramref name="controls"/> array is <c>null</c>.
        /// </exception>
        public static void ClearControlText(Control[] controls)
        {
            foreach (Control c in controls)
                c.Text = "";
        }
        /// <summary>
        /// Clears the text of each control in the specified list.
        /// </summary>
        /// <param name="Controls">A list of <see cref="Control"/> objects whose <c>Text</c> property will be set to an empty string.</param>
        /// <remarks>
        /// This method is useful for resetting form fields such as labels, textboxes, or other controls with textual content.
        /// </remarks>
        public static void ClearControlText(List<Control> Controls)
        {
            foreach (Control c in Controls)
                c.Text = "";
        }
        /// <summary>
        /// Clears all items from each <see cref="ComboBox"/> in the specified array.
        /// </summary>
        /// <param name="ComboBoxes">An array of <see cref="ComboBox"/> controls to be emptied.</param>
        /// <remarks>
        /// This method iterates through the provided combo boxes and removes all entries from each control.
        /// Commonly used in BBHRKS modules to reset dropdowns before repopulating them with updated data.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="ComboBoxes"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="NullReferenceException">
        /// Thrown if any element in the <paramref name="ComboBoxes"/> array is <c>null</c>.
        /// </exception>
        public static void ClearComboBoxesItems(ComboBox[] ComboBoxes)
        {
            foreach (ComboBox c in ComboBoxes)
                c.Items.Clear();
        }
        /// <summary>
        /// Executes a SQL SELECT command and binds the resulting data to a <see cref="DataGridView"/> control.
        /// </summary>
        /// <param name="DGVInterface">The <see cref="DataGridView"/> control to populate with query results.</param>
        /// <param name="SQLSelectCommand">The SQL SELECT command string to execute.</param>
        /// <param name="Connection">An open <see cref="MySqlConnection"/> used to perform the query.</param>
        /// <remarks>
        /// This method initializes a <see cref="MySqlDataAdapter"/> with the provided SQL command and connection,
        /// fills a <see cref="DataSet"/> with the results, and binds the first table to the <paramref name="DGVInterface"/>.
        /// The control's <c>DataSource</c> is reset before binding to ensure clean refresh.
        /// </remarks>
        /// <exception cref="MySqlException">
        /// Thrown if the SQL command fails to execute or the connection is invalid.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the <paramref name="Connection"/> is closed or improperly configured.
        /// </exception>
        public static void FillDataGridView(DataGridView DGVInterface, string SQLSelectCommand, MySqlConnection Connection)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            DGVInterface.DataSource = null;
            adapter.SelectCommand = new MySqlCommand(SQLSelectCommand, Connection);
            adapter.Fill(ds);
            DGVInterface.DataSource = ds.Tables[0];
        }
        /// <summary>
        /// Populates the specified <see cref="ComboBox"/> with a list of string items.
        /// </summary>
        /// <param name="comboBox">The <see cref="ComboBox"/> control to be filled.</param>
        /// <param name="Items">A list of string values to add to the combo box.</param>
        /// <remarks>
        /// Clears any existing entries before adding the provided items.
        /// Commonly used in BBHRKS modules to refresh dropdown options based on dynamic data or user context.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="comboBox"/> or <paramref name="Items"/> is <c>null</c>.
        /// </exception>
        public static void FillComboBox(ComboBox comboBox, List<string> Items)
        {
            comboBox.Items.Clear();

            foreach (string item in Items)
                comboBox.Items.Add(item);
        }
        /// <summary>
        /// Populates the specified <see cref="ComboBox"/> with a list of string items.
        /// </summary>
        /// <param name="comboBox">The <see cref="ComboBox"/> control to be filled.</param>
        /// <param name="Items">A list of string values to add to the combo box.</param>
        /// <remarks>
        /// This method clears any existing entries before adding the provided items.
        /// Commonly used in BBHRKS modules to refresh dropdown options based on dynamic data or user context.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="comboBox"/> or <paramref name="Items"/> is <c>null</c>.
        /// </exception>
        public static void FillComboBox(ComboBox comboBox, string[] Items)
        {
            comboBox.Items.Clear();

            for(int a=0; a<Items.Length; a++)
                comboBox.Items.Add(Items[a]);
        }
        /// <summary>
        /// Recursively retrieves all child controls contained within the specified parent control.
        /// </summary>
        /// <param name="Parent">The root <see cref="Control"/> from which to begin the search.</param>
        /// <returns>
        /// A <see cref="List{Control}"/> containing all descendant controls, including those nested within containers.
        /// </returns>
        /// <remarks>
        /// This method is useful for scenarios where controls are nested inside panels, group boxes, or other containers,
        /// and you need to perform operations like filtering, resetting, or styling across the entire form hierarchy.
        /// </remarks>
        public static List<Control> GetAllControls(Control Parent)
        {
            var controls = new List<Control>();

            foreach(Control c in Parent.Controls)
            {
                controls.Add(c);
                controls.AddRange(GetAllControls(c));
            }

            return controls;
        }
        /// <summary>
        /// Sets the enabled state of each <see cref="Control"/> in the specified array.
        /// </summary>
        /// <param name="controls">An array of <see cref="Control"/> objects whose <c>Enabled</c> properties will be updated.</param>
        /// <param name="enabled">A boolean value indicating whether the controls should be enabled or disabled.</param>
        /// <remarks>
        /// This method iterates through the provided controls and applies the specified enabled state.
        /// Commonly used to toggle form interactivity in BBHRKS modules, such as locking fields during processing or enabling inputs after validation.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the <paramref name="controls"/> array is <c>null</c>.
        /// </exception>
        /// <exception cref="NullReferenceException">
        /// Thrown if any element in the <paramref name="controls"/> array is <c>null</c>.
        /// </exception>
        public static void SetControlEnabled(Control[] controls, bool enabled)
        {
            foreach (Control c in controls)
                c.Enabled = enabled;
        }
    }
}
