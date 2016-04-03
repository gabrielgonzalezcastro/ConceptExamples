using System;

namespace DecoratorDesignPattern
{
    public class ValidationApplicationFacade : ApplicationFacadeDecorator
    {
        public ValidationApplicationFacade(IApplicationFacade applicationFacade) 
            : base(applicationFacade)
        {
        }

        public override int Sum(int number1, int number2)
        {
            var result = base.Sum(number1, number2);
            if(result > 2)
                throw new Exception("Sum is greater than 2");

            return result;
        }
    }
}
