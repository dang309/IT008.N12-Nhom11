using FastFood.Objects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FastFood.Forms
{
    /// <summary>
    /// Interaction logic for Logged_in_form.xaml
    /// </summary>
    public partial class Logged_in_form : Window
    {
        private Border Last_window = null;
        private List<A_product> products;
        public Logged_in_form()
        {
            InitializeComponent();

            products = new List<A_product>();

            MySqlConnection cn = null;

            MySqlCommand cm = Tools.Connect(ref cn);

            cm.CommandText = "Select * from sanpham;";

            MySqlDataReader reader = cm.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);
            reader.Close();
            cn.Close();

            foreach(DataRow dr in table.Rows)
            {
                A_product product = new A_product();

                product.Cnt_code = Convert.ToInt32(dr[0]);
                product.Name = Convert.ToString(dr[1]);
                product.Type_code = Convert.ToInt32(dr[2]);
                product.Number = Convert.ToInt32(dr[3]);
                product.Type_str = Convert.ToString(dr[4]);
                product.Product_img_str = Convert.ToString(dr[5]);
                product.Price = Convert.ToInt32(dr[6]);

                products.Add(product);
            }

            Fragment_container.Children.Add(new Sell_control().Prepare(products));
        }

        private void Sell_window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Toggle((Border)sender);
        }

        private void Discount_window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Toggle((Border)sender);
        }

        private void Toggle(Border border)
        {
            if (Last_window != null)
                Last_window.Background = Brushes.Transparent;

            border.Background = Brushes.BlueViolet;
            Last_window = border;
        }

        private void Product_window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Toggle((Border)sender);
        }

        private void Emp_window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Toggle((Border)sender);
        }

        private void Customer_window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Toggle((Border)sender);
        }

        private void Import_window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Toggle((Border)sender);
        }

        private void Stats_window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Toggle((Border)sender);
        }

        private void Change_pass_window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void Out_window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }
    }
}
