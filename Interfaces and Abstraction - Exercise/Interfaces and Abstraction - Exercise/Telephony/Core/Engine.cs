using System.Collections.Generic;
using System.Text;

namespace Telephony.Core
{
    using System;
    using Telephony.IO.Interfaces;
    using Telephony.Models;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly Stationaryphone stationaryPhone;
        private readonly Smartphone smartPhone;

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public Engine()
        {
            this.stationaryPhone = new Stationaryphone();
            this.smartPhone = new Smartphone();
        }

        public void Run()
        {
            string[] phoneNumbers = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var number in phoneNumbers)
            {
                if (!this.ValidateNumber(number))
                {
                    this.writer.WriteLine("Invalid number!");
                }
                else if (number.Length == 10)
                {
                    this.writer.WriteLine(smartPhone.Call(number));
                }
                else if (number.Length == 7)
                {
                    this.writer.WriteLine(stationaryPhone.Call(number));
                }
            }
            foreach (var url in urls)
            {
                if (!ValidateURL(url))
                {
                    this.writer.WriteLine("Invalid URL!");
                }
                else
                {
                    this.writer.WriteLine(smartPhone.Browse(url));
                }
            }
        }
        private bool ValidateNumber(string number)
        {
            foreach (var digit in number)
            {
                if (!char.IsDigit(digit))
                {
                    return false;
                }
            }
            return true;
        }
        private bool ValidateURL(string url)
        {
            foreach (var @char in url)
            {
                if (char.IsDigit(@char))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
