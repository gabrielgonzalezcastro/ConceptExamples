using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize Subject
            StockMarket stockMarket = new StockMarket();
            int latestQuote = 0;

            // Initialize Gadgets..Note the subject being passed in Constructor
            GoogleStockGadet googleGadget = new GoogleStockGadet(stockMarket);

          
            
            
            // Code for Getting latest stock 
            // ....
            // ....
            latestQuote = 99;
            stockMarket.setValue(latestQuote);

            // Updating all Registered Observers
            stockMarket.notify();

            //GoogleGadget decides to unregister/unsubscirbe
            googleGadget.unsubscribe();

            

        }
    }
}
