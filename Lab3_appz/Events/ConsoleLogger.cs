using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_appz.Events
{
    public class ConsoleLogger : IObserver
    {
        public void Update(string message)
        {
            Printer.Print(message);
        }
    }
}
