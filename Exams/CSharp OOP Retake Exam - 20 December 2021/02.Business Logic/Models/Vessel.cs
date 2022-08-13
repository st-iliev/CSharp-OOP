using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private double mainWeaponCaliber;
        private double speed;
        private double armorThickness;
        private ICaptain captain;
        private ICollection<string> targets;
        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
            this.targets = new List<string>();
            this.captain = null;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                this.name = value;
            }
        }
        public ICaptain Captain
        {
            get => captain;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }
                this.captain = value;
            }
        }
        public double ArmorThickness
        {
            get => armorThickness;
              set
            {
                this.armorThickness = value;
            }
        }

        public double MainWeaponCaliber
        {
            get => mainWeaponCaliber;
            protected set
            {
                this.mainWeaponCaliber = value;
            }
        }
        public double Speed
        {
            get => speed;
            protected set
            {
                this.speed = value;
            }
        }
        public ICollection<string> Targets => targets;
        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.InvalidTarget));
            }

            double targetArmor = target.ArmorThickness - this.MainWeaponCaliber;

            if (targetArmor < 0)
            {
                target.ArmorThickness = 0;
            }
            else
            {
                target.ArmorThickness = targetArmor;
            }

            this.targets.Add(target.Name);
        }

        public abstract void RepairVessel();
       

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {this.Speed} knots");
            string target = "";
            if (!this.Targets.Any())
            {
                target = "None";
            }
            else
            {
                target = string.Join(", ", targets);
            }
            sb.Append($" *Targets: {target}");
            return sb.ToString().TrimEnd();
        }   
    }
}
