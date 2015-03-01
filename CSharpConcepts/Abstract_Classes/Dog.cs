using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Classes
{
    class Dog : FourLeggedAnimal
    {
        public override string Describe()
        {

            string result = base.Describe();//con esto llamo al metodo "Describe" que esta implementado en la classe abstracta (base)
            result += "  + codigo anadido en Dog class";
            return result;
        }
    }
}
