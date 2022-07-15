using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.IO.Contracts
{
    public class Writer : IWriter
    {
        public void Write(string message)
        {
           Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
