using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace i20022
{
    class Report
    {
        string report = "";
        int count = 0;
        int oks = 0;
        int errors = 0;

        public void add(string part)
        {
            report = report + part;
        }

        public void addInNewLine(string part)
        {
            report = report + "\r\n" + part;
        }

        public void increaseCounter()
        {
            count++;
        }

        public int getNumberOfMessages()
        {
            return count;
        }

        public void increaseOks()
        {
            oks++;
        }

        public int getNumberOfOKMessages()
        {
            return oks;
        }

        public void increaseErrors()
        {
            errors++;
        }

        public int getNumberErrorMessages()
        {
            return errors;
        }

        public void writeReportToFile(string path)
        {
            string aux = report + "\r\n\r\n" + "Number of Messages OK: " + getNumberOfOKMessages() + "\r\n";
            aux = aux + "Number of Messages Error: " + getNumberErrorMessages() + "\r\n";
            aux = aux + "Total Number of Messages: " + getNumberOfMessages();
            File.WriteAllText(path + "/Report.txt", aux);
        }

    }
}
