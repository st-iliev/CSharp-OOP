using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddCollection : IAddCollection
    {
        private readonly ICollection<string> collectiong;

        public AddCollection()
        {
            this.collectiong = new List<string>();
        }

        public int AddItem(string item)
        {
            collectiong.Add(item);
            return collectiong.Count - 1;
        }
    }
}
