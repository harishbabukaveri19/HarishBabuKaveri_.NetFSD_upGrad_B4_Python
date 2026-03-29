using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week6_Day1.Problem_Statement_4
{
    public class AdvancedPrinter : IPrinter, IScanner, IFax
    {
        public void Print()
        {
            Console.WriteLine("Advanced Printer: Printing...!");
        }

        public void Scan()
        {
            Console.WriteLine("Advanced Printer: Scanning...!");
        }

        public void Fax()
        {
            Console.WriteLine("Advanced Printer: Sending Fax...!");
        }
    }
}
