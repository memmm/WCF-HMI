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

namespace HmiStyle.MainScreens
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
            
        }

        List<ObjectNode> nodes;

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            nodes = new List<ObjectNode>();
            foreach (var db in (DataContext as FormMain).Devices)
            {
                nodes.Add(new ObjectNode(db.DevName, db));
            }
            ResultTreeView.ItemsSource = nodes;
            
        }

        private void DeviceListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var c in (DeviceListBox.SelectedItem).GetType().GetProperties())
            {
                Console.WriteLine(c.GetType());
                if (c == typeof(String))
                {
                    Console.WriteLine("String value:  " + c);
                    TextBox tb = new TextBox();
                    tb.Text = c.ToString();
                    DeviceDetailsGrid.Children.Add(tb);
                }
            }
        }

        //private void ResultTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        //{
        //    DeviceDetailsGB.Header = ((ObjectNode)e.NewValue).Value;
        //    foreach (var c in ((ObjectNode)e.NewValue).Children)
        //    {
        //        if (c.Value.GetType() == typeof(string))
        //        {
        //            TextBox tb = new TextBox();
        //            tb.Text = c.Value.ToString();
        //            DeviceDetailsGrid.Children.Add(tb);
        //        }
        //    }
        //}
    }
}
