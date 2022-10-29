using FastFood.Objects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace FastFood.Control_panels
{
    /// <summary>
    /// Interaction logic for Drawer.xaml
    /// </summary>
    public partial class Drawer : UserControl
    {
        private const int MAX_PROGRESS = 120;
        private const int BILL_REQUESTING = 0;
        private const int NO_BILL_YET = 1;
        private const int DRAWER_OPEN_FOR_VIEW = 0;
        private const int DRAWER_OPEN_FOR_SAVING= 1;

        private DispatcherTimer animate_timer, scaling_animate_timer, fade_animate_timer;
        private int speed = 0, current_progress = 0, direction = 0, bill_state, drawer_state, emp_Code;
        private bool Scaled_small, Completed = false;
        private ObservableCollection<A_cart_item> items;

        public string total_price
        {
            get
            {
                if (Bought_list == null)
                    return "0 VND";

                long total = 0;

                items = (ObservableCollection<A_cart_item>)Bought_list.ItemsSource;
                foreach (var item in items)
                    total += item.price * item.item_number;

                return total.ToString("#,###", A_product.cul.NumberFormat) + " VND";
            }
        }

        public string Confirm_total_str
        {
            get
            {
                return "Số lượng: " + GetCurrentCartSize();
            }
        }

        public Drawer()
        {
            InitializeComponent();

            Animate_controls();
            bill_state = NO_BILL_YET;
            drawer_state = DRAWER_OPEN_FOR_VIEW;
        }

        public void Prepare(ObservableCollection<A_cart_item> Selected_list, int Emp_code)
        {
            Bought_list.ItemsSource = Selected_list;
            this.emp_Code = Emp_code;
        }

        public void Open()
        {
            if (current_progress == MAX_PROGRESS)
                return;

            animate_timer.Stop();

            speed = 10;
            direction = 4;

            animate_timer.Start();
        }

        private void Close()
        {
            if (current_progress == 0)
                return;

            animate_timer.Stop();
            speed = -10;
            direction = -4;

            animate_timer.Start();
        }

        private void Close_btn_Click(object sender, RoutedEventArgs e)
        {
            if(drawer_state == DRAWER_OPEN_FOR_VIEW)
                Close();
            else
            {
                A_customer customer = Bill_creator.GetSelectedCustomer();

                if (customer == null)
                    MessageBox.Show("You have not selected any customer!", "Invalid command", MessageBoxButton.OK);
                else
                {
                    long total = 0;

                    ObservableCollection<A_cart_item> items = (ObservableCollection<A_cart_item>)Bought_list.ItemsSource;
                    foreach (var item in items)
                        total += item.price * item.item_number;

                    MySqlConnection cn = null;
                    MySqlCommand cm = Tools.Connect(ref cn);

                    cm.CommandText = "Select max(MaHD) from hoadon;";

                    MySqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    int max = reader.GetInt32(0) + 1;
                    reader.Close();

                    cm.Parameters.Add("_Code", MySqlDbType.Int32).Value = max;
                    cm.Parameters.Add("Cus_code", MySqlDbType.Int32).Value = customer.Code;
                    cm.Parameters.Add("Emp_code", MySqlDbType.Int32).Value = emp_Code;
                    cm.Parameters.Add("_Today", MySqlDbType.DateTime).Value = DateTime.Today;
                    cm.Parameters.Add("total", MySqlDbType.Int32).Value = total;
                    cm.Parameters.Add("_note", MySqlDbType.VarChar).Value = "Đã thanh toán";

                    cm.CommandText = "INSERT INTO hoadon VALUES(@_Code, @Cus_code, @Emp_Code, @_Today, @total, @_note);";

                    cm.ExecuteNonQuery();

                    cn.Close();

                    Completed = true;
                    Confirm_btn_Click(null, null); // press confirm programtically
                }
            }
        }

        private void Confirm_btn_Click(object sender, RoutedEventArgs e)
        {
            Scaled_small = false;

            bill_state = 1 - bill_state;
            drawer_state = 1 - drawer_state;

            if (bill_state == BILL_REQUESTING)
            {
                // static set-up
                Close_save_img.Source = new BitmapImage(new Uri("../image/save_2.png", UriKind.Relative));
                Confirm_cancel_img.Source = new BitmapImage(new Uri("../image/cancel.png", UriKind.Relative));
                Bill_creator.Visibility = Visibility.Visible;
            }
            else
            {
                // static set-up
                Close_save_img.Source = new BitmapImage(new Uri("../image/next.png", UriKind.Relative));
                Confirm_cancel_img.Source = new BitmapImage(new Uri("../image/confirm.png", UriKind.Relative));
            }

            // animation
            scaling_animate_timer.Start();
            fade_animate_timer.Start();

            new Thread(new ThreadStart(() =>
            {
                while (scaling_animate_timer.IsEnabled || fade_animate_timer.IsEnabled) ; // wait for animation to stop

                if (Completed)
                    Dispatcher.Invoke(() =>
                    {
                        items.Clear();
                        Confirm_number_txt.Content = "1";
                        Total_price_txt.Content = "0 VND";
                        Close();
                    });
            })).Start();
        }

        private int GetCurrentCartSize()
        {
            if (Bought_list == null)
                return 0;
            else
                return ((ObservableCollection<A_cart_item>)Bought_list.ItemsSource).Count;
        }

        public void UpdateData()
        {
            Total_price_txt.Content = total_price;
            Confirm_number_txt.Content = Confirm_total_str;
        }

        private void Animate_controls()
        {
            // For drawer open up and close down
            animate_timer = new DispatcherTimer();
            animate_timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            animate_timer.Tick += (sender, args) =>
            {
                Drawer_wrapper.Width += speed;
                current_progress += direction;

                if (current_progress == MAX_PROGRESS || current_progress == 0)
                    animate_timer.Stop();
            };

            // For save button
            scaling_animate_timer = new DispatcherTimer();
            scaling_animate_timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            scaling_animate_timer.Tick += (sender, args) =>
            {
                if (Close_save_img.Width > 10 && !Scaled_small)
                {
                    Close_save_img.Width--;
                    Close_save_img.Height--;
                }
                else
                {
                    Scaled_small = true;
                    Close_save_img.Width++;
                    Close_save_img.Height++;
                }

                if (Close_save_img.Width == 20)
                    scaling_animate_timer.Stop();
            };

            // For bill creator appearance
            fade_animate_timer = new DispatcherTimer();
            fade_animate_timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            fade_animate_timer.Tick += (sender, args) =>
            {
                if (bill_state == BILL_REQUESTING)
                    Bill_creator.Opacity += 0.1;
                else
                    Bill_creator.Opacity -= 0.1;

                if (Math.Abs(Bill_creator.Opacity - 1.0) < 0.0001 || Math.Abs(Bill_creator.Opacity) < 0.0001)
                {
                    fade_animate_timer.Stop();

                    if (Math.Abs(Bill_creator.Opacity) < 0.0001)
                        Bill_creator.Visibility = Visibility.Collapsed;
                }
            };
        }
    }
}
