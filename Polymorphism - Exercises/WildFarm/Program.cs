using System;
using WildFarm.Core;
using WildFarm.IO;
using WildFarm.IO.Contracts;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IWriter writer = new Writer();
            IReader reader = new Reader();
            IEngine engine = new Engine(writer, reader);
            engine.Run();
        }
    }
}
