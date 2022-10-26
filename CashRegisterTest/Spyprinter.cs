using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister;
using Xunit.Sdk;

namespace CashRegisterTest
{
    public class SpyPrinter : Printer
    {
        public bool HasPrinted { get; set; }
        public override void Print(string content)
        {
            base.Print(content);
            HasPrinted = true;
        }
    }
}
