using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Manager : IPosition
    {
        public string Title
        {
            get
            {
                return "Manager";
            }
        }
    }
}
