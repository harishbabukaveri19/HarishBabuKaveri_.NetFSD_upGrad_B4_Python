/* Problem 2 – Level 1:
Scenario:
An administrator wants to check file properties stored in a particular folder for auditing purposes.
Requirements:
1.Accept a folder path from the user.
2. Display file name, file size, and creation date.
3. Count and display the total number of files.
Technical Constraints:
• Use FileInfo class.
• Handle invalid directory paths.
Expectations:
The program should list file details clearly in the console.
Learning Outcome:
Students will understand how to retrieve file metadata using FileInfo. */

using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week5_Day2
{
    internal class ProblemStatement2
    {
        static void Main(string[] args)
        {
            Console.Write("Enter folder path: ");
            string folderPath = Console.ReadLine();

            // Check if directory exists
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Invalid directory path!");
                return;
            }

            try
            {
                string[] files = Directory.GetFiles(folderPath);

                if (files.Length == 0)
                {
                    Console.WriteLine("No files found in the directory.");
                    return;
                }

                Console.WriteLine("\n===== FILE DETAILS =====\n");

                int count = 0;

                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);

                    Console.WriteLine("File Name   : " + fileInfo.Name);
                    Console.WriteLine("File Size   : " + fileInfo.Length + " bytes");
                    Console.WriteLine("Created On  : " + fileInfo.CreationTime);
                    Console.WriteLine("----------------------------");

                    count++;
                }

                Console.WriteLine($"\nTotal Files: {count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
