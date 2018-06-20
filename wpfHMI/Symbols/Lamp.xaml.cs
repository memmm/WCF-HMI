using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace HmiStyle.Symbols
{
    /// <summary>
    /// Interaction logic for Lamp.xaml
    /// </summary>
    public partial class Lamp : UserControl
    {
        private DispatcherTimer _timer;
        private bool _blinkSlow = false;
        private bool _blinkFast = false;

        public Lamp()
        {
            InitializeComponent();

            // Configure Timer used for blinking: 
            // Blinking_Fast = 250ms; Blinking_Slow = 500ms
            _timer = new DispatcherTimer();
            _timer.Interval = new System.TimeSpan(0, 0, 0, 0, 250); // [ms]
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        public static readonly DependencyProperty SteadyOnProperty = DependencyProperty.Register(
            "SteadyOn", typeof(bool), typeof(Lamp), new PropertyMetadata(default(bool), RefreshStatus));
        public static readonly DependencyProperty BlinkingSlowProperty = DependencyProperty.Register(
            "BlinkingSlow", typeof(bool), typeof(Lamp), new PropertyMetadata(default(bool), RefreshStatus));
        public static readonly DependencyProperty BlinkingFastProperty = DependencyProperty.Register(
            "BlinkingFast", typeof(bool), typeof(Lamp), new PropertyMetadata(default(bool), RefreshStatus));
        public static readonly DependencyProperty LampColorProperty = DependencyProperty.Register(
            "LampColor", typeof(Brush), typeof(Lamp), new PropertyMetadata(default(Brush), RefreshStatus));

        public bool SteadyOn
        {
            get { return (bool)GetValue(SteadyOnProperty); }
            set { SetValue(SteadyOnProperty, value); }
        }

        public bool BlinkingSlow
        {
            get { return (bool)GetValue(BlinkingSlowProperty); }
            set { SetValue(BlinkingSlowProperty, value); }
        }

        public bool BlinkingFast
        {
            get { return (bool)GetValue(BlinkingFastProperty); }
            set { SetValue(BlinkingFastProperty, value); }
        }

        public Brush LampColor
        {
            get { return (Brush)GetValue(LampColorProperty); }
            set { SetValue(LampColorProperty, value); }
        }

        private static void RefreshStatus(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var lamp = d as Lamp;
            if (lamp != null) d.Dispatcher.Invoke(() => lamp.updateStatus());
        }

        private void _timer_Tick(object sender, System.EventArgs e)
        {
            _blinkFast ^= true;
            if (_blinkFast) _blinkSlow ^= true;
            Dispatcher.Invoke(() => updateStatus());
        }

        private void updateStatus()
        {
            if (BlinkingFast)
            {
                xBackground.Fill = _blinkFast ? LampColor : Brushes.LightGray;
            }
            else if (BlinkingSlow)
            {
                xBackground.Fill = _blinkSlow ? LampColor : Brushes.LightGray;
            }
            else
            {
                xBackground.Fill = SteadyOn ? LampColor : Brushes.LightGray;
            }
        }

    }
}
