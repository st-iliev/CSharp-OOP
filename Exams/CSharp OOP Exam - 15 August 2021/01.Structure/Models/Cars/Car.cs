using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsepower;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;

        public Car(string make, string model, string VIN, int horsepower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = VIN;
            this.HorsePower = horsepower;
            this.FuelAvailable = fuelAvailable;
            this.FuelConsumptionPerRace = fuelConsumptionPerRace;
        }

        public string Make
        {
            get => make;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Car make cannot be null or empty.");
                }
                this.make = value;
            }
        }
        public string Model
        {
            get => model;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Car model cannot be null or empty.");
                }
                this.model = value;
            }
        }
        public string VIN
        {
            get => vin;
            private set
            {
                if (vin.Length != 17)
                {
                    throw new ArgumentException("Car VIN must be exactly 17 characters long.");
                }
                this.vin = value;
            }
        }
        public int HorsePower
        {
            get => horsepower;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Car VIN must be exactly 17 characters long.");
                }
                this.horsepower = value;
            }
        }
        public double FuelAvailable
        {
            get => fuelAvailable;
            private set
            {
                fuelAvailable = value;
                if (fuelAvailable < 0)
                {
                    fuelAvailable = 0;
                }
            }
        }
        public double FuelConsumptionPerRace
        {
            get => fuelConsumptionPerRace;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel consumption cannot be below 0.");
                }
                this.fuelConsumptionPerRace = value;
            }
        }

        public virtual void Drive()
        {
            this.FuelAvailable -= FuelConsumptionPerRace;
        }
    }
}
