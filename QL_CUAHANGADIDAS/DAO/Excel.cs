using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using app = Microsoft.Office.Interop.Excel.Application;

namespace QL_CUAHANGADIDAS.DAO
{
    class Excel
    {
         private static Excel instance;

        public static Excel Instance
        {
            get { if (instance == null) instance = new Excel(); return instance; }
            private set { instance = value; }
        }

        private Excel() { }
        public void export2Excel(DataGridView g)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.InitialDirectory = @"C:\";
            saveDlg.Filter = "Excel files (*.xls)|*.xlsx";
            saveDlg.FilterIndex = 0;
            saveDlg.RestoreDirectory = true;
            saveDlg.Title = "Export Excel File To";

            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = saveDlg.FileName;

                    app obj = new app();
                    obj.Application.Workbooks.Add(Type.Missing);
                    obj.Columns.ColumnWidth = 25;
                    for (int i = 1; i < g.Columns.Count + 1; i++)
                    {
                        obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
                    }
                    for (int i = 0; i < g.Rows.Count; i++)
                    {
                        for (int j = 0; j < g.Columns.Count; j++)
                        {
                            if (g.Rows[i].Cells[j].Value != null)
                            {
                                obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }
                    obj.ActiveWorkbook.SaveCopyAs(path);
                    obj.ActiveWorkbook.Saved = true;
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            
        }
    }

}
