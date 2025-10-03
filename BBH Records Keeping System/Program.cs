using System.IO;
using System.Text;
using BBHRKS.MySQL;
using JunX.NET8.MySQL;
using MySql.Data.MySqlClient;

namespace BBH_Records_Keeping_System
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<string> columns = new List<string>();
            string Enums = "";

            MySqlConnection conn = new MySqlConnection("server=localhost; user=root; sslmode=none");
            conn.Open();

            List<string> TableList = Database.Tables.TableList(conn);

            foreach(string tables in Database.Tables.TableList(conn))
            {
                columns.Clear();
                columns = MySQLTables.GetColumns(conn, "dbBBHRKS", tables);
                Enums = MySQLTables.GenerateEnumFromList(columns, tables);
                CreateColumnEnums(Enums, tables);
            }
            conn.Close();
            conn.Dispose();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Dashboard());
        }

        static void CreateColumnEnums(string Code, string EnumName)
        {
            string outputPath = Path.Combine(Application.StartupPath, "TableEnums", EnumName + ".cs");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            File.WriteAllText(outputPath, Code);
        }
    }
}