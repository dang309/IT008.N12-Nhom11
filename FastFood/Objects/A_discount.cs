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
        private string Name_value;
        public string Name 
        {
            get { return Name_value; }
            set 
            {
                Name_value = value;
                OnPropertyChanged();
            } 
        }
        private int Percent_value;
        public int Percent 
        {
            get { return Percent_value; }
            set
            {
                Percent_value = value;
                OnPropertyChanged();
            }
        }

        private int Constraint_value;
        public int Constraint
        {
            get { return Constraint_value;  }
            set
            {
                Constraint_value = value;
                OnPropertyChanged();
            }
        }

        private DateTime Begin_date_value;
        public DateTime Begin_date 
        {
            get { return Begin_date_value; }
            set
            {
                Begin_date_value = value;
                Begin_date_str = ""; // changed it
                Out_of_date = true; // fake set
            }
        }

        private DateTime End_date_value;
        public DateTime End_date 
        {
            get { return End_date_value; }
            set
            {
                End_date_value = value;
                End_date_str = "";
                Out_of_date = true; // fake set
            }
        }

        // UI-render data
        public string Begin_date_str
        {
            get { return Begin_date.ToString("dd-MM-yyyy"); }
            set 
            {
                OnPropertyChanged(); 
            }
        }
        public string End_date_str
        {
            get { return End_date.ToString("dd-MM-yyyy"); }
            set
            {
                OnPropertyChanged();
            }
        }

        public bool Out_of_date
        {
            get 
            {
                DateTime today = DateTime.Now;

                return today > End_date;
            }

            set { OnPropertyChanged(); }
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
