using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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
    /// Interaction logic for MainWindow_TestingTransactions.xaml
    /// </summary>
    public partial class MainWindow_TestingTransactions : Window
    {
        public MainWindow_TestingTransactions()
        {
            InitializeComponent();
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

        private void btnUpdateBatch_Click(object sender, RoutedEventArgs e)
        {
            List<ZipCityData> cityZipList = new List<ZipCityData>()
            {
            	new ZipCityData() { ZipCode = "07035", City = "Bedrock" },
                new ZipCityData() { ZipCode = "33033", City = "End of the World" }
            };

            try
            {

                GeoClient proxy = new GeoClient("tcpEP");

                //proxy.UpdateZipCity(cityZipList);
                proxy.UpdateZipCityManageTransactionManually(cityZipList);

                proxy.Close();

                MessageBox.Show("Updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void btnPutBack_Click(object sender, RoutedEventArgs e)
        {
            List<ZipCityData> cityZipList = new List<ZipCityData>()
            {
            	new ZipCityData() { ZipCode = "07035", City = "Lincoln Park" },
                new ZipCityData() { ZipCode = "33033", City = "Homestead" }
            };

            try
            {
                GeoClient proxy = new GeoClient("tcpEP");

                proxy.UpdateZipCity(cityZipList);

                proxy.Close();

                MessageBox.Show("Updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void btnUpdateBatchInClient_Click(object sender, RoutedEventArgs e)
        {
            List<ZipCityData> cityZipList = new List<ZipCityData>()
            {
            	new ZipCityData() { ZipCode = "07035", City = "Bedrock" },
                new ZipCityData() { ZipCode = "33033", City = "End of the World" }
            };

            try
            {
                GeoClient proxy = new GeoClient("tcpEP");

                using (TransactionScope scope = new TransactionScope())
                {
                    proxy.UpdateZipCity(cityZipList);
                    proxy.Close();
                    
                    //Althought the service runs successfully and changed the zip data in the database and vote commit,
                    //when this exception is throw the service is called again to rollback the information due 
                    //is inside this transaction in the client and the TransactionFlow Property is true and
                    //TransactionScopeRequired is true in the service.
                    throw  new ApplicationException("UH OH!"); 

                    scope.Complete();
                }
                

                MessageBox.Show("Updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }
    }
}
