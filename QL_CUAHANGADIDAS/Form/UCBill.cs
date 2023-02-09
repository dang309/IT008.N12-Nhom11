using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_CUAHANGADIDAS
{
    public partial class UCBill : UserControl
    {
        public UCBill()
        {
            InitializeComponent();
        }

   

        private void btnTotalDT_Click_1(object sender, EventArgs e)
        {
            frmBestSelling f = new frmBestSelling();
            f.Show();
        }

        /* private void btnBuyer_Click_1(object sender, EventArgs e)
        {
            frmMostBuyer f = new frmMostBuyer();
            f.Show();
        } */

        private void btnBill_Click(object sender, EventArgs e)
        {
            frmBill f = new frmBill();
            f.Show();
        }

        private void btnBSeller_Click(object sender, EventArgs e)
        {
            frmBestSeller f = new frmBestSeller();
            f.Show();
        }
    }
}
