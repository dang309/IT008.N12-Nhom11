using FastFood.Objects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FastFood.Control_panels
{
    /// <summary>
    /// Interaction logic for Employee_profile_control.xaml
    /// </summary>
    public partial class Employee_profile_control : UserControl
    {
        private An_emp emp;
        public delegate void OnBackListener();

        private OnBackListener listener;
        public Employee_profile_control()
        {
            InitializeComponent();
        }

        public Employee_profile_control Prepare(An_emp emp)
        {
            this.emp = emp;

            if (!emp.Is_male)
                Gender_img.Source = new BitmapImage(new Uri("../image/female.png", UriKind.Relative));

            Name_txt.Content = emp.Name;
            ChucVu_txt.Content = emp.ChucVu;

            MySqlConnection cn = null;

            MySqlCommand cm = Tools.Connect(ref cn);
            cm.Parameters.Add("_code", MySqlDbType.Int32).Value = emp.Code;

            General_txt.Content = "Tổng thu của nhân viên: " + getTotal(cm) + '\n' + "Xếp hạng: " + getRank(cm);

            Customer_list.ItemsSource = getCustomers(cm);
            Order_list.ItemsSource = getOrders(cm);

            cn.Close();

            return this;
        }

        public Employee_profile_control Add_back_listener(OnBackListener listener)
        {
            this.listener = listener;

            return this;
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            listener();
        }

        private List<A_customer> getCustomers(MySqlCommand cm)
        {
            List<A_customer> customers = new List<A_customer>();

            cm.CommandText = "Select Concat(Ho, \" \", Ten), GioiTinh from khachhang K INNER JOIN " +
                            "(Select distinct MaKH from hoadon Where MaNv = @_Code) T On K.MaKH = T.MaKH;";

            MySqlDataReader reader = cm.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            reader.Close();

            foreach(DataRow dr in table.Rows)
            {
                A_customer cus = new A_customer();
                cus.name = (string)dr[0];
                cus.Is_male = (string)dr[1] == "Nam";

                customers.Add(cus);
            }

            return customers;
        }

        private List<An_order> getOrders(MySqlCommand cm)
        {
            List<An_order> orders = new List<An_order>();

            cm.CommandText = "Select MaHD, Concat(K.Ho, \" \", K.Ten), T.TongTien, T.NgayLap from khachhang K INNER JOIN " +
                    "(Select * from hoadon Where MaNv = @_Code) T On K.MaKH = T.MaKH order by NgayLap;";

            MySqlDataReader reader = cm.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            reader.Close();

            foreach(DataRow dr in table.Rows)
            {
                An_order order = new An_order()
                {
                    Code = Convert.ToInt32(dr[0]),
                    Who_bought = (string)dr[1],
                    Total_price = Convert.ToInt64(dr[2]),
                    Order_Date = (DateTime)dr[3]
                };

                orders.Add(order);
            }

            return orders;
        }

        private long getTotal(MySqlCommand cm)
        {
            cm.CommandText = "Select Sum(TongTien) from HoaDon Where MaNv = @_code;";

            MySqlDataReader reader = cm.ExecuteReader();
            reader.Read();

            int ans;
            if (reader.IsDBNull(0))
                ans = 0;
            else
                ans = reader.GetInt32(0);

            reader.Close();

            return ans;
        }

        private int getRank(MySqlCommand cm)
        {
            cm.CommandText = "Select _rank from (" +
                    "Select row_number()  over(order by Tong desc, MaNv) as _rank, Manv from(" +
                    "Select Sum(TongTien) as Tong, MaNv from HoaDon group by MaNv) T) T1 Where Manv = @_code;";

            MySqlDataReader reader = cm.ExecuteReader();

            int ans;

            DataTable table = new DataTable();
            table.Load(reader);
            if (table.Rows.Count == 0)
            {
                reader.Close();
                cm.CommandText = "Select COUNT(DISTINCT MaNv) from HoaDon;";
                reader = cm.ExecuteReader();
                reader.Read();
                ans = reader.GetInt32(0) + 1;
            }
            else
                ans = Convert.ToInt32(table.Rows[0][0]);

            reader.Close();
            return ans;
        }
    }
}
