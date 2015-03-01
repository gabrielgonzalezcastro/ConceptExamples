using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
           var libro = new Book("Gabriel");
            
            //seteo al delegate, diciendole que metodo va a ejecutar cuando cambie la propiedad Name
           libro.NameChanged += OnNameChanged;
           //Pudiera setear varios metodos al mismo delegate para que se ejecuten cuando la propiedad Name cambie
           libro.NameChanged += OnNameChanged2;
            
            //Cambia la palabra
            libro.Name = "Pedro";

        }

        private static void OnNameChanged(string oldValue, string newValue)
        {
            Console.WriteLine("Name changed from {0} to {1}", oldValue,newValue);
            Console.ReadKey();
        }

        private static void OnNameChanged2(string oldValue, string newValue)
        {
            Console.WriteLine("**********");
            Console.ReadKey();
        }
    }
}
