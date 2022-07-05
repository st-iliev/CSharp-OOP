using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;
        private double weight;
        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
        public string Type
        {
            get { return type; }
            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }
        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value > 0 && value < 51)
                {
                    this.weight = value;
                }
                else
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
            }
        }
        public double Calories
        {
            get => CalculateCalories();
        }

        private double CalculateCalories()
        {
            double modifier = 0;
            if (type.ToLower() == "meat")
            {
                modifier = 1.2;
            }
            else if (type.ToLower() == "veggies")
            {
                modifier = 0.8;
            }
            else if (type.ToLower() == "cheese")
            {
                modifier = 1.1;
            }
            else if (type.ToLower() == "sauce")
            {
                modifier = 0.9;
            }
            return 2 * this.Weight * modifier;
        }
    }
}
