using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class MobileSMS : BaseMessage
    {
        public MobileSMS(string strSender, string strRecipient, string strMessage)
        {
            this.MessageSender = strSender;
            this.MessageRecipient = strRecipient;
            this.Message = strMessage;
        }

        public string Message { get; set; }

        public override void SendMessage()
        {
            //Send Text message
        }
    }
}
