using FastFood.Objects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FastFood.Control_panels
{
    /// <summary>
    /// Interaction logic for Bill_creator.xaml
    /// </summary>
    public partial class Bill_creator : UserControl
    {
        private List<A_customer> customers;
        public Bill_creator()
        {
            InitializeComponent();

            MySqlConnection cn = null;
            MySqlCommand cm = Tools.Connect(ref cn);

            cm.CommandText = "Select * from khachhang;";

            DataTable table = new DataTable();
            MySqlDataReader reader = cm.ExecuteReader();
            table.Load(reader);
            reader.Close();
            cn.Close();

            customers = new List<A_customer>();
            foreach(DataRow dr in table.Rows)
            {
                A_customer customer = new A_customer();
                customer.Code = Convert.ToInt32(dr[0]);
                customer.name = (string)dr[1] + " " + (string)dr[2];
                customer.Is_male = (string)dr[3] == "Nam";

                customers.Add(customer);
            }

            Customer_list.ItemsSource = customers;
        }

        public A_customer GetSelectedCustomer()
        {
            return (A_customer)Customer_list.SelectedItem;
        }
    }
}
