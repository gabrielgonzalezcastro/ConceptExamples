using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            //declaring an int array
            MyGenericArray<int> intArray = new MyGenericArray<int>(5);

            //setting values
            for (int c = 0; c < 5; c++)
            {
                intArray.SetItem(c, c * 5);
            }

            //retrieving the values
            for (int c = 0; c < 5; c++)
            {
                Console.Write(intArray.GetItem(c) + " ");
            }

            Console.WriteLine();
            
            //declaring a character array
            MyGenericArray<char> charArray = new MyGenericArray<char>(5);
            
            //setting values
            for (int c = 0; c < 5; c++)
            {
                charArray.SetItem(c, (char)(c + 97));
            }
            
            //retrieving the values
            for (int c = 0; c < 5; c++)
            {
                Console.Write(charArray.GetItem(c) + " ");
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
