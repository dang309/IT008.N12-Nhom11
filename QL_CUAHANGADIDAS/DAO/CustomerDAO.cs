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
    class CustomerDAO
    {
        private static CustomerDAO instance;

        internal static CustomerDAO Instance
        {
            get { if (instance == null) instance = new CustomerDAO(); return CustomerDAO.instance; }

            private set { CustomerDAO.instance = value; }
        }

        private CustomerDAO() { }

        public List<Customer> GetListCustomer()
        {
            List<Customer> list = new List<Customer>();

            string query = "SELECT A.ID, A.NAME, A.PHONE, A.SEX, A.DIACHI FROM dbo.TBL_KHACHHANG A";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Customer Cus = new Customer(item);
                list.Add(Cus);
            }

            return list;
        }
        public List<Customer> SearchCusByName(string Name)
        {
            List<Customer> list = new List<Customer>();
            string query = string.Format("SELECT * FROM dbo.TBL_KHACHHANG WHERE dbo.GetUnsignString(NAME) LIKE N'%' + dbo.GetUnsignString(N'{0}') + '%'", Name);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Customer shoes = new Customer(item);
                list.Add(shoes);
            }
            return list;
        }
        public bool InsertCus(string NAME, int PHONE, string DIACHI, string SEX)
        {
            string query = string.Format("INSERT dbo.TBL_KHACHHANG ( NAME, PHONE, DIACHI, SEX ) VALUES  ( N'{0}', {1}, N'{2}', N'{3}')", NAME, PHONE, DIACHI, SEX);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }
        public bool UpdatetCus(string NAME, int PHONE, string DIACHI, string SEX,int ID)
        {
            string query = string.Format("UPDATE dbo.TBL_KHACHHANG SET NAME = N'{0}',PHONE= {1}, DIACHI = N'{2}', SEX = N'{3}' WHERE ID = {4}", NAME, PHONE, DIACHI, SEX, ID);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteCus(int idcus)
        {

            
            string query = ("DELETE dbo.TBL_KHACHHANG WHERE ID = " + idcus);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }

    }
}
