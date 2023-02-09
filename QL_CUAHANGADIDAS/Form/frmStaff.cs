using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_CUAHANGADIDAS
{
    public partial class frmStaff : Form
    {
        BindingSource Stafflist = new BindingSource();
        public frmStaff()
        {
            InitializeComponent();
            dtgvStaff.DataSource = Stafflist;
            BindingStaff();
            GetListStaff();

        }

        void InsertStaf()
        {
            //  foreach (DataGridView item in dtgvStaff) ;
            string name = txbName.Text;
            int phone = Convert.ToInt32(txbPhone.Text);
            string address = txbAddress.Text;
            string email = txbEmail.Text;
            string sex = cbSex.Text;
            int IDCV = Convert.ToInt32(DAO.StaffDAO.GetIDCVV(cbChucvu.Text)[0]);

            if (DAO.StaffDAO.Instance.InsertStaff(name, phone, address, email, sex, IDCV))
            {
                MessageBox.Show("Thêm nhân viên thành công");
                GetListStaff();
            }
            else
            {
                MessageBox.Show("lỗi khi thêm nhân viên");
            }

        }
        void UpdateStaff()
        {
            int id = Convert.ToInt32(txbID.Text);
            string name = txbName.Text;
            int phone = Convert.ToInt32(txbPhone.Text);
            string address = txbAddress.Text;
            string email = txbEmail.Text;
            string sex = cbSex.Text;
            int IDCV = Convert.ToInt32(DAO.StaffDAO.GetIDCVV(cbChucvu.Text)[0]);

            if (DAO.StaffDAO.Instance.UpdateStaff(name, phone, address, email, sex, IDCV, id))
            {
                MessageBox.Show("Cập nhật nhân viên thành công");
                GetListStaff();
                DAO.AccountDAO.Instance.UpdateIDCV(IDCV, id);
            }
            else
            {
                MessageBox.Show("lỗi khi cập nhật nhân viên");
            }

        }

        void BindingStaff()
        {
            txbID.DataBindings.Add(new Binding("Text", dtgvStaff.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbName.DataBindings.Add(new Binding("Text", dtgvStaff.DataSource, "NAME", true, DataSourceUpdateMode.Never));
            txbPhone.DataBindings.Add(new Binding("Text", dtgvStaff.DataSource, "PHONE", true, DataSourceUpdateMode.Never));
            txbAddress.DataBindings.Add(new Binding("Text", dtgvStaff.DataSource, "ADDRESS", true, DataSourceUpdateMode.Never));
            txbEmail.DataBindings.Add(new Binding("Text", dtgvStaff.DataSource, "EMAIL", true, DataSourceUpdateMode.Never));
            cbSex.DataBindings.Add(new Binding("Text", dtgvStaff.DataSource, "SEX", true, DataSourceUpdateMode.Never));
            cbChucvu.DataBindings.Add(new Binding("Text", dtgvStaff.DataSource, "POSITION", true, DataSourceUpdateMode.Never));

        }
        void GetListStaff()
        {
            Stafflist.DataSource = DAO.StaffDAO.Instance.GetStaff();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dtgvStaff.DataSource = DAO.StaffDAO.Instance.SearchStaff(txbSearch.Text);
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            gbinfo.Enabled = true;
            btnDelStaff.Enabled = false;
            btnUpdateStaff.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnUpdateStaff_Click(object sender, EventArgs e)
        {
            btnDelStaff.Enabled = false;
            btnAddStaff.Enabled = false;
            gbinfo.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnDelStaff_Click(object sender, EventArgs e)
        {
            btnAddStaff.Enabled = false;
            btnUpdateStaff.Enabled = false;
            gbinfo.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAddStaff.Enabled = true;
            btnUpdateStaff.Enabled = true;
            btnDelStaff.Enabled = true;
            gbinfo.Enabled = false;
            btnSave.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txbAddress.Text == null || txbAddress.Text == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!");
                return;
            }

            if (txbEmail.Text == null || txbEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Email!");
                return;
            }
            if (txbName.Text == null || txbName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập họ và tên!");
                return;
            }
            if (txbPhone.Text == null || txbPhone.Text == "")
            {
                MessageBox.Show("Vui lòng nhập sđt!");
                return;
            }

            if (cbChucvu.Text == null || cbChucvu.Text == "")
            {
                MessageBox.Show("Vui lòng nhập chức vụ!");
                return;
            }

            if (cbSex.Text == "" || cbSex.Text == null)
            {
                MessageBox.Show("Vui lòng chọn giới tính!");
                return;
            }
            if (btnAddStaff.Enabled == true)
                InsertStaf();
            if (btnDelStaff.Enabled == true)
            {
                if (MessageBox.Show("Hệ thống sẻ xóa các hoa đơn của nhân viên này. \n Bạn có muốn xóa? ", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    int id = Convert.ToInt32(txbID.Text);
                    DAO.StaffDAO.Instance.DeleteStaff(id);
                    MessageBox.Show("Xóa thành công");
                    GetListStaff();
                }

            }
            if (btnUpdateStaff.Enabled == true)
            {
                UpdateStaff();
            }
        }

        private void txbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập số");
            }
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            dtgvStaff.DataSource = DAO.StaffDAO.Instance.SearchStaff(txbSearch.Text);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xuất file Excel?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                DAO.Excel.Instance.export2Excel(dtgvStaff);
            }
        }
    }
}
