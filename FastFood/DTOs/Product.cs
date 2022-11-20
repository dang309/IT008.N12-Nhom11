using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.DTOs
{
    public class Product
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public int DatHang { get; set; }
        public int MaLoai { get; set; }
        public string DonViTinh { get; set; }
        public string HinhAnh { get; set; }
        public int DonGia { get; set; }

        public double ThanhTien { get; set; }

    }
}
