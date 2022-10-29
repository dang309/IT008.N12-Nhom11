using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;

namespace FastFood.Objects
{
    public class An_import : INotifyPropertyChanged
    {
        public An_import(DataRow dr)
        {
            Code = Convert.ToInt32(dr[0]);
            Import_date = ((DateTime)dr[1]).ToString("dd-MM-yyyy");
            total_cost = Convert.ToInt32(dr[2]);
            Emp_name = (string)dr[3];
        }

        public int Code { get; set; }
        private string Emp_name;
        private string Import_date;
        private int total_cost;

        private bool Show_import_btn_value = false;
        public bool Show_import_btn 
        {
            get { return Show_import_btn_value;  }
            set
            {
                Show_import_btn_value = value;
                OnPropertyChanged();
            }
        }

        public string General_info
        {
            get 
            {
                return "Nhân viên: " + Emp_name +  "\nMã sản phẩm: " + Code 
                    + "\nNhập vào ngày: " +  Import_date + "\n Tổng tiền: " + total_cost;
            }
            set {  }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
