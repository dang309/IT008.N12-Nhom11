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
using QL_CUAHANGADIDAS.DAO;
using System.Globalization;
using System.Threading;


namespace QL_CUAHANGADIDAS
{
    
    public partial class UCShopping : UserControl
    {   
        BindingSource Menulist = new BindingSource();
        private Account loginAccount;

        internal Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; }
        }

        

        
        public UCShopping(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            loaddata();


        }
        public string ID;
        public int IDD;

        void loaddata()
        {
            dtgvMenu.DataSource = Menulist;
            
            LoadListShoes();
            ShowNameUser();
            Money();




        }
        public void Money()
        {
            string tiennhan = txbRecieve.Text;
            string tienthua = txbExtra.Text;
            frmBillDetail f = new frmBillDetail(tiennhan, tienthua);
        }



        void ShowNameUser()
        {
            int ID = loginAccount.IDNS;
            string name = StaffDAO.GetName(ID)[0];
            txbUserr.Text = name;


        }

        internal void populate()
        {
            txbCus.Text = ID;

        }

        
        void LoadListShoes()
        {
            Menulist.DataSource = ShoesDAO.Instance.GetListShoes();
        }

       

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            string soA = "";
            string soB = txbTotalPrice.Text.Split(',')[0];
            soA = txbRecieve.Text;
            if(soA.Length == 0)
            {
                txbExtra.Text = "0";
                return;
                
            }
            double A;
            double B;
            double kq;

            A = double.Parse(soA);
            B = double.Parse(soB);
            kq = (A - B);
            txbExtra.Text = kq.ToString("C", culture);
           
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txbCus.Text = "";
            double totalprice = 0;
            if (dtgvMenu.SelectedRows[0].Cells[3].Value.ToString() == "0")
            {
                MessageBox.Show("Giày bạn chọn đã hết! Vui lòng chọn sản phẩm khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (DataGridViewRow row in dtgvMenu.SelectedRows)
                {
                    ListViewItem lvt1 = new ListViewItem(row.Cells[0].Value.ToString());
                    lvt1.SubItems.Add(row.Cells[1].Value.ToString());
                    lvt1.SubItems.Add(row.Cells[2].Value.ToString());
                    lvt1.SubItems.Add(nmShoesCount.Value.ToString());
                    lvt1.SubItems.Add(row.Cells[4].Value.ToString());
                    lvBill.Items.Add(lvt1);

                }

                for (int i = 0; i < lvBill.Items.Count; i++)
                {
                    totalprice += (double.Parse(lvBill.Items[i].SubItems[4].Text) * (double.Parse(lvBill.Items[i].SubItems[3].Text)));
                }
                CultureInfo culture = new CultureInfo("vi-VN");
               // Thread.CurrentThread.CurrentCulture = culture;
                txbTotalPrice.Text = totalprice.ToString("c", culture);
            }
            
            
                
        }

        private void lvBill_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            //Keep the width not changed.
            e.NewWidth = this.lvBill.Columns[e.ColumnIndex].Width;
            //Cancel the event.
            e.Cancel = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lvBill.Items.Count == 0)
            {
                MessageBox.Show("Chưa có mặt hàng cần xóa.");
                return;
            }
            foreach (ListViewItem lvt1 in lvBill.SelectedItems)
            {
                lvBill.Items.Remove(lvt1);
                txbTotalPrice.Refresh();
            }
            
        }

        private void UCShopping_Load(object sender, EventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if(lvBill.Items.Count == 0)
            {
                MessageBox.Show("Chưa có mặt hàng cần thanh toán");
                return;
            }
            
            
            if( txbCus.Text == "")
              {
                MessageBox.Show("Vui lòng chọn khách hàng!");
                return;
              }
                
                
            if (MessageBox.Show("Bạn có thật sự muốn thanh toán?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
               int ID = LoginAccount.IDNS;
               int IDNV = Convert.ToInt32(StaffDAO.GetIDName(ID)[0]);
               BillDAO.Instance.InsertBill(IDNV, IDD);
               int bill = BillDAO.Instance.GetMaxIDBill();

               for (int i = 0; i < lvBill.Items.Count; i++)
                {
                        int idgiay = int.Parse(lvBill.Items[i].SubItems[0].Text);
                        int sl = int.Parse(lvBill.Items[i].SubItems[3].Text);
                        ShoesDAO.Instance.UpdateSLShoes(sl, idgiay);
                        BillDetailsDAO.Instance.InsertBillDetail(bill, idgiay, sl);

                }
                double totalPrice;

                totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0]);
                BillDAO.Instance.CheckOutBill((float)totalPrice, bill);                       
                MessageBox.Show("Đã thanh toán!");
                lvBill.Items.Clear();
                LoadListShoes();
                // btnPrint.Enabled = true;
            }
            
        }

        private void btnAddCus_Click(object sender, EventArgs e)
        {
            
            frmAddCus f = new frmAddCus(this);
            this.Hide();
            f.Show();
            this.Show();
        }

        private void txbCus_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           MessageBox.Show(ID);
        }

        private void txbRecieve_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txbRecieve_Enter(object sender, EventArgs e)
        {
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
          

        }

   
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txbCus.Text == "")
            {
                MessageBox.Show("Chưa có thông tin để in hóa đơn!");
                return;
            }
            string namenvv = txbUserr.Text;
            string namekhh = txbCus.Text;
            string moneyy = txbTotalPrice.Text.Split(',')[0];
            frmPrintBilling f = new frmPrintBilling(namenvv, namekhh, moneyy);
            f.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            dtgvMenu.DataSource = ShoesDAO.Instance.SearchShoesByName(txbSearch.Text);
        }
    }
}
