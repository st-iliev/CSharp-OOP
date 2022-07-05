using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weigh;
        private double calories;
        public Dough(string flourType, string bakingTechnique, double weigh)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weigh = weigh;
            this.Calories = calories;
        }

        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }
        public double Weigh
        {
            get { return weigh; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weigh = value;
            }
        }
        public double Calories
        {
            get { return calories; }
            private set { this.calories = CalculateCalories(); }
        }
        private double CalculateCalories()
        {
            double modifier = 1;
            if (FlourType.ToLower() == "white")
            {
                modifier = 1.5;
            }
            if (BakingTechnique.ToLower() == "crispy")
            {
                modifier *= 0.9;
            }
            else if (BakingTechnique.ToLower() == "chewy")
            {
                modifier *= 1.1;
            }
            else if (BakingTechnique.ToLower() == "homemade")
            {
                modifier *= 1.0;
            }
            return calories = 2 * Weigh * modifier;
        }
    }
}
