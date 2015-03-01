using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Classes
{
    class Horse : Abstract_Class_With_Abstract_Method
    {
        public override string Abstract_Describe()
        {
            return "Este metodo debe ser implementado porque es un abstract method (code in Horse Class)";
        }
    }
}
