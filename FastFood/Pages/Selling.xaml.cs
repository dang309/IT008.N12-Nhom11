using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;

using MySql.Data.MySqlClient;

using FastFood.DTOs;
using System.Collections.ObjectModel;

namespace FastFood.Pages
{
    /// <summary>
    /// Interaction logic for Selling.xaml
    /// </summary>
    public partial class Selling : Page
    {
        public int currentEmpId { get; set; }
        private ObservableCollection<Product> productsInCart { get; set; }
        private string lastDonViTinh;
        public Selling()
        {
            InitializeComponent();

            this.productsInCart = new ObservableCollection<Product>();

            getProducts();
            setupTableProductsInCart();
        }

        public void getProducts()
        {
            string queryStr = "SELECT * FROM sanpham;";
            MySqlCommand cm = Tools.Connect(queryStr);


            MySqlDataReader reader = cm.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            da.Fill(dataTable);
            this.tbProducts.ItemsSource = dataTable.DefaultView;
            this.tbProductsInCart.ItemsSource = productsInCart;
        }

        public string getInfoEmp()
        {
            string result = "";
            string queryStr = "SELECT MaNV, Ho, Ten FROM nhanvien WHERE MaNV=@empID;";

            MySqlCommand cm = Tools.Connect(queryStr);

            cm.Parameters.Add("empID", MySqlDbType.VarChar).Value = currentEmpId;

            MySqlDataReader reader = cm.ExecuteReader();

            while (reader.Read())
            {
                string ho = reader.GetString("Ho");
                string ten = reader.GetString("Ten");
                result = ho + " " + ten;

            }
            return result;
        }

        private void tbProducts_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "MaLoai")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "HinhAnh")
            {
                e.Cancel = true;
            }
        }

        private void getProductDetail(string selectedProductId)
        {

            string queryStr = "SELECT * FROM sanpham WHERE MaSP=@maSP";
            MySqlCommand cm = Tools.Connect(queryStr);

            cm.Parameters.Add("maSP", MySqlDbType.Int32).Value = Int32.Parse(selectedProductId);

            MySqlDataReader reader = cm.ExecuteReader();

            string empInfo = getInfoEmp();
            this.txtNhanVien.Text = empInfo;

            while (reader.Read())
            {
                this.txtMaSP.Text = reader.GetInt32("MaSP").ToString();
                this.txtTenSP.Text = reader.GetString("TenSP");
                this.txtDonGia.Text = reader.GetString("DonGia");
                this.txtSoLuong.Text = "1";
                lastDonViTinh = reader.GetString("DonViTinh");
                // string stringPath = "/image/SanPham/" + reader.GetString("HinhAnh");
                // Uri imageUri = new Uri(stringPath, UriKind.Relative);
                // BitmapImage imageBitmap = new BitmapImage(imageUri);
                // this.imgProduct.Source = imageBitmap;
            }
        }

        private void tbProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            string maSP = ((TextBlock)RowColumn.Content).Text;

            getProductDetail(maSP);
        }

        private void setupTableProductsInCart()
        {
            tbProductsInCart.CanUserDeleteRows = true;
        }

        private void btn_addToCart_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < productsInCart.Count; i++)
            {
                if (productsInCart[i].MaSP == this.txtMaSP.Text)
                {
                    productsInCart[i].SoLuong += Int32.Parse(this.txtSoLuong.Text);
                    return;
                }
            }

            Product product = new Product()
            {
                MaSP = txtMaSP.Text,
                TenSP = txtTenSP.Text,
                DonViTinh = lastDonViTinh,
                DonGia = Int32.Parse(this.txtDonGia.Text),
                SoLuong = Int32.Parse(this.txtSoLuong.Text),
                ThanhTien = Int32.Parse(this.txtDonGia.Text) * Int32.Parse(this.txtSoLuong.Text)
            };

            productsInCart.Add(product);
        }


    }
}
