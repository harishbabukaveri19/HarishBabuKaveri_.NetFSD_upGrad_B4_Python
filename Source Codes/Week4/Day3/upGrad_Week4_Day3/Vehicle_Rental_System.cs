//Level - 2 Problem 5: Vehicle Rental System
//Scenario:
//A vehicle rental company wants a system where different vehicle types calculate rental charges differently.
//Requirements:
//1.Create a base class Vehicle with properties Brand and RentalRatePerDay.
//2. Create derived classes Car and Bike.
//3. Override CalculateRental(int days) method.
//4. Car adds insurance charge of 500 per rental.
//5. Bike offers 5% discount on total rental.
//Technical Constraints:
//• Use encapsulation with proper access modifiers.
//• Apply runtime polymorphism.
//• Validate number of rental days.
//Expectations:
//• Use base class reference to call overridden methods.
//• Implement clean class hierarchy.
//• Display final rental cost.
//Learning Outcome:
//• Master inheritance and polymorphism.
//• Implement real-world OOP scenarios.
//• Improve object-oriented design skills.
//Sample Input: 
//Car RentalRatePerDay = 2000, Days = 3
//Sample Output: 
//Total Rental = 6500


using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week4_Day3
{
    internal class Vehicle_Rental_System
    {
        // Base Class
        class Vehicle
        {
            public string Brand { get; set; }

            private double rentalRatePerDay;

            // Encapsulation with validation
            public double RentalRatePerDay
            {
                get { return rentalRatePerDay; }
                set
                {
                    if (value < 0)
                    {
                        Console.WriteLine("Rental rate cannot be negative. Setting to 0.");
                        rentalRatePerDay = 0;
                    }
                    else
                    {
                        rentalRatePerDay = value;
                    }
                }
            }

            // Virtual Method
            public virtual double CalculateRental(int days)
            {
                return RentalRatePerDay * days;
            }
        }

        // Derived Class: Car
        class Car : Vehicle
        {
            public override double CalculateRental(int days)
            {
                return (RentalRatePerDay * days) + 500; // Insurance charge
            }
        }

        // Derived Class: Bike
        class Bike : Vehicle
        {
            public override double CalculateRental(int days)
            {
                double total = RentalRatePerDay * days;
                return total - (0.05 * total); // 5% discount
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Enter vehicle type (Car/Bike): ");
                string type = Console.ReadLine();

                Console.WriteLine("Enter brand: ");
                string brand = Console.ReadLine();

                Console.WriteLine("Enter rental rate per day: ");
                double rate = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter number of days: ");
                int days = Convert.ToInt32(Console.ReadLine());

                // Validate days
                if (days <= 0)
                {
                    Console.WriteLine("Invalid number of days.");
                    return;
                }

                Vehicle vehicle;

                // Runtime Polymorphism
                if (type.ToLower() == "car")
                {
                    vehicle = new Car();
                }
                else
                {
                    vehicle = new Bike();
                }

                vehicle.Brand = brand;
                vehicle.RentalRatePerDay = rate;

                double total = vehicle.CalculateRental(days);

                Console.WriteLine("Total Rental = " + total);
            }
        }
    }
}