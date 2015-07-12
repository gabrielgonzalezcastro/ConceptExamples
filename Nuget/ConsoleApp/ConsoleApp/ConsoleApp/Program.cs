using System;
using NugetPackageExample;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var writer = new NugetPackageExample.Writer();
            //version 1.0
            writer.WriteMessageInConsole("Hello");
            writer.WritePersianDateTime();
           //added in version 1.1
            writer.WriteDayOfWeek();
            Console.ReadLine();
        }
    }
}
