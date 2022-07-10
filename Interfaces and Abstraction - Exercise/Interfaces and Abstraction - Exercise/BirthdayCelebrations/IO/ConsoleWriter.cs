using BirthdayCelebrations.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }
    }
}
