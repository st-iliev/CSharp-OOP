using System;
using Vehicles.Core;
using Vehicles.IO;
using Vehicles.IO.Contracts;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();
            IEngine engine = new Engine(reader,writer);
            engine.Run();
        }
    }
}
