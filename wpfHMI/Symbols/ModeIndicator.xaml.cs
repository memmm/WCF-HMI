using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HmiStyle.Symbols
{
    /// <summary>
    /// Interaction logic for ModeIndicator.xaml
    /// </summary>
    public partial class ModeIndicator : UserControl
    {
        public ModeIndicator()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty U_DowntimeProperty = DependencyProperty.Register(
            "UnscheduledDowntime", typeof(bool), typeof(ModeIndicator), new PropertyMetadata(default(bool), RefreshStatus));
        public static readonly DependencyProperty S_DowntimeProperty = DependencyProperty.Register(
            "ScheduledDowntime", typeof(bool), typeof(ModeIndicator), new PropertyMetadata(default(bool), RefreshStatus));
        public static readonly DependencyProperty EngineeringTimeProperty = DependencyProperty.Register(
            "EngieneeringTime", typeof(bool), typeof(ModeIndicator), new PropertyMetadata(default(bool), RefreshStatus));
        public static readonly DependencyProperty StandbyTimeProperty = DependencyProperty.Register(
            "StandbyTime", typeof(bool), typeof(ModeIndicator), new PropertyMetadata(default(bool), RefreshStatus));
        public static readonly DependencyProperty ProductiveTimeProperty = DependencyProperty.Register(
            "ProductiveTime", typeof(bool), typeof(ModeIndicator), new PropertyMetadata(default(bool), RefreshStatus));

        public bool UnscheduledDowntime
        {
            get { return (bool)GetValue(U_DowntimeProperty); }
            set { SetValue(U_DowntimeProperty, value); }
        }

        public bool ScheduledDowntime
        {
            get { return (bool)GetValue(S_DowntimeProperty); }
            set { SetValue(S_DowntimeProperty, value); }
        }
        public bool EngineeringTime
        {
            get { return (bool)GetValue(EngineeringTimeProperty); }
            set { SetValue(EngineeringTimeProperty, value); }
        }
        public bool StandbyTime
        {
            get { return (bool)GetValue(StandbyTimeProperty); }
            set { SetValue(StandbyTimeProperty, value); }
        }
        public bool ProductiveTime
        {
            get { return (bool)GetValue(ProductiveTimeProperty); }
            set { SetValue(ProductiveTimeProperty, value); }
        }

        private static void RefreshStatus(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var mode = d as ModeIndicator;
            if (mode != null) d.Dispatcher.Invoke(() => mode.updateStatus());
        }

        private void updateStatus()
        {
            if (UnscheduledDowntime)
            {
                GradColor1.Color = (Color)ColorConverter.ConvertFromString("OrangeRed");
                GradColor2.Color = (Color)ColorConverter.ConvertFromString("DarkRed");
                lblMode.Text = "Unscheduled Downtime".ToUpper();
                lblMode.Foreground = Brushes.White;
            }
            else if (ScheduledDowntime)
            {
                GradColor1.Color = (Color)ColorConverter.ConvertFromString("LightSalmon");
                GradColor2.Color = (Color)ColorConverter.ConvertFromString("Red");
                lblMode.Text = "Scheduled Downtime".ToUpper();
                lblMode.Foreground = Brushes.White;
            }
            else if (EngineeringTime)
            {
                GradColor1.Color = (Color)ColorConverter.ConvertFromString("LightSkyBlue");
                GradColor2.Color = (Color)ColorConverter.ConvertFromString("DarkBlue");
                lblMode.Text = "Engineering Time".ToUpper();
                lblMode.Foreground = Brushes.White;
            }
            else if (StandbyTime)
            {
                GradColor1.Color = (Color)ColorConverter.ConvertFromString("Yellow");
                GradColor2.Color = (Color)ColorConverter.ConvertFromString("Pink");
                lblMode.Text = "Standby Time".ToUpper();
                lblMode.Foreground = Brushes.Gray;
            }
            else if (ProductiveTime)
            {
                GradColor1.Color = (Color)ColorConverter.ConvertFromString("Yellow");
                GradColor2.Color = (Color)ColorConverter.ConvertFromString("Green");
                lblMode.Text = "Productive Time".ToUpper();
                lblMode.Foreground = Brushes.Gray;
            }
        }
    }

    public class BoolToVisConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            return (value is bool && (bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            return value is Visibility && (Visibility)value == Visibility.Visible;
        }
    }
}
