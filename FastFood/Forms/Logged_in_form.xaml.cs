using FastFood.Control_panels;
using FastFood.Control_panels.Discount_window;
using FastFood.Objects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace FastFood.Forms
{
    /// <summary>
    /// Interaction logic for Logged_in_form.xaml
    /// </summary>
    public partial class Logged_in_form : Window
    {
        private Border Last_tab;
        public An_emp MyEmp { get; set; }
        public Logged_in_form()
        {
            InitializeComponent();

            Last_tab = Sell_window;
            Sell_window.Background = Brushes.BlueViolet;
        }

        public void Prepare(int emp_code, MySqlCommand cm)
        {
            cm.Parameters.Add("_code", MySqlDbType.Int32).Value = emp_code;

            cm.CommandText = "Select * from nhanvien Where MaNV = @_code;";
            MySqlDataReader reader = cm.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            DataRow dr = table.Rows[0];

            MyEmp = new An_emp()
            {
                Code = emp_code,
                Name = (string)dr[1] + (string)dr[2],
                Is_male = (string)dr[3] == "Nam",
                Is_admin = (string)dr[4] == "Admin"
            };

            Fragment_container.Children.Add(new Sell_control().Prepare(MyEmp.Code));
        }

        private void Sell_window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Toggle((Border)sender);

            if(!(Fragment_container.Children[0] is Sell_control))
            {
                Fragment_container.Children.RemoveAt(0);
                Fragment_container.Children.Add(new Sell_control().Prepare(MyEmp.Code));
            }
        }

        private void Discount_window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Toggle((Border)sender);

            if (!(Fragment_container.Children[0] is Discount_control))
            {
                Fragment_container.Children.RemoveAt(0);
                Fragment_container.Children.Add(new Discount_control());
            }
        }

        private void Toggle(Border border)
        {
            Last_tab.Background = Brushes.Transparent;

            border.Background = Brushes.BlueViolet;
            Last_tab = border;
        }

        private void Product_window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Toggle((Border)sender);

            if (!(Fragment_container.Children[0] is Product_control))
            {
                Fragment_container.Children.RemoveAt(0);
                Fragment_container.Children.Add(new Product_control());
            }
        }

        private void Emp_window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Toggle((Border)sender);

            if (!(Fragment_container.Children[0] is Employee_control))
            {
                Fragment_container.Children.RemoveAt(0);
                Fragment_container.Children.Add(new Employee_control());
            }
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
