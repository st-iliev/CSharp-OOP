using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }
        public override double FuelConsumption => base.FuelConsumption + 0.9;
        public override void Refuel(double liters)
        {
            ValidateLiters(liters);
            base.Refuel(liters);

        }

    }
}
