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
    public partial class frmPrintBilling : Form
    {
        private string namenv11;
        private string namekh11;
        private string money11;
        public frmPrintBilling()
        {
            InitializeComponent();
        }
        public frmPrintBilling(string namenv, string namekh, string money)
        {
            InitializeComponent();
            this.namenv11 = namenv;
            this.namekh11 = namekh;
            this.money11 = money;

        }
        private void frmPrintBilling_Load(object sender, EventArgs e)
        {
            string id = Convert.ToString(DAO.BillDAO.Instance.GetMaxIDBill());
            DateTime now = DateTime.Now;
            string date = now.ToString();
            string namenv = namenv11;
            string namekh = namekh11;
            string money = money11;

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
            if (ds.Tables[0].Rows.Count > 0)
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
