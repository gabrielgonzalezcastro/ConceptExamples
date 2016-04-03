
namespace DecoratorDesignPattern
{
    public abstract class ApplicationFacadeDecorator : IApplicationFacade
    {
        private readonly IApplicationFacade _applicationFacade;

        public ApplicationFacadeDecorator(IApplicationFacade applicationFacade)
        {
            _applicationFacade = applicationFacade;
        }

        public virtual int Sum(int number1, int number2)
        {
            return _applicationFacade.Sum(number1, number2);
        }
    }
}
