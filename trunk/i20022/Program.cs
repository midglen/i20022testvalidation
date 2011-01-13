using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using i20022;
using i20022.acmt00200102;
using System.IO;

namespace i20022
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string xml = File.ReadAllText("C:/Users/jpfse/Documents/My Dropbox/Documentos/IST/RGI/Projecto/msg1002/Business Areas/Account Management/acmt.002.001.02.xml");
            MessageDocument md = new MessageDocument(xml);
            i20022.acmt00200102.Document newObject = (i20022.acmt00200102.Document) md.ToObject();
            string temp = newObject.ToString();*/
            XmlValidator validator = new XmlValidator();
            validator.validate("C:/Users/jpfse/Documents/My Dropbox/Documentos/IST/RGI/Projecto/msg1002/Business Areas/Account Management/acmt.006.001.02.xml","C:/Users/jpfse/Documents/My Dropbox/Documentos/IST/RGI/Projecto/msg1002/Business Areas/Account Management/acmt.001.001.02.xsd");
            //Console.WriteLine(temp);
            Console.ReadLine();
        }
    }
}
