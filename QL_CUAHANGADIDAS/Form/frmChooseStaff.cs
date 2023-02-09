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
    public partial class frmChooseStaff : Form
    {
        frmAccount test;
        
        public frmChooseStaff(frmAccount a)
        {
            test = a;
            InitializeComponent();
            
            GetListStaff();
        }
        void GetListStaff()
        {
            dtgvStaff.DataSource = DAO.StaffDAO.Instance.GetStaff();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dtgvStaff == null)
            {
                MessageBox.Show("Chưa có thông tin khách hàng");
            }
            else
            {
                foreach (DataGridViewRow row in dtgvStaff.SelectedRows)
                {
                    string name = dtgvStaff.SelectedRows[0].Cells[1].Value.ToString();
                    string id = dtgvStaff.SelectedRows[0].Cells[0].Value.ToString();
                    string namecv = dtgvStaff.SelectedRows[0].Cells[5].Value.ToString();
                    test.namenv = name;
                    test.namecv = namecv;
                    test.idnv = Convert.ToInt32(id);
                    test.populate();
                    MessageBox.Show("Đã chọn Nhân viên: " + name);
                    this.Close();
                }
            }
        }

        

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            dtgvStaff.DataSource = DAO.StaffDAO.Instance.SearchStaff(txbSearch.Text);
        }
    }
}
