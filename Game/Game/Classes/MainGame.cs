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
        public void Start()
        {
            Console.WriteLine("Lost Curse\n");

            Console.Write("Add meg a játékos neved: ");
            string name = Console.ReadLine();

            Player player = new Player(name);
            Enemy enemy = new Enemy("Goblin", 50, 50, 10, 0, 1, 20, 5);

            Console.WriteLine();
            Console.WriteLine(player.ToString());
            Console.WriteLine();
            Console.WriteLine(enemy.ToString());
            Console.WriteLine();

            Battle battle = new Battle(player, enemy);
            battle.Begin();
        }

        public void End()
        {
            Console.WriteLine("Bye.");
        }
    }
}
