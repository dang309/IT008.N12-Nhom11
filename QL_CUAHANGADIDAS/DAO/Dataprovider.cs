using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYGIAY.DAO
{
    class DataProvider
    {
        private static DataProvider instance;

        private string connectionSTR = "Data Source=HAIDANG309;Initial Catalog=QL_CUAHANGADIDAS;Integrated Security=True";

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return DataProvider.instance;
            }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        public System.Data.DataTable ExcuteQuery(string query, object[] parameter = null)
        {
            System.Data.DataTable data = new System.Data.DataTable();
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionSTR))
            {
                connection.Open();


                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] lispara = query.Split(' ');
                    int i = 0;
                    foreach (string item in lispara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }



            return data;
        }

        internal int ExecuteNonQuery(string query)
        {
            throw new NotImplementedException();
        }

        internal void ExecuteQuery(string v)
        {
            throw new NotImplementedException();
        }

        public int ExcuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionSTR))
            {
                connection.Open();


                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] lispara = query.Split(' ');
                    int i = 0;
                    foreach (string item in lispara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }



            return data;
        }
        public object ExcuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionSTR))
            {
                connection.Open();


                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] lispara = query.Split(' ');
                    int i = 0;
                    foreach (string item in lispara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
            }



            return data;
        }
    }
}
