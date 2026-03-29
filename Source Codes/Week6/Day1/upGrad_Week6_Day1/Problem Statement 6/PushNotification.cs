using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week6_Day1.Problem_Statement_6
{
    public class PushNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Push Notification Sent: " + message);
        }
    }
}
