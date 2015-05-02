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
using GeoLib.Contracts;
using GeoLib.Proxies;

namespace GeoLib.Client
{
    /// <summary>
    /// Interaction logic for MainWindow_TestingStatefulService.xaml
    /// </summary>
    public partial class MainWindow_TestingStatefulService : Window
    {
        private StatefulGeoClient _proxy = null;

        public MainWindow_TestingStatefulService()
        {
            InitializeComponent();
            _proxy = new StatefulGeoClient();
        }

        private void btnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            if (txtZipCode.Text != "")
            {

                ZipCodeData data = _proxy.GetZipInfo();
                if (data != null)
                {
                    lblCity.Content = data.City;
                    lblState.Content = data.State;
                }

                
            }
        }

        private void btnGetInRange_Click(object sender, RoutedEventArgs e)
        {
            if (txtZipCode.Text != "" && txtRange.Text != "")
            {

                IEnumerable<ZipCodeData> data = _proxy.GetZips(int.Parse(txtRange.Text));
                if (data != null)
                    lstZips.ItemsSource = data;

            }
        }

        private void btnPush_Click(object sender, RoutedEventArgs e)
        {
            if (txtZipCode.Text != "")
            {
                _proxy.PushZip(txtZipCode.Text);
            }
        }
    }
}
