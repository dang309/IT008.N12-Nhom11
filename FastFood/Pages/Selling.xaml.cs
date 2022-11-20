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

using FastFood.DTOs;
using FastFood.Forms;

namespace FastFood.Pages
{
    /// <summary>
    /// Interaction logic for Selling.xaml
    /// </summary>
    public partial class Selling : Page
    {
        public int currentEmpId { get; set; }
        private List<Product> productsInCart { get; set; }
        public Selling()
        {
            InitializeComponent();

            getProducts();
            setupTableProductsInCart();

            this.productsInCart = new List<Product>();

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
                int maNV = reader.GetInt32("MaNV");

                string ho = reader.GetString("Ho");
                string ten = reader.GetString("Ten");
                result = ho + " " + ten;

                MessageBox.Show(maNV.ToString());

            }
            return result;
        }

        public void addToCart(Product p)
        {
            this.productsInCart.Add(p);
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
            DataGridTextColumn col1 = new DataGridTextColumn();
            DataGridTextColumn col2 = new DataGridTextColumn();
            DataGridTextColumn col3 = new DataGridTextColumn();
            DataGridTextColumn col4 = new DataGridTextColumn();
            DataGridTextColumn col5 = new DataGridTextColumn();

            tbProductsInCart.Columns.Add(col1);
            tbProductsInCart.Columns.Add(col2);
            tbProductsInCart.Columns.Add(col3);
            tbProductsInCart.Columns.Add(col4);
            tbProductsInCart.Columns.Add(col5);

            col1.Binding = new Binding("MaSP");
            col2.Binding = new Binding("TenSP");
            col3.Binding = new Binding("DonGia");
            col4.Binding = new Binding("DatHang") { Mode = BindingMode.TwoWay };
            col5.Binding = new Binding("ThanhTien") { Mode = BindingMode.TwoWay };

            col1.Header = "Mã sản phẩm";
            col2.Header = "Tên sản phẩm";
            col3.Header = "Đơn giá";
            col4.Header = "Số lượng";
            col5.Header = "Thành tiền";

            tbProductsInCart.CanUserDeleteRows = true;
        }

        private void btn_addToCart_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < productsInCart.Count; i++)
            {
                if (productsInCart[i].MaSP == this.txtMaSP.Text)
                {
                    productsInCart[i].DatHang += Int32.Parse(this.txtSoLuong.Text);
                    productsInCart[i].ThanhTien = productsInCart[i].SoLuong * productsInCart[i].DonGia;
                    return;
                }
            }
            this.productsInCart.Add(new Product() { MaSP = this.txtMaSP.Text, DatHang = Int32.Parse(this.txtSoLuong.Text) });

            tbProductsInCart.Items.Add(new Product()
            {
                MaSP = this.txtMaSP.Text,
                TenSP = this.txtTenSP.Text,
                DonGia = Int32.Parse(this.txtDonGia.Text),
                DatHang = Int32.Parse(this.txtSoLuong.Text),
                ThanhTien = Int32.Parse(this.txtDonGia.Text) * Int32.Parse(this.txtSoLuong.Text)
            });
        }


    }
}
