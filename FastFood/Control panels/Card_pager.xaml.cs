using FastFood.Objects;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace FastFood.Control_panels
{
    /// <summary>
    /// Interaction logic for Card_pager.xaml
    /// </summary>
    public partial class Card_pager : UserControl
    {
        public delegate void OnHideListener(An_emp emp);

        private ObservableCollection<An_emp> emps;
        private int First_visible_index = 0, Last_visible_index = 0;
        private OnHideListener listener;
        public Card_pager()
        {
            InitializeComponent();

            Next_btn.AddOnClickListener(() =>
            {
                int last_index = Last_visible_index;

                Last_visible_index = Math.Min(emps.Count - 1, Last_visible_index + 3);
                Employee_list.ScrollIntoView(emps[Last_visible_index]);

                if (last_index != Last_visible_index)
                    First_visible_index += 3;
            });

            Back_btn.AddOnClickListener(() =>
            {
                int last_index = First_visible_index;

                First_visible_index = Math.Max(0, First_visible_index - 3);
                Employee_list.ScrollIntoView(emps[First_visible_index]);

                if (First_visible_index != last_index)
                    Last_visible_index -= 3;
            });
        }

        public Card_pager Prepare(ObservableCollection<An_emp> buffer)
        {
            emps = buffer;
            Employee_list.ItemsSource = buffer;

            Last_visible_index = Math.Min(2, buffer.Count - 1);
            return this;
        }

        private void Employee_list_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                listener((An_emp)Employee_list.SelectedItem);
        }

        public Card_pager AddOnEmployeeClick(OnHideListener listener)
        {
            this.listener = listener;

            return this;
        }
    }
}
