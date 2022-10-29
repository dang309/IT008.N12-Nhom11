using FastFood.Forms;
using FastFood.Objects;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace FastFood
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public MainWindow()
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ResizeMode = ResizeMode.NoResize;
            WindowStyle = WindowStyle.None;

            Loaded += (sender, args) =>
            {
                var hwnd = new WindowInteropHelper(this).Handle;
                SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
            };
        }

        private void Hover_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Close_img.Source = new BitmapImage(new Uri("image/loginUI/btn-close--hover.png", UriKind.Relative));
        }

        private void Close_btn_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Close_img.Source = new BitmapImage(new Uri("image/loginUI/btn-close.png", UriKind.Relative));
        }

        private void Forgot_btn_Click(object sender, RoutedEventArgs e)
        {
            new Forgot_form().Show();
        }

        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {
            string user_name = User_name_editTxt.Text;
            string password = Password_editTxt.Text;

            MySqlConnection cn = null;
            MySqlCommand cm = Tools.Connect(ref cn);

            cm.Parameters.Add("_name", MySqlDbType.VarChar).Value = user_name;
            cm.Parameters.Add("_pass", MySqlDbType.VarChar).Value = password;
            cm.CommandText = "Select * from taikhoan Where TenDangNhap=@_name AND MatKhau=@_pass;";

            MySqlDataReader reader = cm.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);
            reader.Close();

            if(table.Rows.Count == 0)
            {
                MessageBox.Show("Wrong user name or password! Please try again!", "Invalid login", MessageBoxButton.OK);
            }
            else
            {
                DataRow dr = table.Rows[0];

                int emp_code = Convert.ToInt32(dr[0]);

                dr = table.Rows[0];

                Logged_in_form form = new Logged_in_form();

                form.Prepare(emp_code, cm);
                form.Show();
                Close();
            }

            cn.Close();
        }

        private void Close_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
