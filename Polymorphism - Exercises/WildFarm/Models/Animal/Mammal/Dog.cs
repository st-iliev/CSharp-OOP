using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animal.Mammal
{
    public class Dog : Mammal
    {
        private const double dogWeightMultiplier = 0.40;
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion){}
        protected override IReadOnlyCollection<Type> PreferredFood => new List<Type> { typeof(Meat) }.AsReadOnly();

        protected override double WeightMultiplier => dogWeightMultiplier;

        public override string ProduceSound()
        {
            return "Woof!";
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
