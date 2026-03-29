using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week6_Day1.Problem_Statement_5
{
    public class ConfigurationManager
    {
        // Static instance (single object)
        private static ConfigurationManager instance;

        // Lock object for thread safety
        private static readonly object lockObj = new object();

        // Private constructor (prevents new)
        private ConfigurationManager()
        {
            ApplicationName = "Inventory System";
            Version = "1.0.0";
            DatabaseConnectionString = "Server=.;Database=InventoryDB;Trusted_Connection=True;";
        }

        // Public method to get instance
        public static ConfigurationManager GetInstance()
        {
            // Thread-safe implementation
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = new ConfigurationManager();
                }
            }
            return instance;
        }

        // Configuration Properties
        public string ApplicationName { get; set; }
        public string Version { get; set; }
        public string DatabaseConnectionString { get; set; }
    }
}
