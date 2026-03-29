//Problem 4 – Level 2
//Scenario:
//A development team wants to analyze all folders inside a project directory to understand the project structure.
//Requirements:
//1.Accept a root directory path.
//2. Display all subdirectories inside the root folder.
//3. Show the number of files present in each directory.
//Technical Constraints:
//• Use DirectoryInfo class.
//• Use loops to iterate through directories.
//• Implement exception handling.
//Expectations:
//The application should display folder names and file counts for each directory.
//Learning Outcome:
//Students will learn how to navigate directories and retrieve folder information using DirectoryInfo.


using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week5_Day2
{
    internal class ProblemStatement4
    {
        static void Main(string[] args)
        {
            Console.Write("Enter root directory path: ");
            string path = Console.ReadLine();

            // Validate directory
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Invalid directory path!");
                return;
            }

            try
            {
                DirectoryInfo root = new DirectoryInfo(path);

                DirectoryInfo[] directories = root.GetDirectories();

                if (directories.Length == 0)
                {
                    Console.WriteLine("No subdirectories found.");
                    return;
                }

                Console.WriteLine("\n===== DIRECTORY ANALYSIS =====\n");

                foreach (DirectoryInfo dir in directories)
                {
                    FileInfo[] files = dir.GetFiles();

                    Console.WriteLine("Folder Name : " + dir.Name);
                    Console.WriteLine("File Count  : " + files.Length);
                    Console.WriteLine("----------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
