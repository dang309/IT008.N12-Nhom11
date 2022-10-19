using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood
{
    class Tools
    {
        public static MySqlCommand Connect(ref MySqlConnection cn)
        {
            cn = new MySqlConnection(
                "SERVER=localhost;" +
                "DATABASE=fastfoodmanagement;" +
                "UID=root;" +
                "PASSWORD=TerMiNaTor_309;");

            cn.Open();

            return cn.CreateCommand();
        }
    }
}
