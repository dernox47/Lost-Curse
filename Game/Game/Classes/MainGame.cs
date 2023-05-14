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
            Enemy enemy;
            TextHandler story = new TextHandler("storyTexts.txt");

            //story.Print("BackgroundStory");
            //story.Print("GuildStart");

            Movement movement;
            movement = new Movement(0, 0);







            enemy = new Enemy("Goblin", 50, 50, 10, 0, 1, 20, 5);

            int enemyX = Console.WindowWidth - 10;
            int enemyY = Console.WindowHeight / 2;

            Console.SetCursorPosition(enemyX, enemyY);
            Console.WriteLine(@"(*_*)");

            Battle battle = new Battle(player, enemy);
            








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
