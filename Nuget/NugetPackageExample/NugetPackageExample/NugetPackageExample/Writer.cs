using System;

namespace NugetPackageExample
{
    public class Writer
    {
        public void WriteMessageInConsole(string message)
        {
            Console.WriteLine(message);
        }

        public void WritePersianDateTime()
        {
            Console.WriteLine(PersianDateTime.Now.ToString());
        }

        public void WriteDayOfWeek()
        {
            Console.WriteLine(DateTime.Now.DayOfWeek);
        }
    }
}
