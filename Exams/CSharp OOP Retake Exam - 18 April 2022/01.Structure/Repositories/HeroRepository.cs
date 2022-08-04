using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly IList<IHero> models;
        public HeroRepository() : base()
        {
            models = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models => throw new NotImplementedException();

        public void Add(IHero model)
        {
            throw new NotImplementedException();
        }

        public IHero FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IHero model)
        {
            throw new NotImplementedException();
        }
    }
}
