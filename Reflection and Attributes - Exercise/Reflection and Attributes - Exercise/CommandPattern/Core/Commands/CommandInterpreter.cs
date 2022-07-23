using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Reflection_and_Attributes___Exercise.CommandPattern.Core.Commands
{
    class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commandSplit = args.Split();
            string commandName = commandSplit[0];
            string[] commandArgs = commandSplit.Skip(1).ToArray();

            Assembly assembly = Assembly.GetEntryAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(s => s.Name == $"{commandName}Command" && s.GetInterfaces().Any(s => s == typeof(ICommand)));

            object commandInstance = Activator.CreateInstance(type);
            MethodInfo method = type.GetMethods().First(s => s.Name == "Execute");
            string result = (string)method.Invoke(commandInstance, new object[] { commandArgs });

            return result;

        }
    }
}
