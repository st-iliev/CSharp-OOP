using System.Collections.Generic;
using System.Text;
using BorderControl.IO.Interfaces;

namespace BorderControl.IO
{
using System;
    public class ConsoleWriter : IWriter

    {
        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }
    }
}
