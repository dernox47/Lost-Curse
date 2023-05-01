using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces.Characters;
using Game.Interfaces.Items;
using Game.Interfaces.Other;
using Game.Classes.Items;
using Game.Classes;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            //--------Eszköztár teszt------
            //Inventory inventory = new Inventory();

            Apple apple = new Apple();
            Bread bread = new Bread();
            HpPotion hpPotion = new HpPotion();

            //inventory.AddItem(apple, 3);
            //inventory.AddItem(bread, 4);
            //inventory.AddItem(hpPotion, 1);
            //Console.WriteLine(inventory.Current);
            //inventory.OpenInventory();
            //Console.WriteLine();
            //inventory.RemoveItem(bread, 2);
            //inventory.RemoveItem(hpPotion);
            //Console.WriteLine(inventory.Current);
            //inventory.OpenInventory();

            //---------Bolt teszt---------
            //Dictionary<IItem, int> itemPrices = new Dictionary<IItem, int>()
            //{
            //    { apple, 10 },
            //    { bread, 10 },
            //    { hpPotion, 50 }
            //};

            //Dictionary<IItem, int> initialStock = new Dictionary<IItem, int>()
            //{
            //    { apple, 5 },
            //    { bread, 6 },
            //    { hpPotion, 4 }
            //};

            //Player player = new Player();
            //Shop shop = new Shop(itemPrices, initialStock, player);

            //Console.WriteLine(player.Gold);
            //player.inventory.OpenInventory();

            //shop.BuyItem(apple, 2);

            //Console.WriteLine(player.Gold);
            //player.inventory.OpenInventory();

            //shop.SellItem(apple, 1);
            //Console.WriteLine(player.Gold);
            //player.inventory.OpenInventory();
            //shop.SellItem(apple, 1);
            //Console.WriteLine(player.Gold);
            //player.inventory.OpenInventory();


            MainGame game = new MainGame();
            game.Start();



            Console.ReadKey();
        }
    }
}
