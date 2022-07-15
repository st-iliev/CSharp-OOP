namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private int power = 80;
        public Druid(string name) : base(name){}
        public override int Power { get { return power; } }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}";
        }
    }
}
