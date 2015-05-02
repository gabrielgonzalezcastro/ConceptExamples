using System.Collections.Generic;
using System.ServiceModel;

namespace GeoLib.Contracts
{
    //This force that to use a binding configuration that offers a transport session like tcp, ipc or WS with Rliability or Security
    //By default the value is SessionMode = Allowed
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IStatefulGeoService
    {
        [OperationContract]
        void PushZip(string zip);

        [OperationContract]
        ZipCodeData GetZipInfo();

        [OperationContract]
        IEnumerable<ZipCodeData> GetZips(int range);
    }
}
