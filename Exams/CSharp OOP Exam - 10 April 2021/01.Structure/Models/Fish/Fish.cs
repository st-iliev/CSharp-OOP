﻿using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        private string name;
        private string species;
        private decimal price;

        protected Fish(string name, string species, decimal price)
        {
            this.name = name;
            this.species = species;
            this.price = price;
        }

        public string Name => throw new NotImplementedException();

        public string Species => throw new NotImplementedException();

        public int Size => throw new NotImplementedException();

        public decimal Price => throw new NotImplementedException();

        public abstract void Eat();
        
    }
}
