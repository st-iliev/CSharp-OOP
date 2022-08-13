using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode;
        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 200.00)
        {
            SubmergeMode = false;
        }
        public bool SubmergeMode
        {
            get
            {
                return this.submergeMode;
            }
            private set
            {
                this.submergeMode = value;
            }
        }
        public  void ToggleSubmergeMode()
        {
            if (submergeMode)
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
                submergeMode = false;
            }
            else
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
                submergeMode = true;
            }
        }
        public override void RepairVessel()
        {
           
            if (this.ArmorThickness < 200)
            {
                this.ArmorThickness = 200;
            }         
        }
    
        public override string ToString()
        {
            string submergeOnOrOff = SubmergeMode == true ? "ON" : "OFF";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Submerge mode: {submergeOnOrOff}");

            return sb.ToString().TrimEnd();
        }
    }
}