using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using i20022.acmt00100102;
using System.Xml.Serialization;
using System.IO;

namespace i20022
{
    class AccountManagementTest
    {
        private string directory = "/i20022tests/AccountManagement/";

        private void writeToXmlFile(Document document, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Document));
            TextWriter tw = new StreamWriter(path);
            serializer.Serialize(tw, document);
            tw.Close(); 
        }

        public void testAcmt00100102()
        {
            Document document = new Document();
            document.AcctOpngInstrV02 = new AccountOpeningInstructionV02();
            document.AcctOpngInstrV02.MsgId = new MessageIdentification1();
            document.AcctOpngInstrV02.MsgId.Id = "message ID";
            document.AcctOpngInstrV02.MsgId.CreDtTm = new DateTime(2011, 1, 4);
            document.AcctOpngInstrV02.InstrDtls = new InvestmentAccountOpeningDetails();
            document.AcctOpngInstrV02.InstrDtls.OpngTp = AccountOpeningType1Code.NEWA;
            document.AcctOpngInstrV02.InvstmtAcct = new InvestmentAccount26();
            document.AcctOpngInstrV02.InvstmtAcct.Item1 = AccountOwnershipType3Code.JOIT;
            document.AcctOpngInstrV02.AcctPties = new AccountParties5();

            //Write the Mandatorie elements xml file to file system
            writeToXmlFile(document, directory + "acmt.001.001.02/acmt.001.001.02.Mandatories.xml");
        }
    }
}
