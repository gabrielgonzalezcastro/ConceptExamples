using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjection_InConstructor;
using Ninject;

namespace DependencyInjection_BootStrapper_Ninject
{
    class Program
    {
        //creamos un container que en este caso es un IKernel
        private static IKernel _container;
        static void Main(string[] args)
        {
            //instacion un standardKernel
            _container = new StandardKernel();
            
            //Hago los binding necesarios: esto dice que cuando necesitemos en algun sitio un objeto que implemente
            //la Interfaz IService (ejemplo la clase Client) le vamos a pasar una instancia de la clase Service1 que
            //obviamente implementa la interfaz IService
            _container.Bind<IService>().To<Service_1>().InTransientScope();
            //InTransientScope dice como se va a instanciar la clase en este caso una nueva instancia cada vez que 
            //lo necesite, hay otras opciones como singlenton.




            ComposeObjects();
            
        }

        private static void ComposeObjects()
        {
            DependencyInjection_InConstructor.Program.Run(_container.Get<Client>());
            Console.ReadKey();
        }
    }
}
