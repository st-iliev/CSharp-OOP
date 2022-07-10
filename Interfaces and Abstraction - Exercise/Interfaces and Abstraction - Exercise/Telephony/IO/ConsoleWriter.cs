using System.Collections.Generic;
using System.Text;
using Telephony.IO.Interfaces;

namespace Telephony.IO
{
using System;
    public class ConsoleWriter : IWriter

    {
        public void Write(string input)
        {
            Console.Write(input);
        }

        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }
    }
}
