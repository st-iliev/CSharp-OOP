using System;
using System.Collections.Generic;
using System.Text;
using Telephony.IO.Interfaces;

namespace Telephony.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string readLine = Console.ReadLine();
            return readLine;
        }
    }
}
