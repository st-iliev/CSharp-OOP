using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.IO.Contracts
{
    public interface IWriter
    {
        void WriteLine(string message);
        void Write(string message);
    }
}
