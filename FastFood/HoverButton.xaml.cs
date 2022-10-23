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
using System.Windows.Threading;

namespace FastFood.Control_panels
{
    /// <summary>
    /// Interaction logic for HoverButton.xaml
    /// </summary>
    public partial class HoverButton : UserControl
    {
        public delegate void OnButtonClickListener();
        private OnButtonClickListener listener;

        private const double SPEED = 0.1;

        private DispatcherTimer enter_animate_timer;
        private double direction;

        public string IconPath { get; set; }

        public static readonly DependencyProperty IconPath_property
                    = DependencyProperty.Register("IconPath", typeof(string),
        typeof(HoverButton), new PropertyMetadata("image/next.png"));
        public HoverButton()
        {
            InitializeComponent();

            enter_animate_timer = new DispatcherTimer();
            enter_animate_timer.Interval = new TimeSpan(0, 0, 0, 0, 30);

            enter_animate_timer.Tick += (sender, args) =>
            {
                if (Direct_btn == null)
                    return;

                if ((Direct_btn.Opacity < 0.0 && direction == 0.1) || (Direct_btn.Opacity > 0.7 && direction == -0.1))
                    Direct_btn.Opacity += direction;
                else if (Direct_btn.Opacity < 0.0)
                {
                    Direct_btn.Opacity = 0.0;
                    direction = 0; // stop listening needs
                }
                else if (Direct_btn.Opacity > 0.7)
                {
                    Direct_btn.Opacity = 0.7;
                    direction = 0; // stop listening needs
                }
                else
                    Direct_btn.Opacity += direction;
            };

            enter_animate_timer.Start();
        }

        public void AddOnClickListener(OnButtonClickListener listener)
        {
            this.listener = listener;
        }

        private void Direct_MouseEnter(object sender, MouseEventArgs e)
        {
            direction = SPEED;
        }

        private void Direct_MouseLeave(object sender, MouseEventArgs e)
        {
            direction = -SPEED;
        }

        private void Direct_btn_Click(object sender, RoutedEventArgs e)
        {
            listener();
        }
    }
}
