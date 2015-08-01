using System.Diagnostics;

namespace DecoratorDesignPattern
{
    //Decorator class that add logging functionality to the Application Facade
    public class LogApplicationFacade : IApplicationFacade
    {
        private readonly IApplicationFacade _applicationFacadeOriginal;

        public LogApplicationFacade(IApplicationFacade applicationFacadeOriginal)
        {
            _applicationFacadeOriginal = applicationFacadeOriginal;
        }

        public int Sum(int number1, int number2)
        {
            Debug.WriteLine("Method Sum Called");
            var result  =_applicationFacadeOriginal.Sum(number1, number2);
            return result;
        }
    }
}
