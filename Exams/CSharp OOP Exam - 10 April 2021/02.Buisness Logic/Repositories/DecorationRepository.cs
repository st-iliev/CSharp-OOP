﻿using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private ICollection<IDecoration> models;

        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }
        public IReadOnlyCollection<IDecoration> Models => (IReadOnlyCollection<IDecoration>)models;

        public void Add(IDecoration model) =>models.Add(model);

        public IDecoration FindByType(string type) => models.FirstOrDefault(s => s.GetType().Name == type);
        
        public bool Remove(IDecoration model) => models.Remove(model);
        
    }
}
