//Level - 2 Problem 1: Employee Management Using Linked List
//Scenario:
//A company wants to maintain employee records dynamically using a Linked List structure.
//Requirements:
//-Create Node structure with employee ID and name.
//- Implement insertion at beginning and end.
//- Implement deletion by employee ID.
//- Traverse and display employee list.
//Technical Constraints:
//-Must implement singly linked list.
//- No use of built-in list structures.
//- Proper memory handling and pointer updates.
//Sample Input:
//Insert: (101, John), (102, Sara), (103, Mike)
//Delete: 102
//Sample Output:
//Employee List After Deletion:
//101 - John
//103 – Mike


//Expectations:
//-Correct node linking.
//-Efficient traversal logic.
//-Clean insertion and deletion operations.
//Learning Outcome:
//-Understand linked list structure.
//- Perform insertion and deletion operations.
//- Learn dynamic data structure behavior.


using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week4_Day4
{
    internal class Employee_Management_Using_Linked_List
    {
        // Node class
        class Node
        {
            public int EmpId;
            public string Name;
            public Node Next;

            public Node(int empId, string name)
            {
                EmpId = empId;
                Name = name;
                Next = null;
            }
        }

        // Linked List class
        class EmployeeLinkedList
        {
            private Node head;

            // Insert at end
            public void Insert(int id, string name)
            {
                Node newNode = new Node(id, name);

                if (head == null)
                {
                    head = newNode;
                    return;
                }

                Node temp = head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }

                temp.Next = newNode;
            }

            // Delete by ID
            public void Delete(int id)
            {
                if (head == null)
                {
                    Console.WriteLine("List is empty");
                    return;
                }

                if (head.EmpId == id)
                {
                    head = head.Next;
                    Console.WriteLine("Employee deleted successfully.");
                    return;
                }

                Node current = head;
                Node previous = null;

                while (current != null && current.EmpId != id)
                {
                    previous = current;
                    current = current.Next;
                }

                if (current == null)
                {
                    Console.WriteLine("Employee not found");
                    return;
                }

                previous.Next = current.Next;
                Console.WriteLine("Employee deleted successfully.");
            }

            // Display
            public void Display()
            {
                if (head == null)
                {
                    Console.WriteLine("No employees found.");
                    return;
                }

                Console.WriteLine("\nEmployee List:");
                Node temp = head;
                while (temp != null)
                {
                    Console.WriteLine($"{temp.EmpId} - {temp.Name}");
                    temp = temp.Next;
                }
            }
        }

        // Main method
        static void Main(string[] args)
        {
            EmployeeLinkedList list = new EmployeeLinkedList();

            while (true)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Delete Employee");
                Console.WriteLine("3. Display All Employees");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Try again.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Employee ID: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();

                        list.Insert(id, name);
                        Console.WriteLine("Employee added successfully.");
                        break;

                    case 2:
                        Console.Write("Enter Employee ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        list.Delete(deleteId);
                        break;

                    case 3:
                        list.Display();
                        break;

                    case 4:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}