using System;

namespace DecoratorDesignPattern
{
    public class ValidationApplicationFacade : IApplicationFacade
    {
        private readonly IApplicationFacade _applicationFacade;

        public ValidationApplicationFacade(IApplicationFacade applicationFacade)
        {
            _applicationFacade = applicationFacade;
        }

        public int Sum(int number1, int number2)
        {
            var result = _applicationFacade.Sum(number1, number2);
            if(result > 2)
                throw new Exception("Sum is greater than 2");

            return result;
        }
    }
}
