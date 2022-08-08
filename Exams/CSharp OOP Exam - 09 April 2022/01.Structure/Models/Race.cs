using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public  class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;

        protected Race(string raceName, int numberOfLaps)
        {
            this.raceName = raceName;
            this.numberOfLaps = numberOfLaps;
        }

        public string RaceName => throw new NotImplementedException();

        public int NumberOfLaps => throw new NotImplementedException();

        public bool TookPlace { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<IPilot> Pilots => throw new NotImplementedException();

        public void AddPilot(IPilot pilot)
        {
            throw new NotImplementedException();
        }

        public string RaceInfo()
        {
            throw new NotImplementedException();
        }
    }
}
