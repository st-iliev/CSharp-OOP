﻿using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public abstract class Decoration : IDecoration
    {
        private int comfort;
        private decimal price;
        public Decoration(int comfort,decimal price)
        {
            this.comfort = comfort;
            this.price = price;
        }
        public int Comfort => throw new NotImplementedException();

        public decimal Price => throw new NotImplementedException();
    }
}
