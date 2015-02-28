using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    //The decorator Class extend the other classes through wrapping them for adding new functionality
    public class Decorator : BaseMessage
    {
        protected BaseMessage Message;

        public Decorator(BaseMessage message)
        {
            this.Message = message;
        }
        //Thsi functionality was added 
        public void SaveMessage()
        {
            //Saves outgoing message
        }

        public void SendMessageAndSave()
        {
            SaveMessage();
            Message.SendMessage();
        }

        public override void SendMessage()
        {
            Message.SendMessage();
        }
    }
}
