using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces.Other;

namespace Game.Classes
{
    class MainGame : IGame
    {
        private static string title = @"

    __               __     ______                   
   / /   ____  _____/ /_   / ____/_  _______________ 
  / /   / __ \/ ___/ __/  / /   / / / / ___/ ___/ _ \
 / /___/ /_/ (__  ) /_   / /___/ /_/ / /  (__  )  __/
/_____/\____/____/\__/   \____/\__,_/_/  /____/\___/ 
                                                     
                                                                                                 
";

        public void Start()
        {
            Console.WriteLine(title);

            Console.Write("Add meg a játékos neved: ");
            string name = Console.ReadLine();
            Console.Clear();

            Player player = new Player(name);
            Enemy enemy = new Enemy("Goblin", 50, 50, 10, 0, 1, 20, 5);

            Movement movement = new Movement(0, 0);

            int enemyX = Console.WindowWidth - 10;
            int enemyY = Console.WindowHeight / 2;

            Console.SetCursorPosition(enemyX, enemyY);
            Console.WriteLine(@"(*_*)");

            Battle battle = new Battle(player, enemy);
            while (true)
            {
                Console.CursorVisible = false;

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        movement.MoveLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        movement.MoveRight();
                        break;
                    case ConsoleKey.UpArrow:
                        movement.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        movement.MoveDown();
                        break;
                }
                if (movement.x == enemyX && movement.y == enemyY)
                {
                    battle.Begin();
                    break;
                }
            }



            

            

            //Console.WriteLine();
            //Console.WriteLine(player2.ToString());
            //Console.WriteLine();
            //Console.WriteLine(enemy.ToString());
            //Console.WriteLine();

            
        }

        public void End()
        {
            Console.WriteLine("Bye.");
        }
    }
}
