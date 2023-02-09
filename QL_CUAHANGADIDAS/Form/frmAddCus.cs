using QL_CUAHANGADIDAS.DAO;
using QL_CUAHANGADIDAS.DTO;
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
    public partial class frmAddCus : Form
    {
        UCShopping test;
        public frmAddCus(UCShopping a)
        {
            test = a;
            InitializeComponent();
            AddCus();
            
        }
        
        
        public void AddCus()
        {
            
            dtgvCus.DataSource = CustomerDAO.Instance.GetListCustomer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dtgvCus == null)
            {
                MessageBox.Show("Chưa có thông tin khách hàng");
            }
            else
            {
                foreach (DataGridViewRow row in dtgvCus.SelectedRows)
                {
                    string name = dtgvCus.SelectedRows[0].Cells[1].Value.ToString();
                    string id = dtgvCus.SelectedRows[0].Cells[0].Value.ToString();
                    test.ID = name;
                    test.IDD = Convert.ToInt32(id);
                    test.populate();
                    MessageBox.Show("Đã chọn khách hàng: " + name);
                    this.Close();
                }
            }
            
            
           
            
            
        }

        

        
        private void txbSearchCus_TextChanged(object sender, EventArgs e)
        {
            dtgvCus.DataSource = CustomerDAO.Instance.SearchCusByName(txbSearchCus.Text);
        }
    }
}
