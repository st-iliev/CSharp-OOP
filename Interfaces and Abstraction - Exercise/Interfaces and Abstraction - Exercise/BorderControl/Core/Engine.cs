using BorderControl.IO.Interfaces;
using BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly List<Citizens> humans;
        private readonly List<Robots> robots;
        public Engine()
        {
            this.humans = new List<Citizens>();
            this.robots = new List<Robots>();
        }
        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] incomming = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<string> ids = new List<string>();
            while (incomming[0] != "End")
            {
                if (incomming.Length == 3)
                {
                    string name = incomming[0];
                    string id = incomming[2];
                    ids.Add(id);
                }
                else if (incomming.Length == 2)
                {
                    string model = incomming[0];
                    string id = incomming[1];
                    ids.Add(id);
                }
                    incomming = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            string number = this.reader.ReadLine();
            foreach (var id in ids)
            {
                if (id.EndsWith(number))
                {
                    this.writer.WriteLine(id);
                }
            }
        }
    }
}
