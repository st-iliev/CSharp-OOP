using FoodShortage.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }
    }
}
