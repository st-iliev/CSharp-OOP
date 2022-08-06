using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;
        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;
           if (type != nameof(SuperCar) && type != nameof(TunedCar))
            {
                throw new ArgumentException("Invalid car type!");
            }
           if (type == nameof(SuperCar))
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            cars.Add(car);
            return $"Successfully added car {car.Make} {car.Model} ({car.VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            if (cars.FindBy(carVIN)==null)
            {
                throw new ArgumentException("Car cannot be found!");
            }
            if (type != nameof(ProfessionalRacer) && type != nameof(StreetRacer))
            {
                throw new ArgumentException("Invalid racer type!");
            }
            IRacer racer;
            ICar car = cars.FindBy(carVIN);
            if (type == nameof(ProfessionalRacer))
            {
                racer = new ProfessionalRacer(username, car);
            }
            else 
            {
                racer = new StreetRacer(username, car);
            }
            racers.Add(racer);
            return $"Successfully added racer {racer.Username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            if (racers.FindBy(racerOneUsername) == null)
            {
                return $"Racer {racerOneUsername} cannot be found!";
            }
            if (racers.FindBy(racerTwoUsername) == null)
            {
                return $"Racer {racerTwoUsername} cannot be found!";
            }
            IRacer racerOne = racers.FindBy(racerOneUsername);
            IRacer racerTwo = racers.FindBy(racerTwoUsername);
            return this.map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var racer in racers.Models.OrderByDescending(s=>s.DrivingExperience).ThenBy(s=>s.Username))
            {
                sb.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                sb.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
