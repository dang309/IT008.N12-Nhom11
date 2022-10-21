using FastFood.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;

namespace FastFood
{
    /// <summary>
    /// Interaction logic for Sell_control.xaml
    /// </summary>
    public partial class Sell_control : UserControl
    {
        private ObservableCollection<A_cart_item> items;
        private int Emp_code;
        private DispatcherTimer animate_timer;
        private int left_cnt = 0;

        public Sell_control()
        {
            InitializeComponent();

            items = new ObservableCollection<A_cart_item>();
            Cart_drawer.Prepare(items, Emp_code);

            animate_timer = new DispatcherTimer();
            animate_timer.Interval = new TimeSpan(0, 0, 0, 0, 5);

            animate_timer.Tick += (sender, args) =>
            {
                if (Animate_img.Width == 0)
                {
                    animate_timer.Stop();
                    return;
                }

                Animate_img.Width -= 10;
                Animate_img.Height -= 10;
            };
        }

        public Sell_control Prepare(List<A_product> products, int Emp_code)
        {
            Product_list.ItemsSource = products;
            Number_txt.Text = "NaN";
            this.Emp_code = Emp_code;
            
            return this;
        }

        private void Inc_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num = Int32.Parse(Number_txt.Text);

                Number_txt.Text = num + 1 + "";
            }
            catch(FormatException exception)
            {
                MessageBox.Show("Please choose some order", "Invalid selection", MessageBoxButton.OK);
            }
        }

        private void Dec_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num = Int32.Parse(Number_txt.Text);

                if (num == 1)
                    return;

                Number_txt.Text = num - 1 + "";
            }
            catch (FormatException exception)
            {
                MessageBox.Show("Please choose some order", "Invalid selection", MessageBoxButton.OK);
            }
        }

        private void Product_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            A_product product = (A_product)Product_list.SelectedItem;

            Selected_product_img.Source = new BitmapImage(new Uri(product.Product_img_str, UriKind.Relative));
            Animate_img.Source = new BitmapImage(new Uri(product.Product_img_str, UriKind.Relative));

            Number_txt.Text = "1";
        }

        private void Cart_btn_Click(object sender, RoutedEventArgs e)
        {
            left_cnt = 0;
            Noti_txt.Visibility = Visibility.Collapsed;
            Cart_drawer.Open();
        }

        private void Confirm_btn_Click(object sender, RoutedEventArgs e)
        {
            Animate_img.Width = 200;
            Animate_img.Height = 200;
            animate_timer.Start();

            A_product product = (A_product)Product_list.SelectedItem;
            int number = int.Parse(Number_txt.Text);

            Number_txt.Text = "1";

            bool found = false;
            foreach(var item in items)
            {
                if(item.item_name == product.Name)
                {
                    found = true;
                    item.item_number += number;
                }
            }

            if (!found)
            {
                items.Add(new A_cart_item()
                {
                    ImgPath = product.Product_img_str,
                    item_number = number,
                    item_name = product.Name,
                    price = product.Price
                });
            }

            Cart_drawer.UpdateData();

            left_cnt++;

            if (left_cnt == 1)
                Noti_txt.Visibility = Visibility.Visible;

            Noti_txt.Content = left_cnt + "";
        }
    }
}
