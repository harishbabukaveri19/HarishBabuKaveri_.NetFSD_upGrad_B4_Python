using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week6_Day1.Problem_Statement_6
{
    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Email Sent: " + message);
        }
    }
}
