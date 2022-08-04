using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private ICollection<IWeapon> models;

        public WeaponRepository() : base()
        {
            models = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => (IReadOnlyCollection<IWeapon>)models;

        public void Add(IWeapon model)
        {
            if (models.Any(s => s.Name == model.Name))
            {
                throw new InvalidOperationException($"The weapon {model.Name} already exists.");
            }
            models.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            var weapon = models.FirstOrDefault(s => s.Name == name);
            if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon {name} does not exist.");
            }
            return weapon;
        }

        public bool Remove(IWeapon model)
        {
            var weaponToRemove = models.FirstOrDefault(s => s.Name == model.Name);

            if (weaponToRemove != null)
            {
                var index = models.Remove(model);
                return true;
            }
            return false;
        }

    }
}
