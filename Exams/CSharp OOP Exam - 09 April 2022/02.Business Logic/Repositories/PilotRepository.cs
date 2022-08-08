using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private ICollection<IPilot> models;
        public PilotRepository()
        {
            models = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models => (IReadOnlyCollection<IPilot>)models;

        public void Add(IPilot model) => models.Add(model);


        public IPilot FindByName(string name) => models.FirstOrDefault(s => s.FullName == name);

        public bool Remove(IPilot model) => models.Remove(model);
       
    }
}
