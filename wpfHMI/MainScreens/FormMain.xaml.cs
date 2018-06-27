using clientProxy;
using contract;
using contract.Devices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HmiStyle.MainScreens
{
    /// <summary>
    /// Interaction logic for FormMain.xaml
    /// </summary>
    public partial class FormMain : Window, INotifyPropertyChanged
    {
        WPFProxy proxy;

        private ObservableCollection<DeviceBase> devices = new ObservableCollection<DeviceBase>();
        public ObservableCollection<DeviceBase> Devices
        {
            get {
                return devices;
            }
            set {
                devices = value;
                NotifyPropertyChanged("Devices");
            }
        }

        private DeviceBase selectedDevice;
        public DeviceBase SelectedDevice
        {
            get { return selectedDevice; }
            set {
                selectedDevice = value;
                NotifyPropertyChanged("SelectedDevice");
            }
        }

        private string systemMode;
        public string SystemMode
        {
            get { return systemMode; }
            set {
                systemMode = value;
                NotifyPropertyChanged("SystemMode");
            }
        }


        public FormMain()
        {

            proxy = new WPFProxy(this);
            Devices = proxy.GetDeviceList();

            InitializeComponent();
            
            SplashScreenHelper.Hide();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            MenuItemMainView.IsChecked = true;
            popup.CustomPopupPlacementCallback = new CustomPopupPlacementCallback(placePopup);
            DataContext = this;
            proxy.Connect();
        }

        public CustomPopupPlacement[] placePopup(Size popupSize, Size targetSize, Point offset)
        {
            CustomPopupPlacement[] ttplaces =
                    new CustomPopupPlacement[] { new CustomPopupPlacement() };
            ttplaces[0].Point = new Point(-50, 90);
            ttplaces[0].PrimaryAxis = PopupPrimaryAxis.Vertical;
            return ttplaces;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

       

        private void MainWindow_Open(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }

        

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender == MenuItemMainView)
            {
                MenuItemRecipes.IsChecked = false;
                MenuItemHelp.IsChecked = false;
            }
            else if (sender == MenuItemHelp)
            {
                MenuItemMainView.IsChecked = false;
                MenuItemRecipes.IsChecked = false;
            }
            else if (sender == MenuItemRecipes)
            {
                MenuItemMainView.IsChecked = false;
                MenuItemHelp.IsChecked = false;
            }
                    
        }


        private void btnUser_Click_1(object sender, RoutedEventArgs e)
        {
            SettingsPopup p = new SettingsPopup();
            p.IsOpen = true;
            p.PlacementTarget = MainContentGrid;
            p.Placement = PlacementMode.Center;
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
