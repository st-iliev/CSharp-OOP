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

    public class Battleship : Vessel, IBattleship 
    {
        private bool sonarMode;
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 300.00)
        {
            SonarMode = false;
        }
        public bool SonarMode
        {
            get
            {
                return this.sonarMode;
            }
            private set
            {
                this.sonarMode = value;
            }
        }

        public  void ToggleSonarMode()
        {
            if (sonarMode)
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
                SonarMode = false;
            }
            else
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
                SonarMode = true;
            }
        }
        public override void RepairVessel()
        {
           if (this.ArmorThickness < 300)
            {
                this.ArmorThickness = 300;
            }
        }
        public override string ToString()
        {
            string sonarOnOrOff = sonarMode == true ? "ON" : "OFF";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Sonar mode: {sonarOnOrOff}");

            return sb.ToString().TrimEnd();
        }
    }
}
