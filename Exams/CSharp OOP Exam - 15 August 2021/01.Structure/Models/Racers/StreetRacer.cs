using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
   public  class StreetRacer : Racer
    {
        public StreetRacer(string userName, ICar car) : base(userName, "aggressive", 10, car)
        {
            this.DrivingExperience = 10;
        }
        public override void Race()
        {
            this.DrivingExperience += 5;
            base.Race();
        }
    }
}
