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
    public partial class frmMain : Form
    {

        private Account loginAccount;

        internal Account LoginAccount 
        {
            get { return loginAccount; }
            set { loginAccount = value; /*CheckAccount(LoginAccount.IDCV);*/ }
        }

        

        static frmMain _obj;
        
        public static frmMain Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new frmMain();
                }
                return _obj;
            }
        }

        public Panel PnlHome
        {

            get { return pnlHome; }
            set { pnlHome = value; }
        }
     //   /*
        public Bunifu.Framework.UI.BunifuFlatButton BackButton
        {
            get { return btnHome; }
            set { btnHome = value; }

        }
        //*/

        public object PntHome { get; private set; }
       

        public frmMain(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            ShowNameStaff();
        }
        
        public frmMain()
        {
        }
 
        void ShowNameStaff()
        {
            int ID = LoginAccount.IDNS;           
            string TenNV = StaffDAO.GetName(ID)[0];
            
            txbUser.Text = TenNV;
          
          
        }
       
        void CheckAccount(int lv)
        {
            if (lv == 1 || lv == 2)
            {
                
                btnSystem.Enabled = true;
                btnBill.Enabled = true;
                btnOrder.Enabled = true;
            }
                
            if (lv == 4)
            {
                btnOrder.Enabled = true;

            }
            if (lv == 3)
            {

                btnBill.Enabled = true;
            }

        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                this.Dispose();
            }
        }
       

        
        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            btnHome.selected = true;

            timer1.Start();
            _obj = this;

            UCHome uc = new UCHome();
            uc.Dock = DockStyle.Fill;
            pnlHome.Controls.Add(uc);


        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            DateTime tn = DateTime.Now;
            lbTime.Text = tn.ToString();
        }

        private void LbTime_Click(object sender, EventArgs e)
        {
            
        }        
        private void PnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (!frmMain.Instance.PnlHome.Controls.ContainsKey("UCUpdateAccount"))
            {
                UCUpdateAccount un = new UCUpdateAccount(LoginAccount);
                un.Dock = DockStyle.Fill;
                frmMain.Instance.PnlHome.Controls.Add(un);
            }
            frmMain.Instance.PnlHome.Controls["UCUpdateAccount"].BringToFront();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            int idcv = loginAccount.IDCV;
            if (idcv == 3)
            {
                if (!frmMain.Instance.PnlHome.Controls.ContainsKey("UCWarning"))
                {
                    UCWarning un = new UCWarning();
                    un.Dock = DockStyle.Fill;
                    frmMain.Instance.PnlHome.Controls.Add(un);
                }
                frmMain.Instance.PnlHome.Controls["UCWarning"].BringToFront();
                return;
            }
            if (!frmMain.Instance.PnlHome.Controls.ContainsKey("UCShopping"))
            {
                UCShopping un = new UCShopping(LoginAccount);
                un.Dock = DockStyle.Fill;
                frmMain.Instance.PnlHome.Controls.Add(un);
            }
            frmMain.Instance.PnlHome.Controls["UCShopping"].BringToFront();
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            pnlHome.Controls["UCHome"].BringToFront();
        }

        private void btnBill_Click_1(object sender, EventArgs e)
        {
            int idcv = loginAccount.IDCV;
            if(idcv == 4)
            {
                if (!frmMain.Instance.PnlHome.Controls.ContainsKey("UCWarning"))
                {
                    UCWarning un = new UCWarning();
                    un.Dock = DockStyle.Fill;
                    frmMain.Instance.PnlHome.Controls.Add(un);
                }
                frmMain.Instance.PnlHome.Controls["UCWarning"].BringToFront();
                return;
            }
            if (!frmMain.Instance.PnlHome.Controls.ContainsKey("UCBill"))
            {
                UCBill un = new UCBill();
                un.Dock = DockStyle.Fill;
                frmMain.Instance.PnlHome.Controls.Add(un);
            }
            frmMain.Instance.PnlHome.Controls["UCBill"].BringToFront();
        }

        private void btnCus_Click(object sender, EventArgs e)
        {

            if (!frmMain.Instance.PnlHome.Controls.ContainsKey("UCCustomer"))
            {
                UCCustomer un = new UCCustomer();
                un.Dock = DockStyle.Fill;
                frmMain.Instance.PnlHome.Controls.Add(un);
            }
            frmMain.Instance.PnlHome.Controls["UCCustomer"].BringToFront();
        }

        private void btnSystem_Click_1(object sender, EventArgs e)
        {

            int idcv = loginAccount.IDCV;
            if (idcv == 1 || idcv == 2)
            {
                if (!frmMain.Instance.PnlHome.Controls.ContainsKey("UCSystem"))
                {
                    UCSystem un = new UCSystem(loginAccount);
                    un.Dock = DockStyle.Fill;
                    frmMain.Instance.PnlHome.Controls.Add(un);
                }
                frmMain.Instance.PnlHome.Controls["UCSystem"].BringToFront();
            }
            else
            {
                if (!frmMain.Instance.PnlHome.Controls.ContainsKey("UCWarning"))
                {
                    UCWarning un = new UCWarning();
                    un.Dock = DockStyle.Fill;
                    frmMain.Instance.PnlHome.Controls.Add(un);
                }
                frmMain.Instance.PnlHome.Controls["UCWarning"].BringToFront();
            }

        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có thật sự muốn đăng xuất?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
