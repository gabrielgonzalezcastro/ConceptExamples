using System.Threading.Tasks;
using GeoLib.Contracts;
using GeoLib.Proxies;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Windows;
using System.Windows.Documents;

namespace GeoLib.Client
{
    /// <summary>
    /// The class need to implement the Callback Contract in order to use a Duplex Operation
    /// </summary>
    /// CallbackBehavior: if we set this property to false we say that the code in the callback method runs in a background thread
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class MainWindow_Testing_Operations : Window, IUpdateZipCallback
    {

        private SynchronizationContext _synchronizationContext = null;

        public MainWindow_Testing_Operations()
        {
            InitializeComponent();
            _synchronizationContext = SynchronizationContext.Current;
        }

        private void btnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            if (txtZipCode.Text != "")
            {
                GeoClient proxy = new GeoClient("tcpEP");

                try
                {
                    ZipCodeData data = proxy.GetZipInfo(txtZipCode.Text);
                    if (data != null)
                    {
                        lblCity.Content = data.City;
                        lblState.Content = data.State;
                    }

                    proxy.Close();
                }
                catch (FaultException ex)
                {
                    MessageBox.Show("Fault Exception: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnGetZipCodes_Click(object sender, RoutedEventArgs e)
        {
            if (txtState.Text != null)
            {
                GeoClient proxy = new GeoClient("tcpEP");

                IEnumerable<ZipCodeData> data = proxy.GetZips(txtState.Text);
                if (data != null)
                    lstZips.ItemsSource = data;

                proxy.Close();
            }
        }

        private async void btnUpdateBatch_Click(object sender, RoutedEventArgs e)
        {
            List<ZipCityData> cityZipList = new List<ZipCityData>()
            {
            	new ZipCityData() { ZipCode = "07035", City = "Bedrock" },
                new ZipCityData() { ZipCode = "33033", City = "End of the World" },
                new ZipCityData() { ZipCode = "90210", City = "Alderan" },
                new ZipCityData() { ZipCode = "07094", City = "Storybrooke" }
            };

            lstUpdates.Items.Clear();

            await Task.Run(() =>
            {
                try
                {
                    //We need to pass to the Instance Context class the class to implement the
                    // Callback Contract (IUpdateZipCallback), in this case 'this' class
                    GeoClientDuplex proxy = new GeoClientDuplex("tcpEP",new InstanceContext(this) );
                    proxy.UpdateZipCityWithCallBack(cityZipList);

                    proxy.Close();

                    MessageBox.Show("Updated.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            });

           
        }

        /// <summary>
        /// Method that is going to be call for the service using Duplex Operation
        /// </summary>
        public void ZipUpdated(ZipCityData zipCityData)
        {
            //MessageBox.Show(string.Format("Updated zipcode {0} with city {1}", zipCityData.ZipCode, zipCityData.City));

            //Marshall the background thread to update the UI
            SendOrPostCallback updateUI = new SendOrPostCallback(arg =>
            {
                lstUpdates.Items.Add(zipCityData);
            });

            _synchronizationContext.Send(updateUI,null);
        }

        private void btnPutBack_Click(object sender, RoutedEventArgs e)
        {
            List<ZipCityData> cityZipList = new List<ZipCityData>()
            {
            	new ZipCityData() { ZipCode = "07035", City = "Lincoln Park" },
                new ZipCityData() { ZipCode = "33033", City = "Homestead" },
                new ZipCityData() { ZipCode = "90210", City = "Beverly Hills" },
                new ZipCityData() { ZipCode = "07094", City = "Secaucus" }
            };

            lstUpdates.Items.Clear();

            Thread thread = new Thread(() =>
            {
                try
                {
                    GeoClient proxy = new GeoClient("tcpEP");
                    proxy.Open();

                    proxy.UpdateZipCity(cityZipList);

                    proxy.Close();

                    MessageBox.Show("Updated.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            });

            thread.Start();
        }

        private void btnOneWay_Click(object sender, RoutedEventArgs e)
        {
            GeoClient proxy = new GeoClient("tcpEP");
            proxy.OneWayOperation();

            MessageBox.Show("OneWay Operation called. Back at Client");

            proxy.Close();

            MessageBox.Show("Proxy is now close");
        }

       
    }
}
