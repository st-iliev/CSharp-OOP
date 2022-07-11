using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }
        public override double FuelConsumption => base.IsEmpty ? base.FuelConsumption : base.FuelConsumption + 1.4;

        public override void Refuel(double liters)
        {
            ValidateLiters(liters);
            base.Refuel(liters);

        }


    }
}
