using System;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;

namespace FastFood.DTOs
{
    public class Product : INotifyPropertyChanged
    {
        public Product()
        {

        }


        public event PropertyChangedEventHandler PropertyChanged;

        public string MaSP { get; set; }
        public string TenSP { get; set; }
        private int soLuongValue;
        public int SoLuong
        {
            get { return soLuongValue; }
            set 
            {
                soLuongValue = value;
                ThanhTien = SoLuong * DonGia;
                NotifyPropertyChanged();
            }
        }
        public int MaLoai { get; set; }
        public string DonViTinh { get; set; }
        public string HinhAnh { get; set; }
        public int DonGia { get; set; }
        private long ThanhTienValue;
        public long ThanhTien
        {
            get { return ThanhTienValue; }
            set { ThanhTienValue = value; NotifyPropertyChanged(); }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
