using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection_and_Attributes___Exercise.CommandPattern.IO.Contracts
{
    public interface IWriter
    {
        void Write(string message);

        void WriteLine(string message);
    }
}
