using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Access to the attribute through Reflection
            PrintAuthorInfo(typeof(SampleClass));

        }

        private static void PrintAuthorInfo(Type t)
        {
            System.Console.WriteLine("Author information for {0}", t);

            // Using reflection.
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t);  // Reflection.

            // Displaying output.
            foreach (System.Attribute attr in attrs)
            {
                if (attr is Author)
                {
                    Author a = (Author)attr;
                    System.Console.WriteLine("   {0}, version {1:f}", a.GetName(), a.Version);
                    Console.ReadLine();
                }
            }
        }
    }
}
