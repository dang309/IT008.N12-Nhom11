using QL_CUAHANGADIDAS.DAO;
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
    public partial class frmShoes : Form
    {
        BindingSource Shoeslist = new BindingSource();
        public frmShoes()
        {
            InitializeComponent();
            dtgvShoes.DataSource = Shoeslist;
            BindingShoes();
            LoadListShoes();
        }
        void InsertShoes()
        {
            string name = txbName.Text;
            float price = float.Parse(txbPrice.Text);
            int size = int.Parse(cbSize.Text);
            int count = int.Parse(txbSL.Text);
            DAO.ShoesDAO.Instance.InsertShoes(name, price, count, size);

        }
        void UpdateShoes()
        {
            string name = txbName.Text;
            float price = float.Parse(txbPrice.Text);
            int size = int.Parse(cbSize.Text);
            int count = int.Parse(txbSL.Text);
            int id = int.Parse(txbID.Text);
            DAO.ShoesDAO.Instance.UpdatetShoes(name, price, count, size, id);
        }
        void BindingShoes()
        {
            txbID.DataBindings.Add(new Binding("Text", dtgvShoes.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbName.DataBindings.Add(new Binding("Text", dtgvShoes.DataSource, "NAME", true, DataSourceUpdateMode.Never));
            txbSL.DataBindings.Add(new Binding("Text", dtgvShoes.DataSource, "SL", true, DataSourceUpdateMode.Never));
            cbSize.DataBindings.Add(new Binding("Text", dtgvShoes.DataSource, "SIZE", true, DataSourceUpdateMode.Never));
            txbPrice.DataBindings.Add(new Binding("Text", dtgvShoes.DataSource, "PRICE", true, DataSourceUpdateMode.Never));

        }
        void LoadListShoes()
        {
            Shoeslist.DataSource = DAO.ShoesDAO.Instance.GetListShoes();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txbAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmShoes_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txbSL_TextChanged(object sender, EventArgs e)
        {

        }



        private void btnAddShoes_Click(object sender, EventArgs e)
        {
            btnDelShoes.Enabled = false;
            btnUpdateShoes.Enabled = false;
            gbinfo.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnUpdateShoes_Click(object sender, EventArgs e)
        {
            btnDelShoes.Enabled = false;
            btnAddShoes.Enabled = false;
            gbinfo.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnDelShoes_Click(object sender, EventArgs e)
        {
            btnUpdateShoes.Enabled = false;
            btnAddShoes.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnUpdateShoes.Enabled = true;
            btnAddShoes.Enabled = true;
            btnDelShoes.Enabled = true;
            gbinfo.Enabled = false;
            btnSave.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txbName.Text == null || txbName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!");
                return;
            }
            if (txbPrice.Text == null || txbPrice.Text == "")
            {
                MessageBox.Show("Vui lòng nhập giá sản phẩm!");
                return;
            }
            if (txbSL.Text == null || txbSL.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng sản phẩm!");
                return;
            }
            if (cbSize.Text == null || cbSize.Text == "")
            {
                MessageBox.Show("Vui lòng nhập kích cỡ!");
                return;
            }

            if (btnAddShoes.Enabled == true)
            {
                InsertShoes();
                MessageBox.Show("Thêm thành công");
                LoadListShoes();
            }
            if (btnDelShoes.Enabled == true)
            {
                int id = int.Parse(txbID.Text);
                if (MessageBox.Show("Xóa khách hàng này? Dữ liệu không thể phục hồi!", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    DAO.ShoesDAO.Instance.DeleteShoess(id);
                    MessageBox.Show("Xóa thành công");
                    LoadListShoes();
                }

            }
            if (btnUpdateShoes.Enabled == true)
            {
                UpdateShoes();
                MessageBox.Show("Cập nhật thành công");
                LoadListShoes();
            }
        }

        private void txbSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập số!");
            }
        }

        private void txbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập số!");
            }
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            dtgvShoes.DataSource = ShoesDAO.Instance.SearchShoesByName(txbSearch.Text);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xuất file Excel?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                DAO.Excel.Instance.export2Excel(dtgvShoes);
            }
        }
    }
}
