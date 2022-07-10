using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private readonly IList<string> collection;
        public AddRemoveCollection()
        {
            this.collection = new List<string>();
        }
        public int AddItem(string item)
        {
            collection.Insert(0, item);
            return 0;
        }

        public string RemoveItem()
        {
            string lastElement = collection[collection.Count - 1];
            collection.Remove(lastElement);
            return lastElement;
        }
    }
}
