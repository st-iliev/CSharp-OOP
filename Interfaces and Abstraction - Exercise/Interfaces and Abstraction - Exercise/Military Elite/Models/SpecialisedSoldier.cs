using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Models.Enums;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id,string firstName,string lastName,decimal salary, Corps corps) :base(id,firstName,lastName,salary)
        {
            this.Corps = corps;
        }
        public Corps Corps { get; }
    }
}
