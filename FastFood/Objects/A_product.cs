using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;

namespace FastFood.Objects
{
    public class A_product
    {
        public A_product(DataRow dr)
        {
            Cnt_code = Convert.ToInt32(dr[0]);
            Name = Convert.ToString(dr[1]);
            Type_code = Convert.ToInt32(dr[2]);
            Number = Convert.ToInt32(dr[3]);
            Type_str = Convert.ToString(dr[5]);
            Product_img_str = Convert.ToString(dr[6]);
            Price = Convert.ToInt32(dr[7]);

            Show_import_btn = false;
        }

        public static CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
        public int Cnt_code { get; set; }
        public string Name { get; set; }
        public int Type_code { get; set; }
        public int Number { get; set; }
        public string Type_str { get; set; }
        public string Product_img_str { get; set; }
        public int Price { get; set; }

        // UI-render properties
        public string Price_str 
        {
            get { return Price.ToString("#,###", cul.NumberFormat) + " VND"; }
        }

        public BitmapImage Product_img
        {
            get 
            {
                string Current_dir = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                return new BitmapImage(new Uri(Current_dir + "/SanPham/" + Product_img_str));
            }
        }
        public bool Show_import_btn
        {
            get; set;
        }
    }
}
