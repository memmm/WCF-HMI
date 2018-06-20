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
using System.Windows.Shapes;

namespace HMI.Domain.ConvertToCS.MainScreens
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.tbProdCode.Text.Length > 13)
                MessageBox.Show("The Product code has a maximum length of 13 characters.");
            else {
                if (System.Text.RegularExpressions.Regex.IsMatch(this.tbProdCode.Text, "^[-_,a-zA-Z0-9]+$"))
                {
                    this.DialogResult = true;
                    this.Close();
                }
                else { MessageBox.Show("The Product code contains illegal characters"); }
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
