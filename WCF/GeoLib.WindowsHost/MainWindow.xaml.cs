using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GeoLib.Services;
using GeoLib.WindowsHost.Contracts;

namespace GeoLib.WindowsHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ServiceHost _hostGeoManager = null;
        private ServiceHost _hostMessageManager = null;
        private SynchronizationContext _synchronizationContext = null;


        public static MainWindow MainUI { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = true;

            MainUI = this;

            this.Title = "UI Running on Thread" + Thread.CurrentThread.ManagedThreadId;

            //represent the execution context of the UI thread
            _synchronizationContext = SynchronizationContext.Current;

        }

        private void BtnStart_OnClick(object sender, RoutedEventArgs e)
        {
            _hostGeoManager = new ServiceHost(typeof(GeoManager));
            _hostMessageManager = new ServiceHost(typeof(MessageManager));

            _hostGeoManager.Open();
            _hostMessageManager.Open();

            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;
        }

        private void BtnStop_OnClick(object sender, RoutedEventArgs e)
        {
            _hostGeoManager.Close();
            _hostMessageManager.Close();

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;

        }

        public void ShowMessage(string message)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            //This is used to sincronize the background thread of my service with the UI thread
            //and modify the UI setting the message in the label.
            SendOrPostCallback callback = new SendOrPostCallback(arg =>
            {
                lblMessage.Content = message + Environment.NewLine + 
                    " (marshalled from thread " + threadId.ToString() +
                    "to thread " + Thread.CurrentThread.ManagedThreadId.ToString() + 
              " | Process " + Process.GetCurrentProcess().Id.ToString() + ")"; 
            });

            _synchronizationContext.Send(callback,null);
        }

        /// <summary>
        /// Method that call the in-process service(When the same app host the service and is the client
        /// </summary>
        private void BtnInProc_OnClick(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                ChannelFactory<IMessageService> factory = new ChannelFactory<IMessageService>("");

                IMessageService proxy = factory.CreateChannel();
                proxy.ShowMessage(DateTime.Now.ToLongTimeString() + "from in-process call");

                factory.Close(); 
            });

            thread.IsBackground = true;
            thread.Start();

        }
    }
}
