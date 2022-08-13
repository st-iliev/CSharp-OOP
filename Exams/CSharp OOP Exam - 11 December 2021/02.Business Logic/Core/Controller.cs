using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
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
            IAthlete atelete;

            if (athleteType == nameof(Boxer))
            {
                atelete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == nameof(Weightlifter))
            {
                atelete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);

            if (athleteType == nameof(Boxer) && gym.GetType().Name != nameof(BoxingGym))
            {
                return string.Format(OutputMessages.InappropriateGym);
            }
            else if (athleteType == nameof(Weightlifter) && gym.GetType().Name != nameof(WeightliftingGym))
            {
                return string.Format(OutputMessages.InappropriateGym);
            }

            gym.AddAthlete(atelete);

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);

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
            IGym gym;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);

            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);

            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
            gyms.Add(gym);
            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(s => s.Name == gymName);
            double sumOfEquipments = gym.Equipment.Sum(s => s.Weight);
            return $"The total weight of the equipment in the gym {gymName} is {sumOfEquipments:F2} grams.";
        }

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

        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(s => s.Name == gymName);
            gym.Exercise();
            return $"Exercise athletes: {gym.Athletes.Count}.";
        }


    }
}
