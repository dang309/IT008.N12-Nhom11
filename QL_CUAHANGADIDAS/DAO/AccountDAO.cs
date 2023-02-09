using QL_CUAHANGADIDAS.DTO;
using QUANLYGIAY.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QL_CUAHANGADIDAS.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string username, string password)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hasPass = "";

            foreach (byte item in hasData)
            {
                hasPass += item;
            }

            string query = "SELECT * FROM dbo.TBL_NGUOIDUNG WHERE username = @username AND Password = @password ";

            DataTable result = DataProvider.Instance.ExcuteQuery(query, new object[] { username, hasPass });

            return result.Rows.Count > 0;


        }
        public bool check(string username)
        {

            string query = "SELECT * FROM dbo.TBL_NGUOIDUNG WHERE username = @username";

            DataTable result = DataProvider.Instance.ExcuteQuery(query, new object[] { username});

            return result.Rows.Count > 0;


        }
        public Account GetAccountByUsername(string USERNAME)
        {
            DataTable dt = DataProvider.Instance.ExcuteQuery("Select * from TBL_NGUOIDUNG where USERNAME = '" + USERNAME + "'");
            foreach(DataRow item in dt.Rows)
            {
                return new Account(item);
            }

            return null;
        }
        public bool UpdateAccount(string userName, string pass, string newPass)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(pass);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hasPass = "";

            foreach (byte item in hasData)
            {
                hasPass += item;
            }

            byte[] temp1 = ASCIIEncoding.ASCII.GetBytes(newPass);
            byte[] hasData1 = new MD5CryptoServiceProvider().ComputeHash(temp1);

            string hasPass1 = "";

            foreach (byte item in hasData1)
            {
                hasPass1 += item;
            }
            int result = DataProvider.Instance.ExcuteNonQuery("exec USP_UpdateAccount @Username  , @Password , @Newpassword", new object[] { userName, hasPass, hasPass1 });

            return result > 0;
        }
        public bool UpdateIDCV(int idcv, int id)
        {
            string query = string.Format("UPDATE dbo.TBL_NGUOIDUNG SET IDCHUCVU = {0} WHERE IDNHANSU = {1}", new object[] {  idcv, id  });
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;

        }

        public DataTable LoadAccount()
        {
            return DataProvider.Instance.ExcuteQuery("USP_LoadAccount");
        }
        public bool InsertAccount(string USERNAME, int IDNHANSU, int IDCHUCVU)
        {
            string query = string.Format("INSERT dbo.TBL_NGUOIDUNG( USERNAME ,PASSWORD , IDNHANSU ,IDCHUCVU)VALUES  ( N'{0}' ,  N'1962026656160185351301320480154111117132155' , {1} ,  {2} )", USERNAME, IDNHANSU, IDCHUCVU);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteAccount(string username)
        {

            string query = string.Format(" DELETE dbo.TBL_NGUOIDUNG WHERE USERNAME = N'{0}' ", username);
            
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }
        public bool UpdatePassword(string username)
        {

            string query = string.Format("UPDATE dbo.TBL_NGUOIDUNG SET PASSWORD = N'1962026656160185351301320480154111117132155' WHERE USERNAME = N'{0}' ", username);

            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }

       
    }
}
