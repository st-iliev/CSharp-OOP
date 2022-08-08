using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsepower;
        private double engineDisplacement;
        protected FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            this.model = model;
            this.horsepower = horsepower;
            this.engineDisplacement = engineDisplacement;
        }

        public string Model => throw new NotImplementedException();

        public int Horsepower => throw new NotImplementedException();

        public double EngineDisplacement => throw new NotImplementedException();

        public double RaceScoreCalculator(int laps)
        {
            throw new NotImplementedException();
        }
    }
}
