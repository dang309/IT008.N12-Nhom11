using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CUAHANGADIDAS.DTO
{
    class Customer
    {
        public Customer(int ID, string NAME,int PHONE, string SEX, string DIACHI)
        {
            this.ID = ID;
            this.NAME = NAME;
            this.PHONE = PHONE;
            this.SEX = SEX;
            this.DIACHI = DIACHI;
        }
        public Customer(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.NAME = row["NAME"].ToString();
            this.PHONE = (int)row["PHONE"];
            this.SEX = row["SEX"].ToString();
            this.DIACHI = row["DIACHI"].ToString();
        }

        private int iD;
        private string nAME;
        private int pHONE;
        private string sEX;
        private string dIACHI;

        public int ID { get => iD; set => iD = value; }
        public string NAME { get => nAME; set => nAME = value; }
        public int PHONE { get => pHONE; set => pHONE = value; }
        public string SEX { get => sEX; set => sEX = value; }
        public string DIACHI { get => dIACHI; set => dIACHI = value; }
    }
}
