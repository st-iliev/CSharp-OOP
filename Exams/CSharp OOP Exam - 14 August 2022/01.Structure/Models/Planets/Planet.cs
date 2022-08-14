using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private UnitRepository units;
        private WeaponRepository weapons;
        private string name;
        private double budget;
        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.units = new UnitRepository();
            this.weapons = new WeaponRepository();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }
        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                this.budget = value;
            }
        }
        public double MilitaryPower { get; } // TODO

        public IReadOnlyCollection<IMilitaryUnit> Army => (IReadOnlyCollection<IMilitaryUnit>)units;

        public IReadOnlyCollection<IWeapon> Weapons => (IReadOnlyCollection<IWeapon>)weapons;

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: { this.Budget} billion QUID");
            string units = "";
            if (Army.Count > 0)
            {
                units = string.Join(", ", Army.Select(s => s.GetType().Name));
            }
            else
            {
                units = "No units";
            }
            sb.AppendLine($"--Forces: {units}");
            string weapons = "";
            if (Weapons.Count > 0)
            {
                weapons = string.Join(", ", Weapons.Select(s => s.GetType().Name)); ;
            }
            else
            {
                weapons = "No weapons";
            }
            sb.AppendLine($"--Combat equipment: {weapons}");
            sb.AppendLine($"--Military Power: {this.MilitaryPower}");
            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public void Spend(double amount)
        {
            if (this.Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            else
            {
                this.Budget -= amount;
            }
        }

        public void TrainArmy()
        {
            foreach (var unit in units.Models)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
