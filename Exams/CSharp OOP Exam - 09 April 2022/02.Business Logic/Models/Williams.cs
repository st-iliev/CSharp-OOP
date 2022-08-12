﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Williams : FormulaOneCar
    {
        public Williams(string model, int horsepower, double engineDisplacement) : base(model, horsepower, engineDisplacement)
        {
        }
        public override double RaceScoreCalculator(int laps)
        {
            return base.RaceScoreCalculator(laps);
        }
    }
}