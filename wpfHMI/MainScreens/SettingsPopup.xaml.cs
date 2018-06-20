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
    /// Interaction logic for SettingsPopup.xaml
    /// </summary>
    public partial class SettingsPopup
    {
        public SettingsPopup()
        {
            InitializeComponent();
        }

        private void ButtonLight_Click(object sender, RoutedEventArgs e)
        {
            var app = App.Current as App;
            app.ChangeTheme(new Uri(@"/Resources/ThemeLight.xaml", UriKind.Relative));
        }

        private void ButtonDark_Click(object sender, RoutedEventArgs e)
        {
            var app = App.Current as App;
            app.ChangeTheme(new Uri(@"/Resources/ThemeDark.xaml", UriKind.Relative));
        }

        private void Label_OnMouseDownOrTouchDown(object sender, EventArgs e)
        {
            this.IsOpen = false;
        }

        private void Label_TouchDown(object sender, TouchEventArgs e)
        {

        }
    }
}
