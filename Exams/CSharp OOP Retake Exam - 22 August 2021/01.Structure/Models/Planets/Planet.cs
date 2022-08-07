using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private ICollection<string> items;

        public Planet(string name)
        {
            this.Name = name;
            this.items = new List<string>();
        }

        public ICollection<string> Items => items;
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid name!");
                }
                this.name = value;
            }
           
        }
    }
}
