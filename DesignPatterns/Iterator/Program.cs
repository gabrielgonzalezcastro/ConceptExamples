using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            //The Iterator Design Pattern allows you abstract out the details of traversing collections.
            //For example, you may different types of collections in your applications, such as an array,
            //a linked list, or a generic dictionary. For whichever the types of collections you have, you
            //will need to traverse, or iterate through the items in the collections.
            //The actual implementation on how to traverse different types of collections will be different,
            //yet the client code(calling code) should not be concerned about the details of the implementations
            
            //The .NET Framework and C# language has the Iterator pattern embedded deep in its code. 
            //The IEnumerable interface is in fact the facilitator of the Iterator pattern. 
            //Generics and Collection classes in C# can be iterated through an enumerator which is in fact an
            //Iterator pattern implementation.  

            //We have not seen the C# and .NET specific implementations of the Iterator pattern in this article.
            //Using the language and framework built-in iterators is definitely more efficient and less error prone.
            //The idea behind this article is to understand how the Iterator pattern works and we implemented
            //a simple Iterator pattern in C# . 

            //http://www.codeproject.com/Articles/186188/Iterator-Design-Pattern
            //http://www.codeproject.com/Articles/362986/Understanding-and-Implementing-the-Iterator-Patter


            IAggregate<string> aggregate = new ConcreteAggregate<string>();

            aggregate.AddItem("Apple");    //add sample data
            aggregate.AddItem("Orange");
            aggregate.AddItem("Banana");
            aggregate.AddItem("Plum");

            //iterate through the collection using IAggregate only
            foreach (string i in aggregate.GetAll())
                Console.WriteLine(i);

            Console.ReadLine();



        }
    }
}
