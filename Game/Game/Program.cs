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
            MainGame game = new MainGame();
            game.Start();

            Console.Write("Add meg a játékos neved: ");
            string name = Console.ReadLine();

            Player player = new Player(name);
            Enemy enemy = new Enemy("Goblin", 50, 50, 10, 0, 1, 20, 5);

            Console.WriteLine();
            Console.WriteLine(player.ToString());
            Console.WriteLine();
            Console.WriteLine(enemy.ToString());
            Console.WriteLine();

            while (player.IsAlive() && enemy.IsAlive())
            {
                player.Attack(enemy);
                Console.WriteLine($"Támadtál:\n" +
                    $"{player.Name} ({player.Hp}/{player.MaxHp})\t{enemy.Name} ({enemy.Hp}/{enemy.MaxHp})");

                enemy.Attack(player);
                Console.WriteLine($"Támadott a(z) {enemy.Name}:\n" +
                    $"{player.Name} ({player.Hp}/{player.MaxHp})\t{enemy.Name} ({enemy.Hp}/{enemy.MaxHp})\n");

                if (!enemy.IsAlive())
                {
                    Console.WriteLine($"Nyertél! A(z) {enemy.Name} meghalt.");
                }
                else if (!player.IsAlive())
                {
                    Console.WriteLine("Vesztettél.");
                }
            }



            Console.ReadKey();
        }
    }
}
