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
        public static void runTest(string path)
        {
            Console.WriteLine("");
            Console.Write("Starting Read and Write Test for file: " + path + "...");
            String xml = File.ReadAllText(path);
            MessageObject mo = null;
            MessageDocument md = null;
            try
            {
                md = new MessageDocument(xml);
                Object document = md.ToObject();
                mo = new MessageObject(document);
            }
            catch (Exception e)
            {
                Console.WriteLine("#### ERROR ####");
                return;
            }
            File.WriteAllText(path + ".rw.test", mo.ToXml());
            Console.WriteLine(" Done!!!");
        }
    }
}
