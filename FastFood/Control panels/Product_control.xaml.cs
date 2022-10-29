using FastFood.Objects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FastFood.Control_panels
{
    /// <summary>
    /// Interaction logic for Product_control.xaml
    /// </summary>
    public partial class Product_control : UserControl
    {
        private int last_code = 1;
        private ObservableCollection<object> all_products;
        private ObservableCollection<An_import> waiting_products;

        private bool Is_loading = false;

        private An_import import;
        public Product_control()
        {
            InitializeComponent();

            all_products = new ObservableCollection<object>();
            all_products.Add(new A_loading());
            waiting_products = new ObservableCollection<An_import>();

            All_list.ItemsSource = all_products;
            New_product_list.ItemsSource = waiting_products;

            MySqlConnection cn = null;
            MySqlCommand cm = Tools.Connect(ref cn);

            foreach (var product in getWaitingProduct(cm))
                waiting_products.Add(product);
            Load_more_products(cm);
            Top_list.ItemsSource = getTopProducts(cm);

            All_list.Loaded += (sender, e) =>
            {
                var scrollViewer = GetDescendantByType(All_list, typeof(ScrollViewer)) as ScrollViewer;

                if (scrollViewer != null)
                {
                    ScrollBar scrollBar = scrollViewer.Template.FindName("PART_HorizontalScrollBar", scrollViewer) as ScrollBar;
                    if (scrollBar != null)
                    {
                        scrollBar.ValueChanged += delegate
                        {
                            Debug.WriteLine(scrollViewer.HorizontalOffset);
                            Debug.WriteLine(Is_loading);
                            if(scrollViewer.HorizontalOffset + scrollViewer.ViewportWidth >= all_products.Count - 1
                                    && !Is_loading) // including loading item
                            {
                                Debug.WriteLine("Loading...");
                                Is_loading = true;

                                DispatcherTimer wait_timer = new DispatcherTimer();
                                wait_timer.Interval = new TimeSpan(0, 0, 0, 0, 300);

                                wait_timer.Tick += (sender, args) =>
                                {
                                    MySqlConnection cn = null;
                                    Load_more_products(Tools.Connect(ref cn));

                                    Is_loading = false;
                                    cn.Close();
                                    wait_timer.Stop();
                                };

                                wait_timer.Start();
                            }
                        };
                    }
                }
            };

            cn.Close();

            MessageBox.Show("Ấn vào từng hàng đang đợi nhập để nhập hàng.\n Tất cả sản phẩm có sử dụng pagination.");
        }
        private static Visual GetDescendantByType(Visual element, Type type)
        {
            if (element == null)
            {
                return null;
            }
            if (element.GetType() == type)
            {
                return element;
            }
            Visual foundElement = null;
            if (element is FrameworkElement)
            {
                (element as FrameworkElement).ApplyTemplate();
            }
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                Visual visual = VisualTreeHelper.GetChild(element, i) as Visual;
                foundElement = GetDescendantByType(visual, type);
                if (foundElement != null)
                {
                    break;
                }
            }
            return foundElement;
        }

        private List<An_import> getWaitingProduct(MySqlCommand cm)
        {
            List<An_import> imports = new List<An_import>();

            cm.CommandText = "Select MaSp, NgayNhap, TongTien, Concat(Ho, \" \", Ten) from hangdoinhap h " +
                "INNER JOIN nhanvien n ON h.MaNv = n.MaNv;";

            MySqlDataReader reader = cm.ExecuteReader();
            DataTable table = new DataTable();

            table.Load(reader);
            reader.Close();

            foreach (DataRow dr in table.Rows)
                imports.Add(new An_import(dr));

            return imports;
        }

        private List<A_product> getTopProducts(MySqlCommand cm)
        {
            cm.CommandText = "Select *  from sanpham group by(NhapVao - SoLuong) order by (NhapVao - SoLuong) desc LIMIT 15;";

            return Query_product_list(cm);
        }

        private void Load_more_products(MySqlCommand cm)
        {
            all_products.RemoveAt(all_products.Count - 1);
            cm.Parameters.Add("_last", MySqlDbType.Int32).Value = last_code;
            cm.CommandText = "Select * from sanpham Where MaSp >= @_last order by MaSp LIMIT 10;";

            MySqlDataReader reader = cm.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);
            reader.Close();

            foreach (DataRow dr in table.Rows)
            {
                A_product product = new A_product(dr);
                all_products.Add(product);
            }


            last_code += table.Rows.Count;
            all_products.Add(new A_loading());
        }

        private List<A_product> Query_product_list(MySqlCommand cm)
        {
            List<A_product> products = new List<A_product>();

            MySqlDataReader reader = cm.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);
            reader.Close();

            foreach (DataRow dr in table.Rows)
            {
                A_product product = new A_product(dr);
                products.Add(product);
            }

            return products;
        }

        private void OnImportNewProduct(object sender, RoutedEventArgs args)
        {
            Container.Children.Add(new New_product_confirm_form().Prepare(
                import,
                () => Container.Children.RemoveAt(1),
                (Img_path) =>
                {
                    MessageBox.Show("File ảnh đã lưu vào " + Img_path, "Note");
                    waiting_products.Remove(import);
                    import = null;
                }));
        }

        private void New_product_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (import != null)
                import.Show_import_btn = false;

            import = (An_import)New_product_list.SelectedItem;
            if(import != null)
                import.Show_import_btn = true;
        }
    }
}
