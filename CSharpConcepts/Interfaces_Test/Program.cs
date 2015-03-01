using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Today is " + DateTime.Now.ToString("MMMM dd, yyyy") + ".");

            Point p = new Point(2, 3);
            Console.Write("My Point: ");
            PrintPoint(p);
            

        }

        // P es de tipo Point o de tipo IPoint
        static void PrintPoint(IPoint p)
        {
            Console.WriteLine("x={0}, y={1}", p.x, p.y);
            Console.ReadLine();
        }


    }
}
