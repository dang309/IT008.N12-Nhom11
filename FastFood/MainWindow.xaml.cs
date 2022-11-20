using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

using MySql.Data.MySqlClient;

using FastFood.Forms;

namespace FastFood
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        ~MainWindow()
        {
            Tools.DisConnect();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = this.txtUsername.Text;
            string password = this.txtPassword.Password;
            string queryStr = "Select * from taikhoan Where TenDangNhap=@username AND MatKhau=@password;";

            MySqlCommand cm = Tools.Connect(queryStr);

            cm.Parameters.Add("username", MySqlDbType.VarChar).Value = username;
            cm.Parameters.Add("password", MySqlDbType.VarChar).Value = password;

            MySqlDataReader reader = cm.ExecuteReader();

            if (!reader.HasRows)
            {
                MessageBox.Show("Vui lòng thử lại hoặc liên hệ 19521315@gm.uit.edu.vn để giải quyết!", "Đăng nhập không hợp lệ!", MessageBoxButton.OK);
                return;
            }

            while (reader.Read())
            {
                int empId = reader.GetInt32("MaNV");
                new Dashboard(empId).Show();
                this.Close();

            }

        }
    }
}
