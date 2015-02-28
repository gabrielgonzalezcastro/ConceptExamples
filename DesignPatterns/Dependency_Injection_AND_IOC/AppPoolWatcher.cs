using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection_AND_IOC
{
    class AppPoolWatcher
    {
        // Handle to EventLog writer to write to the logs
        INofificationAction action = null;

        //Injection de Dependencia en el constructor de la clase
        public AppPoolWatcher(INofificationAction concreteImplementation)
        {
            this.action = concreteImplementation;
        }

        // This function will be called when the app pool has problem
        public void Notify(string message)
        {
            action.ActOnNotification(message);
        }

    }
}
