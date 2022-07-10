using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models
{
    public class Citizens : ILeaveable
    {
        public Citizens(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }

        public string Leave(string id)
        {
            return id;
        }
    }
}
