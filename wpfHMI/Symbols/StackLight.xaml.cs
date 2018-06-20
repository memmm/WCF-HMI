using System;
using System.Collections.Generic;
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
    /// Interaction logic for StackLight.xaml
    /// </summary>
    public partial class StackLight : UserControl
    {
        public StackLight()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty Lamp1Property = DependencyProperty.Register(
            "Lamp1", typeof(Lamp), typeof(StackLight), new PropertyMetadata(default(Lamp)));
        public static readonly DependencyProperty Lamp2Property = DependencyProperty.Register(
            "Lamp2", typeof(Lamp), typeof(StackLight), new PropertyMetadata(default(Lamp)));
        public static readonly DependencyProperty Lamp3Property = DependencyProperty.Register(
            "Lamp3", typeof(Lamp), typeof(StackLight), new PropertyMetadata(default(Lamp)));
        public static readonly DependencyProperty Lamp4Property = DependencyProperty.Register(
            "Lamp4", typeof(Lamp), typeof(StackLight), new PropertyMetadata(default(Lamp)));

        public Lamp Lamp1
        {
            get { return (Lamp)GetValue(Lamp1Property); }
            set { SetValue(Lamp1Property, value); }
        }

        public Lamp Lamp2
        {
            get { return (Lamp)GetValue(Lamp2Property); }
            set { SetValue(Lamp2Property, value); }
        }

        public Lamp Lamp3
        {
            get { return (Lamp)GetValue(Lamp3Property); }
            set { SetValue(Lamp3Property, value); }
        }

        public Lamp Lamp4
        {
            get { return (Lamp)GetValue(Lamp4Property); }
            set { SetValue(Lamp4Property, value); }
        }

        //private static void RefreshLightConfig(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    var stackLight = d as StackLight;
        //    if (stackLight != null) d.Dispatcher.Invoke(() => stackLight.SetCustomLight());
        //}

        //public void SetCustomLight()
        //{
        //    Data.StackLight stackLight = DataContext as Data.StackLight;
        //    if (stackLight == null) return;

        //    switch (CustomColorSequence)
        //    {
        //        case ColorOrder.RedAmberGreen:
        //        {
        //            Lamp1 = stackLight.RED;
        //            Lamp2 = stackLight.AMBER;
        //            Lamp3 = stackLight.GREEN;
        //            Lamp4 = null;
        //            break;
        //        }
        //        case ColorOrder.RedAmberGreenBW:
        //        {
        //            Lamp1 = stackLight.RED;
        //            Lamp2 = stackLight.AMBER;
        //            Lamp3 = stackLight.GREEN;
        //            Lamp4 = stackLight.BLUE_WHITE;
        //            break;
        //        }
        //        case ColorOrder.GreenAmberRed:
        //        {
        //            Lamp1 = stackLight.GREEN;
        //            Lamp2 = stackLight.AMBER;
        //            Lamp3 = stackLight.RED;
        //            Lamp4 = null;
        //            break;
        //        }
        //        case ColorOrder.GreenAmberRedBW:
        //        {
        //            Lamp1 = stackLight.GREEN;
        //            Lamp2 = stackLight.AMBER;
        //            Lamp3 = stackLight.RED;
        //            Lamp4 = stackLight.BLUE_WHITE;
        //            break;
        //        }
        //        default:
        //        {
        //            Lamp1 = stackLight.GREEN;
        //            Lamp2 = stackLight.AMBER;
        //            Lamp3 = stackLight.RED;
        //            Lamp4 = null;
        //            break;
        //        }
        //    }
        //}


    }
}
