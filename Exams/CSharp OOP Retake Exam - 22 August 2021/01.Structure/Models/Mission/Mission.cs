using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while (astronauts.Count > 0 && planet.Items.Count > 0)
            {
                IAstronaut astronaut = astronauts.First();
                while (astronaut.Oxygen > 0)
                {
                    if (planet.Items.Count == 0)
                    {
                        break;
                    }
                    astronaut.Breath();
                    if (astronaut.Oxygen == 0)
                    {
                        break;
                    }
                    else
                    {
                        string item = planet.Items.First();
                        astronaut.Bag.Items.Add(item);
                        planet.Items.Remove(item);
                    }
                }
            }
        }
    }
}
