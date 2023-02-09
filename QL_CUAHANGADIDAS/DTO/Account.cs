using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CUAHANGADIDAS.DTO
{
    public class Account
    {
        public Account (string USERNAME, string PASSWORD, int IDNHANSU, int IDCHUCVU)
        {
            this.USERNAME = USERNAME;
            this.PASSWORD = PASSWORD;
            this.IDNS = IDNHANSU;
            this.IDCV = IDCHUCVU;
        }
        public Account(DataRow row)
        {
            this.USERNAME = row["USERNAME"].ToString();
            this.PASSWORD = row["PASSWORD"].ToString();
            this.IDNS = (int)row["IDNHANSU"];
            this.IDCV = (int)row["IDCHUCVU"];
        }
            
            
        private string uSERNAME;
        private string pASSWORD;
        private int iDNS;
        private int iDCV;

        public string USERNAME { get => uSERNAME; set => uSERNAME = value; }
        public string PASSWORD { get => pASSWORD; set => pASSWORD = value; }
        public int IDNS { get => iDNS; set => iDNS = value; }
        public int IDCV { get => iDCV; set => iDCV = value; }
    }
}
