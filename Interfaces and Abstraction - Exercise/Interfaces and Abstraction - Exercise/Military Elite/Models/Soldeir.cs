using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get;}
        public string FirstName { get;}
        public string LastName { get;}
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id}";
        }
    }
}
