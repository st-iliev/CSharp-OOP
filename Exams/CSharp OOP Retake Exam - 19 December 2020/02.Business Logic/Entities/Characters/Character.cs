using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double baseHealth;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = BaseHealth;
            this.BaseArmor = armor;
            this.Armor = BaseArmor;
            this.AbilityPoints = abilityPoints;
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
        public double BaseHealth
        {
            get => baseHealth;
            private set => baseHealth = value;
        }
        public double Health
        {
            get => health;
             set
            {
                if (value < 0 )
                {
                    value = 0;
                }
                if (value > baseHealth)
                {
                    value = baseHealth;
                }
                this.health = value;
            }
        }
        public double BaseArmor
        {
            get => baseArmor;
            private set => baseArmor = value;
        }
        public double Armor
        {
            get => armor;
            private set
            {
                if (value < 0)
                {
                    this.armor = 0;
                }
                if (value > baseArmor)
                {
                    value = baseArmor;
                }
                this.armor = value;
            }
        }
        public double AbilityPoints
        {
            get => abilityPoints;
            private set => abilityPoints = value;
        }
        public Bag Bag
        {
            get => bag;
            private set => bag = (Bag)value;
        }
        public bool IsAlive { get; set; } = true;

        protected internal void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();
            if (this.Armor - hitPoints > 0)
            {
                this.Armor -= hitPoints;
            }
            else if (this.Armor - hitPoints == 0)
            {
                this.Armor = 0;
            }
            else
            {
                hitPoints -= this.Armor;
                this.Armor = 0;
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
            EnsureAlive();
            if (this.IsAlive)
            {
                item.AffectCharacter(this);
            }
        }
    }
}