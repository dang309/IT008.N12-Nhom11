using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CUAHANGADIDAS.DTO
{
    class Staff
    {
        public Staff(int ID,string NAME, int PHONE, string ADDRESS, string EMAIL, string NAMECV,string SEX)
        {
            this.ID = ID;
            this.NAME = NAME;
            this.PHONE = PHONE;
            this.ADDRESS = ADDRESS;
            this.EMAIL = EMAIL;
            this.POSITION = NAMECV;
            this.SEX = SEX;
        }
        public Staff(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.NAME= row["NAME"].ToString();
            this.PHONE = (int)row["PHONE"];
            this.ADDRESS = row["ADDRESS"].ToString();
            this.EMAIL = row["EMAIL"].ToString();
            this.POSITION = row["NAMECV"].ToString();
            this.SEX = row["SEX"].ToString();
        }
    
        
        
        private int iD;
        private string nAME;
        private int pHONE;
        private string aDDRESS;
        private string eMAIL;
        private string pOSITION;
        
        private string sEX; 
        
        public int ID { get => iD; set => iD = value; }
        public string NAME { get => nAME; set => nAME = value; }
        public int PHONE { get => pHONE; set => pHONE = value; }
        public string ADDRESS { get => aDDRESS; set => aDDRESS = value; }
        public string EMAIL { get => eMAIL; set => eMAIL = value; }
        public string POSITION { get => pOSITION; set => pOSITION = value; }
        public string SEX { get => sEX; set => sEX = value; }
        
    }
}
