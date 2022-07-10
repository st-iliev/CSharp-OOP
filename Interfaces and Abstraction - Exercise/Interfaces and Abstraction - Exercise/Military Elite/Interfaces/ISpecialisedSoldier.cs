using MilitaryElite.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models.Interfaces
{
    public interface ISpecialisedSoldier : IPrivate
    {
        public Corps Corps { get;}
    }
}
