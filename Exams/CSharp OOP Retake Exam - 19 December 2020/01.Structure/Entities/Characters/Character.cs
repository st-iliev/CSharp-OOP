using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double armor;
        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPOints = abilityPoints;
            this.Bag = bag;


        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }
        public double BaseHealth => baseHealth;
        public double Health
        {
            get => health;
             set
            {
                if (value > 0 && value < BaseHealth)
                {
                    this.health = value;
                }
            }
        }
        public double BaseArmor { get; private set; }
        public double Armor { get; private set; }
        public double AbilityPOints { get; private set; }
        public Bag Bag { get; private set; }
        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
       public void TakeDamage(double hitPoints)
        {
            if (this.BaseArmor - hitPoints > 0)
            {
               
                this.BaseArmor -= hitPoints;
            }
            else if (this.BaseArmor - hitPoints == 0)
            {
                this.BaseArmor = 0;
            }
            else
            {
                hitPoints -= this.BaseArmor;
                this.BaseArmor = 0;
                if (this.Health - hitPoints > 0)
                {
                    this.Health -= hitPoints;
                }
                else
                {
                    this.Health = 0;
                    IsAlive = false;
                }
            }
        }
        public void UseItem(Item item)
        {
            if (this.IsAlive)
            {
                item.AffectCharacter(this);
            }
        }
    }
}