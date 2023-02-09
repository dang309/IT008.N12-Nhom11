using QUANLYGIAY.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CUAHANGADIDAS.DAO
{
    class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }

        private BillDAO() { }

        public void InsertBill(int IDNS, int IDKH)
        {

            DataProvider.Instance.ExcuteNonQuery("exec USP_InsertBill  @IDNS , @IDKH ", new object[] {  IDNS, IDKH });
        }

        
        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExcuteScalar("SELECT MAX(id) FROM dbo.TBL_HOADON");
            }
            catch
            {
                return 1;
            }
        }
        public void CheckOutBill(float TOTALPRICE, int ID)
        {

            DataProvider.Instance.ExcuteNonQuery("exec USP_UpdateBill @TOTALPRICE , @ID ", new object[] { TOTALPRICE, ID });
        }
        public DataTable GetListBillByDate(DateTime date1, DateTime date2)
        {
            return DataProvider.Instance.ExcuteQuery("exec USP_GetBillbyDate @date1 , @date2 ", new object[] { date1, date2 });
        }
        public DataTable GetBestSelling()
        {
            return DataProvider.Instance.ExcuteQuery("exec USP_BestSelling ");
        }

        public DataTable GetBestSeller()
        {
            return DataProvider.Instance.ExcuteQuery("exec USP_BestSeller ");
        }

        public DataTable GetMostBuyer()
        {
            return DataProvider.Instance.ExcuteQuery("exec USP_MostBuyer ");
        }
    }
}
