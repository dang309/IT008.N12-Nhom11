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
    class BillDetailsDAO
    {
        private static BillDetailsDAO instance;

        public static BillDetailsDAO Instance
        {
            get { if (instance == null) instance = new BillDetailsDAO(); return BillDetailsDAO.instance; }
            private set { BillDetailsDAO.instance = value; }
        }

        private BillDetailsDAO() { }

        public List<BillDetails> GetListBillDetail(int id)
        {
            List<BillDetails> listBillDetail = new List<BillDetails>();

            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT b.NAME ,b.SIZE ,a.COUNT , b.PRICE  FROM dbo.TBL_CHITIETHOADON a, dbo.TBL_GIAY B WHERE a.IDGIAY=b.ID AND IDBILL = " + id);

            foreach (DataRow item in data.Rows)
            {
                BillDetails info = new BillDetails(item);
                listBillDetail.Add(info);
            }

            return listBillDetail;

        }
        public void InsertBillDetail(int IDBILL, int IDGIAY, int COUNT)
        {
            DataProvider.Instance.ExcuteNonQuery("EXEC USP_InsertBillDetails @IDBILL , @IDGIAY , @COUNT ", new object[] { IDBILL, IDGIAY, COUNT });
        }

        public DataTable GetCTHT(int IDBILL)
        {
            return DataProvider.Instance.ExcuteQuery("EXEC USP_ShowCTHDByIdHD @IDBILL ", new object[] { IDBILL });
        }
    }
}
