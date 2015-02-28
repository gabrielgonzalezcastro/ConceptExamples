using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Programmer : IPosition
    {
        public string Title
        {
            get
            {
                return "Programmer";
            }
        }
    }
}
