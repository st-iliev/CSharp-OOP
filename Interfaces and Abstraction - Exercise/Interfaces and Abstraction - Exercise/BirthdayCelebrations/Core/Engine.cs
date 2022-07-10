using BirthdayCelebrations.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BirthdayCelebrations.Core
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;

        public Engine(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

         public void Run()
        {
            string[] input = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<string> birthdays = new List<string>();
            while (input[0]!="End")
            {
                if (input[0] == "Citizen")
                {
                    string birthday = input[4];
                    birthdays.Add(birthday);
                }
                else if (input[0] == "Pet")
                {
                    string birthday = input[2];
                    birthdays.Add(birthday);
                }
                
                input = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            string date = reader.ReadLine();
            if (!birthdays.Any(s => s.Contains(date))) { }
            else
            {
                foreach (var bd in birthdays)
                {
                    if (bd.EndsWith(date))
                    {
                        this.writer.WriteLine(bd);
                    }
                }
            }
        }
    }
}
