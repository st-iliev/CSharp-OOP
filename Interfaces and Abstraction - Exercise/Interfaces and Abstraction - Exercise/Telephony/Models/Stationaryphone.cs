using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class Stationaryphone : ICallable
    {
        public string Call(string number)
        {
            return $"Dialing... {number}";
        }
    }
}
