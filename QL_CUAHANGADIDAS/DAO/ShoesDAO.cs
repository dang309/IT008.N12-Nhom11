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
    class ShoesDAO
    {
        private static ShoesDAO instance;

        internal static ShoesDAO Instance
        {
            get { if (instance == null) instance = new ShoesDAO(); return ShoesDAO.instance; }

            private set { ShoesDAO.instance = value; }
        }

        private ShoesDAO() { }

        public List<Shoes> GetListShoes()
        {
            List<Shoes> list = new List<Shoes>();

            string query = "Select * FROM dbo.TBL_GIAY ";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Shoes shoes = new Shoes(item);
                list.Add(shoes);
            }

            return list;
        }

        public List<Shoes> SearchShoesByName(string Name)
        {
            List<Shoes> list = new List<Shoes>();
            string query = string.Format("Select * FROM dbo.TBL_GIAY WHERE dbo.GetUnsignString(NAME) LIKE N'%' + dbo.GetUnsignString(N'{0}') + '%'", Name);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Shoes shoes = new Shoes(item);
                list.Add(shoes);
            }
            return list;
        }
        public void UpdateSLShoes(int SL, int ID)
        {
            DataProvider.Instance.ExcuteNonQuery("exec USP_UpdateSLGiay @SL , @ID  ", new object[] { SL, ID });

        }
        public bool InsertShoes(string NAME, float PRICE, int SL, int SIZE)
        {
            string query = string.Format("INSERT dbo.TBL_GIAY ( NAME, PRICE, SL, SIZE ) VALUES  ( N'{0}', {1}, N'{2}', N'{3}')", NAME, PRICE, SL, SIZE);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteShoess(int id)
        {


            string query = ("DELETE dbo.TBL_GIAY WHERE ID = " + id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }
        public bool UpdatetShoes(string NAME, float PRICE, int SL, int SIZE, int ID)
        {
            string query = string.Format("UPDATE dbo.TBL_GIAY SET NAME = N'{0}',PRICE = N'{1}', SL = N'{2}',SIZE = N'{3}' WHERE ID = {4}", NAME, PRICE, SL, SIZE, ID);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }
    }
}
