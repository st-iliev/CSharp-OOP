using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private ICollection<IMilitaryUnit> models;
        public UnitRepository()
        {
            this.models = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => (IReadOnlyCollection<IMilitaryUnit>)models;

        public void AddItem(IMilitaryUnit model) => models.Add(model);


        public IMilitaryUnit FindByName(string name) => models.FirstOrDefault(s => s.GetType().Name == name);
      

        public bool RemoveItem(string name)
        {
            IMilitaryUnit unit = models.FirstOrDefault(s => s.GetType().Name == name);
            return models.Remove(unit);
        }
    }
}
