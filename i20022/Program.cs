using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace i20022
{
    class Program
    {

        private static void recursiveDirectorieSearchAndTestRun(string path, Report report)
        {
            //Get directory info
            string[] directories = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path, "*.xml");

            //handling found files
            if (files.GetLength(0) > 0)
                foreach (string f in files)
                {
                    report.addInNewLine("");
                    report.increaseCounter();
                    ReadAndWriteTest.runTest(f, report);
                }

            //handling found directories
            if (directories.GetLength(0) > 0)
                foreach (string d in directories)
                    recursiveDirectorieSearchAndTestRun(d, report);
        }

        static void Main(string[] args)
        {

            //getting path to search files
            Console.WriteLine("************** i20022 framework test tool *****************");
            Console.WriteLine("Your current directory is: " + Directory.GetCurrentDirectory());
            Console.WriteLine("Please, type the path to search for files or press enter to exit. Do not finish with /");
            string path = null;
            while (true)
            {
                path = Console.ReadLine();
                if (path.Equals("")) return;
                //testing path 
                try
                {
                    string[] directories = Directory.GetDirectories(path);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong path, please type path again or press enter to exit.");
                }
            }

            //creating new Report instance
            Report report = new Report();
            report.add("Teste and Validation of Framework i20022 (http://i20022.com/)");
            report.addInNewLine("Testbed: " + path);
            report.addInNewLine("");

            //Applying directory search and test run
            recursiveDirectorieSearchAndTestRun(path, report);

            //Creating Report
            Console.WriteLine("");
            Console.Write("Creating Report...");
            report.writeReportToFile(path);
            Console.WriteLine(" Done!!!");

            //Presenting final message
            Console.WriteLine("");
            Console.WriteLine("Number of Messages OK: " + report.getNumberOfOKMessages());
            Console.WriteLine("Number of Messages Error: " + report.getNumberErrorMessages());
            Console.WriteLine("Total Number of Messages: " + report.getNumberOfMessages());
            Console.Write("Test is finished, please press enter to exit.");
            Console.ReadLine();
        }
    }
}
