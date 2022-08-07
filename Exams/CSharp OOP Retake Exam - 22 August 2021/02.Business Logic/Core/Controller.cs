using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IAstronaut> astronauts;
        private readonly IRepository<IPlanet> planets;
        private readonly IMission mission;
        private int exploredPlanets;
        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
            this.mission = new Mission();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type != nameof(Biologist) && type != nameof(Geodesist) && type != nameof(Meteorologist))
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }
            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else
            {
                astronaut = new Meteorologist(astronautName);
            }
            astronauts.Add(astronaut);
            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            planets.Add(planet);
            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            var astronautNnMission = astronauts.Models.Where(s => s.Oxygen > 60).ToList();
            IPlanet planet = planets.FindByName(planetName);
            if (!astronautNnMission.Any())
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }
            mission.Explore(planet, astronautNnMission);
            exploredPlanets++;
            int deadAstronauts = astronautNnMission.Count(s => !s.CanBreath);
            return $"Planet: {planetName} was explored! Exploration finished with {deadAstronauts} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine($"Astronauts info:");
            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                string info = astronaut.Bag.Items.Any() ? $"{string.Join(", ", astronaut.Bag.Items)}" : "none";
                sb.AppendLine($"Bag items: {info}");
            }
            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.FindByName(astronautName);
            if (astronaut == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
            astronauts.Remove(astronaut);
            return $"Astronaut {astronautName} was retired!";
        }
    }
}
