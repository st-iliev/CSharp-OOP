using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {

        private string name;

        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            Athletes = new List<IAthlete>();
            Equipment = new List<IEquipment>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight { get { return this.Equipment.Select(s => s.Weight).Sum(); } }

        public ICollection<IEquipment> Equipment { get; }

        public ICollection<IAthlete> Athletes { get; }

        public void AddAthlete(IAthlete athlete)
        {
            if (Athletes.Count + 1 > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            Athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var ath in Athletes)
            {
                ath.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            string athletes;
            if (Athletes.Count > 0)
            {

                athletes = string.Join(", ", Athletes.Select(s => s.FullName));
            }
            else
            {
                athletes = "No athletes";
            }
            sb.AppendLine($"Athletes: {athletes}");
            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {this.EquipmentWeight:F2} grams");
            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete) => Athletes.Remove(athlete);

    }
}
