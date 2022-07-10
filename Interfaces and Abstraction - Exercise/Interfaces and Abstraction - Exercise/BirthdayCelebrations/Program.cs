using BirthdayCelebrations.Core;
using BirthdayCelebrations.IO;
using BirthdayCelebrations.IO.Interfaces;
using System;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(writer,reader);
            engine.Run();
        }
    }
}
