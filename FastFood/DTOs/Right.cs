using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FastFood.DTOs
{
    public class Right
    {
        public string Quyen { get; set; }
        public bool NhapHang { get; set; }
        public bool QLSanPham { get; set; }
        public bool QLNhanVien { get; set; }
        public bool QLKhachHang { get; set; }
        public bool ThongKe { get; set; }

        public Right()
        {

        }

    }
}
