using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public class Spy : Soldier , ISpy
    {
        public Spy(int id , string firstName , string lastName,int codeNumber) : base(id,firstName,lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; }
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id}\nCode Number: {CodeNumber}";
        }
    }
}
