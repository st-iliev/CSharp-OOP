using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;
        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name
        {
            get { return name; }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                this.name = value;
            }
        }
        public int Capacity { get; }

        public int Comfort => decorations.Select(s => s.Comfort).Sum();

        public ICollection<IDecoration> Decorations => decorations;

        public ICollection<IFish> Fish => fish;

        public void AddDecoration(IDecoration decoration) => decorations.Add(decoration);

        public void AddFish(IFish fish)
        {
            if (this.fish.Count + 1 > Capacity)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
            this.fish.Add(fish);
        }
       

        public void Feed()
        {
            foreach (var currentFish in this.fish)
            {
                currentFish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} ({this.GetType().Name}):");
            if (this.Fish.Count > 0)
            {
                sb.AppendLine($"Fish: {string.Join(", ", this.Fish.Select(s=>s.Name))}");
            }
            else
            {
                sb.AppendLine($"Fish: none");
            }
            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");
            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish) => this.Fish.Remove(fish);
       
    }
}
