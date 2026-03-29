////Level - 2 Problem 1: Bank Account with Encapsulation
////Scenario:
////A bank wants to manage customer accounts securely using encapsulation.
////Requirements:
////1.Create class BankAccount.
////2.Private field: balance.
////3.Public methods: Deposit(double amount), Withdraw(double amount).
////4.Method GetBalance() to return balance.
////5. Prevent withdrawal if insufficient balance.
////Technical Constraints:
////1.Balance must be private.
////2.Access balance only through public methods.
////3.Use appropriate return types.
////Expectations:
////Proper use of encapsulation and object-oriented principles.
////Learning Outcome:
////Understand encapsulation, access modifiers, and secure data handling.
////Sample Input: 
////Deposit 1000, Withdraw 300
////Sample Output: 
////Current Balance = 700


using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week4_Day3
{
    internal class Bank_Account_with_Encapsulation
    {
        class BankAccount
        {
            private double balance;

            public void Deposit(double amount)
            {
                if (amount > 0)
                {
                    balance += amount;
                }
                else
                {
                    Console.WriteLine("Invalid deposit amount.");
                }
            }

            public void Withdraw(double amount)
            {
                if (amount > 0 && amount <= balance)
                {
                    balance -= amount;
                }
                else
                {
                    Console.WriteLine("Insufficient balance or invalid amount.");
                }
            }
            public double GetBalance()
            {
                return balance;
            }
        }

        class Program
        {
            static void Main()
            {
                BankAccount account = new BankAccount();

                Console.Write("Enter amount to deposit: ");
                double depositAmount = Convert.ToDouble(Console.ReadLine());

                account.Deposit(depositAmount);

                Console.Write("Enter amount to withdraw: ");
                double withdrawAmount = Convert.ToDouble(Console.ReadLine());

                account.Withdraw(withdrawAmount);
                
                Console.WriteLine("Current Balance = " + account.GetBalance());
            }
        }
    }
}
