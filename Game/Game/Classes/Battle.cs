using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes
{
    class Battle
    {
        public Player Player { get; set; }
        public Enemy Enemy { get; set; }

        public Battle(Player player, Enemy enemy)
        {
            Player = player;
            Enemy = enemy;
        }

        public void Begin()
        {
            while (Player.IsAlive() && Enemy.IsAlive())
            {
                Player.Attack(Enemy);
                Console.WriteLine($"Támadtál:\n" +
                    $"{Player.Name} ({Player.Hp}/{Player.MaxHp})\t{Enemy.Name} ({Enemy.Hp}/{Enemy.MaxHp})");
                if (!Enemy.IsAlive())
                {
                    Console.WriteLine($"Nyertél! A(z) {Enemy.Name} meghalt.");
                    break;
                }

                Enemy.Attack(Player);
                Console.WriteLine($"Támadott a(z) {Enemy.Name}:\n" +
                    $"{Player.Name} ({Player.Hp}/{Player.MaxHp})\t{Enemy.Name} ({Enemy.Hp}/{Enemy.MaxHp})\n");
                if (!Player.IsAlive())
                {
                    Console.WriteLine("Vesztettél.");
                    break;
                }
            }
        }

    }
}
