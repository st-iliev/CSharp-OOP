using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models.Interfaces
{
    public interface ICommando : ISpecialisedSoldier
    { 
        public ICollection<IMission> Missions { get; }

    }
}
