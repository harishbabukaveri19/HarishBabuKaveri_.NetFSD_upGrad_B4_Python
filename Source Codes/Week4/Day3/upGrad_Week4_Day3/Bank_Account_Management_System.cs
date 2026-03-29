//Level - 2 Problem 2: Bank Account Management System
//Scenario:
//A bank wants to develop a simple console-based application to manage customer bank accounts. The system should protect account balance information and allow controlled access using properties.
//Requirements:
//1.Create a BankAccount class with private fields for account number and balance.
//2.Use properties to allow controlled access to account number and balance.
//3.Implement Deposit and Withdraw methods with proper validation.
//4.Prevent withdrawal if balance is insufficient.
//Technical Constraints:
//• Use private fields with public properties.
//• Apply encapsulation and data hiding.
//• No direct access to balance field from outside the class.
//Expectations:
//• Demonstrate correct use of access modifiers.
//• Validate negative deposit or withdrawal amounts.
//• Display updated balance after each transaction.
//Learning Outcome:
//• Understand encapsulation using properties.
//• Apply data hiding effectively.
//• Implement validation logic inside class methods.
//Sample Input: 
//Deposit = 5000, Withdraw = 2000
//Sample Output: 
//Current Balance = 3000


using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week4_Day3
{
    internal class Bank_Account_Management_System
    {
        class BankAccount
        {
            // Private fields
            private string accountNumber;
            private double balance;

            // Public property for Account Number
            public string AccountNumber
            {
                get { return accountNumber; }
                set
                {
                    if (!string.IsNullOrEmpty(value))
                        accountNumber = value;
                    else
                        Console.WriteLine("Invalid account number.");
                }
            }

            // Public property for Balance (Read-only outside)
            public double Balance
            {
                get { return balance; }
                private set { balance = value; } // only modified inside class
            }

            // Deposit method
            public void Deposit(double amount)
            {
                if (amount > 0)
                {
                    Balance += amount;
                    Console.WriteLine("Deposited: " + amount);
                    Console.WriteLine("Current Balance = " + Balance);
                }
                else
                {
                    Console.WriteLine("Invalid deposit amount.");
                }
            }

            // Withdraw method
            public void Withdraw(double amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Invalid withdrawal amount.");
                }
                else if (amount > Balance)
                {
                    Console.WriteLine("Insufficient balance.");
                }
                else
                {
                    Balance -= amount;
                    Console.WriteLine("Withdrawn: " + amount);
                    Console.WriteLine("Current Balance = " + Balance);
                }
            }
        }

        class Program
        {
            static void Main()
            {
                BankAccount account = new BankAccount();

                Console.Write("Enter Account Number: ");
                account.AccountNumber = Console.ReadLine();

                Console.Write("Enter Deposit Amount: ");
                double deposit = Convert.ToDouble(Console.ReadLine());
                account.Deposit(deposit);

                Console.Write("Enter Withdraw Amount: ");
                double withdraw = Convert.ToDouble(Console.ReadLine());
                account.Withdraw(withdraw);
            }
        }
    }
}