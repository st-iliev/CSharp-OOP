using BirthdayCelebrations.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations.IO
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
