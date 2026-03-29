//Problem 5- Implementing Singleton Pattern
//Scenario: Application Configuration Manager
//A company is developing a console-based inventory management system.
//The application needs to read application settings (e.g., database connection string, app name, version) from a configuration manager.
//Since configuration settings should be loaded only once and shared across the entire application, multiple instances of the configuration manager must be prevented.
//Therefore, the development team decides to implement the Singleton Design Pattern.

//Program Flow Diagram:
//Program(Main Application) -> ConfigurationManager(Singleton) -> ConfigurationData(AppName, Version, ConnectionString)
 
//Requirements:
//Students must implement:
//1.A class named ConfigurationManager
//2.	Ensure only one instance of the class can be created.
//3.Provide a method:
//GetInstance()
//to retrieve the single object.
//4.	Store configuration values such as:
//•	ApplicationName
//•	Version
//•	DatabaseConnectionString
//5.	Demonstrate that multiple calls to GetInstance() return the same instance.

//Technical Constraints:
//•	Use private constructor.
//•	Use static instance variable.
//•	Use thread-safe implementation (basic level optional).
//•	Console application using C# (.NET).
//Expectations:
//Students should:
//•	Prevent object creation using new.
//•	Access instance using:
//	ConfigurationManager.GetInstance()
//•	Print configuration details from multiple method calls.
//Learning Outcome:
//After completing this problem, learners will understand:
//•	Why Singleton is used
//•	How to restrict object creation
//•	Global shared objects
//•	Basic design pattern implementation in C#


using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week6_Day1.Problem_Statement_5
{
    public class Program
    {
        static void Main(string[] args)
        {
            // First call
            ConfigurationManager config1 = ConfigurationManager.GetInstance();

            // Second call
            ConfigurationManager config2 = ConfigurationManager.GetInstance();

            // Print values
            Console.WriteLine("From Config1:");
            PrintConfig(config1);

            Console.WriteLine("\nFrom Config2:");
            PrintConfig(config2);

            // Check same instance
            Console.WriteLine("\nAre both instances same? " +
                (config1 == config2));
        }

        static void PrintConfig(ConfigurationManager config)
        {
            Console.WriteLine("App Name: " + config.ApplicationName);
            Console.WriteLine("Version: " + config.Version);
            Console.WriteLine("DB Connection: " + config.DatabaseConnectionString);
        }
    }
}
