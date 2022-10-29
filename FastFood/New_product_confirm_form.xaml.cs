using FastFood.Objects;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FastFood
{
    /// <summary>
    /// Interaction logic for New_product_confirm_form.xaml
    /// </summary>
    public partial class New_product_confirm_form : UserControl
    {
        public delegate void OnClose();
        public delegate void OnConfirm(string Img_path);

        private An_import import;
        private OnClose listener;
        private OnConfirm confirm_listener;
        private string Img_path;

        private string Local_image_path = Path.GetDirectoryName
                (System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName).ToString() + @"\SanPham\";

        public New_product_confirm_form()
        {
            InitializeComponent();

            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Center;
        }

        public New_product_confirm_form Prepare(An_import import, OnClose listener, OnConfirm confirm_listener)
        {
            this.import = import;
            this.listener = listener;
            this.confirm_listener = confirm_listener;

            return this;
        }

        private void Import_btn_Click(object sender, RoutedEventArgs e)
        {
            File.Copy(Img_path, Local_image_path + Path.GetFileName(Img_path));

            MySqlConnection cn = null;
            MySqlCommand cm = Tools.Connect(ref cn);

            cm.Parameters.Add("_code", MySqlDbType.Int32).Value = import.Code;
            cm.CommandText = "Delete from  hangdoinhap Where MaSp = @_code;";
            cm.ExecuteNonQuery();

            cm.Parameters.Add("_Name", MySqlDbType.VarChar).Value = Name_editTxt.Text;
            cm.Parameters.Add("_TypeCode", MySqlDbType.VarChar).Value = TypeCode_editTxt.Text;
            cm.Parameters.Add("_Number", MySqlDbType.Int32).Value = Convert.ToInt32(Number_editTxt.Text);
            cm.Parameters.Add("DonViTinh", MySqlDbType.VarChar).Value = DonViTinh_editTxt.Text;
            cm.Parameters.Add("_Img", MySqlDbType.VarChar).Value = Path.GetFileName(Img_path);
            cm.Parameters.Add("Price", MySqlDbType.Int32).Value = Convert.ToInt32(Price_editTxt.Text);

            string Img_name = Path.GetFileName(Img_path);

            cm.CommandText = "INSERT INTO sanpham VALUES(@_Code, @_Name, @_TypeCode, @_Number, @_Number, @DonViTinh, @_Img, @Price);";
            cm.ExecuteNonQuery();

            confirm_listener(Local_image_path + Path.GetFileName(Img_path));
            cn.Close();
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            listener();
        }

        private void Choose_img_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();

            Img_path = openFileDialog.FileName;
            Product_img.Source = new BitmapImage(new Uri(Img_path));
        }
    }
}
