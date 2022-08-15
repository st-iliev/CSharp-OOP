using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> models;
        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => models;

        public void AddItem(IPlanet model) => models.Add(model);
      

        public IPlanet FindByName(string name) => models.FirstOrDefault(s => s.Name == name);
        

        public bool RemoveItem(string name) =>  models.Remove(models.FirstOrDefault(s => s.Name == name));
        
    }
}
