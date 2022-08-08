using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private ICollection<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models => (IReadOnlyCollection<IFormulaOneCar>)models;

        public void Add(IFormulaOneCar model) => models.Add(model);

        public IFormulaOneCar FindByName(string name) => models.FirstOrDefault(s => s.Model == name);
       

        public bool Remove(IFormulaOneCar model) => models.Remove(model);
       
    }
}
