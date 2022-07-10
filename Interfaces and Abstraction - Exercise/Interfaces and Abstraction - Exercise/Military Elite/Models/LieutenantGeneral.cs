using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Models.Interfaces;
namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id , string firstName,string lastName,decimal salary, Dictionary<int,IPrivate> @private) : base(id,firstName,lastName,salary)
        {
            this.Private = @private;
        }
        public Dictionary<int, IPrivate> Private { get; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
            sb.AppendLine("Privates:");
            foreach (var item in Private.Values)
            {
                sb.AppendLine(" " + item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
