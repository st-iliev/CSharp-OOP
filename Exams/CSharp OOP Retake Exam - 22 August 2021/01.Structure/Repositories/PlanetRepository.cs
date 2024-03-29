﻿using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private ICollection<IPlanet> models;
        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => (IReadOnlyCollection<IPlanet>)models;

        public void Add(IPlanet model) => models.Add(model);


        public IPlanet FindByName(string name) => models.FirstOrDefault(s => s.Name == name);


        public bool Remove(IPlanet model) => models.Remove(model);
       
    }
}
