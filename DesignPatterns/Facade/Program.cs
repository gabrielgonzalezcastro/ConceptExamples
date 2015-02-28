using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            ///////////////NOW BELOW IS MY CLIENT CODE WITHOUT USING FACADE/////////////////////////////////////

            //Here we have created 3 objects of 3 different classes and call their respective method for our task
            
            //ShutDownWindows ObjPCShutDown = new ShutDownWindows();
            //string sOutput = ObjPCShutDown.ShutDownWindow();

            //MonitorOff ObjMonitorOff = new MonitorOff();
            //sOutput = sOutput + "," + ObjMonitorOff.TurnOffMonitor();

            //UPSOff ObjUPSOff = new UPSOff();
            //sOutput = sOutput + " and Finally, " + ObjUPSOff.TurnOffUPS();

            //Console.WriteLine(sOutput);
            //Console.ReadKey();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////

            /////////////////////////////////WITH FACADE DESIGN PATTERN///////////////////////////////////////

            //Now my client code need not worry about 3 different classes and their functions.

            TurnOffDesktop ObjTurnOffDesktop = new TurnOffDesktop();
            string sOutput = ObjTurnOffDesktop.Method_TurnOffDesktop();

            Console.WriteLine(sOutput);
            Console.ReadKey();

            ////////////////////////////////////////////////////////////////////////////////////////////////////
        }
    }
}
