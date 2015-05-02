using System.Net;
using System.ServiceModel.Channels;
using GeoLib.Contracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace GeoLib.Proxies
{
    /// <summary>
    /// Proxy class that is used to call the service. It has to inherit from ClientBase and
    /// ServiceContract. 
    /// </summary>
    public class GeoClient : ClientBase<IGeoService>, IGeoService
    {
        /// <summary>
        /// Contructor which received the endpoint name declared in the web.config
        /// </summary>
        public GeoClient(string endpointName):base(endpointName)
        {
        }

        /// <summary>
        /// Constructor used to set the endpoing by code programatically
        /// </summary>
        public GeoClient(Binding binding, EndpointAddress address) : base(binding, address)
        {
        }

        public ZipCodeData GetZipInfo(string zip)
        {
            return Channel.GetZipInfo(zip);
        }

        public IEnumerable<string> GetStates(bool primaryOnly)
        {
            return Channel.GetStates(primaryOnly);
        }

        public IEnumerable<ZipCodeData> GetZips(string state)
        {
            return Channel.GetZips(state);
        }

        public IEnumerable<ZipCodeData> GetZips(string zip, int range)
        {
            return Channel.GetZips(zip, range);
        }

        public void UpdateZipCity(string zip, string city)
        {
            Channel.UpdateZipCity(zip,city);
        }

        public void UpdateZipCity(IEnumerable<ZipCityData> zipCityData)
        {
            Channel.UpdateZipCity(zipCityData);
        }

        public void UpdateZipCityManageTransactionManually(IEnumerable<ZipCityData> zipCityData)
        {
            Channel.UpdateZipCityManageTransactionManually(zipCityData);
        }

        public void OneWayOperation()
        {
            Channel.OneWayOperation();
        }


        public void UpdateZipCityWithCallBack(IEnumerable<ZipCityData> zipCityData)
        {
            throw new System.NotImplementedException();
        }
    }
}
