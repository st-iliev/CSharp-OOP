﻿using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private ICollection<IDye> dyes;

        protected Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.dyes = new List<IDye>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Bunny name cannot be null or empty.");
                }
                this.name = value;
            }
        }
        public int Energy
        {
            get => energy;
            protected set
            {
                if (value < 0)
                {
                    energy = 0;
                }
                this.energy = value;
            }
        }


        public ICollection<IDye> Dyes => dyes;

        public void AddDye(IDye dye) => dyes.Add(dye);


        public virtual void Work() => this.Energy -= 10;
        
    }
}
