using System.Threading;
using GeoLib.Contracts;
using GeoLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Transactions;
using System.Windows.Forms;

namespace GeoLib.Services
{
    //InstanceContextMode: With Per Call Instance the services is stateless (the value of class scope variables is not hold
    //because create a instance of the call PER CALL

    //ReleaseServiceInstanceOnTransactionComplete: By default when we use transaction the session of the service is dispose
    //when the transaction finished. To avoid this if we need to use session to mantain the state in the service
    //we need to set this attribute to false.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession,
        IncludeExceptionDetailInFaults = true,
        ReleaseServiceInstanceOnTransactionComplete = false)]

    public class GeoManager : IGeoService
    {
        private int _Counter = 0;
        private IZipCodeRepository _zipCodeRepository = null;
        private IStateRepository _stateRepository = null;

        public GeoManager()
        {
        }

        public GeoManager(IZipCodeRepository zipCodeRepository)
            : this(zipCodeRepository, null)
        {
        }

        public GeoManager(IStateRepository stateRepository)
            : this(null, stateRepository)
        {
        }

        public GeoManager(IZipCodeRepository zipCodeRepository, IStateRepository stateRepository)
        {
            _zipCodeRepository = zipCodeRepository;
            _stateRepository = stateRepository;
        }



        public ZipCodeData GetZipInfo(string zip)
        {
            ZipCodeData zipCodeData = null;

            IZipCodeRepository zipCodeRepository = _zipCodeRepository ?? new ZipCodeRepository();
            ZipCode zipCodeEntity = zipCodeRepository.GetByZip(zip);
            if (zipCodeEntity != null)
            {
                zipCodeData = new ZipCodeData
                {
                    City = zipCodeEntity.City,
                    State = zipCodeEntity.State.Abbreviation,
                    ZipCode = zipCodeEntity.Zip
                };
            }
            else
            {
                //throw new ApplicationException(string.Format("Zip code {0} not found", zip));

                //throw new FaultException(string.Format("Zip code {0} not found.", zip));

                //ApplicationException ex = new ApplicationException(string.Format("Zip code {0} not found.", zip));
                //throw new FaultException<ApplicationException>(ex, "Just another Message");

                NotFoundData data = new NotFoundData
                {
                    Message = string.Format("Zip code {0} not found.", zip),
                    When = DateTime.Now.ToString(),
                    User = "Gabriel"
                };
                throw new FaultException<NotFoundData>(data, "Just another Message");

            }

            //Code to test instancing of the service
            _Counter++;
            Console.WriteLine("Counter = {0}", _Counter.ToString());

            return zipCodeData;
        }

        public IEnumerable<string> GetStates(bool primaryOnly)
        {
            var stateData = new List<string>();

            IStateRepository stateRepository = _stateRepository ?? new StateRepository();
            IEnumerable<State> states = stateRepository.Get(primaryOnly);
            if (states != null)
            {
                stateData.AddRange(states.Select(state => state.Abbreviation));
            }

            return stateData;
        }

        public IEnumerable<ZipCodeData> GetZips(string state)
        {
            var zipCodeData = new List<ZipCodeData>();

            IZipCodeRepository zipCodeRepository = _zipCodeRepository ?? new ZipCodeRepository();
            var zips = zipCodeRepository.GetByState(state);
            if (zips != null)
            {
                foreach (var zipCode in zips)
                {
                    zipCodeData.Add(new ZipCodeData
                    {
                        City = zipCode.City,
                        State = zipCode.State.Abbreviation,
                        ZipCode = zipCode.Zip
                    });
                }
            }

            return zipCodeData;
        }

        public IEnumerable<ZipCodeData> GetZips(string zip, int range)
        {
            var zipCodeData = new List<ZipCodeData>();

            IZipCodeRepository zipCodeRepository = _zipCodeRepository ?? new ZipCodeRepository();
            ZipCode zipEntity = zipCodeRepository.GetByZip(zip);
            IEnumerable<ZipCode> zips = zipCodeRepository.GetZipsForRange(zipEntity, range);
            if (zips != null)
            {
                foreach (var zipCode in zips)
                {
                    zipCodeData.Add(new ZipCodeData
                    {
                        City = zipCode.City,
                        State = zipCode.State.Abbreviation,
                        ZipCode = zipCode.Zip
                    });
                }
            }

            return zipCodeData;
        }

        //If a Transaction come from the client (transactionFlow=true) this operation is going to join to that transaction
        // because of the TransactionScopeRequired = true, if there is not transaction comming from the client
        //this operation is going to create one
        [OperationBehavior(TransactionScopeRequired = true)]
        public void UpdateZipCity(string zip, string city)
        {
            IZipCodeRepository zipCodeRepository = _zipCodeRepository ?? new ZipCodeRepository();

            ZipCode zipEntity = zipCodeRepository.GetByZip(zip);
            if (zipEntity != null)
            {
                zipEntity.City = city;
                zipCodeRepository.Update(zipEntity);
            }
        }

        //If a Transaction come from the client (transactionFlow=true) this operation is going to join to that transaction
        // because of the TransactionScopeRequired = true, if there is not transaction comming from the client
        //this operation is going to create one
        [OperationBehavior(TransactionScopeRequired = true)]
        public void UpdateZipCity(IEnumerable<ZipCityData> zipCityData)
        {
            IZipCodeRepository zipCodeRepository = _zipCodeRepository ?? new ZipCodeRepository();

            #region Optimize code
            //Dictionary<string, string> cityBatch = new Dictionary<string, string>();

            //foreach (ZipCityData zipCityItem in zipCityData)
            //    cityBatch.Add(zipCityItem.ZipCode, zipCityItem.City);

            //zipCodeRepository.UpdateCityBatch(cityBatch);
            #endregion

            int counter = 0;

            foreach (ZipCityData zipCityItem in zipCityData)
            {
                counter++;

                //make the service fails in the second row,this leave a inconsistent state the database
                if (counter == 2)
                    throw new FaultException("Sorry, no can do");

                ZipCode zipCodeEntity = zipCodeRepository.GetByZip(zipCityItem.ZipCode);
                zipCodeEntity.City = zipCityItem.City;
                ZipCode updateItem = zipCodeRepository.Update(zipCodeEntity);
            }

        }


        [OperationBehavior(TransactionScopeRequired = false)]
        public void UpdateZipCityManageTransactionManually(IEnumerable<ZipCityData> zipCityData)
        {
            IZipCodeRepository zipCodeRepository = _zipCodeRepository ?? new ZipCodeRepository();

            using (TransactionScope scope = new TransactionScope())
            {
                int counter = 0;

                foreach (ZipCityData zipCityItem in zipCityData)
                {
                    counter++;

                    //make the service fails in the second row,this leave a inconsistent state the database
                    if (counter == 2)
                        throw new FaultException("Sorry, no can do");

                    ZipCode zipCodeEntity = zipCodeRepository.GetByZip(zipCityItem.ZipCode);
                    zipCodeEntity.City = zipCityItem.City;
                    ZipCode updateItem = zipCodeRepository.Update(zipCodeEntity);
                }

                scope.Complete();
            }
        }


        public void OneWayOperation()
        {
            MessageBox.Show("Made it to the service");
        }


        public void UpdateZipCityWithCallBack(IEnumerable<ZipCityData> zipCityData)
        {
            IZipCodeRepository zipCodeRepository = _zipCodeRepository ?? new ZipCodeRepository();

            foreach (ZipCityData zipCityItem in zipCityData)
            {
                ZipCode zipCodeEntity = zipCodeRepository.GetByZip(zipCityItem.ZipCode);
                zipCodeEntity.City = zipCityItem.City;
                ZipCode updateItem = zipCodeRepository.Update(zipCodeEntity);

                //Making the callback to the client to notice it that a zipcode has been updated
                IUpdateZipCallback callback = OperationContext.Current.GetCallbackChannel<IUpdateZipCallback>();
                if (callback != null)
                {
                    callback.ZipUpdated(zipCityItem);
                    Thread.Sleep(1000);
                }

            }
        }
    }
}
