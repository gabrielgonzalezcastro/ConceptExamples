using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection_AND_IOC
{
    class SMSSender : INofificationAction
    {
        public void ActOnNotification(string message)
        {
            // Send SMS from here
        }
    }
}
