using HmiStyle;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace HmiStyle
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private const string Unique = "SplashScreen";

        [STAThread]
        public static void Main()
        {
            Thread thread = new Thread(
                new System.Threading.ThreadStart(
                    delegate ()
                    {
                        SplashScreenHelper.SplashScreen = new SplashScreenView();
                        SplashScreenHelper.Show();
                        System.Windows.Threading.Dispatcher.Run();
                    }
                ));
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
            var application = new App();
            application.InitializeComponent();
            
            application.Run();
            
        }

        public void ChangeTheme(Uri uri)
        {
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            var path = Application.Current.Resources.MergedDictionaries;
            path.Remove(path[0]);
            path.Insert(0,resourceDict);
        }
    }
}
