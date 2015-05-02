using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace GeoLib.WebHost
{
    /// <summary>
    /// With this class I can add configuration to the creation of the servive programmatically
    /// instead of configurationally with the web.config. All this because I have a instance 
    /// of the Service Host.
    /// This class need to be referenced in the web.config as a factory for my service
    /// </summary>
    public class CustomHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            ServiceHost  host = new ServiceHost(serviceType, baseAddresses);

            return host;
        }
    }
}