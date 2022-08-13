using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private ICollection<IEgg> models;

        public EggRepository()
        {
            this.models = new List<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models => (IReadOnlyCollection<IEgg>)models;

        public void Add(IEgg model) => models.Add(model);


        public IEgg FindByName(string name) => models.FirstOrDefault(s => s.Name == name);
    

        public bool Remove(IEgg model) => models.Remove(model);
       
    }
}
