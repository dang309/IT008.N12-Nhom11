using FastFood.Objects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FastFood.Edit_discount_table
{
    /// <summary>
    /// Interaction logic for Edit_discount_fragment.xaml
    /// </summary>
    public partial class Edit_discount_fragment : UserControl
    {
        private Button last_btn;
        private int NORMAL_DISPLAY = 0;
        private int DATE_DISPLAY = 1;

        public const int SAVING = 0;
        public const int EXIT_WITHOUT_SAVING = 1;

        public delegate void CloseListener();
        public delegate void OnCloseFragment(A_discount discount);
        private CloseListener Close;
        private OnCloseFragment OnClose;

        private A_discount discount;
        public Edit_discount_fragment()
        {
            InitializeComponent();

            last_btn = Name_btn;
        }

        public Edit_discount_fragment Add_discount_info(A_discount discount)
        {
            this.discount = discount;

            Change_panel.Children.Add(new Normal_edit_control().Add_content_and_hint
                ("Tên mã giảm giá", "Nhập tên mã", discount.Name));
            return this;
        }

        public void AddCloseListener(CloseListener listener)
        {
            this.Close = listener;
        }

        public void AddOnCloseListener(OnCloseFragment onClose)
        {
            this.OnClose = onClose;
        }

        private void OnTabChangeListener(object sender, RoutedEventArgs e)
        {
            Save_info(last_btn);

            if(sender != last_btn)
            {
                last_btn.Background = Brushes.Transparent;
                last_btn.Foreground = new SolidColorBrush(Colors.Black);
                last_btn.FontSize = 12;
                last_btn.Margin = new Thickness(0, 0, 0, 0);
            }

            last_btn = (Button)sender;

            last_btn.Background = Brushes.DeepSkyBlue;
            last_btn.Foreground = new SolidColorBrush(Colors.White);
            last_btn.FontSize = 15;
            last_btn.Margin = new Thickness(5, 0, 0, 0);

            if(last_btn == Date_btn)
            {
                List<object> Params = new List<object>();
                Params.Add(discount.Begin_date);
                Params.Add(discount.End_date);
                Tab_selection(Params, DATE_DISPLAY);
            }
            else
            {
                List<object> Params = new List<object>();

                if(last_btn == Percent_btn)
                {
                    Params.Add("Phầm trăm giảm");
                    Params.Add("Nhập vào phầm trăm(%)");
                    Params.Add(discount.Percent + "");
                }
                else if(last_btn == Constraint_btn)
                {
                    Params.Add("Điều kiện giảm giá");
                    Params.Add("Nhập vào mức tối thiểu");
                    Params.Add(discount.Constraint + "");
                }
                else
                {
                    Params.Add("Tên mã giảm giá");
                    Params.Add("Nhập tên mã");
                    Params.Add(discount.Name + "");
                }

                Tab_selection(Params, NORMAL_DISPLAY);
            }
        }

        private void Tab_selection(List<object> Params, int code)
        {
            if(code == NORMAL_DISPLAY)
            {
                Change_panel.Children.RemoveAt(0);
                Change_panel.Children.Add(new Normal_edit_control().Add_content_and_hint
                ((string)Params[0], (string)Params[1], (string)Params[2]));
            }
            else
            {
                Change_panel.Children.RemoveAt(0);
                Change_panel.Children.Add(new Date_edit_control().Add_time_line(
                    (DateTime)Params[0], (DateTime)Params[1]));
            }
        }

        private void Save_info(Button last_btn)
        {
            if(last_btn == Name_btn)
            {
                Normal_edit_control edit_panel = (Normal_edit_control)Change_panel.Children[0];
                discount.Name = edit_panel.Normal_content;
            }
            else if(last_btn == Percent_btn)
            {
                Normal_edit_control edit_panel = (Normal_edit_control)Change_panel.Children[0];
                discount.Percent = int.Parse(edit_panel.Normal_content);
            }
            else if(last_btn == Constraint_btn)
            {
                Normal_edit_control edit_panel = (Normal_edit_control)Change_panel.Children[0];
                discount.Constraint = int.Parse(edit_panel.Normal_content);
            }
            else
            {
                Date_edit_control date_panel = (Date_edit_control)Change_panel.Children[0];
                discount.Begin_date = date_panel.begin_date;
                discount.End_date = date_panel.end_date;
            }
        }

        private void Confirm_btn_Click(object sender, RoutedEventArgs e)
        {
            Save_info(last_btn);
            Close();
            OnClose(discount);
        }

        private void Close_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
