using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace QL_CUAHANGADIDAS
{
    public partial class frmMostBuyer : Form
    {
        public frmMostBuyer()
        {
            InitializeComponent();
            load();
        }
        void load()
        {
            dtgvBuyer.DataSource = DAO.BillDAO.Instance.GetMostBuyer();
        }





        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xuất file Excel?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                DAO.Excel.Instance.export2Excel(dtgvBuyer);
            }
        }
    }
}
