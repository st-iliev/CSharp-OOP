using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Models.Enums;
using MilitaryElite.Models.Interfaces;
namespace MilitaryElite.Models
{
    public class Engineer: SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps,ICollection<IRepair> repairs) : base(id,firstName,lastName,salary,corps)
        {
            this.Repairs = repairs;
        }

        public ICollection<IRepair> Repairs { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Repairs:");
            foreach (var rep in Repairs)
            {
                sb.AppendLine(" " + rep.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
