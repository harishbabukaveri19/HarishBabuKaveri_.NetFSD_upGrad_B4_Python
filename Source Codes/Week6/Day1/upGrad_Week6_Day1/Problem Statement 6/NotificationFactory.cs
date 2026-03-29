using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week6_Day1.Problem_Statement_6
{
    public class NotificationFactory
    {
        public INotification CreateNotification(string type)
        {
            switch (type.ToLower())
            {
                case "email":
                    return new EmailNotification();

                case "sms":
                    return new SMSNotification();

                case "push":
                    return new PushNotification();

                default:
                    throw new ArgumentException("Invalid notification type");
            }
        }
    }
}
