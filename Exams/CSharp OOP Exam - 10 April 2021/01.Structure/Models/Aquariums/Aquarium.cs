using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;

        protected Aquarium(string name, int capacity)
        {
            this.name = name;
            this.capacity = capacity;
        }

        public string Name => throw new NotImplementedException();

        public int Capacity => throw new NotImplementedException();

        public int Comfort => throw new NotImplementedException();

        public ICollection<IDecoration> Decorations => throw new NotImplementedException();

        public ICollection<IFish> Fish => throw new NotImplementedException();

        public void AddDecoration(IDecoration decoration)
        {
            throw new NotImplementedException();
        }

        public void AddFish(IFish fish)
        {
            throw new NotImplementedException();
        }

        public void Feed()
        {
            throw new NotImplementedException();
        }

        public string GetInfo()
        {
            throw new NotImplementedException();
        }

        public bool RemoveFish(IFish fish)
        {
            throw new NotImplementedException();
        }
    }
}
