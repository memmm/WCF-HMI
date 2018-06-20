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
using HmiStyle.UI.WPF.Control.Popup;
using HmiStyle.UI.WPF.Data;
using HmiStyle.UI.WPF.Interface;

namespace HmiStyle.UI.WPF.Control.Symbols
{
    /// <summary>
    /// Interaction logic for TagIndicator.xaml
    /// </summary>
    public partial class TagIndicator : UserControl, IHmiControl
    {
        private HmiData _hmiData = new HmiData(true, typeof(OverviewTags));

        public TagIndicator()
        {
            InitializeComponent();
            Level = SecurityLevel.Smit;
        }

        public HmiData HmiData
        {
            get { return _hmiData; }
        }

        public SecurityLevel Level { get; set; }
        public int? UnitId { get; set; }

        private void OnButtonClicked(object sender, RoutedEventArgs e)
        {
            _hmiData.OnClicked(this);
        }
    }
}
