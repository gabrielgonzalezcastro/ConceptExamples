using System.ServiceModel;

namespace GeoLib.WindowsHost.Contracts
{
    /// <summary>
    /// This Service Contract is created to demostrate Contract Equivalence
    /// </summary>
    [ServiceContract(Namespace = "http://www.gabriel.com/Gabriel/Wcf")]
    public interface IMessageService
    {
        [OperationContract]
        void ShowMessage(string message);
    }
}
