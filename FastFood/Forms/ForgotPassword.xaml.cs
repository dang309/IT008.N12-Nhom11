using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;


namespace FastFood.Forms
{
    /// <summary>
    /// Interaction logic for Forgot_form.xaml
    /// </summary>
    public partial class Forgot_form : Window
    {
        public Forgot_form()
        {
            InitializeComponent();
        }

        private void Change_btn_Click(object sender, RoutedEventArgs e)
        {
            string queryStr = "Select * from taikhoan Where TenDangNhap = @_name;";

            MySqlCommand cm = Tools.Connect(queryStr);

            // cm.Parameters.Add("_name", MySqlDbType.VarChar).Value = User_name_editTxt.Text;

            MySqlDataReader reader = cm.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            reader.Close();

            if (table.Rows.Count == 1)
            {
                // cm.Parameters.Add("_pass", MySqlDbType.VarChar).Value = Password_editTxt.Text;
                cm.CommandText = "Update taikhoan Set MatKhau = @_pass Where TenDangNhap = @_name;";
                cm.ExecuteNonQuery();
                Close();
            }
            else
                MessageBox.Show("We can't find your user name! Please try again!", "Invalid user name", MessageBoxButton.OK);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
