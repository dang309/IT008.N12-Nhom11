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
    public partial class frmBill : Form
    {
        
        public frmBill()
        {
            
            InitializeComponent();
            LoadListBill(dtpkFromDate.Value, dtpkToDate.Value);
            LoadDateTimePickerBill();

        }

        

        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }

        void LoadListBill(DateTime date1, DateTime date2)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetListBillByDate(date1, date2);
            
        }
        

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadListBill(dtpkFromDate.Value, dtpkToDate.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
          
            foreach (DataGridViewRow row in dtgvBill.SelectedRows)
            {
                string id = dtgvBill.SelectedRows[0].Cells[0].Value.ToString();
                string date1= dtgvBill.SelectedRows[0].Cells[1].Value.ToString();
                string namenvv= dtgvBill.SelectedRows[0].Cells[2].Value.ToString();
                string namekhh = dtgvBill.SelectedRows[0].Cells[3].Value.ToString();
                string moneyy= dtgvBill.SelectedRows[0].Cells[4].Value.ToString();

                frmBillDetail f = new frmBillDetail(id,date1,namenvv,namekhh,moneyy);
                
                f.ShowDialog();
                
              
                
            }
        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            LoadListBill(dtpkFromDate.Value, dtpkToDate.Value);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            frmReportSales f = new frmReportSales();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
