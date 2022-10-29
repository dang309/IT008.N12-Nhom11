using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FastFood.Objects
{
    public class An_emp : INotifyPropertyChanged
    {
        public int Code { get; set; }
        public bool Is_admin { get; set; }
        public string ChucVu { get; set; }

        public string Name { get; set; }
        public bool Is_male { get; set; }

        // UI render property
        private double Container_width_value;
        public double Container_width
        {
            get { return Container_width_value; }
            set
            {
                Container_width_value = value;
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
