using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            DateExtension();
            IEnumerableExtension();
        }

        private static void IEnumerableExtension()
        {
            IEnumerable<string> cities = new[] { "Caracas", "Lima", "Uruguay", "London" };

            IEnumerable<string> query = cities.StringThatStartWith("L");

            foreach (var city in query)
            {
                Console.WriteLine(city);
            }
            Console.ReadKey();
        }

        private static void DateExtension()
        {
            var date = new DateTime(2002, 8, 9);

            int daysTillEndOfMonth = date.DaysToEndOfMonth();

            Console.WriteLine(daysTillEndOfMonth.ToString());
            Console.ReadKey();
        }
    }
}
