using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private ICollection<IRace> models;
        public RaceRepository()
        {
            models = new List<IRace>();

        }
        public IReadOnlyCollection<IRace> Models => (IReadOnlyCollection<IRace>)models;

        public void Add(IRace model) => models.Add(model);


        public IRace FindByName(string name) => models.FirstOrDefault(s => s.RaceName == name);
       

        public bool Remove(IRace model) => models.Remove(model);
        

    }
}
