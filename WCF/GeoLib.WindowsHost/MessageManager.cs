using GeoLib.WindowsHost.Contracts;
using System.ServiceModel;

namespace GeoLib.WindowsHost
{
    //With this attribute we specify that the service is going to run in a background thread.
    [ServiceBehavior(UseSynchronizationContext = false)]
    public class MessageManager : IMessageService
    {

        public void ShowMessage(string message)
        {
            MainWindow.MainUI.ShowMessage(message);
        }
    }
}
