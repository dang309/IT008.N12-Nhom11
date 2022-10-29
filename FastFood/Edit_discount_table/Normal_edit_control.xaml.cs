using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FastFood.Edit_discount_table
{
    /// <summary>
    /// Interaction logic for Normal_edit_control.xaml
    /// </summary>
    public partial class Normal_edit_control : UserControl
    {
        public string Normal_content
        {
            get { return Hint_editTxt.Text; }
        }

        public Normal_edit_control()
        {
            InitializeComponent();
        }

        public Normal_edit_control Add_content_and_hint(string Content, string Hint, string Existing_content)
        {
            Title_txt.Content = Content;
            Hint_editTxt.HintText = Hint;
            Hint_editTxt.TextContent = Existing_content;

            return this;
        }
    }
}
