using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private IRepository<IHero> heroes;
        private IRepository<IWeapon> weapons;
        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if (heroes.FindByName(heroName) == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            else if (weapons.FindByName(weaponName) == null)
            {
                throw new InvalidOperationException($"Weapon  {weaponName} does not exist.");
            }
            var currentHero = heroes.FindByName(heroName);
            var currentWeapon = weapons.FindByName(weaponName);
            if (currentHero.Weapon != null)
            {
                throw new InvalidCastException($"Hero {heroName} is well-armed.");
            }
            currentHero.AddWeapon(currentWeapon);
            this.weapons.Remove(currentWeapon);

            return $"Hero {heroName} can participate in battle using a {currentHero.Weapon.GetType().Name.ToLower()}.";

        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero hero = null;
            if (heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }
            if (type != "Barbarian" && type != "Knight")
            {
                throw new InvalidOperationException("Invalid hero type.");
            }
            else
            {
                if (type == "Barbarian")
                {
                    hero = new Barbarian(name, health, armour);

                }
                else
                {
                    hero = new Knight(name, health, armour);
                }
            }
            heroes.Add(hero);
            return type == "Barbarian" ? $"Successfully added Barbarian {name} to the collection." : $"Successfully added Sir {name} to the collection.";
        }

        public string CreateWeapon(string type, string name, int durability)
        {           
            if (type != "Mace" && type != "Claymore")
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }
            if (type == "Mace")
            {
                weapons.Add(new Mace(name, durability));
            }
            else
            {
                weapons.Add(new Claymore(name, durability));
            }
            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var hero in heroes.Models.OrderBy(s => s.GetType().Name).ThenByDescending(s => s.Health).ThenBy(s => s.Name))
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                if (hero.Weapon == null)
                {
                    sb.AppendLine("--Weapon: Unarmed");
                }
                else
                {
                    sb.AppendLine($"--Weapon: {hero.Weapon.Name}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            Map map = new Map();
            return map.Fight(heroes.Models as ICollection<IHero>);
        }
    }
}
