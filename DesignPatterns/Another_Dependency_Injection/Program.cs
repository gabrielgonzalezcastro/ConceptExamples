using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyInjection_InConstructor
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //var Service_1 = new Service_1();
            //var cliente = new Client(Service_1);

           // var Service_2 = new Service_2();
            //var cliente = new Client(Service_2);
            
            //cliente.CountNames();

            

        }

        public static void Run(Client cliente)
        {
            cliente.CountNames();
            
        }

        
    }
}
