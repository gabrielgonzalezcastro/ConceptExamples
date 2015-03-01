using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegates;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var libro = new Book("Gabriel");

            // me suscribo al evento, diciendole que metodo va a ejecutar cuando cambie la propiedad Name
            libro.NameChanged += OnNameChanged;
            //Pudiera setear varios metodos al mismo delegate para que se ejecuten cuando la propiedad Name cambie
            libro.NameChanged += OnNameChanged2;

            //Cambia la Name
            libro.Name = "Pedro";

            //Con eventos  puedo tambien unsuscribe al evento usando (-=)
            libro.NameChanged -= OnNameChanged2;
           
            //Cambia la Name
            libro.Name = "Angel";

        }

        //Por Convencion los metodos o handlers que se ejecutan cuando se dispara un evento reciben 2 parametros
        // 1 .- sender: Clase que dispara el evento
        // 2.- Parametros que recibe el handlers que necesite para su ejecucion (pueden ser cualquiera). Para esto
        //creamos la clase NameChangedEventArgs con las propiedades oldvalue y newvalue
        private static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("Name changed from {0} to {1}", args.OldValue, args.NewValue);
            Console.ReadKey();
        }

        private static void OnNameChanged2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("**********");
            Console.ReadKey();
        }
    }
}
