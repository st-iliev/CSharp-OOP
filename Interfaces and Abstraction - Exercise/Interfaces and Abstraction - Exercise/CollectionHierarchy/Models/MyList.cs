using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class MyList : IMyList

    {
        private readonly IList<string> collection;
        public MyList()
        {
            this.collection = new List<string>();
        }
        public int Used { get { return collection.Count; } }

        public int AddItem(string item)
        {
            collection.Insert(0, item);
            return 0;
        }

        public string RemoveItem()
        {
            string firstElement = collection[0];
            collection.RemoveAt(0);
            return firstElement;

        }
    }
}
