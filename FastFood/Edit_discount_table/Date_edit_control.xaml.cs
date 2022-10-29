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

namespace FastFood.Edit_discount_table
{
    /// <summary>
    /// Interaction logic for Date_edit_control.xaml
    /// </summary>
    public partial class Date_edit_control : UserControl
    {
        public DateTime begin_date
        {
            get { return (DateTime)Begin_picker.SelectedDate; }
        }

        public DateTime end_date
        {
            get { return (DateTime)End_picker.SelectedDate; }
        }

        public Date_edit_control()
        {
            InitializeComponent();
        }

        public Date_edit_control Add_time_line(DateTime Begin_date, DateTime End_date)
        {
            Begin_picker.SelectedDate = Begin_date;
            End_picker.SelectedDate = End_date;

            return this;
        }
    }
}
