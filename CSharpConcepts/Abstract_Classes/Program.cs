using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            var perro = new Dog();
            var leon = new Lion();
            var gato = new Cat();
            //Perro
            Console.WriteLine(perro.Describe());
            Console.ReadLine();

            Console.WriteLine(leon.Describe());
            Console.ReadLine();

            Console.WriteLine(gato.Describe());
            Console.ReadLine();
            /////////////////////////////////////////////////////////////////////////////////////////////////

            //Test Abstract class with abstract method
            var horse = new Horse();
            Console.WriteLine(horse.Abstract_Describe());
            Console.ReadLine();


        }
    }
}
