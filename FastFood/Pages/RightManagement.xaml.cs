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
using System.Collections.ObjectModel;

using MySql.Data.MySqlClient;

using FastFood.DTOs;

namespace FastFood.Pages
{
    /// <summary>
    /// Interaction logic for RightManagement.xaml
    /// </summary>
    public partial class RightManagement : Page
    {
        public RightManagement()
        {
            InitializeComponent();

            getRights();

        }

        public void getRights()
        {
            string queryStr = "SELECT * FROM phanquyen;";
            MySqlCommand cm = Tools.Connect(queryStr);


            MySqlDataReader reader = cm.ExecuteReader();

            List<Right> rights = new List<Right>();


            while (reader.Read())
            {
                string Quyen = reader.GetString("Quyen");
                bool QLNhapHang = reader.GetString("NhapHang") == "1" ? true : false;
                bool QLNhanVien = reader.GetString("QLNhanVien") == "1" ? true : false;
                bool QLSanPham = reader.GetString("QLSanPham") == "1" ? true : false;
                bool QLKhachHang = reader.GetString("QLKhachHang") == "1" ? true : false;
                bool ThongKe = reader.GetString("ThongKe") == "1" ? true : false;
                rights.Add(new Right() { Quyen = Quyen, NhapHang = QLNhapHang, QLKhachHang = QLKhachHang, QLSanPham = QLSanPham, QLNhanVien = QLNhanVien, ThongKe = ThongKe });
            }

            tbRights.ItemsSource = rights;
        }

        private void tbRights_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Quyen")
            {
                e.Column.IsReadOnly = true;
            }
        }


    }
}
