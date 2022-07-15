using System;
using System.Linq;
using System.Collections.Generic;
using static Raiding.Factory.HeroesFactory;
using Raiding;
using Raiding.IO.Contracts;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private HeroFactory heroFactory;
        
        public Engine(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
            this.heroFactory = new HeroFactory();
        }

        public void Run()
        {

            int numberOfHeroes = int.Parse(this.reader.ReadLine());

            List<BaseHero> heroes = new List<BaseHero>();
            while (heroes.Count != numberOfHeroes)
            {
                string name = this.reader.ReadLine();
                string type = this.reader.ReadLine();
                try
                {
                    BaseHero hero = this.heroFactory.ProduceHero(name, type);
                    heroes.Add(hero);
                }
                catch (Exception e)
                {
                    this.writer.WriteLine(e.Message);
                }
            }

            long bossPower = long.Parse(this.reader.ReadLine());

            long herosPowerSum = 0;

            if (heroes.Any())
            {
                foreach (var hero in heroes)
                {
                    this.writer.WriteLine(hero.CastAbility());
                }
                herosPowerSum = heroes.Sum(s => s.Power);

                if (herosPowerSum >= bossPower)
                {
                    this.writer.WriteLine("Victory!");
                }
                else
                {
                    this.writer.WriteLine("Defeat...");
                }
            }
        }
    }
}