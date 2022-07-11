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
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public virtual double FuelQuantity
        {
            get { return fuelQuantity; }
             set { fuelQuantity = value; }
        }
        public virtual double FuelConsumption
        {
            get { return fuelConsumption; }
             set { fuelConsumption = value; }
        }

        public bool CanDrive(double kilometers)
        {
            if (this.FuelQuantity - (kilometers * this.FuelConsumption) >= 0)
            {
                return true;
            }
            return false;
        }

        public  void Drive(double kilometer)
        {
             this.FuelQuantity -= kilometer * this.FuelConsumption;
        }

        public virtual void Refuel(double liters)
        {
             this.FuelQuantity += liters;
        }
    }
}
