using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
        }
        public  double TankCapacity
        {
            get { return tankCapacity; }
            set { this.tankCapacity = value; }
        }
        public  double FuelQuantity
        {
            get { return fuelQuantity; }
            set
            {
                if (value > TankCapacity)
                {
                    value = 0;
                }
                fuelQuantity = value;
            }
        }
        public virtual double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public virtual bool IsEmpty { get; set; }

        public bool CanDrive(double kilometers)
        {
            if (this.FuelQuantity - (kilometers * this.FuelConsumption) >= 0)
            {
                return true;
            }
            return false;
        }

        public void Drive(double kilometer)
        {
            this.FuelQuantity -= kilometer * this.FuelConsumption;
        }

        public virtual void Refuel(double liters)
        {
            ValidateLiters(liters);
            ValidateQuantity(liters);

            this.FuelQuantity += liters;
        }

        protected static void ValidateQuantity(double liters)
        {
            if (liters <= 0)
            {
                throw new AggregateException("Fuel must be a positive number");
            }
        }

        protected void ValidateLiters(double liters)
        {
            if (this.FuelQuantity + liters > tankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }
        }
    }
}
