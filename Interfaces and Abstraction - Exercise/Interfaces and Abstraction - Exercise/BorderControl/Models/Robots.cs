using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models
{
    public class Robots : ILeaveable
    {
        private string model;
        private string id;

        public Robots(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model { get; set; }
        public string Id { get; set; }

        public string Leave(string id)
        {
            return id;
        }
    }
}
