using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models.Interfaces
{
    public interface IVehicle
    {
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }
        public bool IsEmpty { get; set; }
        bool CanDrive(double kilometers);
        void Drive(double kilometer);
        void Refuel(double liters);
    }
}
