using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
            MySqlConnection cn = null;
            MySqlCommand cm = Tools.Connect(ref cn);

            cm.Parameters.Add("_name", MySqlDbType.VarChar).Value = User_name_editTxt.Text;
            cm.CommandText = "Select * from taikhoan Where TenDangNhap = @_name;";

            MySqlDataReader reader = cm.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            reader.Close();

            if (table.Rows.Count == 1)
            {
                cm.Parameters.Add("_pass", MySqlDbType.VarChar).Value = Password_editTxt.Text;
                cm.CommandText = "Update taikhoan Set MatKhau = @_pass Where TenDangNhap = @_name;";
                cm.ExecuteNonQuery();
                Close();
            }
            else
                MessageBox.Show("We can't find your user name! Please try again!", "Invalid user name", MessageBoxButton.OK);

            cn.Close();
        }
    }
}
