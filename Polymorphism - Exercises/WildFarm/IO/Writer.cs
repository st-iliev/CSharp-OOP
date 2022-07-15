using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.IO.Contracts;

namespace WildFarm.IO
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
