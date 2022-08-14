using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private ICollection<IWeapon> models;

        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => (IReadOnlyCollection<IWeapon>)models;

        public void AddItem(IWeapon model) => models.Add(model);

        public IWeapon FindByName(string name) => models.FirstOrDefault(s => s.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            IWeapon weapon = models.FirstOrDefault(s => s.GetType().Name == name);
            return models.Remove(weapon);

        }

    }
}
