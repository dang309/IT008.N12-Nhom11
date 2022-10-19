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

namespace FastFood
{
    /// <summary>
    /// Interaction logic for Hint_textBox.xaml
    /// </summary>
    public partial class Hint_textBox : UserControl
    {
        public string Text
        {
            get { return Main_editTxt.Text; }
        }

        public string HintText
        {
            get { return (string)GetValue(hint_property); }
            set { SetValue(hint_property, value); }
        }

        public static readonly DependencyProperty hint_property
            = DependencyProperty.Register("HintText", typeof(string),
                typeof(Hint_textBox), new PropertyMetadata("TEST"));
        public Hint_textBox()
        {
            InitializeComponent();
        }
    }
}
