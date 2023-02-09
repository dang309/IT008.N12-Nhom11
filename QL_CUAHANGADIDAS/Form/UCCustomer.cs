using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

using QL_CUAHANGADIDAS.DAO;

namespace QL_CUAHANGADIDAS
{
    public partial class UCCustomer : UserControl
    {
        BindingSource Cuslist = new BindingSource();
        public UCCustomer()
        {

            InitializeComponent();
            dtgvCus.DataSource = Cuslist;
            LoadlistCus();
            BindingCus();
        }
        void DeleteCus()
        {
            int ID = Convert.ToInt32(txbID.Text);
            CustomerDAO.Instance.DeleteCus(ID);
        }
        void UpdateCus()
        {
            string name = txbName.Text;
            int phone = int.Parse(txbPhone.Text);
            string DC = txbAddress.Text;
            string sex = cbSex.Text;
            int ID = Convert.ToInt32(txbID.Text);
            CustomerDAO.Instance.UpdatetCus(name, phone, DC, sex, ID);
            LoadlistCus();
        }
        void InsertCus()
        {
            string name = txbName.Text;
            int phone = int.Parse(txbPhone.Text);
            string DC = txbAddress.Text;
            string sex = cbSex.Text;
            CustomerDAO.Instance.InsertCus(name, phone, DC, sex);
            LoadlistCus();
        }
        void BindingCus()
        {
            txbName.DataBindings.Add(new Binding("Text", dtgvCus.DataSource, "NAME", true, DataSourceUpdateMode.Never));
            txbAddress.DataBindings.Add(new Binding("Text", dtgvCus.DataSource, "DIACHI", true, DataSourceUpdateMode.Never));
            txbPhone.DataBindings.Add(new Binding("Text", dtgvCus.DataSource, "PHONE", true, DataSourceUpdateMode.Never));
            cbSex.DataBindings.Add(new Binding("Text", dtgvCus.DataSource, "SEX", true, DataSourceUpdateMode.Never));
            txbID.DataBindings.Add(new Binding("Text", dtgvCus.DataSource, "ID", true, DataSourceUpdateMode.Never));
        }

        void LoadlistCus()
        {
            Cuslist.DataSource = CustomerDAO.Instance.GetListCustomer();
        }
        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void UCCustomer_Load(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex.IsMatch(txbPhone.Text, "[ ^ 0-9]");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearchCus_Click(object sender, EventArgs e)
        {

        }

        private void btnAddCus_Click(object sender, EventArgs e)
        {
            txbAddress.Enabled = true;
            txbID.Enabled = true;
            txbName.Enabled = true;
            cbSex.Enabled = true;
            txbPhone.Enabled = true;
            btnDelCus.Enabled = false;
            btnEditCus.Enabled = false;
            btnSave.Enabled = true;

        }

        private void dtgvCus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAddCus.Enabled = true;
            btnDelCus.Enabled = true;
            btnEditCus.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txbName.Text == "")
            {
                MessageBox.Show("Bạn không thể để trống tên khách hàng");
                return;
            }
            if (txbAddress.Text == "")
            {
                MessageBox.Show("Bạn không thể để trống địa chỉ");
                return;
            }
            if (txbPhone.Text == "")
            {
                MessageBox.Show("Bạn không thể để trống số điện thoại");
                return;
            }
            if (btnAddCus.Enabled == true)
            {
                InsertCus();
                MessageBox.Show("Đã thêm khách hàng");
                LoadlistCus();

            }

            if (btnEditCus.Enabled == true)
            {
                UpdateCus();
                MessageBox.Show("Cập nhật thành công");
                LoadlistCus();
            }
            if (btnDelCus.Enabled == true)
            {
                if (MessageBox.Show("Hệ thống sẻ xóa các hoa đơn của Khách hàng này. \n Bạn có muốn xóa? ", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    DeleteCus();
                    MessageBox.Show("Xóa thành công");
                    LoadlistCus();
                }

            }
            btnAddCus.Enabled = true;
            btnDelCus.Enabled = true;
            btnEditCus.Enabled = true;

        }

        private void btnDelCus_Click(object sender, EventArgs e)
        {
            txbAddress.Enabled = true;
            txbID.Enabled = true;
            txbName.Enabled = true;
            cbSex.Enabled = true;
            txbPhone.Enabled = true;
            btnAddCus.Enabled = false;
            btnEditCus.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnEditCus_Click(object sender, EventArgs e)
        {
            txbAddress.Enabled = true;
            txbID.Enabled = true;
            txbName.Enabled = true;
            cbSex.Enabled = true;
            txbPhone.Enabled = true;
            btnDelCus.Enabled = false;
            btnAddCus.Enabled = false;
            btnSave.Enabled = true;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txbPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txbAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập số");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnDelCus.Enabled = true;
            btnEditCus.Enabled = true;
            btnAddCus.Enabled = true;
            txbAddress.Enabled = false;
            txbID.Enabled = false;
            txbName.Enabled = false;
            cbSex.Enabled = false;
            txbPhone.Enabled = false;
            btnSave.Enabled = false;


        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xuất file Excel?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Excel.Instance.export2Excel(dtgvCus);
            }

        }

        private void txbSearchCus_TextChanged(object sender, EventArgs e)
        {
            dtgvCus.DataSource = CustomerDAO.Instance.SearchCusByName(txbSearchCus.Text);
        }
    }
}
