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
            //--------Eszköztár teszt------
            //Inventory inventory = new Inventory();
            //inventory.AddItem("alma", 3);
            //inventory.AddItem("poti", 4);
            //inventory.AddItem("kard");
            //inventory.OpenInventory();
            //inventory.RemoveItem("poti", );
            //inventory.RemoveItem("kard");
            //inventory.OpenInventory();


            //MainGame game = new MainGame();
            //game.Start();

            Movement player = new Movement(0, 0);

            while (true)
            {
                Console.CursorVisible = false;

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        player.MoveLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        player.MoveRight();
                        break;
                    case ConsoleKey.UpArrow:
                        player.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        player.MoveDown();
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
