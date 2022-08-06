using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return $"Race cannot be completed because both racers are not available!";
            }
            if (!racerOne.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            else if (!racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }

            racerOne.Race();
            racerTwo.Race();
            double racerOneChance = racerOne.Car.HorsePower * racerOne.DrivingExperience * (racerOne.GetType().Name == nameof(ProfessionalRacer) ? 1.2 : 1.1);
            double racerTwoChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * (racerTwo.GetType().Name == nameof(ProfessionalRacer) ? 1.2 : 1.1);
            return $"{racerOne.Username} has just raced against {racerTwo.Username}! {(racerOneChance> racerTwoChance?racerOne.Username:racerTwo.Username)} is the winner!";
        }
    }
}
