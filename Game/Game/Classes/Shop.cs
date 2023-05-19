using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces.Items;
using Game.Interfaces.Other;

namespace Game.Classes
{
    class Shop : IShop
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<IItem, int> Stock { get; set; }
        private Player player;

        public Shop(Dictionary<IItem, int> initialStock, Player player, string name = "Shop", string description = "This is a shop.")
        {
            Stock = initialStock;
            Name = name;
            Description = description;
            this.player = player;
        }

        public void BuyItem(IItem item, int quantity)
        {
            if (!Stock.ContainsKey(item) || Stock[item] < quantity)
            {
                Console.WriteLine("There isn't enough in the shop.");
                return;
            }

            int totalPrice = item.Value * quantity;
            if (player.Gold < totalPrice)
            {
                Console.WriteLine("You don't have enough gold.");
                return;
            }

            player.Gold -= totalPrice;
            player.inventory.AddItem(item, quantity);

            Stock[item] -= quantity;
            Console.WriteLine($"Added to your inventory: {quantity} {item.Name}");
        }

        public void SellItem(IItem item, int quantity)
        {
            if (!player.inventory.items.ContainsKey(item) || player.inventory.items[item] < quantity)
            {
                Console.WriteLine("You dont have enough in your inventory.");
                return;
            }

            int totalPrice = item.Value * quantity;
            player.Gold += totalPrice;

            player.inventory.RemoveItem(item, quantity);

            if (Stock.ContainsKey(item))
            {
                Stock[item] += quantity;
            }
            else
            {
                Stock[item] = quantity;
            }

            Console.WriteLine($"You sold {quantity} {item.Name}");
        }

        public void Open()
        {
            int count = 0;
            
            foreach (KeyValuePair<IItem, int> item in Stock)
            {
                if (count == 0)
                {
                    Console.WriteLine(new string('=', 80));
                }
                Console.Write($"{item.Key.Name}({item.Value}) {item.Key.Value} gold");

                count++;
                if (count % 3 == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine(new string('=', 80));
                }
                else Console.Write("\t\t");
            }
            Console.WriteLine();
            if (count > 3)
            {
                Console.WriteLine(new string('=', 80));
            }
        }
    }
}
