using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Data;

using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using FastFood.DTOs;
using System.Windows.Threading;

namespace FastFood.Pages
{
    /// <summary>
    /// Interaction logic for ProductManagement.xaml
    /// </summary>
    public partial class ProductManagement : Page
    {
        private ObservableCollection<Product> products;
        private string fileName, lastSearch = "";
        private int selectedIndex = -1;
        public ProductManagement()
        {
            InitializeComponent();
            getProducts("");

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            timer.Tick += (o, e) =>
            {
                if(lastSearch != txtSearch.Text)
                {
                    lastSearch = txtSearch.Text;
                    getProducts(lastSearch);
                }
            };

            timer.Start();
        }

        public void getProducts(string searchTerm)
        {
            products = new ObservableCollection<Product>();

            string queryStr = "Select * from sanpham Where TenSP LIKE CONCAT('%', @searchTerm, '%')";
            MySqlCommand cm = Tools.Connect(queryStr);
            cm.Parameters.Add("searchTerm", MySqlDbType.VarChar).Value = searchTerm;
            MySqlDataReader reader = cm.ExecuteReader();

            while(reader.Read())
            {
                Product product = new Product()
                {
                    MaSP = reader.GetString("MaSP"),
                    TenSP = reader.GetString("TenSP"),
                    SoLuong = reader.GetInt32("SoLuong"),
                    MaLoai = reader.GetInt32("MaLoai"),
                    DonViTinh = reader.GetString("DonViTinh"),
                    HinhAnh = reader.GetString("HinhAnh")
                };
                products.Add(product);
            }

            Tools.DisConnect();

            this.tbProducts.ItemsSource = products;
        }

        private void btnPickImgProduct_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document
                fileName = dlg.FileName;
                imgProduct.Source = new BitmapImage(new Uri(fileName));
            }
        }

        private void btnAdding_Click(object sender, RoutedEventArgs e)
        {
            if (txtTenSP.Text == "" || txtMaSP.Text == "" || txtLoai.Text == "" || txtSoLuong.Text == "" || 
                txtDonViTinh.Text == "" || txtDonGia.Text == "" || fileName == null)
            {
                MessageBox.Show("San pham loi!");
                return;
            }

            Product product = new Product()
            {
                MaSP = txtMaSP.Text,
                TenSP = txtTenSP.Text,
                MaLoai = Int32.Parse(txtLoai.Text),
                SoLuong = Int32.Parse(txtSoLuong.Text),
                DonViTinh = txtDonViTinh.Text,
                DonGia = Int32.Parse(txtDonGia.Text),
                HinhAnh = fileName
            };

            products.Add(product);

            MySqlCommand cm = Tools.Connect("INSERT INTO sanpham VALUES(@_code, @_name, @_type, @_number, @_type_str, " +
                "@_img, @_price);");

            cm.Parameters.Add("@_code", MySqlDbType.Int32).Value = product.MaSP;
            cm.Parameters.Add("@_name", MySqlDbType.VarChar).Value = product.TenSP;
            cm.Parameters.Add("@_type", MySqlDbType.Int32).Value = product.MaLoai;
            cm.Parameters.Add("@_number", MySqlDbType.Int32).Value = product.SoLuong;
            cm.Parameters.Add("@_type_str", MySqlDbType.VarChar).Value = product.DonViTinh;
            cm.Parameters.Add("@_price", MySqlDbType.Int32).Value = product.DonGia;
            cm.Parameters.Add("@_img", MySqlDbType.VarChar).Value = product.HinhAnh;

            cm.ExecuteNonQuery();
            Tools.DisConnect();
        }

        private DataTable getTable()
        {
            string queryStr = "Select * from sanpham Where TenSP LIKE CONCAT('%', @searchTerm, '%')";
            MySqlCommand cm = Tools.Connect(queryStr);
            cm.Parameters.Add("searchTerm", MySqlDbType.VarChar).Value = lastSearch;
            MySqlDataReader reader = cm.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            Tools.DisConnect();
            return table;
        }

        private void tbProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedIndex = tbProducts.SelectedIndex;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Tools.ExportToExcel(getTable());
            MessageBox.Show("Kiem tra tai duong dan: D:\test.csv");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            products.RemoveAt(selectedIndex);
            selectedIndex = -1;
        }


    }
}
