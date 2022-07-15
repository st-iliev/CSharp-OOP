using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.IO.Contracts;

namespace WildFarm.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
