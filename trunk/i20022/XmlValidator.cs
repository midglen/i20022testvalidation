using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Text;

namespace i20022
{
    class XmlValidator
    {

        public static void ValidationHandler(object sender, ValidationEventArgs args)
        {
            Console.WriteLine(args.Message + "\r\n");
        }

        public Boolean validate(String xmlPath, String schemaPath)
        {
            string xml = File.ReadAllText(xmlPath);
            string scm = File.ReadAllText(schemaPath);
            XmlSchema schema = XmlSchema.Read(scm, ValidationHandler);
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, schema);
            XmlReader reader = XmlReader.Create(xmlPath, settings);
            bool res = reader.Read();
            Console.WriteLine(reader.SchemaInfo.ToString());
            //Console.WriteLine(res);
            return true;
        }
    }
}
