using FastFood.Objects;
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

namespace FastFood
{
    /// <summary>
    /// Interaction logic for Sell_control.xaml
    /// </summary>
    public partial class Sell_control : UserControl
    {
        public Sell_control()
        {
            InitializeComponent();
        }

        public Sell_control Prepare(List<A_product> products)
        {
            Product_list.ItemsSource = products;
            Number_txt.Text = "NaN";

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
            Number_txt.Text = "1";
        }
    }
}
