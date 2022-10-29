using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Objects
{
    public class An_order
    {
        public int Code { get; set; }
        public DateTime Order_Date { get; set; }
        public string Who_bought { get; set; }
        public long Total_price { get; set; }
        
        //UI-render
        public string Total_str
        {
            get { return Total_price.ToString("#,###", A_product.cul.NumberFormat) + " VND"; }
        }
        public string Date_str
        {
            get { return Order_Date.ToString("dd-MM-yyyy"); }
        }
    }
}
