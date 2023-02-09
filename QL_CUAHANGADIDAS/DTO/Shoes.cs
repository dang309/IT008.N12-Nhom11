using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CUAHANGADIDAS.DTO
{
    class Shoes
    {
        public Shoes(int ID, string NAME, int SIZE,int SL, float PRICE)
        {
            this.ID = ID;
            this.NAME = NAME;
            this.SIZE = SIZE;
            this.SL = SL;
            this.PRICE = PRICE;
        }
        public Shoes(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.NAME = row["NAME"].ToString();
            this.SIZE = (int)row["SIZE"];
            this.SL = (int)row["SL"];
            this.PRICE = (float)Convert.ToDouble(row["PRICE"].ToString());
        }
        private int iD;
        private string nAME;
        private int sIZE;
        private float pRICE;
        private int sL;

        public int ID { get => iD; set => iD = value; }
        public string NAME { get => nAME; set => nAME = value; }      
        public int SIZE { get => sIZE; set => sIZE = value; }
        public int SL { get => sL; set => sL = value; }
        public float PRICE { get => pRICE; set => pRICE = value; }
    }
}
