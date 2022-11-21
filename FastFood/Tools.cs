using ClosedXML.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace FastFood
{
    class Tools
    {
        private readonly static string connectionStr = "SERVER=localhost;" +
                "DATABASE=fastfoodmanagement;" +
                "UID=root;" +
                "PASSWORD=TerMiNaTor_309;";
        private static MySqlConnection con;
        public static MySqlCommand Connect(string queryStr)
        {
            con = new MySqlConnection(connectionStr);
            MySqlCommand cmd = new MySqlCommand(queryStr, con);
            con.Open();

            return cmd;
        }

        public static void DisConnect()
        {
            con.Close();
        }

        public static void ExportToExcel(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }

            File.WriteAllText(@"D:\test.csv", sb.ToString());
        }
    }
}
