using Raiding.Core;
using Raiding.IO.Contracts;
using System;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();
            IEngine engine = new Engine(writer, reader);
            engine.Run();
        }
    }
}
