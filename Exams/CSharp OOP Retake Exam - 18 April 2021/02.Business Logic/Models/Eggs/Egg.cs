using Easter.Models.Eggs.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private string name;
        private int energyRequired;

        public Egg(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Egg name cannot be null or empty.");
                }
                this.name = value;
            }
        }
        public int EnergyRequired
        {
            get => energyRequired;
            private set
            {
                energyRequired = value;
                if (energyRequired < 0)
                {
                    energyRequired = 0;
                }
               
            }
        }
        public void GetColored() => this.EnergyRequired -= 10;


        public bool IsDone() => this.EnergyRequired == 0;
       
    }
}
