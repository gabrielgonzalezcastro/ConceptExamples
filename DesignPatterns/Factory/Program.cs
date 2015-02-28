using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 3; i++)
            {
                var position = Factory.Get(i);
                Console.WriteLine("Where id = {0}, position = {1} ", i, position.Title);
            }
            Console.ReadKey();

        }
    }
}
