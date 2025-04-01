using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_appz
{
    static class Printer
    {
        public static void Print(string text)
        {
            Console.Clear();
            Console.WriteLine(text);
            Thread.Sleep(1000);
        }
    }
}
