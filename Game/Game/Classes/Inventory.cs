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
        private string[] items;

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
        public string[] Items
        { 
            get { return items; } 
        }
        public Inventory()
        {
            current = 0;
            items = new string[max];
        }
        public void AddItem(string item)
        {
            items.Append(item);
        }
        public void RemoveItem(string item)
        {
            for (int i = 0; i > max; i++)
            {
                if (items[i] == item)
                {
                    items[i] = null;
                }
            }
        }
        public string OpenInventory()
        {
            return $"[ {items[0]} ] [ {items[1]} ] [ {items[2]} ] [ {items[3]} ] [ {items[4]} ]\n" +
                $"[ {items[5]} ] [ {items[6]} ] [ {items[7]} ] [ {items[8]} ] [ {items[9]} ]\n" +
                $"[ {items[10]} ] [ {items[11]} ] [ {items[12]} ] [ {items[13]} ] [ {items[14]} ]\n";
        }
    }
}
