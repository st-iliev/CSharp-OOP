using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public class Private : Soldier , IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary)
             : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get;}
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}";
        }
    }
}
