using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private  ICollection<Item> items;
        public Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }
        public int Capacity { get;  set; } = 100;

        public int Load => Items.Select(s => s.Weight).Sum();

        public IReadOnlyCollection<Item> Items => (IReadOnlyCollection<Item>)items;

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            else
            {
                items.Add(item);
            }
        }

        public Item GetItem(string name)
        {
           if (!items.Any())
            {
                throw new InvalidOperationException("Bag is empty!");
            }
           if (!items.Any(s=>s.GetType().Name == name))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            Item item = items.FirstOrDefault(s => s.GetType().Name == name);
            items.Remove(item);
            return item;
        }
    }
}
