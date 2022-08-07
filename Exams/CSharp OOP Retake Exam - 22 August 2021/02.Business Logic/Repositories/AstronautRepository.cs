using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> models;

        public AstronautRepository()
        {
            models = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models => models;
        public void Add(IAstronaut model) => models.Add(model);


        public IAstronaut FindByName(string name) => models.FirstOrDefault(s => s.Name == name);
       

        public bool Remove(IAstronaut model) => models.Remove(model);
        
    }
}
