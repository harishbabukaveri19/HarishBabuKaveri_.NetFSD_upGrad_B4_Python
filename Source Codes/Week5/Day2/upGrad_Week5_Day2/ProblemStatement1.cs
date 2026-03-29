/* Problem 1 – Level 1
Scenario:
A small organization wants to store simple log messages into a text file using a C# console application.
Requirements:
1.Accept a message from the user.
2. Write the message into a file using FileStream.
3.Append multiple messages to the same file.
4. Display confirmation after writing the data.
Technical Constraints:
• Use FileStream class.
• Use appropriate FileMode and FileAccess.
• Implement exception handling for file access errors.
Expectations:
The application should successfully write user messages to the file and allow multiple entries.
Learning Outcome:
Students will learn how to create and write data into files using FileStream.*/


using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week5_Day2
{
    internal class ProblemStatement1
    {
        static void Main()
        {
            string filePath = @"D:\\Visual Studio Data\\upGrad_Week5_Day2\\log.txt.txt\";

            try
            {
                while (true)
                {
                    Console.Write("Enter your message (type 'exit' to stop): ");
                    string message = Console.ReadLine();

                    if (message.ToLower() == "exit")
                        break;

                    // Convert string to byte array
                    byte[] data = Encoding.UTF8.GetBytes(message + Environment.NewLine);

                    // FileStream with Append mode
                    using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                    {
                        fs.Write(data, 0, data.Length);
                    }

                    Console.WriteLine("Message written successfully!\n");
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: You do not have permission to access the file.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("File error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }

            Console.WriteLine("Application closed.");
        }
    }
}