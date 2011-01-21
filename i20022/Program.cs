using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace i20022
{
    class Program
    {
        static void Main(string[] args)
        {
            //getting path to search files
            Console.WriteLine("Please, enter the path to search for files");
            string path = Console.ReadLine();

            //Applying read and write test
            ReadAndWriteTest.runTest(path);

            //Presenting final message
            Console.WriteLine("");
            Console.Write("Test is finished, please hit enter to end.");
            Console.ReadLine();
        }
    }
}
