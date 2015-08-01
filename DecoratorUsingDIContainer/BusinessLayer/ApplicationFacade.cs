
namespace DecoratorDesignPattern
{
    public class ApplicationFacade : IApplicationFacade
    {
        public int Sum(int number1, int number2)
        {
            return number1 + number2;
        }
    }
}
