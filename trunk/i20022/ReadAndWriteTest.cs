using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using i20022;
using i20022.Reporting;
using i20022.acmt00100102;
using System.Xml.Serialization;
using System.IO;

namespace i20022
{
    static class ReadAndWriteTest
    {
        public static void runTest(string path, Report report)
        {
            Console.WriteLine("...");
            Console.Write("Starting Read and Write Test for file: " + path + "...");

            //Creating report information
            report.addInNewLine("Message: " + path);

            String xml = File.ReadAllText(path);
            MessageObject mo = null;
            MessageDocument md = null;
            Object document = null;

            try
            {
                //Creating report information
                report.addInNewLine("   Convertion XML to Object: ");
                md = new MessageDocument(xml);
                document = md.ToObject();
            }
            catch (Exception e)
            {
                Console.WriteLine("#### ERROR transforming XML to object ####");
                Console.WriteLine(e.Message);
                //Creating report information
                report.add("ERROR, problem: " + e.Message);
                report.increaseErrors();
                return;
            }

            //Creating report information
            report.add("OK!");

            try
            {
                //Creating report information
                report.addInNewLine("   Convertion Object to XML: ");
                mo = new MessageObject(document);
            }
            catch (Exception e)
            {
                Console.WriteLine("#### ERROR transforming object to XML ####");
                Console.WriteLine(e.Message);
                //Creating report information
                report.add("ERROR, problem: " + e.Message);
                report.increaseErrors();
                return;
            }

            File.WriteAllText(path + ".rw.test", mo.ToXml());
            Console.WriteLine(" Done!!!");
            //Creating report information
            report.add("OK!");
            report.increaseOks();

            //test squema compliance
            Console.Write("Test schema compliance...");
            //Creating report information
            report.addInNewLine("             XSD Validation: OK!");
        }
    }
}
