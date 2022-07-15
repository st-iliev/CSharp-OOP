using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animal.Birds
{
    public class Hen : Bird
    {
        private const double henWeightMultiplier = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize){}

        protected override IReadOnlyCollection<Type> PreferredFood => new List<Type> { typeof(Meat),typeof(Fruit),typeof(Vegetable),typeof(Seeds)}.AsReadOnly();

        protected override double WeightMultiplier => henWeightMultiplier;

        public override string ProduceSound()
        {
            return "Cluck";
        }
      
    }
}
