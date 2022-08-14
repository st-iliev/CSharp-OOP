using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;
        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IMilitaryUnit unit;
            if (planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            if (unitTypeName != nameof(AnonymousImpactUnit) && unitTypeName != nameof(SpaceForces) && unitTypeName != nameof(StormTroopers))
            {
                throw new InvalidOperationException($"{unitTypeName} still not available!");
            }
            if (unitTypeName == nameof(AnonymousImpactUnit))
            {
                unit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else
            {
                unit = new StormTroopers();
            }
            IPlanet planet = planets.FindByName(planetName);
            if (planet.Army.Any(s=>s.GetType().Name ==unit.GetType().Name))
            {
                throw new InvalidOperationException($"{unitTypeName} already added to the Army of {planetName}!");
            }
            if (planet.Budget >= unit.Cost)
            {
            planet.AddUnit(unit);
            planet.Spend(unit.Cost);
            }
            else
            {
                return $"Budget too low!";
            }
            return $"{unitTypeName} added successfully to the Army of {planetName}!";

        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = planets.FindByName(planetName);
            if (planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            if (planet.Weapons.Any(s => s.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException($"{weaponTypeName} already added to the Weapons of {planetName}!");
            }
            IWeapon weapon;
            if (weaponTypeName != nameof(BioChemicalWeapon) && weaponTypeName != nameof(NuclearWeapon) && weaponTypeName != nameof(SpaceMissiles))
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }
            if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            if (planet.Budget >= weapon.Price)
            {
                planet.Spend(weapon.Price);
                planet.AddWeapon(weapon);
            }
            else
            {
                return $"Budget too low!";
            }
            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.FindByName(name) != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }
            IPlanet planet = new Planet(name, budget);
            planets.AddItem(planet);
            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in planets.Models.OrderByDescending(s=>s.MilitaryPower).ThenBy(s=>s.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.FindByName(planetOne);
            IPlanet secondPlanet = planets.FindByName(planetTwo);
            double planet1Budget = firstPlanet.Budget;
            double planet2Budget = secondPlanet.Budget;
            double totalSum = 0;
            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {
                bool firstPlanetNuclear = firstPlanet.Weapons.Any(s => s.GetType().Name == "NuclearWeapon");
                bool secondPlanetNuclear = secondPlanet.Weapons.Any(s => s.GetType().Name == "NuclearWeapon");
                if (firstPlanetNuclear == true && secondPlanetNuclear == true || firstPlanetNuclear == false && secondPlanetNuclear == false)
                {
                    firstPlanet.Spend(planet1Budget / 2);
                    secondPlanet.Spend(planet2Budget / 2);
                    return "The only winners from the war are the ones who supply the bullets and the bandages!";
                }
                else if (firstPlanetNuclear == true && secondPlanetNuclear == false)
                {
                    firstPlanet.Spend(planet1Budget / 2);
                    firstPlanet.Profit(planet2Budget / 2);
                    totalSum = secondPlanet.Army.Sum(s => s.Cost) + secondPlanet.Weapons.Sum(s => s.Price);
                    firstPlanet.Profit(totalSum);
                    planets.RemoveItem(planetTwo);
                    return $"{planetOne} destructed {planetTwo}!";
                }
                else if (firstPlanetNuclear == false && secondPlanetNuclear == true)
                {
                    secondPlanet.Spend(planet2Budget / 2);
                    secondPlanet.Profit(planet1Budget / 2);
                    totalSum = firstPlanet.Army.Sum(s => s.Cost) + firstPlanet.Weapons.Sum(s => s.Price);
                    secondPlanet.Profit(totalSum);
                    planets.RemoveItem(planetOne);
                    return $"{planetTwo} destructed {planetOne}!";
                }
            }
            else if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {
                firstPlanet.Spend(planet1Budget / 2);
                firstPlanet.Profit(planet2Budget / 2);
                totalSum = secondPlanet.Army.Sum(s => s.Cost) + secondPlanet.Weapons.Sum(s => s.Price);
                firstPlanet.Profit(totalSum);
                planets.RemoveItem(planetTwo);
                return $"{planetOne} destructed {planetTwo}!";
            }
            secondPlanet.Spend(planet2Budget / 2);
            secondPlanet.Profit(planet1Budget / 2);
            totalSum = firstPlanet.Army.Sum(s => s.Cost) + firstPlanet.Weapons.Sum(s => s.Price);
            secondPlanet.Profit(totalSum);
            planets.RemoveItem(planetOne);
            return $"{planetTwo} destructed {planetOne}!";
        }

        public string SpecializeForces(string planetName)
        {
            if (planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            IPlanet planet = planets.FindByName(planetName);
            if (planet.Army.Count == 0)
            {
               throw new InvalidOperationException("No units available for upgrade!");
            }
            planet.TrainArmy();
            planet.Spend(1.25);
            return $"{planetName} has upgraded its forces!";
        }
    }
}
