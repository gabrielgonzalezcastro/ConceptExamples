using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Pattern
{
    public class StockMarket : ISubject
    {
        // A Collection to keep track of all Registered Observers
        List<IObserver> observers = new List<IObserver>();
        

        // Stores latest stock quote (example is purposely simplistic)
        int newValue = 0;

        public void setValue(int v)
        {
            newValue = v;
        }

        public void register(IObserver o)
        {
            observers.Add(o);
        }

        public void unregister(IObserver o)
        {
            
            observers.Remove(o);
        }

        public void notify()
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(newValue);
            }

         }
    }
}
