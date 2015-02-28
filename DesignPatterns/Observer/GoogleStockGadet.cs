using Observer_Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Pattern
{
    class GoogleStockGadet : IObserver
    {
        int latestValue = 0;
        ISubject stockMarket; // Subject reference variable

        // Note how subject is passed in the constructor of Observer
        public GoogleStockGadet(ISubject subject)
        {
            stockMarket = subject;
            stockMarket.register(this); // Registering itself to the Subject
        }

        public void Update(int value)
        {
            latestValue = value;
            display();
        }

        public void display()
        {
            Console.WriteLine("Latest Quote=" + latestValue);
            Console.ReadKey();
        }

        public void unsubscribe()
        {
            stockMarket.unregister(this);
        }

       
    }
}
