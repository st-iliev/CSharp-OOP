using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private List<IVessel> models;
        public VesselRepository()
        {
            models = new List<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models => models;

        public void Add(IVessel vessel) => models.Add(vessel);
        public IVessel FindByName(string name) => models.FirstOrDefault(s => s.Name == name);
        public bool Remove(IVessel vessel) => models.Remove(vessel);
    }
}
