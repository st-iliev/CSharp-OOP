using CommandPattern.Core.Contracts;
using Reflection_and_Attributes___Exercise.CommandPattern.Core;
using Reflection_and_Attributes___Exercise.CommandPattern.Core.Commands;
using Reflection_and_Attributes___Exercise.CommandPattern.IO;
using Reflection_and_Attributes___Exercise.CommandPattern.IO.Contracts;
using System;

/*namespace CommandPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command,reader,writer);
            engine.Run();
        }
    }
}
*/