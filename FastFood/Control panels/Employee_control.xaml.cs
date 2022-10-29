using FastFood.Objects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace FastFood.Control_panels
{
    /// <summary>
    /// Interaction logic for Employee_control.xaml
    /// </summary>
    public partial class Employee_control : UserControl
    {
        private static CultureInfo culture = new CultureInfo("vi-VN");

        private string last_text = "";
        private double direction, width_direction;

        private ObservableCollection<An_emp> emps;
        private DispatcherTimer search_watcher, animate_timer;

        private An_emp selected_emp;

        public Employee_control()
        {
            InitializeComponent();

            emps = new ObservableCollection<An_emp>();
            Fill_all();

            Control_container.Children.Add(new Card_pager().Prepare(emps).AddOnEmployeeClick((emp)
                =>
            {
                direction = 0.1;
                width_direction = 16;
                animate_timer.Start();

                selected_emp = emp;
            }));

            Init_search_tracker();

            animate_timer = new DispatcherTimer();
            animate_timer.Interval = new TimeSpan(0, 0, 0, 0, 10);

            animate_timer.Tick += (sender, args) =>
            {
                Control_container.Opacity -= direction;

                if(direction > 0)
                    Search_area.Width -= width_direction;

                if (Math.Abs(Control_container.Opacity) < 0.00001)
                {
                    Control_container.Children.RemoveAt(0);

                    if(width_direction > 0)
                    {
                        FileStream fs = File.Open(@"D:\History.txt", FileMode.Open);

                        fs.Write(Encoding.UTF8.GetBytes(selected_emp.Name + Environment.NewLine));
                        fs.Close();

                        Control_container.Children.Add(new Employee_profile_control()
                            .Prepare(selected_emp)
                            .Add_back_listener(() =>
                            {
                                direction = 0.1;
                                width_direction = -16;

                                emps = new ObservableCollection<An_emp>();
                                Fill_all();
                                animate_timer.Start();
                            }));
                    }
                    else
                    {
                        Control_container.Children.Add(new Card_pager().Prepare(emps).AddOnEmployeeClick((emp) =>
                        {
                            direction = 0.1;
                            width_direction = 16;
                            animate_timer.Start();

                            selected_emp = emp;
                        }));
                    }

                    direction = -0.1;
                }
                else if (Math.Abs(Control_container.Opacity - 1.0) < 0.00001)
                    animate_timer.Stop();
            };

            MessageBox.Show("Nhấn đúp vào card nhân viên(màu vàng) để xem lược sử. \nTìm kiếm có kèm gợi ý. \n" +
                "Lia chuột đến góc trái/phải nhất để xem thêm card nhân viên.", "HDSD");
        }

        private List<A_search> Search_in_history(string search_term)
        {
            List<A_search> hints = new List<A_search>();

            if (!File.Exists(@"D:\History.txt"))
                File.Create(@"D:\History.txt").Close();

            foreach (var line in File.ReadLines(@"D:\History.txt"))
            {
                if (culture.CompareInfo.IndexOf(line, search_term, CompareOptions.IgnoreCase) >= 0)
                {
                    DataTable table = Find_similar(search_term);
                    DataRow dr = table.Rows[0];

                    An_emp emp = new An_emp()
                    {
                        Code = Convert.ToInt32(dr[0]),
                        Name = (string)dr[1] + " " + (string)dr[2],
                        Is_male = (string)dr[3] == "Name",
                        ChucVu = (string)dr[4]
                    };

                    hints.Add(new A_search()
                    {
                        Search_Content = line,
                        type = A_search.HISTORY,
                        Associated_emp = emp
                    });
                }
            }

            return hints;
        }

        private void Fill_all()
        {
            MySqlConnection cn = null;

            MySqlCommand cm = Tools.Connect(ref cn);

            cm.CommandText = "Select * from nhanvien;";

            MySqlDataReader reader = cm.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            reader.Close();
            cn.Close();

            foreach (DataRow dr in table.Rows)
            {
                An_emp emp = new An_emp()
                {
                    Code = Convert.ToInt32(dr[0]),
                    Name = (string)dr[1] + " " + (string)dr[2],
                    Is_male = (string)dr[3] == "Name",
                    ChucVu = (string)dr[4]
                };

                emps.Add(emp);
            }
        }

        private void Search_list_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                direction = 0.1;
                width_direction = 16;
                selected_emp = ((A_search)Search_list.SelectedItem).Associated_emp;
                animate_timer.Start();
            }
        }

        private void Init_search_tracker()
        {
            search_watcher = new DispatcherTimer();
            search_watcher.Interval = new TimeSpan(0, 0, 0, 0, 10);

            search_watcher.Tick += (sender, args) =>
            {
                if (Search_editTxt.Text == last_text)
                    return;

                if (Search_editTxt.Text == "")
                {
                    emps.Clear();
                    Fill_all();

                    Search_list.ItemsSource = new List<A_search>();
                    last_text = Search_editTxt.Text;
                    return;
                }

                string search_term = Search_editTxt.Text;

                emps.Clear();
                List<A_search> hints = Search_in_history(search_term);

                DataTable table = Find_similar(search_term);

                foreach (DataRow dr in table.Rows)
                {
                    string Full_name = (string)dr[1] + " " + (string)dr[2];

                    An_emp emp = new An_emp()
                    {
                        Code = Convert.ToInt32(dr[0]),
                        Name = Full_name,
                        Is_male = (string)dr[3] == "Name",
                        ChucVu = (string)dr[4]
                    };

                    int t = A_search.NAME;
                    string content = Full_name;

                    if (culture.CompareInfo.IndexOf(Full_name, search_term, CompareOptions.IgnoreCase) < 0)
                    {
                        content = Convert.ToInt32(dr[0]) + " - " + content;
                        t = A_search.ID;
                    }

                    hints.Add(new A_search()
                    {
                        Search_Content = content,
                        Associated_emp = emp,
                        type = t
                    });

                    emps.Add(emp);
                }

                Search_list.ItemsSource = hints;

                last_text = Search_editTxt.Text;
            };

            search_watcher.Start();
        }

        private DataTable Find_similar(string search_term)
        {
            MySqlConnection cn = null;
            MySqlCommand cm = Tools.Connect(ref cn);

            cm.Parameters.Add("_Content", MySqlDbType.VarChar).Value = search_term;

            if (int.TryParse(search_term, out _))
                cm.CommandText = "Select *" +
                " from nhanvien Where MaNv = @_Content";
            else
                cm.CommandText = "Select * from nhanvien Where Concat(Ho, \" \", Ten) LIKE Concat('%', @_Content , '%');";

            MySqlDataReader reader = cm.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            reader.Close();
            cn.Close();

            return table;
        }
    }
}
