using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private ICollection<IBunny> models;
        public BunnyRepository()
        {
            this.models = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => (IReadOnlyCollection<IBunny>)models;
        public void Add(IBunny model) => models.Add(model);

        public IBunny FindByName(string name) => models.FirstOrDefault(s => s.Name == name);
       
        public bool Remove(IBunny model) => models.Remove(model);
      
    }
}
