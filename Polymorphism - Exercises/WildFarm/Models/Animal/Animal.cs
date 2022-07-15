

using System;
using System.Collections.Generic;
using System.Linq;
using WildFarm.Exeptions;

namespace WildFarm.Models.Animal
{
    public abstract class Animal 
    {
        protected Animal(string name , double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }
        protected abstract IReadOnlyCollection<Type> PreferredFood { get; }
        protected abstract double WeightMultiplier { get; }
        public abstract string ProduceSound();
        public  void Eat(Food food)
        {
            if (!this.PreferredFood.Contains(food.GetType()))
            {
                throw new FoodExeption(String.Format(ExceptionMessage.message,this.GetType().Name,food.GetType().Name));
            }
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightMultiplier;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }

    }
}
