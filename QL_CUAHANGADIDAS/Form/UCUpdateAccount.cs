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
    public partial class UCUpdateAccount : UserControl
    {
        private Account loginAccount;

        internal Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; }
        }
        public UCUpdateAccount(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            load();
        }


        void load()
        {
            txbUsername.Text = loginAccount.USERNAME;
        }
        void UpdateAccount()
        {
            string username = txbUsername.Text;
            string password = txbPass.Text;
            string newpass = txbNewpass.Text;
            string renewpass = txbRepass.Text;
            if (!newpass.Equals(renewpass))
            {
                MessageBox.Show("Mật khẩu mới không khớp,");
            }
            else
            {
                if (DAO.AccountDAO.Instance.UpdateAccount(username, password, newpass))
                {
                    MessageBox.Show("Thành công!");
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không chính xác!");
                }
            }
            txbPass.Clear();
            txbNewpass.Clear();
            txbRepass.Clear();
        }
        private void frmOK_Click(object sender, EventArgs e)
        {
            UpdateAccount();

        }
    }
}
