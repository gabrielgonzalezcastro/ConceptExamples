using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    //Class that hides all the sub systems from client
    public class TurnOffDesktop
    {
        public string Method_TurnOffDesktop()
        {
            ShutDownWindows ObjPCShutDown = new ShutDownWindows();
            string sResult = ObjPCShutDown.ShutDownWindow();

            MonitorOff ObjMonitorOff = new MonitorOff();
            sResult = sResult + "," + ObjMonitorOff.TurnOffMonitor();

            UPSOff ObjUPSOff = new UPSOff();
            sResult = sResult + " and Finally, " + ObjUPSOff.TurnOffUPS();

            return sResult;
        }
    }
}
