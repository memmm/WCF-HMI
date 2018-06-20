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
using Hmi.Core;
using System.IO;

namespace HMI.Domain.ConvertToCS.MainScreens
{
    /// <summary>
    /// Interaction logic for FormLoadRecipe.xaml
    /// </summary>
    public partial class FormLoadRecipe : Window
    {
        private string m_SelectedRecipe;

        public FormLoadRecipe()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbRecipeDirectory.Text = GeneralApplicationSettings.GetSettings().DirectorySettings + "Recipe";
            this.lbRecipeList.Items.Clear();
            foreach (string foundFile in System.IO.Directory.GetFiles(tbRecipeDirectory.Text))
                { if (foundFile.ToLower().EndsWith(".xml"))
                    this.lbRecipeList.Items.Add(System.IO.Path.GetFileName(foundFile));
            }
        }

        public string SelectedRecipe
        {
        get {
                return tbRecipeDirectory.Text + "\\" + m_SelectedRecipe;
            }
        set {
                m_SelectedRecipe = System.IO.Path.GetFileName(value); 
            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void lbRecipeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m_SelectedRecipe = this.lbRecipeList.SelectedItem.ToString();
        }

        private void lbRecipeList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            m_SelectedRecipe = this.lbRecipeList.SelectedItem.ToString();
            this.DialogResult = true;
            this.Close();
        }
    }
}
