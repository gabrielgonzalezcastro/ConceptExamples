using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection_AND_IOC
{
    class Program
    {
        static void Main(string[] args)
        {
            EventLogWriter writer = new EventLogWriter();
            AppPoolWatcher watcher = new AppPoolWatcher(writer);
            watcher.Notify("Sample message to log");

            //Now if we want this class to send email or sms instead, all we need to do is to pass the object
            //of the respective class in the AppPoolWatcher's constructor. This method is useful when we know 
            //that the instance of the dependent class will use the same concrete class for its entire lifetime.
        }
    }
}
