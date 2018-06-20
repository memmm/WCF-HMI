using HmiStyle.MainScreens;
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

namespace HmiStyle
{

    public class MockRecord
    {
        public string Surname { get; set; }
        public string ID { get; set; }
        public string Value { get; set; }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SplashScreenView Splash = new SplashScreenView();
            Splash.Show();
           
        }

        private void MediumButton_Click(object sender, RoutedEventArgs e)
        {
            
            SplashScreenHelper.Hide();
        }

       

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            FormMain mainform = new FormMain();
            mainform.Show();
            this.Close();
        }
    }
       
    
}
