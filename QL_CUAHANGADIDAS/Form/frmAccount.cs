using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_CUAHANGADIDAS
{
    public partial class frmAccount : Form
    {
        BindingSource Accountlist = new BindingSource();
        public frmAccount()
        {
            InitializeComponent();
            dtgvAccount.DataSource = Accountlist;
            loadAccount();
            BinDingAccount();
        }
        public int idnv;
        public string namenv;
        public string namecv;

        bool Login(string userName)
        {  
            return DAO.AccountDAO.Instance.check(userName);
        }
        void DeleteAccount()
        {
            string user = txbUsername.Text;
            if (MessageBox.Show("Hệ thống sẻ xóa các hoa đơn của nhân viên này. \n Bạn có muốn xóa? ", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {

                DAO.AccountDAO.Instance.DeleteAccount(user);
                MessageBox.Show("Xóa thành công");
                loadAccount();
            }

        }
       
        void InsertAccount()
        {
            
            string username = txbUsername.Text;
            
            int IDCV = Convert.ToInt32(DAO.StaffDAO.GetIDCVV(cbChucvu.Text)[0]);
            if (Login(username))
            {
                MessageBox.Show("Tài khoản đã có người sử dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                

            }
            else
            {
                if (DAO.AccountDAO.Instance.InsertAccount(username, idnv, IDCV))
                {
                    MessageBox.Show("Thêm tài khoản thành công");
                    loadAccount();
                }
                else
                {
                    MessageBox.Show("lỗi khi thêm tài khoản");
                }
            }

        }
        void BinDingAccount()
        {
            txbUsername.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "USERNAME", true, DataSourceUpdateMode.Never));
            txbNV.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Nhân viên", true, DataSourceUpdateMode.Never));
            cbChucvu.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Chức vụ", true, DataSourceUpdateMode.Never));
        }
        void loadAccount()
        {
            Accountlist.DataSource = DAO.AccountDAO.Instance.LoadAccount();
        }

        internal void populate()
        {
            txbNV.Text = namenv;
            cbChucvu.Text = namecv;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txbUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txbNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GbInfo.Enabled = true;
            btnDel.Enabled = false;
            btnUpdate.Enabled = false ;
            btnSave.Enabled = true;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnDel.Enabled = false;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {  
            btnUpdate.Enabled = false;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddstaff_Click(object sender, EventArgs e)
        {
            frmChooseStaff f = new frmChooseStaff(this);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txbNV == null || txbNV.Text == "")
            {
                MessageBox.Show("Please Enter Staff");
                return;
            }
           
            if(btnAdd.Enabled == true)
            {
                InsertAccount();
            }
            if(btnDel.Enabled == true)
            {
                DeleteAccount();

            }
            if(btnUpdate.Enabled == true)
            {
                string user = txbUsername.Text;
                DAO.AccountDAO.Instance.UpdatePassword(user);
                MessageBox.Show("Cập nhật mật khẩu thành công");
                loadAccount();

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GbInfo.Enabled = false;
            btnAdd.Enabled = true;
            btnDel.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
           
        }
    }
}
