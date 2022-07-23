using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection_and_Attributes___Exercise.CommandPattern.Core.Commands
{
    public class ExitCommand : ICommand
    {
        private const int successExitCode = 0;
        public string Execute(string[] args)
        {
            Environment.Exit(successExitCode);
            return null;
        }
    }
}
