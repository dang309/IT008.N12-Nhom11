using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media.Imaging;

namespace FastFood.Objects
{
    public class A_cart_item : INotifyPropertyChanged
    {
        public string ImgPath { get; set; }
        public BitmapImage Product_img
        {
            get
            {
                string Current_dir = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                return new BitmapImage(new Uri(Current_dir + "/SanPham/" + ImgPath));
            }
        }
        public string item_name { get; set; }
        public string Price_str
        {
            get { return price.ToString("#,###", A_product.cul.NumberFormat) + " VND"; }
        }

        private int item_number_value;
        public int item_number 
        {
            get { return item_number_value; } 
            set
            {
                item_number_value = value;
                OnPropertyChanged();
            }
        }
        public int price { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
