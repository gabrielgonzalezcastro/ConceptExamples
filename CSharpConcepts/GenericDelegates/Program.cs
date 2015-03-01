using System;

namespace GenericDelegates
{
    class Program
    {
        delegate T NumberChanger<T>(T n);
        static int num = 10;

        static void Main(string[] args)
        {
            //create delegate instances
            NumberChanger<int> nc1 = new NumberChanger<int>(AddNum);
            NumberChanger<int> nc2 = new NumberChanger<int>(MultNum);

            //calling the methods using the delegate objects
            nc1(25);
            Console.WriteLine("Value of Num: {0}", GetNum());
            nc2(5);
            Console.WriteLine("Value of Num: {0}", GetNum());
            Console.ReadKey();
        }

        public static int AddNum(int p)
        {
            num += p;
            return num;
        }

        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }
        public static int GetNum()
        {
            return num;
        }
    }
}
