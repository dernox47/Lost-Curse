using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            int currentX = 0;
            int currentY = 0;
            string[,] grid = new string[Convert.ToInt32(Math.Ceiling(Stock.Count / 3.0)), 3];

            int gridX = 0;
            int gridY = 0;
            foreach (KeyValuePair<IItem, int> item in Stock)
            {
                grid[gridY, gridX] = $"{item.Key.Name}({item.Value}) {item.Key.Value} gold";
                gridX++;
                if (gridX % 3 == 0)
                {
                    gridY++;
                    gridX = 0;
                }
            }


            if (Stock.Count % 3 != 0)
            {
                if (Stock.Count % 3 == 1)
                {
                    grid[Stock.Count / 3, 1] = " ";
                    grid[Stock.Count / 3, 2] = " ";
                }
                else if (Stock.Count % 3 == 2)
                {
                    grid[Convert.ToInt32(Math.Ceiling(Stock.Count / 3.0) - 1), 2] = " ";
                }
            }

            while (true)
            {
                Console.Clear();

                int count = 0;
                for (int y = 0; y < Convert.ToInt32(Math.Ceiling(Stock.Count / 3.0)); y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        if (count == 0)
                        {
                            Console.WriteLine(new string('=', 80));
                        }

                        Console.BackgroundColor = (y == currentY && x == currentX) ? ConsoleColor.White : ConsoleColor.Black;
                        Console.ForegroundColor = (y == currentY && x == currentX) ? ConsoleColor.Black : ConsoleColor.White;

                        Console.Write(grid[y, x]);
                        Console.ResetColor(); 
                        count++;

                        if (count % 3 == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine(new string('=', 80));
                        }
                        else Console.Write("\t\t");
                    }
                }
                Console.WriteLine();
                

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                ConsoleKey keyPressed = keyInfo.Key;

                switch (keyPressed)
                {
                    case ConsoleKey.LeftArrow:
                        if (currentX > 0)
                        {
                            currentX--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (currentX < 3 - 1 && grid[currentY, currentX + 1] != " ")
                        {
                            currentX++;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (currentY > 0)
                        {
                            currentY--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentY < Convert.ToInt32(Math.Ceiling(Stock.Count / 3.0)) - 1 && grid[currentY + 1, currentX] != " ")
                        {
                            currentY++;
                        }
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            }
        }
    }
}
