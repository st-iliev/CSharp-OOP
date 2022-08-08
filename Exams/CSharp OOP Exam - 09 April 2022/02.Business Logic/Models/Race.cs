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
        private ICollection<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
            this.pilots = new List<IPilot>();
           
        }

        public string RaceName
        {
            get => raceName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid race name: {value}.");
                }
                this.raceName = value;
            }
        }
        public int NumberOfLaps
        {
            get => numberOfLaps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"Invalid lap numbers: {value}.");
                }
                this.numberOfLaps = value;
            }
        }
        public bool TookPlace { get; set; } = false;
        public ICollection<IPilot> Pilots => pilots;

        public void AddPilot(IPilot pilot)
        {
            this.pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The {this.RaceName} race has:");
            sb.AppendLine($"Participants: {this.Pilots.Count}");
            sb.AppendLine($"Number of laps: {this.NumberOfLaps}");
            if (TookPlace)
            {
                sb.AppendLine($"Took place: Yes");
            }
            else
            {
                sb.AppendLine($"Took place: No");
            }
            return sb.ToString().TrimEnd();

        }
    }
}
