using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private IBag bag;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Astronaut name cannot be null or empty.");
                }
                this.name = value;
            }
        }
        public double Oxygen
        {
            get => oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }
            }
        }
        public bool CanBreath => this.Oxygen > 0;

        public IBag Bag
        {
            get => bag;
            private set
            {
                this.bag = value;
            }
        }
        public virtual void Breath()
        {
            this.Oxygen -= 10;
        }
    }
}
