using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private readonly EquipmentRepository equipment;
        private readonly List<IGym> gyms;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            var gym = gyms.FirstOrDefault(s => s.Name == gymName);
            bool isAdded = false;
            if (athleteType == "Boxer")
            {
                if (gym.GetType().Name == nameof(BoxingGym))
                {
                    isAdded = true;
                    Boxer athlete = new Boxer(athleteName, motivation, numberOfMedals);
                    gym.AddAthlete(athlete);
                }
            }
            else if (athleteType == "Weightlifter")
            {
                if (gym.GetType().Name == nameof(WeightliftingGym))
                {
                    isAdded = true;
                    Weightlifter athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                    gym.AddAthlete(athlete);
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }
            if (isAdded)
            {
               
                return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }
                return String.Format(OutputMessages.InappropriateGym);
           
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType == "BoxingGloves")
            {
                equipment.Add(new BoxingGloves());     
            }
            else if (equipmentType == "Kettlebell")
            {
                equipment.Add(new Kettlebell());
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType == "BoxingGym")
            {
                IGym gym = new BoxingGym(gymName);
                gyms.Add(gym);
                return String.Format(OutputMessages.SuccessfullyAdded, gymType);
            }
            else if (gymType == "WeightliftingGym")
            {
                IGym gym = new WeightliftingGym(gymName);
                gyms.Add(gym);
                return String.Format(OutputMessages.SuccessfullyAdded, gymType);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
        }

        public string EquipmentWeight(string gymName) => $"The total weight of the equipment in the gym {gymName} is {gyms.Where(s => s.Name == gymName).Sum(s => s.EquipmentWeight)} grams.";

        public string InsertEquipment(string gymName, string equipmentType)
        {
           IEquipment currentEquipment = equipment.FindByType(equipmentType);
            if (currentEquipment == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            var newGym = gyms.FirstOrDefault(s => s.Name == gymName);
            newGym.AddEquipment(currentEquipment);
            equipment.Remove(currentEquipment);
            return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName) => $"Exercise athletes: {gyms.Where(s => s.Name == gymName).Count()}.";

    }
}
