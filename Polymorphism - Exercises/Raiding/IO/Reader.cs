using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.IO.Contracts
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
