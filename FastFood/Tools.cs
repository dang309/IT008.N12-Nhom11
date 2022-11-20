using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood
{
    class Tools
    {
        private readonly static string connectionStr = "SERVER=localhost;" +
                "DATABASE=fastfoodmanagement;" +
                "UID=root;" +
                "PASSWORD=192837;";
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
    }
}
