using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection_InProperty
{
    public class Client
    {
        //La inyecccion de dependencia sera por la propiedad.
        public IService Service { get; set; }
        

        public int CountNames()
        {
            var nombres = Service.GetNames();
            return nombres.Count();
        }

        
    }
}
