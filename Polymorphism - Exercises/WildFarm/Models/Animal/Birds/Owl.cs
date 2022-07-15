using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animal.Birds
{
    public class Owl : Bird
    {
        private const double owlWeightMultiplier = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize){}

        protected override IReadOnlyCollection<Type> PreferredFood => new List<Type> { typeof(Meat)}.AsReadOnly();

        protected override double WeightMultiplier => owlWeightMultiplier;

        public override string ProduceSound()
        {
            return $"Hoot Hoot";
        }
    }
}
