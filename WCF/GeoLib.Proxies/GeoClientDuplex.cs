using GeoLib.Contracts;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace GeoLib.Proxies
{
    //When we use Duplex Operations we have to use the class DuplexClientBase in the Proxy
    //and pass to the constructors the instanceContext
    public class GeoClientDuplex: DuplexClientBase<IGeoService>, IGeoService
    {
        public GeoClientDuplex(InstanceContext instanceContext) : base(instanceContext)
        {
            
        }
        
        public GeoClientDuplex(string endpointName, InstanceContext instanceContext)
            : base(instanceContext,endpointName)
        {
        }

        public GeoClientDuplex(Binding binding, EndpointAddress address, InstanceContext instanceContext)
            : base(instanceContext,binding, address)
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
            Channel.UpdateZipCityWithCallBack(zipCityData);
        }
    }
}
