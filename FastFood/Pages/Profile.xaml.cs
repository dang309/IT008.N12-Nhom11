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

using FastFood.Forms;

namespace FastFood.Pages
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {

        public Profile(int currentEmpId)
        {
            InitializeComponent();

            getInfoEmp(currentEmpId);

        }

        private void btnChangePass_Click(object sender, RoutedEventArgs e)
        {
            new ChangePassword().Show();
        }

        private void getInfoEmp(int currentEmpId)
        {
            string queryStr = "SELECT * FROM nhanvien WHERE MaNV=@empID;";

            MySqlCommand cm = Tools.Connect(queryStr);

            cm.Parameters.Add("empID", MySqlDbType.VarChar).Value = currentEmpId;

            MySqlDataReader reader = cm.ExecuteReader();

            while (reader.Read())
            {
                int maNV = reader.GetInt32("MaNV");
                string ho = reader.GetString("Ho");
                string ten = reader.GetString("Ten");
                string gioiTinh = reader.GetString("GioiTinh");
                string chucVu = reader.GetString("ChucVu");


                this.txtMaNV.Text = maNV.ToString();
                this.txtHoDem.Text = ho;
                this.txtTen.Text = ten;
                this.txtGioiTinh.Text = gioiTinh;
                this.txtChucVu.Text = chucVu;
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            var allWindows = Application.Current.Windows;
            foreach (var window in allWindows)
            {
                Window win = window as Window;
                string name = win.Name;
                if (name == "dashboardWin")
                {
                    new MainWindow().Show();
                    win.Close();
                    return;
                }
            }

        }
    }
}
