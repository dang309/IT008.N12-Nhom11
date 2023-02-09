using QL_CUAHANGADIDAS.DTO;
using QUANLYGIAY.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CUAHANGADIDAS.DAO
{
    class StaffDAO
    {
        private static StaffDAO instance;

        internal static StaffDAO Instance
        {
            get { if (instance == null) instance = new StaffDAO(); return StaffDAO.instance; }

            private set { StaffDAO.instance = value; }
        }

        private StaffDAO() { }

        public List<Staff> ShowNameStaff(int id)
        {
            List<Staff> list = new List<Staff>();

            

            DataTable data = DataProvider.Instance.ExcuteQuery("exec USP_ShowNameStaff @ID ", new object[] { id });

            foreach (DataRow item in data.Rows)
            {
                Staff staff = new Staff(item);
                list.Add(staff);
            }

            return list;
        }

        public static string[] GetName(int ID)
        {
            string[] info = new string[1];
            DataTable data = DataProvider.Instance.ExcuteQuery("exec USP_GetName @ID ", new object[] { ID });
            info[0] = data.Rows[0]["NAME"].ToString();
            

            return info;
        }
        public static string[] GetIDName(int ID)
        {
            string[] info = new string[1];
            DataTable data = DataProvider.Instance.ExcuteQuery("exec USP_GetIDName @ID ", new object[] { ID });
            info[0] = data.Rows[0]["ID"].ToString();          

            return info;
        }

        public List<Staff> GetStaff()
        {
            List<Staff> list = new List<Staff>();

            DataTable data = DataProvider.Instance.ExcuteQuery("exec USP_GetStaff");

            foreach (DataRow item in data.Rows)
            {
                Staff staff = new Staff(item);
                list.Add(staff);
            }

            return list;
        }
        //public static string[] GetIDCV(int ID)
        //{
        //    string[] info = new string[1];
        //    DataTable data = DataProvider.Instance.ExcuteQuery("exec USP_GetIDName @ID ", new object[] { ID });
        //    info[0] = data.Rows[0]["NAMECV"].ToString();

        //    return info;
        //}
        public static string[] GetIDCVV(string name)
        {
            string[] info = new string[1];
            DataTable data = DataProvider.Instance.ExcuteQuery("exec dbo.USP_GetIDByNameCV @NAME ", new object[] { name });
            info[0] = data.Rows[0]["ID"].ToString();

            return info;
        }
        public List<Staff> SearchStaff(string name)
        {
            List<Staff> list = new List<Staff>();
            string query = string.Format("SELECT A.ID, A.NAME,A.PHONE,A.ADDRESS,A.EMAIL, B.NAMECV,A.SEX FROM dbo.TBL_NHANSU A, dbo.TBL_CHUCVU B  WHERE A.CHUCVU=B.ID AND dbo.GetUnsignString(A.NAME) LIKE N'%' + dbo.GetUnsignString(N'{0}') + '%'", name);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Staff staff = new Staff(item);
                list.Add(staff);
            }

            return list;
        }
        public bool InsertStaff (string NAME, int PHONE, string ADDRESS, string EMAIL, string SEX, int POSITION)
        {
            string query = string.Format("INSERT dbo.TBL_NHANSU( NAME ,PHONE ,ADDRESS ,EMAIL ,SEX ,CHUCVU)VALUES  ( N'{0}', {1} , N'{2}', N'{3}', N'{4}', {5} ) ", NAME, PHONE, ADDRESS, EMAIL, SEX, POSITION);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteStaff(int id)
        {


            string query = ("DELETE dbo.TBL_NHANSU WHERE ID = " + id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateStaff(string name,int phone,string address,string email, string sex, int chucvu,int id)
        {
           string query= string.Format("UPDATE dbo.TBL_NHANSU SET NAME = N'{0}',PHONE = {1} ,ADDRESS = N'{2}', EMAIL = N'{3}',SEX = N'{4}', CHUCVU = {5} WHERE ID = {6}", new object[] { name, phone,address,email,sex,chucvu,id });
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;

        }
    }
}
