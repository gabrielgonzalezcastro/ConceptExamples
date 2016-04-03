using System;
using System.Diagnostics;

namespace DecoratorDesignPattern
{
    //Decorator class that add logging functionality to the Application Facade
    public class LogApplicationFacade : ApplicationFacadeDecorator
    {
        public LogApplicationFacade(IApplicationFacade applicationFacade) 
            : base(applicationFacade)
        {
        }

        public override int Sum(int number1, int number2)
        {
            Log("Method Sum Called");
            return base.Sum(number1, number2);
        }

        private void Log(string message)
        {
             Debug.WriteLine(message);
        }
    }
}
