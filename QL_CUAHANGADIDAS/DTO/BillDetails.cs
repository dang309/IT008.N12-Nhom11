using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CUAHANGADIDAS.DTO
{
    class BillDetails
    {
        public BillDetails(string NAME, int SIZE, int COUNT, float PRICE)
        {
            this.Name = NAME;
            this.Size = SIZE;
            this.Count = COUNT;
            this.Price = PRICE;

        }
        public BillDetails(DataRow row)
        {
            this.Name = row["NAME"].ToString();            
            this.Size = (int)row["SIZE"];
            this.Count = (int)row["COUNT"];
            this.Price = (float)Convert.ToDouble(row["PRICE"].ToString());
        }
        private string name;
        private int size;
        private int count;
        private float price;

        public string Name { get => name; set => name = value; }
        public int Size { get => size; set => size = value; }
        public int Count { get => count; set => count = value; }
        public float Price { get => price; set => price = value; }
    }
}
