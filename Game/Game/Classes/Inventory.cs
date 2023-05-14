using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces;
using Game.Interfaces.Items;
using Game.Interfaces.Other;

namespace Game.Classes
{
    class Inventory
    {
        private static int max = 15;
        private int current;
        public Dictionary<IItem, int> items;

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
            items = new Dictionary<IItem, int>();
        }
        public void AddItem(IItem item, int amount = 1) {

            if (current <= max)
            {
                if (items.ContainsKey(item))
                {
                    items[item] += amount;
                }
                else
                {
                    current++;
                    items[item] = amount;
                }
            }
            else
            {
                Console.WriteLine("Your Inventory is full!");
            }
        }

        public void RemoveItem(IItem item, int amount = 1)
        {
            items[item] -= amount;
            if (items[item] <= 0)
            {
                current--;
                items.Remove(item);
            }
        }
        public void OpenInventory()
        {
            if (current == 0)
            {
                Console.WriteLine("Your Inventory is empty");
            }
            else
            {
                int count = 0;
                foreach (KeyValuePair<IItem, int> item in items)
                {
                    Console.Write($"{item.Key.Name} ({item.Value})");
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
}
