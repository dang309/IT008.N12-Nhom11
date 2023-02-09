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
    public partial class frmBestSelling : Form
    {
        public frmBestSelling()
        {
            InitializeComponent();
            load();
        }

        public void load()
        {
            dtgvBestSelling.DataSource = DAO.BillDAO.Instance.GetBestSelling();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBestSelling_Load(object sender, EventArgs e)
        {

        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xuất file Excel?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                DAO.Excel.Instance.export2Excel(dtgvBestSelling);
            }
        }
    }
}
