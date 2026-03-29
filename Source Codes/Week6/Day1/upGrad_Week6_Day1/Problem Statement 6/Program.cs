//Problem 6- Implementing Factory Pattern
//Scenario: Notification Service
//A company application sends notifications to users using different communication channels:
//•	Email
//•	SMS
//•	Push Notification
//The application should not directly create objects using new.
//Instead, a Factory class should determine which notification service to create.


//Program Flow:
//Client Program -> Notification Factory -> EmailService, SMSService, PushService -> Send Email, Send SMS, Send Push

//Requirements:
//Students must implement:
//•	Interface
//INotification
//•	Method:
//Send(string message)
//Classes
//•	EmailNotification
//•	SMSNotification
//•	PushNotification
//Each class should implement INotification.
//Factory Class
//NotificationFactory
//Method:
//CreateNotification(string type)
//Example:
//CreateNotification("email")
//CreateNotification("sms")
//CreateNotification("push")
//Technical Constraints
//•	Use interface-based design.
//•	Client should not instantiate concrete classes directly.
//•	Use Factory Pattern to create objects.
//•	Language: C# Console Application.




//Expectations:
//Students should demonstrate:
//NotificationFactory factory = new NotificationFactory();

//var notification = factory.CreateNotification("email");

//notification.Send("Welcome to our service!");

//Learning Outcome:
//Students will learn:
//•	Decoupling object creation from usage
//•	Interface-based programming
//•	Open/Closed Principle basics
//•	Real-world object creation management



using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week6_Day1.Problem_Statement_6
{
    public class Program
    {
        static void Main(string[] args)
        {
            NotificationFactory factory = new NotificationFactory();

            Console.WriteLine("Enter notification type (email/sms/push): ");
            string type = Console.ReadLine();

            Console.WriteLine("Enter message: ");
            string message = Console.ReadLine();

            try
            {
                INotification notification = factory.CreateNotification(type);
                notification.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
