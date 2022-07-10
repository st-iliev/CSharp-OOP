using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Models.Enums;
using MilitaryElite.Models.Interfaces;
namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id,string firstName,string lastName,decimal salary,Corps corps, ICollection<IMission> missions) : base(id,firstName,lastName,salary,corps)
        {
            this.Missions = missions;
        }
        public ICollection<IMission> Missions { get; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Missions:");
            foreach (var mis in Missions)
            {
                sb.AppendLine(" " + mis.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
