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
            Console.Write("Starting Read and Write Test for file: " + path);
            String xml = File.ReadAllText(path);
            MessageDocument md = new MessageDocument(xml);
            Document document = (Document)md.ToObject();
            MessageObject mo = new MessageObject(document);
            File.WriteAllText(path + "-test.xml", mo.ToXml());
            Console.WriteLine(" Done!!!");
        }
    }
}
