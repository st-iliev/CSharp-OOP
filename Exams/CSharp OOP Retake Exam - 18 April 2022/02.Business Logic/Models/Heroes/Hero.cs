using Heroes.Models.Contracts;
using Heroes.Models.Weapons;
using System;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        public Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Health
        {
            get => health;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                this.health = value;
            }
        }
        public int Armour
        {
            get => armour;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                this.armour = value;
            }
        }
        public bool IsAlive => this.Health > 0;
       
        public IWeapon Weapon
        {
            get { return weapon; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }
                AddWeapon(value);
            }
        }
        public void AddWeapon(IWeapon weapon)
        {
            if (weapon == null)
            {
                throw new ArgumentException("Weapon cannot be null.");
            }
            else if (Weapon != null)
            {
                throw new InvalidOperationException($"Hero {Name} is well-armed.");
            }
            this.weapon = weapon;
        }
        public void TakeDamage(int points)
        {

            if (this.Armour > points)
            {
                this.Armour -= points;
            }
            else
            {
                points -= this.Armour;
                this.Armour = 0;
            }
            if (this.Health > points && this.Armour == 0)
            {
                this.Health -= points;
            }
            else if (this.Health <= points && this.Armour == 0)
            {
                this.Health = 0;
            }
        }
    }
}
