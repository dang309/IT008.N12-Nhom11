using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FastFood.Objects
{
    public class A_product
    {
        private static CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
        public int Cnt_code { get; set; }
        public string Name { get; set; }
        public int Type_code { get; set; }
        public int Number { get; set; }
        public string Type_str { get; set; }
        private string Product_img_path { get; set; }
        public int Price { get; set; }

        public string Price_str 
        {
            get { return Price.ToString("#,###", cul.NumberFormat) + " VND"; }
        }
        public string Product_img_str 
        {
            get { return "../image/SanPham/" + Product_img_path; }
            set { Product_img_path = value; }
        }
    }
}
