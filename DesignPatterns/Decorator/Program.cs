using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {

        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.SendSMS(SendMessageOption.SendOnly);
            obj.SendSMS(SendMessageOption.SendAndSave);
            obj.SendMMS(SendMessageOption.SendOnly);
            obj.SendMMS(SendMessageOption.SendAndSave);
            //Wait for user enter key
            Console.Read();
        }

        public enum SendMessageOption
        {
            SendOnly = 0,
            SendAndSave = 1
        }

        private void SendSMS(SendMessageOption option)
        {
            //Send SMS
            var sms = new MobileSMS("123", "456", "This is example of decorator pattern.");
            if (option == SendMessageOption.SendOnly)
            {
                sms.SendMessage();
            }
            else if (option == SendMessageOption.SendAndSave)
            {
                var decorator = new Decorator(sms);
                decorator.SendMessageAndSave();
            }
        }

        private void SendMMS(SendMessageOption option)
        {
            //Send MMS
            MobileMMS mms = new MobileMMS("123", "456", new byte[] { 1, 2, 3, 4 });
            if (option == SendMessageOption.SendOnly)
            {
                mms.SendMessage();
            }
            else if (option == SendMessageOption.SendAndSave)
            {
                var decorator = new Decorator(mms);
                decorator.SendMessageAndSave();
            }
        }

    }
}
