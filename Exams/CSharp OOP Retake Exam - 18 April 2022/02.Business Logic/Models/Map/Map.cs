using Heroes.Models.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Heroes.Models.Heroes;

namespace Heroes.Models.Map
{
    public class Map
    {
        public string Fight(ICollection<IHero> heroes)
        {
           List<IHero> barbarians = new List<IHero>();
            List<IHero> knights = new List<IHero>();
           
            foreach (var hero in heroes.Where(s=>s.IsAlive == true))
            {
                if (hero.GetType().Name == nameof(Barbarian) && hero.Weapon != null )
                {
                    barbarians.Add(hero);
                }
                else if (hero.GetType().Name == nameof(Knight) && hero.Weapon != null)
                {
                    knights.Add(hero);
                }
            }
            int barbariansCount = barbarians.Count;
            int knightsCount = knights.Count;
            while (barbarians.Count > 0 && knights.Count > 0)
            {
                foreach (var knight in knights)
                {
                    foreach (var barbarian in barbarians)
                    {
                        if (barbarian.Health > 0)
                        {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                        }
                    }
                }
                barbarians = barbarians.Where(s => s.Health > 0).ToList();
                if (barbarians.Count == 0)
                {
                    break;
                }
                foreach (var barbarian in barbarians)
                {
                    foreach (var knight in knights)
                    {
                        if (knight.Health > 0)
                        {
                           
                        knight.TakeDamage(barbarian.Weapon.DoDamage());
                        }
                    }
                }
                knights = knights.Where(s => s.Health > 0).ToList();
            }
            if (knights.Count > 0)
            {
                return $"The knights took {knightsCount - knights.Count} casualties but won the battle.";
            }
            else
            {
                return $"The barbarians took {barbariansCount - barbarians.Count} casualties but won the battle.";
            }
        }
    }
}
