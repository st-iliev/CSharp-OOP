using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private int toppings;
        private double calories;
        public Pizza(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length <= 0 || value.Length >= 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        public int Toppings => toppings;
        public double Calories => calories;
        public void AddDough(Dough dough)
        {
            calories += dough.Calories;
        }
        public void AddToppin(Topping toppin)
        {
            if (toppings + 1 <= 10)
            {
                calories += toppin.Calories;
                toppings++;        
            }
            else
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }
    }
}
