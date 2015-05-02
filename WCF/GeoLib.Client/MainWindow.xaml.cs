using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GeoLib.Client.Contracts;
using GeoLib.Client.ServiceReference1;
using GeoLib.Contracts;
using GeoLib.Proxies;

namespace GeoLib.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Title = "UI Running on Thread " + Thread.CurrentThread.ManagedThreadId +
               " | Process " + Process.GetCurrentProcess().Id.ToString();

        }

        private void btnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            if (txtZipCode.Text != "")
            {

                #region Call to the Service using my own Proxy Class

                //Call the service using configuration (web.config)
                GeoClient proxy = new GeoClient("httpEP");


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
                catch (FaultException<ExceptionDetail> ex)
                {
                    MessageBox.Show("Exception thrown by service. \n\rException type: " +
                                    "FaultException<ExceptionDetail>\n\r" +
                                    "Message " + ex.Detail.Message + "\n\r" +
                                    "Proxy state: " + proxy.State.ToString());
                }
                catch (FaultException<ApplicationException> ex)
                {
                    MessageBox.Show("FaultException<ApplicationException> thrown by service. \n\rException type: " +
                                    "FaultException<ApplicationException>\n\r" +
                                    "Reason : " + ex.Message + "\n\r" +
                                    "Message " + ex.Detail.Message + "\n\r" +
                                    "Proxy state: " + proxy.State.ToString());
                }
                catch (FaultException<NotFoundData> ex)
                {
                    MessageBox.Show("FaultException<NotFoundData> thrown by service. \n\rException type: " +
                                    "FaultException<NotFoundData>\n\r" +
                                    "Reason : " + ex.Message + "\n\r" +
                                    "Message " + ex.Detail.Message + "\n\r" +
                                    "Proxy state: " + proxy.State.ToString());
                }
                catch (FaultException ex)
                {
                    MessageBox.Show("FaultException thrown by service. \n\rException type: " +
                                    ex.GetType().Name + "\n\r" +
                                    "Message " + ex.Message + "\n\r" +
                                    "Proxy state: " + proxy.State.ToString()); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception thrown by service. \n\rException type: " +
                                    ex.GetType().Name + "\n\r" +
                                    "Message " + ex.Message + "\n\r" +
                                    "Proxy state: " + proxy.State.ToString());
                }

                #endregion

                #region Call the Service using the auto-generated Proxy Class when we added a service using Visual Studio.

                //ServiceReference1.GeoServiceClient proxy = new GeoServiceClient();

                //ZipCodeData data = proxy.GetZipInfo(txtZipCode.Text);
                //if (data != null)
                //{
                //    lblCity.Content = data.City;
                //    lblState.Content = data.State;
                //}

                //proxy.Close();

                #endregion

            }
        }

        private void btnGetZipCodes_Click(object sender, RoutedEventArgs e)
        {
            if (txtState.Text != null)
            {
                //Call the service using configuration by code Programatically
                EndpointAddress address = new EndpointAddress("net.tcp://localhost:8009/GeoService");
                Binding binding = new NetTcpBinding();

                GeoClient proxy = new GeoClient(binding, address);
                IEnumerable<ZipCodeData> data = proxy.GetZips(txtState.Text);
                if (data != null)
                {
                    lstZips.ItemsSource = data;
                }

                proxy.Close();
            }
        }

        private void btnMakeCall_Click(object sender, RoutedEventArgs e)
        {
            //Another way to call a service using channel factory to create a proxy class

            ChannelFactory<IMessageService> factory = new ChannelFactory<IMessageService>("");
            IMessageService proxy = factory.CreateChannel();

            proxy.ShowMessage(txtMessage.Text);
            factory.Close();

        }
    }
}
