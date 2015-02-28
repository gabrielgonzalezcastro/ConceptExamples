using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection_InConstructor
{
    public class Service_1 : IService
    {
        public IEnumerable<string> GetNames()
        {
            Console.WriteLine("Service 1 called");
            Console.ReadKey();

            return new List<string> {"Gabriel", "Gonzalez"};
        }
    }
}
