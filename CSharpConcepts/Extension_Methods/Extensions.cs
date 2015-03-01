using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_Methods
{
    //Si se quiere los extension method se pueden meter en una clase static para tener el codigo mas limpio
    public static class Extensions
    {
        //Vamos a hacer un extension method para la clase DateTime.

        //El extension metodo tiene que ser static. y usar en los parametros el keyword this seguido de la clase
        //que queremos extender, en este caso DateTime.
        public static int DaysToEndOfMonth(this DateTime date)
        {
            return DateTime.DaysInMonth(date.Year, date.Month) - date.Day;
        }

        //Ahora podremos hacer DateTime.DaysToEndOfMonth


        public static IEnumerable<string> StringThatStartWith(this IEnumerable<string> input, string start)
        {
            foreach (var c in input)
            {
                if (c.StartsWith(start))
                    yield return c; //yield return generara automaticamente un IEnumerable y le pasara los valores que
                                    //que cinciden.
            }
        }




    }
}
