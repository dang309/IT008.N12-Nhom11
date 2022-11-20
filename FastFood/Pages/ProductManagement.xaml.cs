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
    /// Interaction logic for ProductManagement.xaml
    /// </summary>
    public partial class ProductManagement : Page
    {
        public ProductManagement()
        {
            InitializeComponent();

            getProducts();
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
                string filename = dlg.FileName;
            }
        }
    }
}
