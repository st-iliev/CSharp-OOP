using Vehicles.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] carInfo = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double carFuelQuantity = double.Parse(carInfo[1]);
            double carLiters = double.Parse(carInfo[2]);
            double carCapacity = double.Parse(carInfo[3]);
            Vehicle car = new Car(carFuelQuantity, carLiters, carCapacity);

            string[] truckinfo = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double truckFuelQuantity = double.Parse(truckinfo[1]);
            double truckLiters = double.Parse(truckinfo[2]);
            double truckCapacity = double.Parse(truckinfo[3]);
            Vehicle truck = new Truck(truckFuelQuantity, truckLiters, truckCapacity);

            string[] businfo = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double busFuelQuantity = double.Parse(businfo[1]);
            double busLiters = double.Parse(businfo[2]);
            double busCapacity = double.Parse(businfo[3]);
            Vehicle bus = new Bus(busFuelQuantity, busLiters, busCapacity);

            int numberOfCommands = int.Parse(this.reader.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                double kilometers = double.Parse(command[2]);
                if (command[0] == "Drive")
                {
                    if (command[1] == "Car")
                    {
                        if (car.CanDrive(kilometers))
                        {
                            car.Drive(kilometers);
                            this.writer.WriteLine($"Car travelled {kilometers} km");
                        }
                        else
                        {
                            this.writer.WriteLine("Car needs refueling");
                        }
                    }
                    else if (command[1] == "Truck")
                    {
                        if (truck.CanDrive(kilometers))
                        {
                            truck.Drive(kilometers);
                            this.writer.WriteLine($"Truck travelled {kilometers} km");
                        }
                        else
                        {
                            this.writer.WriteLine("Truck needs refueling");
                        }
                    }
                    else if (command[1] == "Bus")
                    {
                        bus.IsEmpty = false;
                        if (bus.CanDrive(kilometers))
                        {
                            bus.Drive(kilometers);
                            this.writer.WriteLine($"Bus travelled {kilometers} km");
                        }
                        else
                        {
                            this.writer.WriteLine("Bus needs refueling");
                        }
                    }
                }
                else if (command[0] == "DriveEmpty")
                {
                    bus.IsEmpty = true;
                    if (bus.CanDrive(kilometers))
                    {
                        bus.Drive(kilometers);
                        this.writer.WriteLine($"Bus travelled {kilometers} km");
                    }
                    else
                    {
                        this.writer.WriteLine("Bus needs refueling");
                    }
                }
                else if (command[0] == "Refuel")
                {
                    try
                    {
                        double liters = double.Parse(command[2]);
                        if (command[1] == "Car")
                        {
                            car.Refuel(liters);
                        }
                        else if (command[1] == "Truck")
                        {
                            truck.Refuel(liters);
                        }
                        else if (command[1] == "Bus")
                        {
                            bus.Refuel(liters);
                        }
                    }
                    catch (Exception e )
                    {

                        Console.WriteLine(e.Message);
                    }
                }
            }
            this.writer.WriteLine($"Car: {Math.Round(car.FuelQuantity, 2):F2}");
            this.writer.WriteLine($"Truck: {Math.Round(truck.FuelQuantity, 2):F2}");
            this.writer.WriteLine($"Bus: {Math.Round(bus.FuelQuantity, 2):F2}");
        }
    }
}
