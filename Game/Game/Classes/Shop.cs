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
        public Dictionary<IItem, int> Prices { get; set; }
        public Dictionary<IItem, int> Stock { get; set; }
        private Player player;

        public Shop(Dictionary<IItem, int> itemPrices, Dictionary<IItem, int> initialStock, Player player, string name = "Bolt", string description = "Ez egy bolt.")
        {
            Prices = itemPrices;
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

            int totalPrice = Prices[item] * quantity;
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

            int totalPrice = Prices[item] * quantity;
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
    }
}
