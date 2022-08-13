using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
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
        private ICollection<string> targets = new List<string>();
        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.name = name;
            this.mainWeaponCaliber = mainWeaponCaliber;
            this.speed = speed;
            this.armorThickness = armorThickness;
        }

        public string Name => throw new NotImplementedException();

        public ICaptain Captain { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double ArmorThickness { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double MainWeaponCaliber => throw new NotImplementedException();
        public double Speed => throw new NotImplementedException();
        public ICollection<string> Targets => throw new NotImplementedException();



        public void Attack(IVessel target)
        {
            throw new NotImplementedException();
        }

        public void RepairVessel()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
