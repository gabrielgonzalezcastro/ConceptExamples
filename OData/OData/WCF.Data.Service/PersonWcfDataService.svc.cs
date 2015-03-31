using DAL;
using System.Data.Services;
using System.Data.Services.Common;

namespace WCF.Data.Service
{
    //This attribute is used to get a message in case of error
    [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    
    public class PersonWcfDataService : DataService<AdventureWorks2012Entities>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            // config.SetEntitySetAccessRule("MyEntityset", EntitySetRights.AllRead);
            // config.SetServiceOperationAccessRule("MyServiceOperation", ServiceOperationRights.All);

            config.SetEntitySetAccessRule("*", EntitySetRights.All);
            config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
        }

        //Url Examples:
        //http://localhost:13558/PersonWcfDataService.svc/People
        //http://localhost:13558/PersonWcfDataService.svc/People(3)

    }
}
