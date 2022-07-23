using Reflection_and_Attributes___Exercise.CommandPattern.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection_and_Attributes___Exercise.CommandPattern.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
           string line =  Console.ReadLine();
            return line;
        }
    }
}
