using System.ServiceModel;

namespace GeoLib.Client.Contracts
{
    /// <summary>
    /// This Service Contract is created to demostrate Contract Equivalence.
    /// The namespace in the host and in the client has to be the same
    /// </summary>
    [ServiceContract(Namespace = "http://www.gabriel.com/Gabriel/Wcf")]
    public interface IMessageService
    {
        [OperationContract]
        void ShowMessage(string message);
    }
}
