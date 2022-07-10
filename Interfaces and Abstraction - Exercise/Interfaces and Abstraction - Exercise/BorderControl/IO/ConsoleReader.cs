using System;
using System.Collections.Generic;
using System.Text;
using BorderControl.IO.Interfaces;

namespace BorderControl.IO
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
