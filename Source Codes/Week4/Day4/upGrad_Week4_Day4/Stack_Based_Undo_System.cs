//Level - 1 Problem 2: Stack - Based Undo System
//Scenario:
//Design a simple text editor undo feature using Stack (LIFO principle).
//Requirements:
//-Implement stack using arrays.
//-Support push(add action) and pop(undo action).
//-Display current state after each operation.
//Technical Constraints:
//-Only array - based stack implementation.
//-Must follow LIFO order strictly.
//- Handle empty stack condition.
//Sample Input:
//Actions: Type A, Type B, Type C, Undo, Undo
//Sample Output:
//Current State After Operations: Type A
//Expectations:
//-Correct LIFO implementation.
//-Proper error handling.
//-Clear logic structure.

//Learning Outcome:
//-Understand stack operations.
//-Learn LIFO principle application.
//- Implement stack using arrays.


using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week4_Day4
{
    internal class Stack_Based_Undo_System
    {
        class Stack
        {
            private string[] arr;
            private int top;
            private int size;

            public Stack(int size)
            {
                this.size = size;
                arr = new string[size];
                top = -1;
            }

            // Push operation (Add action)
            public void Push(string action)
            {
                if (top == size - 1)
                {
                    Console.WriteLine("Stack Overflow! Cannot add more actions.");
                    return;
                }

                arr[++top] = action;
                Console.WriteLine($"Action added: {action}");
                Display();
            }

            // Pop operation (Undo action)
            public void Pop()
            {
                if (top == -1)
                {
                    Console.WriteLine("Nothing to undo (Stack is empty)");
                    return;
                }

                Console.WriteLine($"Undo: {arr[top]}");
                top--;
                Display();
            }

            // Display current state
            public void Display()
            {
                if (top == -1)
                {
                    Console.WriteLine("Current State: Empty");
                    return;
                }

                Console.Write("Current State: ");
                for (int i = 0; i <= top; i++)
                {
                    Console.Write(arr[i]);
                    if (i != top) Console.Write(" -> ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter stack size: ");
            int size = int.Parse(Console.ReadLine());

            Stack stack = new Stack(size);

            while (true)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Add Action (Type)");
                Console.WriteLine("2. Undo Action");
                Console.WriteLine("3. Display Current State");
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
                        Console.Write("Enter action (e.g., Type A): ");
                        string action = Console.ReadLine();
                        stack.Push(action);
                        break;

                    case 2:
                        stack.Pop();
                        break;

                    case 3:
                        stack.Display();
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