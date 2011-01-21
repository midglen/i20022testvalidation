using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace i20022
{
    class Program
    {
        private static void recursiveDirectorieSearchAndTestRun(string path)
        {
            //Get directory info
            string[] directories = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path, "*.xml");

            //handling found files
            if (files.GetLength(0) > 0)
                foreach (string f in files)
                {
                    ReadAndWriteTest.runTest(f);
                }

            //handling found directories
            if (directories.GetLength(0) > 0)
                foreach (string d in directories)
                    recursiveDirectorieSearchAndTestRun(d);
        }

        static void Main(string[] args)
        {
            //getting path to search files
            Console.WriteLine("************** i20022 framework test tool *****************");
            Console.WriteLine("Your current directory is: " + Directory.GetCurrentDirectory());
            Console.WriteLine("Please, enter the path to search for files. Do not finish with /");
            string path = Console.ReadLine();

            //Applying directory search and test run
            recursiveDirectorieSearchAndTestRun(path);

            //Presenting final message
            Console.WriteLine("");
            Console.Write("Test is finished, please hit enter to end.");
            Console.ReadLine();
        }
    }
}
