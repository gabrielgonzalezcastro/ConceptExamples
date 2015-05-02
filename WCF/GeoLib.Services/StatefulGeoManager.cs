using GeoLib.Contracts;
using GeoLib.Data;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace GeoLib.Services
{
    //Instancing the Service Per Session The Service can hold the state of the variables in the class
    //scope like _zipcodeEntity. The Session remains alive per proxy. If we close the proxy and 
    // we make another call another instance of the service is created.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class StatefulGeoManager : IStatefulGeoService
    {
        private ZipCode _zipCodeEntity;

        public void PushZip(string zip)
        {
            IZipCodeRepository zipCodeRepository = new ZipCodeRepository();
            _zipCodeEntity = zipCodeRepository.GetByZip(zip);

        }

        public ZipCodeData GetZipInfo()
        {
            ZipCodeData zipCodeData = null;

            if (_zipCodeEntity != null)
            {
                zipCodeData = new ZipCodeData
                {
                    City = _zipCodeEntity.City,
                    State = _zipCodeEntity.State.Abbreviation,
                    ZipCode = _zipCodeEntity.Zip
                };
            }
            else
                throw new ApplicationException("Uh Oh");

            return zipCodeData;
        }

        public IEnumerable<ZipCodeData> GetZips(int range)
        {
            var zipCodeData = new List<ZipCodeData>();


            if (_zipCodeEntity != null)
            {
                IZipCodeRepository zipCodeRepository = new ZipCodeRepository();
                IEnumerable<ZipCode> zips = zipCodeRepository.GetZipsForRange(_zipCodeEntity, range);

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
            }

            return zipCodeData;
        }
    }
}
