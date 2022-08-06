using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private ICollection<ICar> models;
        public CarRepository()
        {
            this.models = new List<ICar>();
        }
        public IReadOnlyCollection<ICar> Models => (IReadOnlyCollection<ICar>)models;
        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Car Repository");
            }
            models.Add(model);
        }

        public ICar FindBy(string property) => models.FirstOrDefault(s => s.VIN == property);
      

        public bool Remove(ICar model) => models.Remove(model);
       
    }
}
