using FastFood.Edit_discount_table;
using FastFood.Objects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using static FastFood.Edit_discount_table.Edit_discount_fragment;

namespace FastFood.Control_panels.Discount_window
{
    /// <summary>
    /// Interaction logic for Discount_control.xaml
    /// </summary>
    public partial class Discount_control : UserControl
    {
        private ObservableCollection<A_discount> discounts;
        private List<A_discount> buffer;
        private DispatcherTimer animate_timer;
        private Edit_discount_fragment fragment;

        private int last_clicked_index = -1, First_visible_index = 0, Last_visible_index;
        private double move_direction, opac_direction;

        public Discount_control()
        {
            InitializeComponent();

            Fetch_data();

            Next_btn.AddOnClickListener(() =>
            {
                if (Last_visible_index + 1 == buffer.Count)
                    return; // do nothing on end!

                discounts.RemoveAt(0);

                First_visible_index++;
                Last_visible_index++;

                discounts.Add(buffer[Last_visible_index]);
            });

            Back_btn.AddOnClickListener(() =>
            {
                if (First_visible_index == 0)
                    return; // do nothing on end!

                if(discounts.Count == 3)
                {
                    discounts.RemoveAt(2);
                    Last_visible_index--;
                }

                First_visible_index--;

                discounts.Insert(0, buffer[First_visible_index]);
            });

            animate_timer = new DispatcherTimer();
            animate_timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            animate_timer.Tick += (sender, args) =>
            {
                fragment.Opacity += opac_direction;
                fragment.Margin = new Thickness(0, fragment.Margin.Top - move_direction, 0, 0);

                if (Math.Abs(fragment.Opacity - 1.0) < 0.0001 || Math.Abs(fragment.Opacity) < 0.0001)
                {
                    animate_timer.Stop();

                    if(Math.Abs(fragment.Opacity) < 0.0001)
                    {
                        Container.Children.Remove(fragment);
                    }
                }
            };
        }

        private void Fetch_data()
        {
            discounts = new ObservableCollection<A_discount>();
            buffer = new List<A_discount>();

            MySqlConnection cn = null;

            MySqlCommand cm = Tools.Connect(ref cn);

            cm.CommandText = "Select * from giamgia;";

            MySqlDataReader reader = cm.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);
            reader.Close();
            cn.Close();

            foreach (DataRow dr in table.Rows)
            {
                A_discount discount = new A_discount()
                {
                    Code = Convert.ToInt32(dr[0]),
                    Name = (string)dr[1],
                    Percent = Convert.ToInt32(dr[2]),
                    Constraint = Convert.ToInt32(dr[3]),
                    Begin_date = (DateTime)dr[4],
                    End_date = (DateTime)dr[5],
                };

                buffer.Add(discount);
            }

            for(int i=0;i<Math.Min(3, buffer.Count);i++)
                discounts.Add(buffer[i]);

            Discount_list.ItemsSource = discounts;
            Last_visible_index = Math.Min(2, buffer.Count - 1);
        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            Remove_item(First_visible_index + Discount_list.SelectedIndex);
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection cn = null;

            MySqlCommand cm = Tools.Connect(ref cn);
            cm.CommandText = "Select max(MaGiam) from giamgia;";
            MySqlDataReader reader = cm.ExecuteReader();
            reader.Read();
            int new_code = reader.GetInt32(0) + 1;
            reader.Close();
            cn.Close();

            A_discount discount = new A_discount()
            {
                Code = new_code,
                Begin_date = DateTime.Now,
                End_date = DateTime.Now
            };

            // Open for
            Open_fragment(discount, (discount) =>
            {
                MySqlConnection cn = null;

                MySqlCommand cm = Tools.Connect(ref cn);
                cm.Parameters.Add("_Code", MySqlDbType.Int32).Value = discount.Code;
                cm.Parameters.Add("_Name", MySqlDbType.VarChar).Value = discount.Name;
                cm.Parameters.Add("_Percent", MySqlDbType.Int32).Value = discount.Percent;
                cm.Parameters.Add("_Constraint", MySqlDbType.Int32).Value = discount.Constraint;
                cm.Parameters.Add("_Begin", MySqlDbType.DateTime).Value = discount.Begin_date;
                cm.Parameters.Add("_End", MySqlDbType.DateTime).Value = discount.End_date;

                cm.CommandText = "INSERT INTO giamgia VALUES(@_Code, @_Name," +
                    "@_Percent, @_Constraint, @_Begin, @_End);";

                cm.ExecuteNonQuery();

                cn.Close();

                buffer.Add(discount);

                int last_index = buffer.Count - 1;

                if (last_index >= First_visible_index && last_index <= First_visible_index + 2)
                    discounts.Add(buffer[last_index]);
            });
        }

        private void Delete_all_btn_Click(object sender, RoutedEventArgs e)
        {
            for(int i=buffer.Count - 1;i>=0;i--)
            {
                if (buffer[i].Out_of_date)
                    Remove_item(i);
            }

            // Now delte all from database
            MySqlConnection cn = null;

            MySqlCommand cm = Tools.Connect(ref cn);
            cm.CommandText = "Delete from giamgia Where NgayKT < CURDATE();";
            cm.ExecuteNonQuery();
            cn.Close();
        }

        private void Edit_btn_Click(object sender, RoutedEventArgs e)
        {
            Open_fragment((A_discount)Discount_list.SelectedItem, (discount) =>
            {
                MySqlConnection cn = null;

                MySqlCommand cm = Tools.Connect(ref cn);
                cm.Parameters.Add("_Code", MySqlDbType.Int32).Value = discount.Code;
                cm.Parameters.Add("_Name", MySqlDbType.VarChar).Value = discount.Name;
                cm.Parameters.Add("_Percent", MySqlDbType.Int32).Value = discount.Percent;
                cm.Parameters.Add("_Constraint", MySqlDbType.Int32).Value = discount.Constraint;
                cm.Parameters.Add("_Begin", MySqlDbType.DateTime).Value = discount.Begin_date;
                cm.Parameters.Add("_End", MySqlDbType.DateTime).Value = discount.End_date;

                cm.CommandText = "Update giamgia Set TenGiamGia=@_Name," +
                    "PhanTramGiam=@_Percent, DieuKien=@_Constraint, NgayBD=@_Begin, NgayKt=@_End Where MaGiam = @_Code;";

                cm.ExecuteNonQuery();

                cn.Close();
            });
        }

        private void Discount_list_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (last_clicked_index >= 0 && last_clicked_index < buffer.Count)
                buffer[last_clicked_index].ItemClicked = false;

            last_clicked_index = Discount_list.SelectedIndex + First_visible_index;
            buffer[last_clicked_index].ItemClicked = true;

            discounts[Discount_list.SelectedIndex].ItemClicked = true; // Sync data with display UI
        }

        private void AutoScroll_disabler(object sender, RequestBringIntoViewEventArgs e)
        {
            e.Handled = true;
        }

        private void Remove_item(int index)
        {
            A_discount discount = buffer[index];

            int code = discount.Code;
            buffer.RemoveAt(index);

            if(index >= First_visible_index && index <= First_visible_index + 2)
                discounts.RemoveAt(index - First_visible_index);

            if (Last_visible_index < buffer.Count)
                discounts.Add(buffer[Last_visible_index]);
            else
                Last_visible_index--;

            MySqlConnection cn = null;

            MySqlCommand cm = Tools.Connect(ref cn);

            cm.Parameters.Add("_Code", MySqlDbType.Int32).Value = code;
            cm.CommandText = "Delete from giamgia Where MaGiam = @_Code;";

            cm.ExecuteNonQuery();

            cn.Close();
        }

        private void Open_fragment(A_discount discount, OnCloseFragment listener)
        {
            fragment = new Edit_discount_fragment().Add_discount_info(discount);

            fragment.VerticalAlignment = VerticalAlignment.Center;
            fragment.HorizontalAlignment = HorizontalAlignment.Center;
            fragment.Margin = new Thickness(0, 200, 0, 0);
            fragment.Width = 400;
            fragment.Height = 210;
            fragment.Opacity = 0;

            Container.Children.Add(fragment);
            fragment.AddCloseListener(() =>
            {
                opac_direction = -0.1;
                move_direction = -20;
                animate_timer.Start();
            });
            fragment.AddOnCloseListener(listener);

            opac_direction = 0.1;
            move_direction = 20;
            animate_timer.Start();
        }
    }
}
