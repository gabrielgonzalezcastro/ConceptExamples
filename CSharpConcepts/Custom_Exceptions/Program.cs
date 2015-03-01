using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            throw new  InvalidAccountException("custom Exception", new Exception("inner exception"));
        }
    }
}
