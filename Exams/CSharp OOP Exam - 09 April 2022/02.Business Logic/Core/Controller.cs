using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;
        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository = new FormulaOneCarRepository();
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepository.FindByName(pilotName);
            IFormulaOneCar car = carRepository.FindByName(carModel);
           if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException($"Pilot { pilotName} does not exist or has a car.");
            }
           if (car == null)
            {
                throw new NullReferenceException($"Car { carModel } does not exist.");
            }
            pilot.AddCar(car);
            carRepository.Remove(car);
            return $"Pilot { pilotName } will drive a {car.GetType().Name} { car.Model } car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {

            IRace race = raceRepository.FindByName(raceName);
            IPilot pilot = pilotRepository.FindByName(pilotFullName);
            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }
            if (pilot == null || !pilot.CanRace || raceRepository.Models.Any(s=>s.Pilots.Contains(pilot)))
            {
                throw new InvalidOperationException($"Can not add pilot { pilotFullName } to the race.");
            }
            race.AddPilot(pilot);
            return $"Pilot { pilotFullName} is added to the { raceName} race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car;
            if (type != nameof(Ferrari) && type != nameof(Williams))
            {
                throw new InvalidOperationException($"Formula one car type { type } is not valid.");
            }
            if (carRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException($"Formula one car { model } is already created.");
            }
            if (type == nameof(Ferrari))
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else
            {
                car = new Williams(model, horsepower, engineDisplacement);

            }
            carRepository.Add(car);
            return $"Car { type }, model { model } is created.";
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }
            IPilot pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);
            return $"Pilot {fullName} is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException($"Race { raceName } is already created.");
            }
            IRace race = new Race(raceName, numberOfLaps);
            raceRepository.Add(race);
            return $"Race { raceName} is created.";
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var pilot in pilotRepository.Models.OrderByDescending(s=>s.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var race in raceRepository.Models.Where(s=>s.TookPlace == true))
            {
                sb.AppendLine(race.RaceInfo());
            }
           return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException($"Race { raceName } does not exist.");
            }
            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException($"Race { raceName} cannot start with less than three participants.");
            }
            if (race.TookPlace)
            {
                throw new InvalidOperationException($"Can not execute race { raceName }.");
            }
            foreach (var pilot in race.Pilots)
            {
                pilot.Car.RaceScoreCalculator(1);
            }
            List<IPilot> pilots = new List<IPilot>();
          
            pilots = race.Pilots.OrderByDescending(s => s.Car.RaceScoreCalculator(1)).ToList();

            pilots.First().WinRace();
            race.TookPlace = true;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot { pilots.First().FullName} wins the {race.RaceName} race.");
            sb.AppendLine($"Pilot { pilots.Skip(1).Take(1).First().FullName} is second in the {race.RaceName} race.");
            sb.AppendLine($"Pilot { pilots.Skip(2).Take(1).First().FullName} is third in the {race.RaceName} race.");
            return sb.ToString().TrimEnd();
        }
    }
}
