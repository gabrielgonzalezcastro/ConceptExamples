using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class BaseMessage
    {
        public string MessageSender { get; set; }
        public string MessageRecipient { get; set; }
        public abstract void SendMessage();
    }
}
