using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using GeoLib.Contracts;
using GeoLib.Services;

namespace GeoLib.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //A ServiceHost instance is necessary by each service
            ServiceHost hostGeoManager = new ServiceHost(typeof(GeoManager));
            ServiceHost hostStatefulGeoManager = new ServiceHost(typeof(StatefulGeoManager));

            #region Service Configuration Programatically

            //The same code apply for the Web Host, we need only put this code in the CustomHostFactory Class
            //string address = "net.tcp://localhost:8009/GeoService";
            //Binding binding = new NetTcpBinding();
            //Type contract = typeof (IGeoService);

            //hostGeoManager.AddServiceEndpoint(contract, binding, address);
            #endregion

            hostStatefulGeoManager.Open();
            hostGeoManager.Open();

            Console.WriteLine("Services started. Press [Enter] to exit.");
            Console.ReadLine();

            //Hosting Stateful GeoManager Service
          
           


            hostGeoManager.Close();
            hostStatefulGeoManager.Close();
            


        }
    }
}
