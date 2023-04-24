using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces.Characters;
using Game.Interfaces.Items;
using Game.Interfaces.Other;
using Game.Classes;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            inventory.AddItem("alma", 3);
            inventory.AddItem("poti", 4);
            inventory.AddItem("kard");
            inventory.OpenInventory();
            Console.WriteLine();
            inventory.RemoveItem("poti", 2);
            inventory.RemoveItem("kard");
            inventory.OpenInventory();



            Console.ReadKey();
        }
    }
}
