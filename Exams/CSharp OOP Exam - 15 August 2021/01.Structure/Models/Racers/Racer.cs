using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string userName;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;

        public Racer(string userName, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = userName;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
        }

        public string Username
        {
            get => userName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username cannot be null or empty.");
                }
                this.userName = value;
            }
        }
        public string RacingBehavior
        {
            get => racingBehavior;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Racing behavior cannot be null or empty.");
                }
                this.racingBehavior = value;
            }
        }
        public int DrivingExperience
        {
            get => drivingExperience;
            protected set
            {
                if (value < 0 && value > 100)
                {
                    throw new ArgumentException("Racer driving experience must be between 0 and 100.");
                }
                this.drivingExperience = value;
            }
        }
        public ICar Car
        {
            get => car;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Car cannot be null or empty.");
                }
                this.car = value;
            }
        }
        public bool IsAvailable() => Car.FuelAvailable >= Car.FuelConsumptionPerRace;
        
        public virtual void Race()
        {
            this.Car.Drive();
        }
    }
}
