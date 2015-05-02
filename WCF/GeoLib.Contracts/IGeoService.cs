using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace GeoLib.Contracts
{
    //We link the Callback Contract using this attribute
    [ServiceContract(CallbackContract = typeof(IUpdateZipCallback))]
    public interface IGeoService
    {
        [OperationContract]
        [FaultContract(typeof(ApplicationException))] // this is used to serialize the application exception and be able to send this exception to the client
        [FaultContract(typeof(NotFoundData))]
        ZipCodeData GetZipInfo(string zip);

        /// <summary>
        /// Behind the scenes WPF is going to change the IEnumerable interface for array
        /// which is a object that everybody understand.
        /// </summary>
        [OperationContract]
        IEnumerable<string> GetStates(bool primaryOnly);

        /// <summary>
        /// Me can expose method using overloading but we have to use the 'Name' property
        /// of the OperationContract to distinguish from each other 
        /// </summary>
        [OperationContract(Name = "GetZipsByState")]
        IEnumerable<ZipCodeData> GetZips(string state);

        [OperationContract(Name = "GetZipsForRange")]
        IEnumerable<ZipCodeData> GetZips(string zip, int range);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void UpdateZipCity(string zip, string city);

        [OperationContract(Name = "UpdateZipCityBatch")]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void UpdateZipCity(IEnumerable<ZipCityData> zipCityData);

         [TransactionFlow(TransactionFlowOption.Allowed)]
        void UpdateZipCityManageTransactionManually(IEnumerable<ZipCityData> zipCityData);

        [OperationContract(IsOneWay = true)]
        void OneWayOperation();

        [OperationContract]
        void UpdateZipCityWithCallBack(IEnumerable<ZipCityData> zipCityData);
    }
    
}
