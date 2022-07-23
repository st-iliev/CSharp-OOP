using CommandPattern.Core.Contracts;
using Reflection_and_Attributes___Exercise.CommandPattern.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection_and_Attributes___Exercise.CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        private readonly IWriter writer;
        private readonly IReader reader;
        public Engine(ICommandInterpreter commandInterpreter,IReader reader , IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            while (true)
            {
                string input = this.reader.ReadLine();
                string result = this.commandInterpreter.Read(input);
                this.writer.WriteLine(result);
            }
        }
    }
}
