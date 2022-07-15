using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animal.Mammal
{
    public class Tiger : Feline
    {
        private const double tigerWeightMultiplier = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed){}

        protected override IReadOnlyCollection<Type> PreferredFood => new List<Type> {typeof(Meat)}.AsReadOnly();

        protected override double WeightMultiplier => tigerWeightMultiplier;

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
