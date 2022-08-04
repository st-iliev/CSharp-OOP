using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly ICollection<IHero> models;
        public HeroRepository() : base()
        {
           this.models = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models => (IReadOnlyCollection<IHero>)models;

        public void Add(IHero model)
        {
            models.Add(model);
        }

        public IHero FindByName(string name) => models.FirstOrDefault(s => s.Name == name);

        public bool Remove(IHero model) => models.Remove(model);
    }
}
