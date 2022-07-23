using Reflection_and_Attributes___Exercise.CommandPattern.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection_and_Attributes___Exercise.CommandPattern.IO
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
