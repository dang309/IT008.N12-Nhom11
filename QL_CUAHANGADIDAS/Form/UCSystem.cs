using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_CUAHANGADIDAS.DTO;

namespace QL_CUAHANGADIDAS
{
    public partial class UCSystem : UserControl
    {
        private Account loginAccount;

        internal Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value;   }
        }
        public UCSystem(Account acc)
        {
            InitializeComponent();
            this.loginAccount = acc;
            CheckAccount();


        }
        public UCSystem()
        {
            
        }
        void CheckAccount()
        {
            int lv = loginAccount.IDCV;
            btnStaff.Enabled = lv == 1;
            btnDTStaff.Enabled = lv == 1;
        }
        private void btnStaff_Click(object sender, EventArgs e)
        {
            
            frmStaff f = new frmStaff(); 
            f.ShowDialog();
            
           
            
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            frmShoes f = new frmShoes();
            f.Show();
        }

        private void btnDTStaff_Click(object sender, EventArgs e)
        {
            frmAccount f = new frmAccount();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này đang được phát triển!");
        }
    }
}
