using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private IReadOnlyCollection<VesselRepository> models;
        public VesselRepository()
        {
            models = new List<VesselRepository>();
        }

        public IReadOnlyCollection<IVessel> Models => throw new NotImplementedException();

        public void Add(IVessel vessel)
        {
            throw new NotImplementedException();
        }

        public IVessel FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IVessel vessel)
        {
            throw new NotImplementedException();
        }
    }
}
