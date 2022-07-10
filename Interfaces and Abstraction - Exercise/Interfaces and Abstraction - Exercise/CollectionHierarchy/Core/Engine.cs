using CollectionHierarchy.Interfaces;
using CollectionHierarchy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int number = int.Parse(Console.ReadLine());
            IAddCollection adCollection = new AddCollection();
            IAddRemoveCollection adReCollection = new AddRemoveCollection();
            IMyList listCollection = new MyList();
            AddToCollection(adCollection, input);
            AddToCollection(adReCollection, input);
            AddToCollection(listCollection, input);
            RevemoFromCollection(adReCollection, number);
            RevemoFromCollection(listCollection, number);
        }
        private static void AddToCollection(IAddCollection collection, string[] input)
        {
            foreach (var item in input)
            {
                Console.Write(collection.AddItem(item) + " ");
            }
            Console.WriteLine();
        }
        private static void RevemoFromCollection(IAddRemoveCollection collection, int number)
        {
            for (int i = 0; i < number; i++)
            {
                Console.Write(collection.RemoveItem() + " ");
            }
            Console.WriteLine();
        }
    }
}
