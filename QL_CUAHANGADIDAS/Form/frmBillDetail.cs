using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;


namespace QL_CUAHANGADIDAS
{
    public partial class frmBillDetail : Form
    {
        
        private string IDHD;
        private string date11;
        private string namenv11;
        private string namekh11;
        private string money11;
        private string recieve;
        private string extra;
        public frmBillDetail()
        {
            InitializeComponent();
            
        }
        public frmBillDetail(string ID,string date,string namenv,string namekh,string money)
        {
            InitializeComponent();
            this.IDHD = ID;
            this.date11 = date;
            this.namenv11 = namenv;
            this.namekh11 = namekh;
            this.money11 = money;
            
        }
        public frmBillDetail(string tiennhan, string tienthua)
        {
            this.recieve = tiennhan;
            this.extra = tienthua;
        }




        private void frmBillDetail_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void frmBillDetail_Load_1(object sender, EventArgs e)
        {
            string id = IDHD;
            string date = date11;
            string namenv = namenv11;
            string namekh = namekh11;
            string money = money11;
            string tiennhan = recieve;
            string tienthua = extra;
           
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.QL_CUAHANGADIDASConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "USP_PintBillDetail";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add(new SqlParameter("@IDBILL", id));
            //khai bao dataset

            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            dap.Fill(ds);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "Report1.rdlc";
            if(ds.Tables[0].Rows.Count >0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "PrintBill";
                rds.Value = ds.Tables[0];
                //show in report
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport();
            }

            ReportParameterCollection rp = new ReportParameterCollection();
            rp.Add(new ReportParameter("ID", id));
            rp.Add(new ReportParameter("DATE", date));
            rp.Add(new ReportParameter("NAMENV", namenv));
            rp.Add(new ReportParameter("NAMEKH", namekh));
            rp.Add(new ReportParameter("MONEY", money));
            
            this.reportViewer1.LocalReport.SetParameters(rp);
            this.reportViewer1.RefreshReport();
        }
    }
}
