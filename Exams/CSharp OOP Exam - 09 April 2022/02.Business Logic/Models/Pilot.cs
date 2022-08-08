using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;
        private int numberOfWins = 0;
        public Pilot(string fullName)
        {
            this.FullName = fullName;
        }

        public string FullName
        {
            get => fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid pilot name: {value}.");
                }
                this.fullName = value;
            }
        }
        public IFormulaOneCar Car
        {
            get => car;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot car can not be null.");
                }
                this.car = value;
            }
        }
        public int NumberOfWins => numberOfWins;

        public bool CanRace { get; set; } = false;        
        
        public void AddCar(IFormulaOneCar car)
        {
            this.CanRace = true;
            this.car = car;
        }

        public void WinRace()
        {
            this.numberOfWins += 1;
        }
        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }
    }
}
