
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HmiStyle
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreenView : Window
    {
        SplashScreenViewModel ssvm = new SplashScreenViewModel();

        public SplashScreenView()
        {
            InitializeComponent();
            DataContext = ssvm;
        }


        public static readonly DependencyProperty AppNameProperty =
            DependencyProperty.Register("AppName", typeof(string), typeof(TextBlock));//, new PropertyMetadata(default(Application.Info.Title)));

        public static readonly DependencyProperty AppVersionProperty =
            DependencyProperty.Register("AppVersion", typeof(string), typeof(TextBlock));//, new PropertyMetadata(default(System.String.Format(Version.Text, Application.Info.Version.Major, Application.Info.Version.Minor, Application.Info.Version.Build)));


        public string AppName
        {
            get { return (string)GetValue(AppNameProperty); }
            set { SetValue(AppNameProperty, value); }
        }

        public string AppVersion
        {
            get { return (string)GetValue(AppVersionProperty); }
            set { SetValue(AppVersionProperty, value); }
        }

       
        


    }


    //In order to set the status text on the splash screen, simply place 
    //a call to the SplashScreenHelper’s ShowText(string text) method, like so:
    //SplashScreenHelper.ShowText("Loading settings from database...");
    //after the last one, call SplashScreenHelper.Hide();
    internal class SplashScreenHelper
    {
        public static SplashScreenView SplashScreen { get; set; }

        public static void Show()
        {
            if (SplashScreen != null)
                
                SplashScreen.Show();
        }

        public static void Hide()
        {
            if (SplashScreen == null) return;

            if (!SplashScreen.Dispatcher.CheckAccess())
            {
                Thread thread = new Thread(
                    new System.Threading.ThreadStart(
                        delegate ()
                        {
                            SplashScreen.Dispatcher.Invoke(
                                DispatcherPriority.Normal,
                                new Action(delegate ()
                                {
                                    Thread.Sleep(2000);
                                    SplashScreen.Hide();
                                }
                            ));
                        }
                ));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            else
                SplashScreen.Hide();
        }

       
        public static void ShowText(string text)
        {
            if (SplashScreen == null) return;
            //We use the dispatcher’s CheckAccess() method to determine if the current thread 
            //has access to the dispatcher, which means we can just issue a call directly upon the View. 
            //If we don’t have access, we must use the dispatcher to invoke the necessary command.
            if (!SplashScreen.Dispatcher.CheckAccess())
            {
                Thread thread = new Thread(
                    new System.Threading.ThreadStart(
                        delegate ()
                        {
                            SplashScreen.Dispatcher.Invoke(
                                DispatcherPriority.Normal,

                                new Action(delegate ()
                                {
                                    ((SplashScreenViewModel)SplashScreen.DataContext).SplashScreenText = text;
                                }
                            ));
                            //makes sure that the UI updates reliably
                            SplashScreen.Dispatcher.Invoke(DispatcherPriority.ApplicationIdle, new Action(() => { }));
                        }
                ));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            else
                ((SplashScreenViewModel)SplashScreen.DataContext).SplashScreenText = text;
        }
    }
}
