using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        private ICollection<IVessel> vessels;

        public Captain(string fullName)
        {
            this.FullName = fullName;
            this.vessels = new List<IVessel>();
            this.combatExperience = 0;
        }
        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                this.fullName = value;
            }
        }
        public int CombatExperience
        {
            get => combatExperience;
            private set => combatExperience = value;

        }

        public ICollection<IVessel> Vessels => vessels;

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }
            vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.combatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {vessels.Count} vessels.");

            if (vessels.Count > 0)
            {
                foreach (var vessel in vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
