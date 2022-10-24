using FastFood.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    }
}
