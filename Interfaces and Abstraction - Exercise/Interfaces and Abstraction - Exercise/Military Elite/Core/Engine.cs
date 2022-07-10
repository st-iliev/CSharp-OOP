using MilitaryElite.Models;
using MilitaryElite.Models.Enums;
using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private Dictionary<int, ISoldier> soldiers;

        public Engine()
        {
            this.soldiers = new Dictionary<int, ISoldier>();
        }

        public void Run()
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                try
                {  
                    string result = this.ReadInput(input);

                    Console.WriteLine(result);
                }
                catch (Exception) {}

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
        public string ReadInput(string[] input)
        {
            string rank = input[0];
            int id = int.Parse(input[1]);
            string firstName = input[2];
            string lastName = input[3];
            ISoldier soldier = null;
            if (rank == "Private")
            {
                decimal salary = decimal.Parse(input[4]);
                soldier = new Private(id, firstName, lastName, salary);
            }
            else if (rank == "LieutenantGeneral")
            {
                decimal salary = decimal.Parse(input[4]);
                Dictionary<int, IPrivate> privates = new Dictionary<int, IPrivate>();
                for (int i = 5; i < input.Length; i++)
                {
                    int soldierId = int.Parse(input[i]);
                    IPrivate currentSoldier = (IPrivate)soldiers[soldierId];
                    privates.Add(soldierId, currentSoldier);
                }
                soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
            }
            else if (rank == "Engineer")
            {
                decimal salary = decimal.Parse(input[4]);
                bool validCorps = Enum.TryParse<Corps>(input[5], out Corps corps);
                
                if (!validCorps)
                {
                    throw new Exception();
                }
                ICollection<IRepair> repairs = new List<IRepair>();
                for (int i = 6; i < input.Length; i+=2)
                {
                    string repairPart = input[i];
                    int repairHours = int.Parse(input[i + 1]);
                    IRepair repair = new Repair(repairPart, repairHours);
                    repairs.Add(repair);
                }
                soldier = new Engineer(id,firstName,lastName,salary,corps,repairs);
            }
            else if (rank == "Commando")
            {
                decimal salary = decimal.Parse(input[4]);
                bool validCorps = Enum.TryParse<Corps>(input[5], out Corps corps);

                if (!validCorps)
                {
                    throw new Exception();
                }
                ICollection<IMission> missions = new List<IMission>();
                for (int i = 6; i < input.Length; i += 2)
                {
                    string missionName = input[i];
                    bool validMissionState = Enum.TryParse<State>(input[i + 1], out State missionState);

                    if (!validMissionState)
                    {
                        continue;
                    }
                    IMission mission = new Mission(missionName, missionState);
                    missions.Add(mission);
                }
                soldier = new Commando(id, firstName, lastName, salary, corps, missions);
            }
            else if (rank == "Spy")
            {
                int codeNumber = int.Parse(input[4]);
                soldier = new Spy(id,firstName,lastName,codeNumber);
            }
            soldiers.Add(id, soldier);

            return soldier.ToString();
        }
    }
}
