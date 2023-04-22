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
            inventory.AddItem("alma");
            inventory.AddItem("poti");
            inventory.AddItem("kard");
            Console.WriteLine(inventory.OpenInventory());

            Console.ReadKey();
        }
    }
}
