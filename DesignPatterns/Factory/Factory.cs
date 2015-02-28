using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    static class Factory
    {
        /// <summary>
        /// Decides which class to instantiate.
        /// </summary>
        public static IPosition Get(int id)
        {
            switch (id)
            {
                case 0:
                    return new Manager();
                case 1:
                case 2:
                    return new Clerk();
                case 3:
                default:
                    return new Programmer();
            }
        }
    }
}
