using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class MobileMMS : BaseMessage
    {
        public MobileMMS(string strSender, string strRecipient, byte[] image)
        {
            this.MessageSender = strSender;
            this.MessageRecipient = strRecipient;
            this.Image = image;
        }

        public byte[] Image { get; set; }

        public override void SendMessage()
        {
            //Send MMS message
        }
    }
}
