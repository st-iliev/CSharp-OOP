using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        public ProfessionalRacer(string userName,ICar car) : base(userName , "strict", 30,car)
        {
            this.DrivingExperience = 30;
        }
        public override void Race()
        {
            this.DrivingExperience += 10;
            base.Race();
        }
    }
}
