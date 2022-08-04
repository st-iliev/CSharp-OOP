using Heroes.Models.Contracts;


namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private bool isAlive ;
        private IWeapon weapon;

        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public string Name { get;}
        public int Health { get;}
        public int Armour { get; }
        public bool IsAlive { get;}
        public IWeapon Weapon  {get;}

        public void AddWeapon(IWeapon weapon)
        {

        }
        public void TakeDamage(int points)
        {


        }
    }
}
