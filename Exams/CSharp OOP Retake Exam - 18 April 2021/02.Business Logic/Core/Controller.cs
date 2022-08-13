using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Workshops.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Dyes.Contracts;

namespace Easter.Core
{
    public class Controller : IController
    {
        private readonly BunnyRepository bunnies;
        private readonly EggRepository eggs;
        private readonly IWorkshop workshop;
        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
            this.workshop = new Workshop();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;
            if (bunnyType != nameof(HappyBunny) && bunnyType != nameof(SleepyBunny))
            {
                throw new InvalidOperationException("Invalid bunny type.");
            }
            if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else
            {
                bunny = new SleepyBunny(bunnyName);
            }
            bunnies.Add(bunny);
            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = bunnies.FindByName(bunnyName);
            if (bunnies.FindByName(bunnyName) == null)
            {
                throw new InvalidOperationException("The bunny you want to add a dye to doesn't exist!");
            }
            IDye dye = new Dye(power);
            bunny.AddDye(dye);
            return $"Successfully added dye with power {power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);
            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            List<IBunny> bunny = bunnies.Models.Where(s => s.Energy >= 50).OrderByDescending(s => s.Energy).ToList();
            if (bunny.Count == 0)
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }
            IEgg egg = eggs.FindByName(eggName);
            foreach (var bun in bunny)
            {
                this.workshop.Color(egg, bun);
                if (bun.Energy == 0)
                {
                    bunnies.Remove(bun);
                }
                if (egg.IsDone())
                {
                    break;
                }
            }

            return $"Egg {eggName} is {(egg.IsDone() ? "done" : "not done")}.";

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{eggs.Models.Count(s => s.IsDone())} eggs are done!");
            sb.AppendLine("Bunnies info:");
            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count()} not finished");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
