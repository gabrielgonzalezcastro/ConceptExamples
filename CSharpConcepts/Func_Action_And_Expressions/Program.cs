using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Func_Action_And_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Func is a generic type that encapsulate delegates. 
            //Es decir que cuando veamos que una funcion recibe un Func podemos escribir un lambda expression,
            //que no es mas que pasarle un metodo.

            //El tipo de dato de un Func es lo que retorna. En este caso retorna int
            Func<int, int> square = x => x*x;
            Console.WriteLine(square(2));
            Console.ReadKey();

            //aqui el lambda recibe dos variables asi que uso parentesis. Con una variable no es necesario.
            Func<int, int, int> add = (x, y) => x + y;
            Console.WriteLine(add(3,3));
            Console.ReadKey();

            //Action es como un Func pero no retorna valor es void
            Action<int> write = x =>
            {
                //esto es como un metodo anonimo puede escribir lo que quiera dentro del metodo.
                Console.WriteLine(x);
                Console.ReadKey();
            };
            write(2);


        }
    }
}
