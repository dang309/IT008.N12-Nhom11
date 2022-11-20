using System;
using System.Collections.Generic;
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
using System.Data;

using MySql.Data.MySqlClient;

namespace FastFood.Pages
{
    /// <summary>
    /// Interaction logic for DiscountManagement.xaml
    /// </summary>
    public partial class DiscountManagement : Page
    {
        public DiscountManagement()
        {
            InitializeComponent();

            getDiscounts();
        }

        public void getDiscounts()
        {
            string queryStr = "SELECT * FROM giamgia;";
            MySqlCommand cm = Tools.Connect(queryStr);


            MySqlDataReader reader = cm.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            da.Fill(dataTable);
            this.tbDiscounts.ItemsSource = dataTable.DefaultView;
        }


    }
}
