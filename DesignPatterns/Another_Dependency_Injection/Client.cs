using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection_InConstructor
{
    public class Client
    {
        private IService _service;

        //Inyeccion de dependencia en el constructor de la clase.
        public Client(IService service)
        {
            _service = service;
        }

        //dependiendo de tipo de clase que se le pase como parametro va a correr la implementacion del metodo Serve
        public int CountNames()
        {
            var listaNombres = _service.GetNames();
            return listaNombres.Count();

        }

    }
}
