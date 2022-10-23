using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FastFood.Objects
{
    public class A_discount : INotifyPropertyChanged
    {
        // Main data
        public int Code { get; set; }
        public string Name { get; set; }
        public int Percent { get; set; }
        public int Constraint { get; set; }
        public DateTime Begin_date { get; set; }
        public DateTime End_date { get; set; }

        // UI-render data
        public string Begin_date_str
        {
            get { return Begin_date.ToString("dd-MM-yyyy"); }
        }
        public string End_date_str
        {
            get { return End_date.ToString("dd-MM-yyyy"); }
        }

        public bool Out_of_date
        {
            get 
            {
                DateTime today = DateTime.Now;

                return today > End_date;
            }
        }

        private bool ItemClicked_value;

        public bool ItemClicked
        {
            get
            {
                return ItemClicked_value;
            }
            set
            {
                ItemClicked_value = value;

                OnPropertyChanged();
            }
        }

        // Others
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
