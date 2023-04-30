using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces;
using Game.Interfaces.Items;
using Game.Other.Interfaces;

namespace Game.Classes
{
    class Inventory
    {
        private static int max = 15;
        private int current;
        private Dictionary<string, int> items;

        public int Current
        {
            get { return current; }
            set
            {
                if (value <= max || value >= 0)
                {
                    Current = value;
                }
                else if (value > max)
                {
                    Current = max;
                }
                else
                {
                    Current = 0;
                }
            }
        }

        public Inventory()
        {
            current = 0;
            items = new Dictionary<string, int>();
        }
        public void AddItem(string item, int amount = 1) {

            if (current <= max)
            {
                current++;
                if (items.ContainsKey(item))
                {
                    items[item] += amount;
                }
                else
                {
                    items.Add(item, amount);
                }
            }
            else
            {
                Console.WriteLine("Az eszköztár be van telve!");
            }
        }
        public void RemoveItem(string item, int amount = 1)
        {
            items[item] -= amount;
            if (items[item] <= 0)
            {
                items.Remove(item);
            }
        }
        public void OpenInventory()
        {
            int count = 0;
            foreach (KeyValuePair<string, int> item in items)
            {
                Console.Write($"{item.Key} ({item.Value})");
                count++;
                if (count % 5 == 0)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("\t");
                }
            }
            Console.WriteLine();
        }
    }
}
