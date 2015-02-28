using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection_AND_IOC
{
    class EmailSender : INofificationAction
    {
        public void ActOnNotification(string message)
        {
            // Send email from here
        }
    }
}
