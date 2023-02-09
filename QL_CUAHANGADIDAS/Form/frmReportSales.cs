using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_CUAHANGADIDAS
{
    public partial class frmReportSales : Form
    {
        public frmReportSales()
        {
            InitializeComponent();
            


        }
       
        private void frmReportSales_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QL_CUAHANGADIDASDataSet.USP_TotalSales' table. You can move, or remove it, as needed.
            // this.USP_TotalSalesTableAdapter.Fill(this.QL_CUAHANGADIDASDataSet.USP_TotalSales);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.QL_CUAHANGADIDASConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "USP_MonthSales";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            dap.Fill(ds);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "Report2.rdlc";
            if (ds.Tables[0].Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = ds.Tables[0];
                //show in report
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport();
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.QL_CUAHANGADIDASConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "USP_TotalSales";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            dap.Fill(ds);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "RpSales.rdlc";
            if (ds.Tables[0].Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "SALES";
                rds.Value = ds.Tables[0];
                //show in report
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
