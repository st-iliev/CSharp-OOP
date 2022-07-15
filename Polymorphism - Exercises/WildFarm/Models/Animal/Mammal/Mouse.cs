using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animal.Mammal
{
    public class Mouse : Mammal
    {
        private const double mouseWeightMultiplier = 0.10;
        public Mouse(string name , double weight,string livingRegion) : base( name, weight,livingRegion){}
        protected override IReadOnlyCollection<Type> PreferredFood => new List<Type> { typeof(Vegetable),typeof(Fruit)}.AsReadOnly();

        protected override double WeightMultiplier => mouseWeightMultiplier;

        public override string ProduceSound()
        {
            return "Squeak";
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
