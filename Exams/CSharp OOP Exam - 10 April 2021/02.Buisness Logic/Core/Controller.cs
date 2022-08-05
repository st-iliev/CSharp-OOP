using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();

        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;
            if (aquariumType != nameof(FreshwaterAquarium) && aquariumType != nameof(SaltwaterAquarium))
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
            if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            aquariums.Add(aquarium);
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decorator = null;
            if (decorationType != nameof(Ornament) && decorationType != nameof(Plant))
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
            if (decorationType == nameof(Ornament))
            {
                decorator = new Ornament();
            }
            else
            {
                decorator = new Plant();
            }
            decorations.Add(decorator);
            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(s => s.Name == aquariumName);
            IFish fish = null;
            if (fishType != nameof(FreshwaterFish) && fishType != nameof(SaltwaterFish))
            {
                throw new InvalidOperationException("Invalid fish type.");
            }
            if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
                if (aquarium.GetType().Name == "FreshwaterAquarium")
                {
                    aquarium.AddFish(fish);
                    return $"Successfully added {fishType} to {aquariumName}.";
                }
                else
                {
                    return $"Water not suitable.";
                }
            }
            else
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
                if (aquarium.GetType().Name == "SaltwaterAquarium")
                {
                    aquarium.AddFish(fish);
                    return $"Successfully added {fishType} to {aquariumName}.";
                }
                else
                {
                    return $"Water not suitable.";
                }
            }

        }

        public string CalculateValue(string aquariumName)
        {
            var aquar = aquariums.FirstOrDefault(s => s.Name == aquariumName);
            decimal decorationPrice = aquar.Decorations.Select(s => s.Price).Sum();
            decimal fishPrice = aquar.Fish.Select(s => s.Price).Sum();
            return $"The value of Aquarium {aquariumName} is {(decorationPrice + fishPrice):F2}.";
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(s => s.Name == aquariumName);
            aquarium.Feed();
            return $"Fish fed: {aquarium.Fish.Count}";

        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(s => s.Name == aquariumName);
            IDecoration decorator = decorations.FindByType(decorationType);
            if (decorator == null)
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
            aquarium?.AddDecoration(decorator);
            decorations.Remove(decorator);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquar in aquariums)
            {
                sb.AppendLine(aquar.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
