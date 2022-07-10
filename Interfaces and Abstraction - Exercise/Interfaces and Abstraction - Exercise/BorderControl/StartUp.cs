using Border_Control.Core;
using BorderControl.IO;
using BorderControl.IO.Interfaces;
using System;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
